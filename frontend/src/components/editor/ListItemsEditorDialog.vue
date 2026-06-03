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
  parseStaticListItems,
  stringifyStaticListItems,
  validateStaticListItems,
  type StaticListItem,
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
const items = ref<StaticListItem[]>([])

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
    items.value = parseStaticListItems(value)
    jsonText.value = value || stringifyStaticListItems(items.value)
  },
  { immediate: true },
)

function handleTabChange(tabName: string | number) {
  validationMessage.value = ''
  if (tabName === 'json') {
    jsonText.value = stringifyStaticListItems(items.value)
    return
  }
  const parsed = parseJsonTab()
  if (parsed) items.value = parsed
}

function addItem() {
  items.value = [
    ...items.value,
    { Text: '', TextInList: null, Value: '', Group: null, Tag: null, ID: null },
  ]
}

function deleteItem(index: number) {
  items.value = items.value.filter((_, itemIndex) => itemIndex !== index)
}

function saveItems() {
  validationMessage.value = ''
  const nextItems = activeTab.value === 'json' ? parseJsonTab() : items.value
  if (!nextItems) return

  const validation = validateStaticListItems(nextItems)
  if (!validation.ok) {
    validationMessage.value = validation.message || '文本不可为空，请检查配置'
    return
  }

  emit('save', stringifyStaticListItems(nextItems))
  emit('close')
}

function parseJsonTab() {
  try {
    const parsed = JSON.parse(jsonText.value || '[]')
    if (!Array.isArray(parsed)) {
      validationMessage.value = 'JSON必须是数组格式'
      return null
    }
    return parseStaticListItems(JSON.stringify(parsed))
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
    title="静态选择项内容"
    width="800px"
    :close-on-click-modal="false"
    class="list-items-editor"
  >
    <ElTabs v-model="activeTab" @tab-change="handleTabChange">
      <ElTabPane label="静态选择项" name="table">
        <div class="list-items-editor__toolbar">
          <ElButton type="primary" size="small" @click="addItem">
            <Plus :size="14" aria-hidden="true" />
            <span>添加</span>
          </ElButton>
          <ElButton type="primary" size="small" @click="saveItems">
            <Save :size="14" aria-hidden="true" />
            <span>保存</span>
          </ElButton>
        </div>
        <ElTable :data="items" height="438" border size="small">
          <ElTableColumn type="index" label="序号" width="78" align="center" />
          <ElTableColumn label="文本" min-width="170">
            <template #default="{ row }">
              <ElInput v-model="row.Text" placeholder="文本" />
            </template>
          </ElTableColumn>
          <ElTableColumn label="数值" min-width="150">
            <template #default="{ row }">
              <ElInput v-model="row.Value" placeholder="数值" />
            </template>
          </ElTableColumn>
          <ElTableColumn label="指定列表文本" min-width="160">
            <template #default="{ row }">
              <ElInput v-model="row.TextInList" placeholder="指定列表文本" />
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
        <div class="list-items-editor__toolbar">
          <ElButton type="primary" size="small" @click="saveItems">
            <Save :size="14" aria-hidden="true" />
            <span>保存</span>
          </ElButton>
        </div>
        <ElInput
          v-model="jsonText"
          type="textarea"
          :rows="18"
          placeholder="请输入内容"
          class="list-items-editor__json"
        />
        <div class="list-items-editor__hint">
          <p>* 数据格式：{"Text":"XXX","TextInList":null,"Value":"XXX","Group":null,"Tag":null,"ID":null}，字段为固定格式。</p>
          <p>* 参考示例：[{"Text":"男","TextInList":"","Value":"1","Group":null,"Tag":null,"ID":null},{"Text":"女","TextInList":null,"Value":"2","Group":null,"Tag":null,"ID":null}]</p>
        </div>
      </ElTabPane>
    </ElTabs>

    <p v-if="validationMessage" class="list-items-editor__error">
      {{ validationMessage }}
    </p>
  </ElDialog>
</template>

<style scoped>
.list-items-editor__toolbar {
  display: flex;
  gap: 8px;
  margin-bottom: 10px;
}

.list-items-editor__toolbar :deep(.el-button) {
  display: inline-flex;
  align-items: center;
  gap: 5px;
}

.list-items-editor__json {
  width: 100%;
}

.list-items-editor__hint {
  margin-top: 10px;
  color: #5d6b7c;
  font-size: 12px;
  line-height: 20px;
}

.list-items-editor__hint p,
.list-items-editor__error {
  margin: 0;
}

.list-items-editor__error {
  padding-top: 8px;
  color: #d03050;
  font-size: 12px;
}
</style>
