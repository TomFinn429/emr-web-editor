import type { DocumentExportFormat, WriterCommandPayload } from '../types/document'
import type { WriterPrintTarget } from './writerPrint'
import {
  closeWriterPrintPreview,
  printWriterDocument,
  showWriterPrintPreview,
  type WriterPrintResult,
} from './writerPrint'

export interface WriterControlTarget extends WriterPrintTarget {
  LoadDocumentFromString?: (
    xml: string,
    format: string,
    specifyLoadPart?: unknown,
    errorCallback?: ((result: unknown) => void),
  ) => boolean | void
  SaveDocumentToString?: (options?: unknown, textOptions?: unknown) => string
  DownLoadFile?: (format: string, fileName?: string) => boolean | void
  GetDocumentPageSettings?: () => Partial<WriterDocumentPageSettings> | null | undefined
  DCExecuteCommand?: (commandName: string, showUI: boolean, parameter?: unknown) => boolean | void
  ExecuteCommand?: (commandName: string, showUI: boolean, parameter?: unknown) => boolean | void
  Focus?: () => boolean | void
  GetCommandStatus?: (commandName: string) => unknown
  addEventListener?: HTMLElement['addEventListener']
  removeEventListener?: HTMLElement['removeEventListener']
  DocumentContentChanged?: (sender: unknown, args: unknown) => void
  SelectionChanged?: (sender: unknown, args: unknown) => void
  DocumentSelectionChanged?: (sender: unknown, args: unknown) => void
  EventFieldOnFocus?: (...args: unknown[]) => void
  EventFieldOnBlur?: (...args: unknown[]) => void
  RefreshDocument?: () => boolean | void
  RefreshInnerView?: (fastMode?: boolean) => boolean | void
  EditorRefreshView?: () => boolean | void
  UpdateDocumentView?: () => boolean | void
  InvalidateAllView?: () => boolean | void
  ApplyDocumentOptions?: () => boolean | void
  getCommentList?: () => WriterComment[]
  setCommentContent?: (index: number, text: string) => boolean | void
  UserLoginByUserLoginInfo?: (loginInfo: WriterTraceUser, updateUI?: boolean) => boolean | void
  UserLoginByParameter?: (
    userID: string,
    userName: string,
    permissionLevel?: string | number,
  ) => boolean | void
  ComplexViewMode?: () => boolean | void
  CleanViewMode?: () => boolean | void
  InComplexViewMode?: () => boolean
  InCleanViewMode?: () => boolean
  GetDocumentUserTrackInfos?: (cleanMode?: boolean) => unknown
  NavigateByUserTrackInfo?: (nativeHandle: number) => boolean | void
  DocumentOptions?: {
    BehaviorOptions?: {
      CommentVisibility?: WriterCommentVisibility
    }
    SecurityOptions?: {
      TrackVisibleLevel1?: Partial<WriterTraceVisualLevel>
      [key: string]: unknown
    }
  }
}

export type WriterCommentVisibility = 'Auto' | 'Visible' | 'Hide'

export interface WriterComment {
  Index?: number
  Text?: string
  Author?: string
  AuthorID?: string
  CreationTime?: string
  Attributes?: Record<string, unknown>
  [key: string]: unknown
}

export interface WriterCommentOptions {
  Text: string
  author?: string
  Author?: string
  AuthorID?: string
  Attributes?: Record<string, unknown>
  BackColor?: string
  BorderColor?: string
  ForeColor?: string
}

export interface WriterTraceUser {
  ID: string
  Name: string
  ClientName?: string
  PermissionLevel?: string | number
  Description?: string
}

export interface WriterTraceInfo {
  NativeHandle?: number | string
  InfoType?: string
  Text?: string
  UserName?: string
  SaveTime?: string
  [key: string]: unknown
}

export interface WriterTraceVisualLevel {
  DeleteLineNum: string
  DeleteLineColorString: string
  UnderLineColorString: string
  UnderLineColorNum: string
  BackgroundColorString: string
}

export type WriterTraceViewMode = 'complex' | 'clean'

export type WriterAdapterFailureReason =
  | 'writer-unavailable'
  | 'load-api-unavailable'
  | 'save-api-unavailable'
  | 'download-api-unavailable'
  | 'command-api-unavailable'
  | 'comment-api-unavailable'
  | 'trace-api-unavailable'
  | 'command-rejected'
  | 'save-empty'

