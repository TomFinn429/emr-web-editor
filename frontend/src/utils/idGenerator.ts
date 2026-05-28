export function createClientId(prefix?: string) {
  const id = globalThis.crypto?.randomUUID?.() ?? createFallbackId()

  return prefix ? `${prefix}-${id}` : id
}

function createFallbackId() {
  return `${Date.now().toString(36)}-${Math.random().toString(36).slice(2, 10)}`
}
