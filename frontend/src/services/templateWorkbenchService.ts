import type { TemplateContent } from '../types/document'
import type { EditorElementProperties, FragmentTemplateTreeNode, MetadataTreeNode } from '../types/editorElement'
import { createDefaultElementProperties } from './elementPropertyService'
import { fetchFragmentTemplateTree, flattenFragmentTemplates } from './fragmentTemplateService'
import { fetchMetadataTree, flattenMetadataItems } from './metadataService'
import { fetchTemplateContent, fetchTemplates } from './templateService'
import type { TemplateSummary } from '../types/document'

export type TemplateTreeNodeKind = 'root' | 'category' | 'template'
export type TemplateUploadStatus = '已上传' | '未上传' | '待上传' | '上传中' | '已取消' | '上传失败'
export type TemplateScopeId = 'global' | 'hospital' | 'department' | 'personal'

export interface TemplateScopeOption {
  id: TemplateScopeId
  label: string
}

export interface TemplateTreeNode {
  id: string
  label: string
  kind: TemplateTreeNodeKind
  category?: string
  templateId?: string
  status?: TemplateUploadStatus
  scope?: TemplateScopeId
  children?: TemplateTreeNode[]
}

export interface MetadataItem {
  id: string
  name: string
  code: string
  valueType: string
}

export interface FragmentTemplate {
  id: string
  name: string
  category: string
}

export interface TemplateProperties {
  id: string
  name: string
  category: string
  status: TemplateUploadStatus
  version: string
  updatedAt: string
  fileName: string
  source: string
  isDirty: boolean
  uploadMessage: string
  scope: TemplateScopeId
  type: string
  printMode: string
  allowRepeat: boolean
  signLevel: string
  departments: string[]
  author: string
  updatedBy: string
}

export type ElementProperties = EditorElementProperties

export interface TemplateHistoryVersion {
  id: string
  templateId: string
  version: string
  savedAt: string
  operator: string
  note: string
}

export interface TemplateOpenTab {
  id: string
  name: string
  fileName: string
  isDirty: boolean
  status: TemplateUploadStatus
}

export interface TemplateWorkbenchData {
  templateTree: TemplateTreeNode[]
  categories: string[]
  metadataItems: MetadataItem[]
  metadataTree: MetadataTreeNode[]
  fragmentTemplates: FragmentTemplate[]
  fragmentTemplateTree: FragmentTemplateTreeNode[]
  templateScopes: TemplateScopeOption[]
  templateProperties: TemplateProperties
  elementProperties: ElementProperties
  historyVersions: TemplateHistoryVersion[]
  openTabs: TemplateOpenTab[]
  activeTemplateId: string
}

export interface TemplateTreeFilter {
  category: string
  keyword: string
  scope?: TemplateScopeId
}

interface TemplateRecord {
  id: string
  name: string
  fileName: string
  category: string
  status: TemplateUploadStatus
  version: string
  updatedAt: string
  source: string
  xml: string
  isDirty: boolean
  uploadMessage: string
  scope: TemplateScopeId
  type: string
  printMode: string
  allowRepeat: boolean
  signLevel: string
  departments: string[]
  author: string
  updatedBy: string
  contentTemplateId?: string
}

interface TemplateWorkbenchState {
  templateTree: TemplateTreeNode[]
  templates: Record<string, TemplateRecord>
  history: Record<string, TemplateHistoryVersion[]>
  openTabs: string[]
  activeTemplateId: string
  nextId: number
  hasLoadedRemoteTemplates: boolean
}

const today = '2026-05-18'
const defaultXml = '<XTextDocument><Body>新建模板</Body></XTextDocument>'
const templateRootId = 'template-root'
const templateRootLabel = 'D:\\XML\\notes'
const templateScopes: TemplateScopeOption[] = [
  { id: 'global', label: '全局' },
  { id: 'hospital', label: '全院' },
  { id: 'department', label: '科室' },
  { id: 'personal', label: '个人' },
]

const mockElementProperties = createDefaultElementProperties('none')

let state = createInitialState()

export function resetTemplateWorkbenchState() {
  state = createInitialState()
}

