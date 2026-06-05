import { readonly, shallowRef } from 'vue'
import type { QualityControlReport } from '../types/qualityControl'

export function useQualityControlSession() {
  const report = shallowRef<QualityControlReport | null>(null)
  const isRunning = shallowRef(false)
  const error = shallowRef<string | null>(null)
  const activeRunId = shallowRef(0)
  const activeDocumentId = shallowRef<string | null>(null)

  async function run(
    documentId: string,
    createReport: () => Promise<QualityControlReport>,
  ) {
    const runId = activeRunId.value + 1
    activeRunId.value = runId
    activeDocumentId.value = documentId
    isRunning.value = true
    error.value = null

    try {
      const nextReport = await createReport()
      if (runId !== activeRunId.value || documentId !== activeDocumentId.value) {
        return
      }
      report.value = cloneReport(nextReport)
    } catch (runError) {
      if (runId !== activeRunId.value) return
      error.value = runError instanceof Error ? runError.message : '质控运行失败。'
    } finally {
      if (runId === activeRunId.value) {
        isRunning.value = false
      }
    }
  }

  function setReport(nextReport: QualityControlReport) {
    activeRunId.value += 1
    activeDocumentId.value = nextReport.documentId
    report.value = cloneReport(nextReport)
    isRunning.value = false
    error.value = null
  }

  function ignoreIssue(issueId: string) {
    setIssueStatus(issueId, 'ignored')
  }

  function resolveIssue(issueId: string) {
    setIssueStatus(issueId, 'resolved')
  }

  function clear() {
    activeRunId.value += 1
    activeDocumentId.value = null
    report.value = null
    isRunning.value = false
    error.value = null
  }

  return {
    report: readonly(report),
    isRunning: readonly(isRunning),
    error: readonly(error),
    run,
    setReport,
    ignoreIssue,
    resolveIssue,
    clear,
  }

  function setIssueStatus(issueId: string, status: 'ignored' | 'resolved') {
    if (!report.value) return
    report.value = {
      ...report.value,
      summary: { ...report.value.summary },
      issues: report.value.issues.map(issue =>
        issue.id === issueId ? { ...issue, status } : { ...issue },
      ),
    }
  }
}

function cloneReport(report: QualityControlReport): QualityControlReport {
  return {
    ...report,
    summary: { ...report.summary },
    issues: report.issues.map(issue => ({
      ...issue,
      evidence: issue.evidence.map(snippet => ({ ...snippet })),
    })),
  }
}
