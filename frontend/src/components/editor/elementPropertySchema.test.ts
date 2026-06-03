import { describe, expect, it } from 'vitest'
import {
  auditElementPropertySources,
  createElementPropertyPatch,
  getElementPropertyMultiSelectValues,
  getElementPropertyFieldSources,
  getElementPropertyGroups,
  getElementPropertySchema,
  getVisibleElementPropertyGroups,
  isElementPropertyMultiSelectOptionSelected,
} from './elementPropertySchema'
import * as elementPropertySchema from './elementPropertySchema'

describe('elementPropertySchema', () => {
  it('exposes target-page input-field property keys', () => {
    const keys = getElementPropertySchema('input-field').map(field => field.key)

    expect(keys).toEqual(expect.arrayContaining([
      'id',
      'name',
      'placeholder',
      'hintText',
      'labelText',
      'unitText',
      'startBorderText',
      'endBorderText',
      'textAlign',
      'fixedWidth',
      'focusShortcut',
      'activationMode',
      'highlight',
      'hidden',
      'dataSourceName',
      'bindingPath',
      'textBindingPath',
      'inputFormat',
      'outputFormat',
      'readonly',
      'allowDelete',
      'allowKeyboardEdit',
      'maxContentLength',
      'encrypted',
      'validationRule',
      'allowedCharacters',
      'calculateExpression',
      'visibleExpression',
      'printVisibleExpression',
      'textColor',
      'backgroundTextColor',
      'customProperties',
      'printVisible',
    ]))
    expect(keys).not.toContain('valueBinding')
  })

  it('groups input-field properties like the reference element inspector', () => {
    const groups = getElementPropertyGroups('input-field')

    expect(groups.map(group => group.label)).toEqual([
      '基本属性',
      '赋值属性',
      '格式属性',
      '权限属性',
      '颜色属性',
      '其他属性',
    ])
    expect(groups[0].fields.map(field => field.writerName)).toEqual([
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
    ])
    expect(groups.find(group => group.id === 'assign')?.fields.map(field => field.writerName)).toEqual([
      'DataSource',
      'BindingPath',
      'BindingPathForText',
    ])
    expect(groups.flatMap(group => group.fields).find(field => field.writerName === 'InnerEditStyle')).toMatchObject({
      key: 'inputFormat',
      kind: 'select',
      options: expect.arrayContaining([
        { label: '日期类型', value: 'Date' },
        { label: '日期时间类型', value: 'DateTime' },
      ]),
    })
    expect(groups.flatMap(group => group.fields).find(field => field.writerName === 'EditorActiveMode')).toMatchObject({
      kind: 'multi-select',
    })
    expect(groups.flatMap(group => group.fields).find(field => field.writerName === 'ListItems')).toMatchObject({
      key: 'listItems',
      kind: 'list-items',
    })
    expect(groups.flatMap(group => group.fields).find(field => field.writerName === 'DisplayFormat')).toMatchObject({
      key: 'outputFormat',
      kind: 'display-format',
      options: expect.arrayContaining([
        { label: 'None', value: 'None' },
        {
          label: 'Numeric',
          value: 'Numeric',
          children: expect.arrayContaining([
            { label: '0.00', value: '0.00' },
            { label: '#.00', value: '#.00' },
          ]),
        },
        {
          label: 'DateTime',
          value: 'DateTime',
          children: expect.arrayContaining([
            { label: 'yyyy-MM-dd HH:mm:ss', value: 'yyyy-MM-dd HH:mm:ss' },
            { label: 'yyyy-MM-dd', value: 'yyyy-MM-dd' },
          ]),
        },
      ]),
    })
  })

  it('audits input-field rules against local constants, online chunk, and Writer object sources', () => {
    const audit = auditElementPropertySources('input-field')
    const innerEditStyle = getElementPropertySchema('input-field')
      .find(field => field.writerName === 'InnerEditStyle')
    const dataSource = getElementPropertySchema('input-field')
      .find(field => field.writerName === 'DataSource')
    const valueBinding = getElementPropertySchema('input-field')
      .find(field => field.writerName === 'ValueBinding')

    expect(audit.missingSourceIds).toEqual([])
    expect(audit.fieldsWithoutSources).toEqual([])
    expect(audit.fieldsMissingWriterObjectSource).toEqual([])
    expect(getElementPropertyFieldSources(innerEditStyle!)).toEqual([
      'local-app-constants',
      'online-p-template-make-chunk',
      'writer-api-csharp',
    ])
    expect(valueBinding).toBeUndefined()
    expect(getElementPropertyFieldSources(dataSource!)).toEqual([
      'local-app-constants',
      'online-p-template-make-chunk',
      'writer-api-csharp',
    ])
  })

  it('matches the online chunk by showing dropdown-list fields only for DropdownList format', () => {
    const textGroups = getVisibleElementPropertyGroups('input-field', {
      id: 'field-1',
      type: 'input-field',
      name: '输入域',
      supportLevel: 'mock',
      inputFormat: 'Text',
    })
    const dropdownGroups = getVisibleElementPropertyGroups('input-field', {
      id: 'field-1',
      type: 'input-field',
      name: '输入域',
      supportLevel: 'mock',
      inputFormat: 'DropdownList',
    })

    const textWriterNames = textGroups.flatMap(group => group.fields).map(field => field.writerName)
    const dropdownWriterNames = dropdownGroups.flatMap(group => group.fields).map(field => field.writerName)

    expect(textWriterNames).toContain('InnerEditStyle')
    expect(textWriterNames).toContain('DisplayFormat')
    expect(textWriterNames).not.toContain('InnerMultiSelect')
    expect(textWriterNames).not.toContain('DynamicListItems')
    expect(textWriterNames).not.toContain('ListItems')
    expect(dropdownWriterNames).toEqual(expect.arrayContaining([
      'InnerMultiSelect',
      'DynamicListItems',
      'ListValueSeparatorChar',
      'ListValueFormatString',
      'InnerListSourceName',
      'ListItems',
    ]))
  })

  it('exposes focused schemas for table, row, and cell elements', () => {
    expect(getElementPropertySchema('table').map(field => field.key)).toEqual(expect.arrayContaining([
      'tableId',
      'rowCount',
      'columnCount',
      'border',
      'width',
    ]))
    expect(getElementPropertySchema('table-row').map(field => field.key)).toEqual(expect.arrayContaining([
      'tableId',
      'rowIndex',
      'height',
      'visibleExpression',
    ]))
    expect(getElementPropertySchema('table-cell').map(field => field.key)).toEqual(expect.arrayContaining([
      'cellPosition',
      'width',
      'height',
      'textAlign',
      'bindingPath',
    ]))
  })

  it('groups table, row, and cell properties separately', () => {
    expect(getElementPropertyGroups('table').map(group => group.label)).toEqual([
      '基本属性',
      '布局属性',
      '权限属性',
    ])
    expect(getElementPropertyGroups('table-row').flatMap(group => group.fields).map(field => field.writerName)).toEqual(expect.arrayContaining([
      'ID',
      'Name',
      'TableID',
      'RowIndex',
      'Height',
      'VisibleExpression',
      'Deleteable',
    ]))
    expect(getElementPropertyGroups('table-cell').flatMap(group => group.fields).map(field => field.writerName)).toEqual(expect.arrayContaining([
      'ID',
      'Name',
      'CellPosition',
      'Width',
      'Height',
      'Alignment',
      'BindingPath',
      'BackgroundText',
    ]))
  })

  it('audits table, row, and cell fields as Writer API/C# backed', () => {
    for (const type of ['table', 'table-row', 'table-cell'] as const) {
      const audit = auditElementPropertySources(type)

      expect(audit.fieldsWithoutSources).toEqual([])
      expect(audit.fieldsMissingWriterObjectSource).toEqual([])
      expect(audit.coveredSourceIds).toEqual(expect.arrayContaining([
        'local-app-constants',
        'writer-api-csharp',
      ]))
    }
  })

  it('creates typed patches from schema field values', () => {
    const fixedWidth = getElementPropertySchema('input-field').find(field => field.key === 'fixedWidth')
    const readonly = getElementPropertySchema('input-field').find(field => field.key === 'readonly')
    const textAlign = getElementPropertySchema('input-field').find(field => field.key === 'textAlign')

    expect(fixedWidth).toBeDefined()
    expect(readonly).toBeDefined()
    expect(textAlign).toBeDefined()
    expect(createElementPropertyPatch(fixedWidth!, '42')).toEqual({ fixedWidth: 42 })
    expect(createElementPropertyPatch(readonly!, true)).toEqual({ readonly: true })
    expect(createElementPropertyPatch(textAlign!, 'center')).toEqual({ textAlign: 'center' })
  })

  it('creates typed patches for multi-select and switch-like fields', () => {
    const activationMode = getElementPropertySchema('input-field')
      .find(field => field.key === 'activationMode')
    const allowDelete = getElementPropertySchema('input-field')
      .find(field => field.key === 'allowDelete')

    expect(activationMode).toBeDefined()
    expect(allowDelete).toBeDefined()
    expect(createElementPropertyPatch(activationMode!, ['Program', 'F2', 'MouseDblClick'])).toEqual({
      activationMode: ['Program', 'F2', 'MouseDblClick'],
    })
    expect(createElementPropertyPatch(allowDelete!, false)).toEqual({ allowDelete: false })
  })

  it('normalizes multi-select values for selected option rendering', () => {
    expect(getElementPropertyMultiSelectValues('Program F2 MouseDblClick')).toEqual([
      'Program',
      'F2',
      'MouseDblClick',
    ])
    expect(isElementPropertyMultiSelectOptionSelected(['Program', 'F2'], 'F2')).toBe(true)
    expect(isElementPropertyMultiSelectOptionSelected('Program F2 MouseDblClick', 'MouseDblClick')).toBe(true)
    expect(isElementPropertyMultiSelectOptionSelected('Program F2 MouseDblClick', 'MouseClick')).toBe(false)
  })

  it('marks activation mode as an Element-style multi-select field', () => {
    const activationMode = getElementPropertySchema('input-field')
      .find(field => field.writerName === 'EditorActiveMode')

    expect(activationMode).toMatchObject({
      key: 'activationMode',
      kind: 'multi-select',
      component: 'element-select',
      collapseTags: true,
    })
  })

  it('summarizes and validates static list item JSON like the online editor', () => {
    type StaticListItemLike = {
      Text: string
      TextInList?: string | null
      Value: string
      Group?: string | null
      Tag?: string | null
      ID?: string | number | null
    }
    const schemaModule = elementPropertySchema as unknown as {
      parseStaticListItems?: (value: string) => StaticListItemLike[]
      summarizeStaticListItems?: (value: string) => string
      stringifyStaticListItems?: (items: StaticListItemLike[]) => string
      validateStaticListItems?: (items: StaticListItemLike[]) => { ok: boolean; message?: string }
    }

    expect(typeof schemaModule.parseStaticListItems).toBe('function')
    expect(typeof schemaModule.summarizeStaticListItems).toBe('function')
    expect(typeof schemaModule.stringifyStaticListItems).toBe('function')
    expect(typeof schemaModule.validateStaticListItems).toBe('function')
    if (!schemaModule.parseStaticListItems || !schemaModule.summarizeStaticListItems || !schemaModule.stringifyStaticListItems || !schemaModule.validateStaticListItems) {
      return
    }

    const source = '[{"Text":"男","TextInList":"","Value":"1","Group":null,"Tag":null,"ID":null},{"Text":"女","TextInList":null,"Value":"2","Group":"基本","Tag":"demo","ID":12}]'
    const items = schemaModule.parseStaticListItems(source)

    expect(items).toEqual([
      { Text: '男', TextInList: '', Value: '1', Group: null, Tag: null, ID: null },
      { Text: '女', TextInList: null, Value: '2', Group: '基本', Tag: 'demo', ID: 12 },
    ])
    expect(schemaModule.summarizeStaticListItems(source)).toBe('2项')
    expect(schemaModule.summarizeStaticListItems('not-json')).toBe('双击新增..')
    expect(schemaModule.validateStaticListItems(items)).toEqual({ ok: true })
    expect(schemaModule.validateStaticListItems([{ Text: '', TextInList: null, Value: '1', Group: null, Tag: null, ID: null }])).toEqual({
      ok: false,
      message: '文本不可为空，请检查配置',
    })
    expect(schemaModule.stringifyStaticListItems(items)).toBe('[{"Text":"男","TextInList":"","Value":"1","Group":null,"Tag":null,"ID":null},{"Text":"女","TextInList":null,"Value":"2","Group":"基本","Tag":"demo","ID":12}]')
  })
})