export async function fetchTemplateWorkbenchData(activeTemplateId?: string): Promise<TemplateWorkbenchData> {
  await ensureTemplateCatalog()
  const activeId = pickActiveTemplateId(activeTemplateId)
  const activeTemplate = state.templates[activeId]
  const metadata = await fetchMetadataTree()
  const fragments = await fetchFragmentTemplateTree()
  return {
    templateTree: cloneTree(state.templateTree),
    categories: ['全部分类', ...collectCategories(state.templateTree)],
    metadataItems: flattenMetadataItems(metadata.tree),
    metadataTree: metadata.tree,
    fragmentTemplates: flattenFragmentTemplates(fragments.tree),
    fragmentTemplateTree: fragments.tree,
    templateScopes: [...templateScopes],
    templateProperties: toTemplateProperties(activeTemplate),
    elementProperties: { ...mockElementProperties },
    historyVersions: getTemplateHistoryVersions(activeId),
    openTabs: state.openTabs.map(toOpenTab).filter((tab): tab is TemplateOpenTab => tab !== null),
    activeTemplateId: activeId,
  }
}

export async function openTemplateContent(id: string): Promise<TemplateContent> {
  const template = readTemplateRecord(id)
  const content = await readTemplateContent(template)
  ensureOpenTab(template.id)
  state.activeTemplateId = template.id
  return content
}

export function closeTemplateTab(id: string) {
  state.openTabs = state.openTabs.filter(tabId => tabId !== id)
  if (state.activeTemplateId === id) {
    state.activeTemplateId = state.openTabs[0] || firstTemplateId() || ''
  }
  return state.activeTemplateId
}

export function getTemplateContent(id: string): TemplateContent | null {
  const template = state.templates[id]
  return template ? toTemplateContent(template) : null
}

export function createTemplateDirectory(
  parentId: string,
  name: string,
  scope?: TemplateScopeId,
): TemplateTreeNode {
  const parent = readTreeNode(parentId)
  const node: TemplateTreeNode = {
    id: createId('directory'),
    label: normalizeName(name, '新建目录'),
    kind: 'category',
    category: normalizeName(name, '新建目录'),
    scope: scope || parent.scope,
    children: [],
  }
  parent.children = [...(parent.children || []), node]
  return cloneNode(node)
}

export function renameTemplateDirectory(id: string, name: string) {
  const node = readTreeNode(id)
  if (node.kind === 'template') {
    throw new Error('模板文件不能按目录重命名。')
  }

  node.label = normalizeName(name, node.label)
  node.category = node.label
  updateChildCategory(node, node.label)
  return cloneNode(node)
}

export function deleteTemplateDirectory(id: string) {
  const node = readTreeNode(id)
  if (node.kind === 'template') {
    throw new Error('模板文件不能按目录删除。')
  }
  if (node.kind === 'root') {
    throw new Error('根目录不能删除。')
  }

  for (const child of node.children || []) {
    removeTemplateRecords(child)
  }
  return removeTreeNode(id)
}

export function createTemplateFile(
  parentId: string,
  name: string,
  xml = defaultXml,
  scope?: TemplateScopeId,
): TemplateRecord {
  const parent = readTreeNode(parentId)
  if (parent.kind === 'template') {
    throw new Error('不能在模板文件下新建模板。')
  }

  const templateName = normalizeName(name, '新建模板')
  const id = createId('template')
  const category = parent.category || templateName
  const record: TemplateRecord = {
    id,
    name: templateName,
    fileName: ensureXmlFileName(templateName),
    category,
    status: '未上传',
    version: 'v1.0',
    updatedAt: today,
    source: 'local',
    xml,
    isDirty: true,
    uploadMessage: '尚未上传',
    scope: scope || parent.scope || 'personal',
    type: '病历模板',
    printMode: '普通打印',
    allowRepeat: true,
    signLevel: '一级签名',
    departments: ['个人模板'],
    author: '模板制作员',
    updatedBy: '模板制作员',
  }
  state.templates[id] = record
  state.history[id] = [historyVersion(record, '创建模板')]
  parent.children = [
    ...(parent.children || []),
    {
      id,
      label: templateName,
      kind: 'template',
      category,
      templateId: id,
      status: record.status,
      scope: record.scope,
    },
  ]
  ensureOpenTab(id)
  state.activeTemplateId = id
  return { ...record }
}

export function renameTemplateFile(id: string, name: string): TemplateRecord {
  const template = readTemplateRecord(id)
  template.name = normalizeName(name, template.name)
  template.fileName = ensureXmlFileName(template.name)
  template.isDirty = true
  template.updatedAt = today
  syncTemplateNode(template)
  return { ...template }
}

export function markTemplateDirty(id: string) {
  const template = state.templates[id]
  if (!template) {
    return null
  }
  template.isDirty = true
  template.uploadMessage = '存在未保存修改'
  ensureOpenTab(id)
  syncTemplateNode(template)
  return { ...template }
}

