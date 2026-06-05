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

const filters: { id: FilterId; label: string }[] = [
  { id: 'all', label: '全部' },
  { id: 'blocking', label: '阻断' },
  { id: 'suggestion', label: '建议' },
  { id: 'ignored', label: '已忽略' },
]

const visibleIssues = computed(() => {
  const issues = props.report?.issues || []
  if (activeFilter.value === 'blocking') return issues.filter(issue => issue.blocking)
  if (activeFilter.value === 'suggestion') return issues.filter(issue => !issue.blocking)
  if (activeFilter.value === 'ignored') return issues.filter(issue => issue.status === 'ignored')
  return issues
})
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
      <span class="quality-panel__issue-source">{{ issue.source === 'agent' ? 'Agent' : '规则' }}</span>
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
  overflow: auto;
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

.quality-panel__run:disabled {
  cursor: not-allowed;
  opacity: 0.65;
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

.quality-panel__issue--critical,
.quality-panel__issue--error {
  background: rgba(255, 244, 230, 0.7);
}

.quality-panel__badge {
  color: #9a3412;
  font-weight: 700;
}

.quality-panel__issue-title {
  min-width: 0;
  overflow: hidden;
  font-weight: 700;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.quality-panel__issue-source {
  color: #695d42;
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
