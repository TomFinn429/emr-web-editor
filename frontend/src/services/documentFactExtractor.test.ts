import { afterEach, describe, expect, it, vi } from 'vitest'
import { extractDocumentFacts } from './documentFactExtractor'

describe('documentFactExtractor', () => {
  afterEach(() => {
    vi.useRealTimers()
  })

  it('extracts required input fields, ValidateStyle, and metadata binding', () => {
    vi.useFakeTimers()
    vi.setSystemTime(new Date('2026-06-05T08:00:00.000Z'))

    const facts = extractDocumentFacts({
      documentId: 'doc-1',
      fileName: 'admission.xml',
      source: 'template',
      templateId: 'tpl-1',
      xml: `
<XTextDocument xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <XElements>
    <Element xsi:type="XInputField">
      <ID>chief-complaint</ID>
      <Name>主诉</Name>
      <BindingPath>Medical.ChiefComplaint</BindingPath>
      <DataSource>EMR</DataSource>
      <ValidateStyle>{"Required":true,"MaxLength":80}</ValidateStyle>
      <InnerValue />
    </Element>
  </XElements>
</XTextDocument>
`,
    })

    expect(facts.documentId).toBe('doc-1')
    expect(facts.generatedAt).toBe('2026-06-05T08:00:00.000Z')
    expect(facts.fields).toEqual([
      expect.objectContaining({
        id: 'chief-complaint',
        name: '主诉',
        value: '',
        required: true,
        bindingPath: 'Medical.ChiefComplaint',
        dataSourceName: 'EMR',
      }),
    ])
    expect(facts.validationRules).toEqual([
      expect.objectContaining({
        fieldId: 'chief-complaint',
        required: true,
      }),
    ])
    expect(facts.metadataBindings).toEqual([
      {
        fieldId: 'chief-complaint',
        bindingPath: 'Medical.ChiefComplaint',
        dataSourceName: 'EMR',
      },
    ])
  })

  it('extracts timeline facts from known date bindings', () => {
    const facts = extractDocumentFacts({
      documentId: 'doc-1',
      fileName: 'record.xml',
      source: 'local',
      xml: `
<XTextDocument xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <XElements>
    <Element xsi:type="XInputField">
      <ID>admission-date</ID>
      <Name>入院日期</Name>
      <BindingPath>Visit.AdmissionDate</BindingPath>
      <InnerValue>2026-06-02</InnerValue>
    </Element>
    <Element xsi:type="XInputField">
      <ID>discharge-date</ID>
      <Name>出院日期</Name>
      <BindingPath>Visit.DischargeDate</BindingPath>
      <InnerValue>2026-06-01</InnerValue>
    </Element>
  </XElements>
</XTextDocument>
`,
    })

    expect(facts.timeline).toEqual([
      expect.objectContaining({ id: 'admission-date', label: '入院日期', value: '2026-06-02' }),
      expect.objectContaining({ id: 'discharge-date', label: '出院日期', value: '2026-06-01' }),
    ])
  })

  it('returns parseError facts instead of throwing for invalid XML', () => {
    const facts = extractDocumentFacts({
      documentId: 'doc-1',
      fileName: 'broken.xml',
      source: 'local',
      xml: '<XTextDocument>',
    })

    expect(facts.parseError).toBe('文档 XML 无法解析。')
    expect(facts.fields).toEqual([])
  })
})
