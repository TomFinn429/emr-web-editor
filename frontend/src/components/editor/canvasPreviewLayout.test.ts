import { describe, expect, it } from 'vitest'
import { getCanvasLayerStyle, getSurfaceStyle } from './canvasPreviewLayout'

describe('canvas preview layout styles', () => {
  it('keeps the external renderer in a single-page column', () => {
    expect(getSurfaceStyle('external', 1)).toEqual({
      width: '795px',
      minWidth: '795px',
      minHeight: '1123px',
    })
    expect(getCanvasLayerStyle('external', 1.2)).toEqual({
      zoom: '1.2',
    })
  })

  it('keeps the fallback canvas reserving a scaled A4 layout box', () => {
    expect(getSurfaceStyle('preview', 0.8)).toEqual({
      width: 'min(636px, 100%)',
      minHeight: '899px',
    })
    expect(getCanvasLayerStyle('preview', 0.8)).toEqual({
      transform: 'scale(0.8)',
    })
  })
})
