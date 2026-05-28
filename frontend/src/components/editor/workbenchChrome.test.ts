import { describe, expect, it } from 'vitest'
import { shellActions, workbenchModules } from './workbenchChrome'

describe('workbenchChrome', () => {
  it('exposes target-page module navigation entries', () => {
    expect(workbenchModules.map(item => item.label)).toEqual([
      '仪表板',
      '模板制作',
      '数据元管理',
      '字典库管理',
      '片段模板库管理',
      '页眉页脚库管理',
      '模板管理',
      '元数据管理',
      '值域管理',
      '数据源管理',
      '模板类型管理',
    ])
    expect(workbenchModules.find(item => item.id === 'templateMake')).toMatchObject({
      label: '模板制作',
      active: true,
    })
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
