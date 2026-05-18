type PreloadWindow = Pick<Window, 'requestIdleCallback' | 'setTimeout'> & {
  __medicalRecordRendererLoading?: Promise<void>
}

type PreloadExternalRenderer = () => Promise<void>

export function shouldPreloadExternalRenderer(isDev: boolean) {
  return !isDev
}

export function scheduleExternalRendererPreload(
  preloadExternalRenderer: PreloadExternalRenderer,
  isDev: boolean,
  targetWindow: PreloadWindow = window,
) {
  if (!shouldPreloadExternalRenderer(isDev)) {
    return
  }

  const requestIdle = targetWindow.requestIdleCallback
    || ((callback: IdleRequestCallback) => targetWindow.setTimeout(callback, 1))

  requestIdle(() => {
    preloadExternalRenderer().catch(() => {
      targetWindow.__medicalRecordRendererLoading = undefined
    })
  })
}
