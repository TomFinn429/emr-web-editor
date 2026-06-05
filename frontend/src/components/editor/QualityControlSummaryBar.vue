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

.quality-summary button:disabled {
  cursor: not-allowed;
  opacity: 0.65;
}
</style>
