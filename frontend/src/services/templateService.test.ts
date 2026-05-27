import { afterEach, describe, expect, it, vi } from 'vitest'
import { fetchTemplateContent, fetchTemplates } from './templateService'

describe('templateService', () => {
  afterEach(() => {
    vi.unstubAllGlobals()
  })

  it('fetches template summaries', async () => {
    vi.stubGlobal(
      'fetch',
      vi.fn(async () => ({
        ok: true,
        json: async () => [
          {
            id: 'admission',
            name: 'Admission Record',
            fileName: 'Admission Record.xml',
            category: 'ClinicalDoc',
          },
        ],
      })),
    )

    await expect(fetchTemplates()).resolves.toEqual([
      {
        id: 'admission',
        name: 'Admission Record',
        fileName: 'Admission Record.xml',
        category: 'ClinicalDoc',
      },
    ])
  })

  it('fetches template content', async () => {
    vi.stubGlobal(
      'fetch',
      vi.fn(async () => ({
        ok: true,
        json: async () => ({
          id: 'admission',
          name: 'Admission Record',
          fileName: 'Admission Record.xml',
          category: 'ClinicalDoc',
          xml: '<XTextDocument />',
        }),
      })),
    )

    await expect(fetchTemplateContent('admission')).resolves.toEqual({
      id: 'admission',
      name: 'Admission Record',
      fileName: 'Admission Record.xml',
      category: 'ClinicalDoc',
      xml: '<XTextDocument />',
    })
  })

  it('throws readable errors for failed responses', async () => {
    vi.stubGlobal(
      'fetch',
      vi.fn(async () => ({
        ok: false,
        status: 404,
        json: async () => ({ message: '未找到指定模板。' }),
      })),
    )

    await expect(fetchTemplateContent('missing')).rejects.toThrow('未找到指定模板。')
  })

  it('encodes template ids in content requests', async () => {
    const fetchMock = vi.fn(async () => ({
      ok: true,
      json: async () => ({
        id: 'a b',
        name: 'Template With Space',
        fileName: 'Template With Space.xml',
        category: 'ClinicalDoc',
        xml: '<XTextDocument />',
      }),
    }))
    vi.stubGlobal('fetch', fetchMock)

    await fetchTemplateContent('a b')

    expect(fetchMock).toHaveBeenCalledWith('/api/templates/a%20b')
  })

  it('throws fallback messages when failed responses are not JSON', async () => {
    vi.stubGlobal(
      'fetch',
      vi.fn(async () => ({
        ok: false,
        status: 500,
        json: async () => {
          throw new Error('Invalid JSON')
        },
      })),
    )

    await expect(fetchTemplates()).rejects.toThrow('模板列表加载失败。')
  })
})
