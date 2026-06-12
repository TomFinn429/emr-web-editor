# 实时修改留痕设计

## 背景

当前 `emr-web-editor-mvp` 已经把 DCWriter / WriterControl 接入到 Vue 工作台中，并通过 `writerControlAdapter.ts` 集中封装文档加载、保存、命令执行、打印和原生批注。近期提交也已经将保存校验和原生批注流程拆开，说明后续 WriterControl 能力应继续走 adapter 边界，而不是在 Vue 组件里直接调用底层控件。

本阶段要补的是 DCWriter 的实时修改留痕能力，范围限定为：实时留痕浏览、点击定位、清洁视图和留痕视图切换。两版 XML 对比生成留痕文档不纳入本阶段。

## 已确认依据

DCWriterApp 中可参考三份页面和一份运行时 API：

- `DCWriterApp/iframeHTML/Authority/RealTimeTrack.html`：实时留痕登录和视图切换示例，使用 `UserLoginByUserLoginInfo`、`ComplexViewMode`、`CleanViewMode` 和 `SecurityOptions.TrackVisibleLevel1`。
- `DCWriterApp/iframeHTML/Authority/TraceList.html`：留痕列表示例，使用 `UserLoginByParameter`、`GetDocumentUserTrackInfos()` 和 `NavigateByUserTrackInfo(NativeHandle)`。
- `DCWriterApp/iframeHTML/Authority/ContrastTrack.html`：两版文档对比示例，本阶段只作为非目标记录。
- `backend/renderer-runtime/_framework/WriterControl_API.js`：当前 MVP 携带的运行时已经暴露 `UserLoginByUserLoginInfo`、`UserLoginByParameter`、`GetDocumentUserTrackInfos`、`NavigateByUserTrackInfo`、`ComplexViewMode`、`CleanViewMode`、`InComplexViewMode` 和 `InCleanViewMode`。

## 目标

本阶段目标是让模板制作工作台能直接查看当前文档中的 WriterControl 原生留痕，并能在留痕列表和文档正文之间联动。

- 编辑器加载后以当前演示操作人登录 WriterControl 留痕系统。
- 用户可以切换清洁视图和留痕视图。
- 用户可以刷新并浏览当前文档的留痕列表。
- 留痕列表展示操作人、操作类型、内容摘要和修改时间。
- 点击留痕项后定位到正文对应痕迹位置。
- 文档内容变化后自动刷新留痕列表。
- 保存和下载 XML 继续复用现有保存链路，保留 WriterControl 序列化出的留痕信息。

## 非目标

本阶段不实现以下能力：

- 不做两版历史 XML 的对比合并，不调用 `MergeDocumentByFileContent2`。
- 不接真实医院账号、权限系统或后端审计接口。
- 不实现留痕接受、拒绝、提交、清空等审阅工作流。
- 不自行解析 XML 生成前端 diff。
- 不改写 DCWriter / WriterControl 原生留痕渲染规则。
- 不把留痕数据存到单独后端表，本阶段以 WriterControl 原生 XML 序列化结果为准。

## 推荐方案

采用“原生能力封装 + Vue 面板展示”的增量方案。

WriterControl 负责记录、渲染和定位留痕；Vue 只负责登录当前操作人、调用模式切换命令、读取留痕列表、展示列表并转发点击定位。这样能保留 DCWriter 原生行为，也符合当前项目“WriterControl 访问集中在 adapter/composable”的既有约束。

当前项目没有真实登录态，因此本阶段使用一个前端演示操作人作为留痕登录信息。默认值由 `writerTraceService` 集中维护，优先取模板属性中的更新者或作者作为显示名；后续接真实登录后，只替换 service 的操作人来源，不改面板和 adapter 契约。

## 架构设计

### WriterControl 适配层

扩展 `writerControlAdapter.ts`，新增留痕相关类型和方法。

新增类型：

- `WriterTraceUser`：`ID`、`Name`、`ClientName`、`PermissionLevel`、`Description`。
- `WriterTraceInfo`：兼容 WriterControl 返回结构，至少支持 `NativeHandle`、`InfoType`、`Text`、`UserName`、`SaveTime`。
- `WriterTraceViewMode`：`complex` 或 `clean`。
- `WriterTraceListResult`：`{ ok: true; traces: WriterTraceInfo[] }` 或 adapter 失败结构。

新增方法：

