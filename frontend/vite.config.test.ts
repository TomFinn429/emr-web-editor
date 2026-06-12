import { describe, expect, it } from 'vitest'
import viteConfig from './vite.config'

describe('vite config', () => {
  it('opens the app at the root path by default', () => {
    expect(viteConfig.server?.open).toBe('/')
  })
})
