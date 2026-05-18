import { describe, expect, it } from 'vitest'
import {
  fetchTemplateWorkbenchData,
  filterTemplateTree,
  findTemplateTreeNode,
} from './templateWorkbenchService'

describe('templateWorkbenchService', () => {
  it('returns mock workbench data behind one service boundary', async () => {
    const data = await fetchTemplateWorkbenchData()

    expect(data.templateTree[0]?.label).toBe('和硕县人民医院')
    expect(data.metadataItems.map(item => item.name)).toEqual(expect.arrayContaining(['患者姓名', '入院日期']))
    expect(data.fragmentTemplates.map(item => item.name)).toEqual(expect.arrayContaining(['通用入院主诉']))
    expect(data.templateProperties.status).toBe('未上传')
    expect(data.elementProperties.type).toBe('未选择元素')
  })

  it('filters template tree by category and keyword while preserving ancestors', async () => {
    const { templateTree } = await fetchTemplateWorkbenchData()
    const filtered = filterTemplateTree(templateTree, {
      category: '病案首页',
      keyword: '西医',
    })

    expect(filtered).toHaveLength(1)
    expect(filtered[0]?.label).toBe('和硕县人民医院')
    expect(filtered[0]?.children?.[0]?.label).toBe('病案首页')
    expect(filtered[0]?.children?.[0]?.children?.map(node => node.label)).toEqual([
      '西医病案首页',
    ])
  })

  it('returns an empty tree when no keyword matches', async () => {
    const { templateTree } = await fetchTemplateWorkbenchData()

    expect(filterTemplateTree(templateTree, { category: '全部分类', keyword: '不存在模板' })).toEqual([])
  })

  it('finds template file nodes by id', async () => {
    const { templateTree } = await fetchTemplateWorkbenchData()

    expect(findTemplateTreeNode(templateTree, 'western-home')?.label).toBe('西医病案首页')
    expect(findTemplateTreeNode(templateTree, 'missing')).toBeNull()
  })
})
