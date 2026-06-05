import { createQualityControlReport } from '../../services/qcRuleEngine'
import type { DocumentSource, ImportedDocument, ValidationIssue } from '../../types/document'

export interface PreviewDocumentInput {
  id: string
  fileName: string
  xml: string
  warnings: readonly string[]
  source: DocumentSource
  templateId?: string
}

export function toPreviewDocument(document: PreviewDocumentInput | null): ImportedDocument | null {
  if (!document) {
    return null
  }

  return {
    id: document.id,
    fileName: document.fileName,
    xml: document.xml,
    warnings: [...document.warnings],
    renderMode: 'canvas',
  }
}

export function canReplaceCurrentDocument(
  isDirty: boolean,
  confirmDiscard: () => boolean,
) {
  return !isDirty || confirmDiscard()
}

export function createReportFromValidationIssues(
  documentId: string,
  issues: readonly ValidationIssue[],
) {
  return createQualityControlReport(documentId, issues.map(issue => ({
    id: issue.id,
    category: 'required',
    severity: issue.severity,
    title: issue.fieldName,
    message: issue.message,
    suggestion: `请核对“${issue.fieldName}”。`,
    evidence: [],
    fieldId: issue.fieldId,
    fieldName: issue.fieldName,
    blocking: issue.severity === 'error',
    confidence: 1,
    source: 'rule',
    status: 'open',
  })), { agentVersion: 'none' })
}
