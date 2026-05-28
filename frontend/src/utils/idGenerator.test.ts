import { afterEach, describe, expect, it, vi } from 'vitest'
import { createClientId } from './idGenerator'

describe('createClientId', () => {
  afterEach(() => {
    vi.unstubAllGlobals()
  })

  it('uses crypto.randomUUID when the browser exposes it', () => {
    vi.stubGlobal('crypto', {
      randomUUID: () => 'native-uuid',
    })

    expect(createClientId()).toBe('native-uuid')
  })

  it('falls back when crypto.randomUUID is unavailable on HTTP LAN origins', () => {
    vi.stubGlobal('crypto', undefined)

    const id = createClientId('writer-host')

    expect(id).toMatch(/^writer-host-[a-z0-9]+-[a-z0-9]+$/)
  })
})
