# Medical Document QC Agent Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a medical document quality-control Agent that adds rule-first document QC, mock semantic Agent review, explainable issue cards, and save-before blocking for high-risk deterministic issues.

**Architecture:** Keep WriterControl and `EditorShell` as the editing composition surface, but move QC behavior into small typed units: `qualityControl` types, `documentFactExtractor`, `qcRuleEngine`, `qcAgentService`, `useQualityControlSession`, and focused Vue panels. Save flow should call deterministic QC before backend save; semantic Agent suggestions run manually or asynchronously and never auto-modify clinical documents.

**Tech Stack:** Vue 3 + Composition API + `<script setup lang="ts">`, TypeScript, Vitest, Vite, existing .NET 9 Minimal API only if a later phase adds backend QC endpoints.

---

## File Structure

### Frontend Types

- Create `frontend/src/types/qualityControl.ts`
  - Own all QC-specific contracts: facts, evidence, issues, reports, options, Agent provider output.

### Frontend Services

- Create `frontend/src/services/documentFactExtractor.ts`
  - Parse XML into `DocumentFacts`.
  - Extract input fields, values, required flags, `ValidateStyle`, metadata bindings, timeline facts, and evidence snippets.

- Create `frontend/src/services/documentFactExtractor.test.ts`
  - Unit tests for required fields, `ValidateStyle`, metadata binding, timeline facts, and invalid XML.

- Create `frontend/src/services/qcRuleEngine.ts`
  - Convert `DocumentFacts` into deterministic `QualityControlIssue[]`.
  - Include XML parse issue, required fields, numeric/date ranges, timeline checks, and simple completeness checks.

- Create `frontend/src/services/qcRuleEngine.test.ts`
  - Unit tests for blocking required fields, date order, valid facts, summary counts, and rule isolation.

- Create `frontend/src/services/qcAgentService.ts`
  - Provide a mock semantic review provider.
  - Validate/sanitize Agent issues into safe non-blocking suggestions unless deterministic evidence supports blocking.

- Create `frontend/src/services/qcAgentService.test.ts`
  - Unit tests for mock semantic issue generation, safe output normalization, and invalid provider output.

- Modify `frontend/src/services/documentValidationService.ts`
  - Keep public `validateDocumentXml(xml)` for compatibility.
  - Internally delegate to fact extraction + rule engine and map blocking QC issues back to legacy `ValidationIssue[]`.

- Modify `frontend/src/services/documentValidationService.test.ts`
  - Preserve existing assertions.
  - Add coverage for `ValidateStyle.Required`, invalid XML, and date-order blocking issue mapping.

- Modify `frontend/src/services/documentSaveService.ts`
  - Keep existing result union stable.
  - Continue using `validateDocumentXml` so current save tests remain meaningful.
  - Do not call semantic Agent in save path.

### Frontend Composable

- Create `frontend/src/composables/useQualityControlSession.ts`
  - Manage current `QualityControlReport`, running state, errors, ignored/resolved issue ids, and stale result protection.
  - Expose readonly state and explicit actions.

- Create `frontend/src/composables/useQualityControlSession.test.ts`
  - Unit tests for running QC, stale result discard, ignore/resolved actions, clear, and error fallback.

### Frontend Components

- Create `frontend/src/components/editor/QualityControlPanel.vue`
  - Display issue cards from `QualityControlReport`.
  - Filter all/blocking/suggestion/ignored.
  - Emit `selectIssue`, `ignoreIssue`, `resolveIssue`, and `runQualityControl`.

- Create `frontend/src/components/editor/QualityControlSummaryBar.vue`
  - Display compact counts and run state.
  - Emit `runQualityControl`.

- Modify `frontend/src/components/editor/WorkbenchEditorArea.vue`
  - Replace `ValidationPanel` with `QualityControlPanel`.
  - Add `qualityControlReport`, `isQualityControlRunning`, and `qualityControlError` props.
  - Re-emit QC actions upward.

- Modify `frontend/src/components/editor/EditorStatusBar.vue`
  - Keep existing `validationCount` prop.
  - Add optional `qualityControlBlockingCount` and `qualityControlSuggestionCount` if needed after UI integration.

- Modify `frontend/src/components/editor/EditorShell.vue`
  - Compose `useQualityControlSession`.
  - On save failure from validation, convert legacy validation issues into a QC report for display.
  - Add manual "run QC" handler that saves current XML snapshot, extracts facts, runs deterministic rules and mock Agent, and updates panel.
  - Preserve template, save, print, metadata, fragment-template, and property-inspector flows.

### Optional Backend Boundary

- Do not implement `/api/qc/*` in this pass unless frontend MVP is stable.
- Leave backend QC endpoints for a follow-up plan after the frontend mock Agent is accepted.

---

## Component Map

- `EditorShell.vue`: Composition surface. Owns WriterControl adapter, document session, quality-control session, and routes events.
- `WorkbenchEditorArea.vue`: Layout component. Receives document, status, tabs, and QC state as props; emits user actions upward.
- `QualityControlPanel.vue`: Presentational + local filter state. It must not parse XML or call services.
- `QualityControlSummaryBar.vue`: Presentational compact status. It must not own reports or call services.
- `useQualityControlSession.ts`: Stateful QC orchestration. Keeps report/error/running state and stale result guard.
- `documentFactExtractor.ts`: Pure service. Converts XML/context into facts.
- `qcRuleEngine.ts`: Pure service. Converts facts into deterministic report/issues.
- `qcAgentService.ts`: Provider-based service. Mock semantic review and output safety normalization.

## Task 1: QC Shared Types

**Files:**

- Create: `frontend/src/types/qualityControl.ts`

- [ ] **Step 1: Write the type module**

Create `frontend/src/types/qualityControl.ts` with:

```ts
import type { DocumentSource } from './document'

export type QualityControlCategory =
  | 'required'
  | 'format'
  | 'timeline'
  | 'consistency'
  | 'completeness'
  | 'semantic'
  | 'safety'

export type QualityControlSeverity = 'critical' | 'error' | 'warning' | 'suggestion'
export type QualityControlSource = 'rule' | 'agent'
export type QualityControlIssueStatus = 'open' | 'ignored' | 'resolved'

export interface EvidenceSnippet {
  id: string
  label: string
  text: string
  fieldId?: string
  sectionId?: string
}

export interface ClinicalSectionFact {
  id: string
  title: string
  text: string
}

export interface ClinicalFieldFact {
  id: string
  name: string
  value: string
  required: boolean
  valueType?: 'text' | 'numeric' | 'datetime' | 'dictionary'
  bindingPath?: string
  dataSourceName?: string
  evidenceId: string
}

export interface MetadataBindingFact {
  fieldId: string
  bindingPath: string
  dataSourceName?: string
}

export interface FieldValidationRuleFact {
  fieldId: string
  required: boolean
  minValue?: number
  maxValue?: number
  dateTimeMinValue?: string
  dateTimeMaxValue?: string
  raw: Record<string, unknown>
}

export interface ClinicalTimelineFact {
  id: string
  label: string
  value: string
  fieldId?: string
}

export interface DocumentFacts {
  documentId: string
  fileName: string
  source: DocumentSource
  templateId?: string
  generatedAt: string
  parseError?: string
  sections: ClinicalSectionFact[]
  fields: ClinicalFieldFact[]
  metadataBindings: MetadataBindingFact[]
  validationRules: FieldValidationRuleFact[]
  timeline: ClinicalTimelineFact[]
  snippets: EvidenceSnippet[]
}

export interface QualityControlIssue {
  id: string
  category: QualityControlCategory
  severity: QualityControlSeverity
  title: string
  message: string
  suggestion: string
  evidence: EvidenceSnippet[]
  fieldId?: string
  fieldName?: string
  blocking: boolean
  confidence: number
  source: QualityControlSource
  status: QualityControlIssueStatus
}

export interface QualityControlSummary {
  criticalCount: number
  errorCount: number
  warningCount: number
  suggestionCount: number
  blockingCount: number
}

export interface QualityControlReport {
  id: string
  documentId: string
  ruleVersion: string
  agentVersion: string
  generatedAt: string
  summary: QualityControlSummary
  issues: QualityControlIssue[]
}

export interface QualityControlRunInput {
  documentId: string
  fileName: string
  source: DocumentSource
  templateId?: string
  xml: string
}

export interface QualityControlAgentProvider {
  analyze: (facts: DocumentFacts) => Promise<QualityControlIssue[]>
}
```

- [ ] **Step 2: Verify TypeScript accepts the new module**

Run:

```powershell
cd .\frontend
npm run build
```

Expected: the build still passes or fails only because later planned modules do not exist yet if this task is batched with following tasks. If running this task alone, it should pass.

- [ ] **Step 3: Commit shared types**

```powershell
git add frontend/src/types/qualityControl.ts
git commit -m "feat: add quality control domain types"
```

## Task 2: Document Fact Extraction

**Files:**

- Create: `frontend/src/services/documentFactExtractor.test.ts`
- Create: `frontend/src/services/documentFactExtractor.ts`

- [ ] **Step 1: Write failing fact extraction tests**

Create `frontend/src/services/documentFactExtractor.test.ts`:

```ts
import { describe, expect, it, vi } from 'vitest'
import { extractDocumentFacts } from './documentFactExtractor'

describe('documentFactExtractor', () => {
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

    vi.useRealTimers()
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
```

- [ ] **Step 2: Run test to verify it fails**

Run:

```powershell
cd .\frontend
npm test -- documentFactExtractor.test.ts
```

Expected: FAIL because `documentFactExtractor.ts` does not exist.

- [ ] **Step 3: Implement fact extraction**

Create `frontend/src/services/documentFactExtractor.ts`:

```ts
import type {
  ClinicalFieldFact,
  ClinicalTimelineFact,
  DocumentFacts,
  EvidenceSnippet,
  FieldValidationRuleFact,
  MetadataBindingFact,
  QualityControlRunInput,
} from '../types/qualityControl'

const timelineBindingNames = new Map([
  ['Visit.AdmissionDate', '入院日期'],
  ['Visit.DischargeDate', '出院日期'],
  ['Operation.Date', '手术日期'],
])

export function extractDocumentFacts(input: QualityControlRunInput): DocumentFacts {
  const base = createEmptyFacts(input)
  const parsed = new DOMParser().parseFromString(input.xml, 'application/xml')

  if (parsed.querySelector('parsererror')) {
    return {
      ...base,
      parseError: '文档 XML 无法解析。',
    }
  }

  const fields = Array.from(
    parsed.querySelectorAll('XInputField, InputField, inputfield, Element'),
  ).filter(isInputField)

  fields.forEach((field, index) => {
    const fieldId = readFieldId(field, index)
    const fieldName = readFieldName(field, fieldId)
    const value = readFieldValue(field)
    const validationRule = readValidationRule(field)
    const bindingPath = readAttributeOrChild(field, ['BindingPath', 'bindingPath'])
      || readValueBindingPart(field, 'BindingPath')
    const dataSourceName = readAttributeOrChild(field, ['DataSource', 'dataSource'])
      || readValueBindingPart(field, 'DataSource')
    const evidence: EvidenceSnippet = {
      id: `evidence-${fieldId}`,
      label: fieldName,
      text: value || `${fieldName}：空值`,
      fieldId,
    }

    base.snippets.push(evidence)
    base.fields.push({
      id: fieldId,
      name: fieldName,
      value,
      required: isRequiredField(field, validationRule),
      bindingPath: bindingPath || undefined,
      dataSourceName: dataSourceName || undefined,
      evidenceId: evidence.id,
    } satisfies ClinicalFieldFact)

    if (bindingPath) {
      base.metadataBindings.push({
        fieldId,
        bindingPath,
        dataSourceName: dataSourceName || undefined,
      } satisfies MetadataBindingFact)
    }

    base.validationRules.push({
      fieldId,
      required: Boolean(validationRule.Required) || isRequiredField(field, validationRule),
      minValue: nullableNumber(validationRule.MinValue),
      maxValue: nullableNumber(validationRule.MaxValue),
      dateTimeMinValue: stringValue(validationRule.DateTimeMinValue),
      dateTimeMaxValue: stringValue(validationRule.DateTimeMaxValue),
      raw: validationRule,
    } satisfies FieldValidationRuleFact)

    const timelineLabel = bindingPath ? timelineBindingNames.get(bindingPath) : undefined
    if (timelineLabel && value) {
      base.timeline.push({
        id: fieldId,
        label: timelineLabel,
        value,
        fieldId,
      } satisfies ClinicalTimelineFact)
    }
  })

  base.sections = extractSections(parsed)
  return base
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

function isInputField(field: Element) {
  const tagName = field.tagName.toLowerCase()
  if (tagName === 'xinputfield' || tagName === 'inputfield') return true
  if (tagName !== 'element') return false
  return readAttribute(field, ['xsi:type', 'type']) === 'XInputField'
}

function readFieldId(field: Element, index: number) {
  return readAttributeOrChild(field, ['ID', 'Id', 'id']) || `field-${index + 1}`
}

function readFieldName(field: Element, fallback: string) {
  return readAttributeOrChild(field, ['Name', 'Title', 'name'])
    || readChildText(field, ['BackgroundText'])
    || fallback
}

function readFieldValue(field: Element) {
  return (
    readChildText(field, ['InnerValue', 'innerValue', 'Value', 'value'])
    || readAttribute(field, ['Value', 'value'])
    || ''
  ).trim()
}

function readValidationRule(field: Element) {
  const raw = readAttributeOrChild(field, ['ValidateStyle'])
  if (!raw) return {}

  if (raw.trim().startsWith('{')) {
    try {
      return JSON.parse(raw) as Record<string, unknown>
    } catch {
      return {}
    }
  }

  const required = readTagText(raw, 'Required')
  return required === null ? {} : { Required: required }
}

function isRequiredField(field: Element, validationRule: Record<string, unknown>) {
  const value =
    readAttributeOrChild(field, ['Required', 'required', 'NotNull', 'notNull', 'RequiredValue'])
    || stringValue(validationRule.Required)
  return value === 'true' || value === 'True' || value === '1'
}

function readValueBindingPart(field: Element, key: string) {
  const raw = readAttributeOrChild(field, ['ValueBinding'])
  if (!raw || !raw.trim().startsWith('{')) return ''
  try {
    const value = JSON.parse(raw) as Record<string, unknown>
    return stringValue(value[key])
  } catch {
    return ''
  }
}

function extractSections(document: Document) {
  return Array.from(document.querySelectorAll('Section, XSection'))
    .map((section, index) => ({
      id: readAttributeOrChild(section, ['ID', 'Id', 'id']) || `section-${index + 1}`,
      title: readAttributeOrChild(section, ['Name', 'Title', 'name']) || `段落 ${index + 1}`,
      text: (section.textContent || '').trim(),
    }))
    .filter(section => section.text)
}

function readAttributeOrChild(element: Element, names: string[]) {
  return readAttribute(element, names) || readChildText(element, names)
}

function readAttribute(element: Element, names: string[]) {
  for (const name of names) {
    const value = element.getAttribute(name)
    if (value) return value
  }
  return ''
}

function readChildText(element: Element, names: string[]) {
  for (const name of names) {
    const child = element.querySelector(name)
    if (child) return child.textContent?.trim() ?? ''
  }
  return ''
}

function readTagText(source: string, name: string) {
  const match = source.match(new RegExp(`<${name}\\b[^>]*>([\\s\\S]*?)</${name}>`))
  return match?.[1]?.trim() ?? null
}

function nullableNumber(value: unknown) {
  if (value === undefined || value === null || value === '') return undefined
  const numberValue = Number(value)
  return Number.isFinite(numberValue) ? numberValue : undefined
}

function stringValue(value: unknown) {
  return value === undefined || value === null ? '' : String(value)
}
```

