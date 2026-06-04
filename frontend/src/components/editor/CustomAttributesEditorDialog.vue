<script setup lang="ts">
import { computed, ref, shallowRef, watch } from 'vue'
import { ElButton, ElDialog, ElInput, ElTabPane, ElTable, ElTableColumn, ElTabs } from 'element-plus'
import 'element-plus/es/components/button/style/css'
import 'element-plus/es/components/dialog/style/css'
import 'element-plus/es/components/input/style/css'
import 'element-plus/es/components/table/style/css'
import 'element-plus/es/components/tabs/style/css'
import { Plus, Save, Trash2 } from 'lucide-vue-next'
import {
  parseCustomAttributes,
  stringifyCustomAttributes,
  validateCustomAttributes,
  type CustomAttributeItem,
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

const activeTab = shallowRef<'table' | 'json'>('table')
const jsonText = shallowRef('')
const validationMessage = shallowRef('')
const items = ref<CustomAttributeItem[]>([])

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
    activeTab.value = 'table'
    validationMessage.value = ''
    items.value = parseCustomAttributes(value)
    jsonText.value = value || stringifyCustomAttributes(items.value)
  },
  { immediate: true },
)

function handleTabChange(tabName: string | number) {
  validationMessage.value = ''
  if (tabName === 'json') {
    jsonText.value = stringifyCustomAttributes(items.value)
    return
  }

  const parsed = parseJsonTab()
  if (parsed) items.value = parsed
}

function addItem() {
  items.value = [
    ...items.value,
    { Text: '', Value: '' },
  ]
}

function deleteItem(index: number) {
  items.value = items.value.filter((_, itemIndex) => itemIndex !== index)
}

function saveItems() {
  validationMessage.value = ''
  const nextItems = activeTab.value === 'json' ? parseJsonTab() : items.value
  if (!nextItems) return

  const validation = validateCustomAttributes(nextItems)
  if (!validation.ok) {
    validationMessage.value = validation.message || '属性名称不能为空'
    return
  }

  emit('save', stringifyCustomAttributes(nextItems))
  emit('close')
}

function parseJsonTab() {
  try {
    const parsed = JSON.parse(jsonText.value || '{}')
    if (!parsed || typeof parsed !== 'object' || Array.isArray(parsed)) {
      validationMessage.value = 'JSON必须是对象格式'
      return null
    }
    return parseCustomAttributes(JSON.stringify(parsed))
  }
  catch {
    validationMessage.value = 'JSON格式错误，请检查配置'
    return null
  }
}
</script>

<template>
  <ElDialog
    v-model="dialogOpen"
    title="自定义属性内容"
    width="680px"
    :close-on-click-modal="false"
    class="custom-attributes-editor"
  >
    <ElTabs v-model="activeTab" @tab-change="handleTabChange">
      <ElTabPane label="静态选择项" name="table">
        <div class="custom-attributes-editor__toolbar">
          <ElButton type="primary" size="small" @click="addItem">
            <Plus :size="14" aria-hidden="true" />
            <span>添加</span>
          </ElButton>
          <ElButton type="primary" size="small" @click="saveItems">
            <Save :size="14" aria-hidden="true" />
            <span>保存</span>
          </ElButton>
        </div>
        <ElTable :data="items" height="360" border size="small">
          <ElTableColumn type="index" label="序号" width="78" align="center" />
          <ElTableColumn label="属性名" min-width="190">
            <template #default="{ row }">
              <ElInput v-model="row.Text" placeholder="属性名" />
            </template>
          </ElTableColumn>
          <ElTableColumn label="属性值" min-width="190">
            <template #default="{ row }">
              <ElInput v-model="row.Value" placeholder="属性值" />
            </template>
          </ElTableColumn>
          <ElTableColumn label="操作" width="96" align="center">
            <template #default="{ $index }">
              <ElButton type="danger" size="small" @click="deleteItem($index)">
                <Trash2 :size="13" aria-hidden="true" />
                <span>删除</span>
              </ElButton>
            </template>
          </ElTableColumn>
        </ElTable>
      </ElTabPane>

      <ElTabPane label="JSON手动配置" name="json">
        <div class="custom-attributes-editor__toolbar">
          <ElButton type="primary" size="small" @click="saveItems">
            <Save :size="14" aria-hidden="true" />
            <span>保存</span>
          </ElButton>
        </div>
        <ElInput
          v-model="jsonText"
          type="textarea"
          :rows="14"
          placeholder="请输入内容"
          class="custom-attributes-editor__json"
        />
        <div class="custom-attributes-editor__hint">
          <p>* 数据格式：{"属性名A":"属性值A","属性名B":"属性值B"}，属性值与属性名均为自定义配对</p>
          <p>* 参考示例：{"height":"180","weight":"140","breathe":"60"}</p>
        </div>
      </ElTabPane>
    </ElTabs>

    <p v-if="validationMessage" class="custom-attributes-editor__error">
      {{ validationMessage }}
    </p>
  </ElDialog>
</template>

<style scoped>
.custom-attributes-editor__toolbar {
  display: flex;
  gap: 8px;
  margin-bottom: 10px;
}

.custom-attributes-editor__toolbar :deep(.el-button) {
  display: inline-flex;
  align-items: center;
  gap: 5px;
}

.custom-attributes-editor__json {
  width: 100%;
}

.custom-attributes-editor__hint {
  margin-top: 10px;
  color: #5d6b7c;
  font-size: 12px;
  line-height: 20px;
}

.custom-attributes-editor__hint p,
.custom-attributes-editor__error {
  margin: 0;
}

.custom-attributes-editor__error {
  padding-top: 8px;
  color: #d03050;
  font-size: 12px;
}
</style>
