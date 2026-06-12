import { describe, expect, it, vi } from 'vitest'
import type { ValidationIssue } from '../types/document'
import {
  createManualCommentOptions,
  createValidationIssueCommentOptions,
  insertManualCommentAndSave,
} from './writerCommentService'

describe('writerCommentService', () => {
  it('creates native WriterControl comment options for validation issues', () => {
    const issue: ValidationIssue = {
      id: 'required-patient-name',
      fieldId: 'patient-name',
      fieldName: 'Patient Name',
      message: '数据不能为空。',
      severity: 'error',
    }

    expect(createValidationIssueCommentOptions(issue)).toEqual({
      Text: '数据校验错误\nPatient Name：数据不能为空。',
      author: 'DCWriter',
      AuthorID: 'validation',
      Attributes: {
        source: 'validation',
        issueId: 'required-patient-name',
        fieldId: 'patient-name',
        fieldName: 'Patient Name',
        severity: 'error',
      },
      BackColor: '#8B8DF4',
      BorderColor: '#3434A8',
      ForeColor: '#000000',
    })
  })

  it('creates native WriterControl comment options for manual comments', () => {
    expect(createManualCommentOptions('请复核这一段诊断描述。')).toEqual({
      Text: '请复核这一段诊断描述。',
      author: 'DCWriter',
      AuthorID: 'manual',
      Attributes: {
        source: 'manual',
      },
      BackColor: '#FFE8E8',
      BorderColor: '#DC4C4C',
      ForeColor: '#000000',
    })
  })

  it('inserts a manual native comment and saves XML with native Comments', () => {
    const insertComment = vi.fn(() => ({ ok: true as const }))
    const saveXml = vi.fn(() => ({ ok: true as const, xml: '<document><Comments /></document>' }))

    expect(insertManualCommentAndSave({ insertComment, saveXml }, '请复核这一段诊断描述。')).toEqual({
      ok: true,
      xml: '<document><Comments /></document>',
    })
    expect(insertComment).toHaveBeenCalledWith(createManualCommentOptions('请复核这一段诊断描述。'))
    expect(saveXml).toHaveBeenCalled()
  })

  it('skips XML save when manual native comment insertion fails', () => {
    const insertComment = vi.fn(() => ({
      ok: false as const,
      reason: 'comment-api-unavailable' as const,
      message: '当前外部编辑器未暴露批注插入接口。',
    }))
    const saveXml = vi.fn()

    expect(insertManualCommentAndSave({ insertComment, saveXml }, '请复核这一段诊断描述。')).toEqual({
      ok: false,
      reason: 'comment-api-unavailable',
      message: '当前外部编辑器未暴露批注插入接口。',
    })
    expect(saveXml).not.toHaveBeenCalled()
  })
})