export function deleteTemplateFile(id: string) {
  readTemplateRecord(id)
  removeTreeNode(id)
  delete state.templates[id]
  delete state.history[id]
  state.openTabs = state.openTabs.filter(tabId => tabId !== id)
  if (state.activeTemplateId === id) {
    state.activeTemplateId = state.openTabs[0] || firstTemplateId() || ''
  }
  return true
}

export function saveTemplateContent(id: string, xml: string, fileName?: string): TemplateRecord {
  const template = readTemplateRecord(id)
  template.xml = xml
  template.fileName = fileName || template.fileName
  template.version = nextVersion(template.version)
  template.updatedAt = today
  template.isDirty = false
  template.status = template.status === '已上传' ? '待上传' : template.status
  template.uploadMessage = '已保存，等待上传'
  state.history[id] = [historyVersion(template, '保存模板内容'), ...(state.history[id] || [])]
  syncTemplateNode(template)
  ensureOpenTab(id)
  return { ...template }
}

export function saveTemplateAsContent(sourceId: string, name: string, xml: string): TemplateRecord {
  const source = readTemplateRecord(sourceId)
  const targetName = normalizeName(name, `${source.name}-另存`)
  const parent = findParentNode(sourceId) || readTreeNode(templateRootId)
  const copied = createTemplateFile(parent.id, targetName, xml)
  copied.isDirty = false
  copied.uploadMessage = '另存为模板，等待上传'
  state.templates[copied.id] = copied
  state.history[copied.id] = [historyVersion(copied, `从 ${source.name} 另存为`)]
  syncTemplateNode(copied)
  return { ...copied }
}

export function requestTemplateUpload(id: string) {
  return updateUploadStatus(id, '待上传', '已加入上传队列')
}

export function beginTemplateUpload(id: string) {
  return updateUploadStatus(id, '上传中', '正在上传')
}

export function cancelTemplateUpload(id: string) {
  return updateUploadStatus(id, '已取消', '已取消上传')
}

export function completeTemplateUpload(id: string) {
  const template = updateUploadStatus(id, '已上传', '上传完成')
  template.isDirty = false
  state.history[id] = [historyVersion(template, '上传模板'), ...(state.history[id] || [])]
  syncTemplateNode(template)
  return { ...template }
}

export function batchUploadTemplates(ids: readonly string[]) {
  return ids
    .filter(id => Boolean(state.templates[id]))
    .map((id) => {
      requestTemplateUpload(id)
      beginTemplateUpload(id)
      return id
    })
}

export function getTemplateHistoryVersions(id: string) {
  return [...(state.history[id] || [])]
}

export function filterTemplateTree(
  nodes: readonly TemplateTreeNode[],
  filter: TemplateTreeFilter,
): TemplateTreeNode[] {
  const keyword = filter.keyword.trim().toLocaleLowerCase()
  const category = filter.category === '全部分类' ? '' : filter.category
  const scope = filter.scope

  return nodes
    .map(node => filterNode(node, category, keyword, scope))
    .filter((node): node is TemplateTreeNode => node !== null)
}

export function findTemplateTreeNode(
  nodes: readonly TemplateTreeNode[],
  id: string,
): TemplateTreeNode | null {
  for (const node of nodes) {
    if (node.id === id) {
      return node
    }

    const found = findTemplateTreeNode(node.children || [], id)
    if (found) {
      return found
    }
  }

  return null
}

function createInitialState(): TemplateWorkbenchState {
  return {
    templateTree: emptyTemplateTree(),
    templates: {},
    history: {},
    openTabs: [],
    activeTemplateId: '',
    nextId: 1,
    hasLoadedRemoteTemplates: false,
  }
}

async function ensureTemplateCatalog() {
  if (state.hasLoadedRemoteTemplates) {
    return
  }

  const templates = await fetchTemplates()
  loadTemplateCatalog(templates)
}

function loadTemplateCatalog(summaries: readonly TemplateSummary[]) {
  const records = Object.fromEntries(
    summaries.map(summary => [summary.id, templateRecord(summary)]),
  )
  state.templates = records
  state.history = Object.fromEntries(
    Object.values(records).map(template => [
      template.id,
      [historyVersion(template, '从本地 XML 模板目录加载')],
    ]),
  )
  state.templateTree = buildTemplateTree(Object.values(records))
  state.activeTemplateId = firstTemplateId() || ''
  state.openTabs = state.activeTemplateId ? [state.activeTemplateId] : []
  state.hasLoadedRemoteTemplates = true
}

