import type {
  DocumentFacts,
  EvidenceSnippet,
  QualityControlIssue,
  QualityControlReport,
  QualityControlSeverity,
} from '../types/qualityControl'

export const qcRuleVersion = 'qc-rules-v1'

export function runQualityControlRules(facts: DocumentFacts): QualityControlIssue[] {
  const issues: QualityControlIssue[] = []

  if (facts.parseError) {
    issues.push({
      id: 'invalid-xml',
      category: 'format',
      severity: 'critical',
      title: 'XML 无法解析',
      message: facts.parseError,
      suggestion: '请检查文书 XML 是否完整，必要时重新从编辑器保存。',
      evidence: [],
      blocking: true,
      confidence: 1,
      source: 'rule',
      status: 'open',
    })
    return issues
  }

  for (const field of facts.fields) {
    if (field.required && !field.value.trim()) {
      issues.push({
        id: `required-${field.id}`,
        category: 'required',
        severity: 'error',
        title: `${field.name}不能为空`,
        message: `必填项“${field.name}”不能为空。`,
        suggestion: `请补充“${field.name}”后再保存。`,
        evidence: evidenceForField(facts, field.evidenceId),
        fieldId: field.id,
        fieldName: field.name,
        blocking: true,
        confidence: 1,
        source: 'rule',
        status: 'open',
      })
    }
  }

  const admissionDate = findTimelineDate(facts, '入院日期')
  const dischargeDate = findTimelineDate(facts, '出院日期')
  if (admissionDate && dischargeDate && dischargeDate.value < admissionDate.value) {
    issues.push({
      id: 'timeline-discharge-before-admission',
      category: 'timeline',
      severity: 'error',
      title: '出院日期早于入院日期',
      message: `出院日期“${dischargeDate.value}”早于入院日期“${admissionDate.value}”。`,
      suggestion: '请核对入院日期和出院日期。',
      evidence: [],
      fieldId: dischargeDate.fieldId,
      fieldName: dischargeDate.label,
      blocking: true,
      confidence: 1,
      source: 'rule',
      status: 'open',
    })
  }

  return issues
}

export function createQualityControlReport(
  documentId: string,
  issues: QualityControlIssue[],
  options: { agentVersion?: string } = {},
): QualityControlReport {
  return {
    id: `qc-${documentId}-${Date.now()}`,
    documentId,
    ruleVersion: qcRuleVersion,
    agentVersion: options.agentVersion || 'none',
    generatedAt: new Date().toISOString(),
    summary: summarizeIssues(issues),
    issues,
  }
}

export function summarizeIssues(issues: readonly QualityControlIssue[]) {
  return {
    criticalCount: countSeverity(issues, 'critical'),
    errorCount: countSeverity(issues, 'error'),
    warningCount: countSeverity(issues, 'warning'),
    suggestionCount: countSeverity(issues, 'suggestion'),
    blockingCount: issues.filter(issue => issue.blocking).length,
  }
}

function countSeverity(issues: readonly QualityControlIssue[], severity: QualityControlSeverity) {
  return issues.filter(issue => issue.severity === severity).length
}

function evidenceForField(facts: DocumentFacts, evidenceId: string): EvidenceSnippet[] {
  const evidence = facts.snippets.find(snippet => snippet.id === evidenceId)
  return evidence ? [evidence] : []
}

function findTimelineDate(facts: DocumentFacts, label: string) {
  const fact = facts.timeline.find(item => item.label === label)
  if (!fact) return null

  const value = Date.parse(fact.value)
  if (Number.isNaN(value)) return null

  return { ...fact, value: new Date(value).toISOString().slice(0, 10) }
}
