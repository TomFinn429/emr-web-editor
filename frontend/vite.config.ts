import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import { devLocalRendererAssetsPlugin } from './devLocalRendererAssetsPlugin'
import { devLocalTemplateApiPlugin } from './devLocalTemplateApiPlugin'

export default defineConfig({
  plugins: [
    devLocalTemplateApiPlugin([
      {
        root: 'D:/XML/notes',
        category: '本地模板',
      },
    ]),
    devLocalRendererAssetsPlugin({
      requestPath: ['/renderer', '/renderer-dev'],
      roots: [
        '../backend/renderer-source',
        '../backend/renderer-runtime',
      ],
    }),
    vue(),
  ],
  server: {
    host: '0.0.0.0',
    port: 5173,
    strictPort: false,
    proxy: {
      '/api': {
        target: 'http://localhost:5190',
        changeOrigin: true,
      },
    },
  },
  preview: {
    port: 4173,
    strictPort: false,
  },
})
