import { shallowRef } from 'vue'
import { describe, expect, it } from 'vitest'
import { useElementInspector } from './useElementInspector'

describe('useElementInspector', () => {
  it('clears the mock input field when WriterControl has no editable selection', () => {
    const writerTarget = shallowRef(null)
    const inspector = useElementInspector({ writerTarget })

    inspector.refreshFromWriter()

    expect(inspector.selectedElement.value).toMatchObject({
      type: 'none',
      name: '未选择元素',
      supportLevel: 'mock',
    })
    expect(inspector.updateStatus.value).toMatchObject({
      ok: false,
      status: 'no-selection',
      reason: 'no-selection',
    })
  })

  it('keeps a real WriterControl input field editable after refresh', () => {
    const inputRef = { kind: 'input-ref' }
    const writerTarget = shallowRef({
      CurrentInputField: () => inputRef,
      GetElementProperties: () => ({
        TypeName: 'XTextInputFieldElement',
        ID: 'Patient.Name',
        Name: '患者姓名',
        NativeHandle: 101,
      }),
    })
    const inspector = useElementInspector({ writerTarget })

    inspector.refreshFromWriter()

    expect(inspector.selectedElement.value).toMatchObject({
      type: 'input-field',
      id: 'Patient.Name',
      name: '患者姓名',
      supportLevel: 'writer',
    })
    expect(inspector.canEditSelectedElement.value).toBe(true)
  })
})
