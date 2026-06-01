import { describe, expect, it } from 'vitest'
import {
  getWriterBootstrapAttributes,
  normalizeWriterServicePageUrl,
} from './writerRendererConfig'

describe('writerRendererConfig', () => {
  it('does not force a remote ServicePageUrl by default', () => {
    expect(normalizeWriterServicePageUrl(undefined)).toBeNull()
    expect(normalizeWriterServicePageUrl('')).toBeNull()
    expect(getWriterBootstrapAttributes(null)).toEqual({})
  })

  it('uses an explicit ServicePageUrl when one is configured', () => {
    const servicePageUrl = ' http://127.0.0.1:5190/MyWriter/MoreHandleDCWriterServicePage '

    expect(normalizeWriterServicePageUrl(servicePageUrl)).toBe(
      'http://127.0.0.1:5190/MyWriter/MoreHandleDCWriterServicePage',
    )
    expect(getWriterBootstrapAttributes(normalizeWriterServicePageUrl(servicePageUrl))).toEqual({
      servicepageurl: 'http://127.0.0.1:5190/MyWriter/MoreHandleDCWriterServicePage',
    })
  })
})
