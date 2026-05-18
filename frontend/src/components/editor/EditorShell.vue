<script setup lang="ts">
import { computed, onMounted, shallowRef } from 'vue'
import EditorStatusBar from './EditorStatusBar.vue'
import PropertyInspectorPanel from './PropertyInspectorPanel.vue'
import TemplateTreePanel from './TemplateTreePanel.vue'
import WorkbenchAssistPanel from './WorkbenchAssistPanel.vue'
import WorkbenchEditorArea from './WorkbenchEditorArea.vue'
import WorkbenchTopMenu from './WorkbenchTopMenu.vue'
import type { ExternalWriterElement } from '../../composables/useCanvasRenderer'
import { useDocumentImport } from '../../composables/useDocumentImport'
import { useDocumentSession } from '../../composables/useDocumentSession'
import { downloadXml, saveDocumentToBackend } from '../../services/documentSaveService'
import { fetchTemplateContent } from '../../services/templateService'
import {
  fetchTemplateWorkbenchData,
  type TemplateTreeNode,
  type TemplateWorkbenchData,
} from '../../services/templateWorkbenchService'
import type { EditorCommandId, ValidationIssue } from '../../types/document'
import { createWriterControlAdapter } from '../../utils/writerControlAdapter'
import type { WriterPrintResult } from '../../utils/writerPrint'
import { createWriterCommandPayload, findCommandDefinition } from './commandRegistry'
import { canReplaceCurrentDocument, toPreviewDocument } from './editorShellState'

const importState = useDocumentImport()
const session = useDocumentSession()

const zoom = shallowRef(1)
const rendererMode = shallowRef('preview')
const rendererError = shallowRef<string | null>(null)
const printMessage = shallowRef<string | null>(null)
const commandMessage = shallowRef<string | null>(null)
const writerElement = shallowRef<ExternalWriterElement | null>(null)
const isPrintPreviewing = shallowRef(false)
const templatesError = shallowRef<string | null>(null)
const isLoadingWorkbench = shallowRef(false)
const workbenchData = shallowRef<TemplateWorkbenchData | null>(null)
const workbenchError = shallowRef<string | null>(null)
const selectedTreeNodeId = shallowRef<string | undefined>()
let disposeContentChanged: (() => void) | null = null

const adapter = computed(() => createWriterControlAdapter(writerElement.value))
const previewDocument = computed(() => toPreviewDocument(session.document.value))
const canUseWriter = computed(() => writerElement.value !== null)
const canSaveFromWriter = computed(() => Boolean(session.document.value) && canUseWriter.value)
const statusRenderMode = computed(() => (rendererMode.value === 'external' ? '外部渲染' : '结构化预览'))
const workbenchTree = computed(() => workbenchData.value?.templateTree || [])
const workbenchCategories = computed(() => workbenchData.value?.categories || ['全部分类'])
const metadataItems = computed(() => workbenchData.value?.metadataItems || [])
const fragmentTemplates = computed(() => workbenchData.value?.fragmentTemplates || [])
const templateProperties = computed(() => workbenchData.value?.templateProperties || null)
const elementProperties = computed(() => workbenchData.value?.elementProperties || null)
const statusMessage = computed(() => {
  if (importState.isImporting.value) return '正在导入 XML'
  if (importState.error.value) return importState.error.value
  if (session.error.value) return session.error.value
  if (rendererError.value) return rendererError.value
  if (commandMessage.value) return commandMessage.value
  if (printMessage.value) return printMessage.value
  if (!session.document.value) return '请选择模板或导入 XML'
  return isPrintPreviewing.value ? '已进入打印预览' : '文档已加载'
})
const warningText = computed(() => session.document.value?.warnings.join('；') || '')

onMounted(() => {
  loadWorkbenchData()
})

async function loadWorkbenchData() {
  isLoadingWorkbench.value = true
  workbenchError.value = null

  try {
    workbenchData.value = await fetchTemplateWorkbenchData()
  } catch (error) {
    workbenchError.value = error instanceof Error ? error.message : '工作台数据加载失败。'
  } finally {
    isLoadingWorkbench.value = false
  }
}

function zoomIn() {
  zoom.value = Math.min(2, Math.round((zoom.value + 0.1) * 10) / 10)
}

