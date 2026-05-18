import { createReadStream, existsSync, statSync } from 'node:fs'
import type { IncomingMessage } from 'node:http'
import path from 'node:path'
import type { Plugin } from 'vite'

export interface DevLocalRendererAssetsPluginOptions {
  requestPath?: string | string[]
  roots: string[]
}

const defaultRequestPaths = ['/renderer']

const contentTypes: Record<string, string> = {
  '.br': 'application/octet-stream',
  '.css': 'text/css; charset=utf-8',
  '.dat': 'application/octet-stream',
  '.dll': 'application/octet-stream',
  '.gz': 'application/gzip',
  '.html': 'text/html; charset=utf-8',
  '.ico': 'image/x-icon',
  '.js': 'text/javascript; charset=utf-8',
  '.json': 'application/json; charset=utf-8',
  '.wasm': 'application/wasm',
  '.webcil': 'application/octet-stream',
  '.xml': 'application/xml; charset=utf-8',
}

export function devLocalRendererAssetsPlugin(options: DevLocalRendererAssetsPluginOptions): Plugin {
  const requestPaths = normalizeRequestPaths(options.requestPath ?? defaultRequestPaths)
  const roots = options.roots.map((root) => path.resolve(root))

  return {
    name: 'dev-local-renderer-assets',
    configureServer(server) {
      server.middlewares.use((request, response, next) => {
        const resolved = resolveRendererAsset(request, { requestPath: requestPaths, roots })
        if (!resolved) {
          next()
          return
        }

        response.statusCode = 200
        response.setHeader('Content-Type', getContentType(resolved))
        createReadStream(resolved)
          .on('error', () => {
            if (!response.headersSent) {
              response.statusCode = 500
            }
            response.end()
          })
          .pipe(response)
      })
    },
  }
}

export function resolveRendererAsset(
  request: Pick<IncomingMessage, 'url'>,
  options: DevLocalRendererAssetsPluginOptions,
) {
  const requestPaths = normalizeRequestPaths(options.requestPath ?? defaultRequestPaths)
  const assetPath = readAssetPath(request.url ?? '', requestPaths)
  if (!assetPath) {
    return null
  }

  const roots = options.roots.map((root) => path.resolve(root))
  for (const root of roots) {
    const candidate = path.resolve(root, assetPath)
    if (!isPathInside(candidate, root) || !existsSync(candidate)) {
      continue
    }

    if (statSync(candidate).isFile()) {
      return candidate
    }
  }

  return null
}

function readAssetPath(url: string, requestPaths: string[]) {
  const pathname = new URL(url, 'http://localhost').pathname
  const requestPath = requestPaths.find((candidate) => (
    pathname === candidate || pathname.startsWith(`${candidate}/`)
  ))
  if (!requestPath) {
    return null
  }

  const relative = decodeURIComponent(pathname.slice(requestPath.length)).replace(/^\/+/, '')
  if (!relative || relative.includes('\0')) {
    return null
  }

  return relative
}

function normalizeRequestPath(value: string) {
  return `/${value.replace(/^\/+|\/+$/g, '')}`
}

function normalizeRequestPaths(value: string | string[]) {
  return (Array.isArray(value) ? value : [value]).map(normalizeRequestPath)
}

function isPathInside(candidate: string, root: string) {
  const relative = path.relative(root, candidate)
  return relative === '' || (!relative.startsWith('..') && !path.isAbsolute(relative))
}

function getContentType(filePath: string) {
  return contentTypes[path.extname(filePath).toLowerCase()] ?? 'application/octet-stream'
}
