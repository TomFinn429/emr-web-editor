import type { EditorElementProperties, EditorElementType } from '../../types/editorElement'

export type ElementPropertyFieldKind =
  | 'text'
  | 'number'
  | 'checkbox'
  | 'switch'
  | 'select'
  | 'multi-select'
  | 'list-items'
  | 'display-format'
  | 'textarea'
  | 'color'
  | 'json'
  | 'autocomplete'

export type ElementPropertyRuleSourceId =
  | 'local-app-constants'
  | 'online-p-template-make-chunk'
  | 'writer-api-csharp'

export interface ElementPropertyRuleSource {
  id: ElementPropertyRuleSourceId
  label: string
  evidence: string
  checksum?: string
}

export interface ElementPropertyVisibilityRule {
  key: keyof EditorElementProperties
  equals: string | number | boolean | Array<string | number | boolean>
}

export interface ElementPropertyOption {
  label: string
  value: string
  children?: ElementPropertyOption[]
}

export interface ElementPropertyField {
  key: keyof EditorElementProperties
  writerName: string
  label: string
  kind: ElementPropertyFieldKind
  options?: ElementPropertyOption[]
  placeholder?: string
  span?: number
  component?: 'element-select'
  collapseTags?: boolean
  visibleWhen?: ElementPropertyVisibilityRule
  sourceRefs?: ElementPropertyRuleSourceId[]
}

export interface ElementPropertyGroup {
  id: string
  label: string
  fields: ElementPropertyField[]
}

export interface ElementPropertySourceAudit {
  type: EditorElementType
  coveredSourceIds: ElementPropertyRuleSourceId[]
  missingSourceIds: ElementPropertyRuleSourceId[]
  fieldsWithoutSources: string[]
  fieldsMissingWriterObjectSource: string[]
}

export const ELEMENT_PROPERTY_RULE_SOURCES: Record<ElementPropertyRuleSourceId, ElementPropertyRuleSource> = {
  'local-app-constants': {
    id: 'local-app-constants',
    label: '本地 app 常量',
    evidence: 'reverse-engineering/full-prelogin-package/js/app.28a7cbe1.js#ELEMENT_PROPERTIES',
    checksum: '02B48B5229A89F011AE9DB3D231F03D293E008259747E9A62DE3C3984B6738BC',
  },
  'online-p-template-make-chunk': {
    id: 'online-p-template-make-chunk',
    label: '线上 pTemplateMake 缺失 chunk',
    evidence: 'http://10.0.15.11:8766/dist_test/static/js/chunk-322abb84.0f2decc8.js',
    checksum: 'BC83483A1EA5EBE30D05ABDB7918CF452356A5CC2501C32009AFE52611A68FD8',
  },
  'writer-api-csharp': {
    id: 'writer-api-csharp',
    label: 'Writer API/C# 对象属性',
    evidence: 'WriterControl_API.js + WriterControlForWASM.cs + writerElementAdapter.ts',
  },
}

const sourceOrder: ElementPropertyRuleSourceId[] = [
  'local-app-constants',
  'online-p-template-make-chunk',
  'writer-api-csharp',
]

const localAppConstantWriterNames = new Set([
  'ID',
  'Name',
  'BackgroundText',
  'ToolTip',
  'StartBorderText',
  'EndBorderText',
  'Alignment',
  'SpecifyWidth',
  'MoveFocusHotKey',
  'LabelText',
  'UnitText',
  'EditorActiveMode',
  'EnableHighlight',
  'Visible',
  'PrintVisibility',
  'ContentReadonly',
  'Deleteable',
  'UserEditable',
  'MaxInputLength',
  'ViewEncryptType',
  'InnerEditStyle',
  'InnerMultiSelect',
  'DynamicListItems',
  'ListValueSeparatorChar',
  'ListValueFormatString',
  'InnerListSourceName',
  'ListItems',
  'DisplayFormat',
  'LimitedInputChars',
  'ValidateStyle',
  'ValueBinding',
  'DataSource',
  'BindingPath',
  'BindingPathForText',
  'RegExpression',
  'ValueExpression',
  'VisibleExpression',
  'PrintVisibilityExpression',
  'TextColor',
  'BackgroundTextColor',
  'Attributes',
])