function zoomOut() {
  zoom.value = Math.max(0.5, Math.round((zoom.value - 0.1) * 10) / 10)
}

function resetZoom() {
  zoom.value = 1
}

async function handleTemplateSelect(id: string, treeNodeId?: string) {
  if (!canReplaceCurrentDocument(session.isDirty.value, confirmDiscardChanges)) {
    return
  }

  rendererError.value = null
  printMessage.value = null
  commandMessage.value = null
  templatesError.value = null

  try {
    const template = await fetchTemplateContent(id)
    session.loadTemplate(template)
    selectedTreeNodeId.value = treeNodeId
  } catch (error) {
    const message = error instanceof Error ? error.message : '模板内容加载失败。'
    templatesError.value = message
    if (session.document.value) {
      session.markFailed(message)
    }
  }
}

async function handleTemplateTreeSelect(node: TemplateTreeNode) {
  if (!node.templateId) {
    return
  }

  await handleTemplateSelect(node.templateId, node.id)
}

async function handleLocalImport(file: File) {
  if (!canReplaceCurrentDocument(session.isDirty.value, confirmDiscardChanges)) {
    return
  }

  rendererError.value = null
  printMessage.value = null
  commandMessage.value = null
  templatesError.value = null
  await importState.importFile(file)
  if (importState.document.value) {
    session.loadLocalDocument(importState.document.value)
    selectedTreeNodeId.value = undefined
  } else if (importState.error.value) {
    session.markFailed(importState.error.value)
  }
}

function handleWorkbenchCommand(commandId: EditorCommandId) {
  const definition = findCommandDefinition(commandId)
  if (!definition || definition.kind === 'placeholder') {
    return
  }

  if (definition.kind === 'app') {
    runAppCommand(commandId)
    return
  }

  runEditorCommand(commandId)
}

function runAppCommand(commandId: EditorCommandId) {
  if (commandId === 'save') {
    void saveToBackend()
  } else if (commandId === 'downloadXml') {
    downloadCurrentXml()
  } else if (commandId === 'print') {
    printDocument()
  } else if (commandId === 'printPreview') {
    openPrintPreview()
  } else if (commandId === 'closePrintPreview') {
    closePrintPreview()
  } else if (commandId === 'clearDocument') {
    clear()
  } else if (commandId === 'zoomIn') {
    zoomIn()
  } else if (commandId === 'zoomOut') {
    zoomOut()
  } else if (commandId === 'resetZoom') {
    resetZoom()
  }
}

function runEditorCommand(commandId: EditorCommandId) {
  const payload = createWriterCommandPayload(commandId)
  if (!payload) {
    return
  }

  const result = adapter.value.executeCommand(payload)
  if (result.ok) {
    commandMessage.value = null
    session.markDirty()
    return
  }

  commandMessage.value = result.message
}

async function saveToBackend() {
  const document = session.document.value
  if (!document) {
    return
  }

  commandMessage.value = null
  session.markSaving(document.id)
  const result = await saveDocumentToBackend(adapter.value, {
    sessionId: document.id,
    fileName: document.fileName,
    source: document.source,
  })

  if (result.ok) {
    session.setValidationIssues([])
    commandMessage.value = null
    session.markSaved(result.xml, document.id)
  } else if (result.reason === 'validation-failed') {
    session.setValidationIssues(result.issues)
    session.markFailed('保存前校验未通过。', document.id)
  } else {
    session.markFailed(result.message, document.id)
  }
}

function downloadCurrentXml() {
  const document = session.document.value
  if (!document) {
    return
  }

  const result = adapter.value.saveXml()
  if (!result.ok) {
    session.markFailed(result.message, document.id)
    return
  }

  downloadXml(document.fileName, result.xml)
  commandMessage.value = null
}

function printDocument() {
  commandMessage.value = null
  applyPrintResult(adapter.value.print())
}

function openPrintPreview() {
  commandMessage.value = null
  const result = adapter.value.openPrintPreview()
  applyPrintResult(result)
  if (result.ok) {
    isPrintPreviewing.value = true
  }
}