function buildTemplateTree(templates: readonly TemplateRecord[]): TemplateTreeNode[] {
  const root = emptyTemplateTree()[0]
  const categories = new Map<string, TemplateTreeNode>()

  for (const template of templates) {
    const categoryNode = readOrCreateCategoryNode(categories, template.category)
    categoryNode.children = [
      ...(categoryNode.children || []),
      {
        id: template.id,
        label: template.name,
        kind: 'template',
        category: template.category,
        templateId: template.id,
        status: template.status,
        scope: template.scope,
      },
    ]
  }

  root.children = [...categories.values()]
  return [root]
}

function readOrCreateCategoryNode(categories: Map<string, TemplateTreeNode>, category: string) {
  const existing = categories.get(category)
  if (existing) {
    return existing
  }

  const node: TemplateTreeNode = {
    id: `category-${category}`,
    label: category,
    kind: 'category',
    category,
    children: [],
  }
  categories.set(category, node)
  return node
}

function emptyTemplateTree(): TemplateTreeNode[] {
  return [
    {
      id: templateRootId,
      label: templateRootLabel,
      kind: 'root',
      children: [],
    },
  ]
}

function templateRecord(
  template: TemplateSummary,
  status: TemplateUploadStatus = '未上传',
): TemplateRecord {
  return {
    id: template.id,
    name: template.name,
    fileName: template.fileName,
    category: template.category,
    status,
    version: 'v1.0',
    updatedAt: today,
    source: template.category,
    xml: `<XTextDocument><Body>${template.name}</Body></XTextDocument>`,
    isDirty: false,
    uploadMessage: status === '已上传' ? '上传完成' : '尚未上传',
    scope: resolveTemplateScope(template),
    type: resolveTemplateType(template),
    printMode: resolvePrintMode(template),
    allowRepeat: !template.name.includes('首页'),
    signLevel: template.name.includes('首页') ? '二级签名' : '一级签名',
    departments: resolveDepartments(template),
    author: '模板制作员',
    updatedBy: '模板制作员',
    contentTemplateId: template.id,
  }
}

async function readTemplateContent(template: TemplateRecord): Promise<TemplateContent> {
  if (!template.contentTemplateId) {
    return toTemplateContent(template)
  }

  try {
    const content = await fetchTemplateContent(template.contentTemplateId)
    template.xml = content.xml
    return {
      id: template.id,
      name: template.name,
      fileName: template.fileName,
      category: template.category,
      xml: content.xml,
    }
  } catch {
    return toTemplateContent(template)
  }
}

function pickActiveTemplateId(activeTemplateId?: string) {
  if (activeTemplateId && state.templates[activeTemplateId]) {
    state.activeTemplateId = activeTemplateId
    return activeTemplateId
  }

  if (state.templates[state.activeTemplateId]) {
    return state.activeTemplateId
  }

  return firstTemplateId() || ''
}

function firstTemplateId() {
  return Object.keys(state.templates)[0]
}

function readTemplateRecord(id: string) {
  const template = state.templates[id]
  if (!template) {
    throw new Error('未找到指定模板。')
  }
  return template
}

function readTreeNode(id: string) {
  const node = findTemplateTreeNode(state.templateTree, id)
  if (!node) {
    throw new Error('未找到指定模板节点。')
  }
  return node
}

function toTemplateContent(template: TemplateRecord): TemplateContent {
  return {
    id: template.id,
    name: template.name,
    fileName: template.fileName,
    category: template.category,
    xml: template.xml,
  }
}

function toTemplateProperties(template: TemplateRecord): TemplateProperties {
  return {
    id: template.id,
    name: template.name,
    category: template.category,
    status: template.status,
    version: template.version,
    updatedAt: template.updatedAt,
    fileName: template.fileName,
    source: template.source,
    isDirty: template.isDirty,
    uploadMessage: template.uploadMessage,
    scope: template.scope,
    type: template.type,
    printMode: template.printMode,
    allowRepeat: template.allowRepeat,
    signLevel: template.signLevel,
    departments: [...template.departments],
    author: template.author,
    updatedBy: template.updatedBy,
  }
}

function toOpenTab(id: string): TemplateOpenTab | null {
  const template = state.templates[id]
  if (!template) {
    return null
  }
  return {
    id: template.id,
    name: template.name,
    fileName: template.fileName,
    isDirty: template.isDirty,
    status: template.status,
  }
}

function historyVersion(template: TemplateRecord, note: string): TemplateHistoryVersion {
  return {
    id: `${template.id}-${template.version}-${Date.now()}-${Math.round(Math.random() * 1000)}`,
    templateId: template.id,
    version: template.version,
    savedAt: `${template.updatedAt} 10:00`,
    operator: '模板制作员',
    note,
  }
}

