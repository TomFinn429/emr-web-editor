<script setup lang="ts">
import EditorShell from './components/editor/EditorShell.vue'
import XmlImportMilestone from './components/presentation/XmlImportMilestone.vue'
import { resolvePresentationStage } from './presentation/stageProfiles'

const presentationStage = resolvePresentationStage({
  search: window.location.search,
  envStage: import.meta.env.VITE_PRESENTATION_STAGE,
})
</script>

<template>
  <XmlImportMilestone
    v-if="presentationStage.kind === 'xml-import'"
    :stage="presentationStage"
  />
  <EditorShell v-else />
</template>
