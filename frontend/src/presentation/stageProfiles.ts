export type PresentationStageId = "full-editor" | "month-2-import-preview";

export type PresentationAllowedAction = "import-xml" | "zoom";

export interface FullEditorStage {
  id: "full-editor";
  kind: "full-editor";
  label: string;
  reportMonth: string;
}

export interface XmlImportStage {
  id: "month-2-import-preview";
  kind: "xml-import";
  label: string;
  reportMonth: string;
  reportGoal: string;
  allowedActions: PresentationAllowedAction[];
  acceptance: string[];
  knownLimitations: string[];
}

export type PresentationStage = FullEditorStage | XmlImportStage;

const fullEditorStage: FullEditorStage = {
  id: "full-editor",
  kind: "full-editor",
  label: "完整编辑器",
  reportMonth: "内部开发态",
};

const monthTwoStage: XmlImportStage = {
  id: "month-2-import-preview",
  kind: "xml-import",
  label: "XML 导入闭环",
  reportMonth: "XML 导入",
  reportGoal:
    "用户可选择本地 XML，基础校验通过后进入渲染链路；版式错乱作为已知问题记录，不阻断闭环汇报。",
  allowedActions: ["import-xml", "zoom"],
  acceptance: [
    "用户可以选择本地 XML 文件。",
    "XML 通过基础格式校验后进入渲染链路。",
    "渲染错乱作为已知问题展示，不阻断导入闭环汇报。",
  ],
  knownLimitations: [
    "仅承诺 XML 能导入并进入渲染链路，不承诺任意 XML 版式完全正确。",
    "复杂表格、页眉页脚、控件状态和分页错乱属于本月已知边界。",
    "本阶段不开放模板制作、保存、上传和高级编辑能力。",
  ],
};

export const presentationStages: readonly PresentationStage[] = [
  fullEditorStage,
  monthTwoStage,
];

export function getPresentationStage(
  stageId: string | null | undefined
): PresentationStage {
  return (
    presentationStages.find((stage) => stage.id === stageId) || fullEditorStage
  );
}

export function resolvePresentationStage(options: {
  search: string;
  envStage?: string;
}): PresentationStage {
  const urlStage = new URLSearchParams(options.search).get("stage");
  return getPresentationStage(urlStage || options.envStage);
}