export type WriterAdapterFailure = {
  ok: false
  reason: WriterAdapterFailureReason
  message: string
}

export type WriterAdapterResult = { ok: true } | WriterAdapterFailure

export type WriterSaveResult = { ok: true; xml: string } | WriterAdapterFailure

export type WriterSaveDocumentFormat = DocumentExportFormat | 'text' | 'rtf'

export type WriterDocumentSaveResult =
  | { ok: true; format: WriterSaveDocumentFormat; content: string }
  | WriterAdapterFailure

export type WriterDocumentDownloadResult =
  | { ok: true; format: DocumentExportFormat; writerFormat: string }
  | WriterAdapterFailure

export type WriterTraceListResult =
  | { ok: true; traces: WriterTraceInfo[] }
  | WriterAdapterFailure

export interface WriterDocumentPageSettings {
  PaperWidthInCM: number
  LeftMarginInCM: number
  RightMarginInCM: number
}

const writerUnavailableMessage = '外部编辑器尚未加载，无法执行该操作。'

export const defaultTraceVisualLevel = {
  DeleteLineNum: '2',
  DeleteLineColorString: 'Black',
  UnderLineColorString: 'Yellow',
  UnderLineColorNum: '2',
  BackgroundColorString: 'LightGrey',
} satisfies WriterTraceVisualLevel

