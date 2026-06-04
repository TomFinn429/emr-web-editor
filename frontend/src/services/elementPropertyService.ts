import type {
  EditorElementProperties,
  EditorElementType,
  ElementCandidateOption,
  MetadataTreeNode,
} from '../types/editorElement'
import { composeWriterValueBinding } from '../utils/writerValueBinding'

let selectedElement = createDefaultElementProperties('input-field')

export function resetElementPropertyState() {
  selectedElement = createDefaultElementProperties('input-field')
}

export function getCurrentMockElementProperties() {
  return cloneElement(selectedElement)
}

export function selectMockElement(type: EditorElementType) {
  selectedElement = createDefaultElementProperties(type)
  return cloneElement(selectedElement)
}

export function setCurrentElementProperties(element: EditorElementProperties) {
  selectedElement = cloneElement(element)
  return cloneElement(selectedElement)
}

export function updateElementProperties(patch: Partial<EditorElementProperties>) {
  selectedElement = {
    ...selectedElement,
    ...patch,
    options: patch.options ? [...patch.options] : selectedElement.options,
  }
  return cloneElement(selectedElement)
}

export function createDefaultElementProperties(type: EditorElementType): EditorElementProperties {
  if (type === 'none') {
    return {
      id: 'none',
      type,
      name: '未选择元素',
      supportLevel: 'mock',
    }
  }

  if (type === 'input-field') {
    return {
      id: 'field-patient-name',
      type,
      name: '输入域',
      code: 'Field.Code',
      defaultValue: '',
      readonly: 'Inherit',
      required: false,
      visible: true,
      hidden: false,
      bindingPath: '',
      dataElementId: '',
      placeholder: '',
      hintText: '',
      labelText: '',
      unitText: '',
      startBorderText: '【',
      endBorderText: '】',
      textAlign: 'Near',
      fixedWidth: 0,
      focusShortcut: 'None',
      activationMode: 'F2',
      highlight: 'Default',
      inputFormat: 'Text',
      outputFormat: '',
      allowDelete: true,
      allowKeyboardEdit: true,
      encrypted: 'None',
      printVisible: 'Visible',
      textColor: '#FFFFFF00',
      backgroundTextColor: '#FFFFFF00',
      backgroundColor: '#FFFFFF00',
      supportLevel: 'mock',
    }
  }

  if (type === 'radio' || type === 'checkbox') {
    return {
      id: `${type}-demo`,
      type,
      name: type === 'radio' ? '单选框' : '复选框',
      displayText: type === 'radio' ? '性别' : '确认项',
      bindingValue: '',
      defaultChecked: false,
      options: getCandidateOptions(type),
      supportLevel: 'mock',
    }
  }

  if (type === 'table') {
    return {
      id: 'table-demo',
      type,
      name: '表格',
      tableId: 'Table1',
      rowCount: 3,
      columnCount: 4,
      width: 520,
      allowDelete: true,
      supportLevel: 'mock',
    }
  }

  if (type === 'table-row') {
    return {
      id: 'table-row-demo',
      type,
      name: '表格行',
      tableId: 'Table1',
      rowIndex: 1,
      height: 32,
      allowDelete: true,
      supportLevel: 'mock',
    }
  }

  if (type === 'table-cell') {
    return {
      id: 'table-cell-demo',
      type,
      name: '单元格',
      tableId: 'Table1',
      rowIndex: 1,
      columnIndex: 1,
      cellPosition: '第 1 行，第 1 列',
      width: 120,
      height: 32,
      textAlign: 'Near',
      bindingPath: '',
      supportLevel: 'mock',
    }
  }

  if (type === 'barcode' || type === 'qrcode') {
    return {
      id: `${type}-demo`,
      type,
      name: type === 'barcode' ? '条形码' : '二维码',
      codeContent: 'DC-EMR-0001',
      bindingPath: '',
      width: type === 'barcode' ? 180 : 120,
      height: type === 'barcode' ? 56 : 120,
      showText: true,
      supportLevel: 'mock',
    }
  }

  return {
    id: 'header-footer-demo',
    type: 'header-footer',
    name: '页眉页脚',
    scope: '全篇',
    libraryName: '默认页眉页脚',
    supportLevel: 'mock',
  }
}

export function bindMetadataToInputField(
  element: EditorElementProperties,
  metadata: MetadataTreeNode,
): EditorElementProperties {
  const inputField = element.type === 'input-field'
    ? element
    : createDefaultElementProperties('input-field')

  return {
    ...inputField,
    name: metadata.label,
    code: metadata.code || inputField.code,
    bindingPath: metadata.code || inputField.bindingPath,
    dataElementId: metadata.id,
    defaultValue: inputField.defaultValue || '',
  }
}

export function toInputFieldWriterOptions(element: EditorElementProperties) {
  const valueBinding = composeWriterValueBinding(element)

  return {
    ID: element.code || element.id,
    Name: element.name,
    BackgroundText: element.name,
    InnerValue: element.defaultValue || '',
    Text: element.defaultValue || '',
    DataSource: valueBinding.DataSource,
    BindingPath: valueBinding.BindingPath,
    BindingPathForText: valueBinding.BindingPathForText,
    ValueBinding: valueBinding,
    ContentReadonly: normalizeContentReadonly(element.readonly),
    UserEditable: element.allowKeyboardEdit !== false,
    Visible: element.visible !== false,
    EnableValueValidate: true,
    EditorActiveMode: normalizeActivationMode(element.activationMode),
    Required: Boolean(element.required),
    StartBorderText: '【',
    EndBorderText: '】',
    TextColor: element.textColor || '',
    BackgroundTextColor: element.backgroundTextColor || '',
    Style: {
      BackgroundColorString: element.backgroundColor || '',
    },
  }
}

function normalizeContentReadonly(value: EditorElementProperties['readonly']) {
  if (value === true || value === 'true') return true
  if (value === false || value === 'false') return false
  return 'Inherit'
}

function normalizeActivationMode(value: EditorElementProperties['activationMode']) {
  if (Array.isArray(value)) {
    return value.map(String).map(item => item.trim()).filter(Boolean).join(' ')
  }
  if (typeof value === 'string') {
    return value.split(/[,\s;|]+/).map(item => item.trim()).filter(Boolean).join(' ')
  }
  return ''
}

export function toChoiceWriterOptions(element: EditorElementProperties) {
  const type = element.type === 'radio' ? 'radio' : 'checkbox'
  return {
    Name: element.name || `${type}-group`,
    Type: type,
    ListItems: (element.options || getCandidateOptions(type)).map(option => ({
      ID: option.id,
      Text: option.text,
      Value: option.value,
      Checked: String(Boolean(option.checked || element.defaultChecked)),
      CaptionFlowLayout: 'false',
      VisualStyle: type === 'radio' ? 'RadioBox' : 'CheckBox',
    })),
  }
}

export function getCandidateOptions(type: EditorElementType): ElementCandidateOption[] {
  if (type === 'radio') {
    return [
      { id: 'radio-male', text: '男', value: 'M' },
      { id: 'radio-female', text: '女', value: 'F' },
    ]
  }

  if (type === 'checkbox') {
    return [
      { id: 'checkbox-informed', text: '已告知', value: 'informed' },
      { id: 'checkbox-signed', text: '已签字', value: 'signed' },
      { id: 'checkbox-review', text: '需复核', value: 'review' },
    ]
  }

  return []
}

function cloneElement(element: EditorElementProperties): EditorElementProperties {
  return {
    ...element,
    options: element.options ? [...element.options] : undefined,
  }
}
