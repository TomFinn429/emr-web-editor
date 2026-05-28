# pTemplateMake High Fidelity MVP Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Build a high-fidelity MVP restoration of the `pTemplateMake` template authoring workbench on top of the existing editor workbench.

**Architecture:** Keep `EditorShell.vue` as the composition surface and extend the current service, command registry, and focused child panels. Mock/domain data stays in `templateWorkbenchService.ts`; Vue components consume typed props and emit events; WriterControl access stays behind existing adapters and composables.

**Tech Stack:** Vue 3, `<script setup lang="ts">`, Vite, Vitest, lucide-vue-next, existing DCWriter adapter utilities.

---

## File Map

- Modify: `frontend/src/services/templateWorkbenchService.ts`
  - Add template scopes, scope-aware tree filtering, richer template properties, and mock defaults that mirror the target page.
- Modify: `frontend/src/services/templateWorkbenchService.test.ts`
  - Cover scope filter behavior and target-page template property fields.
- Modify: `frontend/src/types/document.ts`
  - Add command ids for target-page Ribbon entries that are not yet represented.
- Modify: `frontend/src/components/editor/commandRegistry.ts`
  - Reorder/expand Ribbon entries to match the target page: file, edit, format, paragraph, insert, design, table, advanced.
- Modify: `frontend/src/components/editor/commandRegistry.test.ts`
  - Assert menu order, new entries, disabled placeholders, and writer payloads.
- Create: `frontend/src/components/editor/elementPropertySchema.ts`
  - Centralize element property field definitions for input fields, cells, rows, and tables.
- Create: `frontend/src/components/editor/elementPropertySchema.test.ts`
  - Verify schema fields and patch coercion for text, number, boolean, and select controls.
- Modify: `frontend/src/types/editorElement.ts`
  - Add optional target-page element properties while preserving existing adapter compatibility.
- Modify: `frontend/src/components/editor/ElementPropertiesPanel.vue`
  - Render fields from schema instead of hard-coded branches.
- Modify: `frontend/src/components/editor/TemplatePropertiesPanel.vue`
  - Display target-page template fields: type, print mode, repeat permission, sign level, departments, authors, updater.
- Modify: `frontend/src/components/editor/TemplateTreePanel.vue`
  - Add target-page scope selector and top action menu while preserving category/keyword filtering.
- Modify: `frontend/src/components/editor/WorkbenchTopMenu.vue`
  - Add icons for newly introduced commands and preserve disabled-state feedback.
- Modify: `frontend/src/components/editor/EditorShell.vue`
  - Pass template scopes into `TemplateTreePanel`; handle new app placeholder commands with status feedback where needed.

## Component Map

- `EditorShell.vue`: orchestrates loading, current template state, command dispatch, and child panel events.
- `TemplateTreePanel.vue`: owns only local filter UI state and emits tree actions upward.
- `WorkbenchTopMenu.vue`: renders the command registry and emits command ids.
- `TemplatePropertiesPanel.vue`: read-only target-page template metadata view.
- `ElementPropertiesPanel.vue`: schema-driven element property editor; emits typed patches.
- `elementPropertySchema.ts`: pure, testable field definitions and patch coercion helpers.

## Task 1: Template Scopes And Properties

**Files:**
- Modify: `frontend/src/services/templateWorkbenchService.ts`
- Test: `frontend/src/services/templateWorkbenchService.test.ts`

- [ ] **Step 1: Write failing service tests**

Add tests that expect:

```ts
it('returns target-page template scopes and filters tree by scope', async () => {
  const data = await fetchTemplateWorkbenchData()

  expect(data.templateScopes.map(scope => scope.label)).toEqual(['全局', '全院', '科室', '个人'])
  expect(data.templateScopes[0]).toMatchObject({ id: 'global', label: '全局' })

  const departmentOnly = filterTemplateTree(data.templateTree, {
    category: '全部分类',
    keyword: '',
    scope: 'department',
  })

  expect(departmentOnly[0]?.children?.flatMap(node => node.children || []).every(node => node.scope === 'department')).toBe(true)
})

it('exposes target-page template property fields', async () => {
  const data = await fetchTemplateWorkbenchData('西医病案首页')

  expect(data.templateProperties).toMatchObject({
    type: '病案模板',
    printMode: '套打',
    allowRepeat: false,
    signLevel: '二级签名',
    departments: ['全院', '病案室'],
    author: '模板制作员',
    updatedBy: '模板制作员',
  })
})
```

- [ ] **Step 2: Verify RED**

Run: `cd frontend && npm test -- src/services/templateWorkbenchService.test.ts`

Expected: FAIL because `templateScopes`, `scope`, and the richer template property fields do not exist yet.

- [ ] **Step 3: Implement minimal service changes**

Add:

```ts
export type TemplateScopeId = 'global' | 'hospital' | 'department' | 'personal'

export interface TemplateScopeOption {
  id: TemplateScopeId
  label: string
}
```

Extend `TemplateTreeNode`, `TemplateProperties`, `TemplateWorkbenchData`, `TemplateTreeFilter`, and `TemplateRecord` with scope and property fields. Add deterministic defaults in `templateRecord()` and `createTemplateFile()`.

- [ ] **Step 4: Verify GREEN**

Run: `cd frontend && npm test -- src/services/templateWorkbenchService.test.ts`

Expected: PASS.

## Task 2: Ribbon Command Registry

**Files:**
- Modify: `frontend/src/types/document.ts`
- Modify: `frontend/src/components/editor/commandRegistry.ts`
- Modify: `frontend/src/components/editor/WorkbenchTopMenu.vue`
- Test: `frontend/src/components/editor/commandRegistry.test.ts`