- [ ] **Step 4: Run fact extractor tests**

Run:

```powershell
cd .\frontend
npm test -- documentFactExtractor.test.ts
```

Expected: PASS.

- [ ] **Step 5: Commit fact extraction**

```powershell
git add frontend/src/services/documentFactExtractor.ts frontend/src/services/documentFactExtractor.test.ts
git commit -m "feat: extract quality control document facts"
```

## Task 3: Deterministic Rule Engine

**Files:**

- Create: `frontend/src/services/qcRuleEngine.test.ts`
- Create: `frontend/src/services/qcRuleEngine.ts`

- [ ] **Step 1: Write failing rule engine tests**

Create `frontend/src/services/qcRuleEngine.test.ts`:

```ts
import { describe, expect, it } from 'vitest'
import type { DocumentFacts } from '../types/qualityControl'
import { createQualityControlReport, runQualityControlRules } from './qcRuleEngine'

describe('qcRuleEngine', () => {
  it('returns a blocking required issue for empty required fields', () => {
    const issues = runQualityControlRules(createFacts({
      fields: [
        {
          id: 'chief-complaint',
          name: '主诉',
          value: '',
          required: true,
          evidenceId: 'ev-1',
        },
      ],
      snippets: [{ id: 'ev-1', label: '主诉', text: '主诉：空值', fieldId: 'chief-complaint' }],
    }))

    expect(issues).toEqual([
      expect.objectContaining({
        id: 'required-chief-complaint',
        category: 'required',
        severity: 'error',
        blocking: true,
        source: 'rule',
      }),
    ])
  })

  it('returns a blocking timeline issue when discharge date is before admission date', () => {
    const issues = runQualityControlRules(createFacts({
      timeline: [
        { id: 'admission-date', label: '入院日期', value: '2026-06-02' },
        { id: 'discharge-date', label: '出院日期', value: '2026-06-01' },
      ],
    }))

    expect(issues).toEqual([
      expect.objectContaining({
        id: 'timeline-discharge-before-admission',
        category: 'timeline',
        severity: 'error',
        blocking: true,
      }),
    ])
  })

  it('creates a report summary from issues', () => {
    const report = createQualityControlReport('doc-1', [
      issue('critical', true),
      issue('warning', false),
      issue('suggestion', false),
    ], { agentVersion: 'mock-agent-v1' })

    expect(report.summary).toEqual({
      criticalCount: 1,
      errorCount: 0,
      warningCount: 1,
      suggestionCount: 1,
      blockingCount: 1,
    })
    expect(report.agentVersion).toBe('mock-agent-v1')
  })

  it('returns parse error as critical issue', () => {
    const issues = runQualityControlRules(createFacts({ parseError: '文档 XML 无法解析。' }))

    expect(issues).toEqual([
      expect.objectContaining({
        id: 'invalid-xml',
        severity: 'critical',
        blocking: true,
      }),
    ])
  })
})

function createFacts(patch: Partial<DocumentFacts>): DocumentFacts {
  return {
    documentId: 'doc-1',
    fileName: 'record.xml',
    source: 'local',
    generatedAt: '2026-06-05T08:00:00.000Z',
    sections: [],
    fields: [],
    metadataBindings: [],
    validationRules: [],
    timeline: [],
    snippets: [],
    ...patch,
  }
}

function issue(severity: 'critical' | 'error' | 'warning' | 'suggestion', blocking: boolean) {
  return {
    id: `issue-${severity}`,
    category: 'semantic' as const,
    severity,
    title: severity,
    message: severity,
    suggestion: '请核对。',
    evidence: [],
    blocking,
    confidence: 0.9,
    source: 'rule' as const,
    status: 'open' as const,
  }
}
```

- [ ] **Step 2: Run test to verify it fails**

Run:

```powershell
cd .\frontend
npm test -- qcRuleEngine.test.ts
```

Expected: FAIL because `qcRuleEngine.ts` does not exist.

- [ ] **Step 3: Implement rule engine**

Create `frontend/src/services/qcRuleEngine.ts`:

```ts
import type {
  DocumentFacts,
  EvidenceSnippet,
  QualityControlIssue,
  QualityControlReport,
  QualityControlSeverity,
} from '../types/qualityControl'

export const qcRuleVersion = 'qc-rules-v1'

export function runQualityControlRules(facts: DocumentFacts): QualityControlIssue[] {
  const issues: QualityControlIssue[] = []

  if (facts.parseError) {
    issues.push({
      id: 'invalid-xml',
      category: 'format',
      severity: 'critical',
      title: 'XML 无法解析',
      message: facts.parseError,
      suggestion: '请检查文书 XML 是否完整，必要时重新从编辑器保存。',
      evidence: [],
      blocking: true,
      confidence: 1,
      source: 'rule',
      status: 'open',
    })
    return issues
  }

  for (const field of facts.fields) {
    if (field.required && !field.value.trim()) {
      issues.push({
        id: `required-${field.id}`,
        category: 'required',
        severity: 'error',
        title: `${field.name}不能为空`,
        message: `必填项“${field.name}”不能为空。`,
        suggestion: `请补充“${field.name}”后再保存。`,
        evidence: evidenceForField(facts, field.evidenceId),
        fieldId: field.id,
        fieldName: field.name,
        blocking: true,
        confidence: 1,
        source: 'rule',
        status: 'open',
      })
    }
  }

  const admissionDate = findTimelineDate(facts, '入院日期')
  const dischargeDate = findTimelineDate(facts, '出院日期')
  if (admissionDate && dischargeDate && dischargeDate.value < admissionDate.value) {
    issues.push({
      id: 'timeline-discharge-before-admission',
      category: 'timeline',
      severity: 'error',
      title: '出院日期早于入院日期',
      message: `出院日期“${dischargeDate.value}”早于入院日期“${admissionDate.value}”。`,
      suggestion: '请核对入院日期和出院日期。',
      evidence: [],
      fieldId: dischargeDate.fieldId,
      fieldName: dischargeDate.label,
      blocking: true,
      confidence: 1,
      source: 'rule',
      status: 'open',
    })
  }

  return issues
}

export function createQualityControlReport(
  documentId: string,
  issues: QualityControlIssue[],
  options: { agentVersion?: string } = {},
): QualityControlReport {
  return {
    id: `qc-${documentId}-${Date.now()}`,
    documentId,
    ruleVersion: qcRuleVersion,
    agentVersion: options.agentVersion || 'none',
    generatedAt: new Date().toISOString(),
    summary: summarizeIssues(issues),
    issues,
  }
}

export function summarizeIssues(issues: readonly QualityControlIssue[]) {
  return {
    criticalCount: countSeverity(issues, 'critical'),
    errorCount: countSeverity(issues, 'error'),
    warningCount: countSeverity(issues, 'warning'),
    suggestionCount: countSeverity(issues, 'suggestion'),
    blockingCount: issues.filter(issue => issue.blocking).length,
  }
}

function countSeverity(issues: readonly QualityControlIssue[], severity: QualityControlSeverity) {
  return issues.filter(issue => issue.severity === severity).length
}

function evidenceForField(facts: DocumentFacts, evidenceId: string): EvidenceSnippet[] {
  const evidence = facts.snippets.find(snippet => snippet.id === evidenceId)
  return evidence ? [evidence] : []
}

function findTimelineDate(facts: DocumentFacts, label: string) {
  const fact = facts.timeline.find(item => item.label === label)
  if (!fact) return null
  const value = Date.parse(fact.value)
  return Number.isNaN(value) ? null : { ...fact, value: new Date(value).toISOString().slice(0, 10) }
}
```

- [ ] **Step 4: Run rule engine tests**

Run:

```powershell
cd .\frontend
npm test -- qcRuleEngine.test.ts
```

Expected: PASS.

- [ ] **Step 5: Commit rule engine**

```powershell
git add frontend/src/services/qcRuleEngine.ts frontend/src/services/qcRuleEngine.test.ts
git commit -m "feat: add deterministic quality control rules"
```

## Task 4: Legacy Validation Compatibility

**Files:**

- Modify: `frontend/src/services/documentValidationService.ts`
- Modify: `frontend/src/services/documentValidationService.test.ts`

- [ ] **Step 1: Add failing compatibility tests**

Append to `frontend/src/services/documentValidationService.test.ts`:

```ts
  it('maps discharge before admission to a legacy validation issue', () => {
    const xml = `
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
`

    expect(validateDocumentXml(xml)).toEqual([
      expect.objectContaining({
        id: 'timeline-discharge-before-admission',
        fieldId: 'discharge-date',
        fieldName: '出院日期',
        severity: 'error',
      }),
    ])
  })
```

- [ ] **Step 2: Run compatibility tests to verify failure**

Run:

```powershell
cd .\frontend
npm test -- documentValidationService.test.ts
```

Expected: FAIL because the existing validator does not use QC facts/rules yet.

- [ ] **Step 3: Delegate validation to QC services**

Replace `frontend/src/services/documentValidationService.ts` with:

```ts
import type { ValidationIssue } from '../types/document'
import type { QualityControlIssue } from '../types/qualityControl'
import { extractDocumentFacts } from './documentFactExtractor'
import { runQualityControlRules } from './qcRuleEngine'

export function validateDocumentXml(xml: string): ValidationIssue[] {
  const facts = extractDocumentFacts({
    documentId: 'document',
    fileName: 'document.xml',
    source: 'unknown',
    xml,
  })

  return runQualityControlRules(facts)
    .filter(issue => issue.blocking)
    .map(toValidationIssue)
}

function toValidationIssue(issue: QualityControlIssue): ValidationIssue {
  return {
    id: issue.id,
    fieldId: issue.fieldId || 'document',
    fieldName: issue.fieldName || issue.title,
    message: issue.message,
    severity: issue.severity === 'critical' || issue.severity === 'error' ? 'error' : 'warning',
  }
}
```

- [ ] **Step 4: Update old tests only if DOM stubs become unnecessary**

If the old DOMParser stub tests now conflict with real `DOMParser` behavior, simplify them to pass real XML strings. Keep the same expected `ValidationIssue[]` payloads. Do not remove behavioral coverage.

- [ ] **Step 5: Run validation and save service tests**

Run:

```powershell
cd .\frontend
npm test -- documentValidationService.test.ts documentSaveService.test.ts
```

Expected: PASS.

- [ ] **Step 6: Commit validation compatibility**

```powershell
git add frontend/src/services/documentValidationService.ts frontend/src/services/documentValidationService.test.ts
git commit -m "feat: route document validation through quality control rules"
```

## Task 5: Mock QC Agent Service

**Files:**

- Create: `frontend/src/services/qcAgentService.test.ts`
- Create: `frontend/src/services/qcAgentService.ts`

- [ ] **Step 1: Write failing Agent service tests**

Create `frontend/src/services/qcAgentService.test.ts`:

