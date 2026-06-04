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
  normalizeColorPickerValue,
  parseValidationRule,
  stringifyValidationRule,
  toColorPickerValue,
  VALIDATION_RULE_DESCRIPTION_ROWS,
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
      'backgroundColor',
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
    expect(createElementPropertyPatch(readonly!, '')).toEqual({ readonly: 'Inherit' })
    expect(createElementPropertyPatch(textAlign!, 'center')).toEqual({ textAlign: 'center' })
  })

  it('restores online ContentReadonly defaults and select options', () => {
    const readonly = getElementPropertySchema('input-field').find(field => field.writerName === 'ContentReadonly')

    expect(readonly).toMatchObject({
      key: 'readonly',
      label: '只读',
      kind: 'select',
      defaultValue: 'Inherit',
      allowEmptyOption: false,
      options: [
        { label: '只读', value: 'true' },
        { label: '不只读', value: 'false' },
        { label: '继承父节点', value: 'Inherit' },
      ],
    })
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

  it('models ValidateStyle as the online structured validation editor', () => {
    const validationRule = getElementPropertySchema('input-field')
      .find(field => field.writerName === 'ValidateStyle')

    expect(validationRule).toMatchObject({
      key: 'validationRule',
      label: '校验',
      kind: 'validation-rule',
      placeholder: '{"CheckMaxValue":true,"CheckMinValue":true,"MaxValue":0,"MinValue":0}',
    })

    const parsed = parseValidationRule('{"Required":true,"CustomMessage":"必填","ExcludeKeywords":"禁用","IncludeKeywords":"允许","MinLength":2,"MaxLength":20,"CheckMinValue":true,"MinValue":1,"CheckMaxValue":true,"MaxValue":99,"CheckDecimalDigits":true,"MaxDecimalDigits":2,"DateTimeMinValue":"2026-01-01","DateTimeMaxValue":"2026-12-31","RegExpression":"^[0-9]+$"}')

    expect(parsed).toEqual({
      Required: true,
      CustomMessage: '必填',
      ExcludeKeywords: '禁用',
      IncludeKeywords: '允许',
      MinLength: 2,
      MaxLength: 20,
      CheckMinValue: true,
      MinValue: 1,
      CheckMaxValue: true,
      MaxValue: 99,
      CheckDecimalDigits: true,
      MaxDecimalDigits: 2,
      DateTimeMinValue: '2026-01-01',
      DateTimeMaxValue: '2026-12-31',
      RegExpression: '^[0-9]+$',
    })
    expect(stringifyValidationRule(parsed)).toBe('{"Required":true,"CustomMessage":"必填","ExcludeKeywords":"禁用","IncludeKeywords":"允许","MinLength":2,"MaxLength":20,"CheckMinValue":true,"MinValue":1,"CheckMaxValue":true,"MaxValue":99,"CheckDecimalDigits":true,"MaxDecimalDigits":2,"DateTimeMinValue":"2026-01-01","DateTimeMaxValue":"2026-12-31","RegExpression":"^[0-9]+$"}')
    expect(VALIDATION_RULE_DESCRIPTION_ROWS).toEqual([
      [
        { property: 'Required:', description: '必填数据 (true/false)' },
        { property: 'CustomMessage:', description: '错误提示' },
      ],
      [
        { property: 'ExcludeKeywords:', description: '违禁关键字(string)' },
        { property: 'IncludeKeywords:', description: '允许关键字(string)' },
      ],
      [
        { property: 'MinLength:', description: '最小长度(Numeric)' },
        { property: 'MaxLength:', description: '最大长度(Numeric)' },
      ],
      [
        { property: 'CheckMinValue:', description: '校验最小值(true/false)' },
        { property: 'MinValue:', description: '最小值(Numeric)' },
      ],
      [
        { property: 'CheckMaxValue:', description: '校验最大值(true/false)' },
        { property: 'MaxValue:', description: '最大值(Numeric)' },
      ],
      [
        { property: 'CheckDecimalDigits:', description: '校验最大小数位数(true/false)' },
        { property: 'MaxDecimalDigits:', description: '最大小数位数(Numeric)' },
      ],
      [
        { property: 'DateTimeMinValue:', description: '最小时间日期值(DateTime)' },
        { property: 'DateTimeMaxValue:', description: '最大时间日期值(DateTime)' },
      ],
      [
        { property: 'RegExpression:', description: '正则表达式文字(string)' },
        { property: 'ValueType:', description: '类型(Text/Numeric/DateTime/RegExpress)' },
      ],
    ])
  })

  it('models Attributes as the online custom attributes editor', () => {
    type CustomAttributeItemLike = {
      Text: string
      Value: string
    }
    const schemaModule = elementPropertySchema as unknown as {
      parseCustomAttributes?: (value: string) => CustomAttributeItemLike[]
      summarizeCustomAttributes?: (value: string) => string
      stringifyCustomAttributes?: (items: CustomAttributeItemLike[]) => string
      validateCustomAttributes?: (items: CustomAttributeItemLike[]) => { ok: boolean; message?: string }
    }
    const attributes = getElementPropertySchema('input-field')
      .find(field => field.writerName === 'Attributes')

    expect(attributes).toMatchObject({
      key: 'customProperties',
      label: '自定义属性',
      kind: 'custom-attributes',
      placeholder: '双击编辑..',
    })
    expect(typeof schemaModule.parseCustomAttributes).toBe('function')
    expect(typeof schemaModule.summarizeCustomAttributes).toBe('function')
    expect(typeof schemaModule.stringifyCustomAttributes).toBe('function')
    expect(typeof schemaModule.validateCustomAttributes).toBe('function')
    if (!schemaModule.parseCustomAttributes || !schemaModule.summarizeCustomAttributes || !schemaModule.stringifyCustomAttributes || !schemaModule.validateCustomAttributes) {
      return
    }

    const source = '{"height":"180","weight":"140","breathe":"60"}'
    const items = schemaModule.parseCustomAttributes(source)

    expect(items).toEqual([
      { Text: 'height', Value: '180' },
      { Text: 'weight', Value: '140' },
      { Text: 'breathe', Value: '60' },
    ])
    expect(schemaModule.summarizeCustomAttributes(source)).toBe('3项')
    expect(schemaModule.summarizeCustomAttributes('')).toBe('双击新增..')
    expect(schemaModule.summarizeCustomAttributes('not-json')).toBe('双击新增..')
    expect(schemaModule.summarizeCustomAttributes('[{"Text":"height","Value":"180"}]')).toBe('双击新增..')
    expect(schemaModule.validateCustomAttributes(items)).toEqual({ ok: true })
    expect(schemaModule.validateCustomAttributes([{ Text: '', Value: '180' }])).toEqual({
      ok: false,
      message: '属性名称不能为空',
    })
    expect(schemaModule.stringifyCustomAttributes(items)).toBe('{"height":"180","weight":"140","breathe":"60"}')
  })

  it('keeps online 8-digit hex color values when using the color picker', () => {
    const colorFields = getElementPropertySchema('input-field')
      .filter(field => [
        'TextColor',
        'BackgroundTextColor',
        'Style.BackgroundColorString',
      ].includes(field.writerName))

    expect(colorFields).toEqual([
      expect.objectContaining({ key: 'textColor', kind: 'color' }),
      expect.objectContaining({ key: 'backgroundTextColor', kind: 'color' }),
      expect.objectContaining({ key: 'backgroundColor', kind: 'color' }),
    ])
    expect(toColorPickerValue('#FFFFFF00')).toBe('rgba(255, 255, 255, 0)')
    expect(toColorPickerValue('#00000080')).toBe('rgba(0, 0, 0, 0.5)')
    expect(normalizeColorPickerValue('rgba(255, 255, 255, 0)')).toBe('#FFFFFF00')
    expect(normalizeColorPickerValue('rgba(0, 0, 0, 0.5)')).toBe('#00000080')
    expect(normalizeColorPickerValue('#336699')).toBe('#336699FF')
    expect(normalizeColorPickerValue('#336699CC')).toBe('#336699CC')
    expect(normalizeColorPickerValue('transparent')).toBe('transparent')
  })
})
