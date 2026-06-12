import type { ValidationIssue } from '../types/document'
import type {
  WriterAdapterResult,
  WriterCommentOptions,
  WriterSaveResult,
} from '../utils/writerControlAdapter'

interface ManualCommentSaveAdapter {
  insertComment: (options: WriterCommentOptions) => WriterAdapterResult
  saveXml: () => WriterSaveResult
}

const validationCommentColors = {
  BackColor: '#8B8DF4',
  BorderColor: '#3434A8',
  ForeColor: '#000000',
} satisfies Pick<WriterCommentOptions, 'BackColor' | 'BorderColor' | 'ForeColor'>

const manualCommentColors = {
  BackColor: '#FFE8E8',
  BorderColor: '#DC4C4C',
  ForeColor: '#000000',
} satisfies Pick<WriterCommentOptions, 'BackColor' | 'BorderColor' | 'ForeColor'>

export function createValidationIssueCommentOptions(issue: ValidationIssue): WriterCommentOptions {
  return {
    Text: `数据校验错误\n${issue.fieldName}：${issue.message}`,
    author: 'DCWriter',
    AuthorID: 'validation',
    Attributes: {
      source: 'validation',
      issueId: issue.id,
      fieldId: issue.fieldId,
      fieldName: issue.fieldName,
      severity: issue.severity,
    },
    ...validationCommentColors,
  }
}

export function createManualCommentOptions(text: string): WriterCommentOptions {
  return {
    Text: text,
    author: 'DCWriter',
    AuthorID: 'manual',
    Attributes: {
      source: 'manual',
    },
    ...manualCommentColors,
  }
}

export function insertManualCommentAndSave(
  adapter: ManualCommentSaveAdapter,
  text: string,
): WriterSaveResult {
  const insertResult = adapter.insertComment(createManualCommentOptions(text))
  if (!insertResult.ok) {
    return insertResult
  }

  return adapter.saveXml()
}
