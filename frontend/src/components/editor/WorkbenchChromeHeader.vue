<script setup lang="ts">
import { Maximize2, Monitor, RefreshCw, UserCircle } from 'lucide-vue-next'
import type { Component } from 'vue'
import { shellActions, type WorkbenchShellAction } from './workbenchChrome'

const iconMap: Record<WorkbenchShellAction['icon'], Component> = {
  display: Monitor,
  fullscreen: Maximize2,
  reload: RefreshCw,
  account: UserCircle,
}
</script>

<template>
  <header class="chrome-header" aria-label="模板制作工作台顶部栏">
    <div class="chrome-header__brand">
      <strong>模板制作</strong>
      <span>DCWriter 模板制作工具</span>
    </div>
    <div class="chrome-header__actions">
      <button
        v-for="action in shellActions"
        :key="action.id"
        class="chrome-header__action"
        type="button"
        :title="action.label"
      >
        <component :is="iconMap[action.icon]" :size="15" aria-hidden="true" />
        <span>{{ action.label }}</span>
      </button>
    </div>
  </header>
</template>

<style scoped>
.chrome-header {
  display: flex;
  min-width: 0;
  height: 44px;
  align-items: center;
  justify-content: space-between;
  border-bottom: 1px solid #c7d2dc;
  background: #f7fafc;
  color: #24364a;
}

.chrome-header__brand {
  display: flex;
  min-width: 0;
  align-items: baseline;
  gap: 10px;
  padding: 0 14px;
}

.chrome-header__brand strong {
  color: #153a59;
  font-size: 16px;
}

.chrome-header__brand span {
  overflow: hidden;
  color: #657589;
  font-size: 12px;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.chrome-header__actions {
  display: flex;
  align-items: center;
  gap: 4px;
  padding: 0 10px;
}

.chrome-header__action {
  display: inline-flex;
  height: 28px;
  align-items: center;
  gap: 5px;
  padding: 0 8px;
  border: 1px solid transparent;
  border-radius: 4px;
  background: transparent;
  color: #40566d;
  font-size: 12px;
}

.chrome-header__action:hover {
  border-color: #c2cfda;
  background: #edf4f8;
}
</style>
