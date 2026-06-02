import { describe, expect, it } from 'vitest'
import {
  composeWriterValueBinding,
  parseWriterValueBinding,
  readWriterValueBindingString,
} from './writerValueBinding'

describe('writerValueBinding', () => {
  it('parses JSON strings returned by Writer ValueBinding', () => {
    const valueBinding = parseWriterValueBinding(JSON.stringify({
      DataSource: 'patient',
      BindingPath: 'Patient.Name.Value',
      BindingPathForText: 'Patient.Name.Text',
    }))

    expect(readWriterValueBindingString(valueBinding, ['DataSource'])).toBe('patient')
    expect(readWriterValueBindingString(valueBinding, ['BindingPath'])).toBe('Patient.Name.Value')
    expect(readWriterValueBindingString(valueBinding, ['BindingPathForText'])).toBe('Patient.Name.Text')
  })

  it('composes current visible assignment fields over stale carrier values', () => {
    expect(composeWriterValueBinding({
      dataSourceName: 'patient',
      bindingPath: 'Patient.Name.Value',
      textBindingPath: 'Patient.Name.Text',
      valueBinding: {
        DataSource: 'stale',
        BindingPath: 'Stale.Value',
        BindingPathForText: 'Stale.Text',
        Extra: 'kept',
      },
    })).toEqual({
      DataSource: 'patient',
      BindingPath: 'Patient.Name.Value',
      BindingPathForText: 'Patient.Name.Text',
      Extra: 'kept',
    })
  })
})
