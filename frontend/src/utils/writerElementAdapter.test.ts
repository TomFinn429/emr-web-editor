import { describe, expect, it, vi } from 'vitest'
import { createDefaultElementProperties } from '../services/elementPropertyService'
import {
  insertCodeElement,
  insertFragmentTemplate,
  readSelectedWriterElement,
  updateSelectedWriterElementProperties,
} from './writerElementAdapter'

describe('writerElementAdapter', () => {
  it('reports unavailable writer element inspection explicitly', () => {
    expect(readSelectedWriterElement(null)).toEqual({
      ok: false,
      reason: 'writer-unavailable',
      message: '外部编辑器尚未加载，无法读取当前选中元素。',
    })
  })

  it('normalizes a selected input field exposed by WriterControl-like APIs', () => {
    const target = {
      GetCurrentElement: vi.fn(() => ({
        TypeName: 'XInputField',
        ID: 'Patient.Name',
        Name: '患者姓名',
        InnerValue: '张三',
        ContentReadonly: false,
        Required: true,
        Visible: true,
      })),
    }

    expect(readSelectedWriterElement(target)).toMatchObject({
      ok: true,
      element: {
        type: 'input-field',
        id: 'Patient.Name',
        name: '患者姓名',
        defaultValue: '张三',
        required: true,
      },
    })
  })

  it('normalizes missing ContentReadonly to the online inherited state', () => {
    const target = {
      GetCurrentElement: vi.fn(() => ({
        TypeName: 'XInputField',
        ID: 'Patient.Name',
        Name: '患者姓名',
      })),
    }

    expect(readSelectedWriterElement(target)).toMatchObject({
      ok: true,
      element: {
        readonly: 'Inherit',
      },
    })
  })

  it('reads current input field through confirmed WriterControl APIs', () => {
    const inputRef = { serializeAsArg: vi.fn() }
    const currentInputField = vi.fn(() => inputRef)
    const getElementProperties = vi.fn(() => ({
      TypeName: 'XTextInputFieldElement',
      ID: 'Patient.Age',
      Name: '年龄',
      InnerValue: '42',
      ContentReadonly: 'False',
      Visible: 'True',
      EditorActiveMode: 'Program F2 MouseDblClick',
      ValueBinding: {
        BindingPath: 'Patient.Age',
      },
    }))

    expect(readSelectedWriterElement({
      CurrentInputField: currentInputField,
      GetElementProperties: getElementProperties,
    })).toMatchObject({
      ok: true,
      element: {
        type: 'input-field',
        id: 'Patient.Age',
        name: '年龄',
        defaultValue: '42',
        bindingPath: 'Patient.Age',
        activationMode: ['Program', 'F2', 'MouseDblClick'],
        supportLevel: 'writer',
      },
    })
    expect(getElementProperties).toHaveBeenCalledWith(inputRef, false)
  })

  it('splits ValueBinding JSON into assignment fields for the property panel', () => {
    expect(readSelectedWriterElement({
      GetCurrentElement: vi.fn(() => ({
        TypeName: 'XTextInputFieldElement',
        ID: 'Patient.Age',
        Name: '年龄',
        DataSource: 'stale-top-level',
        BindingPath: 'Stale.BindingPath',
        BindingPathForText: 'Stale.TextPath',
        ValueBinding: JSON.stringify({
          DataSource: 'patient',
          BindingPath: 'Patient.Age.Value',
          BindingPathForText: 'Patient.Age.Text',
        }),
      })),
    })).toMatchObject({
      ok: true,
      element: {
        type: 'input-field',
        dataSourceName: 'patient',
        bindingPath: 'Patient.Age.Value',
        textBindingPath: 'Patient.Age.Text',
      },
    })
  })

  it('reads independent online color properties from the current input field', () => {
    expect(readSelectedWriterElement({
      GetCurrentElement: vi.fn(() => ({
        TypeName: 'XTextInputFieldElement',
        ID: 'Patient.Color',
        Name: '颜色字段',
        TextColor: '#D43C3CFF',
        BackgroundTextColor: '#0000FFFF',
        Style: {
          BackgroundColorString: '#FFFFFF00',
        },
      })),
    })).toMatchObject({
      ok: true,
      element: {
        textColor: '#D43C3CFF',
        backgroundTextColor: '#0000FFFF',
        backgroundColor: '#FFFFFF00',
      },
    })
  })

  it('does not normalize plain text characters as editable input fields', () => {
    expect(readSelectedWriterElement({
      CurrentElement: vi.fn(() => ({ _id: 'char-ref' })),
      GetElementProperties: vi.fn(() => ({
        TypeName: 'XTextCharElement',
        NativeHandle: 569,
        Text: '医',
      })),
    })).toEqual({
      ok: false,
      reason: 'unsupported',
      message: '当前 WriterControl 选中元素暂不支持属性编辑。',
    })
  })

  it('reads current table cell, row, and table through confirmed WriterControl APIs', () => {
    const cellRef = { kind: 'cell-ref' }
    const rowRef = { kind: 'row-ref' }
    const tableRef = { kind: 'table-ref' }

    expect(readSelectedWriterElement({
      CurrentTableCell: vi.fn(() => cellRef),
      GetElementProperties: vi.fn(() => ({
        TypeName: 'XTableCellElement',
        ID: 'cell-1-1',
        Name: '评分单元格',
        TableID: 'ScoreTable',
        RowIndex: 1,
        ColumnIndex: 1,
        CellPosition: '第 1 行，第 1 列',
        Width: 80,
        Height: 24,
        Alignment: 'Center',
        BindingPath: 'Score.Value',
      })),
    })).toMatchObject({
      ok: true,
      element: {
        type: 'table-cell',
        id: 'cell-1-1',
        tableId: 'ScoreTable',
        rowIndex: 1,
        columnIndex: 1,
        cellPosition: '第 1 行，第 1 列',
        textAlign: 'Center',
        bindingPath: 'Score.Value',
      },
    })

    expect(readSelectedWriterElement({
      CurrentTableRow: vi.fn(() => rowRef),
      GetElementProperties: vi.fn(() => ({
        TypeName: 'XTableRowElement',
        ID: 'row-1',
        Name: '评分行',
        TableID: 'ScoreTable',
        RowIndex: 1,
        Height: 28,
        VisibleExpression: '[Score]>0',
      })),
    })).toMatchObject({
      ok: true,
      element: {
        type: 'table-row',
        tableId: 'ScoreTable',
        rowIndex: 1,
        height: 28,
        visibleExpression: '[Score]>0',
      },
    })

    expect(readSelectedWriterElement({
      CurrentTable: vi.fn(() => tableRef),
      GetElementProperties: vi.fn(() => ({
        TypeName: 'XTableElement',
        ID: 'ScoreTable',
        Name: '评分表',
        RowCount: 5,
        ColumnCount: 4,
        Width: 520,
        Deleteable: false,
      })),
    })).toMatchObject({
      ok: true,
      element: {
        type: 'table',
        id: 'ScoreTable',
        rowCount: 5,
        columnCount: 4,
        width: 520,
        allowDelete: false,
      },
    })
  })

  it('updates selected writer element properties when a supported setter exists', () => {
    const setCurrentElementProperties = vi.fn(() => true)
    const element = createDefaultElementProperties('input-field')

    expect(updateSelectedWriterElementProperties({ SetCurrentElementProperties: setCurrentElementProperties }, element)).toEqual({
      ok: true,
      status: 'success',
      message: '元素属性已同步到 WriterControl。',
    })
    expect(setCurrentElementProperties).toHaveBeenCalledWith(element)
  })

  it('writes normalized properties through SetElementProperties for the current WriterControl element', () => {
    const inputRef = { serializeAsArg: vi.fn() }
    const currentInputField = vi.fn(() => inputRef)
    const getElementProperties = vi.fn(() => ({
      TypeName: 'XTextInputFieldElement',
      NativeHandle: 101,
    }))
    const setElementProperties = vi.fn(() => true)
    const element = {
      ...createDefaultElementProperties('input-field'),
      id: 'Patient.Name',
      code: 'Patient.Name',
      name: '患者姓名',
      defaultValue: '李四',
      readonly: true,
      required: true,
      visible: false,
      dataSourceName: 'patient',
      bindingPath: 'Patient.Name',
      textBindingPath: 'Patient.Name.Text',
      valueBinding: {
        DataSource: 'stale',
        BindingPath: 'Stale.Path',
        BindingPathForText: 'Stale.TextPath',
      },
      activationMode: ['Program', 'F2', 'MouseDblClick'],
    }

    expect(updateSelectedWriterElementProperties({
      CurrentInputField: currentInputField,
      GetElementProperties: getElementProperties,
      SetElementProperties: setElementProperties,
    }, element)).toEqual({
      ok: true,
      status: 'success',
      message: '元素属性已同步到 WriterControl。',
    })
    expect(getElementProperties).toHaveBeenCalledWith(inputRef, false)
    expect(setElementProperties).toHaveBeenCalledWith(101, expect.objectContaining({
      ID: 'Patient.Name',
      Name: '患者姓名',
      BackgroundText: '患者姓名',
      InnerValue: '李四',
      ContentReadonly: true,
      Required: true,
      Visible: false,
      EditorActiveMode: 'Program F2 MouseDblClick',
      DataSource: 'patient',
      ValueBinding: {
        DataSource: 'patient',
        BindingPath: 'Patient.Name',
        BindingPathForText: 'Patient.Name.Text',
      },
      BindingPath: 'Patient.Name',
      BindingPathForText: 'Patient.Name.Text',
    }), true)
  })

  it('falls back to the current element reference when WriterControl properties do not include NativeHandle', () => {
    const inputRef = { serializeAsArg: vi.fn() }
    const setElementProperties = vi.fn(() => true)

    expect(updateSelectedWriterElementProperties({
      CurrentInputField: vi.fn(() => inputRef),
      GetElementProperties: vi.fn(() => ({
        TypeName: 'XTextInputFieldElement',
      })),
      SetElementProperties: setElementProperties,
    }, createDefaultElementProperties('input-field'))).toMatchObject({ ok: true })

    expect(setElementProperties).toHaveBeenCalledWith(inputRef, expect.any(Object), true)
  })

  it('writes structured ValidateStyle JSON through SetElementProperties', () => {
    const inputRef = { serializeAsArg: vi.fn() }
    const setElementProperties = vi.fn(() => true)

    expect(updateSelectedWriterElementProperties({
      CurrentInputField: vi.fn(() => inputRef),
      SetElementProperties: setElementProperties,
    }, {
      ...createDefaultElementProperties('input-field'),
      validationRule: '{"Required":true,"CheckMaxValue":true,"MaxValue":99}',
    })).toMatchObject({ ok: true })

    expect(setElementProperties).toHaveBeenCalledWith(inputRef, expect.objectContaining({
      ValidateStyle: {
        Required: true,
        CheckMaxValue: true,
        MaxValue: 99,
      },
    }), true)
  })

  it('writes independent online color properties without rewriting alpha values', () => {
    const inputRef = { serializeAsArg: vi.fn() }
    const setElementProperties = vi.fn(() => true)

    expect(updateSelectedWriterElementProperties({
      CurrentInputField: vi.fn(() => inputRef),
      SetElementProperties: setElementProperties,
    }, {
      ...createDefaultElementProperties('input-field'),
      textColor: '#D43C3CFF',
      backgroundTextColor: '#18259B00',
      backgroundColor: '#FFFFFF00',
    })).toMatchObject({ ok: true })

    expect(setElementProperties).toHaveBeenCalledWith(inputRef, expect.objectContaining({
      TextColor: '#D43C3CFF',
      BackgroundTextColor: '#18259B00',
      Style: {
        BackgroundColorString: '#FFFFFF00',
      },
    }), true)
  })

  it('writes table cell, row, and table properties through their current WriterControl elements', () => {
    const cellRef = { kind: 'cell-ref' }
    const rowRef = { kind: 'row-ref' }
    const tableRef = { kind: 'table-ref' }
    const setElementProperties = vi.fn(() => true)

    expect(updateSelectedWriterElementProperties({
      CurrentTableCell: vi.fn(() => cellRef),
      SetElementProperties: setElementProperties,
    }, {
      ...createDefaultElementProperties('table-cell'),
      id: 'cell-1-1',
      name: '评分单元格',
      tableId: 'ScoreTable',
      rowIndex: 1,
      columnIndex: 1,
      width: 80,
      height: 24,
      textAlign: 'Center',
      bindingPath: 'Score.Value',
      placeholder: '评分',
    })).toMatchObject({ ok: true })

    expect(updateSelectedWriterElementProperties({
      CurrentTableRow: vi.fn(() => rowRef),
      SetElementProperties: setElementProperties,
    }, {
      ...createDefaultElementProperties('table-row'),
      id: 'row-1',
      name: '评分行',
      tableId: 'ScoreTable',
      rowIndex: 1,
      height: 28,
      visibleExpression: '[Score]>0',
      allowDelete: false,
    })).toMatchObject({ ok: true })

    expect(updateSelectedWriterElementProperties({
      CurrentTable: vi.fn(() => tableRef),
      SetElementProperties: setElementProperties,
    }, {
      ...createDefaultElementProperties('table'),
      id: 'ScoreTable',
      name: '评分表',
      rowCount: 5,
      columnCount: 4,
      width: 520,
      allowDelete: false,
    })).toMatchObject({ ok: true })

    expect(setElementProperties).toHaveBeenNthCalledWith(1, cellRef, expect.objectContaining({
      ID: 'cell-1-1',
      Name: '评分单元格',
      TableID: 'ScoreTable',
      RowIndex: 1,
      ColumnIndex: 1,
      Width: 80,
      Height: 24,
      Alignment: 'Center',
      BindingPath: 'Score.Value',
      BackgroundText: '评分',
    }), true)
    expect(setElementProperties).toHaveBeenNthCalledWith(2, rowRef, expect.objectContaining({
      ID: 'row-1',
      Name: '评分行',
      TableID: 'ScoreTable',
      RowIndex: 1,
      Height: 28,
      VisibleExpression: '[Score]>0',
      Deleteable: false,
    }), true)
    expect(setElementProperties).toHaveBeenNthCalledWith(3, tableRef, expect.objectContaining({
      ID: 'ScoreTable',
      Name: '评分表',
      RowCount: 5,
      ColumnCount: 4,
      Width: 520,
      Deleteable: false,
    }), true)
  })

  it('inserts fragment XML through confirmed InsertXmlString API', () => {
    const insertXmlString = vi.fn(() => true)

    expect(insertFragmentTemplate({ InsertXmlString: insertXmlString }, '<XTextDocument />')).toEqual({
      ok: true,
      status: 'success',
      message: '片段模板已插入到当前光标位置。',
    })
    expect(insertXmlString).toHaveBeenCalledWith('<XTextDocument />')
  })

  it('inserts barcode and qrcode through confirmed WriterControl command names', () => {
    const dcExecuteCommand = vi.fn(() => true)

    expect(insertCodeElement({ DCExecuteCommand: dcExecuteCommand }, 'barcode', createDefaultElementProperties('barcode'))).toEqual({
      ok: true,
      status: 'success',
      message: '条形码已提交给 WriterControl 插入。',
    })
    expect(insertCodeElement({ DCExecuteCommand: dcExecuteCommand }, 'qrcode', createDefaultElementProperties('qrcode'))).toEqual({
      ok: true,
      status: 'success',
      message: '二维码已提交给 WriterControl 插入。',
    })
    expect(dcExecuteCommand).toHaveBeenNthCalledWith(1, 'insertbarcodeelement', true, expect.objectContaining({
      Text: 'DC-EMR-0001',
      Width: 180,
      Height: 56,
    }))
    expect(dcExecuteCommand).toHaveBeenNthCalledWith(2, 'inserttdbarcodeelement', true, expect.objectContaining({
      Text: 'DC-EMR-0001',
      Width: 120,
      Height: 120,
    }))
  })

  it('keeps unsupported writer operations explicit for mock fallback', () => {
    const element = createDefaultElementProperties('qrcode')

    expect(updateSelectedWriterElementProperties({}, element)).toEqual({
      ok: false,
      status: 'unsupported',
      reason: 'unsupported',
      message: '当前 WriterControl 未暴露元素属性写入接口，已保留前端 mock 状态。',
    })
    expect(insertFragmentTemplate({}, '<XTextDocument />')).toEqual({
      ok: false,
      status: 'unsupported',
      reason: 'unsupported',
      message: '当前 WriterControl 未暴露片段模板插入接口，未修改文档内容。',
    })
  })
})
