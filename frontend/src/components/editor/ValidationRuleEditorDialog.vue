<script setup lang="ts">
import { computed, reactive, shallowRef, watch } from 'vue'
import { ElButton, ElCheckbox, ElDialog, ElInput, ElInputNumber, ElRadio, ElTabPane, ElTabs } from 'element-plus'
import 'element-plus/es/components/button/style/css'
import 'element-plus/es/components/checkbox/style/css'
import 'element-plus/es/components/dialog/style/css'
import 'element-plus/es/components/input/style/css'
import 'element-plus/es/components/input-number/style/css'
import 'element-plus/es/components/radio/style/css'
import 'element-plus/es/components/tabs/style/css'
import { Save } from 'lucide-vue-next'
import {
  createEmptyValidationRule,
  parseValidationRule,
  stringifyValidationRule,
  VALIDATION_RULE_DESCRIPTION_ROWS,
  type ValidationRuleConfig,
} from './elementPropertySchema'

interface Props {
  open: boolean
  value: string
}

interface Emits {
  close: []
  save: [value: string]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()

const activeTab = shallowRef<'static' | 'json'>('static')
const selectedMode = shallowRef<'Text' | 'Numeric' | 'DateTime' | 'RegExpress'>('Text')
const jsonText = shallowRef('')
const validationMessage = shallowRef('')
const form = reactive<ValidationRuleConfig>(createEmptyValidationRule())

const dialogOpen = computed({
  get: () => props.open,
  set: value => {
    if (!value) emit('close')
  },
})

watch(
  () => [props.open, props.value] as const,
  ([open, value]) => {
    if (!open) return
    activeTab.value = 'static'
    validationMessage.value = ''
    Object.assign(form, parseValidationRule(value))
    selectedMode.value = inferValidationMode(form)
    jsonText.value = value || stringifyValidationRule(form)
  },
  { immediate: true },
)

function handleTabChange(tabName: string | number) {
  validationMessage.value = ''
  if (tabName === 'json') {
    jsonText.value = stringifyValidationRule(form)
    return
  }

  const parsed = parseJsonTab()
  if (parsed) {
    Object.assign(form, parsed)
    selectedMode.value = inferValidationMode(form)
  }
}

function saveRule() {
  validationMessage.value = ''
  const nextRule = activeTab.value === 'json' ? parseJsonTab() : form
  if (!nextRule) return

  emit('save', stringifyValidationRule(nextRule))
  emit('close')
}

function parseJsonTab() {
  try {
    return parseValidationRule(jsonText.value || '{}')
  }
  catch {
    validationMessage.value = 'JSON格式错误，请检查配置'
    return null
  }
}

function inferValidationMode(rule: ValidationRuleConfig): typeof selectedMode.value {
  if (rule.RegExpression) return 'RegExpress'
  if (rule.DateTimeMinValue || rule.DateTimeMaxValue) return 'DateTime'
  if (rule.CheckMinValue || rule.CheckMaxValue || rule.CheckDecimalDigits || rule.MinValue !== null || rule.MaxValue !== null || rule.MaxDecimalDigits !== null) {
    return 'Numeric'
  }
  return 'Text'
}
</script>

<template>
  <ElDialog
    v-model="dialogOpen"
    title="校验"
    width="800px"
    :close-on-click-modal="false"
    class="validation-rule-editor"
  >
    <ElTabs v-model="activeTab" @tab-change="handleTabChange">
      <ElTabPane label="静态选择项" name="static">
        <div class="validation-rule-editor__top-grid">
          <label class="validation-rule-editor__field validation-rule-editor__field--inline">
            <span>是否必填</span>
            <ElCheckbox v-model="form.Required" />
          </label>
          <label class="validation-rule-editor__field">
            <span>错误提示</span>
            <ElInput v-model="form.CustomMessage" />
          </label>
          <label class="validation-rule-editor__field">
            <span>违禁关键字</span>
            <ElInput v-model="form.ExcludeKeywords" />
          </label>
          <label class="validation-rule-editor__field">
            <span>允许关键字</span>
            <ElInput v-model="form.IncludeKeywords" />
          </label>
        </div>

        <section class="validation-rule-editor__block">
          <ElRadio v-model="selectedMode" label="Text">
            纯文本格式校验
          </ElRadio>
          <div class="validation-rule-editor__pair-grid">
            <label class="validation-rule-editor__field">
              <span>最小长度</span>
              <ElInputNumber v-model="form.MinLength" :disabled="selectedMode !== 'Text'" :min="0" controls-position="right" />
            </label>
            <label class="validation-rule-editor__field">
              <span>最大长度</span>
              <ElInputNumber v-model="form.MaxLength" :disabled="selectedMode !== 'Text'" :min="0" controls-position="right" />
            </label>
          </div>
        </section>

