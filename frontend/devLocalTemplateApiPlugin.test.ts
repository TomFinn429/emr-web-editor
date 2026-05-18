import { mkdirSync, writeFileSync } from 'node:fs'
import os from 'node:os'
import path from 'node:path'
import { describe, expect, it } from 'vitest'
import { listTemplateAssets, readTemplateAsset } from './devLocalTemplateApiPlugin'

describe('devLocalTemplateApiPlugin', () => {
  it('lists local demo templates with backend-compatible ids and source categories', () => {
    const sourceRoot = makeTemplateRoot('template-source-')
    const runtimeRoot = makeTemplateRoot('template-runtime-')
    writeTemplate(sourceRoot, 'Admission Record.xml', '<XTextDocument />')
    writeTemplate(runtimeRoot, 'Fine Movement Function Measure（FMFM）.xml', '<XTextDocument />')

    expect(listTemplateAssets([
      { root: sourceRoot, category: 'source' },
      { root: runtimeRoot, category: 'runtime' },
    ])).toEqual([
      {
        id: 'Admission-Record',
        name: 'Admission Record',
        fileName: 'Admission Record.xml',
        category: 'source',
      },
      {
        id: 'Fine-Movement-Function-Measure-FMFM',
        name: 'Fine Movement Function Measure（FMFM）',
        fileName: 'Fine Movement Function Measure（FMFM）.xml',
        category: 'runtime',
      },
    ])
  })

  it('serves template XML from local demo assets for Vite verification', () => {
    const sourceRoot = makeTemplateRoot('template-source-')
    writeTemplate(sourceRoot, 'Admission Record.xml', '<XTextDocument />')

    expect(readTemplateAsset('Admission-Record', [
      { root: sourceRoot, category: 'source' },
    ])).toEqual({
      id: 'Admission-Record',
      name: 'Admission Record',
      fileName: 'Admission Record.xml',
      category: 'source',
      xml: '<XTextDocument />',
    })
  })

  it('deduplicates templates by id and keeps the first configured root', () => {
    const sourceRoot = makeTemplateRoot('template-source-')
    const runtimeRoot = makeTemplateRoot('template-runtime-')
    writeTemplate(sourceRoot, 'Admission Record.xml', '<source />')
    writeTemplate(runtimeRoot, 'Admission Record.xml', '<runtime />')

    expect(listTemplateAssets([
      { root: sourceRoot, category: 'source' },
      { root: runtimeRoot, category: 'runtime' },
    ])).toHaveLength(1)
    expect(readTemplateAsset('Admission-Record', [
      { root: sourceRoot, category: 'source' },
      { root: runtimeRoot, category: 'runtime' },
    ])?.xml).toBe('<source />')
  })
})

function makeTemplateRoot(prefix: string) {
  const directory = path.join(os.tmpdir(), `${prefix}${crypto.randomUUID()}`)
  mkdirSync(path.join(directory, 'demoDocuments'), { recursive: true })
  return directory
}

function writeTemplate(root: string, fileName: string, xml: string) {
  writeFileSync(path.join(root, 'demoDocuments', fileName), xml, 'utf8')
}
