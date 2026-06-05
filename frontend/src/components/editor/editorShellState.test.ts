import { describe, expect, it, vi } from 'vitest'
import editorShellSource from './EditorShell.vue?raw'
import workbenchEditorAreaSource from './WorkbenchEditorArea.vue?raw'
import type { EditorDocument } from '../../types/document'
import { canReplaceCurrentDocument, createReportFromValidationIssues, toPreviewDocument } from './editorShellState'

const editorDocument: EditorDocument = {
  id: 'doc-1',
  fileName: 'record.xml',
  xml: '<XTextDocument />',
  warnings: ['本地导入未上传服务器。'],
  source: 'local',
}

describe('editorShellState', () => {
  it('maps the active editor document to the preview document contract', () => {
    expect(toPreviewDocument(editorDocument)).toEqual({
      id: 'doc-1',
      fileName: 'record.xml',
      xml: '<XTextDocument />',
      warnings: ['本地导入未上传服务器。'],
      source: 'local',
      renderMode: 'canvas',
    })
  })

  it('passes template source metadata through to the renderer', () => {
    expect(toPreviewDocument({
      ...editorDocument,
      source: 'template',
      templateId: '西医病案首页',
    })).toMatchObject({
      source: 'template',
      templateId: '西医病案首页',
    })
  })

  it('keeps an empty preview document when no editor document is active', () => {
    expect(toPreviewDocument(null)).toBeNull()
  })

  it('allows replacing a clean document without prompting', () => {
    const confirmDiscard = vi.fn()

    expect(canReplaceCurrentDocument(false, confirmDiscard)).toBe(true)
    expect(confirmDiscard).not.toHaveBeenCalled()
  })

  it('asks before replacing a dirty document', () => {
    const confirmDiscard = vi.fn(() => false)

    expect(canReplaceCurrentDocument(true, confirmDiscard)).toBe(false)
    expect(confirmDiscard).toHaveBeenCalledTimes(1)
  })

  it('maps save-before validation failures into a quality control report', () => {
    const report = createReportFromValidationIssues('doc-1', [
      {
        id: 'required-chief-complaint',
        fieldId: 'chief-complaint',
        fieldName: '主诉',
        message: '必填项“主诉”不能为空。',
        severity: 'error',
      },
      {
        id: 'warning-present-illness',
        fieldId: 'present-illness',
        fieldName: '现病史',
        message: '请补充现病史。',
        severity: 'warning',
      },
    ])

    expect(report).toMatchObject({
      documentId: 'doc-1',
      agentVersion: 'none',
      summary: {
        errorCount: 1,
        warningCount: 1,
        blockingCount: 1,
      },
    })
    expect(report.issues).toEqual([
      expect.objectContaining({
        id: 'required-chief-complaint',
        category: 'required',
        severity: 'error',
        title: '主诉',
        fieldId: 'chief-complaint',
        fieldName: '主诉',
        blocking: true,
        source: 'rule',
        status: 'open',
      }),
      expect.objectContaining({
        id: 'warning-present-illness',
        severity: 'warning',
        blocking: false,
      }),
    ])
  })

  it('routes the workbench editor area through the quality control panel contract', () => {
    expect(workbenchEditorAreaSource).toContain("import QualityControlPanel from './QualityControlPanel.vue'")
    expect(workbenchEditorAreaSource).not.toContain("import ValidationPanel from './ValidationPanel.vue'")
    expect(workbenchEditorAreaSource).toContain('qualityControlReport: QualityControlReport | null')
    expect(workbenchEditorAreaSource).toContain('runQualityControl: []')
    expect(workbenchEditorAreaSource).toContain('<QualityControlPanel')
    expect(workbenchEditorAreaSource).toContain('@run-quality-control="emit(\'runQualityControl\')"')
    expect(workbenchEditorAreaSource).toContain('@select-issue="emit(\'selectQualityIssue\', $event)"')
  })

  it('composes the quality control session in the editor shell workflow', () => {
    expect(editorShellSource).toContain("import { useQualityControlSession } from '../../composables/useQualityControlSession'")
    expect(editorShellSource).toContain("import { extractDocumentFacts } from '../../services/documentFactExtractor'")
    expect(editorShellSource).toContain("import { createMockQualityControlAgent, mockAgentVersion } from '../../services/qcAgentService'")
    expect(editorShellSource).toContain("import { createQualityControlReport, runQualityControlRules } from '../../services/qcRuleEngine'")
    expect(editorShellSource).toContain('const qualityControl = useQualityControlSession()')
    expect(editorShellSource).toContain('async function runQualityControl()')
    expect(editorShellSource).toContain('qualityControl.setReport(createReportFromValidationIssues(document.id, result.issues))')
    expect(editorShellSource).toContain(':quality-control-report="qualityControl.report.value"')
    expect(editorShellSource).toContain('@run-quality-control="runQualityControl"')
    expect(editorShellSource).toContain('@select-quality-issue="handleQualityIssue"')
  })
})
