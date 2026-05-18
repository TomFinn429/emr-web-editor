<script setup lang="ts">
import { Database, FileStack, RefreshCw } from 'lucide-vue-next'
import { computed, shallowRef } from 'vue'
import type { FragmentTemplate, MetadataItem } from '../../services/templateWorkbenchService'

interface Props {
  metadataItems: readonly MetadataItem[]
  fragmentTemplates: readonly FragmentTemplate[]
}

const props = defineProps<Props>()

const activeTab = shallowRef<'metadata' | 'fragment'>('metadata')

const activeTitle = computed(() => (activeTab.value === 'metadata' ? '元数据' : '片段模板'))
</script>

<template>
  <aside class="assist-panel" aria-label="编辑辅助面板">
    <div class="assist-panel__tabs">
      <button
        class="assist-panel__tab"
        :class="{ 'assist-panel__tab--active': activeTab === 'metadata' }"
        type="button"
        @click="activeTab = 'metadata'"
      >
        <Database :size="14" aria-hidden="true" />
        <span>元数据</span>
      </button>
      <button
        class="assist-panel__tab"
        :class="{ 'assist-panel__tab--active': activeTab === 'fragment' }"
        type="button"
        @click="activeTab = 'fragment'"
      >
        <FileStack :size="14" aria-hidden="true" />
        <span>片段模板</span>
      </button>
    </div>

    <div class="assist-panel__header">
      <span>{{ activeTitle }}</span>
      <button class="assist-panel__refresh" type="button" title="刷新">
        <RefreshCw :size="14" aria-hidden="true" />
      </button>
    </div>

    <div v-if="activeTab === 'metadata'" class="assist-panel__body">
      <button
        v-for="item in props.metadataItems"
        :key="item.id"
        class="assist-panel__item"
        type="button"
        :title="`${item.name} ${item.code}`"
      >
        <span class="assist-panel__name">{{ item.name }}</span>
        <span class="assist-panel__meta">{{ item.code }} · {{ item.valueType }}</span>
      </button>
    </div>

    <div v-else class="assist-panel__body">
      <button
        v-for="fragment in props.fragmentTemplates"
        :key="fragment.id"
        class="assist-panel__item"
        type="button"
        :title="fragment.name"
      >
        <span class="assist-panel__name">{{ fragment.name }}</span>
        <span class="assist-panel__meta">{{ fragment.category }}</span>
      </button>
    </div>
  </aside>
</template>

<style scoped>
.assist-panel {
  display: flex;
  min-width: 0;
  min-height: 0;
  flex-direction: column;
  border-right: 1px solid #c9d5df;
  background: #f8fafc;
  color: #1f2937;
}

.assist-panel__tabs {
  display: grid;
  height: 34px;
  grid-template-columns: 1fr 1fr;
  border-bottom: 1px solid #cfd9e3;
  background: #eef3f7;
}

.assist-panel__tab {
  display: inline-flex;
  min-width: 0;
  align-items: center;
  justify-content: center;
  gap: 5px;
  border: 0;
  border-right: 1px solid #cfd9e3;
  background: transparent;
  color: #40566d;
  font-size: 12px;
}

.assist-panel__tab--active {
  background: #fff;
  color: #1f4f73;
  font-weight: 700;
}

.assist-panel__header {
  display: flex;
  height: 36px;
  align-items: center;
  justify-content: space-between;
  padding: 0 9px;
  border-bottom: 1px solid #d9e2ea;
  background: #ffffff;
  font-size: 13px;
  font-weight: 700;
}

.assist-panel__refresh {
  display: inline-flex;
  width: 26px;
  height: 26px;
  align-items: center;
  justify-content: center;
  border: 1px solid #c5d0db;
  border-radius: 4px;
  background: #fff;
  color: #40566d;
}

.assist-panel__body {
  min-height: 0;
  overflow: auto;
  padding: 7px;
}

.assist-panel__item {
  display: flex;
  width: 100%;
  min-height: 48px;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
  gap: 3px;
  margin-bottom: 6px;
  padding: 6px 7px;
  border: 1px solid #d4dee7;
  border-radius: 4px;
  background: #ffffff;
  color: #1f2937;
  text-align: left;
}

.assist-panel__item:hover {
  border-color: #9bb6ca;
  background: #eef6fa;
}

.assist-panel__name,
.assist-panel__meta {
  max-width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.assist-panel__name {
  font-size: 12px;
  font-weight: 700;
}

.assist-panel__meta {
  color: #66788b;
  font-size: 11px;
}
</style>
