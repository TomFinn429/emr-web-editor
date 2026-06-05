import type {
  ClinicalFieldFact,
  ClinicalTimelineFact,
  DocumentFacts,
  EvidenceSnippet,
  FieldValidationRuleFact,
  MetadataBindingFact,
  QualityControlRunInput,
} from '../types/qualityControl'

interface ParsedField {
  tagName: string
  attributes: Record<string, string>
  children: Record<string, string>
}

const timelineBindingNames = new Map([
  ['Visit.AdmissionDate', '入院日期'],
  ['Visit.DischargeDate', '出院日期'],
  ['Operation.Date', '手术日期'],
])

export function extractDocumentFacts(input: QualityControlRunInput): DocumentFacts {
  const facts = createEmptyFacts(input)
  const parsed = parseInputFields(input.xml)

  if (!parsed.ok) {
    return {
      ...facts,
      parseError: '文档 XML 无法解析。',
    }
  }

  parsed.fields.forEach((field, index) => {
    const fieldId = readFieldId(field, index)
    const fieldName = readFieldName(field, fieldId)
    const value = readFieldValue(field)
    const validationRule = readValidationRule(field)
    const bindingPath =
      readFieldString(field, ['BindingPath', 'bindingPath'])
      || readValueBindingPart(field, 'BindingPath')
    const dataSourceName =
      readFieldString(field, ['DataSource', 'dataSource'])
      || readValueBindingPart(field, 'DataSource')
    const evidence: EvidenceSnippet = {
      id: `evidence-${fieldId}`,
      label: fieldName,
      text: value || `${fieldName}：空值`,
      fieldId,
    }

    facts.snippets.push(evidence)
    facts.fields.push({
      id: fieldId,
      name: fieldName,
      value,
      required: isRequiredField(field, validationRule),
      bindingPath: bindingPath || undefined,
      dataSourceName: dataSourceName || undefined,
      evidenceId: evidence.id,
    } satisfies ClinicalFieldFact)

    if (bindingPath) {
      facts.metadataBindings.push({
        fieldId,
        bindingPath,
        dataSourceName: dataSourceName || undefined,
      } satisfies MetadataBindingFact)
    }

    facts.validationRules.push({
      fieldId,
      required: BooleanValue(validationRule.Required) || isRequiredField(field, validationRule),
      minValue: nullableNumber(validationRule.MinValue),
      maxValue: nullableNumber(validationRule.MaxValue),
      dateTimeMinValue: stringValue(validationRule.DateTimeMinValue) || undefined,
      dateTimeMaxValue: stringValue(validationRule.DateTimeMaxValue) || undefined,
      raw: validationRule,
    } satisfies FieldValidationRuleFact)

    const timelineLabel = bindingPath ? timelineBindingNames.get(bindingPath) : undefined
    if (timelineLabel && value) {
      facts.timeline.push({
        id: fieldId,
        label: timelineLabel,
        value,
        fieldId,
      } satisfies ClinicalTimelineFact)
    }
  })

  facts.sections = parseSections(input.xml)
  return facts
}

function createEmptyFacts(input: QualityControlRunInput): DocumentFacts {
  return {
    documentId: input.documentId,
    fileName: input.fileName,
    source: input.source,
    templateId: input.templateId,
    generatedAt: new Date().toISOString(),
    sections: [],
    fields: [],
    metadataBindings: [],
    validationRules: [],
    timeline: [],
    snippets: [],
  }
}

function parseInputFields(xml: string): { ok: true; fields: ParsedField[] } | { ok: false } {
  if (!isXmlStructurallyBalanced(xml)) {
    return { ok: false }
  }

  const domFields = parseWithDomParser(xml)
  if (domFields) {
    return domFields
  }

  return { ok: true, fields: parseFieldsFromText(xml) }
}

function parseWithDomParser(xml: string): { ok: true; fields: ParsedField[] } | { ok: false } | null {
  if (typeof DOMParser === 'undefined') {
    return null
  }

  const document = new DOMParser().parseFromString(xml, 'application/xml')
  if (document.querySelector('parsererror')) {
    return { ok: false }
  }

  return {
    ok: true,
    fields: Array.from(
      document.querySelectorAll('XInputField, InputField, inputfield, Element'),
    )
      .filter(isDomInputField)
      .map(toParsedField),
  }
}

function toParsedField(element: Element): ParsedField {
  const attributes: Record<string, string> = {}
  for (const attribute of Array.from(element.attributes)) {
    attributes[attribute.name] = attribute.value
  }

  const children: Record<string, string> = {}
  for (const child of Array.from(element.children)) {
    children[child.tagName] = child.textContent?.trim() ?? ''
  }

  return {
    tagName: element.tagName,
    attributes,
    children,
  }
}

function isDomInputField(field: Element) {
  const tagName = field.tagName.toLowerCase()
  if (tagName === 'xinputfield' || tagName === 'inputfield') return true
  if (tagName !== 'element') return false
  return field.getAttribute('xsi:type') === 'XInputField' || field.getAttribute('type') === 'XInputField'
}

