import { describe, expect, it } from 'vitest'
import type { DocumentFacts } from '../types/qualityControl'
import { createMockQualityControlAgent, normalizeAgentIssues } from './qcAgentService'

describe('qcAgentService', () => {
  it('returns non-blocking semantic suggestions from mock Agent', async () => {
    const agent = createMockQualityControlAgent()
    const issues = await agent.analyze(createFacts({
      fields: [
        {
          id: 'chief-complaint',
          name: '主诉',
          value: '头痛三天',
          required: false,
          evidenceId: 'ev-chief',
        },
        {
          id: 'present-illness',
          name: '现病史',
          value: '患者否认头痛。',
          required: false,
          evidenceId: 'ev-illness',
        },
      ],
      snippets: [
        { id: 'ev-chief', label: '主诉', text: '头痛三天', fieldId: 'chief-complaint' },
        { id: 'ev-illness', label: '现病史', text: '患者否认头痛。', fieldId: 'present-illness' },
      ],
    }))

    expect(issues).toEqual([
      expect.objectContaining({
        category: 'semantic',
        severity: 'warning',
        blocking: false,
        source: 'agent',
      }),
    ])
  })

  it('normalizes unsafe Agent issues to non-blocking suggestions', () => {
    const normalized = normalizeAgentIssues(createFacts({ snippets: [] }), [
      {
        id: 'agent-danger',
        category: 'semantic',
        severity: 'critical',
        title: '危险输出',
        message: '请直接诊断。',
        suggestion: '立即调整医嘱。',
        evidence: [],
        blocking: true,
        confidence: 2,
        source: 'agent',
        status: 'open',
      },
    ])

    expect(normalized).toEqual([
      expect.objectContaining({
        severity: 'suggestion',
        blocking: false,
        confidence: 1,
        evidence: [],
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
