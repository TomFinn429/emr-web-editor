import { describe, expect, it } from 'vitest'
import canvasPreviewSource from './CanvasPreview.vue?raw'
import { getCanvasLayerStyle, getSurfaceStyle } from './canvasPreviewLayout'
import { DEFAULT_PREVIEW_PAGE_SIZE, getPreviewPageSizeFromXml, getRenderedPageSize } from '../../utils/writerPageLayout'

describe('canvas preview layout styles', () => {
  it('keeps the external renderer in the default portrait page box', () => {
    expect(getSurfaceStyle('external', 1, DEFAULT_PREVIEW_PAGE_SIZE)).toEqual({
      width: '795px',
      minWidth: '795px',
      minHeight: '1123px',
    })

    expect(getCanvasLayerStyle('external', 1.2, DEFAULT_PREVIEW_PAGE_SIZE)).toEqual({
      zoom: '1.2',
      width: '795px',
      minWidth: '795px',
      minHeight: '1123px',
    })
  })

  it('uses landscape page settings instead of forcing a portrait shell', () => {
    const pageSize = getPreviewPageSizeFromXml('<XTextDocument><PageSettings><Landscape>true</Landscape></PageSettings></XTextDocument>')

    expect(pageSize).toEqual({
      width: DEFAULT_PREVIEW_PAGE_SIZE.height,
      height: DEFAULT_PREVIEW_PAGE_SIZE.width,
    })
    expect(getSurfaceStyle('external', 1, pageSize)).toEqual({
      width: '1123px',
      minWidth: '1123px',
      minHeight: '795px',
    })
  })

  it('can read the rendered page size from DCWriter public DOM attributes', () => {
    const root = {
      querySelector: () => ({
        getAttribute: (name: string) => {
          if (name === 'native-width') return '1123.333'
          if (name === 'native-height') return '795.333'
          return null
        },
      }),
    } as unknown as ParentNode

    expect(getRenderedPageSize(root)).toEqual({
      width: 1123.333,
      height: 795.333,
    })
  })

  it('keeps the fallback canvas reserving a scaled A4 layout box', () => {
    expect(getSurfaceStyle('preview', 0.8, DEFAULT_PREVIEW_PAGE_SIZE)).toEqual({
      width: 'min(636px, 100%)',
      minHeight: '899px',
    })

    expect(getCanvasLayerStyle('preview', 0.8, DEFAULT_PREVIEW_PAGE_SIZE)).toEqual({
      transform: 'scale(0.8)',
      width: '795px',
      minWidth: '795px',
      minHeight: '1123px',
    })
  })

  it('allows DCWriter native side comments to render outside the page box', () => {
    const pageContainerStyle = extractStyleRule(
      '.preview-panel__host :deep(.external-renderer-host [dctype="page-container"])',
    )
    const printPreviewStyle = extractStyleRule(
      '.preview-panel__host :deep(.external-renderer-host [dctype="page-printpreview"])',
    )

    expect(pageContainerStyle).toContain('overflow: visible !important;')
    expect(pageContainerStyle).not.toContain('overflow-x: hidden !important;')
    expect(pageContainerStyle).not.toContain('overflow: auto !important;')

    expect(printPreviewStyle).toContain('overflow: visible !important;')
    expect(printPreviewStyle).not.toContain('overflow-x: hidden !important;')
    expect(printPreviewStyle).not.toContain('overflow: auto !important;')
  })
})

function extractStyleRule(selector: string) {
  const escapedSelector = selector.replace(/[.*+?^${}()|[\]\\]/g, '\\$&')
  const match = canvasPreviewSource.match(new RegExp(`${escapedSelector}\\s*\\{([^}]*)\\}`))
  return match?.[1] ?? ''
}