- `loginTraceUser(user: WriterTraceUser)`：优先调用 `UserLoginByUserLoginInfo(user, true)`，缺失时降级到 `UserLoginByParameter(user.ID, user.Name, user.PermissionLevel)`。
- `setTraceViewMode(mode: WriterTraceViewMode)`：`complex` 调 `ComplexViewMode()` 或 `DCExecuteCommand('ComplexViewMode')`；`clean` 调 `CleanViewMode()` 或 `DCExecuteCommand('CleanViewMode')`。
- `getTraceViewMode()`：优先使用 `InComplexViewMode()` / `InCleanViewMode()`，不可用时返回 `null`。
- `getTraceList(options?: { cleanMode?: boolean })`：调用 `GetDocumentUserTrackInfos(cleanMode)`，返回数组时透传，非数组时归一为空数组。
- `navigateToTrace(nativeHandle: number)`：调用 `NavigateByUserTrackInfo(nativeHandle)`，失败时返回结构化错误。
- `applyTraceVisualOptions()`：如果 `DocumentOptions.SecurityOptions.TrackVisibleLevel1` 存在，则应用 RealTimeTrack 示例中的删除线、下划线和背景色配置，再调用 `ApplyDocumentOptions()`。

新增失败原因：

- `trace-api-unavailable`：当前 WriterControl 不支持留痕接口。
- 复用 `writer-unavailable`、`command-rejected` 等已有失败类型。

### 渲染宿主

扩展 `useCanvasRenderer.ts` 的 WriterControl 类型声明和宿主属性。

宿主属性继续保持模板文档可编辑、非模板只读。新增与留痕相关的初始化属性：

- `DocumentOptions.SecurityOptions.EnablePermission`
- `DocumentOptions.SecurityOptions.EnableLogicDelete`
- `DocumentOptions.SecurityOptions.ShowLogicDeletedContent`
- `DocumentOptions.SecurityOptions.ShowPermissionTip`
- `DocumentOptions.SecurityOptions.ShowPermissionMark`

这些属性与 `TraceList.html` 的初始化保持一致。实际登录后，当前运行时的 `UserLoginByUserLoginInfo` / `UserLoginByParameter` 也会再次同步启用这些选项。

### 留痕服务

新增 `writerTraceService.ts`，负责纯数据归一和默认操作人生成。

职责：

- 从模板属性或本地默认值生成 `WriterTraceUser`。
- 将 `InfoType` 映射为中文操作类型：
  - `Create` -> `输入`
  - `Checked` -> `勾选`
  - `UnChecked` -> `去掉勾选`
  - `Delete` -> `删除`
  - 其他类型显示原始值或 `修改`
- 格式化 `SaveTime`，无效时间显示为空。
- 生成列表 key，优先使用 `NativeHandle`，否则使用用户、时间和索引组合。
- 截断过长正文摘要，但保留完整内容在 `title` 中。

### Vue 组件边界

#### `WriterTracesPanel.vue`

新增底部留痕面板，保持与 `WriterCommentsPanel.vue` 相近的密度和风格。

单一职责：展示留痕列表、工具按钮和点击事件。

Props：

- `traces: readonly WriterTraceInfo[]`
- `viewMode: WriterTraceViewMode | null`
- `currentUser: WriterTraceUser | null`
- `errorMessage?: string | null`
- `canUseTraces: boolean`

Emits：

- `refreshTraces`
- `loginTraceUser`
- `viewModeChange: [mode: WriterTraceViewMode]`
- `selectTrace: [trace: WriterTraceInfo]`

界面元素：

- 标题：`修改留痕` 和数量。
- 工具按钮：登录、刷新、留痕模式、清洁模式。
- 列表项：操作人、操作类型、正文摘要、修改时间。
- 空态：`暂无留痕`。
- 错误态：展示 adapter 返回的结构化错误。

#### `WorkbenchEditorArea.vue`

继续作为编辑区组合组件，新增留痕相关 props 和 emits，并渲染 `WriterTracesPanel.vue`。

第一版采用独立底部面板，不重构现有 `WriterCommentsPanel.vue`。如果后续底部空间变紧，再把批注和留痕合并成一个 `审阅` 标签面板。

#### `EditorShell.vue`

继续作为跨区域编排层。

新增状态：

- `writerTraces`
- `writerTraceError`
- `writerTraceViewMode`
- `writerTraceUser`

新增行为：

- WriterControl ready 后生成默认留痕用户并登录。
- 登录成功后读取当前视图模式和留痕列表。
- 内容变化监听中，在刷新批注之后刷新留痕列表。
- 切换清洁/留痕视图时调用 adapter，成功后刷新视图模式和列表。
- 点击留痕项时调用 `navigateToTrace`，失败时写入状态栏消息。

### Ribbon 入口

在 `commandRegistry.ts` 中新增 `审阅` 或 `高级` 下的留痕命令。为了让功能入口更清晰，推荐新增 `审阅` 标签，包含一个 `留痕` 分组。

命令：

- `traceLogin`：登录/重新登录演示操作人。
- `traceComplexView`：留痕模式。
- `traceCleanView`：清洁模式。
- `traceRefresh`：刷新留痕。

这些命令作为 app command 处理，由 `EditorShell` 调用 adapter，不作为普通 writer command，避免在按钮里硬编码 WriterControl 命令。

