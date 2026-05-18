import { existsSync, readdirSync, readFileSync, statSync } from 'node:fs'
import type { ServerResponse } from 'node:http'
import path from 'node:path'
import type { Plugin } from 'vite'

export interface DevLocalTemplateRoot {
  root: string
  category: string
}

export interface TemplateSummaryAsset {
  id: string
  name: string
  fileName: string
  category: string
}

export interface TemplateContentAsset extends TemplateSummaryAsset {
  xml: string
}

export function devLocalTemplateApiPlugin(roots: DevLocalTemplateRoot[]): Plugin {
  const normalizedRoots = normalizeRoots(roots)

  return {
    name: 'dev-local-template-api',
    configureServer(server) {
      server.middlewares.use((request, response, next) => {
        if (request.method !== 'GET') {
          next()
          return
        }

        const pathname = new URL(request.url ?? '', 'http://localhost').pathname
        if (pathname === '/api/templates') {
          writeJson(response, 200, listTemplateAssets(normalizedRoots))
          return
        }

        const templateId = readTemplateId(pathname)
        if (!templateId) {
          next()
          return
        }

        const template = readTemplateAsset(templateId, normalizedRoots)
        if (!template) {
          writeJson(response, 404, { errorCode: 'TEMPLATE_NOT_FOUND', message: '未找到指定模板。' })
          return
        }

        writeJson(response, 200, template)
      })
    },
  }
}

export function listTemplateAssets(roots: DevLocalTemplateRoot[]): TemplateSummaryAsset[] {
  const templates = new Map<string, TemplateSummaryAsset>()

  for (const templateFile of enumerateTemplateFiles(normalizeRoots(roots))) {
    const summary = toTemplateSummary(templateFile)
    if (!templates.has(summary.id.toLowerCase())) {
      templates.set(summary.id.toLowerCase(), summary)
    }
  }

  return Array.from(templates.values())
    .sort((left, right) => left.name.localeCompare(right.name, undefined, { sensitivity: 'base' }))
}

export function readTemplateAsset(id: string, roots: DevLocalTemplateRoot[]): TemplateContentAsset | null {
  const targetId = id.toLowerCase()

  for (const templateFile of enumerateTemplateFiles(normalizeRoots(roots))) {
    const summary = toTemplateSummary(templateFile)
    if (summary.id.toLowerCase() !== targetId) {
      continue
    }

    return {
      ...summary,
      xml: readFileSync(templateFile.path, 'utf8'),
    }
  }

  return null
}

function readTemplateId(pathname: string) {
  const prefix = '/api/templates/'
  if (!pathname.startsWith(prefix)) {
    return null
  }

  const encodedId = pathname.slice(prefix.length)
  if (!encodedId || encodedId.includes('/')) {
    return null
  }

  return decodeURIComponent(encodedId)
}

function writeJson(response: ServerResponse, statusCode: number, payload: unknown) {
  response.statusCode = statusCode
  response.setHeader('Content-Type', 'application/json; charset=utf-8')
  response.end(JSON.stringify(payload))
}

function normalizeRoots(roots: DevLocalTemplateRoot[]) {
  return roots.map((entry) => ({
    root: path.resolve(entry.root),
    category: entry.category,
  }))
}

function enumerateTemplateFiles(roots: DevLocalTemplateRoot[]) {
  const result: Array<DevLocalTemplateRoot & { path: string }> = []

  for (const entry of roots) {
    const templateDirectory = path.join(entry.root, 'demoDocuments')
    if (!existsSync(templateDirectory) || !statSync(templateDirectory).isDirectory()) {
      continue
    }

    for (const fileName of readdirSync(templateDirectory)) {
      const filePath = path.join(templateDirectory, fileName)
      if (path.extname(filePath).toLowerCase() === '.xml' && statSync(filePath).isFile()) {
        result.push({ ...entry, path: filePath })
      }
    }
  }

  return result
}

function toTemplateSummary(templateFile: DevLocalTemplateRoot & { path: string }): TemplateSummaryAsset {
  const fileName = path.basename(templateFile.path)
  const name = path.basename(templateFile.path, path.extname(templateFile.path)).trim()

  return {
    id: toTemplateId(name),
    name,
    fileName,
    category: templateFile.category,
  }
}

function toTemplateId(name: string) {
  return name
    .replace(/（/g, '-')
    .replace(/）/g, '')
    .replace(/\(/g, '-')
    .replace(/\)/g, '')
    .split(/\s+/)
    .filter(Boolean)
    .join('-')
    .replace(/^-+|-+$/g, '')
}
