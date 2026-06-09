<script setup lang="ts">
import type { Component } from 'vue'
import type { CommandDefinition } from './commandRegistry'

interface Props {
  commands: readonly CommandDefinition[]
  commandIcon: (command: CommandDefinition) => Component
  isCommandDisabled: (command: CommandDefinition) => boolean
}

interface Emits {
  command: [command: CommandDefinition]
}

const props = defineProps<Props>()
const emit = defineEmits<Emits>()

function runCommand(command: CommandDefinition) {
  if (props.isCommandDisabled(command)) {
    return
  }
  emit('command', command)
}
</script>

<template>
  <div class="dropdown-menu" role="menu">
    <div
      v-for="command in props.commands"
      :key="command.id"
      class="dropdown-menu__item"
      :class="{ 'dropdown-menu__item--disabled': props.isCommandDisabled(command) }"
      :title="command.disabledReason || command.label"
      role="menuitem"
      @click="runCommand(command)"
    >
      <component :is="props.commandIcon(command)" :size="15" aria-hidden="true" />
      <span class="dropdown-menu__label">{{ command.label }}</span>
    </div>
  </div>
</template>

<style scoped>
.dropdown-menu {
  position: fixed;
  z-index: 10001;
  min-width: 150px;
  padding: 6px 0;
  border-radius: 4px;
  background: #ffffff;
  box-shadow:
    0 2px 4px rgba(0, 0, 0, 0.12),
    0 0 6px rgba(0, 0, 0, 0.04);
  color: #2c3e50;
  font-size: 13px;
  line-height: 16px;
}

.dropdown-menu__item {
  position: relative;
  display: flex;
  height: 30px;
  align-items: center;
  gap: 10px;
  padding: 0 12px;
  color: #606266;
  cursor: pointer;
  line-height: 30px;
  white-space: nowrap;
}

.dropdown-menu__item:hover {
  background: #ecf5ff;
  color: #409eff;
}

.dropdown-menu__item--disabled {
  cursor: not-allowed;
  opacity: 0.45;
}

.dropdown-menu__item--expand {
  cursor: default;
}

.dropdown-menu__label {
  min-width: 0;
  flex: 1;
  overflow: hidden;
  text-overflow: ellipsis;
}
</style>
