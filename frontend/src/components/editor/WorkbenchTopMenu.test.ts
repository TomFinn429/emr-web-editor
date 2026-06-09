import { createSSRApp } from 'vue'
import { renderToString } from 'vue/server-renderer'
import { describe, expect, it } from 'vitest'
import WorkbenchTopMenu from './WorkbenchTopMenu.vue'

const baseProps = {
  canUseWriterCommands: true,
  canUseWriterPrint: true,
  canSave: true,
  canPrint: true,
  canUpload: true,
  isSaving: false,
  isImporting: false,
  isPrintPreviewing: false,
  fileName: '西医病案首页.xml',
}

async function renderTopMenu() {
  const app = createSSRApp(WorkbenchTopMenu, baseProps)
  return renderToString(app)
}

describe('WorkbenchTopMenu', () => {
  it('renders file commands in the ribbon toolbar by default', async () => {
    const html = await renderTopMenu()

    expect(html).toContain('导入 XML')
    expect(html).toContain('保存')
    expect(html).toContain('导出到本地')
    expect(html).toContain('上传')
    expect(html).toContain('打印预览')
    expect(html).not.toContain('workbench-menu__toolbar--file')
  })

  it('renders the export command as a command-level dropdown trigger', async () => {
    const html = await renderTopMenu()

    expect(html).toContain('aria-haspopup="menu"')
    expect(html).toContain('aria-expanded="false"')
  })

  it('teleports command dropdowns so toolbar overflow does not clip them', async () => {
    const html = await renderTopMenu()

    expect(html).toContain('<!--teleport start-->')
    expect(html).toContain('<!--teleport end-->')
  })
})
