# 实时留痕功能实现计划

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** 在 `emr-web-editor-mvp` 中接入 DCWriter 原生实时留痕浏览、点击定位，以及清洁/留痕视图切换。

**Architecture:** 继续沿用现有边界：`writerControlAdapter` 负责封装 WriterControl 原生 API，新增 `writerTraceService` 负责留痕数据归一与默认登录人生成，Vue 组件只负责展示、事件转发和状态编排。留痕列表采用独立底部面板 `WriterTracesPanel.vue`，并由 `EditorShell.vue` 在 WriterControl ready、内容变化和视图切换时刷新。

**Tech Stack:** Vue 3, `<script setup lang="ts">`, TypeScript, Vitest, existing WriterControl runtime APIs.

---

### Task 1: 扩展 `writerControlAdapter` 的实时留痕 API

**Files:**
- Modify: `frontend/src/utils/writerControlAdapter.ts`
- Modify: `frontend/src/utils/writerControlAdapter.test.ts`

- [ ] **Step 1: Write the failing test**

```ts
it('logs in a trace user, switches trace view modes, lists traces, and navigates by native handle', () => {
  const target: WriterControlTarget = {
    UserLoginByUserLoginInfo: vi.fn(() => true),
    ComplexViewMode: vi.fn(() => true),
    CleanViewMode: vi.fn(() => true),
    GetDocumentUserTrackInfos: vi.fn(() => [{ NativeHandle: 12 }]),
    NavigateByUserTrackInfo: vi.fn(() => true),
    DocumentOptions: {
      SecurityOptions: {},
    },
  }

  const adapter = createWriterControlAdapter(target)

  expect(adapter.loginTraceUser({
    ID: 'demo',
    Name: '演示用户',
    ClientName: 'emr-web-editor',
    PermissionLevel: '0',
    Description: 'demo',
  })).toEqual({ ok: true })
  expect(adapter.setTraceViewMode('complex')).toEqual({ ok: true })
  expect(adapter.setTraceViewMode('clean')).toEqual({ ok: true })
  expect(adapter.getTraceList()).toEqual({ ok: true, traces: [{ NativeHandle: 12 }] })
  expect(adapter.navigateToTrace(12)).toEqual({ ok: true })
})
```

- [ ] **Step 2: Run the focused test to verify it fails**

Run: `cd frontend && npm test -- src/utils/writerControlAdapter.test.ts`

Expected: fail because the trace APIs do not exist yet.

- [ ] **Step 3: Implement the minimal adapter methods**

Add `WriterTraceUser`, `WriterTraceInfo`, `WriterTraceViewMode`, `WriterTraceListResult`, and trace-related failure reasons. Implement login fallback, complex/clean mode switching, trace list retrieval, and native-handle navigation.

- [ ] **Step 4: Run the focused test to verify it passes**

Run: `cd frontend && npm test -- src/utils/writerControlAdapter.test.ts`

Expected: pass with the new trace assertions green.

- [ ] **Step 5: Commit**

```bash
git add frontend/src/utils/writerControlAdapter.ts frontend/src/utils/writerControlAdapter.test.ts
git commit -m "feat: add writer trace adapter APIs"
```

### Task 2: 新增 `writerTraceService`

**Files:**
- Create: `frontend/src/services/writerTraceService.ts`
- Create: `frontend/src/services/writerTraceService.test.ts`

- [ ] **Step 1: Write the failing test**

```ts
it('creates a fallback trace user and formats trace rows', () => {
  const user = createDefaultTraceUser({
    templateName: '西医病案首页',
    authorName: '张三',
  })

  expect(user.Name).toContain('张三')
  expect(formatTraceInfo({
    NativeHandle: 8,
    InfoType: 'Create',
    Text: '已修改内容',
    UserName: '张三',
    SaveTime: '2026-06-16T08:00:00Z',
  })).toMatchObject({
    typeLabel: '输入',
    summary: '已修改内容',
  })
})
```

- [ ] **Step 2: Run the focused test to verify it fails**

