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
  evidence: readonly EvidenceSnippet[]
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
  issues: readonly QualityControlIssue[]
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