export function createWriterControlAdapter(target: WriterControlTarget | null) {
  return {
    isAvailable() {
      return target !== null
    },

    loadXml(xml: string): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.LoadDocumentFromString !== 'function') {
        return {
          ok: false,
          reason: 'load-api-unavailable',
          message: '当前外部编辑器未暴露 XML 加载接口。',
        }
      }

      return normalizeWriterResult(
        target.LoadDocumentFromString(xml, 'xml', null, undefined),
        '编辑器未接受 XML 加载请求。',
      )
    },

    executeCommand(payload: WriterCommandPayload): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      const execute =
        payload.executor === 'legacy' ? target.ExecuteCommand : target.DCExecuteCommand

      if (typeof execute !== 'function') {
        return {
          ok: false,
          reason: 'command-api-unavailable',
          message: '当前外部编辑器未暴露命令执行接口。',
        }
      }

      target.Focus?.()
      return normalizeWriterResult(
        execute.call(target, payload.commandName, payload.showUI, payload.parameter ?? null),
        `编辑器未接受命令：${payload.commandName}。`,
      )
    },

    getCommandStatus(commandName: string): unknown {
      if (!target || typeof target.GetCommandStatus !== 'function') {
        return null
      }

      return target.GetCommandStatus(commandName)
    },

    insertComment(options: WriterCommentOptions): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.DCExecuteCommand !== 'function') {
        return commentApiUnavailable('当前外部编辑器未暴露批注插入接口。')
      }

      target.Focus?.()
      return normalizeWriterResult(
        target.DCExecuteCommand('insertcomment', true, options),
        '编辑器未接受批注插入请求。',
      )
    },

    getCommentList(): { ok: true; comments: WriterComment[] } | WriterAdapterFailure {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.getCommentList !== 'function') {
        return commentApiUnavailable('当前外部编辑器未暴露批注列表接口。')
      }

      const comments = target.getCommentList()
      return { ok: true, comments: Array.isArray(comments) ? comments : [] }
    },

    setCommentContent(index: number, text: string): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.setCommentContent !== 'function') {
        return commentApiUnavailable('当前外部编辑器未暴露批注修改接口。')
      }

      const result = normalizeWriterResult(
        target.setCommentContent(index, text),
        '编辑器未接受批注修改请求。',
      )
      if (result.ok) {
        target.RefreshDocument?.()
      }

      return result
    },

    deleteCurrentComment(): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.DCExecuteCommand !== 'function') {
        return commentApiUnavailable('当前外部编辑器未暴露批注删除接口。')
      }

      const result = normalizeWriterResult(
        target.DCExecuteCommand('DeleteComment', false, null),
        '编辑器未接受批注删除请求。',
      )
      if (result.ok) {
        target.RefreshDocument?.()
      }

      return result
    },

    setCommentVisibility(visibility: WriterCommentVisibility): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      if (!target.DocumentOptions?.BehaviorOptions) {
        return commentApiUnavailable('当前外部编辑器未暴露批注显示选项。')
      }

      target.DocumentOptions.BehaviorOptions.CommentVisibility = visibility
      target.ApplyDocumentOptions?.()
      target.RefreshDocument?.()
      return { ok: true }
    },

    loginTraceUser(user: WriterTraceUser): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      let loginResult: WriterAdapterResult
      if (typeof target.UserLoginByUserLoginInfo === 'function') {
        loginResult = normalizeWriterResult(
          target.UserLoginByUserLoginInfo(user, true),
          '编辑器未接受留痕用户登录请求。',
        )
      } else if (typeof target.UserLoginByParameter === 'function') {
        loginResult = normalizeWriterResult(
          target.UserLoginByParameter(user.ID, user.Name, user.PermissionLevel),
          '编辑器未接受留痕用户登录请求。',
        )
      } else {
        return traceApiUnavailable('当前外部编辑器未暴露留痕登录接口。')
      }

      if (!loginResult.ok) {
        return loginResult
      }

      return applyTraceVisualOptionsToTarget(target)
    },

    applyTraceVisualOptions(): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      return applyTraceVisualOptionsToTarget(target)
    },

    setTraceViewMode(mode: WriterTraceViewMode): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      const directMethod = mode === 'complex' ? target.ComplexViewMode : target.CleanViewMode
      if (typeof directMethod === 'function') {
        const result = normalizeWriterResult(
          directMethod.call(target),
          mode === 'complex' ? '编辑器未接受留痕视图切换请求。' : '编辑器未接受清洁视图切换请求。',
        )
        if (result.ok) {
          refreshWriterTraceView(target)
        }
        return result
      }

      if (typeof target.DCExecuteCommand === 'function') {
        const commandName = mode === 'complex' ? 'ComplexViewMode' : 'CleanViewMode'
        const result = normalizeWriterResult(
          target.DCExecuteCommand(commandName, false, null),
          mode === 'complex' ? '编辑器未接受留痕视图切换请求。' : '编辑器未接受清洁视图切换请求。',
        )
        if (result.ok) {
          refreshWriterTraceView(target)
        }
        return result
      }

      return traceApiUnavailable('当前外部编辑器未暴露留痕视图切换接口。')
    },

    getTraceViewMode(): WriterTraceViewMode | null {
      if (!target) {
        return null
      }

      if (typeof target.InComplexViewMode === 'function' && target.InComplexViewMode()) {
        return 'complex'
      }

      if (typeof target.InCleanViewMode === 'function' && target.InCleanViewMode()) {
        return 'clean'
      }

      return null
    },

    getTraceList(options?: { cleanMode?: boolean }): WriterTraceListResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.GetDocumentUserTrackInfos !== 'function') {
        return traceApiUnavailable('当前外部编辑器未暴露留痕列表接口。')
      }

      const traces = target.GetDocumentUserTrackInfos(options?.cleanMode)
      return { ok: true, traces: Array.isArray(traces) ? traces : [] }
    },

    navigateToTrace(nativeHandle: number): WriterAdapterResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.NavigateByUserTrackInfo !== 'function') {
        return traceApiUnavailable('当前外部编辑器未暴露留痕定位接口。')
      }

      target.Focus?.()
      return normalizeWriterResult(
        target.NavigateByUserTrackInfo(nativeHandle),
        '编辑器未接受留痕定位请求。',
      )
    },

    onContentChanged(callback: () => void) {
      if (!target) {
        return () => {}
      }

      const previousDocumentContentChanged = target.DocumentContentChanged
      const contentChangedHandler = (sender: unknown, args: unknown) => {
        previousDocumentContentChanged?.call(target, sender, args)
        callback()
      }
      target.DocumentContentChanged = contentChangedHandler

      const fallbackEvents = ['input', 'change', 'paste', 'cut'] as const
      const fallbackHandler = () => callback()
      fallbackEvents.forEach((eventName) => {
        target.addEventListener?.(eventName, fallbackHandler, true)
      })

      return () => {
        if (target.DocumentContentChanged === contentChangedHandler) {
          target.DocumentContentChanged = previousDocumentContentChanged
        }

        fallbackEvents.forEach((eventName) => {
          target.removeEventListener?.(eventName, fallbackHandler, true)
        })
      }
    },

    onSelectionChanged(callback: () => void) {
      if (!target) {
        return () => {}
      }

      const previousSelectionChanged = target.SelectionChanged
      const previousDocumentSelectionChanged = target.DocumentSelectionChanged
      const previousEventFieldOnFocus = target.EventFieldOnFocus
      const previousEventFieldOnBlur = target.EventFieldOnBlur
      let pendingSelectionRefresh: ReturnType<typeof setTimeout> | null = null
      const scheduleSelectionRefresh = () => {
        if (pendingSelectionRefresh !== null) {
          return
        }
        pendingSelectionRefresh = setTimeout(() => {
          pendingSelectionRefresh = null
          callback()
        }, 0)
      }
      const selectionChangedHandler = (sender: unknown, args: unknown) => {
        previousSelectionChanged?.call(target, sender, args)
        scheduleSelectionRefresh()
      }
      const documentSelectionChangedHandler = (sender: unknown, args: unknown) => {
        previousDocumentSelectionChanged?.call(target, sender, args)
        scheduleSelectionRefresh()
      }
      const fieldOnFocusHandler = (...args: unknown[]) => {
        previousEventFieldOnFocus?.call(target, ...args)
        scheduleSelectionRefresh()
      }
      const fieldOnBlurHandler = (...args: unknown[]) => {
        previousEventFieldOnBlur?.call(target, ...args)
        scheduleSelectionRefresh()
      }
      target.SelectionChanged = selectionChangedHandler
      target.DocumentSelectionChanged = documentSelectionChangedHandler
      target.EventFieldOnFocus = fieldOnFocusHandler
      target.EventFieldOnBlur = fieldOnBlurHandler

      const fallbackEvents = ['click', 'mouseup', 'keyup'] as const
      const fallbackHandler = () => scheduleSelectionRefresh()
      fallbackEvents.forEach((eventName) => {
        target.addEventListener?.(eventName, fallbackHandler, true)
      })

      return () => {
        if (pendingSelectionRefresh !== null) {
          clearTimeout(pendingSelectionRefresh)
          pendingSelectionRefresh = null
        }
        if (target.SelectionChanged === selectionChangedHandler) {
          target.SelectionChanged = previousSelectionChanged
        }
        if (target.DocumentSelectionChanged === documentSelectionChangedHandler) {
          target.DocumentSelectionChanged = previousDocumentSelectionChanged
        }
        if (target.EventFieldOnFocus === fieldOnFocusHandler) {
          target.EventFieldOnFocus = previousEventFieldOnFocus
        }
        if (target.EventFieldOnBlur === fieldOnBlurHandler) {
          target.EventFieldOnBlur = previousEventFieldOnBlur
        }

        fallbackEvents.forEach((eventName) => {
          target.removeEventListener?.(eventName, fallbackHandler, true)
        })
      }
    },

    saveXml(): WriterSaveResult {
      const result = this.saveDocument('xml')
      if (result.ok) {
        return { ok: true, xml: result.content }
      }
      if (result.reason === 'save-api-unavailable') {
        return {
          ...result,
          message: '当前外部编辑器未暴露 XML 保存接口。',
        }
      }
      if (result.reason === 'save-empty') {
        return {
          ...result,
          message: '编辑器未返回可保存的 XML 内容。',
        }
      }
      return result
    },

    saveDocument(format: WriterSaveDocumentFormat): WriterDocumentSaveResult {
      if (!target) {
        return writerUnavailable()
      }

      if (typeof target.SaveDocumentToString !== 'function') {
        return {
          ok: false,
          reason: 'save-api-unavailable',
          message: '当前外部编辑器未暴露文档保存接口。',
        }
      }

      const content = target.SaveDocumentToString({ FileFormat: writerSaveFormat(format) })
      if (!content) {
        return {
          ok: false,
          reason: 'save-empty',
          message: '编辑器未返回可保存的文档内容。',
        }
      }

      return { ok: true, format, content: normalizeSavedDocumentContent(format, content, target) }
    },

    downloadDocumentFile(format: DocumentExportFormat, fileName?: string): WriterDocumentDownloadResult {
      if (!target) {
        return writerUnavailable()
      }

      if (format === 'pdf') {
        return {
          ok: false,
          reason: 'command-rejected',
          message: 'PDF 导出已切换为浏览器打印保存，避免 WriterControl 本地 PDF 生成读取字体时内存溢出。',
        }
      }

      if (typeof target.DownLoadFile !== 'function') {
        return {
          ok: false,
          reason: 'download-api-unavailable',
          message: '当前外部编辑器未暴露本地文件导出接口。',
        }
      }

      const writerFormat = writerDownloadFormat(format)
      const result = normalizeWriterResult(
        target.DownLoadFile(writerFormat, fileName),
        `编辑器未接受 ${format.toUpperCase()} 本地导出请求。`,
      )
      if (!result.ok) {
        return result
      }

      return { ok: true, format, writerFormat }
    },

    exportPdfFile(): WriterPrintResult {
      return printWriterDocument(target)
    },

    print() {
      return printWriterDocument(target)
    },

    openPrintPreview() {
      return showWriterPrintPreview(target)
    },

    closePrintPreview() {
      return closeWriterPrintPreview(target)
    },
  }
}

