import type { DocumentSource, SaveDocumentResponse } from '../types/document'
import type { WriterSaveResult } from '../utils/writerControlAdapter'

interface SaveAdapter {
  saveXml: () => WriterSaveResult
}

export interface SaveDocumentOptions {
  sessionId: string
  fileName: string
  source: DocumentSource
}

export type BackendSaveResult =
  | { ok: true; response: SaveDocumentResponse; xml: string }
  | { ok: false; reason: 'adapter-failed'; message: string }
  | { ok: false; reason: 'backend-failed'; message: string; xml: string }

export interface DownloadDocumentOptions {
  fileName: string
  extension: string
  content: string | BlobPart[]
  mimeType: string
}

export async function saveDocumentToBackend(
  adapter: SaveAdapter,
  options: SaveDocumentOptions,
): Promise<BackendSaveResult> {
  const saveResult = adapter.saveXml()
  if (!saveResult.ok) {
    return { ok: false, reason: 'adapter-failed', message: saveResult.message }
  }

  let response: Response
  try {
    response = await fetch('/api/documents/save', {
      method: 'POST',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify({
        sessionId: options.sessionId,
        fileName: options.fileName,
        xml: saveResult.xml,
        source: options.source,
        updatedAt: new Date().toISOString(),
      }),
    })
  } catch (error) {
    return {
      ok: false,
      reason: 'backend-failed',
      message: error instanceof Error ? error.message : '文档保存失败。',
      xml: saveResult.xml,
    }
  }

  const payload = await response.json().catch(() => null)
  if (!response.ok) {
    return {
      ok: false,
      reason: 'backend-failed',
      message: readErrorMessage(payload) || '文档保存失败。',
      xml: saveResult.xml,
    }
  }

  return { ok: true, response: payload as SaveDocumentResponse, xml: saveResult.xml }
}

export function downloadXml(fileName: string, xml: string) {
  downloadDocument({
    fileName: fileName || 'document.xml',
    extension: 'xml',
    content: xml,
    mimeType: 'application/xml;charset=utf-8',
  })
}

export function downloadDocument(options: DownloadDocumentOptions) {
  const content = Array.isArray(options.content) ? options.content : [options.content]
  const blob = new Blob(content, { type: options.mimeType })
  const url = URL.createObjectURL(blob)
  const anchor = document.createElement('a')
  anchor.href = url
  anchor.download = withExtension(options.fileName, options.extension)
  document.body.appendChild(anchor)
  anchor.click()
  document.body.removeChild(anchor)
  setTimeout(() => URL.revokeObjectURL(url), 0)
}

function withExtension(fileName: string, extension: string) {
  const normalizedExtension = extension.replace(/^\./, '')
  const baseName = fileName.trim() || `document.${normalizedExtension}`
  return baseName.replace(/\.[^.\\/]+$/, '') + `.${normalizedExtension}`
}

function readErrorMessage(payload: unknown) {
  if (payload && typeof payload === 'object' && 'message' in payload) {
    return String((payload as { message?: unknown }).message || '')
  }

  return ''
}
