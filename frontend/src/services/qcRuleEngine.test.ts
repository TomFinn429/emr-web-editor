import { describe, expect, it } from 'vitest'
import type { DocumentFacts, QualityControlSeverity } from '../types/qualityControl'
import { createQualityControlReport, runQualityControlRules } from './qcRuleEngine'

describe('qcRuleEngine', () => {
  it('returns a blocking required issue for empty required fields', () => {
    const issues = runQualityControlRules(createFacts({
      fields: [
        {
          id: 'chief-complaint',
          name: '主诉',
          value: '',
          required: true,
          evidenceId: 'ev-1',
        },
      ],
      snippets: [{ id: 'ev-1', label: '主诉', text: '主诉：空值', fieldId: 'chief-complaint' }],
    }))

    expect(issues).toEqual([
      expect.objectContaining({
        id: 'required-chief-complaint',
        category: 'required',
        severity: 'error',
        blocking: true,
        source: 'rule',
      }),
    ])
  })

  it('returns a blocking timeline issue when discharge date is before admission date', () => {
    const issues = runQualityControlRules(createFacts({
      timeline: [
        { id: 'admission-date', label: '入院日期', value: '2026-06-02' },
        { id: 'discharge-date', label: '出院日期', value: '2026-06-01' },
      ],
    }))

    expect(issues).toEqual([
      expect.objectContaining({
        id: 'timeline-discharge-before-admission',
        category: 'timeline',
        severity: 'error',
        blocking: true,
      }),
    ])
  })

  it('creates a report summary from issues', () => {
    const report = createQualityControlReport('doc-1', [
      issue('critical', true),
      issue('warning', false),
      issue('suggestion', false),
    ], { agentVersion: 'mock-agent-v1' })

    expect(report.summary).toEqual({
      criticalCount: 1,
      errorCount: 0,
      warningCount: 1,
      suggestionCount: 1,
      blockingCount: 1,
    })
    expect(report.agentVersion).toBe('mock-agent-v1')
  })

  it('returns parse error as critical issue', () => {
    const issues = runQualityControlRules(createFacts({ parseError: '文档 XML 无法解析。' }))

    expect(issues).toEqual([
      expect.objectContaining({
        id: 'invalid-xml',
        severity: 'critical',
        blocking: true,
      }),
    ])
  })
})

function createFacts(patch: Partial<DocumentFacts>): DocumentFacts {
  return {
    documentId: 'doc-1',
    fileName: 'record.xml',
    source: 'local',
    generatedAt: '2026-06-05T08:00:00.000Z',
    sections: [],
    fields: [],
    metadataBindings: [],
    validationRules: [],
    timeline: [],
    snippets: [],
    ...patch,
  }
}

function issue(severity: QualityControlSeverity, blocking: boolean) {
  return {
    id: `issue-${severity}`,
    category: 'semantic' as const,
    severity,
    title: severity,
    message: severity,
    suggestion: '请核对。',
    evidence: [],
    blocking,
    confidence: 0.9,
    source: 'rule' as const,
    status: 'open' as const,
  }
}
