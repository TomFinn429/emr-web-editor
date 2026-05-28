import { beforeEach, describe, expect, it, vi } from 'vitest'
import { fetchTemplates } from './templateService'
import {
  batchUploadTemplates,
  beginTemplateUpload,
  cancelTemplateUpload,
  completeTemplateUpload,
  createTemplateDirectory,
  createTemplateFile,
  fetchTemplateWorkbenchData,
  filterTemplateTree,
  findTemplateTreeNode,
  getTemplateContent,
  getTemplateHistoryVersions,
  openTemplateContent,
  renameTemplateDirectory,
  renameTemplateFile,
  requestTemplateUpload,
  resetTemplateWorkbenchState,
  saveTemplateAsContent,
  saveTemplateContent,
  deleteTemplateDirectory,
  deleteTemplateFile,
} from './templateWorkbenchService'

vi.mock('./templateService', () => ({
  fetchTemplates: vi.fn(),
  fetchTemplateContent: vi.fn(async (id: string) => ({
    id,
    name: id,
    fileName: `${id}.xml`,
    category: '本地模板',
    xml: `<XTextDocument><Body>${id}</Body></XTextDocument>`,
  })),
}))

const localTemplates = [
  {
    id: 'ICU手术患者交接记录单',
    name: 'ICU手术患者交接记录单',
    fileName: 'ICU手术患者交接记录单.xml',
    category: '本地模板',
  },
  {
    id: '入院告知书',
    name: '入院告知书',
    fileName: '入院告知书.xml',
    category: '本地模板',
  },
  {
    id: '西医病案首页',
    name: '西医病案首页',
    fileName: '西医病案首页.xml',
    category: '本地模板',
  },
]

