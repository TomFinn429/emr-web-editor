import { describe, expect, it, vi } from 'vitest'
import { scheduleExternalRendererPreload, shouldPreloadExternalRenderer } from './rendererPreload'

describe('rendererPreload', () => {
  it('does not preload the external renderer during development startup', () => {
    expect(shouldPreloadExternalRenderer(true)).toBe(false)

    const preload = vi.fn(async () => {})
    const requestIdleCallback = vi.fn()
    const targetWindow = {
      requestIdleCallback,
      setTimeout: vi.fn(),
    }

    scheduleExternalRendererPreload(preload, true, targetWindow)

    expect(requestIdleCallback).not.toHaveBeenCalled()
    expect(preload).not.toHaveBeenCalled()
  })

  it('preloads the external renderer on production startup and clears failed loads', async () => {
    expect(shouldPreloadExternalRenderer(false)).toBe(true)

    const preloadError = new Error('load failed')
    const preload = vi.fn(async () => {
      throw preloadError
    })
    const requestIdleCallback = vi.fn((callback: IdleRequestCallback) => {
      callback({ didTimeout: false, timeRemaining: () => 10 })
      return 1
    })
    const targetWindow = {
      __medicalRecordRendererLoading: Promise.resolve(),
      requestIdleCallback,
      setTimeout: vi.fn(),
    }

    scheduleExternalRendererPreload(preload, false, targetWindow)
    await Promise.resolve()

    expect(requestIdleCallback).toHaveBeenCalledTimes(1)
    expect(preload).toHaveBeenCalledTimes(1)
    expect(targetWindow.__medicalRecordRendererLoading).toBeUndefined()
  })
})
