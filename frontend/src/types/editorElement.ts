export type EditorElementType =
  | 'none'
  | 'input-field'
  | 'radio'
  | 'checkbox'
  | 'table'
  | 'table-row'
  | 'table-cell'
  | 'barcode'
  | 'qrcode'
  | 'header-footer'

export interface ElementCandidateOption {
  id: string
  text: string
  value: string
  checked?: boolean
}

export interface EditorElementProperties {
  id: string
  type: EditorElementType
  name: string
  supportLevel: 'writer' | 'mock'
  code?: string
  placeholder?: string
  hintText?: string
  labelText?: string
  unitText?: string
  startBorderText?: string
  endBorderText?: string
  defaultValue?: string
  readonly?: boolean | string
  required?: boolean
  visible?: boolean
  hidden?: boolean
  bindingPath?: string
  textBindingPath?: string
  valueBinding?: Record<string, unknown> | string
  dataElementId?: string
  dataSourceName?: string
  inputFormat?: string
  outputFormat?: string
  allowMultiSelect?: boolean
  dynamicListItems?: boolean
  listValueSeparatorChar?: string
  listValueFormatString?: string
  innerListSourceName?: string
  listItems?: string
  validationRule?: string
  allowedCharacters?: string
  calculateExpression?: string
  visibleExpression?: string
  printVisibleExpression?: string
  customProperties?: string
  allowDelete?: boolean
  allowKeyboardEdit?: boolean
  encrypted?: boolean | string
  printVisible?: boolean | string
  border?: string
  textAlign?: string
  fixedWidth?: number
  focusShortcut?: string
  activationMode?: string | string[]
  highlight?: boolean | string
  maxContentLength?: number
  textColor?: string
  backgroundTextColor?: string
  displayText?: string
  bindingValue?: string
  defaultChecked?: boolean
  options?: ElementCandidateOption[]
  tableId?: string
  rowCount?: number
  columnCount?: number
  rowIndex?: number
  columnIndex?: number
  cellPosition?: string
  width?: number
  height?: number
  codeContent?: string
  showText?: boolean
  scope?: string
  libraryName?: string
}

export interface MetadataTreeNode {
  id: string
  kind: 'group' | 'item'
  label: string
  code?: string
  valueType?: string
  description?: string
  category?: string
  children?: MetadataTreeNode[]
}

export interface FragmentTemplateTreeNode {
  id: string
  kind: 'group' | 'item'
  label: string
  category?: string
  description?: string
  xml?: string
  insertMode?: 'writer-command' | 'mock'
  children?: FragmentTemplateTreeNode[]
}

export type ElementPropertyUpdateStatus =
  | 'success'
  | 'unsupported'
  | 'no-selection'
  | 'failed'

export type ElementPropertyUpdateResult =
  | {
    ok: true
    status: 'success'
    message: string
  }
  | {
    ok: false
    status: Exclude<ElementPropertyUpdateStatus, 'success'>
    reason: Exclude<ElementPropertyUpdateStatus, 'success'>
    message: string
  }