- [ ] **Step 1: Write failing command tests**

Add expectations that:

```ts
expect(topMenuTabs.map(tab => tab.label)).toEqual([
  '文件',
  '编辑',
  '格式',
  '段落',
  '插入',
  '设计',
  '表格',
  '高级',
])
expect(findCommandDefinition('strikethrough')).toMatchObject({ kind: 'writer', label: '删除线' })
expect(findCommandDefinition('specialCharacter')).toMatchObject({ kind: 'placeholder', label: '特殊字符' })
expect(findCommandDefinition('refreshDocument')).toMatchObject({ kind: 'app', label: '刷新文档' })
expect(findCommandDefinition('xmlSource')).toMatchObject({ kind: 'placeholder', label: 'XML 源码' })
```

- [ ] **Step 2: Verify RED**

Run: `cd frontend && npm test -- src/components/editor/commandRegistry.test.ts`

Expected: FAIL because the edit tab and target-page ids are missing.

- [ ] **Step 3: Implement registry and icon support**

Add the command ids to `document.ts`, insert the `编辑` tab, move clipboard commands there, add target-page entries, and add required lucide icons in `WorkbenchTopMenu.vue`.

- [ ] **Step 4: Verify GREEN**

Run: `cd frontend && npm test -- src/components/editor/commandRegistry.test.ts`

Expected: PASS.

## Task 3: Element Property Schema

**Files:**
- Create: `frontend/src/components/editor/elementPropertySchema.ts`
- Create: `frontend/src/components/editor/elementPropertySchema.test.ts`
- Modify: `frontend/src/types/editorElement.ts`

- [ ] **Step 1: Write failing schema tests**

Create tests that expect:

```ts
expect(getElementPropertySchema('input-field').map(field => field.key)).toEqual(expect.arrayContaining([
  'id',
  'name',
  'placeholder',
  'border',
  'textAlign',
  'fixedWidth',
  'dataSourceName',
  'bindingPath',
  'textBindingPath',
  'inputFormat',
  'outputFormat',
  'readonly',
  'validationRule',
  'calculateExpression',
  'visibleExpression',
  'printVisibleExpression',
  'textColor',
  'backgroundTextColor',
  'customProperties',
  'printVisible',
]))
expect(createElementPropertyPatch(field, '42')).toEqual({ fixedWidth: 42 })
expect(createElementPropertyPatch(readonlyField, true)).toEqual({ readonly: true })
```

- [ ] **Step 2: Verify RED**

Run: `cd frontend && npm test -- src/components/editor/elementPropertySchema.test.ts`

Expected: FAIL because the schema file does not exist.

- [ ] **Step 3: Implement schema and types**

Add optional properties to `EditorElementProperties` and export:

```ts
export function getElementPropertySchema(type: EditorElementType): ElementPropertyField[]
export function createElementPropertyPatch(field: ElementPropertyField, value: string | boolean): Partial<EditorElementProperties>
```

- [ ] **Step 4: Verify GREEN**

Run: `cd frontend && npm test -- src/components/editor/elementPropertySchema.test.ts`

Expected: PASS.

## Task 4: Schema-Driven Element Panel

**Files:**
- Modify: `frontend/src/components/editor/ElementPropertiesPanel.vue`

- [ ] **Step 1: Run existing tests before UI change**

Run: `cd frontend && npm test -- src/components/editor/elementPropertySchema.test.ts`

Expected: PASS.

- [ ] **Step 2: Render schema fields**

Replace the large type-specific template branches with a computed schema and generic field renderer for text, number, checkbox, select, and textarea controls.

- [ ] **Step 3: Verify build type safety**

Run: `cd frontend && npm run build`

Expected: PASS.

## Task 5: Template Tree And Template Properties UI

**Files:**
- Modify: `frontend/src/components/editor/TemplateTreePanel.vue`
- Modify: `frontend/src/components/editor/TemplatePropertiesPanel.vue`
- Modify: `frontend/src/components/editor/EditorShell.vue`

- [ ] **Step 1: Wire service data into components**

Pass `templateScopes` into `TemplateTreePanel.vue` and include `scope` in `filterTemplateTree()`.

- [ ] **Step 2: Add target-page tree controls**

Render scope selector labels `全局 / 全院 / 科室 / 个人`, keep category select and keyword search, and keep top icon actions for new folder and template.

- [ ] **Step 3: Add target-page template property rows**

Render rows for name, category, type, print mode, allow repeat, sign level, departments, author, updatedBy, updatedAt, status, version, file, and upload message.

- [ ] **Step 4: Verify service tests and build**

Run:

```bash
cd frontend && npm test -- src/services/templateWorkbenchService.test.ts
cd frontend && npm run build
```

Expected: PASS.

## Task 6: Integration Verification

**Files:**
- No production file should change unless verification exposes a defect.

- [ ] **Step 1: Run focused tests**

Run:

```bash
cd frontend && npm test -- src/services/templateWorkbenchService.test.ts src/components/editor/commandRegistry.test.ts src/components/editor/elementPropertySchema.test.ts
```

Expected: PASS.

- [ ] **Step 2: Run full test suite**

Run: `cd frontend && npm test`

Expected: PASS.

- [ ] **Step 3: Run production build**

Run: `cd frontend && npm run build`

Expected: PASS.

- [ ] **Step 4: Browser verification**

Start dev server with `cd frontend && npm run dev -- --host 127.0.0.1 --port 5173`, then use MCP Playwright to verify:

- The left panel shows scope selector, search, tree, state badges, and create actions.
- Ribbon tabs include file, edit, format, paragraph, insert, design, table, advanced.
- Template properties include target-page fields.
- Element properties render input-field schema fields and can emit changes without layout breakage.
