import { describe, expect, it } from 'vitest'
import type { WriterTraceInfo } from '../utils/writerControlAdapter'
import {
  createDefaultTraceUser,
  findTraceIdentityById,
  formatTraceInfo,
  formatTraceList,
  getTraceKey,
  traceIdentityOptions,
} from './writerTraceService'

describe('writerTraceService', () => {
  it('creates a default trace user from template author metadata', () => {
    expect(createDefaultTraceUser({
      templateName: '西医病案首页',
      authorName: '张三',
    })).toEqual({
      ID: 'emr-web-editor-demo',
      Name: '张三',
      ClientName: 'emr-web-editor',
      PermissionLevel: 2,
      Description: '西医病案首页实时留痕演示用户',
    })
  })

  it('falls back to a local demo trace user without metadata', () => {
    expect(createDefaultTraceUser({})).toEqual({
      ID: 'emr-web-editor-demo',
      Name: '演示医生',
      ClientName: 'emr-web-editor',
      PermissionLevel: 2,
      Description: '实时留痕演示用户',
    })
  })

  it('provides selectable trace identities for multi-user editing demonstrations', () => {
    expect(traceIdentityOptions.map(user => user.Name)).toEqual([
      '模板制作员',
      '张三主任医师',
      '李四审核医师',
    ])
    expect(findTraceIdentityById('review-doctor')).toMatchObject({
      ID: 'review-doctor',
      Name: '李四审核医师',
      PermissionLevel: 3,
    })
    expect(findTraceIdentityById('missing')).toBeNull()
  })

  it('formats native trace info for the panel', () => {
    expect(formatTraceInfo({
      NativeHandle: 8,
      InfoType: 'Create',
      Text: '已修改内容',
      UserName: '张三',
      SaveTime: '2026-06-16T08:00:00',
    }, 0)).toEqual({
      key: '8',
      nativeHandle: 8,
      actionKind: 'insert',
      actionSymbol: '+',
      actionTone: 'insert',
      typeLabel: '新增',
      summary: '已修改内容',
      fullText: '已修改内容',
      userName: '张三',
      userColor: '#2f7d5c',
      reviewTitle: '张三 新增',
      timeText: '2026-06-16 08:00:00',
      trace: {
        NativeHandle: 8,
        InfoType: 'Create',
        Text: '已修改内容',
        UserName: '张三',
        SaveTime: '2026-06-16T08:00:00',
      },
    })
  })

  it('uses review-facing labels that distinguish inserted text from deleted text', () => {
    expect(formatTraceInfo({
      InfoType: 'Create',
      Text: '新增术后观察',
      UserName: '张三主任医师',
    })).toMatchObject({
      actionKind: 'insert',
      actionSymbol: '+',
      actionTone: 'insert',
      typeLabel: '新增',
      reviewTitle: '张三主任医师 新增',
      summary: '新增术后观察',
    })
  })

  it('formats deletions with a destructive action tone and review title', () => {
    expect(formatTraceInfo({
      NativeHandle: 9,
      InfoType: 'Delete',
      Text: '错别字',
      UserName: '李四审核医师',
      SaveTime: '2026-06-16T09:30:00',
    })).toMatchObject({
      actionKind: 'delete',
      actionSymbol: '-',
      actionTone: 'delete',
      typeLabel: '删除',
      userColor: '#b25d00',
      reviewTitle: '李四审核医师 删除',
      summary: '错别字',
    })
  })

  it('maps supported trace types and keeps unknown types visible', () => {
    expect(formatTraceInfo({ InfoType: 'Checked' }).typeLabel).toBe('勾选')
    expect(formatTraceInfo({ InfoType: 'UnChecked' }).typeLabel).toBe('去掉勾选')
    expect(formatTraceInfo({ InfoType: 'Delete' }).typeLabel).toBe('删除')
    expect(formatTraceInfo({ InfoType: 'Replace' }).typeLabel).toBe('Replace')
    expect(formatTraceInfo({}).typeLabel).toBe('修改')
  })

  it('creates stable fallback keys and truncates long summaries', () => {
    const longText = '术后恢复良好。'.repeat(20)
    const trace: WriterTraceInfo = {
      InfoType: 'Delete',
      Text: longText,
      UserName: '李四',
      SaveTime: 'not-a-date',
    }

    expect(getTraceKey(trace, 2)).toBe('李四-not-a-date-2')
    expect(formatTraceInfo(trace, 2).summary.length).toBeLessThan(longText.length)
    expect(formatTraceInfo(trace, 2).summary.endsWith('...')).toBe(true)
    expect(formatTraceInfo(trace, 2).timeText).toBe('')
  })

  it('formats a trace list without mutating source traces', () => {
    const traces: WriterTraceInfo[] = [
      { NativeHandle: '13', InfoType: 'Delete', Text: '删除内容' },
    ]

    expect(formatTraceList(traces)[0]).toMatchObject({
      key: '13',
      nativeHandle: 13,
      typeLabel: '删除',
      summary: '删除内容',
    })
    expect(traces[0].NativeHandle).toBe('13')
  })
})
