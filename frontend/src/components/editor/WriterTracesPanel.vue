<script setup lang="ts">
import { computed, shallowRef } from 'vue'
import {
  Eye,
  FileClock,
  LocateFixed,
  LogIn,
  RefreshCw,
  Sparkles,
} from 'lucide-vue-next'
import { formatTraceList, type TraceIdentityOption } from '../../services/writerTraceService'
import type {
  WriterTraceInfo,
  WriterTraceUser,
  WriterTraceViewMode,
} from '../../utils/writerControlAdapter'

interface Props {
  traces: readonly WriterTraceInfo[]
  viewMode: WriterTraceViewMode | null
  currentUser: WriterTraceUser | null
  identityOptions: readonly TraceIdentityOption[]
  activeTraceKey?: string | null
  canUseTraces: boolean
  errorMessage?: string | null
}

interface Emits {
  loginTraceUser: []
  refreshTraces: []
  viewModeChange: [mode: WriterTraceViewMode]
  traceIdentityChange: [identityId: string]
  selectTrace: [trace: WriterTraceInfo]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()

const formattedTraces = computed(() => formatTraceList(props.traces))
const traceCountText = computed(() => String(props.traces.length))
type TraceActionFilter = 'all' | 'insert' | 'delete'

const selectedActionFilter = shallowRef<TraceActionFilter>('all')
const visibleTraces = computed(() => {
  if (selectedActionFilter.value === 'insert') {
    return formattedTraces.value.filter(trace => trace.actionKind === 'insert')
  }

  if (selectedActionFilter.value === 'delete') {
    return formattedTraces.value.filter(trace => trace.actionKind === 'delete')
  }

  return formattedTraces.value
})
const activeTrace = computed(() =>
  formattedTraces.value.find(trace => trace.key === props.activeTraceKey) ?? null,
)
const activeAuthorName = computed(() => activeTrace.value?.userName ?? '')
const authorLegendItems = computed(() => {
  const seen = new Set<string>()
  return formattedTraces.value.filter((trace) => {
    if (seen.has(trace.userName)) {
      return false
    }
    seen.add(trace.userName)
    return true
  })
})
const activeUserName = computed(() => props.currentUser?.Name || '未登录')
const matchedIdentity = computed(() => {
  if (!props.currentUser) {
    return null
  }

  return props.identityOptions.find(option => option.ID === props.currentUser?.ID)
    ?? props.identityOptions.find(option => option.Name === props.currentUser?.Name)
    ?? null
})
const activeUserId = computed(() => matchedIdentity.value?.ID || props.currentUser?.ID || '')
const shouldShowFallbackUser = computed(() => Boolean(
  props.currentUser
  && activeUserId.value
  && !matchedIdentity.value,
))

const viewModeOptions: Array<{
  value: WriterTraceViewMode
  label: string
  title: string
}> = [
  { value: 'complex', label: '留痕', title: '切换到留痕视图' },
  { value: 'clean', label: '清洁', title: '切换到清洁视图' },
]

const actionFilterOptions: Array<{ value: TraceActionFilter; label: string }> = [
  { value: 'all', label: '全部动作' },
  { value: 'insert', label: '只看新增' },
  { value: 'delete', label: '只看删除' },
]

function getTraceItemStyle(trace: { userColor: string }) {
  return {
    borderLeftColor: trace.userColor,
  }
}

function getAuthorSwatchStyle(trace: { userColor: string }) {
  return {
    backgroundColor: trace.userColor,
  }
}

function isSameAuthorAsActiveTrace(trace: { userName: string; key: string }) {
  return Boolean(
    activeAuthorName.value
    && trace.userName === activeAuthorName.value
    && trace.key !== props.activeTraceKey,
  )
}

function handleTraceIdentityChange(event: Event) {
  emit('traceIdentityChange', (event.target as HTMLSelectElement).value)
}

function setActionFilter(filter: TraceActionFilter) {
  selectedActionFilter.value = filter
}
</script>

<template>
  <section class="writer-traces" aria-label="修改留痕">
    <div class="writer-traces__header">
      <div class="writer-traces__title">
        <FileClock :size="16" aria-hidden="true" />
        <span>修改留痕</span>
        <strong>{{ traceCountText }}</strong>
      </div>

