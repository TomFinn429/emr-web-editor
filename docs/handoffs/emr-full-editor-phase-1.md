# 都昌电子病历编辑器完整版迭代第一阶段交接

## 第一阶段完成清单

- 已搭建完整版电子病历模板制作工作台骨架：顶部菜单、左侧模板树、中左辅助面板、中间 DCWriter 编辑区、右侧属性栏、底部状态栏。
- 顶部菜单已包含：文件、格式、段落、常规、设计、表格、插入、高级。
- 左侧模板树已包含：分类筛选、关键字搜索、模板分类、模板文件节点、待上传状态、更多操作入口。
- 中左辅助面板已包含：元数据、片段模板两个页签。
- 右侧属性面板已包含：模板属性、元素属性两个页签。
- 已建立统一 `commandRegistry`，用于管理菜单命令、应用命令、WriterControl 命令和后续占位命令。
- 已建立 `templateWorkbenchService` mock/service 数据边界，模板树、元数据、片段模板、属性数据集中在 service 层。
- 已保留并接通当前 MVP 已有保存、下载 XML、打印、打印预览、关闭打印预览、基础编辑命令。
- 未重写底层 DCWriter / WriterControl 渲染与打印引擎。

## 修改文件列表

- `frontend/src/types/document.ts`
- `frontend/src/components/editor/EditorShell.vue`
- `frontend/src/components/editor/WorkbenchTopMenu.vue`
- `frontend/src/components/editor/TemplateTreePanel.vue`
- `frontend/src/components/editor/TemplateTreeNode.vue`
- `frontend/src/components/editor/WorkbenchAssistPanel.vue`
- `frontend/src/components/editor/WorkbenchEditorArea.vue`
- `frontend/src/components/editor/PropertyInspectorPanel.vue`
- `frontend/src/components/editor/commandRegistry.ts`
- `frontend/src/components/editor/commandRegistry.test.ts`
- `frontend/src/services/templateWorkbenchService.ts`
- `frontend/src/services/templateWorkbenchService.test.ts`
- `docs/handoffs/emr-full-editor-phase-1.md`

## 当前组件结构

- `EditorShell.vue`：完整版工作台组合层，负责会话状态、WriterControl 适配、保存、打印、预览、XML 导入和子组件事件分发。
- `WorkbenchTopMenu.vue`：顶部菜单和工具条，根据 `commandRegistry` 渲染命令。
- `TemplateTreePanel.vue`：左侧模板列表、分类筛选、搜索和树入口。
- `TemplateTreeNode.vue`：模板树递归节点。
- `WorkbenchAssistPanel.vue`：中左辅助区，承载元数据和片段模板。
- `WorkbenchEditorArea.vue`：中间文档标签、状态提示、`CanvasPreview` 和校验面板。
- `PropertyInspectorPanel.vue`：右侧模板属性和元素属性。
- `CanvasPreview.vue`、`useCanvasRenderer.ts`、`writerControlAdapter.ts`、`writerPrint.ts`：继续作为 DCWriter/WriterControl 能力接入层。

## Command Registry 设计说明

`commandRegistry.ts` 将命令分为三类：

- `app`：应用层命令，不直接走 WriterControl，例如保存、下载 XML、导入 XML、打印、打印预览、关闭预览、清空、缩放。
- `writer`：WriterControl 命令，包含 `WriterCommandPayload`，由 `EditorShell` 调用 `writerControlAdapter.executeCommand` 执行。
- `placeholder`：第一阶段只展示入口，暂不接真实能力，例如上传、取消上传、历史版本、审批、数据元、字典、数据源、权限控制。

命令入口统一由 `WorkbenchTopMenu.vue` 渲染，由 `EditorShell.vue` 按 `kind` 分发。二阶段扩展时应优先扩展 registry 和 service，而不是把新命令散落到组件内部。

## Service/Mock 数据边界

`templateWorkbenchService.ts` 是第一阶段新增的工作台数据边界，当前提供 mock 数据：

- `fetchTemplateWorkbenchData()`：返回模板树、分类、元数据、片段模板、模板属性、元素属性。
- `filterTemplateTree()`：统一处理分类和关键字过滤。
- `findTemplateTreeNode()`：按 id 查找模板树节点。