function parseFieldsFromText(xml: string) {
  return [
    ...parseNamedFieldsFromText(xml, 'XInputField'),
    ...parseNamedFieldsFromText(xml, 'InputField'),
    ...parseNamedFieldsFromText(xml, 'inputfield'),
    ...parseNamedFieldsFromText(xml, 'Element').filter(isTextInputField),
  ]
}

function parseNamedFieldsFromText(xml: string, tagName: string): ParsedField[] {
  return Array.from(xml.matchAll(new RegExp(`<${tagName}\\b([^>]*)>([\\s\\S]*?)</${tagName}>`, 'g')))
    .map(match => ({
      tagName,
      attributes: parseAttributes(match[1]),
      children: parseChildren(match[2]),
    }))
}

function isTextInputField(field: ParsedField) {
  return field.attributes['xsi:type'] === 'XInputField' || field.attributes.type === 'XInputField'
}

function readFieldId(field: ParsedField, index: number) {
  return readFieldString(field, ['ID', 'Id', 'id']) || `field-${index + 1}`
}

function readFieldName(field: ParsedField, fallback: string) {
  return readFieldString(field, ['Name', 'Title', 'name', 'BackgroundText']) || fallback
}

function readFieldValue(field: ParsedField) {
  return (
    readFieldString(field, ['InnerValue', 'innerValue', 'Value', 'value'])
    || field.attributes.Value
    || field.attributes.value
    || ''
  ).trim()
}

function readValidationRule(field: ParsedField) {
  const raw = readFieldString(field, ['ValidateStyle'])
  if (!raw) return {}

  if (raw.trim().startsWith('{')) {
    try {
      return JSON.parse(raw) as Record<string, unknown>
    } catch {
      return {}
    }
  }

  const children = parseChildren(raw)
  return Object.keys(children).length > 0 ? children : {}
}

function isRequiredField(field: ParsedField, validationRule: Record<string, unknown>) {
  const value =
    readFieldString(field, ['Required', 'required', 'NotNull', 'notNull', 'RequiredValue'])
    || stringValue(validationRule.Required)
  return BooleanValue(value)
}

function readValueBindingPart(field: ParsedField, key: string) {
  const raw = readFieldString(field, ['ValueBinding'])
  if (!raw || !raw.trim().startsWith('{')) return ''

  try {
    const value = JSON.parse(raw) as Record<string, unknown>
    return stringValue(value[key])
  } catch {
    return ''
  }
}

function readFieldString(field: ParsedField, names: string[]) {
  for (const name of names) {
    const attributeValue = field.attributes[name]
    if (attributeValue) return attributeValue

    const childValue = field.children[name]
    if (childValue !== undefined) return childValue
  }

  return ''
}

function parseSections(xml: string) {
  return Array.from(xml.matchAll(/<(Section|XSection)\b([^>]*)>([\s\S]*?)<\/\1>/g))
    .map((match, index) => {
      const attributes = parseAttributes(match[2])
      return {
        id: attributes.ID || attributes.Id || attributes.id || `section-${index + 1}`,
        title: attributes.Name || attributes.Title || attributes.name || `段落 ${index + 1}`,
        text: stripTags(match[3]).trim(),
      }
    })
    .filter(section => section.text)
}

function parseAttributes(source: string) {
  return Object.fromEntries(
    Array.from(source.matchAll(/([\w:-]+)="([^"]*)"/g)).map(match => [match[1], decodeXml(match[2])]),
  )
}

function parseChildren(source: string) {
  const entries = Array.from(source.matchAll(/<([\w:-]+)\b[^>]*>([\s\S]*?)<\/\1>|<([\w:-]+)\b[^>]*\/>/g))
    .map((match) => {
      const name = match[1] || match[3]
      const value = match[2] === undefined ? '' : decodeXml(stripTags(match[2]).trim())
      return [name, value]
    })

  return Object.fromEntries(entries) as Record<string, string>
}

function isXmlStructurallyBalanced(xml: string) {
  const stack: string[] = []
  const source = xml
    .replace(/<\?[\s\S]*?\?>/g, '')
    .replace(/<!--[\s\S]*?-->/g, '')
    .replace(/<!\[CDATA\[[\s\S]*?]]>/g, '')

  for (const match of source.matchAll(/<\/([^>\s]+)>|<([^!?/][^>\s/]*)([^>]*)>/g)) {
    const closingName = match[1]
    const openingName = match[2]

    if (closingName) {
      if (stack.pop() !== closingName) return false
      continue
    }

    if (!openingName || match[3].trimEnd().endsWith('/')) {
      continue
    }

    stack.push(openingName)
  }

  return stack.length === 0
}

function stripTags(value: string) {
  return value.replace(/<[^>]+>/g, '')
}

function decodeXml(value: string) {
  return value
    .replace(/&lt;/g, '<')
    .replace(/&gt;/g, '>')
    .replace(/&quot;/g, '"')
    .replace(/&apos;/g, "'")
    .replace(/&amp;/g, '&')
}

function nullableNumber(value: unknown) {
  if (value === undefined || value === null || value === '') return undefined
  const numberValue = Number(value)
  return Number.isFinite(numberValue) ? numberValue : undefined
}

function stringValue(value: unknown) {
  return value === undefined || value === null ? '' : String(value)
}

function BooleanValue(value: unknown) {
  return value === true || value === 'true' || value === 'True' || value === '1'
}
