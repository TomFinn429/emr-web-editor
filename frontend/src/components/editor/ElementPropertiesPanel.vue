<script setup lang="ts">
import { computed, shallowRef } from 'vue'
import { ElOption, ElSelect } from 'element-plus'
import 'element-plus/es/components/select/style/css'
import 'element-plus/es/components/option/style/css'
import { Edit3, RefreshCw } from 'lucide-vue-next'
import type {
  EditorElementProperties,
  EditorElementType,
  ElementPropertyUpdateResult,
} from '../../types/editorElement'
import {
  createElementPropertyPatch,
  getElementPropertyMultiSelectValues,
  getVisibleElementPropertyGroups,
  summarizeStaticListItems,
  type ElementPropertyField,
} from './elementPropertySchema'
import DisplayFormatPicker from './DisplayFormatPicker.vue'
import ListItemsEditorDialog from './ListItemsEditorDialog.vue'

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
const groups = computed(() => getVisibleElementPropertyGroups(props.element.type, props.element))
const editingListItemsField = shallowRef<ElementPropertyField | null>(null)
const editingListItemsValue = computed(() => editingListItemsField.value
  ? fieldTextValue(editingListItemsField.value)
  : '')

const referenceTypeOptions: Array<{ type: EditorElementType; label: string }> = [
  { type: 'input-field', label: '输入域' },
  { type: 'table-cell', label: '单元格' },
  { type: 'table-row', label: '表格行' },
  { type: 'table', label: '表格' },
]

const fallbackTypeLabels: Record<EditorElementType, string> = {
  none: '无',
  'input-field': '输入域',
  radio: '单选框',
  checkbox: '复选框',
  table: '表格',
  'table-row': '表格行',
  'table-cell': '单元格',
  barcode: '条码',
  qrcode: '二维码',
  'header-footer': '页眉页脚',
}

const typeOptions = computed(() => {
  if (referenceTypeOptions.some(option => option.type === props.element.type)) {
    return referenceTypeOptions
  }
  return [
    ...referenceTypeOptions,
    {
      type: props.element.type,
      label: fallbackTypeLabels[props.element.type],
    },
  ]
})

function fieldTextValue(field: ElementPropertyField): string {
  const value = props.element[field.key]
  if (Array.isArray(value)) return value.join(',')
  if (typeof value === 'object' && value) return JSON.stringify(value)
  return typeof value === 'number' || typeof value === 'string' ? String(value) : ''
}

function fieldCheckedValue(field: ElementPropertyField) {
  return Boolean(props.element[field.key])
}

function fieldMultiSelectValues(field: ElementPropertyField) {
  return getElementPropertyMultiSelectValues(props.element[field.key])
}

function updateField(field: ElementPropertyField, event: Event) {
  const target = event.target as HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
  const value = field.kind === 'checkbox' || field.kind === 'switch'
    ? (target as HTMLInputElement).checked
    : field.kind === 'multi-select'
      ? Array.from((target as HTMLSelectElement).selectedOptions).map(option => option.value)
      : target.value
  emit('update', createElementPropertyPatch(field, value))
}

function updateMultiSelectField(field: ElementPropertyField, value: unknown) {
  const selectedValues = Array.isArray(value)
    ? value.map(String)
    : typeof value === 'string'
      ? [value]
      : []
  emit('update', createElementPropertyPatch(field, selectedValues))
}

function updateFieldValue(field: ElementPropertyField, value: string) {
  emit('update', createElementPropertyPatch(field, value))
}

function openListItemsEditor(field: ElementPropertyField) {
  editingListItemsField.value = field
}

function closeListItemsEditor() {
  editingListItemsField.value = null
}

function saveListItems(value: string) {
  if (!editingListItemsField.value) return
  updateFieldValue(editingListItemsField.value, value)
}
</script>

