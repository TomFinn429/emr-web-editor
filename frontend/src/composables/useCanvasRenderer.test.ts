import { afterEach, describe, expect, it, vi } from 'vitest'
import {
  configureExternalWriterHost,
  prepareExternalWriterXmlForLoad,
} from './useCanvasRenderer'

describe('useCanvasRenderer external writer setup', () => {
  afterEach(() => {
    vi.unstubAllGlobals()
  })

  it('initializes template documents as editable content without enabling DCWriter design mode', () => {
    const host = createAttributeTarget()

    configureExternalWriterHost(host, 'template')

    expect(host.getAttribute('dctype')).toBe('WriterControlForWASM')
    expect(host.getAttribute('DocumentOptions.BehaviorOptions.Readonly')).toBe('false')
    expect(host.getAttribute('DocumentOptions.BehaviorOptions.DesignMode')).toBe('false')
    expect(host.getAttribute('Readonly')).toBe('false')
    expect(host.getAttribute('ReadViewMode')).toBe('false')
    expect(host.getAttribute('ExtViewMode')).toBeNull()
  })

  it('keeps non-template documents in readonly preview mode', () => {
    const host = createAttributeTarget()

    configureExternalWriterHost(host, 'local')

    expect(host.getAttribute('DocumentOptions.BehaviorOptions.Readonly')).toBe('true')
    expect(host.getAttribute('DocumentOptions.BehaviorOptions.DesignMode')).toBe('false')
  })

  it('unlocks table container ContentReadonly before loading template XML without changing field readonly flags', () => {
    installXmlDomStub()

    const xml = '<XTextDocument />'
    const preparedXml = prepareExternalWriterXmlForLoad(xml, 'template')

    expect(preparedXml).toContain('<Element xsi:type="XTextTable"><ContentReadonly>False</ContentReadonly></Element>')
    expect(preparedXml).toContain('<Element xsi:type="XInputField"><ContentReadonly>True</ContentReadonly></Element>')
  })

  it('does not rewrite XML for non-template documents', () => {
    installXmlDomStub()

    expect(prepareExternalWriterXmlForLoad('<XTextDocument />', 'local')).toBe('<XTextDocument />')
  })
})

function createAttributeTarget() {
  const attributes = new Map<string, string>()
  return {
    setAttribute(name: string, value: string) {
      attributes.set(name, value)
    },
    getAttribute(name: string) {
      return attributes.get(name) ?? null
    },
  } as HTMLElement
}

function installXmlDomStub() {
  vi.stubGlobal('DOMParser', class {
    parseFromString() {
      return createXmlDocumentStub([
        createXmlElementStub('XTextTable', 'True'),
        createXmlElementStub('XInputField', 'True'),
      ])
    }
  })
  vi.stubGlobal('XMLSerializer', class {
    serializeToString(document: ReturnType<typeof createXmlDocumentStub>) {
      return document.serialize()
    }
  })
}

function createXmlDocumentStub(elements: Array<ReturnType<typeof createXmlElementStub>>) {
  return {
    getElementsByTagName(name: string) {
      if (name === 'parsererror') return []
      if (name === 'Element') return elements
      return []
    },
    serialize() {
      return elements.map((element) => element.serialize()).join('')
    },
  }
}

function createXmlElementStub(type: string, readonly: string) {
  const contentReadonly = {
    tagName: 'ContentReadonly',
    localName: 'ContentReadonly',
    textContent: readonly,
  }
  return {
    tagName: 'Element',
    localName: 'Element',
    children: [contentReadonly],
    getAttribute(name: string) {
      return name === 'xsi:type' ? type : null
    },
    getAttributeNS(_namespace: string, name: string) {
      return name === 'type' ? type : null
    },
    serialize() {
      return `<Element xsi:type="${type}"><ContentReadonly>${contentReadonly.textContent}</ContentReadonly></Element>`
    },
  }
}
