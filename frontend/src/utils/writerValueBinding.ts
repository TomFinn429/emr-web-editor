import type { EditorElementProperties } from '../types/editorElement'

export interface WriterValueBinding extends Record<string, unknown> {
  DataSource?: string
  BindingPath?: string
  BindingPathForText?: string
}

export function parseWriterValueBinding(value: unknown): WriterValueBinding | undefined {
  if (value && typeof value === 'object' && !Array.isArray(value)) {
    return value as WriterValueBinding
  }

  if (typeof value !== 'string' || !value.trim()) {
    return undefined
  }

  try {
    const parsed = JSON.parse(value)
    return parsed && typeof parsed === 'object' && !Array.isArray(parsed)
      ? parsed as WriterValueBinding
      : undefined
  } catch {
    return undefined
  }
}

export function readWriterValueBindingString(
  valueBinding: WriterValueBinding | undefined,
  names: string[],
) {
  if (!valueBinding) return ''

  for (const name of names) {
    const value = valueBinding[name]
    if (typeof value === 'string' && value.trim()) {
      return value
    }
    if (typeof value === 'number') {
      return String(value)
    }
  }

  return ''
}

export function composeWriterValueBinding(
  properties: Pick<EditorElementProperties, 'bindingPath' | 'code' | 'dataSourceName' | 'textBindingPath' | 'valueBinding'>,
): WriterValueBinding {
  return {
    ...parseWriterValueBinding(properties.valueBinding),
    DataSource: properties.dataSourceName || '',
    BindingPath: properties.bindingPath || properties.code || '',
    BindingPathForText: properties.textBindingPath || '',
  }
}
