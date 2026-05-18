export type TemplateTreeNodeKind = 'root' | 'category' | 'template'
export type TemplateUploadStatus = '已上传' | '未上传' | '待上传'

export interface TemplateTreeNode {
  id: string
  label: string
  kind: TemplateTreeNodeKind
  category?: string
  templateId?: string
  status?: TemplateUploadStatus
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
}

export interface ElementProperties {
  id: string
  name: string
  type: string
  bindingPath: string
  readonly: boolean
}

export interface TemplateWorkbenchData {
  templateTree: TemplateTreeNode[]
  categories: string[]
  metadataItems: MetadataItem[]
  fragmentTemplates: FragmentTemplate[]
  templateProperties: TemplateProperties
  elementProperties: ElementProperties
}

export interface TemplateTreeFilter {
  category: string
  keyword: string
}

const mockTemplateTree: TemplateTreeNode[] = [
  {
    id: 'hospital-root',
    label: '和硕县人民医院',
    kind: 'root',
    children: [
      {
        id: 'category-home',
        label: '病案首页',
        kind: 'category',
        category: '病案首页',
        children: [
          {
            id: 'western-home',
            label: '西医病案首页',
            kind: 'template',
            category: '病案首页',
            templateId: 'The-front-page-of-medical-records',
            status: '待上传',
          },
          {
            id: 'chinese-home',
            label: '中医病案首页',
            kind: 'template',
            category: '病案首页',
            templateId: 'Medical-Record',
            status: '待上传',
          },
        ],
      },
      {
        id: 'category-inpatient',
        label: '住院病历',
        kind: 'category',
        category: '住院病历',
        children: [
          {
            id: 'admission-record',
            label: '入院记录',
            kind: 'template',
            category: '住院病历',
            templateId: 'Admission-Record',
            status: '已上传',
          },
          {
            id: 'surgery-record',
            label: '手术记录',
            kind: 'template',
            category: '住院病历',
            templateId: 'Operation-Schedule',
            status: '未上传',
          },
        ],
      },
      {
        id: 'category-nursing',
        label: '护理病历',
        kind: 'category',
        category: '护理病历',
        children: [
          {
            id: 'nursing-notice',
            label: '护理告知书',
            kind: 'template',
            category: '护理病历',
            templateId: 'List-of-Nursing-Evaluation-at-Admission-for-Patient',
            status: '已上传',
          },
          {
            id: 'risk-assessment',
            label: '风险评估表',
            kind: 'template',
            category: '护理病历',
            templateId: 'Pain-Scale',
            status: '待上传',
          },
        ],
      },
      {
        id: 'category-other',
        label: '暂未分类',
        kind: 'category',
        category: '暂未分类',
        children: [
          {
            id: 'consultation-apply',
            label: '会诊申请',
            kind: 'template',
            category: '暂未分类',
            templateId: 'Imaging-Examination-Application-Sheet',
            status: '未上传',
          },
        ],
      },
    ],
  },
]

const mockMetadataItems: MetadataItem[] = [
  { id: 'patient-name', name: '患者姓名', code: 'Patient.Name', valueType: '文本' },
  { id: 'admission-date', name: '入院日期', code: 'Visit.AdmissionDate', valueType: '日期' },
  { id: 'department', name: '科室', code: 'Visit.Department', valueType: '字典' },
  { id: 'diagnosis', name: '主要诊断', code: 'Diagnosis.Primary', valueType: '文本' },
]

const mockFragmentTemplates: FragmentTemplate[] = [
  { id: 'chief-complaint', name: '通用入院主诉', category: '住院病历' },
  { id: 'physical-exam', name: '体格检查片段', category: '住院病历' },
  { id: 'nursing-risk', name: '护理风险说明', category: '护理病历' },
]

const mockTemplateProperties: TemplateProperties = {
  id: 'western-home',
  name: '西医病案首页',
  category: '病案首页',
  status: '未上传',
  version: 'v1.0',
  updatedAt: '2026-05-18',
}

const mockElementProperties: ElementProperties = {
  id: 'none',
  name: '未选择元素',
  type: '未选择元素',
  bindingPath: '-',
  readonly: false,
}

export async function fetchTemplateWorkbenchData(): Promise<TemplateWorkbenchData> {
  const categories = collectCategories(mockTemplateTree)
  return {
    templateTree: cloneTree(mockTemplateTree),
    categories: ['全部分类', ...categories],
    metadataItems: [...mockMetadataItems],
    fragmentTemplates: [...mockFragmentTemplates],
    templateProperties: { ...mockTemplateProperties },
    elementProperties: { ...mockElementProperties },
  }
}

export function filterTemplateTree(
  nodes: readonly TemplateTreeNode[],
  filter: TemplateTreeFilter,
): TemplateTreeNode[] {
  const keyword = filter.keyword.trim().toLocaleLowerCase()
  const category = filter.category === '全部分类' ? '' : filter.category

  return nodes
    .map(node => filterNode(node, category, keyword))
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

function filterNode(
  node: TemplateTreeNode,
  category: string,
  keyword: string,
): TemplateTreeNode | null {
  const children = (node.children || [])
    .map(child => filterNode(child, category, keyword))
    .filter((child): child is TemplateTreeNode => child !== null)

  const matchesCategory = !category || node.category === category || node.kind === 'root'
  const matchesKeyword = !keyword || node.label.toLocaleLowerCase().includes(keyword)
  const isMatch = matchesCategory && matchesKeyword

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
  return nodes.map(node => ({
    ...node,
    children: node.children ? cloneTree(node.children) : undefined,
  }))
}