      <div class="writer-traces__tools">
        <select
          class="writer-traces__identity"
          title="切换编辑身份"
          :value="activeUserId"
          :disabled="!props.canUseTraces || props.identityOptions.length === 0"
          @change="handleTraceIdentityChange"
        >
          <option v-if="shouldShowFallbackUser" :value="activeUserId">
            {{ activeUserName }}
          </option>
          <option
            v-for="identity in props.identityOptions"
            :key="identity.ID"
            :value="identity.ID"
          >
            {{ identity.label }}
          </option>
        </select>
        <button
          class="writer-traces__icon-button"
          type="button"
          title="登录留痕用户"
          :disabled="!props.canUseTraces"
          @click="emit('loginTraceUser')"
        >
          <LogIn :size="14" aria-hidden="true" />
        </button>
        <button
          class="writer-traces__icon-button"
          type="button"
          title="刷新留痕"
          :disabled="!props.canUseTraces"
          @click="emit('refreshTraces')"
        >
          <RefreshCw :size="14" aria-hidden="true" />
        </button>
      </div>
    </div>

    <div class="writer-traces__mode" role="group" aria-label="留痕视图方式">
      <button
        v-for="option in viewModeOptions"
        :key="option.value"
        class="writer-traces__mode-button"
        :class="{ 'writer-traces__mode-button--active': option.value === props.viewMode }"
        type="button"
        :title="option.title"
        :disabled="!props.canUseTraces"
        @click="emit('viewModeChange', option.value)"
      >
        <Eye v-if="option.value === 'complex'" :size="13" aria-hidden="true" />
        <Sparkles v-else :size="13" aria-hidden="true" />
        <span>{{ option.label }}</span>
      </button>
    </div>

    <div v-if="formattedTraces.length > 0" class="writer-traces__review-tools">
      <div class="writer-traces__legend" aria-label="作者图例">
        <span class="writer-traces__legend-title">作者图例</span>
        <span class="writer-traces__legend-hint">颜色代表身份</span>
        <span
          v-for="trace in authorLegendItems"
          :key="trace.userName"
          class="writer-traces__legend-item"
          :title="`${trace.userName}作者色`"
        >
          <span class="writer-traces__legend-dot" :style="getAuthorSwatchStyle(trace)" />
          <span>{{ trace.userName }}</span>
        </span>
      </div>
      <div class="writer-traces__filters" role="group" aria-label="留痕动作过滤">
        <button
          v-for="filter in actionFilterOptions"
          :key="filter.value"
          class="writer-traces__filter-button"
          :class="{ 'writer-traces__filter-button--active': filter.value === selectedActionFilter }"
          type="button"
          :disabled="!props.canUseTraces"
          @click="setActionFilter(filter.value)"
        >
          {{ filter.label }}
        </button>
      </div>
    </div>

    <p v-if="props.errorMessage" class="writer-traces__error">{{ props.errorMessage }}</p>

    <div v-if="activeTrace" class="writer-traces__active">
      <span class="writer-traces__active-label">
        <span class="writer-traces__active-dot" :style="getAuthorSwatchStyle(activeTrace)" />
        当前选中
      </span>
      <strong>{{ activeTrace.reviewTitle }}</strong>
      <small v-if="activeTrace.timeText">{{ activeTrace.timeText }}</small>
      <p>{{ activeTrace.fullText || activeTrace.summary }}</p>
    </div>

    <div v-if="visibleTraces.length > 0" class="writer-traces__list">
      <button
        v-for="trace in visibleTraces"
        :key="trace.key"
        class="writer-traces__item"
        :class="{
          'writer-traces__item--active': trace.key === props.activeTraceKey,
          'writer-traces__item--same-author': isSameAuthorAsActiveTrace(trace),
          'writer-traces__item--insert': trace.actionKind === 'insert',
          'writer-traces__item--delete': trace.actionKind === 'delete',
        }"
        :style="getTraceItemStyle(trace)"
        type="button"
        :title="trace.reviewTitle"
        :disabled="!props.canUseTraces || trace.nativeHandle === null"
        @click="emit('selectTrace', trace.trace)"
      >
        <div class="writer-traces__item-meta">
          <span class="writer-traces__author">
            <span class="writer-traces__legend-dot" :style="getAuthorSwatchStyle(trace)" />
            <span>{{ trace.userName }}</span>
          </span>
          <small v-if="trace.timeText">{{ trace.timeText }}</small>
        </div>
        <div class="writer-traces__item-body">
          <span
            class="writer-traces__item-type"
            :class="`writer-traces__item-type--${trace.actionTone}`"
          >
            {{ trace.actionSymbol }} {{ trace.typeLabel }}
          </span>
          <p>{{ trace.summary }}</p>
          <LocateFixed :size="13" aria-hidden="true" />
        </div>
      </button>
    </div>

    <p v-else class="writer-traces__empty">暂无留痕</p>
  </section>
