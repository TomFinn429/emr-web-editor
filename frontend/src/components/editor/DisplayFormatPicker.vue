<script setup lang="ts">
import { computed, useTemplateRef } from 'vue'
import { ElButton, ElCascader } from 'element-plus'
import type { CascaderOption } from 'element-plus'
import 'element-plus/es/components/button/style/css'
import 'element-plus/es/components/cascader/style/css'
import { Edit3 } from 'lucide-vue-next'
import type { ElementPropertyOption } from './elementPropertySchema'

interface Props {
  value: string
  options: ElementPropertyOption[]
  disabled?: boolean
}

interface Emits {
  update: [value: string]
}

interface CascaderExpose {
  togglePopperVisible?: (visible?: boolean) => void
  focus?: () => void
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()
const cascaderRef = useTemplateRef<CascaderExpose>('cascader')

const cascaderProps = {
  emitPath: true,
  checkStrictly: true,
}

const cascaderOptions = computed(() => props.options as unknown as CascaderOption[])
const selectedPath = computed(() => resolveDisplayFormatPath(props.value, props.options))

function updatePath(value: unknown) {
  if (props.disabled) return
  const path = Array.isArray(value) ? value.map(String).filter(Boolean) : []
  emit('update', path.length > 1 ? path[1] : path[0] || '')
}

function openPicker() {
  if (props.disabled) return
  cascaderRef.value?.togglePopperVisible?.(true)
  cascaderRef.value?.focus?.()
}

function resolveDisplayFormatPath(value: string, options: ElementPropertyOption[]) {
  const trimmed = value.trim()
  if (!trimmed) return []

  if (trimmed.includes('/')) {
    return trimmed.split('/').map(item => item.trim()).filter(Boolean)
  }

  for (const option of options) {
    if (option.value === trimmed) return [option.value]
    const child = option.children?.find(item => item.value === trimmed)
    if (child) return [option.value, child.value]
  }

  return [trimmed]
}
</script>

<template>
  <span class="display-format-picker">
    <ElCascader
      ref="cascader"
      class="display-format-picker__cascader"
      :model-value="selectedPath"
      :options="cascaderOptions"
      :props="cascaderProps"
      :show-all-levels="false"
      placeholder="输出格式"
      clearable
      :disabled="props.disabled"
      @update:model-value="updatePath"
    />
    <ElButton class="display-format-picker__button" title="编辑输出格式" :disabled="props.disabled" @click="openPicker">
      <Edit3 :size="13" aria-hidden="true" />
    </ElButton>
  </span>
</template>

<style scoped>
.display-format-picker {
  display: flex;
  width: 100%;
  min-width: 0;
  align-items: center;
}

.display-format-picker__cascader {
  min-width: 0;
  flex: 1;
}

.display-format-picker__cascader :deep(.el-input__wrapper) {
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
  box-shadow: 0 0 0 1px #c8d3de inset;
}

.display-format-picker__button {
  width: 34px;
  height: 28px;
  border: 1px solid #c8d3de;
  border-left: 0;
  border-radius: 0 4px 4px 0;
  background: #f7fafc;
  color: #697586;
}
</style>