Run: `cd frontend && npm test -- src/services/writerTraceService.test.ts`

Expected: fail because the service file does not exist yet.

- [ ] **Step 3: Implement the service**

Add default-user generation, InfoType-to-label mapping, timestamp formatting, key generation, and summary truncation.

- [ ] **Step 4: Run the focused test to verify it passes**

Run: `cd frontend && npm test -- src/services/writerTraceService.test.ts`

Expected: pass.

- [ ] **Step 5: Commit**

```bash
git add frontend/src/services/writerTraceService.ts frontend/src/services/writerTraceService.test.ts
git commit -m "feat: normalize trace data for UI"
```

### Task 3: 给 WriterControl 宿主补上留痕初始化属性

**Files:**
- Modify: `frontend/src/composables/useCanvasRenderer.ts`
- Modify: `frontend/src/composables/useCanvasRenderer.test.ts`

- [ ] **Step 1: Write the failing test**

```ts
it('initializes trace-related security options on the writer host', () => {
  const host = createAttributeTarget()

  configureExternalWriterHost(host, 'template')

  expect(host.getAttribute('DocumentOptions.SecurityOptions.EnablePermission')).toBe('true')
  expect(host.getAttribute('DocumentOptions.SecurityOptions.EnableLogicDelete')).toBe('true')
  expect(host.getAttribute('DocumentOptions.SecurityOptions.ShowLogicDeletedContent')).toBe('true')
  expect(host.getAttribute('DocumentOptions.SecurityOptions.ShowPermissionTip')).toBe('false')
  expect(host.getAttribute('DocumentOptions.SecurityOptions.ShowPermissionMark')).toBe('false')
})
```

- [ ] **Step 2: Run the focused test to verify it fails**

Run: `cd frontend && npm test -- src/composables/useCanvasRenderer.test.ts`

Expected: fail because the attributes are not set yet.

- [ ] **Step 3: Implement the host attributes**

Extend `ExternalWriterElement` and `configureExternalWriterHost()` to apply the trace-related security attributes for template documents.

- [ ] **Step 4: Run the focused test to verify it passes**

Run: `cd frontend && npm test -- src/composables/useCanvasRenderer.test.ts`

Expected: pass.

- [ ] **Step 5: Commit**

```bash
git add frontend/src/composables/useCanvasRenderer.ts frontend/src/composables/useCanvasRenderer.test.ts
git commit -m "feat: enable trace security options on writer host"
```

### Task 4: 新增 `WriterTracesPanel.vue`

**Files:**
- Create: `frontend/src/components/editor/WriterTracesPanel.vue`
- Create: `frontend/src/components/editor/WriterTracesPanel.test.ts`

- [ ] **Step 1: Write the failing test**

```ts
it('renders trace rows and emits refresh, login, view mode, and selection events', async () => {
  const html = await renderTracesPanel([
    {
      NativeHandle: 12,
      InfoType: 'Create',
      Text: '已修改内容',
      UserName: '张三',
      SaveTime: '2026-06-16 08:00',
    },
  ])

  expect(html).toContain('修改留痕')
  expect(html).toContain('已修改内容')
  expect(html).toContain('张三')
})
```

- [ ] **Step 2: Run the focused test to verify it fails**

Run: `cd frontend && npm test -- src/components/editor/WriterTracesPanel.test.ts`

Expected: fail because the component does not exist yet.

- [ ] **Step 3: Implement the panel**

Mirror the style and density of `WriterCommentsPanel.vue`, with toolbar buttons, view-mode toggles, empty/error states, and clickable trace rows.

- [ ] **Step 4: Run the focused test to verify it passes**

Run: `cd frontend && npm test -- src/components/editor/WriterTracesPanel.test.ts`

Expected: pass.

- [ ] **Step 5: Commit**

```bash
git add frontend/src/components/editor/WriterTracesPanel.vue frontend/src/components/editor/WriterTracesPanel.test.ts
git commit -m "feat: add trace list panel"
```