## 数据流

### 文档加载

1. 用户打开模板或导入本地 XML。
2. `useCanvasRenderer` 创建 WriterControl 宿主并加载 XML。
3. `EditorShell.updateWriterElement()` 收到 WriterControl 实例。
4. `EditorShell` 生成默认 `WriterTraceUser`。
5. adapter 调用 `loginTraceUser()`。
6. adapter 调用 `applyTraceVisualOptions()`。
7. adapter 查询 `getTraceViewMode()` 和 `getTraceList()`。
8. `WriterTracesPanel` 展示当前列表。

### 编辑和自动刷新

1. 用户在 WriterControl 中编辑正文、删除内容或勾选控件。
2. WriterControl 原生记录留痕。
3. 既有 `onContentChanged()` 回调触发。
4. `EditorShell` 标记文档 dirty，并刷新批注和留痕列表。
5. 面板展示新增或变化后的留痕项。

### 模式切换

1. 用户点击 `留痕模式` 或 `清洁模式`。
2. `EditorShell` 调用 `setTraceViewMode(mode)`。
3. 成功后刷新 WriterControl 视图和 `writerTraceViewMode`。
4. 再调用 `getTraceList()` 更新列表。
5. 失败时在留痕面板和状态栏展示错误。

### 点击定位

1. 用户点击某条留痕。
2. `WriterTracesPanel` 发出 `selectTrace`。
3. `EditorShell` 校验 `NativeHandle` 是否为数字。
4. adapter 调用 `NavigateByUserTrackInfo(NativeHandle)`。
5. WriterControl 将光标或视图定位到对应痕迹。

## 错误处理

- WriterControl 未加载：按钮禁用，面板显示 `外部编辑器尚未加载，无法读取留痕。`
- 留痕 API 缺失：面板显示 `当前外部编辑器未暴露留痕接口。`
- 登录失败：保留面板可见，提示登录失败，刷新和模式切换仍按 API 可用性决定。
- 列表为空：显示空态，不当作错误。
- `NativeHandle` 缺失：该项不可定位，但仍可展示。
- 定位返回 `false`：提示当前阅读、预览或控件状态不允许定位。
- 时间解析失败：不抛异常，时间字段显示为空。

## 测试计划

单元测试：

- `writerControlAdapter.test.ts`
  - 登录优先调用 `UserLoginByUserLoginInfo`。
  - 缺失完整登录 API 时降级到 `UserLoginByParameter`。
  - 留痕/清洁视图切换调用正确命令。
  - `GetDocumentUserTrackInfos` 返回非数组时归一为空数组。
  - `NavigateByUserTrackInfo` 正常、缺失和返回 false 的分支。
- `writerTraceService.test.ts`
  - 默认操作人生成。
  - `InfoType` 中文映射。
  - 时间格式化。
  - key 和摘要生成。
- `WriterTracesPanel.test.ts`
  - 渲染数量、用户、类型、摘要和时间。
  - 空态和错误态。
  - 工具按钮和列表点击事件。
- `commandRegistry.test.ts`
  - `审阅` 标签或留痕命令存在。
  - 留痕命令为 app command，不生成 writer payload。
- `useCanvasRenderer.test.ts`
  - WriterControl 宿主包含留痕相关 `SecurityOptions` 属性。

构建验证：

- `cd frontend && npm test`
- `cd frontend && npm run build`

页面验收：

- 打开模板后显示 `修改留痕` 面板。
- 编辑正文后留痕列表自动出现或刷新。
- 点击 `留痕模式` 后正文显示原生留痕效果。
- 点击 `清洁模式` 后正文切换到清洁视图。
- 点击留痕列表项能定位到正文对应位置。
- 保存和下载 XML 不被破坏。

## 实施顺序

1. 扩展 `writerControlAdapter.ts` 类型和留痕 API，并补 adapter 单测。
2. 扩展 `useCanvasRenderer.ts` 宿主属性和类型声明，并补宿主初始化测试。
3. 新增 `writerTraceService.ts` 和单测。
4. 新增 `WriterTracesPanel.vue` 和 SSR 渲染测试。
5. 扩展 `WorkbenchEditorArea.vue` 和 `EditorShell.vue`，接入状态、事件和自动刷新。
6. 扩展 `commandRegistry.ts` 和 `WorkbenchTopMenu` 相关测试。
7. 跑 `npm test` 和 `npm run build`。
8. 若本地运行时可用，再用 Playwright 验收真实 WriterControl 留痕交互。

## 设计约束

- 继续使用 Vue 3、Composition API、`<script setup lang="ts">`。
- 组件使用 props down、events up。
- Vue 组件不直接访问 WriterControl 私有结构。
- WriterControl 原生 API 只通过 adapter 调用。
- 留痕数据归一放在 service，组件不硬编码底层字段处理。
- 本阶段不新增后端接口。