function applyTraceVisualOptionsToTarget(target: WriterControlTarget): WriterAdapterResult {
  if (!target.DocumentOptions?.SecurityOptions) {
    return traceApiUnavailable('当前外部编辑器未暴露留痕显示选项。')
  }

  target.DocumentOptions.SecurityOptions.TrackVisibleLevel1 ??= {}
  Object.assign(target.DocumentOptions.SecurityOptions.TrackVisibleLevel1, defaultTraceVisualLevel)
  target.ApplyDocumentOptions?.()
  refreshWriterTraceView(target)
  return { ok: true }
}

function refreshWriterTraceView(target: WriterControlTarget) {
  if (typeof target.RefreshInnerView === 'function') {
    target.RefreshInnerView(false)
    return
  }

  target.RefreshDocument?.()
  target.EditorRefreshView?.()
  target.UpdateDocumentView?.()
  target.InvalidateAllView?.()
}

function writerSaveFormat(format: WriterSaveDocumentFormat) {
  if (format === 'xml') return 'XML'
  if (format === 'txt') return 'text'
  return format
}

function writerDownloadFormat(format: DocumentExportFormat) {
  if (format === 'doc') return 'rtf'
  if (format === 'txt') return 'text'
  return format
}

function normalizeSavedDocumentContent(
  format: WriterSaveDocumentFormat,
  content: string,
  target: WriterControlTarget,
) {
  if (format !== 'html') {
    return content
  }

  const pageSettings = target.GetDocumentPageSettings?.()
  if (!pageSettings) {
    return content
  }

  const headerPattern = /<head>([\s\S]*?)<\/head>/i
  const match = content.match(headerPattern)
  if (!match) {
    return content
  }

  const bodyStyle = createHtmlBodyPageStyle(pageSettings)
  return content.replace(headerPattern, `<head>${match[1]}<style>${bodyStyle}</style></head>`)
}