function closePrintPreview() {
  commandMessage.value = null
  const result = adapter.value.closePrintPreview()
  applyPrintResult(result)
  if (result.ok) {
    isPrintPreviewing.value = false
  }
}

function updateWriterElement(element: ExternalWriterElement | null) {
  disposeContentChanged?.()
  disposeContentChanged = null
  writerElement.value = element
  isPrintPreviewing.value = false
  printMessage.value = null
  commandMessage.value = null
  if (element) {
    disposeContentChanged = createWriterControlAdapter(element).onContentChanged(() => {
      session.markDirty()
    })
  }
}

function applyPrintResult(result: WriterPrintResult) {
  printMessage.value = result.ok ? null : result.message
}

function clear() {
  if (!canReplaceCurrentDocument(session.isDirty.value, confirmDiscardChanges)) {
    return
  }

  session.clearDocument()
  importState.clearDocument()
  writerElement.value = null
  selectedTreeNodeId.value = undefined
  isPrintPreviewing.value = false
  printMessage.value = null
  commandMessage.value = null
  rendererError.value = null
}

function handleValidationIssue(issue: ValidationIssue) {
  session.markFailed(`暂时无法自动定位字段“${issue.fieldName}”：${issue.message}`)
}

function confirmDiscardChanges() {
  return window.confirm('当前文档有未保存修改，是否继续切换？')
}
</script>

<template>
  <div class="app-shell">
    <WorkbenchTopMenu
      :file-name="session.document.value?.fileName"
      :is-importing="importState.isImporting.value"
      :can-save="canSaveFromWriter"
      :can-print="Boolean(session.document.value)"
      :can-use-writer-print="canUseWriter"
      :can-use-writer-commands="canUseWriter"
      :is-saving="session.isSaving.value"
      :is-print-previewing="isPrintPreviewing"
      @import-file="handleLocalImport"
      @command="handleWorkbenchCommand"
    />

    <main class="app-shell__body">
      <TemplateTreePanel
        :nodes="workbenchTree"
        :categories="workbenchCategories"
        :selected-node-id="selectedTreeNodeId"
        :is-loading="isLoadingWorkbench"
        :error="workbenchError || templatesError"
        @select-template="handleTemplateTreeSelect"
      />

      <section class="app-shell__middle">
        <WorkbenchAssistPanel
          :metadata-items="metadataItems"
          :fragment-templates="fragmentTemplates"
        />
        <WorkbenchEditorArea
          :document="previewDocument"
          :file-name="session.document.value?.fileName"
          :status-message="statusMessage"
          :warning-text="warningText"
          :zoom="zoom"
          :validation-issues="session.validationIssues.value"
          @mode-change="rendererMode = $event"
          @render-error="rendererError = $event"
          @writer-ready="updateWriterElement"
          @select-issue="handleValidationIssue"
        />
      </section>

      <PropertyInspectorPanel
        :template-properties="templateProperties"
        :element-properties="elementProperties"
      />
    </main>

    <EditorStatusBar
      :file-name="session.document.value?.fileName"
      :save-state="session.saveState.value"
      :render-mode="statusRenderMode"
      :zoom="zoom"
      :validation-count="session.validationIssues.value.length"
      :is-print-previewing="isPrintPreviewing"
    />
  </div>
</template>

<style scoped>
.app-shell {
  display: grid;
  width: 100%;
  height: 100%;
  min-width: 0;
  min-height: 0;
  grid-template-rows: auto minmax(0, 1fr) auto;
  background: #eef2f6;
  color: #1f2937;
  font-family: "Microsoft YaHei UI", "Segoe UI", Arial, sans-serif;
}

.app-shell__body {
  display: grid;
  min-width: 0;
  min-height: 0;
  grid-template-columns: 244px minmax(0, 1fr) 318px;
}

.app-shell__middle {
  display: grid;
  min-width: 0;
  min-height: 0;
  grid-template-columns: 182px minmax(0, 1fr);
}

@media (max-width: 860px) {
  .app-shell__body {
    grid-template-columns: minmax(0, 1fr);
  }

  .app-shell__body :deep(.template-tree),
  .app-shell__body :deep(.assist-panel),
  .app-shell__body :deep(.property-panel) {
    display: none;
  }
}
</style>