function updateUploadStatus(id: string, status: TemplateUploadStatus, uploadMessage: string) {
  const template = readTemplateRecord(id)
  template.status = status
  template.uploadMessage = uploadMessage
  template.updatedAt = today
  syncTemplateNode(template)
  ensureOpenTab(id)
  return { ...template }
}

function ensureOpenTab(id: string) {
  if (!state.openTabs.includes(id)) {
    state.openTabs = [...state.openTabs, id]
  }
}

function removeTemplateRecords(node: TemplateTreeNode) {
  if (node.kind === 'template') {
    delete state.templates[node.id]
    delete state.history[node.id]
    state.openTabs = state.openTabs.filter(id => id !== node.id)
    return
  }

  for (const child of node.children || []) {
    removeTemplateRecords(child)
  }
}

function removeTreeNode(id: string) {
  const parent = findParentNode(id)
  if (!parent?.children) {
    return false
  }

  const before = parent.children.length
  parent.children = parent.children.filter(child => child.id !== id)
  return parent.children.length !== before
}

function findParentNode(id: string, nodes = state.templateTree, parent: TemplateTreeNode | null = null): TemplateTreeNode | null {
  for (const node of nodes) {
    if (node.id === id) {
      return parent
    }

    const found = findParentNode(id, node.children || [], node)
    if (found) {
      return found
    }
  }

  return null
}

function syncTemplateNode(template: TemplateRecord) {
  const node = findTemplateTreeNode(state.templateTree, template.id)
  if (!node) {
    return
  }

  node.label = template.name
  node.category = template.category
  node.status = template.status
  node.templateId = template.id
  node.scope = template.scope
}

function updateChildCategory(node: TemplateTreeNode, category: string) {
  for (const child of node.children || []) {
    child.category = category
    if (child.kind === 'template') {
      const template = state.templates[child.id]
      if (template) {
        template.category = category
      }
    }
    updateChildCategory(child, category)
  }
}

function filterNode(
  node: TemplateTreeNode,
  category: string,
  keyword: string,
  scope?: TemplateScopeId,
): TemplateTreeNode | null {
  const children = (node.children || [])
    .map(child => filterNode(child, category, keyword, scope))
    .filter((child): child is TemplateTreeNode => child !== null)

  const matchesCategory = !category || node.category === category || node.kind === 'root'
  const matchesKeyword = !keyword || node.label.toLocaleLowerCase().includes(keyword)
  const matchesScope = !scope || (node.kind === 'template' && node.scope === scope)
  const isMatch = matchesCategory && matchesKeyword && matchesScope

  if (isMatch || children.length > 0) {
    return { ...node, children }
  }

  return null
}

function collectCategories(nodes: readonly TemplateTreeNode[]) {
  const categories = new Set<string>()
  nodes.forEach((node) => {
    if (node.kind === 'category' && node.category) {
      categories.add(node.category)
    }
    collectCategories(node.children || []).forEach(category => categories.add(category))
  })
  return [...categories]
}

function cloneTree(nodes: readonly TemplateTreeNode[]): TemplateTreeNode[] {
  return nodes.map(node => cloneNode(node))
}

function cloneNode(node: TemplateTreeNode): TemplateTreeNode {
  return {
    ...node,
    children: node.children ? cloneTree(node.children) : undefined,
  }
}

function createId(prefix: string) {
  const id = `${prefix}-${state.nextId}`
  state.nextId += 1
  return id
}

function normalizeName(name: string, fallback: string) {
  return name.trim() || fallback
}

function ensureXmlFileName(name: string) {
  return name.toLocaleLowerCase().endsWith('.xml') ? name : `${name}.xml`
}

function nextVersion(version: string) {
  const match = /^v(\d+)\.(\d+)$/.exec(version)
  if (!match) {
    return 'v1.1'
  }

  return `v${match[1]}.${Number(match[2]) + 1}`
}

function resolveTemplateScope(template: TemplateSummary): TemplateScopeId {
  if (template.name.includes('入院')) {
    return 'department'
  }
  if (template.name.includes('首页')) {
    return 'hospital'
  }
  return 'global'
}

function resolveTemplateType(template: TemplateSummary) {
  return template.name.includes('首页') ? '病案模板' : '病历模板'
}

function resolvePrintMode(template: TemplateSummary) {
  return template.name.includes('首页') ? '套打' : '普通打印'
}

function resolveDepartments(template: TemplateSummary) {
  if (template.name.includes('首页')) {
    return ['全院', '病案室']
  }
  if (template.name.includes('入院')) {
    return ['急诊科', '住院部']
  }
  return ['全局']
}