        <section class="validation-rule-editor__block">
          <ElRadio v-model="selectedMode" label="Numeric">
            数值格式校验
          </ElRadio>
          <div class="validation-rule-editor__numeric-grid">
            <label class="validation-rule-editor__field validation-rule-editor__field--inline">
              <ElCheckbox v-model="form.CheckMinValue" :disabled="selectedMode !== 'Numeric'">
                最小值
              </ElCheckbox>
              <ElInputNumber v-model="form.MinValue" :disabled="selectedMode !== 'Numeric' || !form.CheckMinValue" controls-position="right" />
            </label>
            <label class="validation-rule-editor__field validation-rule-editor__field--inline">
              <ElCheckbox v-model="form.CheckMaxValue" :disabled="selectedMode !== 'Numeric'">
                最大值
              </ElCheckbox>
              <ElInputNumber v-model="form.MaxValue" :disabled="selectedMode !== 'Numeric' || !form.CheckMaxValue" controls-position="right" />
            </label>
            <label class="validation-rule-editor__field validation-rule-editor__field--inline">
              <ElCheckbox v-model="form.CheckDecimalDigits" :disabled="selectedMode !== 'Numeric'">
                最大小数位数
              </ElCheckbox>
              <ElInputNumber v-model="form.MaxDecimalDigits" :disabled="selectedMode !== 'Numeric' || !form.CheckDecimalDigits" :min="0" controls-position="right" />
            </label>
          </div>
        </section>

        <section class="validation-rule-editor__block">
          <ElRadio v-model="selectedMode" label="DateTime">
            日期格式校验
          </ElRadio>
          <div class="validation-rule-editor__pair-grid">
            <label class="validation-rule-editor__field">
              <span>不得早于</span>
              <ElInput v-model="form.DateTimeMinValue" :disabled="selectedMode !== 'DateTime'" placeholder="选择日期" />
            </label>
            <label class="validation-rule-editor__field">
              <span>不得晚于</span>
              <ElInput v-model="form.DateTimeMaxValue" :disabled="selectedMode !== 'DateTime'" placeholder="选择日期" />
            </label>
          </div>
        </section>

        <section class="validation-rule-editor__block">
          <ElRadio v-model="selectedMode" label="RegExpress">
            正则表达式
          </ElRadio>
          <ElInput v-model="form.RegExpression" :disabled="selectedMode !== 'RegExpress'" />
        </section>
      </ElTabPane>

      <ElTabPane label="JSON手动配置" name="json">
        <ElInput
          v-model="jsonText"
          type="textarea"
          :rows="20"
          placeholder="请输入校验 JSON"
          class="validation-rule-editor__json"
        />
        <table class="validation-rule-editor__description-table">
          <thead>
            <tr>
              <th scope="col">属性</th>
              <th scope="col">说明</th>
              <th scope="col">属性</th>
              <th scope="col">说明</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="(row, index) in VALIDATION_RULE_DESCRIPTION_ROWS" :key="index">
              <template v-for="cell in row" :key="cell.property">
                <td class="validation-rule-editor__description-property">
                  {{ cell.property }}
                </td>
                <td>{{ cell.description }}</td>
              </template>
            </tr>
          </tbody>
        </table>
      </ElTabPane>
    </ElTabs>

    <p v-if="validationMessage" class="validation-rule-editor__error">
      {{ validationMessage }}
    </p>

    <template #footer>
      <ElButton type="primary" size="small" class="validation-rule-editor__save" @click="saveRule">
        <Save :size="14" aria-hidden="true" />
        <span>保存</span>
      </ElButton>
    </template>
  </ElDialog>
</template>

<style scoped>
.validation-rule-editor__top-grid,
.validation-rule-editor__pair-grid {
  display: grid;
  grid-template-columns: 1fr 1fr;
  gap: 12px 18px;
}

.validation-rule-editor__top-grid {
  margin-bottom: 14px;
}

.validation-rule-editor__field {
  display: grid;
  gap: 6px;
  color: #4b5f73;
  font-size: 12px;
}

.validation-rule-editor__field--inline {
  display: flex;
  align-items: center;
  gap: 8px;
}

.validation-rule-editor__block {
  display: grid;
  gap: 10px;
  margin-top: 12px;
  padding: 12px;
  border: 1px solid #e1e7ef;
  background: #fbfdff;
}

.validation-rule-editor__numeric-grid {
  display: grid;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 12px;
}

.validation-rule-editor__numeric-grid .validation-rule-editor__field {
  align-items: flex-start;
  flex-direction: column;
}

.validation-rule-editor__json {
  width: 100%;
}

.validation-rule-editor__error {
  margin: 0;
}

.validation-rule-editor__description-table {
  width: 100%;
  margin-top: 14px;
  border-collapse: collapse;
  table-layout: fixed;
  color: #606266;
  font-size: 13px;
}

.validation-rule-editor__description-table th {
  background: #666;
  color: #fff;
  font-weight: 600;
  text-align: left;
}

.validation-rule-editor__description-table th,
.validation-rule-editor__description-table td {
  overflow-wrap: anywhere;
  padding: 6px 8px;
  border: 1px solid #d3d7de;
  line-height: 20px;
}

.validation-rule-editor__description-property {
  width: 18%;
}

.validation-rule-editor__error {
  padding-top: 8px;
  color: #d03050;
  font-size: 12px;
}

.validation-rule-editor__save {
  display: inline-flex;
  width: 100%;
  align-items: center;
  justify-content: center;
  gap: 5px;
}
</style>
