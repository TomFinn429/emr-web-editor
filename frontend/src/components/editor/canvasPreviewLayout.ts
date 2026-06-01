import type { CSSProperties } from 'vue'
import type { RendererMode } from '../../composables/useCanvasRenderer'
import { DEFAULT_PREVIEW_PAGE_SIZE, type PreviewPageSize } from '../../utils/writerPageLayout'

export function getSurfaceStyle(
  mode: RendererMode,
  zoom: number,
  pageSize: PreviewPageSize = DEFAULT_PREVIEW_PAGE_SIZE,
): CSSProperties {
  const minHeight = toPx(pageSize.height * zoom)
  if (mode === 'external') {
    const width = toPx(pageSize.width * zoom)
    return {
      width,
      minWidth: width,
      minHeight,
    }
  }

  return {
    width: `min(${Math.round(pageSize.width * zoom)}px, 100%)`,
    minHeight,
  }
}

export function getCanvasLayerStyle(
  mode: RendererMode,
  zoom: number,
  pageSize: PreviewPageSize = DEFAULT_PREVIEW_PAGE_SIZE,
): CSSProperties {
  const width = toPx(pageSize.width)
  const minHeight = toPx(pageSize.height)
  if (mode === 'external') {
    return {
      zoom: String(zoom),
      width,
      minWidth: width,
      minHeight,
    } as CSSProperties
  }

  return {
    transform: `scale(${zoom})`,
    width,
    minWidth: width,
    minHeight,
  }
}

function toPx(value: number) {
  return `${Math.round(value)}px`
}
