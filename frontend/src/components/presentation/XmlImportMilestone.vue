<script setup lang="ts">
import { computed, shallowRef } from 'vue'
import { FileUp, RotateCcw, ZoomIn, ZoomOut } from 'lucide-vue-next'
import CanvasPreview from '../editor/CanvasPreview.vue'
import { useDocumentImport } from '../../composables/useDocumentImport'
import type { XmlImportStage } from '../../presentation/stageProfiles'

interface Props {
  stage: XmlImportStage
}

const props = defineProps<Props>()

const importState = useDocumentImport()
const zoom = shallowRef(0.9)
const rendererMode = shallowRef('preview')
const rendererError = shallowRef<string | null>(null)

const statusText = computed(() => {
  if (importState.isImporting.value) return '正在导入 XML'
  if (importState.error.value) return importState.error.value
  if (rendererError.value) return rendererError.value
  if (!importState.document.value) return '请选择本地 XML 文件'
  return rendererMode.value === 'external' ? '已进入外部渲染链路' : '已进入结构化预览链路'
})

const importedFileName = computed(() => importState.document.value?.fileName || '未导入 XML')

async function handleFileChange(event: Event) {
  const input = event.target as HTMLInputElement
  const file = input.files?.[0]
  if (file) {
    rendererError.value = null
    await importState.importFile(file)
  }
  input.value = ''
}

function zoomIn() {
  zoom.value = Math.min(1.4, Math.round((zoom.value + 0.1) * 10) / 10)
}

function zoomOut() {
  zoom.value = Math.max(0.6, Math.round((zoom.value - 0.1) * 10) / 10)
}

function resetZoom() {
  zoom.value = 0.9
}
</script>

<template>
  <main class="import-stage">
    <aside class="import-stage__sidebar" aria-label="XML 导入闭环说明">
      <header class="import-stage__header">
        <span class="import-stage__month">{{ props.stage.reportMonth }}</span>
        <h1>{{ props.stage.label }}</h1>
        <p>{{ props.stage.reportGoal }}</p>
      </header>

      <label class="import-card" for="xml-import-input">
        <FileUp :size="20" aria-hidden="true" />
        <span class="import-card__title">导入 XML</span>
        <span class="import-card__text">选择本地 XML 后立即进入渲染链路。</span>
        <input
          id="xml-import-input"
          class="import-card__input"
          type="file"
          accept=".xml,text/xml,application/xml"
          :disabled="importState.isImporting.value"
          @change="handleFileChange"
        />
      </label>

      <section class="import-stage__section" aria-label="验收口径">
        <h2>验收口径</h2>
        <ul>
          <li v-for="item in props.stage.acceptance" :key="item">{{ item }}</li>
        </ul>
      </section>

      <section class="import-stage__section" aria-label="已知边界">
        <h2>已知边界</h2>
        <ul>
          <li v-for="item in props.stage.knownLimitations" :key="item">{{ item }}</li>
        </ul>
      </section>
    </aside>

    <section class="import-stage__preview" aria-label="XML 导入渲染展示">
      <header class="import-stage__toolbar">
        <div class="import-stage__status">
          <strong>{{ importedFileName }}</strong>
          <span>{{ statusText }}</span>
        </div>
        <div class="import-stage__actions" aria-label="缩放控制">
          <button type="button" title="缩小" @click="zoomOut">
            <ZoomOut :size="16" aria-hidden="true" />
          </button>
          <span>{{ Math.round(zoom * 100) }}%</span>
          <button type="button" title="重置缩放" @click="resetZoom">
            <RotateCcw :size="16" aria-hidden="true" />
          </button>
          <button type="button" title="放大" @click="zoomIn">
            <ZoomIn :size="16" aria-hidden="true" />
          </button>
        </div>
      </header>

      <CanvasPreview
        :document="importState.document.value"
        :zoom="zoom"
        @mode-change="rendererMode = $event"
        @render-error="rendererError = $event"
      />
    </section>
  </main>
</template>

<style scoped>
.import-stage {
  display: grid;
  width: 100%;
  height: 100%;
  min-width: 0;
  min-height: 0;
  grid-template-columns: 340px minmax(0, 1fr);
  background: #eef2f6;
  color: #1f2937;
  font-family: "Microsoft YaHei UI", "Segoe UI", Arial, sans-serif;
}

.import-stage__sidebar {
  display: grid;
  min-width: 0;
  min-height: 0;
  align-content: start;
  gap: 14px;
  overflow: auto;
  padding: 18px;
  border-right: 1px solid #c7d2dc;
  background: #f8fafc;
}

.import-stage__header {
  display: grid;
  gap: 8px;
}

.import-stage__month {
  color: #166269;
  font-size: 12px;
  font-weight: 700;
}

.import-stage__header h1 {
  margin: 0;
  color: #172033;
  font-size: 20px;
  line-height: 1.3;
}

.import-stage__header p {
  margin: 0;
  color: #536171;
  font-size: 13px;
  line-height: 1.55;
}

.import-card {
  display: grid;
  gap: 8px;
  min-width: 0;
  padding: 14px;
  border: 1px solid #2e7784;
  border-radius: 6px;
  background: #e8f4f3;
  color: #163b46;
  cursor: pointer;
}

.import-card:hover {
  background: #dcf0ee;
}

.import-card__title {
  font-size: 15px;
  font-weight: 700;
}

.import-card__text {
  color: #49616a;
  font-size: 12px;
  line-height: 1.45;
}

.import-card__input {
  width: 100%;
  min-width: 0;
  color: #334155;
  font-size: 12px;
}

.import-stage__section {
  display: grid;
  gap: 8px;
}

.import-stage__section h2 {
  margin: 0;
  color: #344256;
  font-size: 13px;
}

.import-stage__section ul {
  display: grid;
  gap: 6px;
  margin: 0;
  padding: 10px 10px 10px 26px;
  border-left: 3px solid #2e7784;
  background: #ffffff;
  color: #667085;
  font-size: 12px;
  line-height: 1.45;
}

.import-stage__preview {
  display: grid;
  min-width: 0;
  min-height: 0;
  grid-template-rows: 48px minmax(0, 1fr);
}

.import-stage__toolbar {
  display: flex;
  min-width: 0;
  align-items: center;
  justify-content: space-between;
  gap: 12px;
  padding: 8px 12px;
  border-bottom: 1px solid #cfd9e3;
  background: #ffffff;
}

.import-stage__status {
  display: grid;
  min-width: 0;
  gap: 2px;
}

.import-stage__status strong,
.import-stage__status span {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.import-stage__status strong {
  color: #1e293b;
  font-size: 13px;
}

.import-stage__status span {
  color: #667085;
  font-size: 12px;
}

.import-stage__actions {
  display: flex;
  flex: 0 0 auto;
  align-items: center;
  gap: 6px;
}

.import-stage__actions button {
  display: inline-flex;
  width: 30px;
  height: 30px;
  align-items: center;
  justify-content: center;
  border: 1px solid #c5d1dc;
  border-radius: 5px;
  background: #f8fafc;
  color: #334155;
}

.import-stage__actions button:hover {
  border-color: #7ca6c0;
  background: #e9f3f7;
}

.import-stage__actions span {
  min-width: 42px;
  color: #475467;
  font-size: 12px;
  text-align: center;
}

@media (max-width: 860px) {
  .import-stage {
    grid-template-columns: minmax(0, 1fr);
    grid-template-rows: auto minmax(0, 1fr);
  }

  .import-stage__sidebar {
    max-height: 42vh;
    border-right: 0;
    border-bottom: 1px solid #c7d2dc;
  }
}
</style>
