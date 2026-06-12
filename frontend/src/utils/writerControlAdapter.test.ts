import { describe, expect, it, vi } from 'vitest'
import { createWriterControlAdapter, type WriterControlTarget } from './writerControlAdapter'

describe('writerControlAdapter', () => {
  it('reports unavailable writer when saving before the external editor is loaded', () => {
    const adapter = createWriterControlAdapter(null)

    expect(adapter.isAvailable()).toBe(false)
    expect(adapter.saveXml()).toEqual({
      ok: false,
      reason: 'writer-unavailable',
      message: '外部编辑器尚未加载，无法执行该操作。',
    })
  })

  it('loads XML through LoadDocumentFromString', () => {
    const target: WriterControlTarget = {
      LoadDocumentFromString: vi.fn(() => true),
    }

    expect(createWriterControlAdapter(target).loadXml('<document />')).toEqual({ ok: true })
    expect(target.LoadDocumentFromString).toHaveBeenCalledWith('<document />', 'xml', null, undefined)
  })

  it('reports unavailable load API when LoadDocumentFromString is missing', () => {
    expect(createWriterControlAdapter({}).loadXml('<document />')).toEqual({
      ok: false,
      reason: 'load-api-unavailable',
      message: '当前外部编辑器未暴露 XML 加载接口。',
    })
  })

  it('normalizes rejected XML load requests', () => {
    const target: WriterControlTarget = {
      LoadDocumentFromString: vi.fn(() => false),
    }

    expect(createWriterControlAdapter(target).loadXml('<document />')).toEqual({
      ok: false,
      reason: 'command-rejected',
      message: '编辑器未接受 XML 加载请求。',
    })
  })

  it('executes commands through DCExecuteCommand by default', () => {
    const target: WriterControlTarget = {
      DCExecuteCommand: vi.fn(() => true),
      ExecuteCommand: vi.fn(() => true),
    }

    const result = createWriterControlAdapter(target).executeCommand({
      commandName: 'bold',
      showUI: false,
      parameter: { value: true },
    })

    expect(result).toEqual({ ok: true })
    expect(target.DCExecuteCommand).toHaveBeenCalledWith('bold', false, { value: true })
    expect(target.ExecuteCommand).not.toHaveBeenCalled()
  })

  it('restores WriterControl focus before executing toolbar commands', () => {
    const focus = vi.fn(() => true)
    const executeCommand = vi.fn(() => true)
    const target: WriterControlTarget = {
      Focus: focus,
      DCExecuteCommand: executeCommand,
    }

    const result = createWriterControlAdapter(target).executeCommand({
      commandName: 'Bold',
      showUI: false,
    })

    expect(result).toEqual({ ok: true })
    expect(focus).toHaveBeenCalledBefore(executeCommand)
  })

  it('executes commands through legacy ExecuteCommand when requested', () => {
    const target: WriterControlTarget = {
      DCExecuteCommand: vi.fn(() => true),
      ExecuteCommand: vi.fn(() => true),
    }

    const result = createWriterControlAdapter(target).executeCommand({
      commandName: 'fontSize',
      showUI: true,
      parameter: 16,
      executor: 'legacy',
    })

    expect(result).toEqual({ ok: true })
    expect(target.ExecuteCommand).toHaveBeenCalledWith('fontSize', true, 16)
    expect(target.DCExecuteCommand).not.toHaveBeenCalled()
  })

  it('returns XML saved through SaveDocumentToString', () => {
    const target: WriterControlTarget = {
      SaveDocumentToString: vi.fn(() => '<document />'),
    }

    expect(createWriterControlAdapter(target).saveXml()).toEqual({
      ok: true,
      xml: '<document />',
    })
    expect(target.SaveDocumentToString).toHaveBeenCalledWith({ FileFormat: 'XML' })
  })

  it('returns exported document content through SaveDocumentToString for supported local formats', () => {
    const target: WriterControlTarget = {
      SaveDocumentToString: vi.fn(() => '{"document":true}'),
    }

    expect(createWriterControlAdapter(target).saveDocument('json')).toEqual({
      ok: true,
      format: 'json',
      content: '{"document":true}',
    })
    expect(target.SaveDocumentToString).toHaveBeenCalledWith({ FileFormat: 'json' })
  })

  it('returns RTF content for DOC-compatible exports', () => {
    const target: WriterControlTarget = {
      SaveDocumentToString: vi.fn(() => '{\\rtf1}'),
    }

    expect(createWriterControlAdapter(target).saveDocument('rtf')).toEqual({
      ok: true,
      format: 'rtf',
      content: '{\\rtf1}',
    })
    expect(target.SaveDocumentToString).toHaveBeenCalledWith({ FileFormat: 'rtf' })
  })

  it('adds WriterControl page settings to saved HTML content', () => {
    const target: WriterControlTarget = {
      SaveDocumentToString: vi.fn(() => '<html><head><title>病案首页</title></head><body></body></html>'),
      GetDocumentPageSettings: vi.fn(() => ({
        PaperWidthInCM: 21,
        LeftMarginInCM: 2,
        RightMarginInCM: 1.5,
      })),
    }

    const result = createWriterControlAdapter(target).saveDocument('html')

    expect(result).toEqual({
      ok: true,
      format: 'html',
      content: '<html><head><title>病案首页</title><style>body{margin-left:auto;margin-right:auto;width:21cm;padding-left:2cm;padding-right:1.5cm;box-sizing:border-box;}</style></head><body></body></html>',
    })
  })

  it('exports PDF through the print API instead of WriterControl local.pdf download', () => {
    const target: WriterControlTarget = {
      DownLoadFile: vi.fn(() => true),
      PrintDocument: vi.fn(() => true),
    }
    const adapter = createWriterControlAdapter(target)

    expect(adapter.exportPdfFile()).toEqual({ ok: true })
    expect(target.PrintDocument).toHaveBeenCalledWith({ PrintRange: 'AllPages' })
    expect(target.DownLoadFile).not.toHaveBeenCalled()
  })

  it('rejects direct WriterControl local.pdf downloads to avoid WASM font memory overflow', () => {
    const target: WriterControlTarget = {
      DownLoadFile: vi.fn(() => true),
    }

    expect(createWriterControlAdapter(target).downloadDocumentFile('pdf', '西医病案首页')).toEqual({
      ok: false,
      reason: 'command-rejected',
      message: 'PDF 导出已切换为浏览器打印保存，避免 WriterControl 本地 PDF 生成读取字体时内存溢出。',
    })
    expect(target.DownLoadFile).not.toHaveBeenCalled()
  })

  it('downloads DOC and HTML through the WriterControl local export API', () => {
    const target: WriterControlTarget = {
      DownLoadFile: vi.fn(() => true),
    }
    const adapter = createWriterControlAdapter(target)

    expect(adapter.downloadDocumentFile('doc', '西医病案首页')).toEqual({
      ok: true,
      format: 'doc',
      writerFormat: 'rtf',
    })
    expect(adapter.downloadDocumentFile('html', '西医病案首页')).toEqual({
      ok: true,
      format: 'html',
      writerFormat: 'html',
    })
    expect(target.DownLoadFile).toHaveBeenNthCalledWith(1, 'rtf', '西医病案首页')
    expect(target.DownLoadFile).toHaveBeenNthCalledWith(2, 'html', '西医病案首页')
  })

  it('reports unavailable local export API when DownLoadFile is missing', () => {
    expect(createWriterControlAdapter({}).downloadDocumentFile('html', '西医病案首页')).toEqual({
      ok: false,
      reason: 'download-api-unavailable',
      message: '当前外部编辑器未暴露本地文件导出接口。',
    })
  })

  it('reports unavailable save API when SaveDocumentToString is missing', () => {
    expect(createWriterControlAdapter({}).saveXml()).toEqual({
      ok: false,
      reason: 'save-api-unavailable',
      message: '当前外部编辑器未暴露 XML 保存接口。',
    })
  })

  it('reports empty save result when SaveDocumentToString returns an empty string', () => {
    const target: WriterControlTarget = {
      SaveDocumentToString: vi.fn(() => ''),
    }

    expect(createWriterControlAdapter(target).saveXml()).toEqual({
      ok: false,
      reason: 'save-empty',
      message: '编辑器未返回可保存的 XML 内容。',
    })
  })

  it('normalizes rejected writer commands', () => {
    const target: WriterControlTarget = {
      DCExecuteCommand: vi.fn(() => false),
    }

    expect(
      createWriterControlAdapter(target).executeCommand({
        commandName: 'bold',
        showUI: false,
      }),
    ).toEqual({
      ok: false,
      reason: 'command-rejected',
      message: '编辑器未接受命令：bold。',
    })
  })

  it('forwards command status when available and returns null otherwise', () => {
    const target: WriterControlTarget = {
      GetCommandStatus: vi.fn(() => ({ enabled: true })),
    }

    expect(createWriterControlAdapter(target).getCommandStatus('bold')).toEqual({ enabled: true })
    expect(target.GetCommandStatus).toHaveBeenCalledWith('bold')
    expect(createWriterControlAdapter({}).getCommandStatus('bold')).toBeNull()
    expect(createWriterControlAdapter(null).getCommandStatus('bold')).toBeNull()
  })

  it('binds WriterControl content change callback and DOM edit fallbacks', () => {
    const addEventListener = vi.fn()
    const removeEventListener = vi.fn()
    const target: WriterControlTarget = {
      addEventListener,
      removeEventListener,
    }
    const onChange = vi.fn()

    const dispose = createWriterControlAdapter(target).onContentChanged(onChange)
    target.DocumentContentChanged?.(target, { TriggerType: 'test' })
    addEventListener.mock.calls
      .filter(([eventName]) => eventName === 'input')
      .forEach(([, handler]) => handler(new Event('input')))

    expect(onChange).toHaveBeenCalledTimes(2)
    expect(addEventListener).toHaveBeenCalledWith('input', expect.any(Function), true)
    expect(addEventListener).toHaveBeenCalledWith('change', expect.any(Function), true)
    expect(addEventListener).toHaveBeenCalledWith('paste', expect.any(Function), true)
    expect(addEventListener).toHaveBeenCalledWith('cut', expect.any(Function), true)

    dispose()

    expect(target.DocumentContentChanged).toBeUndefined()
    expect(removeEventListener).toHaveBeenCalledWith('input', expect.any(Function), true)
    expect(removeEventListener).toHaveBeenCalledWith('change', expect.any(Function), true)
    expect(removeEventListener).toHaveBeenCalledWith('paste', expect.any(Function), true)
    expect(removeEventListener).toHaveBeenCalledWith('cut', expect.any(Function), true)
  })

  it('binds WriterControl selection change callback and DOM selection fallbacks after WriterControl state settles', () => {
    vi.useFakeTimers()
    const previousSelectionChanged = vi.fn()
    const addEventListener = vi.fn()
    const removeEventListener = vi.fn()
    const target: WriterControlTarget = {
      SelectionChanged: previousSelectionChanged,
      addEventListener,
      removeEventListener,
    }
    const onSelectionChanged = vi.fn()

    const dispose = createWriterControlAdapter(target).onSelectionChanged(onSelectionChanged)
    target.SelectionChanged?.(target, { TriggerType: 'test' })
    addEventListener.mock.calls
      .filter(([eventName]) => eventName === 'click')
      .forEach(([, handler]) => handler(new Event('click')))

    expect(previousSelectionChanged).toHaveBeenCalledWith(target, { TriggerType: 'test' })
    expect(onSelectionChanged).not.toHaveBeenCalled()
    vi.runOnlyPendingTimers()
    expect(onSelectionChanged).toHaveBeenCalledTimes(1)
    expect(addEventListener).toHaveBeenCalledWith('click', expect.any(Function), true)
    expect(addEventListener).toHaveBeenCalledWith('mouseup', expect.any(Function), true)
    expect(addEventListener).toHaveBeenCalledWith('keyup', expect.any(Function), true)

    dispose()

    expect(target.SelectionChanged).toBe(previousSelectionChanged)
    expect(removeEventListener).toHaveBeenCalledWith('click', expect.any(Function), true)
    expect(removeEventListener).toHaveBeenCalledWith('mouseup', expect.any(Function), true)
    expect(removeEventListener).toHaveBeenCalledWith('keyup', expect.any(Function), true)
    vi.useRealTimers()
  })

  it('refreshes element selection from WriterControl field focus and blur events', () => {
    vi.useFakeTimers()
    const previousFieldOnFocus = vi.fn()
    const previousFieldOnBlur = vi.fn()
    const target: WriterControlTarget = {
      EventFieldOnFocus: previousFieldOnFocus,
      EventFieldOnBlur: previousFieldOnBlur,
    }
    const onSelectionChanged = vi.fn()

    const dispose = createWriterControlAdapter(target).onSelectionChanged(onSelectionChanged)
    target.EventFieldOnFocus?.({ TypeName: 'XTextInputFieldElement' })
    target.EventFieldOnBlur?.({ TypeName: 'XTextInputFieldElement' })

    expect(previousFieldOnFocus).toHaveBeenCalledWith({ TypeName: 'XTextInputFieldElement' })
    expect(previousFieldOnBlur).toHaveBeenCalledWith({ TypeName: 'XTextInputFieldElement' })
    expect(onSelectionChanged).not.toHaveBeenCalled()
    vi.runOnlyPendingTimers()
    expect(onSelectionChanged).toHaveBeenCalledTimes(1)

    dispose()

    expect(target.EventFieldOnFocus).toBe(previousFieldOnFocus)
    expect(target.EventFieldOnBlur).toBe(previousFieldOnBlur)
    vi.useRealTimers()
  })

  it('does not overwrite a newer WriterControl content change callback when disposed', () => {
    const previousContentChanged = vi.fn()
    const nextContentChanged = vi.fn()
    const removeEventListener = vi.fn()
    const target: WriterControlTarget = {
      DocumentContentChanged: previousContentChanged,
      removeEventListener,
    }

    const dispose = createWriterControlAdapter(target).onContentChanged(vi.fn())
    target.DocumentContentChanged = nextContentChanged

    dispose()

    expect(target.DocumentContentChanged).toBe(nextContentChanged)
    expect(removeEventListener).toHaveBeenCalledTimes(4)
  })

  it('delegates print operations to existing writer print helpers', () => {
    const target: WriterControlTarget = {
      PrintDocument: vi.fn(() => true),
      LoadPrintPreview: vi.fn(() => true),
      ClosePrintPreview: vi.fn(() => true),
    }
    const adapter = createWriterControlAdapter(target)

    expect(adapter.print()).toEqual({ ok: true })
    expect(target.PrintDocument).toHaveBeenCalledWith({ PrintRange: 'AllPages' })

    expect(adapter.openPrintPreview()).toEqual({ ok: true })
    expect(target.LoadPrintPreview).toHaveBeenCalledWith({ PrintRange: 'AllPages' })

    expect(adapter.closePrintPreview()).toEqual({ ok: true })
    expect(target.ClosePrintPreview).toHaveBeenCalled()
  })
})
