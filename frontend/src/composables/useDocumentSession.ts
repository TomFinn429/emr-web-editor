import { computed, readonly, shallowRef } from 'vue'
import type {
  EditorDocument,
  ImportedDocument,
  SaveState,
  TemplateContent,
  ValidationIssue,
} from '../types/document'

export function useDocumentSession() {
  const document = shallowRef<EditorDocument | null>(null)
  const saveState = shallowRef<SaveState>('idle')
  const lastSavedXml = shallowRef('')
  const validationIssues = shallowRef<ValidationIssue[]>([])
  const error = shallowRef<string | null>(null)
  const isLoading = shallowRef(false)
  const isSaving = shallowRef(false)

  const isDirty = computed(() => saveState.value === 'dirty')

  function loadTemplate(template: TemplateContent) {
    document.value = {
      id: template.id,
      fileName: template.fileName,
      xml: template.xml,
      warnings: [],
      source: 'template',
      templateId: template.id,
    }
    lastSavedXml.value = template.xml
    validationIssues.value = []
    error.value = null
    isLoading.value = false
    isSaving.value = false
    saveState.value = 'saved'
  }

  function loadLocalDocument(imported: ImportedDocument) {
    document.value = {
      id: imported.id,
      fileName: imported.fileName,
      xml: imported.xml,
      warnings: [...imported.warnings],
      source: 'local',
    }
    lastSavedXml.value = imported.xml
    validationIssues.value = []
    error.value = null
    isLoading.value = false
    isSaving.value = false
    saveState.value = 'saved'
  }

  function markDirty() {
    if (document.value) {
      saveState.value = 'dirty'
    }
  }

  function markSaving(documentId?: string) {
    if (!isCurrentDocument(documentId)) {
      return
    }

    isSaving.value = true
    error.value = null
    saveState.value = 'saving'
  }

  function markSaved(xml: string, documentId?: string) {
    if (!isCurrentDocument(documentId)) {
      return
    }

    isSaving.value = false
    lastSavedXml.value = xml
    error.value = null
    saveState.value = 'saved'
  }

  function markFailed(message: string, documentId?: string) {
    if (!isCurrentDocument(documentId)) {
      return
    }

    isSaving.value = false
    error.value = message
    saveState.value = 'failed'
  }

  function setValidationIssues(issues: readonly ValidationIssue[]) {
    validationIssues.value = [...issues]
  }

  function clearDocument() {
    document.value = null
    lastSavedXml.value = ''
    validationIssues.value = []
    error.value = null
    isSaving.value = false
    isLoading.value = false
    saveState.value = 'idle'
  }

  return {
    document: readonly(document),
    saveState: readonly(saveState),
    lastSavedXml: readonly(lastSavedXml),
    validationIssues: readonly(validationIssues),
    error: readonly(error),
    isLoading: readonly(isLoading),
    isSaving: readonly(isSaving),
    isDirty,
    loadTemplate,
    loadLocalDocument,
    markDirty,
    markSaving,
    markSaved,
    markFailed,
    setValidationIssues,
    clearDocument,
  }

  function isCurrentDocument(documentId?: string) {
    if (!document.value) {
      return false
    }

    return !documentId || document.value.id === documentId
  }
}
