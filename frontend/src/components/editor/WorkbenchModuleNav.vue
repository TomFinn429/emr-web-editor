<script setup lang="ts">
import { Database, FileCog, LayoutDashboard, Library, Settings } from 'lucide-vue-next'
import type { Component } from 'vue'
import { workbenchModules, type WorkbenchModuleItem } from './workbenchChrome'

const iconMap: Record<WorkbenchModuleItem['icon'], Component> = {
  dashboard: LayoutDashboard,
  template: FileCog,
  data: Database,
  library: Library,
  settings: Settings,
}
</script>

<template>
  <nav class="module-nav" aria-label="模板制作主模块导航">
    <button
      v-for="item in workbenchModules"
      :key="item.id"
      class="module-nav__item"
      :class="{ 'module-nav__item--active': item.active }"
      type="button"
      :aria-current="item.active ? 'page' : undefined"
      :title="item.label"
    >
      <component :is="iconMap[item.icon]" :size="16" aria-hidden="true" />
      <span>{{ item.label }}</span>
    </button>
  </nav>
</template>

<style scoped>
.module-nav {
  display: flex;
  min-width: 0;
  min-height: 0;
  flex-direction: column;
  gap: 3px;
  overflow: auto;
  padding: 8px 6px;
  border-right: 1px solid #c7d2dc;
  background: #edf3f7;
}

.module-nav__item {
  display: grid;
  min-height: 36px;
  grid-template-columns: 18px minmax(0, 1fr);
  align-items: center;
  gap: 7px;
  padding: 0 8px;
  border: 1px solid transparent;
  border-radius: 4px;
  background: transparent;
  color: #40566d;
  font-size: 12px;
  text-align: left;
}

.module-nav__item span {
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.module-nav__item:hover {
  border-color: #c2cfda;
  background: #f7fafc;
}

.module-nav__item--active {
  border-color: #7ca6c0;
  background: #dfeff7;
  color: #153a59;
  font-weight: 700;
}
</style>
