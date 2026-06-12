import { createSSRApp } from 'vue'
import { renderToString } from 'vue/server-renderer'
import { describe, expect, it } from 'vitest'
import type { WriterComment } from '../../utils/writerControlAdapter'
import WriterCommentsPanel from './WriterCommentsPanel.vue'

async function renderCommentsPanel(comments: WriterComment[]) {
  const app = createSSRApp(WriterCommentsPanel, {
    comments,
    visibility: 'Visible',
    errorMessage: null,
    canUseComments: true,
  })
  return renderToString(app)
}

describe('WriterCommentsPanel', () => {
  it('renders native DCWriter comments with count and author metadata', async () => {
    const html = await renderCommentsPanel([
      {
        Index: 0,
        Text: '数据校验错误\nPatient Name：数据不能为空。',
        Author: 'DCWriter',
        AuthorID: 'validation',
      },
      {
        Index: 1,
        Text: 'Some comment',
        Author: 'DC',
      },
    ])

    expect(html).toContain('原生批注')
    expect(html).toContain('2')
    expect(html).toContain('DCWriter')
    expect(html).toContain('Patient Name：数据不能为空。')
    expect(html).toContain('Some comment')
    expect(html).toContain('总是显示')
  })

  it('renders an add comment tool in the native comments header', async () => {
    const html = await renderCommentsPanel([])

    expect(html).toContain('title="新增批注"')
    expect(html).toContain('暂无批注')
  })
})
