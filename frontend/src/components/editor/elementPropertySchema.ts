import type { EditorElementProperties, EditorElementType } from '../../types/editorElement'

export type ElementPropertyFieldKind = 'text' | 'number' | 'checkbox' | 'select' | 'textarea'

export interface ElementPropertyField {
  key: keyof EditorElementProperties
  label: string
  kind: ElementPropertyFieldKind
  options?: Array<{ label: string; value: string }>
}

const textAlignOptions = [
  { label: '左对齐', value: 'left' },
  { label: '居中', value: 'center' },
  { label: '右对齐', value: 'right' },
]

const borderOptions = [
  { label: '默认', value: 'default' },
  { label: '显示', value: 'visible' },
  { label: '隐藏', value: 'hidden' },
]

const activationOptions = [
  { label: '单击', value: 'click' },
  { label: '双击', value: 'double-click' },
  { label: '焦点进入', value: 'focus' },
]

const baseFields: ElementPropertyField[] = [
  { key: 'id', label: '编号', kind: 'text' },
  { key: 'name', label: '名称', kind: 'text' },
]

const inputFieldSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'placeholder', label: '背景文字', kind: 'text' },
  { key: 'hintText', label: '提示信息', kind: 'text' },
  { key: 'labelText', label: '标签文本', kind: 'text' },
  { key: 'unitText', label: '单位文本', kind: 'text' },
  { key: 'border', label: '边框', kind: 'select', options: borderOptions },
  { key: 'textAlign', label: '内容对齐方式', kind: 'select', options: textAlignOptions },
  { key: 'fixedWidth', label: '固定宽度', kind: 'number' },
  { key: 'focusShortcut', label: '焦点快捷键', kind: 'text' },
  { key: 'activationMode', label: '激活模式', kind: 'select', options: activationOptions },
  { key: 'highlight', label: '高亮度状态', kind: 'checkbox' },
  { key: 'hidden', label: '隐藏', kind: 'checkbox' },
  { key: 'dataSourceName', label: '数据源名称', kind: 'text' },
  { key: 'bindingPath', label: '绑定路径', kind: 'text' },
  { key: 'textBindingPath', label: 'Text 绑定路径', kind: 'text' },
  { key: 'inputFormat', label: '输入格式', kind: 'text' },
  { key: 'outputFormat', label: '输出格式', kind: 'text' },
  { key: 'readonly', label: '只读', kind: 'checkbox' },
  { key: 'allowDelete', label: '允许删除', kind: 'checkbox' },
  { key: 'allowKeyboardEdit', label: '允许键盘编辑', kind: 'checkbox' },
  { key: 'maxContentLength', label: '最大内容长度', kind: 'number' },
  { key: 'encrypted', label: '加密显示', kind: 'checkbox' },
  { key: 'validationRule', label: '校验', kind: 'text' },
  { key: 'allowedCharacters', label: '仅可输入字符', kind: 'text' },
  { key: 'calculateExpression', label: '计算表达式', kind: 'textarea' },
  { key: 'visibleExpression', label: '可见性表达式', kind: 'textarea' },
  { key: 'printVisibleExpression', label: '打印可见性表达式', kind: 'textarea' },
  { key: 'textColor', label: '文字颜色', kind: 'text' },
  { key: 'backgroundTextColor', label: '背景文字颜色', kind: 'text' },
  { key: 'customProperties', label: '自定义属性', kind: 'textarea' },
  { key: 'printVisible', label: '打印可见性', kind: 'checkbox' },
]

const tableSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'tableId', label: '表格 ID', kind: 'text' },
  { key: 'rowCount', label: '行数', kind: 'number' },
  { key: 'columnCount', label: '列数', kind: 'number' },
  { key: 'border', label: '边框', kind: 'select', options: borderOptions },
  { key: 'width', label: '宽度', kind: 'number' },
]

const tableRowSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'tableId', label: '表格 ID', kind: 'text' },
  { key: 'rowIndex', label: '行序号', kind: 'number' },
  { key: 'height', label: '行高', kind: 'number' },
  { key: 'visibleExpression', label: '可见性表达式', kind: 'textarea' },
]

const tableCellSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'cellPosition', label: '单元格', kind: 'text' },
  { key: 'width', label: '宽度', kind: 'number' },
  { key: 'height', label: '高度', kind: 'number' },
  { key: 'textAlign', label: '内容对齐方式', kind: 'select', options: textAlignOptions },
  { key: 'bindingPath', label: '绑定路径', kind: 'text' },
]

const choiceSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'displayText', label: '显示文本', kind: 'text' },
  { key: 'bindingValue', label: '绑定值', kind: 'text' },
  { key: 'defaultChecked', label: '默认选中', kind: 'checkbox' },
  { key: 'bindingPath', label: '绑定路径', kind: 'text' },
]

const codeSchema: ElementPropertyField[] = [
  ...baseFields,
  { key: 'codeContent', label: '编码内容', kind: 'text' },
  { key: 'bindingPath', label: '绑定字段', kind: 'text' },
  { key: 'width', label: '宽度', kind: 'number' },
  { key: 'height', label: '高度', kind: 'number' },
  { key: 'showText', label: '显示文本', kind: 'checkbox' },
]

const schemas: Partial<Record<EditorElementType, ElementPropertyField[]>> = {
  'input-field': inputFieldSchema,
  radio: choiceSchema,
  checkbox: choiceSchema,
  table: tableSchema,
  'table-row': tableRowSchema,
  'table-cell': tableCellSchema,
  barcode: codeSchema,
  qrcode: codeSchema,
}

export function getElementPropertySchema(type: EditorElementType): ElementPropertyField[] {
  return schemas[type] || baseFields
}

export function createElementPropertyPatch(
  field: ElementPropertyField,
  value: string | boolean,
): Partial<EditorElementProperties> {
  if (field.kind === 'checkbox') {
    return { [field.key]: Boolean(value) }
  }

  if (field.kind === 'number') {
    const numberValue = Number(value)
    return { [field.key]: Number.isNaN(numberValue) ? undefined : numberValue }
  }

  return { [field.key]: value }
}