```ts
import { describe, expect, it } from 'vitest'
import type { DocumentFacts } from '../types/qualityControl'
import { createMockQualityControlAgent, normalizeAgentIssues } from './qcAgentService'

describe('qcAgentService', () => {
  it('returns non-blocking semantic suggestions from mock Agent', async () => {
    const agent = createMockQualityControlAgent()
    const issues = await agent.analyze(createFacts({
      fields: [
        {
          id: 'chief-complaint',
          name: '主诉',
          value: '头痛三天',
          required: false,
          evidenceId: 'ev-chief',
        },
        {
          id: 'present-illness',
          name: '现病史',
          value: '患者否认头痛。',
          required: false,
          evidenceId: 'ev-illness',
        },
      ],
      snippets: [
        { id: 'ev-chief', label: '主诉', text: '头痛三天', fieldId: 'chief-complaint' },
        { id: 'ev-illness', label: '现病史', text: '患者否认头痛。', fieldId: 'present-illness' },
      ],
    }))

    expect(issues).toEqual([
      expect.objectContaining({
        category: 'semantic',
        severity: 'warning',
        blocking: false,
        source: 'agent',
      }),
    ])
  })

  it('normalizes unsafe Agent issues to non-blocking suggestions', () => {
    const normalized = normalizeAgentIssues(createFacts({ snippets: [] }), [
      {
        id: 'agent-danger',
        category: 'semantic',
        severity: 'critical',
        title: '危险输出',
        message: '请直接诊断。',
        suggestion: '立即调整医嘱。',
        evidence: [],
        blocking: true,
        confidence: 2,
        source: 'agent',
        status: 'open',
      },
    ])

    expect(normalized).toEqual([
      expect.objectContaining({
        severity: 'suggestion',
        blocking: false,
        confidence: 1,
        evidence: [],
      }),
    ])
  })
})

function createFacts(patch: Partial<DocumentFacts>): DocumentFacts {
  return {
    documentId: 'doc-1',
    fileName: 'record.xml',
    source: 'local',
    generatedAt: '2026-06-05T08:00:00.000Z',
    sections: [],
    fields: [],
    metadataBindings: [],
    validationRules: [],
    timeline: [],
    snippets: [],
    ...patch,
  }
}
```

- [ ] **Step 2: Run Agent tests to verify failure**

Run:

```powershell
cd .\frontend
npm test -- qcAgentService.test.ts
```

Expected: FAIL because `qcAgentService.ts` does not exist.

- [ ] **Step 3: Implement mock Agent service**

Create `frontend/src/services/qcAgentService.ts`:

```ts
import type {
  DocumentFacts,
  QualityControlAgentProvider,
  QualityControlIssue,
} from '../types/qualityControl'

export const mockAgentVersion = 'mock-qc-agent-v1'

export function createMockQualityControlAgent(): QualityControlAgentProvider {
  return {
    async analyze(facts: DocumentFacts) {
      const issues: QualityControlIssue[] = []
      const chiefComplaint = findField(facts, '主诉')
      const presentIllness = findField(facts, '现病史')

      if (
        chiefComplaint?.value.includes('头痛')
        && presentIllness?.value.includes('否认头痛')
      ) {
        issues.push({
          id: 'agent-chief-complaint-present-illness-conflict',
          category: 'semantic',
          severity: 'warning',
          title: '主诉与现病史疑似不一致',
          message: '主诉提到头痛，但现病史描述中出现否认头痛，请核对二者是否一致。',
          suggestion: '请核对主诉与现病史描述，必要时补充症状出现时间、持续时间和否认项范围。',
          evidence: facts.snippets.filter(snippet =>
            snippet.fieldId === chiefComplaint.id || snippet.fieldId === presentIllness.id,
          ),
          fieldId: presentIllness.id,
          fieldName: presentIllness.name,
          blocking: false,
          confidence: 0.76,
          source: 'agent',
          status: 'open',
        })
      }

      return normalizeAgentIssues(facts, issues)
    },
  }
}

export function normalizeAgentIssues(
  facts: DocumentFacts,
  issues: readonly QualityControlIssue[],
): QualityControlIssue[] {
  return issues.map((issue) => {
    const evidence = issue.evidence.filter(snippet =>
      facts.snippets.some(candidate => candidate.id === snippet.id),
    )
    return {
      ...issue,
      id: issue.id || `agent-${cryptoSafeId(issue.title)}`,
      severity: issue.severity === 'critical' || issue.severity === 'error'
        ? 'suggestion'
        : issue.severity,
      suggestion: safeSuggestion(issue.suggestion),
      evidence,
      blocking: false,
      confidence: Math.max(0, Math.min(1, issue.confidence)),
      source: 'agent',
      status: issue.status === 'ignored' || issue.status === 'resolved' ? issue.status : 'open',
    }
  })
}

function findField(facts: DocumentFacts, name: string) {
  return facts.fields.find(field => field.name === name)
}

function safeSuggestion(value: string) {
  if (!value.trim()) return '请核对相关文书内容。'
  if (value.includes('立即调整医嘱')) return '请核对相关文书内容，必要时补充证据说明。'
  return value
}

function cryptoSafeId(value: string) {
  return value
    .toLowerCase()
    .replace(/[^a-z0-9\u4e00-\u9fa5]+/g, '-')
    .replace(/^-|-$/g, '')
    || 'issue'
}
```

- [ ] **Step 4: Run Agent tests**

Run:

```powershell
cd .\frontend
npm test -- qcAgentService.test.ts
```

Expected: PASS.

- [ ] **Step 5: Commit mock Agent**

```powershell
git add frontend/src/services/qcAgentService.ts frontend/src/services/qcAgentService.test.ts
git commit -m "feat: add mock quality control agent"
```

## Task 6: QC Session Composable

**Files:**

- Create: `frontend/src/composables/useQualityControlSession.test.ts`
- Create: `frontend/src/composables/useQualityControlSession.ts`

- [ ] **Step 1: Write failing composable tests**

Create `frontend/src/composables/useQualityControlSession.test.ts`:

```ts
import { describe, expect, it } from 'vitest'
import { useQualityControlSession } from './useQualityControlSession'
import type { QualityControlReport } from '../types/qualityControl'

describe('useQualityControlSession', () => {
  it('runs QC and stores the latest report', async () => {
    const session = useQualityControlSession()

    await session.run('doc-1', async () => createReport('doc-1'))

    expect(session.report.value?.documentId).toBe('doc-1')
    expect(session.isRunning.value).toBe(false)
    expect(session.error.value).toBeNull()
  })

  it('discards stale results for older documents', async () => {
    const session = useQualityControlSession()
    let resolveOld!: (report: QualityControlReport) => void
    const oldRun = session.run('old', () => new Promise<QualityControlReport>((resolve) => {
      resolveOld = resolve
    }))
    const newRun = session.run('new', async () => createReport('new'))

    resolveOld(createReport('old'))
    await oldRun
    await newRun

    expect(session.report.value?.documentId).toBe('new')
  })

  it('marks issues ignored and resolved without mutating original report', async () => {
    const session = useQualityControlSession()
    await session.run('doc-1', async () => createReport('doc-1'))

    session.ignoreIssue('issue-1')
    expect(session.report.value?.issues[0].status).toBe('ignored')

    session.resolveIssue('issue-1')
    expect(session.report.value?.issues[0].status).toBe('resolved')
  })

  it('stores errors and clears state', async () => {
    const session = useQualityControlSession()

    await session.run('doc-1', async () => {
      throw new Error('质控失败')
    })

    expect(session.error.value).toBe('质控失败')
    session.clear()
    expect(session.report.value).toBeNull()
    expect(session.error.value).toBeNull()
  })
})

function createReport(documentId: string): QualityControlReport {
  return {
    id: `report-${documentId}`,
    documentId,
    ruleVersion: 'rules',
    agentVersion: 'agent',
    generatedAt: '2026-06-05T08:00:00.000Z',
    summary: {
      criticalCount: 0,
      errorCount: 1,
      warningCount: 0,
      suggestionCount: 0,
      blockingCount: 1,
    },
    issues: [{
      id: 'issue-1',
      category: 'required',
      severity: 'error',
      title: '必填',
      message: '必填',
      suggestion: '请补充。',
      evidence: [],
      blocking: true,
      confidence: 1,
      source: 'rule',
      status: 'open',
    }],
  }
}
```

- [ ] **Step 2: Run composable tests to verify failure**

Run:

```powershell
cd .\frontend
npm test -- useQualityControlSession.test.ts
```

Expected: FAIL because `useQualityControlSession.ts` does not exist.

- [ ] **Step 3: Implement composable**

Create `frontend/src/composables/useQualityControlSession.ts`:

```ts
import { readonly, shallowRef } from 'vue'
import type { QualityControlReport } from '../types/qualityControl'

export function useQualityControlSession() {
  const report = shallowRef<QualityControlReport | null>(null)
  const isRunning = shallowRef(false)
  const error = shallowRef<string | null>(null)
  const activeRunId = shallowRef(0)
  const activeDocumentId = shallowRef<string | null>(null)

  async function run(
    documentId: string,
    createReport: () => Promise<QualityControlReport>,
  ) {
    const runId = activeRunId.value + 1
    activeRunId.value = runId
    activeDocumentId.value = documentId
    isRunning.value = true
    error.value = null

    try {
      const nextReport = await createReport()
      if (runId !== activeRunId.value || documentId !== activeDocumentId.value) {
        return
      }
      report.value = cloneReport(nextReport)
    } catch (runError) {
      if (runId !== activeRunId.value) return
      error.value = runError instanceof Error ? runError.message : '质控运行失败。'
    } finally {
      if (runId === activeRunId.value) {
        isRunning.value = false
      }
    }
  }

  function ignoreIssue(issueId: string) {
    setIssueStatus(issueId, 'ignored')
  }

  function resolveIssue(issueId: string) {
    setIssueStatus(issueId, 'resolved')
  }

  function clear() {
    activeRunId.value += 1
    activeDocumentId.value = null
    report.value = null
    isRunning.value = false
    error.value = null
  }

  return {
    report: readonly(report),
    isRunning: readonly(isRunning),
    error: readonly(error),
    run,
    ignoreIssue,
    resolveIssue,
    clear,
  }

  function setIssueStatus(issueId: string, status: 'ignored' | 'resolved') {
    if (!report.value) return
    report.value = {
      ...report.value,
      issues: report.value.issues.map(issue =>
        issue.id === issueId ? { ...issue, status } : issue,
      ),
    }
  }
}

function cloneReport(report: QualityControlReport): QualityControlReport {
  return {
    ...report,
    summary: { ...report.summary },
    issues: report.issues.map(issue => ({
      ...issue,
      evidence: issue.evidence.map(snippet => ({ ...snippet })),
    })),
  }
}
```

- [ ] **Step 4: Run composable tests**

Run:

```powershell
cd .\frontend
npm test -- useQualityControlSession.test.ts
```

Expected: PASS.

- [ ] **Step 5: Commit composable**

```powershell
git add frontend/src/composables/useQualityControlSession.ts frontend/src/composables/useQualityControlSession.test.ts
git commit -m "feat: add quality control session state"
```

## Task 7: QC Panel Components

**Files:**

- Create: `frontend/src/components/editor/QualityControlPanel.vue`
- Create: `frontend/src/components/editor/QualityControlSummaryBar.vue`

- [ ] **Step 1: Create QualityControlPanel**

Create `frontend/src/components/editor/QualityControlPanel.vue`:

```vue
<script setup lang="ts">
import { computed, shallowRef } from 'vue'
import { AlertTriangle, CheckCircle2, RotateCw } from 'lucide-vue-next'
import type { QualityControlIssue, QualityControlReport } from '../../types/qualityControl'

type FilterId = 'all' | 'blocking' | 'suggestion' | 'ignored'

interface Props {
  report: QualityControlReport | null
  isRunning: boolean
  error: string | null
}

interface Emits {
  runQualityControl: []
  selectIssue: [issue: QualityControlIssue]
  ignoreIssue: [issueId: string]
  resolveIssue: [issueId: string]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()
const activeFilter = shallowRef<FilterId>('all')

const visibleIssues = computed(() => {
  const issues = props.report?.issues || []
  if (activeFilter.value === 'blocking') return issues.filter(issue => issue.blocking)
  if (activeFilter.value === 'suggestion') return issues.filter(issue => !issue.blocking)
  if (activeFilter.value === 'ignored') return issues.filter(issue => issue.status === 'ignored')
  return issues
})

const filters: { id: FilterId; label: string }[] = [
  { id: 'all', label: '全部' },
  { id: 'blocking', label: '阻断' },
  { id: 'suggestion', label: '建议' },
  { id: 'ignored', label: '已忽略' },
]
</script>

<template>
  <section class="quality-panel" aria-label="医疗文书质控">
    <div class="quality-panel__header">
      <div class="quality-panel__title">
        <AlertTriangle :size="16" aria-hidden="true" />
        <span>文书质控</span>
      </div>
      <button
        class="quality-panel__run"
        type="button"
        :disabled="props.isRunning"
        @click="emit('runQualityControl')"
      >
        <RotateCw :size="14" aria-hidden="true" />
        {{ props.isRunning ? '质控中' : '运行质控' }}
      </button>
    </div>

    <p v-if="props.error" class="quality-panel__error">{{ props.error }}</p>

    <div v-if="props.report" class="quality-panel__summary">
      <span>阻断 {{ props.report.summary.blockingCount }}</span>
      <span>错误 {{ props.report.summary.errorCount }}</span>
      <span>建议 {{ props.report.summary.suggestionCount + props.report.summary.warningCount }}</span>
    </div>

    <div class="quality-panel__filters" role="tablist" aria-label="质控过滤">
      <button
        v-for="filter in filters"
        :key="filter.id"
        class="quality-panel__filter"
        :class="{ 'quality-panel__filter--active': activeFilter === filter.id }"
        type="button"
        @click="activeFilter = filter.id"
      >
        {{ filter.label }}
      </button>
    </div>

    <div v-if="visibleIssues.length === 0" class="quality-panel__empty">
      <CheckCircle2 :size="16" aria-hidden="true" />
      <span>{{ props.report ? '当前过滤下暂无问题' : '尚未运行质控' }}</span>
    </div>

    <button
      v-for="issue in visibleIssues"
      :key="issue.id"
      class="quality-panel__issue"
      :class="`quality-panel__issue--${issue.severity}`"
      type="button"
      @click="emit('selectIssue', issue)"
    >
      <span class="quality-panel__badge">{{ issue.blocking ? '阻断' : '建议' }}</span>
      <span class="quality-panel__issue-title">{{ issue.title }}</span>
      <span class="quality-panel__issue-message">{{ issue.message }}</span>
      <span class="quality-panel__issue-suggestion">{{ issue.suggestion }}</span>
      <span class="quality-panel__actions" @click.stop>
        <button type="button" @click="emit('ignoreIssue', issue.id)">忽略</button>
        <button type="button" @click="emit('resolveIssue', issue.id)">已处理</button>
      </span>
    </button>
  </section>
</template>

<style scoped>
.quality-panel {
  display: grid;
  max-height: 220px;
  border-top: 1px solid #d6b25e;
  background: #fff9e8;
  color: #3f3417;
  font-size: 12px;
}

.quality-panel__header,
.quality-panel__summary,
.quality-panel__filters {
  display: flex;
  align-items: center;
  gap: 8px;
  padding: 6px 12px;
}

.quality-panel__header {
  justify-content: space-between;
  font-weight: 700;
}

.quality-panel__title,
.quality-panel__run {
  display: inline-flex;
  align-items: center;
  gap: 6px;
}

.quality-panel__run,
.quality-panel__filter,
.quality-panel__actions button {
  border: 1px solid #d8c48a;
  border-radius: 4px;
  background: #fff;
  color: inherit;
}

.quality-panel__filter--active {
  background: #ffe7a3;
  font-weight: 700;
}

.quality-panel__error {
  margin: 0;
  padding: 6px 12px;
  color: #b42318;
}

.quality-panel__empty {
  display: inline-flex;
  align-items: center;
  gap: 6px;
  padding: 10px 12px;
  color: #596273;
}

.quality-panel__issue {
  display: grid;
  grid-template-columns: 42px minmax(0, 1fr) auto;
  gap: 4px 8px;
  padding: 8px 12px;
  border: 0;
  border-top: 1px solid rgba(216, 196, 138, 0.65);
  background: transparent;
  color: inherit;
  text-align: left;
}

.quality-panel__issue:hover {
  background: #fff0bd;
}

.quality-panel__badge {
  color: #9a3412;
  font-weight: 700;
}

.quality-panel__issue-title {
  font-weight: 700;
}

.quality-panel__issue-message,
.quality-panel__issue-suggestion {
  grid-column: 2 / 4;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.quality-panel__actions {
  display: inline-flex;
  gap: 4px;
}
</style>
```

- [ ] **Step 2: Create QualityControlSummaryBar**

Create `frontend/src/components/editor/QualityControlSummaryBar.vue`:

```vue
<script setup lang="ts">
import type { QualityControlReport } from '../../types/qualityControl'

interface Props {
  report: QualityControlReport | null
  isRunning: boolean
}

interface Emits {
  runQualityControl: []
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()
</script>

<template>
  <div class="quality-summary">
    <span>{{ props.isRunning ? '质控运行中' : '质控' }}</span>
    <span v-if="props.report">阻断 {{ props.report.summary.blockingCount }}</span>
    <span v-if="props.report">建议 {{ props.report.summary.warningCount + props.report.summary.suggestionCount }}</span>
    <button type="button" :disabled="props.isRunning" @click="emit('runQualityControl')">
      运行质控
    </button>
  </div>
</template>

<style scoped>
.quality-summary {
  display: inline-flex;
  align-items: center;
  gap: 8px;
  color: #4b5563;
}

.quality-summary button {
  border: 1px solid #cbd5e1;
  border-radius: 4px;
  background: #fff;
  color: #334155;
}
</style>
```

- [ ] **Step 3: Run frontend build for SFC type checking**

Run:

```powershell
cd .\frontend
npm run build
```

Expected: PASS if prior tasks are complete.

- [ ] **Step 4: Commit QC panel components**

```powershell
git add frontend/src/components/editor/QualityControlPanel.vue frontend/src/components/editor/QualityControlSummaryBar.vue
git commit -m "feat: add quality control panel components"
```

## Task 8: Editor Integration

**Files:**

- Modify: `frontend/src/components/editor/WorkbenchEditorArea.vue`
- Modify: `frontend/src/components/editor/EditorShell.vue`
- Modify: `frontend/src/components/editor/EditorStatusBar.vue` only if needed

- [ ] **Step 1: Wire QC props and events through WorkbenchEditorArea**

Modify `WorkbenchEditorArea.vue`:

```ts
import QualityControlPanel from './QualityControlPanel.vue'
import type { QualityControlIssue, QualityControlReport } from '../../types/qualityControl'

interface Props {
  // keep existing props
  qualityControlReport: QualityControlReport | null
  isQualityControlRunning: boolean
  qualityControlError: string | null
}

interface Emits {
  // keep existing emits
  runQualityControl: []
  ignoreQualityIssue: [issueId: string]
  resolveQualityIssue: [issueId: string]
  selectQualityIssue: [issue: QualityControlIssue]
}
```

Replace the old `ValidationPanel` block with:

```vue
<QualityControlPanel
  :report="props.qualityControlReport"
  :is-running="props.isQualityControlRunning"
  :error="props.qualityControlError"
  @run-quality-control="emit('runQualityControl')"
  @select-issue="emit('selectQualityIssue', $event)"
  @ignore-issue="emit('ignoreQualityIssue', $event)"
  @resolve-issue="emit('resolveQualityIssue', $event)"
/>
```

- [ ] **Step 2: Compose QC session in EditorShell**

Modify imports in `EditorShell.vue`:

