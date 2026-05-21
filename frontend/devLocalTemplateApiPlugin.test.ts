import { mkdirSync, writeFileSync } from 'node:fs'
import os from 'node:os'
import path from 'node:path'
import { describe, expect, it } from 'vitest'
import { listTemplateAssets, readTemplateAsset } from './devLocalTemplateApiPlugin'

describe('devLocalTemplateApiPlugin', () => {
  it('lists XML templates directly from configured template directories', () => {
    const sourceRoot = makeTemplateRoot('template-source-')
    const runtimeRoot = makeTemplateRoot('template-runtime-')
    writeTemplate(sourceRoot, '西医病案首页.xml', '<XTextDocument />')
    writeTemplate(runtimeRoot, '入院告知书.xml', '<XTextDocument />')

    expect(listTemplateAssets([
      { root: sourceRoot, category: '本地模板' },
      { root: runtimeRoot, category: '本地模板' },
    ])).toEqual([
      {
        id: '入院告知书',
        name: '入院告知书',
        fileName: '入院告知书.xml',
        category: '本地模板',
      },
      {
        id: '西医病案首页',
        name: '西医病案首页',
        fileName: '西医病案首页.xml',
        category: '本地模板',
      },
    ])
  })

  it('serves template XML from configured template directories', () => {
    const sourceRoot = makeTemplateRoot('template-source-')
    writeTemplate(sourceRoot, '西医病案首页.xml', '<XTextDocument />')

    expect(readTemplateAsset('西医病案首页', [
      { root: sourceRoot, category: '本地模板' },
    ])).toEqual({
      id: '西医病案首页',
      name: '西医病案首页',
      fileName: '西医病案首页.xml',
      category: '本地模板',
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
  mkdirSync(directory, { recursive: true })
  return directory
}

function writeTemplate(root: string, fileName: string, xml: string) {
  writeFileSync(path.join(root, fileName), xml, 'utf8')
}