describe('templateWorkbenchService', () => {
  beforeEach(async () => {
    vi.mocked(fetchTemplates).mockResolvedValue(localTemplates)
    resetTemplateWorkbenchState()
    await fetchTemplateWorkbenchData()
  })

  it('returns workbench data from the configured XML template list', async () => {
    const data = await fetchTemplateWorkbenchData()

    expect(data.templateTree[0]?.label).toBe('D:\\XML\\notes')
    expect(data.templateTree[0]?.children?.[0]?.label).toBe('本地模板')
    expect(data.templateTree[0]?.children?.[0]?.children?.map(node => node.label)).toEqual([
      'ICU手术患者交接记录单',
      '入院告知书',
      '西医病案首页',
    ])
    expect(data.categories).toEqual(['全部分类', '本地模板'])
    expect(data.activeTemplateId).toBe('ICU手术患者交接记录单')
    expect(data.metadataItems.map(item => item.name)).toEqual(expect.arrayContaining(['患者姓名', '入院日期']))
    expect(data.fragmentTemplates.map(item => item.name)).toEqual(expect.arrayContaining(['通用入院主诉']))
    expect(data.templateProperties.status).toBe('未上传')
    expect(data.elementProperties).toMatchObject({
      type: 'none',
      name: '未选择元素',
    })
  })

  it('filters template tree by category and keyword while preserving ancestors', async () => {
    const { templateTree } = await fetchTemplateWorkbenchData()
    const filtered = filterTemplateTree(templateTree, {
      category: '本地模板',
      keyword: '西医',
    })

    expect(filtered).toHaveLength(1)
    expect(filtered[0]?.label).toBe('D:\\XML\\notes')
    expect(filtered[0]?.children?.[0]?.label).toBe('本地模板')
    expect(filtered[0]?.children?.[0]?.children?.map(node => node.label)).toEqual([
      '西医病案首页',
    ])
  })

  it('returns target-page template scopes and filters tree by scope', async () => {
    const data = await fetchTemplateWorkbenchData()

    expect(data.templateScopes.map(scope => scope.label)).toEqual(['全局', '全院', '科室', '个人'])
    expect(data.templateScopes[0]).toMatchObject({ id: 'global', label: '全局' })

    const departmentOnly = filterTemplateTree(data.templateTree, {
      category: '全部分类',
      keyword: '',
      scope: 'department',
    })
    const visibleTemplates = departmentOnly.flatMap(root =>
      (root.children || []).flatMap(category => category.children || []),
    )

    expect(visibleTemplates.map(node => node.label)).toEqual(['入院告知书'])
    expect(visibleTemplates.every(node => node.scope === 'department')).toBe(true)
    expect(filterTemplateTree(data.templateTree, {
      category: '全部分类',
      keyword: '',
      scope: 'personal',
    })).toEqual([])
  })

  it('creates new directories and templates inside the selected template scope', async () => {
    const directory = createTemplateDirectory('template-root', '科室专用目录', 'department')
    const template = createTemplateFile(directory.id, '科室随访记录', '<XTextDocument />', 'department')
    const data = await fetchTemplateWorkbenchData(template.id)
    const departmentOnly = filterTemplateTree(data.templateTree, {
      category: '全部分类',
      keyword: '科室随访',
      scope: 'department',
    })
    const personalOnly = filterTemplateTree(data.templateTree, {
      category: '全部分类',
      keyword: '科室随访',
      scope: 'personal',
    })

    expect(directory.scope).toBe('department')
    expect(template.scope).toBe('department')
    expect(findTemplateTreeNode(departmentOnly, template.id)?.label).toBe('科室随访记录')
    expect(findTemplateTreeNode(personalOnly, template.id)).toBeNull()
  })

  it('returns an empty tree when no keyword matches', async () => {
    const { templateTree } = await fetchTemplateWorkbenchData()

    expect(filterTemplateTree(templateTree, { category: '全部分类', keyword: '不存在模板' })).toEqual([])
  })

  it('finds template file nodes by id', async () => {
    const { templateTree } = await fetchTemplateWorkbenchData()

    expect(findTemplateTreeNode(templateTree, '西医病案首页')?.label).toBe('西医病案首页')
    expect(findTemplateTreeNode(templateTree, 'missing')).toBeNull()
  })

  it('returns active template linked properties and history versions', async () => {
    const data = await fetchTemplateWorkbenchData('西医病案首页')

    expect(data.activeTemplateId).toBe('西医病案首页')
    expect(data.templateProperties.id).toBe('西医病案首页')
    expect(data.templateProperties.name).toBe('西医病案首页')
    expect(data.templateProperties).toMatchObject({
      type: '病案模板',
      printMode: '套打',
      allowRepeat: false,
      signLevel: '二级签名',
      departments: ['全院', '病案室'],
      author: '模板制作员',
      updatedBy: '模板制作员',
    })
    expect(data.historyVersions.length).toBeGreaterThan(0)
  })

  it('supports template directory and file CRUD through the service boundary', async () => {
    const directory = createTemplateDirectory('template-root', '测试目录')
    const template = createTemplateFile(directory.id, '新增模板', '<XTextDocument />')

    let data = await fetchTemplateWorkbenchData(template.id)
    expect(findTemplateTreeNode(data.templateTree, directory.id)?.label).toBe('测试目录')
    expect(findTemplateTreeNode(data.templateTree, template.id)?.label).toBe('新增模板')

    renameTemplateDirectory(directory.id, '重命名目录')
    data = await fetchTemplateWorkbenchData(template.id)
    expect(findTemplateTreeNode(data.templateTree, directory.id)?.label).toBe('重命名目录')

    renameTemplateFile(template.id, '重命名模板')
    data = await fetchTemplateWorkbenchData(template.id)
    expect(findTemplateTreeNode(data.templateTree, template.id)?.label).toBe('重命名模板')

    deleteTemplateFile(template.id)
    data = await fetchTemplateWorkbenchData()
    expect(findTemplateTreeNode(data.templateTree, template.id)).toBeNull()

    deleteTemplateDirectory(directory.id)
    data = await fetchTemplateWorkbenchData()
    expect(findTemplateTreeNode(data.templateTree, directory.id)).toBeNull()
  })

  it('opens template content and exposes open tabs through service state', async () => {
    const opened = await openTemplateContent('西医病案首页')
    const data = await fetchTemplateWorkbenchData('西医病案首页')

    expect(opened.id).toBe('西医病案首页')
    expect(opened.fileName).toBe('西医病案首页.xml')
    expect(data.openTabs.map(tab => tab.id)).toContain('西医病案首页')
    expect(data.openTabs[0]?.isDirty).toBe(false)
  })

  it('tracks save, save as, and history versions', async () => {
    const updated = saveTemplateContent(
      '西医病案首页',
      '<XTextDocument><A /></XTextDocument>',
      '西医病案首页.xml',
    )

    expect(updated.version).toBe('v1.1')

    const copied = saveTemplateAsContent(
      '西医病案首页',
      '西医病案首页-另存',
      '<XTextDocument><B /></XTextDocument>',
    )
    expect(copied.name).toBe('西医病案首页-另存')
    expect(getTemplateContent(copied.id)?.xml).toContain('<B />')

    const history = getTemplateHistoryVersions('西医病案首页')
    expect(history[0]?.note).toContain('保存')
    expect(history[0]?.version).toBe('v1.1')
  })

  it('walks upload states and supports cancellation and batch upload', async () => {
    requestTemplateUpload('入院告知书')
    expect((await fetchTemplateWorkbenchData('入院告知书')).templateProperties.status).toBe('待上传')

    beginTemplateUpload('入院告知书')
    expect((await fetchTemplateWorkbenchData('入院告知书')).templateProperties.status).toBe('上传中')

    cancelTemplateUpload('入院告知书')
    expect((await fetchTemplateWorkbenchData('入院告知书')).templateProperties.status).toBe('已取消')

    const uploadedIds = batchUploadTemplates(['入院告知书'])
    expect(uploadedIds).toEqual(['入院告知书'])

    completeTemplateUpload('入院告知书')
    expect((await fetchTemplateWorkbenchData('入院告知书')).templateProperties.status).toBe('已上传')
  })
})
