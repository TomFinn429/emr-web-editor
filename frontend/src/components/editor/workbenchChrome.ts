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

export const workbenchModules: WorkbenchModuleItem[] = []

export const shellActions: WorkbenchShellAction[] = [
  { id: 'displayMode', label: '显示模式', icon: 'display' },
  { id: 'fullscreen', label: '全屏', icon: 'fullscreen' },
  { id: 'reload', label: '重载', icon: 'reload' },
  { id: 'account', label: '当前账号', icon: 'account' },
]