const onlineChunkWriterNames = new Set([
  'ID',
  'Name',
  'BackgroundText',
  'ToolTip',
  'LabelText',
  'UnitText',
  'StartBorderText',
  'EndBorderText',
  'Alignment',
  'SpecifyWidth',
  'MoveFocusHotKey',
  'EditorActiveMode',
  'EnableHighlight',
  'Visible',
  'DataSource',
  'BindingPath',
  'BindingPathForText',
  'InnerEditStyle',
  'InnerMultiSelect',
  'DynamicListItems',
  'ListValueSeparatorChar',
  'ListValueFormatString',
  'InnerListSourceName',
  'ListItems',
  'DisplayFormat',
  'ContentReadonly',
  'Deleteable',
  'UserEditable',
  'MaxInputLength',
  'ViewEncryptType',
  'ValidateStyle',
  'LimitedInputChars',
  'ValueExpression',
  'VisibleExpression',
  'PrintVisibilityExpression',
  'TextColor',
  'BackgroundTextColor',
  'Attributes',
  'PrintVisibility',
])

const writerApiCsharpWriterNames = new Set([
  'ID',
  'Name',
  'BackgroundText',
  'ToolTip',
  'LabelText',
  'UnitText',
  'StartBorderText',
  'EndBorderText',
  'Alignment',
  'SpecifyWidth',
  'MoveFocusHotKey',
  'EditorActiveMode',
  'EnableHighlight',
  'Visible',
  'InnerValue',
  'Text',
  'Value',
  'Checked',
  'DataSource',
  'ValueBinding',
  'BindingPath',
  'BindingPathForText',
  'InnerEditStyle',
  'InnerMultiSelect',
  'DynamicListItems',
  'ListValueSeparatorChar',
  'ListValueFormatString',
  'InnerListSourceName',
  'ListItems',
  'DisplayFormat',
  'ContentReadonly',
  'Deleteable',
  'UserEditable',
  'MaxInputLength',
  'ViewEncryptType',
  'ValidateStyle',
  'LimitedInputChars',
  'ValueExpression',
  'VisibleExpression',
  'PrintVisibilityExpression',
  'TextColor',
  'BackgroundTextColor',
  'PrintVisibility',
  'Attributes',
  'Required',
  'EnableValueValidate',
  'TableID',
  'RowCount',
  'ColumnCount',
  'RowIndex',
  'ColumnIndex',
  'CellPosition',
  'Border',
  'Width',
  'Height',
  'ShowText',
])

const dropdownListVisibleWhen: ElementPropertyVisibilityRule = {
  key: 'inputFormat',
  equals: 'DropdownList',
}

const textAlignOptions = [
  { label: '左对齐', value: 'Near' },
  { label: '居中', value: 'Center' },
  { label: '右对齐', value: 'Far' },
]

const borderOptions = [
  { label: '默认', value: 'default' },
  { label: '显示', value: 'visible' },
  { label: '隐藏', value: 'hidden' },
]

const activationOptions = [
  { label: '默认激活模式', value: 'Default' },
  { label: '应用程序激活', value: 'Program' },
  { label: '键盘F2键激活', value: 'F2' },
  { label: '获取光标激活', value: 'GotFocus' },
  { label: '双击激活', value: 'MouseDblClick' },
  { label: '单击激活', value: 'MouseClick' },
  { label: '右击激活', value: 'MouseRightClick' },
  { label: '键盘Enter键激活', value: 'Enter' },
]

const focusShortcutOptions = [
  { label: 'Default', value: 'Default' },
  { label: 'None', value: 'None' },
  { label: 'Tab', value: 'Tab' },
  { label: 'Enter', value: 'Enter' },
]

const highlightOptions = [
  { label: '默认', value: 'Default' },
  { label: '允许', value: 'Enabled' },
  { label: '禁止', value: 'Disabled' },
]

const inputFormatOptions = [
  { label: '纯文本输入域', value: 'Text' },
  { label: '下拉列表', value: 'DropdownList' },
  { label: '日期类型', value: 'Date' },
  { label: '日期时间类型', value: 'DateTime' },
  { label: '不含秒的日期时间类型', value: 'DateTimeWithoutSecond' },
  { label: '时间类型', value: 'Time' },
  { label: '数值类型', value: 'Numeric' },
]

