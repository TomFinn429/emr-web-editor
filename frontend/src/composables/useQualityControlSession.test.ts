import { describe, expect, it } from 'vitest'
import type { QualityControlReport } from '../types/qualityControl'
import { useQualityControlSession } from './useQualityControlSession'

describe('useQualityControlSession', () => {
  it('runs QC and stores the latest report', async () => {
    const session = useQualityControlSession()

    await session.run('doc-1', async () => createReport('doc-1'))

    expect(session.report.value?.documentId).toBe('doc-1')
    expect(session.isRunning.value).toBe(false)
    expect(session.error.value).toBeNull()
  })

  it('discards stale results for older documents', async () => {
    const session = useQualityControlSession()
    let resolveOld!: (report: QualityControlReport) => void
    const oldRun = session.run('old', () => new Promise<QualityControlReport>((resolve) => {
      resolveOld = resolve
    }))
    const newRun = session.run('new', async () => createReport('new'))

    resolveOld(createReport('old'))
    await oldRun
    await newRun

    expect(session.report.value?.documentId).toBe('new')
  })

  it('marks issues ignored and resolved without mutating original report', async () => {
    const session = useQualityControlSession()
    const report = createReport('doc-1')
    await session.run('doc-1', async () => report)

    session.ignoreIssue('issue-1')
    expect(session.report.value?.issues[0].status).toBe('ignored')
    expect(report.issues[0].status).toBe('open')

    session.resolveIssue('issue-1')
    expect(session.report.value?.issues[0].status).toBe('resolved')
    expect(report.issues[0].status).toBe('open')
  })

  it('stores errors and clears state', async () => {
    const session = useQualityControlSession()

    await session.run('doc-1', async () => {
      throw new Error('质控失败')
    })

    expect(session.error.value).toBe('质控失败')
    session.clear()
    expect(session.report.value).toBeNull()
    expect(session.error.value).toBeNull()
    expect(session.isRunning.value).toBe(false)
  })

  it('sets reports directly for save-before validation failures', () => {
    const session = useQualityControlSession()

    session.setReport(createReport('doc-1'))

    expect(session.report.value?.documentId).toBe('doc-1')
    expect(session.error.value).toBeNull()
  })
})

function createReport(documentId: string): QualityControlReport {
  return {
    id: `report-${documentId}`,
    documentId,
    ruleVersion: 'rules',
    agentVersion: 'agent',
    generatedAt: '2026-06-05T08:00:00.000Z',
    summary: {
      criticalCount: 0,
      errorCount: 1,
      warningCount: 0,
      suggestionCount: 0,
      blockingCount: 1,
    },
    issues: [{
      id: 'issue-1',
      category: 'required',
      severity: 'error',
      title: '必填',
      message: '必填',
      suggestion: '请补充。',
      evidence: [],
      blocking: true,
      confidence: 1,
      source: 'rule',
      status: 'open',
    }],
  }
}
