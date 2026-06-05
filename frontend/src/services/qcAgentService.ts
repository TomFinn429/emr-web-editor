import type {
  DocumentFacts,
  QualityControlAgentProvider,
  QualityControlIssue,
} from '../types/qualityControl'

export const mockAgentVersion = 'mock-qc-agent-v1'

export function createMockQualityControlAgent(): QualityControlAgentProvider {
  return {
    async analyze(facts: DocumentFacts) {
      const issues: QualityControlIssue[] = []
      const chiefComplaint = findField(facts, '主诉')
      const presentIllness = findField(facts, '现病史')

      if (
        chiefComplaint?.value.includes('头痛')
        && presentIllness?.value.includes('否认头痛')
      ) {
        issues.push({
          id: 'agent-chief-complaint-present-illness-conflict',
          category: 'semantic',
          severity: 'warning',
          title: '主诉与现病史疑似不一致',
          message: '主诉提到头痛，但现病史描述中出现否认头痛，请核对二者是否一致。',
          suggestion: '请核对主诉与现病史描述，必要时补充症状出现时间、持续时间和否认项范围。',
          evidence: facts.snippets.filter(snippet =>
            snippet.fieldId === chiefComplaint.id || snippet.fieldId === presentIllness.id,
          ),
          fieldId: presentIllness.id,
          fieldName: presentIllness.name,
          blocking: false,
          confidence: 0.76,
          source: 'agent',
          status: 'open',
        })
      }

      return normalizeAgentIssues(facts, issues)
    },
  }
}

export function normalizeAgentIssues(
  facts: DocumentFacts,
  issues: readonly QualityControlIssue[],
): QualityControlIssue[] {
  return issues.map((issue) => {
    const evidence = issue.evidence.filter(snippet =>
      facts.snippets.some(candidate => candidate.id === snippet.id),
    )

    return {
      ...issue,
      id: issue.id || `agent-${slugIssueTitle(issue.title)}`,
      severity: issue.severity === 'critical' || issue.severity === 'error'
        ? 'suggestion'
        : issue.severity,
      suggestion: safeSuggestion(issue.suggestion),
      evidence,
      blocking: false,
      confidence: Math.max(0, Math.min(1, issue.confidence)),
      source: 'agent',
      status: issue.status === 'ignored' || issue.status === 'resolved' ? issue.status : 'open',
    }
  })
}

function findField(facts: DocumentFacts, name: string) {
  return facts.fields.find(field => field.name === name)
}

function safeSuggestion(value: string) {
  if (!value.trim()) return '请核对相关文书内容。'
  if (value.includes('立即调整医嘱')) return '请核对相关文书内容，必要时补充证据说明。'
  return value
}

function slugIssueTitle(value: string) {
  return value
    .toLowerCase()
    .replace(/[^a-z0-9\u4e00-\u9fa5]+/g, '-')
    .replace(/^-|-$/g, '')
    || 'issue'
}
