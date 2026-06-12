<script setup lang="ts">
import { computed, shallowRef } from 'vue'
import { ElColorPicker, ElOption, ElSelect } from 'element-plus'
import 'element-plus/es/components/color-picker/style/css'
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
  normalizeColorPickerValue,
  summarizeCustomAttributes,
  summarizeStaticListItems,
  toColorPickerValue,
  type ElementPropertyField,
} from './elementPropertySchema'
import CustomAttributesEditorDialog from './CustomAttributesEditorDialog.vue'
import DisplayFormatPicker from './DisplayFormatPicker.vue'
import ListItemsEditorDialog from './ListItemsEditorDialog.vue'
import ValidationRuleEditorDialog from './ValidationRuleEditorDialog.vue'

interface Props {
  element: EditorElementProperties
  status: ElementPropertyUpdateResult
  canEdit: boolean
}

interface Emits {
  refresh: []
  selectType: [type: EditorElementType]
  update: [patch: Partial<EditorElementProperties>]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()
const groups = computed(() => getVisibleElementPropertyGroups(props.element.type, props.element))
const isReadOnly = computed(() => !props.canEdit)
const editingListItemsField = shallowRef<ElementPropertyField | null>(null)
const editingValidationRuleField = shallowRef<ElementPropertyField | null>(null)
const editingCustomAttributesField = shallowRef<ElementPropertyField | null>(null)
const editingListItemsValue = computed(() => editingListItemsField.value
  ? fieldTextValue(editingListItemsField.value)
  : '')
const editingValidationRuleValue = computed(() => editingValidationRuleField.value
  ? fieldTextValue(editingValidationRuleField.value)
  : '')
const editingCustomAttributesValue = computed(() => editingCustomAttributesField.value
  ? fieldTextValue(editingCustomAttributesField.value)
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
  if ((value === null || value === undefined || value === '') && field.defaultValue !== undefined) {
    return field.defaultValue
  }
  if (Array.isArray(value)) return value.join(',')
  if (typeof value === 'object' && value) return JSON.stringify(value)
  if (typeof value === 'boolean' && field.kind === 'select') return String(value)
  return typeof value === 'number' || typeof value === 'string' ? String(value) : ''
}

function fieldCheckedValue(field: ElementPropertyField) {
  return Boolean(props.element[field.key])
}

function fieldMultiSelectValues(field: ElementPropertyField) {
  return getElementPropertyMultiSelectValues(props.element[field.key])
}

function updateField(field: ElementPropertyField, event: Event) {
  if (isReadOnly.value) return
  const target = event.target as HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement
  const value = field.kind === 'checkbox' || field.kind === 'switch'
    ? (target as HTMLInputElement).checked
    : field.kind === 'multi-select'
      ? Array.from((target as HTMLSelectElement).selectedOptions).map(option => option.value)
      : target.value
  emit('update', createElementPropertyPatch(field, value))
}

function updateMultiSelectField(field: ElementPropertyField, value: unknown) {
  if (isReadOnly.value) return
  const selectedValues = Array.isArray(value)
    ? value.map(String)
    : typeof value === 'string'
      ? [value]
      : []
  emit('update', createElementPropertyPatch(field, selectedValues))
}

function updateFieldValue(field: ElementPropertyField, value: string) {
  if (isReadOnly.value) return
  emit('update', createElementPropertyPatch(field, value))
}

function updateColorField(field: ElementPropertyField, value: string) {
  updateFieldValue(field, normalizeColorPickerValue(value))
}

function openListItemsEditor(field: ElementPropertyField) {
  if (isReadOnly.value) return
  editingListItemsField.value = field
}

function openValidationRuleEditor(field: ElementPropertyField) {
  if (isReadOnly.value) return
  editingValidationRuleField.value = field
}

function openCustomAttributesEditor(field: ElementPropertyField) {
  if (isReadOnly.value) return
  editingCustomAttributesField.value = field
}

function closeListItemsEditor() {
  editingListItemsField.value = null
}

function closeValidationRuleEditor() {
  editingValidationRuleField.value = null
}

function closeCustomAttributesEditor() {
  editingCustomAttributesField.value = null
}

function saveListItems(value: string) {
  if (!editingListItemsField.value) return
  updateFieldValue(editingListItemsField.value, value)
}

function saveValidationRule(value: string) {
  if (!editingValidationRuleField.value) return
  updateFieldValue(editingValidationRuleField.value, value)
}

function saveCustomAttributes(value: string) {
  if (!editingCustomAttributesField.value) return
  updateFieldValue(editingCustomAttributesField.value, value)
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
                :disabled="isReadOnly"
                @change="updateField(field, $event)"
              />
              <input
                v-else-if="field.kind === 'switch'"
                class="element-properties__switch"
                type="checkbox"
                role="switch"
                :checked="fieldCheckedValue(field)"
                :disabled="isReadOnly"
                @change="updateField(field, $event)"
              />
              <select
                v-else-if="field.kind === 'select'"
                :value="fieldTextValue(field)"
                :disabled="isReadOnly"
                @change="updateField(field, $event)"
              >
                <option v-if="field.allowEmptyOption !== false" value="">未设置</option>
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
                :disabled="isReadOnly"
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
                :disabled="isReadOnly"
                @input="updateField(field, $event)"
              />
              <span v-else-if="field.kind === 'list-items'" class="element-properties__json">
                <input
                  type="text"
                  readonly
                  :value="summarizeStaticListItems(fieldTextValue(field))"
                  :placeholder="field.placeholder || field.label"
                  :disabled="isReadOnly"
                  @dblclick="openListItemsEditor(field)"
                />
                <button type="button" :title="`编辑${field.label}`" :disabled="isReadOnly" @click="openListItemsEditor(field)">
                  <Edit3 :size="13" aria-hidden="true" />
                </button>
              </span>
              <DisplayFormatPicker
                v-else-if="field.kind === 'display-format'"
                :value="fieldTextValue(field)"
                :options="field.options || []"
                :disabled="isReadOnly"
                @update="updateFieldValue(field, $event)"
              />
              <span v-else-if="field.kind === 'validation-rule'" class="element-properties__json">
                <input
                  type="text"
                  readonly
                  :value="fieldTextValue(field)"
                  :placeholder="field.placeholder || field.label"
                  :disabled="isReadOnly"
                  @click="openValidationRuleEditor(field)"
                />
                <button type="button" :title="`编辑${field.label}`" :disabled="isReadOnly" @click="openValidationRuleEditor(field)">
                  <Edit3 :size="13" aria-hidden="true" />
                </button>
              </span>
              <span v-else-if="field.kind === 'custom-attributes'" class="element-properties__json">
                <input
                  type="text"
                  readonly
                  :value="summarizeCustomAttributes(fieldTextValue(field))"
                  :placeholder="field.placeholder || field.label"
                  :disabled="isReadOnly"
                  @click="openCustomAttributesEditor(field)"
                  @dblclick="openCustomAttributesEditor(field)"
                />
                <button type="button" :title="`编辑${field.label}`" :disabled="isReadOnly" @click="openCustomAttributesEditor(field)">
                  <Edit3 :size="13" aria-hidden="true" />
                </button>
              </span>
              <span v-else-if="field.kind === 'json'" class="element-properties__json">
                <input
                  type="text"
                  :value="fieldTextValue(field)"
                  :placeholder="field.placeholder || field.label"
                  :disabled="isReadOnly"
                  @input="updateField(field, $event)"
                />
                <button type="button" :title="`编辑${field.label}`" :disabled="isReadOnly">
                  <Edit3 :size="13" aria-hidden="true" />
                </button>
              </span>
              <span v-else-if="field.kind === 'color'" class="element-properties__color">
                <input
                  type="text"
                  :value="fieldTextValue(field)"
                  :placeholder="field.placeholder || field.label"
                  :disabled="isReadOnly"
                  @input="updateField(field, $event)"
                />
                <ElColorPicker
                  :model-value="toColorPickerValue(fieldTextValue(field))"
                  show-alpha
                  color-format="rgb"
                  :predefine="['#000000FF', '#FFFFFFFF', '#FF0000FF', '#00FF00FF', '#0000FFFF', '#FFFFFF00']"
                  :disabled="isReadOnly"
                  @update:model-value="updateColorField(field, $event || '')"
                />
              </span>
              <input
                v-else
                :type="field.kind === 'number' ? 'number' : 'text'"
                :value="fieldTextValue(field)"
                :placeholder="field.placeholder || field.label"
                :disabled="isReadOnly"
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
    <ValidationRuleEditorDialog
      :open="Boolean(editingValidationRuleField)"
      :value="editingValidationRuleValue"
      @close="closeValidationRuleEditor"
      @save="saveValidationRule"
    />
    <CustomAttributesEditorDialog
      :open="Boolean(editingCustomAttributesField)"
      :value="editingCustomAttributesValue"
      @close="closeCustomAttributesEditor"
      @save="saveCustomAttributes"
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

.element-properties__field input[type="checkbox"] {
  width: 16px;
  height: 16px;
}

.element-properties__field--switch .element-properties__control {
  justify-content: flex-start;
}

.element-properties__switch {
  position: relative;
  width: 42px !important;
  height: 22px !important;
  padding: 0 !important;
  border: 0 !important;
  border-radius: 999px !important;
  appearance: none;
  background: #ff4d4f !important;
  cursor: pointer;
  transition: background 0.16s ease;
}

.element-properties__switch::after {
  position: absolute;
  top: 3px;
  left: 3px;
  width: 16px;
  height: 16px;
  border-radius: 50%;
  background: #fff;
  box-shadow: 0 1px 3px rgba(15, 23, 42, 0.24);
  content: "";
  transition: transform 0.16s ease;
}

.element-properties__switch:checked {
  background: #22c55e !important;
}

.element-properties__switch:checked::after {
  transform: translateX(20px);
}

.element-properties__switch:focus-visible {
  outline: 2px solid rgba(63, 95, 199, 0.32);
  outline-offset: 2px;
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

.element-properties__field input:disabled,
.element-properties__field select:disabled,
.element-properties__field textarea:disabled,
.element-properties__json button:disabled {
  cursor: not-allowed;
  background: #f3f6f8;
  color: #8a96a3;
}

.element-properties__color {
  display: flex;
  width: 100%;
  min-width: 0;
  align-items: center;
  gap: 6px;
}

.element-properties__color input {
  flex: 1 1 auto;
}

.element-properties__color :deep(.el-color-picker) {
  flex: 0 0 auto;
  height: 28px;
}

.element-properties__color :deep(.el-color-picker__trigger) {
  width: 30px;
  height: 28px;
  padding: 3px;
  border-color: #c8d3de;
  border-radius: 4px;
}

.element-properties__color :deep(.el-color-picker__color) {
  border-color: #c8d3de;
}
</style>