export const displayFormatOptions: ElementPropertyOption[] = [
  { label: 'None', value: 'None' },
  {
    label: 'Numeric',
    value: 'Numeric',
    children: [
      { label: '0.00', value: '0.00' },
      { label: '#.00', value: '#.00' },
      { label: 'c', value: 'c' },
      { label: 'e', value: 'e' },
      { label: 'f', value: 'f' },
      { label: 'g', value: 'g' },
      { label: 'r', value: 'r' },
      { label: 'FormatedSize', value: 'FormatedSize' },
    ],
  },
  {
    label: 'Currency',
    value: 'Currency',
    children: [
      { label: '00.00', value: '00.00' },
      { label: '大写中文', value: '大写中文' },
      { label: '小写中文', value: '小写中文' },
      { label: '#.00', value: '#.00' },
      { label: 'c', value: 'c' },
    ],
  },
  {
    label: 'DateTime',
    value: 'DateTime',
    children: [
      { label: 'yyyy-MM-dd HH:mm:ss', value: 'yyyy-MM-dd HH:mm:ss' },
      { label: 'yyyy-MM-dd', value: 'yyyy-MM-dd' },
      { label: 'yyyy-MM-dd hh:mm:ss', value: 'yyyy-MM-dd hh:mm:ss' },
      { label: 'HH:mm:ss', value: 'HH:mm:ss' },
      { label: 'yyyy年MM月dd日', value: 'yyyy年MM月dd日' },
      { label: 'yyyy年MM月dd日 HH时', value: 'yyyy年MM月dd日 HH时' },
      { label: 'mm分ss秒', value: 'mm分ss秒' },
      { label: 'd', value: 'd' },
      { label: 'D', value: 'D' },
      { label: 'f', value: 'f' },
      { label: 'F', value: 'F' },
    ],
  },
]

const readonlyOptions = [
  { label: '只读', value: 'true' },
  { label: '不只读', value: 'false' },
  { label: '继承父节点', value: 'Inherit' },
]

const encryptOptions = [
  { label: '不加密', value: 'None' },
  { label: '部分加密', value: 'Partial' },
  { label: '全部加密', value: 'Both' },
]

const printVisibleOptions = [
  { label: '显示', value: 'Visible' },
  { label: '隐藏，但占据排版位置', value: 'Hidden' },
  { label: '隐藏，而且不占据排版位置', value: 'None' },
]

const baseFields: ElementPropertyField[] = [
  { key: 'id', writerName: 'ID', label: '编号', kind: 'text' },
  { key: 'name', writerName: 'Name', label: '名称', kind: 'text' },
]