function createHtmlBodyPageStyle(pageSettings: Partial<WriterDocumentPageSettings>) {
  const width = typeof pageSettings.PaperWidthInCM === 'number' ? `${pageSettings.PaperWidthInCM}cm` : 'auto'
  const left = typeof pageSettings.LeftMarginInCM === 'number' ? pageSettings.LeftMarginInCM : 0
  const right = typeof pageSettings.RightMarginInCM === 'number' ? pageSettings.RightMarginInCM : 0
  return `body{margin-left:auto;margin-right:auto;width:${width};padding-left:${left}cm;padding-right:${right}cm;box-sizing:border-box;}`
}

function writerUnavailable(): WriterAdapterFailure {
  return {
    ok: false,
    reason: 'writer-unavailable',
    message: writerUnavailableMessage,
  }
}

function commentApiUnavailable(message: string): WriterAdapterFailure {
  return {
    ok: false,
    reason: 'comment-api-unavailable',
    message,
  }
}

function traceApiUnavailable(message: string): WriterAdapterFailure {
  return {
    ok: false,
    reason: 'trace-api-unavailable',
    message,
  }
}

function normalizeWriterResult(result: boolean | void, falseMessage: string): WriterAdapterResult {
  if (result === false) {
    return {
      ok: false,
      reason: 'command-rejected',
      message: falseMessage,
    }
  }

  return { ok: true }
}
