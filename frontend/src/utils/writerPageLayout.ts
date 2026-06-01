export interface PreviewPageSize {
  width: number
  height: number
}

export const DEFAULT_PREVIEW_PAGE_SIZE: PreviewPageSize = {
  width: 795.333,
  height: 1123.333,
}

const A4_WIDTH_IN_CM = 21
const A4_HEIGHT_IN_CM = 29.7

export function getPreviewPageSizeFromXml(xml: string): PreviewPageSize {
  const pageSettings = readPageSettings(xml)
  const explicitPageSize = pageSettings ? readExplicitPageSize(pageSettings) : null
  const landscape = pageSettings ? readBooleanTag(pageSettings, 'Landscape') : null
  const pageSize = explicitPageSize ?? DEFAULT_PREVIEW_PAGE_SIZE

  return orientPageSize(pageSize, landscape)
}

export function getRenderedPageSize(root: Pick<ParentNode, 'querySelector'>): PreviewPageSize | null {
  const pageElement = root.querySelector('canvas[dctype="page"], svg[dctype="page"]')
  if (!pageElement) {
    return null
  }

  const width = readNumberAttribute(pageElement, 'native-width')
  const height = readNumberAttribute(pageElement, 'native-height')
  if (!width || !height) {
    return null
  }

  return { width, height }
}

function readPageSettings(xml: string) {
  return xml.match(/<PageSettings\b[^>]*>([\s\S]*?)<\/PageSettings>/i)?.[1] ?? ''
}

function readExplicitPageSize(pageSettings: string): PreviewPageSize | null {
  const width = readNumberTag(pageSettings, ['PaperWidth', 'PageWidth', 'Width'])
  const height = readNumberTag(pageSettings, ['PaperHeight', 'PageHeight', 'Height'])
  if (isUsablePageDimension(width) && isUsablePageDimension(height)) {
    return { width, height }
  }

  const widthInCm = readNumberTag(pageSettings, ['PaperWidthInCM', 'PageWidthInCM'])
  const heightInCm = readNumberTag(pageSettings, ['PaperHeightInCM', 'PageHeightInCM'])
  if (widthInCm > 0 && heightInCm > 0) {
    return {
      width: (widthInCm / A4_WIDTH_IN_CM) * DEFAULT_PREVIEW_PAGE_SIZE.width,
      height: (heightInCm / A4_HEIGHT_IN_CM) * DEFAULT_PREVIEW_PAGE_SIZE.height,
    }
  }

  return null
}

function orientPageSize(pageSize: PreviewPageSize, landscape: boolean | null): PreviewPageSize {
  if (landscape === true && pageSize.width < pageSize.height) {
    return { width: pageSize.height, height: pageSize.width }
  }

  if (landscape === false && pageSize.width > pageSize.height) {
    return { width: pageSize.height, height: pageSize.width }
  }

  return { width: pageSize.width, height: pageSize.height }
}

function readBooleanTag(source: string, tagName: string): boolean | null {
  const value = readTag(source, tagName)?.trim().toLowerCase()
  if (value === 'true' || value === '1') {
    return true
  }
  if (value === 'false' || value === '0') {
    return false
  }
  return null
}

function readNumberTag(source: string, tagNames: string[]) {
  for (const tagName of tagNames) {
    const value = Number(readTag(source, tagName)?.trim())
    if (Number.isFinite(value)) {
      return value
    }
  }
  return 0
}

function readTag(source: string, tagName: string) {
  return source.match(new RegExp(`<${tagName}\\b[^>]*>([\\s\\S]*?)<\\/${tagName}>`, 'i'))?.[1] ?? null
}

function readNumberAttribute(element: Element, attributeName: string) {
  const value = Number(element.getAttribute(attributeName))
  return Number.isFinite(value) && value > 0 ? value : 0
}

function isUsablePageDimension(value: number) {
  return value > 50
}