</template>

<style scoped>
.writer-traces {
  display: grid;
  max-height: 262px;
  min-height: 0;
  grid-template-rows: 34px 32px auto auto auto minmax(0, 1fr);
  border-top: 1px solid #b9c8d6;
  background: #f8fbfd;
  color: #263648;
}

.writer-traces__header {
  display: flex;
  min-width: 0;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
  padding: 0 10px 0 12px;
  border-bottom: 1px solid #d7e1ea;
}

.writer-traces__title {
  display: inline-flex;
  min-width: 0;
  align-items: center;
  gap: 7px;
  font-size: 13px;
  font-weight: 700;
}

.writer-traces__title strong {
  display: inline-flex;
  min-width: 22px;
  height: 20px;
  align-items: center;
  justify-content: center;
  border-radius: 8px;
  background: #dfe8f1;
  color: #1f4f73;
  font-size: 12px;
}

.writer-traces__tools {
  display: inline-flex;
  min-width: 0;
  flex: 0 0 auto;
  align-items: center;
  gap: 4px;
}

.writer-traces__identity {
  max-width: 126px;
  height: 24px;
  min-width: 0;
  overflow: hidden;
  border: 1px solid #bfd0df;
  border-radius: 5px;
  background: #ffffff;
  color: #5b6d80;
  font-size: 12px;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.writer-traces__identity:disabled {
  background: #eef3f7;
  color: #9aaabd;
  cursor: not-allowed;
}

.writer-traces__icon-button {
  display: inline-flex;
  width: 24px;
  height: 24px;
  align-items: center;
  justify-content: center;
  border: 1px solid transparent;
  border-radius: 5px;
  background: transparent;
  color: #40566d;
}

.writer-traces__icon-button:hover:not(:disabled) {
  border-color: #b8c8d8;
  background: #e9f1f8;
}

.writer-traces__icon-button:disabled {
  color: #9aaabd;
  cursor: not-allowed;
}

.writer-traces__mode {
  display: grid;
  min-width: 0;
  grid-template-columns: repeat(2, minmax(0, 1fr));
  gap: 4px;
  padding: 5px 10px;
  border-bottom: 1px solid #d7e1ea;
}

.writer-traces__mode-button {
  display: inline-flex;
  min-width: 0;
  height: 22px;
  align-items: center;
  justify-content: center;
  gap: 4px;
  overflow: hidden;
  border: 1px solid #bfd0df;
  border-radius: 5px;
  background: #ffffff;
  color: #40566d;
  font-size: 12px;
  white-space: nowrap;
}

.writer-traces__mode-button:hover:not(:disabled),
.writer-traces__mode-button--active {
  border-color: #2f7d8d;
  background: #eaf7f9;
  color: #155e6d;
}

.writer-traces__mode-button:disabled {
  color: #9aaabd;
  cursor: not-allowed;
}

.writer-traces__error {
  margin: 0;
  padding: 6px 12px;
  border-bottom: 1px solid #f0c36d;
  background: #fff8e6;
  color: #9a3412;
  font-size: 12px;
  line-height: 18px;
}

.writer-traces__review-tools {
  display: grid;
  min-width: 0;
  gap: 4px;
  padding: 5px 10px;
  border-bottom: 1px solid #d7e1ea;
  background: #f2f7fb;
}

.writer-traces__legend,
.writer-traces__filters {
  display: flex;
  min-width: 0;
  align-items: center;
  gap: 6px;
  overflow: hidden;
}

.writer-traces__legend-title {
  flex: 0 0 auto;
  color: #52677d;
  font-size: 11px;
  font-weight: 700;
}

.writer-traces__legend-hint {
  flex: 0 0 auto;
  color: #6b7f93;
  font-size: 11px;
}

.writer-traces__legend-item,
.writer-traces__author {
  display: inline-flex;
  min-width: 0;
  align-items: center;
  gap: 4px;
}

.writer-traces__legend-item {
  max-width: 120px;
  color: #40566d;
  font-size: 11px;
  white-space: nowrap;
}

.writer-traces__legend-item span:last-child,
.writer-traces__author span:last-child {
  min-width: 0;
  overflow: hidden;
  text-overflow: ellipsis;
}

.writer-traces__legend-dot {
  width: 8px;
  height: 8px;
  flex: 0 0 auto;
  border-radius: 50%;
}

.writer-traces__filter-button {
  height: 20px;
  padding: 0 7px;
  border: 1px solid #c5d5e2;
  border-radius: 5px;
  background: #ffffff;
  color: #40566d;
  font-size: 11px;
}

.writer-traces__filter-button--active,
.writer-traces__filter-button:hover:not(:disabled) {
  border-color: #2f7d8d;
  background: #eaf7f9;
  color: #155e6d;
}

.writer-traces__active {
  display: grid;
  grid-template-columns: auto minmax(0, 1fr) auto;
  gap: 5px 8px;
  padding: 6px 10px;
  border-bottom: 1px solid #c8d5e0;
  background: #fffdf4;
  color: #314256;
  font-size: 12px;
}

.writer-traces__active-label {
  display: inline-flex;
  min-width: 0;
  align-items: center;
  gap: 5px;
  color: #8a5a00;
  font-weight: 700;
}

.writer-traces__active-dot {
  width: 9px;
  height: 9px;
  flex: 0 0 auto;
  border-radius: 50%;
}

.writer-traces__active strong,
.writer-traces__active small {
  min-width: 0;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.writer-traces__active p {
  grid-column: 1 / -1;
  margin: 0;
  overflow: hidden;
  color: #4a5b6f;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.writer-traces__list {
  min-height: 0;
  overflow: auto;
  padding: 8px 10px 10px;
}

.writer-traces__item {
  display: grid;
  width: 100%;
  gap: 5px;
  padding: 8px 9px;
  border: 1px solid #c8d5e0;
  border-left: 4px solid #2f7d8d;
  border-radius: 7px;
  background: #ffffff;
  color: inherit;
  text-align: left;
}

.writer-traces__item--active {
  border-color: #8a6d1d;
  background: #fffaf0;
}

.writer-traces__item--same-author {
  background: #f6fbff;
  box-shadow: inset 0 0 0 1px rgba(47, 125, 141, 0.18);
}

.writer-traces__item + .writer-traces__item {
  margin-top: 6px;
}

.writer-traces__item:hover:not(:disabled) {
  border-color: #7fb2bd;
  background: #f0fbfd;
}

.writer-traces__item:disabled {
  cursor: not-allowed;
  opacity: 0.72;
}

.writer-traces__item-meta {
  display: flex;
  min-width: 0;
  align-items: center;
  gap: 8px;
  color: #2e4054;
  font-size: 12px;
  font-weight: 700;
}

.writer-traces__item-meta small {
  min-width: 0;
  overflow: hidden;
  color: #718399;
  font-size: 11px;
  font-weight: 400;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.writer-traces__item-body {
  display: grid;
  min-width: 0;
  grid-template-columns: auto minmax(0, 1fr) auto;
  align-items: center;
  gap: 6px;
}

.writer-traces__item-type {
  display: inline-flex;
  max-width: 72px;
  min-height: 20px;
  align-items: center;
  padding: 0 6px;
  border-radius: 5px;
  background: #dff3f5;
  color: #155e6d;
  font-size: 12px;
  font-weight: 700;
  white-space: nowrap;
}

.writer-traces__item-type--insert {
  background: #e0f3e8;
  color: #1f6b4a;
}

.writer-traces__item-type--delete {
  background: #fde7e7;
  color: #a33838;
}

.writer-traces__item--insert .writer-traces__item-body p {
  color: #1f6b4a;
  text-decoration: underline;
  text-decoration-thickness: 1px;
  text-underline-offset: 3px;
}

.writer-traces__item--delete .writer-traces__item-body p {
  color: #8f2e2e;
  text-decoration: line-through;
  text-decoration-thickness: 1px;
}

.writer-traces__item-body p {
  min-width: 0;
  margin: 0;
  overflow: hidden;
  color: #314256;
  font-size: 12px;
  line-height: 18px;
  overflow-wrap: anywhere;
  white-space: nowrap;
  text-overflow: ellipsis;
}

.writer-traces__empty {
  margin: 0;
  padding: 14px 12px;
  color: #6b7f93;
  font-size: 12px;
}
</style>
