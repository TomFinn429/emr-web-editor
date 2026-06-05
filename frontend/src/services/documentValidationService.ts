import type { ValidationIssue } from '../types/document'
import type { QualityControlIssue } from '../types/qualityControl'
import { extractDocumentFacts } from './documentFactExtractor'
import { runQualityControlRules } from './qcRuleEngine'

export function validateDocumentXml(xml: string): ValidationIssue[] {
  const facts = extractDocumentFacts({
    documentId: 'document',
    fileName: 'document.xml',
    source: 'unknown',
    xml,
  })

  return runQualityControlRules(facts)
    .filter(issue => issue.blocking)
    .map(toValidationIssue)
}

function toValidationIssue(issue: QualityControlIssue): ValidationIssue {
  return {
    id: issue.id,
    fieldId: issue.fieldId || 'document',
    fieldName: issue.id === 'invalid-xml' ? 'XML' : issue.fieldName || issue.title,
    message: issue.message,
    severity: issue.severity === 'critical' || issue.severity === 'error' ? 'error' : 'warning',
  }
}