当前真实模板 XML 内容仍通过已有 `templateService.ts` 的 `/api/templates/{id}` 读取；工作台外围数据先走 mock service。后续模板 CRUD、上传、审批、历史版本、数据元/字典/数据源管理都应从该 service 边界继续接入真实 API。

## 已接通的 WriterControl 命令

- 撤销：`Undo`
- 重做：`Redo`
- 复制：`Copy`
- 剪切：`Cut`
- 粘贴：`Paste`
- 全选：`selectall`
- 加粗：`Bold`
- 斜体：`Italic`
- 下划线：`Underline`
- 左对齐：`AlignLeft`
- 居中：`AlignCenter`
- 右对齐：`AlignRight`
- 输入域：`InsertInputField`
- 日期时间：`InsertDateTimeField`
- 勾选框/单选框：`InsertCheckBoxOrRadio`
- 插入表格：`InsertTable`
- 删除表格：`Table_DeleteTable`
- 插入行/列：`Table_InsertRowUp`、`Table_InsertRowDown`、`Table_InsertColumnLeft`、`Table_InsertColumnRight`
- 合并/拆分单元格：`Table_MergeCell`、`Table_SplitCellExt`
- 表格/行/单元格属性：`tableproperties`、`tablerowproperties`、`tablecellproperties`
- 分页符：`insertpagebreak`
- 页码：`InsertPageInfoElement`

保存、打印、打印预览继续复用已有适配：

- 保存：`SaveDocumentToString({ FileFormat: 'XML' })` + `documentSaveService`
- 打印：`PrintDocument` 或 `Print`
- 打印预览：`LoadPrintPreview`
- 关闭打印预览：`ClosePrintPreview`

## 未完成事项

- 未接真实后端模板 CRUD。
- 未接真实上传、取消上传、审批流。
- 未实现完整历史版本。
- 未实现完整数据元、字典、值域、数据源后台管理。
- 未接全量高级 WriterControl 命令。
- 右侧元素属性目前是 mock 占位，尚未监听 WriterControl 当前元素选择。
- 中左元数据和片段模板目前只展示入口，尚未实现拖拽/插入。

## 第二阶段推荐入口

1. 从 `templateWorkbenchService.ts` 开始，把 mock 数据替换为真实 API。
2. 从 `commandRegistry.ts` 开始补齐上传、审批、历史版本、数据元/字典/数据源管理命令。
3. 在 `writerControlAdapter.ts` 增加“当前元素选择/属性读取/属性更新”的薄适配，不要直接在属性组件里访问 WriterControl 私有结构。
4. 在 `WorkbenchAssistPanel.vue` 为元数据和片段模板增加插入行为，命令仍经 `EditorShell` 分发。
5. 为模板 CRUD 和上传审批补 service 单元测试，再接 UI。

## 禁止二阶段推翻的一阶段决策

- 不要重写 DCWriter / WriterControl 渲染与打印引擎。
- 不要把模板 CRUD、上传、审批、历史版本逻辑散落在 Vue 组件里，必须经过 service 边界。
- 不要绕过 `commandRegistry` 直接在按钮里硬编码 WriterControl 命令。
- 不要把 `EditorShell.vue` 重新做成超大展示组件；复杂 UI 应继续拆到工作台子组件。
- 不要破坏现有保存、打印、打印预览、XML 导入和基础编辑命令链路。

## 验收命令与结果

- `npm test`
  - 结果：已通过，14 个测试文件，81 个测试。
- `npm run build`
  - 结果：已通过，`vue-tsc -b` 与 `vite build` 均成功。
- MCP Playwright 本地页面验证
  - 结果：已打开 `http://127.0.0.1:5173/` 验证工作台首屏。
  - 已确认顶部八个菜单、左侧模板树、中左元数据/片段模板、中央 DCWriter 编辑区、右侧模板属性/元素属性均可见。
  - 已确认点击模板节点后仍复用当前 XML 加载链路，并进入外部渲染模式。
  - 已确认保存入口可用，保存后状态保持为“已保存”。
  - 已确认打印预览入口可用，点击后进入打印预览状态。
  - 已确认打印入口可用，点击后触发浏览器原生打印流程；该流程会占用 Playwright 会话，后续自动化验证避免重复点击打印。
