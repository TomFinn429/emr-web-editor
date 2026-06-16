import { createSSRApp } from 'vue'
import { renderToString } from 'vue/server-renderer'
import { describe, expect, it } from 'vitest'
import type { TraceIdentityOption } from '../../services/writerTraceService'
import type {
  WriterTraceInfo,
  WriterTraceUser,
  WriterTraceViewMode,
} from '../../utils/writerControlAdapter'
import { traceIdentityOptions } from '../../services/writerTraceService'
import WriterTracesPanel from './WriterTracesPanel.vue'
import writerTracesPanelSource from './WriterTracesPanel.vue?raw'

async function renderTracesPanel(
  traces: WriterTraceInfo[],
  options: {
    viewMode?: WriterTraceViewMode | null
    currentUser?: WriterTraceUser | null
    identityOptions?: readonly TraceIdentityOption[]
    activeTraceKey?: string | null
    errorMessage?: string | null
    canUseTraces?: boolean
  } = {},
) {
  const app = createSSRApp(WriterTracesPanel, {
    traces,
    viewMode: options.viewMode ?? 'complex',
    currentUser: options.currentUser ?? {
      ID: traceIdentityOptions[1].ID,
      Name: '张三主任医师',
    },
    identityOptions: options.identityOptions ?? traceIdentityOptions,
    activeTraceKey: options.activeTraceKey ?? null,
    errorMessage: options.errorMessage ?? null,
    canUseTraces: options.canUseTraces ?? true,
  })
  return renderToString(app)
}

describe('WriterTracesPanel', () => {
  it('renders native DCWriter traces with count, user, type, summary, and time', async () => {
    const html = await renderTracesPanel([
      {
        NativeHandle: 12,
        InfoType: 'Create',
        Text: '新增病程记录内容',
        UserName: '张三主任医师',
        SaveTime: '2026-06-16T08:00:00',
      },
      {
        NativeHandle: 13,
        InfoType: 'Delete',
        Text: '删除多余诊断',
        UserName: '李四主任医师',
        SaveTime: '2026-06-16T09:30:00',
      },
    ])

    expect(html).toContain('修改留痕')
    expect(html).toContain('2')
    expect(html).toContain('张三主任医师')
    expect(html).toContain('新增')
    expect(html).toContain('新增病程记录内容')
    expect(html).toContain('2026-06-16 08:00:00')
    expect(html).toContain('删除')
    expect(html).toContain('删除多余诊断')
  })

  it('renders review semantics so authors and insert/delete actions are distinguishable', async () => {
    const html = await renderTracesPanel([
      {
        NativeHandle: 12,
        InfoType: 'Create',
        Text: '新增诊断',
        UserName: '张三主任医师',
        SaveTime: '2026-06-16T08:00:00',
      },
      {
        NativeHandle: 13,
        InfoType: 'Delete',
        Text: '删除错字',
        UserName: '李四审核医师',
        SaveTime: '2026-06-16T09:30:00',
      },
    ], {
      activeTraceKey: '13',
    })

    expect(html).toContain('作者图例')
    expect(html).toContain('全部动作')
    expect(html).toContain('只看新增')
    expect(html).toContain('只看删除')
    expect(html).toContain('+')
    expect(html).toContain('-')
    expect(html).toContain('张三主任医师 新增')
    expect(html).toContain('李四审核医师 删除')
    expect(html).toContain('当前选中')
    expect(html).toContain('删除错字')
  })

  it('renders inserted text with underline and deleted text with strikethrough affordances', async () => {
    const html = await renderTracesPanel([
      {
        NativeHandle: 12,
        InfoType: 'Create',
        Text: '新增术后观察',
        UserName: '张三主任医师',
      },
      {
        NativeHandle: 13,
        InfoType: 'Delete',
        Text: '删除错字',
        UserName: '李四审核医师',
      },
    ])

    expect(html).toContain('writer-traces__item--insert')
    expect(html).toContain('writer-traces__item--delete')
    expect(writerTracesPanelSource).toContain('text-decoration: underline')
    expect(writerTracesPanelSource).toContain('text-decoration: line-through')
  })

  it('uses author color as the identity cue and highlights traces from the selected author', async () => {
    const html = await renderTracesPanel([
      {
        NativeHandle: 12,
        InfoType: 'Create',
        Text: '新增诊断',
        UserName: '张三主任医师',
      },
      {
        NativeHandle: 13,
        InfoType: 'Delete',
        Text: '删除错字',
        UserName: '李四审核医师',
      },
      {
        NativeHandle: 14,
        InfoType: 'Create',
        Text: '补充医嘱',
        UserName: '张三主任医师',
      },
    ], {
      activeTraceKey: '12',
    })

    expect(html).toContain('颜色代表身份')
    expect(html).toContain('张三主任医师作者色')
    expect(html).toContain('李四审核医师作者色')
    expect(html).toContain('writer-traces__active-dot')
    expect(html).toContain('writer-traces__item--same-author')
    expect(html).toContain('border-left-color:#2f7d5c')
    expect(html).toContain('border-left-color:#b25d00')
  })

  it('renders login, refresh, clean, and complex view controls', async () => {
    const html = await renderTracesPanel([])

    expect(html).toContain('title="登录留痕用户"')
    expect(html).toContain('title="刷新留痕"')
    expect(html).toContain('清洁')
    expect(html).toContain('留痕')
  })

  it('renders trace identity options and the selected current user', async () => {
    const html = await renderTracesPanel([], {
      currentUser: {
        ID: traceIdentityOptions[1].ID,
        Name: traceIdentityOptions[1].Name,
      },
    })

    expect(html).toContain('模板制作员')
    expect(html).toContain('张三主任医师')
    expect(html).toContain('李四审核医师')
    expect(html).toContain(`value="${traceIdentityOptions[1].ID}"`)
  })

  it('maps a matching current user name to a selectable identity without duplicating options', async () => {
    const html = await renderTracesPanel([], {
      currentUser: {
        ID: 'emr-web-editor-demo',
        Name: '模板制作员',
      },
    })

    expect(html).toContain('value="template-maker"')
    expect(html).not.toContain('value="emr-web-editor-demo"')
  })

  it('renders error and empty states', async () => {
    const html = await renderTracesPanel([], {
      errorMessage: '当前外部编辑器未暴露留痕列表接口。',
    })

    expect(html).toContain('当前外部编辑器未暴露留痕列表接口。')
    expect(html).toContain('暂无留痕')
  })
})
