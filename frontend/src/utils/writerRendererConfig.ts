export function normalizeWriterServicePageUrl(value: unknown) {
  if (typeof value !== 'string') {
    return null
  }

  const servicePageUrl = value.trim()
  return servicePageUrl.length > 0 ? servicePageUrl : null
}

// Keep the legacy remote ServicePageUrl only as an opt-in comparison hook.
// By default we do not pass `servicepageurl`, so DCWriter follows the local
// runtime path under `/renderer/_framework/`. When 10.0.15.23:8084 is reachable
// and we need to compare remote Blazor/WASM loading, set this in `.env.local`:
// VITE_DCWRITER_SERVICE_PAGE_URL=http://10.0.15.23:8084/MyWriter/MoreHandleDCWriterServicePage
export function getWriterServicePageUrl() {
  return normalizeWriterServicePageUrl(import.meta.env.VITE_DCWRITER_SERVICE_PAGE_URL)
}

export function getWriterBootstrapAttributes(servicePageUrl: string | null): Record<string, string> {
  if (!servicePageUrl) {
    return {}
  }

  return {
    servicepageurl: servicePageUrl,
  }
}