```ts
import { useQualityControlSession } from '../../composables/useQualityControlSession'
import { extractDocumentFacts } from '../../services/documentFactExtractor'
import { createMockQualityControlAgent, mockAgentVersion } from '../../services/qcAgentService'
import { createQualityControlReport, runQualityControlRules } from '../../services/qcRuleEngine'
import type { QualityControlIssue } from '../../types/qualityControl'
```

Add setup state:

```ts
const qualityControl = useQualityControlSession()
const qualityControlAgent = createMockQualityControlAgent()
```

Add runner:

```ts
async function runQualityControl() {
  const document = session.document.value
  if (!document) return

  const result = adapter.value.saveXml()
  if (!result.ok) {
    session.markFailed(result.message, document.id)
    return
  }

  await qualityControl.run(document.id, async () => {
    const facts = extractDocumentFacts({
      documentId: document.id,
      fileName: document.fileName,
      source: document.source,
      templateId: document.templateId,
      xml: result.xml,
    })
    const ruleIssues = runQualityControlRules(facts)
    const agentIssues = await qualityControlAgent.analyze(facts)
    return createQualityControlReport(document.id, [...ruleIssues, ...agentIssues], {
      agentVersion: mockAgentVersion,
    })
  })
}
```

Update validation issue handler:

```ts
function handleQualityIssue(issue: QualityControlIssue) {
  session.markFailed(`暂时无法自动定位问题“${issue.title}”：${issue.message}`)
}
```

Update `WorkbenchEditorArea` usage:

```vue
<WorkbenchEditorArea
  ...
  :quality-control-report="qualityControl.report.value"
  :is-quality-control-running="qualityControl.isRunning.value"
  :quality-control-error="qualityControl.error.value"
  @run-quality-control="runQualityControl"
  @select-quality-issue="handleQualityIssue"
  @ignore-quality-issue="qualityControl.ignoreIssue"
  @resolve-quality-issue="qualityControl.resolveIssue"
/>
```

- [ ] **Step 3: Preserve save-before validation behavior**

Keep `saveToBackend()` using `saveDocumentToBackend`. When result reason is `validation-failed`, continue calling `session.setValidationIssues(result.issues)` for compatibility and additionally create a QC report if the new panel no longer receives legacy validation issues directly.

If a helper is needed, add:

```ts
function createReportFromValidationIssues(documentId: string, issues: readonly ValidationIssue[]) {
  return createQualityControlReport(documentId, issues.map(issue => ({
    id: issue.id,
    category: 'required',
    severity: issue.severity === 'error' ? 'error' : 'warning',
    title: issue.fieldName,
    message: issue.message,
    suggestion: `请核对“${issue.fieldName}”。`,
    evidence: [],
    fieldId: issue.fieldId,
    fieldName: issue.fieldName,
    blocking: issue.severity === 'error',
    confidence: 1,
    source: 'rule',
    status: 'open',
  })), { agentVersion: 'none' })
}
```

Then store it through a `qualityControl.setReport(report)` action if the composable needs that action. Add the action with a failing test before production code.

- [ ] **Step 4: Clear QC state on document switch**

Call `qualityControl.clear()` in:

- `handleTemplateSelect`
- `handleLocalImport`
- `clearDocument`
- close active tab path when current document is cleared

- [ ] **Step 5: Run focused tests and build**

Run:

```powershell
cd .\frontend
npm test -- useQualityControlSession.test.ts documentValidationService.test.ts documentSaveService.test.ts qcRuleEngine.test.ts qcAgentService.test.ts documentFactExtractor.test.ts
npm run build
```

Expected: PASS.

- [ ] **Step 6: Commit editor integration**

```powershell
git add frontend/src/components/editor/WorkbenchEditorArea.vue frontend/src/components/editor/EditorShell.vue frontend/src/components/editor/EditorStatusBar.vue frontend/src/composables/useQualityControlSession.ts frontend/src/composables/useQualityControlSession.test.ts
git commit -m "feat: integrate quality control into editor workflow"
```

## Task 9: Runtime Verification

**Files:**

- Modify only files needed for fixes discovered during verification.

- [ ] **Step 1: Run full frontend tests**

Run:

```powershell
cd .\frontend
npm test
```

Expected: all Vitest suites pass.

- [ ] **Step 2: Run frontend build**

Run:

```powershell
cd .\frontend
npm run build
```

Expected: build exits with code 0.

- [ ] **Step 3: Run backend build**

Run:

```powershell
dotnet build .\backend\backend.csproj
```

Expected: build exits with code 0.

- [ ] **Step 4: Manual browser smoke test**

Start backend and frontend:

```powershell
cd .\backend
dotnet run
```

```powershell
cd .\frontend
npm run dev
```

Verify in browser:

- Open a template.
- Click “运行质控”.
- Confirm the QC panel shows counts and issue cards.
- Trigger a required-field validation failure and confirm save is blocked.
- Confirm Agent semantic suggestions are non-blocking.
- Confirm existing save/download/print controls still work.

- [ ] **Step 5: Commit runtime fixes**

If runtime fixes are required:

```powershell
git status --short
git add frontend/src/components/editor/EditorShell.vue frontend/src/components/editor/WorkbenchEditorArea.vue frontend/src/components/editor/QualityControlPanel.vue frontend/src/components/editor/QualityControlSummaryBar.vue frontend/src/composables/useQualityControlSession.ts frontend/src/composables/useQualityControlSession.test.ts frontend/src/services/documentFactExtractor.ts frontend/src/services/documentFactExtractor.test.ts frontend/src/services/qcRuleEngine.ts frontend/src/services/qcRuleEngine.test.ts frontend/src/services/qcAgentService.ts frontend/src/services/qcAgentService.test.ts frontend/src/services/documentValidationService.ts frontend/src/services/documentValidationService.test.ts
git commit -m "fix: stabilize quality control runtime integration"
```

If no fixes are required, do not create an empty commit.

## Self-Review Checklist

- Spec coverage:
  - Rule-first deterministic QC: Tasks 2, 3, 4.
  - Agent semantic review: Task 5.
  - Explainable issue cards: Task 7.
  - Doctor actions ignore/resolved: Tasks 6, 7.
  - Save-before blocking: Tasks 4, 8.
  - Stale result protection: Task 6.
  - Vue component boundaries: Component Map and Tasks 7, 8.
  - Verification: Task 9.
- No placeholders:
  - Every task names exact files and commands.
  - Every implementation step includes concrete code or exact integration snippets.
- Type consistency:
  - `QualityControlIssue`, `QualityControlReport`, `DocumentFacts`, `QualityControlAgentProvider`, and `QualityControlRunInput` are defined before downstream tasks use them.
- Scope control:
  - No real HIS/EMR integration.
  - No real model provider.
  - No automatic medical edits.
  - Backend `/api/qc/*` remains deferred until frontend MVP is stable.
