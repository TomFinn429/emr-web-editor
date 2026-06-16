import type { WriterTraceInfo, WriterTraceUser } from '../utils/writerControlAdapter'

export interface DefaultTraceUserOptions {
  templateName?: string | null
  authorName?: string | null
}

export interface TraceIdentityOption extends WriterTraceUser {
  label: string
}

export interface FormattedWriterTrace {
  key: string
  nativeHandle: number | null
  actionKind: 'insert' | 'delete' | 'check' | 'uncheck' | 'change'
  actionSymbol: '+' | '-' | '✓' | '×' | '•'
  actionTone: 'insert' | 'delete' | 'neutral'
  typeLabel: string
  summary: string
  fullText: string
  userName: string
  userColor: string
  reviewTitle: string
  timeText: string
  trace: WriterTraceInfo
}

const traceTypeLabels: Record<string, string> = {
  Create: '新增',
  Checked: '勾选',
  UnChecked: '去掉勾选',
  Delete: '删除',
}

const defaultTraceUserId = 'emr-web-editor-demo'
const defaultTraceClientName = 'emr-web-editor'
const defaultTracePermissionLevel = 2
const maxSummaryLength = 60
const fallbackUserColors = ['#2472b3', '#2f7d5c', '#b25d00', '#7654a3', '#a34343']

export const traceIdentityOptions: TraceIdentityOption[] = [
  {
    ID: 'template-maker',
    Name: '模板制作员',
    ClientName: defaultTraceClientName,
    PermissionLevel: 2,
    Description: '模板制作员身份演示',
    label: '模板制作员',
  },
  {
    ID: 'attending-doctor',
    Name: '张三主任医师',
    ClientName: defaultTraceClientName,
    PermissionLevel: 4,
    Description: '主任医师身份演示',
    label: '张三主任医师',
  },
  {
    ID: 'review-doctor',
    Name: '李四审核医师',
    ClientName: defaultTraceClientName,
    PermissionLevel: 3,
    Description: '审核医师身份演示',
    label: '李四审核医师',
  },
]

export function createDefaultTraceUser(options: DefaultTraceUserOptions): WriterTraceUser {
  const templateName = normalizeText(options.templateName)
  return {
    ID: defaultTraceUserId,
    Name: normalizeText(options.authorName) || '演示医生',
    ClientName: defaultTraceClientName,
    PermissionLevel: defaultTracePermissionLevel,
    Description: templateName ? `${templateName}实时留痕演示用户` : '实时留痕演示用户',
  }
}

export function findTraceIdentityById(identityId: string) {
  return traceIdentityOptions.find(option => option.ID === identityId) ?? null
}

export function formatTraceList(traces: readonly WriterTraceInfo[]) {
  return traces.map((trace, index) => formatTraceInfo(trace, index))
}

export function formatTraceInfo(trace: WriterTraceInfo, index = 0): FormattedWriterTrace {
  const fullText = normalizeText(trace.Text)
  const nativeHandle = parseNativeHandle(trace.NativeHandle)
  const typeLabel = getTraceTypeLabel(trace.InfoType)
  const userName = normalizeText(trace.UserName) || '未知用户'
  const action = getTraceAction(trace.InfoType)
  return {
    key: getTraceKey(trace, index),
    nativeHandle,
    actionKind: action.kind,
    actionSymbol: action.symbol,
    actionTone: action.tone,
    typeLabel,
    summary: summarizeTraceText(fullText),
    fullText,
    userName,
    userColor: getTraceUserColor(userName),
    reviewTitle: `${userName} ${typeLabel}`,
    timeText: formatTraceTime(trace.SaveTime),
    trace,
  }
}

export function getTraceKey(trace: WriterTraceInfo, index: number) {
  const nativeHandle = normalizeText(trace.NativeHandle)
  if (nativeHandle) {
    return nativeHandle
  }

  return [
    normalizeText(trace.UserName) || 'trace',
    normalizeText(trace.SaveTime) || 'time',
    index,
  ].join('-')
}

export function getTraceTypeLabel(infoType: unknown) {
  const type = normalizeText(infoType)
  if (!type) {
    return '修改'
  }

  return traceTypeLabels[type] || type
}

export function getTraceAction(infoType: unknown) {
  const type = normalizeText(infoType)
  if (type === 'Create') {
    return { kind: 'insert', symbol: '+', tone: 'insert' } as const
  }

  if (type === 'Delete') {
    return { kind: 'delete', symbol: '-', tone: 'delete' } as const
  }

  if (type === 'Checked') {
    return { kind: 'check', symbol: '✓', tone: 'neutral' } as const
  }

  if (type === 'UnChecked') {
    return { kind: 'uncheck', symbol: '×', tone: 'neutral' } as const
  }

  return { kind: 'change', symbol: '•', tone: 'neutral' } as const
}

export function getTraceUserColor(userName: string) {
  const identityIndex = traceIdentityOptions.findIndex(identity =>
    identity.Name === userName
    || identity.Name.includes(userName)
    || userName.includes(identity.Name),
  )
  if (identityIndex >= 0) {
    return fallbackUserColors[identityIndex % fallbackUserColors.length]
  }

  const hash = Array.from(userName).reduce((total, char) => total + char.charCodeAt(0), 0)
  return fallbackUserColors[hash % fallbackUserColors.length]
}

export function summarizeTraceText(text: string) {
  if (!text) {
    return '无正文摘要'
  }

  if (text.length <= maxSummaryLength) {
    return text
  }

  return `${text.slice(0, maxSummaryLength)}...`
}

export function formatTraceTime(value: unknown) {
  const text = normalizeText(value)
  if (!text) {
    return ''
  }

  const date = new Date(text)
  if (Number.isNaN(date.getTime())) {
    return ''
  }

  const year = date.getFullYear()
  const month = padDatePart(date.getMonth() + 1)
  const day = padDatePart(date.getDate())
  const hours = padDatePart(date.getHours())
  const minutes = padDatePart(date.getMinutes())
  const seconds = padDatePart(date.getSeconds())
  return `${year}-${month}-${day} ${hours}:${minutes}:${seconds}`
}

function parseNativeHandle(value: unknown) {
  const handle = Number(value)
  return Number.isFinite(handle) ? handle : null
}

function normalizeText(value: unknown) {
  return String(value ?? '').replace(/\s+/g, ' ').trim()
}

function padDatePart(value: number) {
  return String(value).padStart(2, '0')
}