<template>
  <section class="element-properties" aria-label="元素属性">
    <div class="element-properties__toolbar">
      <div class="element-properties__title">元素属性</div>
      <select
        class="element-properties__type-select"
        :value="props.element.type"
        disabled
        aria-disabled="true"
        @change="emit('selectType', ($event.target as HTMLSelectElement).value as EditorElementType)"
      >
        <option v-for="option in typeOptions" :key="option.type" :value="option.type">
          {{ option.label }}
        </option>
      </select>
      <button class="element-properties__update" type="button" title="更新" @click="emit('refresh')">
        <RefreshCw :size="14" aria-hidden="true" />
        <span>更新</span>
      </button>
    </div>

    <div class="element-properties__status" :class="`element-properties__status--${props.status.status}`">
      {{ props.status.message }}
    </div>

    <form class="element-properties__form" @submit.prevent>
      <section v-for="group in groups" :key="group.id" class="element-properties__group">
        <h3 class="element-properties__group-title">{{ group.label }}</h3>
        <div class="element-properties__grid">
          <label
            v-for="field in group.fields"
            :key="field.writerName"
            class="element-properties__field"
            :class="{
              'element-properties__field--wide': field.span && field.span > 1,
              'element-properties__field--switch': field.kind === 'switch' || field.kind === 'checkbox',
            }"
          >
            <span class="element-properties__label">{{ field.label }}</span>
            <span class="element-properties__control">
              <input
                v-if="field.kind === 'checkbox'"
                type="checkbox"
                :checked="fieldCheckedValue(field)"
                @change="updateField(field, $event)"
              />
              <input
                v-else-if="field.kind === 'switch'"
                class="element-properties__switch"
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
              <ElSelect
                v-else-if="field.kind === 'multi-select'"
                class="element-properties__element-select"
                :model-value="fieldMultiSelectValues(field)"
                multiple
                :collapse-tags="field.collapseTags"
                collapse-tags-tooltip
                :placeholder="field.label"
                popper-class="element-properties__select-popper"
                @update:model-value="updateMultiSelectField(field, $event)"
              >
                <ElOption
                  v-for="option in field.options || []"
                  :key="option.value"
                  :value="option.value"
                  :label="option.label"
                />
              </ElSelect>
              <textarea
                v-else-if="field.kind === 'textarea' || field.kind === 'autocomplete'"
                :value="fieldTextValue(field)"
                :placeholder="field.placeholder || field.label"
                rows="2"
                @input="updateField(field, $event)"
              />
              <span v-else-if="field.kind === 'list-items'" class="element-properties__json">
                <input
                  type="text"
                  readonly
                  :value="summarizeStaticListItems(fieldTextValue(field))"
                  :placeholder="field.placeholder || field.label"
                  @dblclick="openListItemsEditor(field)"
                />
                <button type="button" :title="`编辑${field.label}`" @click="openListItemsEditor(field)">
                  <Edit3 :size="13" aria-hidden="true" />
                </button>
              </span>
              <DisplayFormatPicker
                v-else-if="field.kind === 'display-format'"
                :value="fieldTextValue(field)"
                :options="field.options || []"
                @update="updateFieldValue(field, $event)"
              />
              <span v-else-if="field.kind === 'json'" class="element-properties__json">
                <input
                  type="text"
                  :value="fieldTextValue(field)"
                  :placeholder="field.placeholder || field.label"
                  @input="updateField(field, $event)"
                />
                <button type="button" :title="`编辑${field.label}`">
                  <Edit3 :size="13" aria-hidden="true" />
                </button>
              </span>
              <input
                v-else
                :type="field.kind === 'number' ? 'number' : field.kind === 'color' ? 'color' : 'text'"
                :value="fieldTextValue(field)"
                :placeholder="field.placeholder || field.label"
                @input="updateField(field, $event)"
              />
            </span>
          </label>
        </div>
      </section>
    </form>
    <ListItemsEditorDialog
      :open="Boolean(editingListItemsField)"
      :value="editingListItemsValue"
      @close="closeListItemsEditor"
      @save="saveListItems"
    />
  </section>
