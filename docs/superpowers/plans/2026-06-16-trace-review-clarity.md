# Trace Review Clarity Implementation Plan

> **For agentic workers:** REQUIRED SUB-SKILL: Use superpowers:subagent-driven-development (recommended) or superpowers:executing-plans to implement this plan task-by-task. Steps use checkbox (`- [ ]`) syntax for tracking.

**Goal:** Make each DCWriter track-change record clearly show who changed which text and whether it was inserted or deleted.

**Architecture:** Keep DCWriter as the source of truth for inline marks and navigation. Add review semantics in `writerTraceService`, then render a compact Word-like review panel in `WriterTracesPanel` with author colors, action badges, filtering, and selected trace detail.

**Tech Stack:** Vue 3 SFC with `<script setup lang="ts">`, Vitest SSR component tests, existing WriterControl adapter APIs.

---

### Task 1: Trace Formatting Semantics

**Files:**
- Modify: `frontend/src/services/writerTraceService.ts`
- Test: `frontend/src/services/writerTraceService.test.ts`

- [ ] Add failing tests for trace action kind, action symbol, author color token, and review title.
- [ ] Run `npm test -- writerTraceService.test.ts` and verify the new tests fail.
- [ ] Extend `FormattedWriterTrace` and `formatTraceInfo()` with review-facing fields.
- [ ] Run `npm test -- writerTraceService.test.ts` and verify the tests pass.

### Task 2: Review Panel Rendering

**Files:**
- Modify: `frontend/src/components/editor/WriterTracesPanel.vue`
- Test: `frontend/src/components/editor/WriterTracesPanel.test.ts`

- [ ] Add failing SSR tests for action badges, author legend, filter controls, and selected detail.
- [ ] Run `npm test -- WriterTracesPanel.test.ts` and verify the new tests fail.
- [ ] Render author/action chips, text previews, filters, and selected-trace detail.
- [ ] Run `npm test -- WriterTracesPanel.test.ts` and verify the tests pass.

### Task 3: Active Trace Wiring

**Files:**
- Modify: `frontend/src/components/editor/WorkbenchEditorArea.vue`
- Modify: `frontend/src/components/editor/EditorShell.vue`
- Test: `frontend/src/components/editor/WorkbenchEditorArea.test.ts`

- [ ] Add failing tests that active trace state reaches the panel.
- [ ] Run `npm test -- WorkbenchEditorArea.test.ts` and verify the new tests fail.
- [ ] Store selected `NativeHandle` in `EditorShell` and pass it through `WorkbenchEditorArea`.
- [ ] Run `npm test -- WorkbenchEditorArea.test.ts` and verify the tests pass.

### Task 4: Verification

- [ ] Run `npm test`.
- [ ] Run `npm run build`.
- [ ] Open the local page and verify multi-user insert/delete records are distinguishable in the review panel.
