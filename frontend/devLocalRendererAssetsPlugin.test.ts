import { mkdirSync, writeFileSync } from 'node:fs'
import os from 'node:os'
import path from 'node:path'
import { describe, expect, it } from 'vitest'
import { resolveRendererAsset } from './devLocalRendererAssetsPlugin'

describe('devLocalRendererAssetsPlugin', () => {
  it('resolves local renderer assets from the first root that contains the file', () => {
    const emptyRoot = makeTempDirectory('renderer-empty-')
    const assetRoot = makeTempDirectory('renderer-assets-')
    const assetPath = path.join(assetRoot, '_framework', 'dcwriter5.js')
    mkdirSync(path.dirname(assetPath), { recursive: true })
    writeFileSync(assetPath, '//! renderer bootstrap', 'utf8')

    expect(resolveRendererAsset(
      { url: '/renderer/_framework/dcwriter5.js?v=1' },
      { roots: [emptyRoot, assetRoot] },
    )).toBe(assetPath)
  })

  it('does not resolve paths outside the configured renderer roots', () => {
    const assetRoot = makeTempDirectory('renderer-assets-')
    const outsideRoot = makeTempDirectory('renderer-outside-')
    const outsideFile = path.join(outsideRoot, 'secret.js')
    writeFileSync(outsideFile, 'secret', 'utf8')

    expect(resolveRendererAsset(
      { url: `/renderer/../${path.basename(outsideRoot)}/secret.js` },
      { roots: [assetRoot] },
    )).toBeNull()
  })

  it('ignores non-renderer requests', () => {
    const assetRoot = makeTempDirectory('renderer-assets-')

    expect(resolveRendererAsset(
      { url: '/api/templates' },
      { roots: [assetRoot] },
    )).toBeNull()
  })

  it('can serve a development-only renderer path for local Vite verification', () => {
    const assetRoot = makeTempDirectory('renderer-assets-')
    const assetPath = path.join(assetRoot, '_framework', 'dcwriter5.js')
    mkdirSync(path.dirname(assetPath), { recursive: true })
    writeFileSync(assetPath, '//! renderer bootstrap', 'utf8')

    expect(resolveRendererAsset(
      { url: '/renderer-dev/_framework/dcwriter5.js' },
      { requestPath: ['/renderer', '/renderer-dev'], roots: [assetRoot] },
    )).toBe(assetPath)
  })
})

function makeTempDirectory(prefix: string) {
  const directory = path.join(os.tmpdir(), `${prefix}${crypto.randomUUID()}`)
  mkdirSync(directory, { recursive: true })
  return directory
}
