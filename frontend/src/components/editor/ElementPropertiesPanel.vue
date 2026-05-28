<script setup lang="ts">
import { computed } from 'vue'
import type {
  EditorElementProperties,
  EditorElementType,
  ElementPropertyUpdateResult,
} from '../../types/editorElement'
import {
  createElementPropertyPatch,
  getElementPropertySchema,
  type ElementPropertyField,
} from './elementPropertySchema'

interface Props {
  element: EditorElementProperties
  status: ElementPropertyUpdateResult
}

interface Emits {
  refresh: []
  selectType: [type: EditorElementType]
  update: [patch: Partial<EditorElementProperties>]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()
const schema = computed(() => getElementPropertySchema(props.element.type))

const typeOptions: Array<{ type: EditorElementType; label: string }> = [
  { type: 'input-field', label: '输入域' },
  { type: 'radio', label: '单选框' },
  { type: 'checkbox', label: '复选框' },
  { type: 'table', label: '表格' },
  { type: 'table-row', label: '表格行' },
  { type: 'table-cell', label: '单元格' },
  { type: 'barcode', label: '条码' },
  { type: 'qrcode', label: '二维码' },
]

function fieldTextValue(field: ElementPropertyField) {
  const value = props.element[field.key]
  return typeof value === 'number' || typeof value === 'string' ? value : ''
}

function fieldCheckedValue(field: ElementPropertyField) {
  return Boolean(props.element[field.key])
}

function updateField(field: ElementPropertyField, event: Event) {
  const target = event.target as HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
  const value = field.kind === 'checkbox'
    ? (target as HTMLInputElement).checked
    : target.value
  emit('update', createElementPropertyPatch(field, value))
}
</script>

<template>
  <section class="element-properties" aria-label="元素属性">
    <div class="element-properties__types" aria-label="元素类型">
      <button
        v-for="option in typeOptions"
        :key="option.type"
        class="element-properties__type"
        :class="{ 'element-properties__type--active': props.element.type === option.type }"
        type="button"
        @click="emit('selectType', option.type)"
      >
        {{ option.label }}
      </button>
    </div>

    <div class="element-properties__status" :class="`element-properties__status--${props.status.status}`">
      {{ props.status.message }}
    </div>

    <button class="element-properties__refresh" type="button" @click="emit('refresh')">
      读取当前选中元素
    </button>

    <form class="element-properties__form" @submit.prevent>
      <label
        v-for="field in schema"
        :key="field.key"
        class="element-properties__field"
        :class="{ 'element-properties__field--checkbox': field.kind === 'checkbox' }"
      >
        <span>{{ field.label }}</span>
        <input
          v-if="field.kind === 'checkbox'"
          type="checkbox"
          :checked="fieldCheckedValue(field)"
          @change="updateField(field, $event)"
        />
        <select
          v-else-if="field.kind === 'select'"
          :value="fieldTextValue(field)"
          @change="updateField(field, $event)"
        >
          <option value="">未设置</option>
          <option v-for="option in field.options || []" :key="option.value" :value="option.value">
            {{ option.label }}
          </option>
        </select>
        <textarea
          v-else-if="field.kind === 'textarea'"
          :value="fieldTextValue(field)"
          rows="3"
          @input="updateField(field, $event)"
        />
        <input
          v-else
          :type="field.kind === 'number' ? 'number' : 'text'"
          :value="fieldTextValue(field)"
          @input="updateField(field, $event)"
        />
      </label>
    </form>
  </section>
</template>

<style scoped>
.element-properties {
  display: grid;
  min-height: 0;
  grid-template-rows: auto auto auto minmax(0, 1fr);
  gap: 8px;
  overflow: auto;
  padding: 9px;
}

.element-properties__types {
  display: grid;
  grid-template-columns: repeat(2, minmax(0, 1fr));
  gap: 5px;
}

.element-properties__type,
.element-properties__refresh {
  min-height: 28px;
  border: 1px solid #c5d0db;
  border-radius: 4px;
  background: #fff;
  color: #40566d;
  font-size: 12px;
}

.element-properties__type--active {
  border-color: #7ca6c0;
  background: #e8f4fa;
  color: #1f4f73;
  font-weight: 700;
}

.element-properties__status {
  padding: 7px;
  border: 1px solid #d7e0e8;
  border-radius: 4px;
  background: #f7fafc;
  color: #4b5f73;
  font-size: 12px;
  line-height: 17px;
}

.element-properties__status--success {
  border-color: #9ac3a7;
  background: #eff8f1;
  color: #276738;
}

.element-properties__status--unsupported,
.element-properties__status--no-selection {
  border-color: #d7c27a;
  background: #fff8e3;
  color: #765d12;
}

.element-properties__status--failed {
  border-color: #dca1a1;
  background: #fff0f0;
  color: #9b1c1c;
}

.element-properties__refresh {
  width: 100%;
  color: #1f4f73;
}

.element-properties__form {
  display: grid;
  gap: 8px;
}

.element-properties__field {
  display: grid;
  gap: 4px;
  font-size: 12px;
}

.element-properties__field span,
.element-properties__option-list strong {
  color: #607084;
}

.element-properties__field input,
.element-properties__field select,
.element-properties__field textarea {
  min-width: 0;
  padding: 0 7px;
  border: 1px solid #c8d3de;
  border-radius: 4px;
  background: #fff;
  color: #26364a;
}

.element-properties__field input,
.element-properties__field select {
  height: 28px;
}

.element-properties__field textarea {
  min-height: 62px;
  padding-top: 6px;
  resize: vertical;
}

.element-properties__field--checkbox {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 10px;
}

.element-properties__field--checkbox input {
  width: 16px;
  height: 16px;
}
</style>