const inputFieldGroups: ElementPropertyGroup[] = [
  {
    id: 'basic',
    label: '基本属性',
    fields: [
      ...baseFields,
      { key: 'placeholder', writerName: 'BackgroundText', label: '背景文字', kind: 'text' },
      { key: 'hintText', writerName: 'ToolTip', label: '提示信息', kind: 'text' },
      { key: 'labelText', writerName: 'LabelText', label: '标签文本', kind: 'text' },
      { key: 'unitText', writerName: 'UnitText', label: '单位文本', kind: 'text' },
      { key: 'startBorderText', writerName: 'StartBorderText', label: '左边框', kind: 'text' },
      { key: 'endBorderText', writerName: 'EndBorderText', label: '右边框', kind: 'text' },
      { key: 'textAlign', writerName: 'Alignment', label: '内容对齐方式', kind: 'select', options: textAlignOptions },
      { key: 'fixedWidth', writerName: 'SpecifyWidth', label: '固定宽度', kind: 'number', span: 2 },
      { key: 'focusShortcut', writerName: 'MoveFocusHotKey', label: '焦点快捷键', kind: 'select', options: focusShortcutOptions },
      {
        key: 'activationMode',
        writerName: 'EditorActiveMode',
        label: '激活模式',
        kind: 'multi-select',
        component: 'element-select',
        collapseTags: true,
        options: activationOptions,
      },
      { key: 'highlight', writerName: 'EnableHighlight', label: '高亮度状态', kind: 'select', options: highlightOptions },
      { key: 'hidden', writerName: 'Visible', label: '隐藏', kind: 'switch' },
    ],
  },
  {
    id: 'assign',
    label: '赋值属性',
    fields: [
      { key: 'dataSourceName', writerName: 'DataSource', label: '数据源名称', kind: 'text', span: 3 },
      { key: 'bindingPath', writerName: 'BindingPath', label: '绑定路径', kind: 'text' },
      { key: 'textBindingPath', writerName: 'BindingPathForText', label: 'Text绑定路径', kind: 'text' },
    ],
  },
  {
    id: 'format',
    label: '格式属性',
    fields: [
      { key: 'inputFormat', writerName: 'InnerEditStyle', label: '输入格式', kind: 'select', options: inputFormatOptions },
      { key: 'allowMultiSelect', writerName: 'InnerMultiSelect', label: '允许多选', kind: 'switch', visibleWhen: dropdownListVisibleWhen },
      { key: 'dynamicListItems', writerName: 'DynamicListItems', label: '动态下拉', kind: 'switch', visibleWhen: dropdownListVisibleWhen },
      { key: 'listValueSeparatorChar', writerName: 'ListValueSeparatorChar', label: '列表分割符', kind: 'text', visibleWhen: dropdownListVisibleWhen },
      { key: 'listValueFormatString', writerName: 'ListValueFormatString', label: '列表格式化', kind: 'text', visibleWhen: dropdownListVisibleWhen },
      { key: 'innerListSourceName', writerName: 'InnerListSourceName', label: '字典来源', kind: 'text', visibleWhen: dropdownListVisibleWhen },
      { key: 'listItems', writerName: 'ListItems', label: '静态项目内容', kind: 'list-items', placeholder: '双击编辑..', visibleWhen: dropdownListVisibleWhen },
      { key: 'outputFormat', writerName: 'DisplayFormat', label: '输出格式', kind: 'display-format', options: displayFormatOptions },
    ],
  },
  {
    id: 'authority',
    label: '权限属性',
    fields: [
      { key: 'readonly', writerName: 'ContentReadonly', label: '只读', kind: 'select', options: readonlyOptions },
      { key: 'allowDelete', writerName: 'Deleteable', label: '允许被删除', kind: 'switch' },
      { key: 'allowKeyboardEdit', writerName: 'UserEditable', label: '允许键盘编辑', kind: 'switch' },
      { key: 'maxContentLength', writerName: 'MaxInputLength', label: '最大内容长度', kind: 'number' },
      { key: 'encrypted', writerName: 'ViewEncryptType', label: '加密显示', kind: 'select', options: encryptOptions },
      { key: 'validationRule', writerName: 'ValidateStyle', label: '校验', kind: 'json', placeholder: '双击编辑..' },
      { key: 'allowedCharacters', writerName: 'LimitedInputChars', label: '仅可输入字符', kind: 'text', placeholder: '如 0123456789.' },
      { key: 'calculateExpression', writerName: 'ValueExpression', label: '计算表达式', kind: 'autocomplete', span: 2 },
      { key: 'visibleExpression', writerName: 'VisibleExpression', label: '可见性表达式', kind: 'autocomplete', span: 2 },
      { key: 'printVisibleExpression', writerName: 'PrintVisibilityExpression', label: '打印可见性表达式', kind: 'autocomplete', span: 2 },
    ],
  },
  {
    id: 'color',
    label: '颜色属性',
    fields: [
      { key: 'textColor', writerName: 'TextColor', label: '文字颜色', kind: 'color' },
      { key: 'backgroundTextColor', writerName: 'BackgroundTextColor', label: '背景文字颜色', kind: 'color' },
    ],
  },
  {
    id: 'other',
    label: '其他属性',
    fields: [
      { key: 'printVisible', writerName: 'PrintVisibility', label: '打印可见性', kind: 'select', options: printVisibleOptions },
      { key: 'customProperties', writerName: 'Attributes', label: '自定义属性', kind: 'json', placeholder: '双击编辑..', span: 2 },
    ],
  },
]

const tableGroups: ElementPropertyGroup[] = [
  {
    id: 'basic',
    label: '基本属性',
    fields: [
      ...baseFields,
      { key: 'tableId', writerName: 'TableID', label: '表格 ID', kind: 'text' },
    ],
  },
  {
    id: 'layout',
    label: '布局属性',
    fields: [
      { key: 'rowCount', writerName: 'RowCount', label: '行数', kind: 'number' },
      { key: 'columnCount', writerName: 'ColumnCount', label: '列数', kind: 'number' },
      { key: 'border', writerName: 'Border', label: '边框', kind: 'select', options: borderOptions },
      { key: 'width', writerName: 'Width', label: '宽度', kind: 'number' },
    ],
  },
  {
    id: 'authority',
    label: '权限属性',
    fields: [
      { key: 'allowDelete', writerName: 'Deleteable', label: '允许被删除', kind: 'switch' },
    ],
  },
]

const tableRowGroups: ElementPropertyGroup[] = [
  {
    id: 'basic',
    label: '基本属性',
    fields: [
      ...baseFields,
      { key: 'tableId', writerName: 'TableID', label: '表格 ID', kind: 'text' },
      { key: 'rowIndex', writerName: 'RowIndex', label: '行序号', kind: 'number' },
      { key: 'height', writerName: 'Height', label: '行高', kind: 'number' },
    ],
  },
  {
    id: 'authority',
    label: '权限属性',
    fields: [
      { key: 'visibleExpression', writerName: 'VisibleExpression', label: '可见性表达式', kind: 'autocomplete', span: 2 },
      { key: 'allowDelete', writerName: 'Deleteable', label: '允许被删除', kind: 'switch' },
    ],
  },
]

