import { describe, expect, it } from 'vitest'
import {
  createElementPropertyPatch,
  getElementPropertySchema,
} from './elementPropertySchema'

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
      'border',
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
})
