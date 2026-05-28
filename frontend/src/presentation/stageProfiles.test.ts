import { describe, expect, it } from 'vitest'
import {
  getPresentationStage,
  resolvePresentationStage,
} from './stageProfiles'

describe('stageProfiles', () => {
  it('defaults to the full editor when no stage is requested', () => {
    expect(resolvePresentationStage({ search: '' }).id).toBe('full-editor')
  })

  it('uses the URL stage before the environment stage', () => {
    expect(resolvePresentationStage({
      search: '?stage=month-2-import-preview',
      envStage: 'full-editor',
    }).id).toBe('month-2-import-preview')
  })

  it('uses the environment stage when the URL does not specify one', () => {
    expect(resolvePresentationStage({
      search: '',
      envStage: 'month-2-import-preview',
    }).id).toBe('month-2-import-preview')
  })

  it('falls back to full editor for unknown stages', () => {
    expect(resolvePresentationStage({
      search: '?stage=missing',
      envStage: 'month-2-import-preview',
    }).id).toBe('full-editor')
  })

  it('keeps month 2 scoped to XML import and render preview', () => {
    const stage = getPresentationStage('month-2-import-preview')

    expect(stage.kind).toBe('xml-import')
    if (stage.kind !== 'xml-import') return

    expect(stage.allowedActions).toEqual(['import-xml', 'zoom'])
    expect(stage.acceptance).toEqual([
      '用户可以选择本地 XML 文件。',
      'XML 通过基础格式校验后进入渲染链路。',
      '渲染错乱作为已知问题展示，不阻断导入闭环汇报。',
    ])
  })

  it('keeps the full editor reachable through the explicit stage parameter', () => {
    expect(resolvePresentationStage({ search: '?stage=full-editor' }).id).toBe('full-editor')
  })
})