### Task 5: 把留痕状态接入 `WorkbenchEditorArea` 和 `EditorShell`

**Files:**
- Modify: `frontend/src/components/editor/WorkbenchEditorArea.vue`
- Modify: `frontend/src/components/editor/EditorShell.vue`

- [ ] **Step 1: Write the failing test**

Add or extend component tests so the editor area renders the trace panel props/events and the shell refreshes traces after writer ready, content change, and mode changes.

- [ ] **Step 2: Run the focused test to verify it fails**

Run: `cd frontend && npm test -- src/components/editor/WorkbenchEditorArea.test.ts src/components/editor/EditorShell.test.ts`

- [ ] **Step 3: Wire the state and events**

Add `writerTraces`, `writerTraceError`, `writerTraceViewMode`, and `writerTraceUser` state in `EditorShell.vue`; login on writer ready; refresh traces on content changes; emit click-to-navigate through the adapter; pass the new props/events through `WorkbenchEditorArea.vue`.

- [ ] **Step 4: Run the focused tests to verify they pass**

Run: `cd frontend && npm test -- src/components/editor/WorkbenchEditorArea.test.ts src/components/editor/EditorShell.test.ts`

- [ ] **Step 5: Commit**

```bash
git add frontend/src/components/editor/WorkbenchEditorArea.vue frontend/src/components/editor/EditorShell.vue
git commit -m "feat: wire trace panel into editor shell"
```

### Task 6: 给顶部菜单增加留痕入口

**Files:**
- Modify: `frontend/src/components/editor/commandRegistry.ts`
- Modify: `frontend/src/components/editor/WorkbenchTopMenu.vue`
- Modify: `frontend/src/components/editor/commandRegistry.test.ts`
- Modify: `frontend/src/components/editor/WorkbenchTopMenu.test.ts`

- [ ] **Step 1: Write the failing test**

```ts
expect(findCommandDefinition('traceRefresh')?.kind).toBe('app')
expect(findCommandDefinition('traceCleanView')?.kind).toBe('app')
expect(findCommandDefinition('traceComplexView')?.kind).toBe('app')
expect(findCommandDefinition('traceLogin')?.kind).toBe('app')
```

- [ ] **Step 2: Run the focused test to verify it fails**

Run: `cd frontend && npm test -- src/components/editor/commandRegistry.test.ts src/components/editor/WorkbenchTopMenu.test.ts`

- [ ] **Step 3: Add the commands and toolbar handling**

Add a `审阅` tab or equivalent留痕分组，接入登录、刷新、清洁模式和留痕模式命令，并让 `EditorShell` 处理这些 app commands。

- [ ] **Step 4: Run the focused tests to verify they pass**

Run: `cd frontend && npm test -- src/components/editor/commandRegistry.test.ts src/components/editor/WorkbenchTopMenu.test.ts`

- [ ] **Step 5: Commit**

```bash
git add frontend/src/components/editor/commandRegistry.ts frontend/src/components/editor/WorkbenchTopMenu.vue frontend/src/components/editor/commandRegistry.test.ts frontend/src/components/editor/WorkbenchTopMenu.test.ts
git commit -m "feat: add trace commands to ribbon"
```

### Task 7: 全量验证

**Files:**
- No new files

- [ ] **Step 1: Run the full frontend test suite**

Run: `cd frontend && npm test`

- [ ] **Step 2: Run the frontend build**

Run: `cd frontend && npm run build`

- [ ] **Step 3: Review any runtime issues**

If the local DCWriter runtime is available, open the app in the browser and verify trace login, list refresh, navigation, and clean/complex mode switching end to end.

### Task 8: 收尾检查

**Files:**
- No new files

- [ ] **Step 1: Check the final diff**

Run: `git -C D:/DCWriterLite/emr-web-editor-demo/.worktrees/emr-web-editor-mvp status --short`

- [ ] **Step 2: Confirm the feature scope stays limited**

Verify that no XML diff/merge workflow or backend trace persistence was introduced.

