import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import { preloadExternalRenderer } from './composables/useCanvasRenderer'
import { scheduleExternalRendererPreload } from './rendererPreload'

createApp(App).mount('#app')

scheduleExternalRendererPreload(preloadExternalRenderer, import.meta.env.DEV)