</template>

<style scoped>
.element-properties {
  display: grid;
  min-height: 0;
  grid-template-rows: auto auto minmax(0, 1fr);
  gap: 7px;
  overflow: auto;
  padding: 8px;
}

.element-properties__toolbar {
  display: grid;
  grid-template-columns: minmax(70px, 1fr) 120px 76px;
  gap: 6px;
  align-items: center;
}

.element-properties__title {
  padding-left: 8px;
  border-left: 3px solid #3f5fc7;
  color: #1f2937;
  font-size: 13px;
  font-weight: 700;
}

.element-properties__type-select,
.element-properties__update {
  height: 30px;
  border: 1px solid #c5d0db;
  border-radius: 4px;
  background: #fff;
  color: #40566d;
  font-size: 12px;
}

.element-properties__update {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  gap: 5px;
  border-color: #3f5fc7;
  background: #3f5fc7;
  color: #fff;
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

.element-properties__form {
  display: grid;
  gap: 12px;
}

.element-properties__group {
  display: grid;
  gap: 6px;
}

.element-properties__group-title {
  margin: 0;
  color: #202936;
  font-size: 13px;
  font-weight: 700;
}

.element-properties__grid {
  display: grid;
  border-top: 1px solid #e4e9ef;
  border-left: 1px solid #e4e9ef;
}

.element-properties__field {
  display: grid;
  min-height: 39px;
  grid-template-columns: 104px minmax(0, 1fr);
  border-right: 1px solid #e4e9ef;
  border-bottom: 1px solid #e4e9ef;
  font-size: 12px;
}

.element-properties__field--wide {
  min-height: 58px;
}

.element-properties__label {
  display: flex;
  min-width: 0;
  align-items: center;
  padding: 0 8px;
  background: #f6f8fa;
  color: #7a8491;
}

.element-properties__control {
  display: flex;
  min-width: 0;
  align-items: center;
  padding: 5px 8px;
}

.element-properties__field input,
.element-properties__field select,
.element-properties__field textarea {
  width: 100%;
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

.element-properties__field select[multiple] {
  min-height: 54px;
  padding: 3px 7px;
}

.element-properties__element-select {
  width: 100%;
  font-size: 12px;
}

.element-properties__element-select :deep(.el-select__wrapper) {
  min-height: 28px;
  border-radius: 4px;
  box-shadow: 0 0 0 1px #c8d3de inset;
  font-size: 12px;
}

.element-properties__element-select :deep(.el-select__wrapper.is-focused) {
  box-shadow: 0 0 0 1px #3f5fc7 inset;
}

.element-properties__element-select :deep(.el-select__tags-text) {
  max-width: 82px;
}

:global(.element-properties__select-popper .el-select-dropdown__item) {
  font-size: 13px;
}

:global(.element-properties__select-popper .el-select-dropdown__item.is-selected) {
  color: #315bdc;
  font-weight: 700;
}

.element-properties__field input[type="color"] {
  padding: 2px;
}

.element-properties__field input[type="checkbox"] {
  width: 16px;
  height: 16px;
}

.element-properties__field--switch .element-properties__control {
  justify-content: flex-start;
}

.element-properties__switch {
  width: 38px;
  height: 20px;
  accent-color: #18c26f;
}

.element-properties__json {
  display: flex;
  align-items: center;
  width: 100%;
}

.element-properties__json input {
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
}

.element-properties__json input[readonly] {
  cursor: pointer;
}

.element-properties__json button {
  display: inline-flex;
  width: 34px;
  height: 28px;
  align-items: center;
  justify-content: center;
  border: 1px solid #c8d3de;
  border-left: 0;
  border-radius: 0 4px 4px 0;
  background: #f7fafc;
  color: #697586;
}
</style>
