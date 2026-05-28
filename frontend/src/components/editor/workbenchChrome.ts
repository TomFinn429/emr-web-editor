export interface WorkbenchModuleItem {
  id: string
  label: string
  icon: 'dashboard' | 'template' | 'data' | 'library' | 'settings'
  active?: boolean
}

export interface WorkbenchShellAction {
  id: string
  label: string
  icon: 'display' | 'fullscreen' | 'reload' | 'account'
}

export const workbenchModules: WorkbenchModuleItem[] = [
  { id: 'dashboard', label: '仪表板', icon: 'dashboard' },
  { id: 'templateMake', label: '模板制作', icon: 'template', active: true },
  { id: 'dataElement', label: '数据元管理', icon: 'data' },
  { id: 'dictionary', label: '字典库管理', icon: 'library' },
  { id: 'fragmentTemplate', label: '片段模板库管理', icon: 'library' },
  { id: 'headerFooter', label: '页眉页脚库管理', icon: 'template' },
  { id: 'templateManage', label: '模板管理', icon: 'template' },
  { id: 'metadata', label: '元数据管理', icon: 'data' },
  { id: 'valueDomain', label: '值域管理', icon: 'data' },
  { id: 'dataSource', label: '数据源管理', icon: 'data' },
  { id: 'templateType', label: '模板类型管理', icon: 'settings' },
]

export const shellActions: WorkbenchShellAction[] = [
  { id: 'displayMode', label: '显示模式', icon: 'display' },
  { id: 'fullscreen', label: '全屏', icon: 'fullscreen' },
  { id: 'reload', label: '重载', icon: 'reload' },
  { id: 'account', label: '当前账号', icon: 'account' },
]
