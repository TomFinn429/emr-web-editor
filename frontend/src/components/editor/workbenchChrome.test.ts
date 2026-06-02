import { describe, expect, it } from 'vitest'
import { shellActions, workbenchModules } from './workbenchChrome'

describe('workbenchChrome', () => {
  it('hides redundant module navigation when template making is the only feature', () => {
    expect(workbenchModules).toEqual([])
  })

  it('exposes target-page shell action labels', () => {
    expect(shellActions.map(action => action.label)).toEqual([
      '显示模式',
      '全屏',
      '重载',
      '当前账号',
    ])
  })
})