const tableCellGroups: ElementPropertyGroup[] = [
  {
    id: 'basic',
    label: '基本属性',
    fields: [
      ...baseFields,
      { key: 'cellPosition', writerName: 'CellPosition', label: '单元格', kind: 'text' },
      { key: 'placeholder', writerName: 'BackgroundText', label: '背景文字', kind: 'text' },
    ],
  },
  {
    id: 'layout',
    label: '布局属性',
    fields: [
      { key: 'tableId', writerName: 'TableID', label: '表格 ID', kind: 'text' },
      { key: 'rowIndex', writerName: 'RowIndex', label: '行序号', kind: 'number' },
      { key: 'columnIndex', writerName: 'ColumnIndex', label: '列序号', kind: 'number' },
      { key: 'width', writerName: 'Width', label: '宽度', kind: 'number' },
      { key: 'height', writerName: 'Height', label: '高度', kind: 'number' },
      { key: 'textAlign', writerName: 'Alignment', label: '内容对齐方式', kind: 'select', options: textAlignOptions },
    ],
  },
  {
    id: 'assign',
    label: '赋值属性',
    fields: [
      { key: 'bindingPath', writerName: 'BindingPath', label: '绑定路径', kind: 'text' },
    ],
  },
]

const choiceSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'displayText', writerName: 'Text', label: '显示文本', kind: 'text' },
  { key: 'bindingValue', writerName: 'Value', label: '绑定值', kind: 'text' },
  { key: 'defaultChecked', writerName: 'Checked', label: '默认选中', kind: 'checkbox' },
  { key: 'bindingPath', writerName: 'BindingPath', label: '绑定路径', kind: 'text' },
]

const codeSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'codeContent', writerName: 'Text', label: '编码内容', kind: 'text' },
  { key: 'bindingPath', writerName: 'BindingPath', label: '绑定字段', kind: 'text' },
  { key: 'width', writerName: 'Width', label: '宽度', kind: 'number' },
  { key: 'height', writerName: 'Height', label: '高度', kind: 'number' },
  { key: 'showText', writerName: 'ShowText', label: '显示文本', kind: 'checkbox' },
]

const groupedSchemas: Partial<Record<EditorElementType, ElementPropertyGroup[]>> = {
  'input-field': inputFieldGroups,
  table: tableGroups,
  'table-row': tableRowGroups,
  'table-cell': tableCellGroups,
  radio: [{ id: 'choice', label: '选择属性', fields: choiceSchema }],
  checkbox: [{ id: 'choice', label: '选择属性', fields: choiceSchema }],
  barcode: [{ id: 'code', label: '编码属性', fields: codeSchema }],
  qrcode: [{ id: 'code', label: '编码属性', fields: codeSchema }],
}

export function getElementPropertyGroups(type: EditorElementType): ElementPropertyGroup[] {
  return groupedSchemas[type] || [{ id: 'basic', label: '基本属性', fields: baseFields }]
}

export function getElementPropertySchema(type: EditorElementType): ElementPropertyField[] {
  return getElementPropertyGroups(type).flatMap(group => group.fields)
}

export function getVisibleElementPropertyGroups(
  type: EditorElementType,
  element: EditorElementProperties,
): ElementPropertyGroup[] {
  return getElementPropertyGroups(type)
    .map(group => ({
      ...group,
      fields: group.fields.filter(field => isElementPropertyFieldVisible(field, element)),
    }))
    .filter(group => group.fields.length > 0)
}

export function isElementPropertyFieldVisible(
  field: ElementPropertyField,
  element: EditorElementProperties,
) {
  if (!field.visibleWhen) return true

  const actual = element[field.visibleWhen.key]
  const expectedValues = Array.isArray(field.visibleWhen.equals)
    ? field.visibleWhen.equals
    : [field.visibleWhen.equals]

  return expectedValues.some(expected => valuesMatch(actual, expected))
}

