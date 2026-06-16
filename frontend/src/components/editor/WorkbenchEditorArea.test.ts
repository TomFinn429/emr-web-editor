import { createSSRApp } from 'vue'
import { renderToString } from 'vue/server-renderer'
import { describe, expect, it } from 'vitest'
import { traceIdentityOptions } from '../../services/writerTraceService'
import WorkbenchEditorArea from './WorkbenchEditorArea.vue'

const baseProps = {
  document: null,
  fileName: '西医病案首页.xml',
  statusMessage: '文档已加载',
  warningText: '',
  zoom: 1,
  validationIssues: [],
  comments: [],
  commentVisibility: 'Visible',
  commentError: null,
  canUseComments: true,
  traces: [
    {
      NativeHandle: 12,
      InfoType: 'Create',
      Text: '新增病程记录内容',
      UserName: '张三主任医师',
      SaveTime: '2026-06-16T08:00:00',
    },
  ],
  traceViewMode: 'complex',
  traceUser: {
    ID: 'demo',
    Name: '张三主任医师',
  },
  traceError: null,
  traceIdentityOptions,
  activeTraceKey: '12',
  canUseTraces: true,
  openTabs: [],
  activeTemplateId: undefined,
}

async function renderEditorArea() {
  const app = createSSRApp(WorkbenchEditorArea, baseProps)
  return renderToString(app)
}

describe('WorkbenchEditorArea', () => {
  it('renders the trace panel below the editor review panels', async () => {
    const html = await renderEditorArea()

    expect(html).toContain('修改留痕')
    expect(html).toContain('新增病程记录内容')
    expect(html).toContain('张三主任医师')
  })

  it('passes selectable trace identities into the trace panel', async () => {
    const html = await renderEditorArea()

    expect(html).toContain('模板制作员')
    expect(html).toContain('李四审核医师')
  })

  it('passes the active trace key into the trace panel detail', async () => {
    const html = await renderEditorArea()

    expect(html).toContain('当前选中')
    expect(html).toContain('张三主任医师 新增')
  })
})
