import type { TemplateContent, TemplateSummary } from '../types/document'

export async function fetchTemplates(): Promise<TemplateSummary[]> {
  const response = await fetch('/api/templates')
  return readJsonResponse<TemplateSummary[]>(response, '模板列表加载失败。')
}

export async function fetchTemplateContent(id: string): Promise<TemplateContent> {
  const response = await fetch(`/api/templates/${encodeURIComponent(id)}`)
  return readJsonResponse<TemplateContent>(response, '模板内容加载失败。')
}

async function readJsonResponse<T>(response: Response, fallbackMessage: string): Promise<T> {
  const payload = await response.json().catch(() => null)
  if (!response.ok) {
    throw new Error(readErrorMessage(payload) || fallbackMessage)
  }

  return payload as T
}

function readErrorMessage(payload: unknown) {
  if (payload && typeof payload === 'object' && 'message' in payload) {
    return String((payload as { message?: unknown }).message || '')
  }

  return ''
}