export function getElementPropertyFieldSources(field: ElementPropertyField): ElementPropertyRuleSourceId[] {
  const sources = new Set<ElementPropertyRuleSourceId>(field.sourceRefs || [])

  if (localAppConstantWriterNames.has(field.writerName)) {
    sources.add('local-app-constants')
  }
  if (onlineChunkWriterNames.has(field.writerName)) {
    sources.add('online-p-template-make-chunk')
  }
  if (writerApiCsharpWriterNames.has(field.writerName)) {
    sources.add('writer-api-csharp')
  }

  return sourceOrder.filter(source => sources.has(source))
}

export function auditElementPropertySources(type: EditorElementType): ElementPropertySourceAudit {
  const fields = getElementPropertySchema(type)
  const coveredSources = new Set<ElementPropertyRuleSourceId>()
  const fieldsWithoutSources: string[] = []
  const fieldsMissingWriterObjectSource: string[] = []

  for (const field of fields) {
    const sources = getElementPropertyFieldSources(field)
    if (sources.length === 0) {
      fieldsWithoutSources.push(field.writerName)
    }
    if (!sources.includes('writer-api-csharp')) {
      fieldsMissingWriterObjectSource.push(field.writerName)
    }
    for (const source of sources) {
      coveredSources.add(source)
    }
  }

  const coveredSourceIds = sourceOrder.filter(source => coveredSources.has(source))

  return {
    type,
    coveredSourceIds,
    missingSourceIds: sourceOrder.filter(source => !coveredSources.has(source)),
    fieldsWithoutSources,
    fieldsMissingWriterObjectSource,
  }
}

export function createElementPropertyPatch(
  field: ElementPropertyField,
  value: string | boolean | string[],
): Partial<EditorElementProperties> {
  if (field.kind === 'checkbox' || field.kind === 'switch') {
    return { [field.key]: Boolean(value) }
  }

  if (field.kind === 'number') {
    const numberValue = Number(value)
    return { [field.key]: Number.isNaN(numberValue) ? undefined : numberValue }
  }

  if (field.kind === 'multi-select') {
    return { [field.key]: getElementPropertyMultiSelectValues(value) }
  }

  return { [field.key]: value }
}

export function getElementPropertyMultiSelectValues(value: unknown) {
  if (Array.isArray(value)) {
    return value.map(String).map(item => item.trim()).filter(Boolean)
  }
  if (typeof value === 'number') return [String(value)]
  if (typeof value !== 'string') return []
  return value.split(/[,\s;|]+/).map(item => item.trim()).filter(Boolean)
}

export function isElementPropertyMultiSelectOptionSelected(value: unknown, optionValue: string) {
  return getElementPropertyMultiSelectValues(value).some(item => item === optionValue)
}

export interface StaticListItem {
  Text: string
  TextInList: string | null
  Value: string
  Group: string | null
  Tag: string | null
  ID: string | number | null
}

export function parseStaticListItems(value: string): StaticListItem[] {
  if (!value.trim()) return []

  try {
    const rawItems = JSON.parse(value)
    if (!Array.isArray(rawItems)) return []

    return rawItems.map(item => normalizeStaticListItem(item))
  }
  catch {
    return []
  }
}

export function summarizeStaticListItems(value: string) {
  const items = parseStaticListItems(value)
  return items.length > 0 ? `${items.length}项` : '双击新增..'
}

export function stringifyStaticListItems(items: StaticListItem[]) {
  return JSON.stringify(items.map(item => normalizeStaticListItem(item)))
}

export function validateStaticListItems(items: StaticListItem[]) {
  const emptyText = items.some(item => item.Text.trim() === '')
  if (emptyText) {
    return {
      ok: false,
      message: '文本不可为空，请检查配置',
    }
  }

  return { ok: true }
}

function valuesMatch(actual: unknown, expected: string | number | boolean) {
  if (Array.isArray(actual)) {
    return actual.some(item => String(item) === String(expected))
  }

  return String(actual ?? '') === String(expected)
}

function stringValue(value: unknown) {
  if (value === null || value === undefined) return ''
  return String(value)
}

function nullableStringValue(value: unknown) {
  if (value === null || value === undefined) return null
  return String(value)
}

function staticListIdValue(value: unknown) {
  if (value === null || value === undefined) return null
  if (typeof value === 'number' || typeof value === 'string') return value
  return String(value)
}

function normalizeStaticListItem(item: Partial<StaticListItem> | null | undefined): StaticListItem {
  return {
    Text: stringValue(item?.Text),
    TextInList: nullableStringValue(item?.TextInList),
    Value: stringValue(item?.Value),
    Group: nullableStringValue(item?.Group),
    Tag: nullableStringValue(item?.Tag),
    ID: staticListIdValue(item?.ID),
  }
}
