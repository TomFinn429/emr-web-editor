//*************************************************************************
//* 项目名称：
//* 当前版本: V 5.3.1
//* 开始时间: 20230601
//* 开发者:
//* 重要描述:
//*************************************************************************
//* 最后更新时间:2023-8-10 10:59:25
//* 最后更新人:xym
//*************************************************************************

"use strict";
import { DCTools20221228 } from "http://10.0.15.23:8084/MyWriter/MoreHandleDCWriterServicePage?wasmres=DCTools20221228.js&ver=20260327143150_409&flag=293105&wasmrootpath=http%3A%2F%2F10.0.15.23%3A8084%2FMyWriter%2FMoreHandleDCWriterServicePage";
import { WriterControl_DialogStaticResources } from "http://10.0.15.23:8084/MyWriter/MoreHandleDCWriterServicePage?wasmres=WriterControl_DialogStaticResources.js&ver=20260327143150_409&flag=293105&wasmrootpath=http%3A%2F%2F10.0.15.23%3A8084%2FMyWriter%2FMoreHandleDCWriterServicePage";
var {
    VERSIONTYPE,
    ISSIMPLIFIED,
    DASHSTYLE,
    LBSJ,
    DIALOGSTYLE,
    SPECIALCHARACTERS,
    ROMANCHARACTERS,
    NUMERICCHARACTERS,
    MEDICALCHARACTERS,
    NAMELIST,
    IDTYPELIST,
    IDLIST,
    PERMANENTTEETHTOP,
    PERMANENTTEETHBOTTOM,
    TEETHPOSTIONTOPOBJ,
    TEETHPOSTIONBOTTOMOBJ,
    BULLETEDLIST,
    MOCKARRAY,
    DATAFONTSIZE,
    TEETHBUTTONLIST,
    DCEXECUTECOMMANDDEFAULTOPTIONS,
    MEDICALCHARACTERSIMGOBJECT,
    IMGEDITSVGOBJECT,
    INPUTFIELDPROPERTYEXPRESSIONSARRAY,
    RADIOCHECKPROPERTYEXPRESSIONSARRAY,
} = WriterControl_DialogStaticResources;

export let WriterControl_Dialog = {
    /**
     * 弹出框样式字符串
     */
    InsertSpecifyCharacterObj: {
        SpecialCharacters: SPECIALCHARACTERS,
        RomanCharacters: ROMANCHARACTERS,
        NumericCharacters: NUMERICCHARACTERS,
        MedicalCharacters: MEDICALCHARACTERS,
    },

    /**
     * 显示对话框
     * @param {string} strContainerID 编辑器容器元素编号
     * @param {string} strDialogName 对话框的名称
     * @param {any} options 参数
     */
    ShowDialog(strContainerID, strDialogName, options) {
        var rootElement =
            typeof strContainerID == "string"
                ? DCTools20221228.GetOwnerWriterControl(strContainerID)
                : strContainerID;
        if (rootElement != null) {
            // 这里的对话框名称定义在C#类型 DCSoft.WASMDialogName 中
            switch (strDialogName) {
                case "EditComment":
                    // CommentEditableWhenReadonly（只读模式下：true允许编辑|false不允许编辑）
                    // DoubleClickToEditComment = true; 允许双击 | false不允许双击
                    // console.log(
                    //     rootElement.DocumentOptions.BehaviorOptions
                    //         .CommentEditableWhenReadonly,
                    //     "CommentEditableWhenReadonly"
                    // );
                    // console.log(
                    //     rootElement.DocumentOptions.BehaviorOptions
                    //         .DoubleClickToEditComment,
                    //     "DoubleClickToEditComment"
                    // );
                    // console.log(rootElement.Readonly, "Readonly");
                    if (
                        rootElement.DocumentOptions.BehaviorOptions.DoubleClickToEditComment
                    ) {
                        if (
                            !rootElement.Readonly ||
                            (rootElement.Readonly &&
                                rootElement.DocumentOptions.BehaviorOptions
                                    .CommentEditableWhenReadonly)
                        ) {
                            // 修改批注
                            var currentComment = rootElement.GetCurrentComment();
                            if (currentComment) {
                                //判断双击的是校验，则不展示批注对话宽
                                if (currentComment.IsInternal === "True") {
                                    return;
                                }
                                WriterControl_Dialog.EditDocumentCommentsDialog(options, rootElement);
                            }
                        }
                    }
                    break;
            }
        }
    },

    /**
     * 插入绑定数据源元素
     * @param appendNode 把绑定数据源元素插入到该元素位置最后面
     * @param ctl 编辑器元素
     */
    appendValueBindingDiv: function (appendNode) {
        if (!(appendNode instanceof jQuery)) {
            return false;
        }
        var ValueBindingHtml = `
        <div class="dcBody-content">
            <div id="dc_ValueBinding_Box" class="dc_Box">
                <h6 class="dc_title">数据源信息</h6>
                <div class="dcBody-content">
                    <label>
                        <input type="checkbox" name="Enabled" data-text="ValueBinding.Enabled" checked="checked">
                        <span class="dcTitle-text">数据源绑定设置有效</span>
                    </label>
                </div>
                <form>
                    <div class="dcBody-content">
                        <label>
                            <input type="checkbox" name="Readonly" data-text="ValueBinding.Readonly">
                            <span>只读，不能回填</span>
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label>
                            <input type="checkbox" name="AutoUpdate" data-text="ValueBinding.AutoUpdate">
                            <span class="dcTitle-text">自动更新，当加载文档或数据源发生改变时自动更新数值</span>
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">数据源：</span>
                            <input type="text" class="dc_full" name="DataSource" data-text="ValueBinding.DataSource">
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">格式化：</span>
                            <input type="text" class="dc_full" name="FormatString" data-text="ValueBinding.FormatString">
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">绑定路径：</span>
                            <input type="text" class="dc_full" name="BindingPath" data-text="ValueBinding.BindingPath">
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">执行状态：</span>
                            <select id="dc_ProcessState" data-text="ValueBinding.ProcessState" class="dc_full">
                                <option value="Always">总是执行</option>
                                <option value="Once">只执行一次</option>
                                <option value="Never">不执行</option>
                            </select>
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_blockelement">
                            <span class="dcTitle-text">Text的绑定路径(仅适用于输入域元素)：</span>
                            <input type="text" class="fullWidth" name="BindingPathForText" data-text="ValueBinding.BindingPathForText">
                        </label>
                    </div>
                </form>
            </div>
        </div>`;
        var ValueBindingDiv = jQuery(ValueBindingHtml);
        var dc_ValueBinding_Box = ValueBindingDiv.find("#dc_ValueBinding_Box");
        var EnabledCheckbox = dc_ValueBinding_Box.find(
            '[data-text="ValueBinding.Enabled"]'
        );
        let that = this;
        // 绑定复选框修改事件
        EnabledCheckbox.off("change");
        EnabledCheckbox.change(function () {
            var formNode = dc_ValueBinding_Box.find("form")[0];
            that.changeFormDisable(formNode, !this.checked);
        });
        appendNode.append(ValueBindingDiv);
    },


    /**
    * 创建关于对话框
    * @param options 关于属性
    * @param ctl 编辑器元素
    */
    AboutMessageDialog: function (options, ctl) {
        var dcLicenseInfoObject = null;
        if (options && options.DCLicenseInfo) {
            dcLicenseInfoObject = handleVersionString(options.DCLicenseInfo);
            // console.log(dcLicenseInfoObject, '========dcLicenseInfoObject');
        }

        var AboutMessageHtml = `
        
            <div class="dc-section">
                <div class="dc-section-title">
                    <span class="dc-section-title-line"></span>
                    <span class="dc-section-title-text">
                        <span>基本信息</span>
                        <span id="dcCopyInfo">复制信息</span>
                    </span>
                </div>

                <div class="dc-info-row">
                    <div class="dc-info-label">编辑器版本：</div>
                    <div class="dc-info-value dc-info-value-color" id="dcPublishDate"></div>
                </div>

                <div class="dc-info-row">
                    <div class="dc-info-label">版本发布时间：</div>
                    <div class="dc-info-value" >${options.DCPublishDate}</div>
                </div>

                <div class="dc-info-row">
                    <div class="dc-info-label">当前域名：</div>
                    <div class="dc-info-value dc-info-value-color">${options.DCWebServerHost}</div>
                </div>
            </div>
            <div class="dc-section" id="dcSectionLicenseInfoBox">
               

               
            </div>
            `;

        var dialogOptions = {
            title: "关于",
            bodyClass: "AboutMessage",
            bodyHtml: AboutMessageHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var dcSectionLicenseInfoBox = ctl.querySelector("#dcSectionLicenseInfoBox");
        //处理版本字符串信息"2025-09-16 09:48:02"
        var dcPublishDate = ctl.querySelector("#dcPublishDate");

        if (options.DCPublishDate) {
            // 解析日期字符串 "2025-09-16 09:48:02"
            var publishDate = new Date(options.DCPublishDate);
            var year = publishDate.getFullYear();
            var month = publishDate.getMonth() + 1; // getMonth() 返回 0-11，需要加1
            var versionString = '';

            if (VERSIONTYPE === 't') {
                //临时版：dcwriter5.0-202508w3(临时)
                var weekNumber = getWeekNumber(publishDate);
                var monthStr = month.toString().padStart(2, '0');
                versionString = `dcwriter5.0-${year}${monthStr}w${weekNumber}(临时)`;
            } else if (VERSIONTYPE === 'w') {
                //周版本：dcwriter5.0-202508w3
                var weekNumber = getWeekNumber(publishDate);
                var monthStr = month.toString().padStart(2, '0');
                versionString = `dcwriter5.0-${year}${monthStr}w${weekNumber}`;
            } else if (VERSIONTYPE === 'm') {
                //月版本：dcwriter5.0-202508m
                var monthStr = month.toString().padStart(2, '0');
                versionString = `dcwriter5.0-${year}${monthStr}m`;
            }
            //[DUWRITER5_0-4845] 20251017 lxy 精简版本显示(精简)
            if (ISSIMPLIFIED) {
                versionString += "(精简)";
            }

            // 设置版本字符串到页面元素
            if (dcPublishDate && versionString) {
                dcPublishDate.textContent = versionString;
            }
        }

        // 获取日期所在月份的第几周
        function getWeekNumber(date) {
            var firstDay = new Date(date.getFullYear(), date.getMonth(), 1);
            var firstDayOfWeek = firstDay.getDay(); // 0-6，0是周日
            var dayOfMonth = date.getDate();

            // 计算是第几周（从1开始）
            var weekNumber = Math.ceil((dayOfMonth + firstDayOfWeek) / 7);
            return weekNumber;
        }




        if (dcLicenseInfoObject) {
            // 检查是否为空对象
            if (Object.keys(dcLicenseInfoObject).length === 0) {
                dcSectionLicenseInfoBox.innerHTML = `
                    <div class="dc-section-title">
                        <span class="dc-section-title-line"></span>
                        <span class="dc-section-title-text">授权信息</span>
                    </div>
                    <div class="dc-info-row">
                        <div class="dc-info-label">状态：</div>
                        <div class="dc-info-value dc-info-value-color-red">未注册</div>
                    </div>`;
            } else {
                var dcLicenseInfoObjectInner = `
                    <div class="dc-section-title">
                        <span class="dc-section-title-line"></span>
                        <span class="dc-section-title-text">授权信息</span>
                    </div>`;
                for (var i in dcLicenseInfoObject) {
                    var innervalue = dcLicenseInfoObject[i];
                    if (innervalue === true || innervalue === false) {
                        innervalue = (innervalue === true) ? "是" : "否";
                    } else if (innervalue === undefined || innervalue === null) {
                        innervalue = "";
                    } else {
                        innervalue = innervalue.toString();
                    }
                    if (i === "授权软件产品") {
                        if (dcLicenseInfoObject['旗舰版']) {
                            innervalue += `(旗舰版)`;
                        } else if (dcLicenseInfoObject['标准版']) {
                            innervalue += `(标准版)`;
                        }
                    }
                    if (i !== "旗舰版" && i !== "标准版") {
                        dcLicenseInfoObjectInner +=
                            `<div class="dc-info-row">
                                <div class="dc-info-label">${i}：</div>
                                <div class="dc-info-value
                                ${i === "用户名" || i === "项目名" ? "dc-info-value-color" : ""}
                                ${i === "更新限制日期" ? "dc-info-value-color-red" : ""}
                                ${i === "截止日期" ? "dc-info-value-color-green" : ""}
                                 ">${innervalue}</div>
                            </div>`;
                    }

                }
                dcSectionLicenseInfoBox.innerHTML = dcLicenseInfoObjectInner;
            }
        }

        //处理版本字符串信息
        function handleVersionString(versionString) {
            const result = {};
            // 匹配所有方括号内的内容
            const regex = /\[(.*?)\]/g;
            let match;
            while ((match = regex.exec(versionString)) !== null) {
                const content = match[1];
                // 检查是否有冒号分隔键值对
                if (content.includes(':') || content.includes('：')) {
                    // 处理中文和英文冒号
                    const separator = content.includes(':') ? ':' : '：';
                    const [key, value] = content.split(separator).map(item => item.trim());

                    // 处理逗号分隔的值
                    if (value && value.includes(',')) {
                        result[key] = value.split(',').map(item => item.trim());
                    } else {
                        result[key] = value;
                    }
                } else {
                    // 没有冒号的情况，作为标志性属性
                    result[content] = true;
                }
            }
            return result;
        }

        //复制dcLicenseInfoObject对象到剪贴板
        var dcCopyInfo = ctl.querySelector("#dcCopyInfo");
        dcCopyInfo.addEventListener("click", function () {
            var dcLicenseInfoObjectString = JSON.stringify(dcLicenseInfoObject);
            copyToClipboard(dcLicenseInfoObjectString);
        });
        function copyToClipboard(text) {
            var textarea = document.createElement("textarea");
            textarea.value = text;
            document.body.appendChild(textarea);
            textarea.select();

            try {
                var success = document.execCommand("copy");
                document.body.removeChild(textarea);

                if (success) {
                    showToast("复制成功！", "success");
                } else {
                    showToast("复制失败，请手动复制", "error");
                }
            } catch (err) {
                document.body.removeChild(textarea);
                showToast("复制失败，请手动复制", "error");
            }
        }

        // 显示气泡提示
        function showToast(message, type) {
            // 创建提示元素
            var toast = document.createElement("div");
            toast.style.cssText = `
                position: fixed;
                top: 20px;
                right: 20px;
                padding: 8px 16px;
                border-radius: 4px;
                font-size: 13px;
                font-weight: 400;
                z-index: 10000;
                background-color: rgba(0, 0, 0, 0.7);
                color: white;
                transition: all 0.3s ease;
                transform: translateX(100%);
                opacity: 0;
                backdrop-filter: blur(4px);
            `;

            toast.textContent = message;
            document.body.appendChild(toast);

            // 显示动画
            setTimeout(function () {
                toast.style.transform = "translateX(0)";
                toast.style.opacity = "1";
            }, 10);

            // 2秒后自动消失
            setTimeout(function () {
                toast.style.transform = "translateX(100%)";
                toast.style.opacity = "0";
                setTimeout(function () {
                    if (toast.parentNode) {
                        document.body.removeChild(toast);
                    }
                }, 300);
            }, 2000);
        }


        //成功的回调函数
        function successFun() {

        }
    },




    /**
     * 创建视频文件的弹窗
     * @param {any} options
     * @param {any} ctl
     */
    MediaDialog: function (options, ctl, ele) {
        //var ele = null;
        if (!options || typeof options != "object") {
            ele = ctl.CurrentElement("xtextmediaelement");
            if (ele == null) {
                options = {};
            } else {
                options = ctl.GetElementProperties(ele);
            }
        }
        var MediaHtml = `
               <div class="dc_Box">
                <h6 class="dc_title">属性</h6>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">编号：</span>
                        <input type="text" class="dc_full" name="ID" data-text="ID"></input>
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">宽度：</span>
                        <input type="number" class="dc_full" name="Width" data-text="Width"></input>
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">高度：</span>
                        <input type="number" class="dc_full" name="Height" data-text="Height"></input>
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">地址：</span>
                        <input type="text" class="dc_full" name="FileName" data-text="FileName"></input>
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">打印显示：</span>
                        <select name="PrintVisibility" data-text="PrintVisibility">
                            <option value="None">不显示</option>
                            <option value="Visible">显示</option>
                        </select>
                    </label>
                </div>
            </div>
        `;
        var dialogOptions = {
            title: "音视频元素",
            bodyHeight: 240,
            bodyClass: "MediaElement",
            bodyHtml: MediaHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        // WriterControl_Dialog.appendValueBindingDiv(dcPanelBody);
        var allDataText = jQuery(dcPanelBody).find("[data-text]");
        for (var i = 0; i < allDataText.length; i++) {
            var thisEle = allDataText[i];
            if (thisEle.nodeName == "INPUT") {
                thisEle.value = options[thisEle.getAttribute("data-text")];
            } else if (thisEle.nodeName == "SELECT") {
                var selectValue = options[thisEle.getAttribute("data-text")];
                selectValue = selectValue ? selectValue : "None";
                jQuery(thisEle)
                    .find("option[value=" + selectValue + "]")
                    .attr("selected", true);
            }
        }

        function successFun() {
            var opt = {};
            for (var i = 0; i < allDataText.length; i++) {
                opt[allDataText[i].getAttribute("data-text")] = allDataText[i].value;
            }
            //获取到需要的元素
            // console.log("successFun -> _data", _data)
            ctl.SetElementProperties(ele, opt);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("xtextmediaelement"));
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建图片属性对话框
     * @param options 图片属性
     * @param ctl 编辑器元素
     */
    ImageDialog: function (options, ctl, ele) {
        //var ele = null;
        if (!options || typeof options != "object") {
            // 当未传入值时
            ele = ctl.CurrentElement("xtextimageelement");
            if (ele == null) {
                return false;
            }
            options = ctl.GetElementProperties(ele);
        }
        options["KeepWidthHeightRate"] = options["KeepWidthHeightRate"] === true ? "true" : "false";
        options["SmoothZoom"] = options["SmoothZoom"] === true ? "true" : "false";
        options["EnableEditImageAdditionShape"] = options["EnableEditImageAdditionShape"] === true ? "true" : "false";
        // console.log(options, '========options');
        var ImageHtml = `
            <div class="dc_Box">
                <h6 class="dc_title">属性</h6>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">编号：</span>
                        <input type="text" class="dc_full" name="ID" data-text="ID">
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">宽度：</span>
                        <input type="number" class="dc_full" name="Width" data-text="Width">
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">高度：</span>
                        <input type="number" class="dc_full" name="Height" data-text="Height">
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">允许编辑：</span>
                        <select  class="dc_full" name="EnableEditImageAdditionShape" data-text="EnableEditImageAdditionShape">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </label>
                </div>
                  <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">保持长宽比<span class="dc_SpecifyWidth_title" title="当设置了保持长宽比，并修改了图片的宽高时，长宽比会根据宽高中的较大值进行缩放调整。若宽高相等，则优先以高度为缩放标准。">?</span>：</span>
                        <select  class="dc_full" name="KeepWidthHeightRate" data-text="KeepWidthHeightRate">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">平滑缩放：</span>
                        <select  class="dc_full" name="SmoothZoom" data-text="SmoothZoom">
                            <option value="true">是</option>
                            <option value="false">否</option>
                        </select>
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">水平分辨率：</span>
                        <input type="number" class="dc_full" name="HorizontalResolution" data-text="HorizontalResolution">
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">垂直分辨率：</span>
                        <input type="number" class="dc_full" name="VerticalResolution" data-text="VerticalResolution">
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">可见性表达式：</span>
                       <input data-text="VisibleExpression" type="text">
                        <button class="dc_visible_expression">示例</button>
                    </label>
                </div>
                <div id="VisibleExpressionBox"></div>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">样式属性</h6>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">布局方式：</span>
                       <select id="dc_ZOrderStyle" class="dc_full" name="ZOrderStyle" data-text="ZOrderStyle">
                            <option value="Normal">普通</option>
                            <option value="UnderText">文本下方</option>
                            <option value="InFrontOfText">文本上方</option>
                        </select>
                    </label>
                </div>
                 <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">X偏移量:</span>
                       <input  class="dc_full dc_disabled_ZOrderStyle" type="number" data-text="OffsetX">
                    </label>
                </div>
                 <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">Y偏移量:</span>
                       <input class="dc_full dc_disabled_ZOrderStyle" type="number" data-text="OffsetY" >
                    </label>
                </div>
                 <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">透明色:</span>
                       <input class="dc_full " data-text="TransparentColorValue" type="text">
                    </label>
                </div>
                <div class="dcBody-content">
                    <label class="dc_flex">
                        <span class="dcTitle-text">垂直对齐方式:</span>
                       <select  class="dc_full " name="VAlign" data-text="VAlign">
                            <option value="Top">上</option>
                            <option value="Middle">中</option>
                            <option value="Bottom">下</option>
                        </select>
                    </label>
                </div>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">图片内容</h6>
                <div id="dc_image_box" class="dcBody-content">
                    <button id="dc_changeImage" onclick="this.querySelector('input').click()">
                        <span>修改图片</span>
                        <input type="file"  accept="image/*">
                    </button>
                    <div class="imgDiv">
                        <input type="hidden" data-text="Src" data-value="img">
                        <img src="" alt="" id="dc_SrcImg">
                    </div>
                </div>
            </div>
        `;
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var dialogOptions = {
            title: "图片元素",
            bodyHeight: 475,
            bodyClass: "ImageElement",
            bodyHtml: ImageHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        // console.log(this.visibleexpressionDialog(ctl, 'VisibleExpressionBox'))
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        // WriterControl_Dialog.appendValueBindingDiv(dcPanelBody);
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        changeDisabledZOrderStyle(options.ZOrderStyle);

        GetOrChangeData(dcPanelBody, opts);
        // 图片的默认赋值
        dcPanelBody.find("[data-value='img']").each(function () {
            var _val = this.value.replace(/[\n\r]/g, "").replace(/ /g, "");
            if (_val) {
                var str = _val;
                if (_val.indexOf("base64,") == -1) {
                    str = "data:image/png;base64," + str;
                    // jQuery(this).val(str);
                }
                jQuery(this).siblings("img#dc_SrcImg").attr("src", str);
            }
        });
        dcPanelBody.find("#dc_changeImage input").change(function () {
            var files = this.files;
            if (files.length == 0) {
                return;
            }
            var dc_image_box = jQuery(this).parents("#dc_image_box:first");
            var imgNode = dc_image_box.find("img#dc_SrcImg");
            var imgInputNode = dc_image_box.find("[data-value=img]");
            if (files[0] && files[0].type.slice(0, 5) == "image") {
                var fileinfo = files[0];
                var reader = new FileReader();
                reader.readAsDataURL(fileinfo);
                reader.onload = function () {
                    var base64 = reader.result;
                    imgNode.attr("src", base64);
                    imgInputNode.val(base64);
                    // imgNode.show();
                    // var str = base64.substr(base64.indexOf("base64,") + 7, base64.length);
                    // btnNode.val(str);
                };
                reader.onerror = function (error) {
                    console.log(error);
                };
            }
        });
        jQuery(ctl).find('#dc_ZOrderStyle').change(function () {
            var selectedValue = jQuery(this).val();
            changeDisabledZOrderStyle(selectedValue);
        });
        //设置样式是否禁用
        function changeDisabledZOrderStyle(selectedValue) {
            if (selectedValue) {
                var dc_disabled_ZOrderStyle = ctl.ownerDocument.querySelectorAll('.dc_disabled_ZOrderStyle');
                for (var i = 0; i < dc_disabled_ZOrderStyle.length; i++) {
                    var item = dc_disabled_ZOrderStyle[i];
                    if (selectedValue === 'Normal') {
                        item.setAttribute('disabled', true);
                    } else {
                        item.removeAttribute('disabled');
                    }
                }
            }

        }
        function getDefaultOptions() {
            var _data = GetOrChangeData(dcPanelBody);
            _data["KeepWidthHeightRate"] = _data["KeepWidthHeightRate"] === "true";
            _data["SmoothZoom"] = _data["SmoothZoom"] === "true";
            _data["EnableEditImageAdditionShape"] = _data["EnableEditImageAdditionShape"] === "true";
            return _data;
        }
        var oldoptions = getDefaultOptions();

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            _data["KeepWidthHeightRate"] = _data["KeepWidthHeightRate"] === "true";
            _data["SmoothZoom"] = _data["SmoothZoom"] === "true";
            _data["EnableEditImageAdditionShape"] = _data["EnableEditImageAdditionShape"] === "true";
            //判断后端是否需要刷新
            if (JSON.stringify(oldoptions) !== JSON.stringify(_data)) {
                _data['refreshparent'] = true;
            } else {
                _data['refreshparent'] = false;
            }
            // 如果图片存在{保持长宽比}时先取消{保持长宽比}再还原【DUWRITER5_0-4587】
            // 图片属性对话框如果没有修改宽度高度时不会被{保持长宽比}影响，反之修改会被{保持长宽比}影响【DUWRITER5_0-4587】
            var _KeepWidthHeightRate = _data.KeepWidthHeightRate;
            // 是否修改了宽度高度
            var isChangeWidthOrHeight = oldoptions.Width != _data.Width || oldoptions.Height != _data.Height;
            if (_KeepWidthHeightRate == true && !isChangeWidthOrHeight) {
                _data.KeepWidthHeightRate = false;
                ctl.SetElementProperties(options.NativeHandle, _data, false);
                ctl.SetElementProperties(options.NativeHandle, {
                    KeepWidthHeightRate: true,
                    refreshparent: _data.refreshparent
                });
            } else {
                ctl.SetElementProperties(options.NativeHandle, _data);
            }
            // ctl.SetElementProperties(ele, _data);
            // console.log("successFun -> _data", _data);

            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("xtextimageelement"));
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }

    },

    /**
     * 创建水印对话框
     * @param options 水印属性
     * @param ctl 编辑器元素
     */
    WatermarkDialog: function (options, ctl) {
        if (!options || typeof options != "object") {
            // 当未传入值时，获取当前的水印数据
            options = ctl.GetDocumentWatermark();
        }
        var watermarkHtml = `
            <div class="dcBody-content">
                <span class="dcTitle-text">倾斜角度:</span>
                <input type="number" class="dcTitle-text-input-number" value="0"  name="angle" min="0" max="360"/>
                <span class="dc_gap-width"></span>
                <span class="dcTitle-text">透明度:</span>
                <input type="number" value="0"  class="dcTitle-text-input-number"  name="alpha" min="0" max="100"/>
            </div>
            <div class="dcBody-content">
                <input type="checkbox" id="dc_repeatCheckbox" name="repeat"/>
                    <label for="dc_repeatCheckbox" class="dcTitle-text">重复平铺，密度(0到1之间):</span>
                <input type="number" value="0"  class="dcTitle-text-input-number"  name="densityforrepeat" min="0" max="1" step="0.1"/>
            </div>
            <div class="dcBody-content">
                <input type="radio" name="type" id="dc_noWaterType" value="None" checked>
                <label for="dc_noWaterType">无水印</label>
            </div>
            <div class="dcBody-content">
                <input type="radio" name="type" id="dc_imgWaterType" value="Image">
                <label for="dc_imgWaterType">图片水印</label>
              <br />
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  <span class="dc_imgWaterType_wring">注：图片水印暂不支持设置透明度</span>
                <div class="dcBody-content">
                    <span class="dc_gap-width"></span>
                    <input type="hidden" id="dc_imagedatabase64string" name="imagedatabase64string" value="选择文件" disabled/>
                    <input type="file" id="WatermarkSrcImgButton" disabled accept="image/*">
                     <img src="" alt="" id="WatermarkSrcImg">
                </div>
            </div>
            <div class="dcBody-content">
                <input type="radio" name="type" id="textWaterType" value="Text">
                <label for="textWaterType">文字水印</label>
                <div class="dcBody-content">
                    <div class="dc_textWaterType_label_box" >
                        <span class="dc_gap-width"></span>
                        <span class="dcTitle-text">文字：</span>
                        <input type="text"  name="text" disabled>
                    </div>
                    <div class="dc_textWaterType_label_box_font">
                        <span class="dc_gap-width"></span>
                        <span class="dcTitle-text">字体：</span>
                        <input type="text"  name="font" disabled>
                    </div>
                    <div class="dc_textWaterType_label_box_color">
                        <span class="dc_gap-width"></span>
                        <span class="dcTitle-text">颜色：</span>
                        <div id="dc_watermark_colorvalue_box" name="colorvalue" data-value="#000000" style="display: inline-block; width: 164px; height: 10px; border: 1px solid rgb(217, 217, 217); border-radius: 4px; cursor: pointer; vertical-align: middle; margin-left: 5px; background-color: #000000;"></div>
                    </div>
                </div>
            </div>
        `;
        var dialogOptions = {
            title: "水印",
            bodyHeight: 326,
            bodyClass: "Watermark",
            bodyHtml: watermarkHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        // 初始化：禁用所有颜色选择器（除非选中了文字水印）
        var watermarkColorBox = jQuery(dcPanelBody).find('#dc_watermark_colorvalue_box')[0];
        if (watermarkColorBox) {
            watermarkColorBox.style.pointerEvents = 'none';
            watermarkColorBox.style.opacity = '0.5';
        }

        // 进行水印类型的切换
        dcPanelBody.find("input[type=radio][name=type]").on("change", function (e) {
            //先将文本和图片的禁用，再根据点击开启
            dcPanelBody
                .find("input[type=radio]")
                .nextAll(".dcBody-content")
                .find("input,select")
                .attr("disabled", "disabled");
            // 禁用div颜色选择器
            dcPanelBody
                .find("input[type=radio]")
                .nextAll(".dcBody-content")
                .find("#dc_watermark_colorvalue_box")
                .each(function () {
                    this.style.pointerEvents = 'none';
                    this.style.opacity = '0.5';
                });

            jQuery(this)
                .nextAll(".dcBody-content")
                .find("input,select")
                .removeAttr("disabled");
            // 启用div颜色选择器
            jQuery(this)
                .nextAll(".dcBody-content")
                .find("#dc_watermark_colorvalue_box")
                .each(function () {
                    this.style.pointerEvents = 'auto';
                    this.style.opacity = '1';
                });
        });
        //图片上传，对文件按钮进行判断
        dcPanelBody.find("input[type=file]").on("change", function (e) {
            var reader = new FileReader();
            var file = e.target.files[0];
            if (file) {
                reader.readAsDataURL(file);
                reader.onloadend = function () {
                    //console.log(reader.result);
                    dcPanelBody.find("#dc_imagedatabase64string").val(reader.result);
                    dcPanelBody.find("img#WatermarkSrcImg").attr("src", reader.result);
                };
            }
        });

        //开始对对话框赋值
        if (options != null && typeof options == "object") {
            // console.log("处理前的水印数据==>", options)
            options = WriterControl_Dialog.checkWaterValue(options);
            // console.log("当前的水印数据==>", options)
            for (var item in options) {
                var _value = options[item];
                var _input = dcPanelBody.find("[name='" + item + "']");

                // 特殊处理 colorvalue，因为它现在是div
                if (item === "colorvalue" && _input.length > 0 && _input[0].nodeName === "DIV") {
                    var colorValue = _value || "#000000";
                    _input[0].style.backgroundColor = colorValue;
                    _input[0].setAttribute("data-value", colorValue);
                    continue;
                }

                var _type = _input.attr("type");
                if (_type == "checkbox") {
                    if (typeof _value == "boolean") {
                        _input.prop("checked", _value);
                    }
                } else if (_type == "radio") {
                    if (typeof _value == "string") {
                        _input.filter("[value=" + _value + "]").click();
                    }
                } else {
                    _input.val(_value);
                }
            }
        }

        if (options.type && options.type === "Image") {
            if (
                options.imagedatabase64string &&
                options.imagedatabase64string.length
            ) {
                let _val = options.imagedatabase64string;
                let str = "";
                if (_val.indexOf("base64,") == -1) {
                    str = "data:image/png;base64," + options.imagedatabase64string;
                }
                dcPanelBody.find("img#WatermarkSrcImg").attr("src", str);
            }
        }

        // 水印颜色选择器 - 点击色块弹出颜色选择器
        if (watermarkColorBox) {
            jQuery(watermarkColorBox).off('click').on('click', function () {
                // 检查是否被禁用
                if (this.style.pointerEvents === 'none') {
                    return;
                }
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_watermark_colorvalue_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#000000'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }

        //成功的回调函数
        function successFun() {
            //获取到所有的属性
            var opt = {
                type: "None", //类型
                densityforrepeat: "", //水印间隔,0-1之间,允许小数,需要是number
                repeat: "", //是否重复
                alpha: "", //透明度,可能是0-255,需要是number
                // "backcolorvalue": "",//颜色值
                colorvalue: "", //字体颜色值
                angle: "", //倾斜角度，0-360之间，允许小数,需要是number
                imagedatabase64string: "", //图片
                text: "", //文本内容
                font: "", //字体样式 微软雅黑, 10.5, style=Bold, Italic, Underline, Strikeout
                // "fontname": "",//字体名称
                // "fontsize": ""//字体大小,需要是number
            };
            for (var item in opt) {
                //找到对应的元素
                var _input = dcPanelBody.find("[name='" + item + "']");

                // 特殊处理 colorvalue，因为它现在是div
                if (item === "colorvalue" && _input.length > 0 && _input[0].nodeName === "DIV") {
                    opt[item] = _input[0].getAttribute("data-value") || "#000000";
                    continue;
                }

                var _type = _input.attr("type");
                if (_type == "checkbox") {
                    opt[item] = _input.prop("checked");
                } else if (_type == "radio") {
                    opt[item] = _input.filter(":checked").val();
                } else {
                    opt[item] = _input.val();
                }
            }
            ctl.SetDocumentWatermark(opt);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetDocumentWatermark();
                ctl.EventDialogChangeProperties(changedOptions);
            };
            return options;
        }
    },

    /**
     * 处理水印数据
     * @param gridLineInfo 水印属性
     * @return 处理完成的水印数据
     */
    checkWaterValue: function (gridLineInfo) {
        if (!gridLineInfo || typeof gridLineInfo != "object") {
            return null;
        }
        var opt = {
            type: "None", //类型
            densityforrepeat: "", //水印间隔,0-1之间,允许小数,需要是number
            repeat: "", //是否重复
            alpha: "", //透明度,可能是0-255,需要是number
            // "backcolorvalue": "",//颜色值
            colorvalue: "", //字体颜色值
            angle: "", //倾斜角度，0-360之间，允许小数,需要是number
            imagedatabase64string: "", //图片
            text: "", //文本内容
            font: "", //字体样式 微软雅黑, 10.5, style=Bold, Italic, Underline, Strikeout
            // "fontname": "",//字体名称
            // "fontsize": ""//字体大小,需要是number
        };
        for (var item in gridLineInfo) {
            var lower_item = item.toLowerCase(); //转换为小写字母
            if (Object.hasOwnProperty.call(opt, lower_item)) {
                var _value = gridLineInfo[item]; //传入对象的内容
                if (_value == null) {
                    _value = "";
                }
                switch (lower_item) {
                    case "type":
                        _value += "";
                        _value = _value.toLowerCase();
                        switch (_value) {
                            case "1":
                            case "image":
                                opt[lower_item] = "Image";
                                break;
                            case "2":
                            case "text":
                                opt[lower_item] = "Text";
                                break;
                            default:
                                opt[lower_item] = "None";
                                break;
                        }
                        break;
                    case "densityforrepeat":
                    case "alpha":
                    case "angle":
                        // case 'fontsize':
                        //确保是数值
                        _value = Number(_value);
                        if (typeof _value === "number" && isNaN(_value)) {
                            // 是NaN
                            _value = 0;
                        }
                        opt[lower_item] = _value;
                        break;
                    case "backcolorvalue":
                    case "colorvalue":
                        //判断是否为颜色
                        if (_value) {
                            var reg_str = "";
                            if (/^rgb\(/.test(_value)) {
                                reg_str =
                                    "^[rR][gG][Bb][(]([\\s]*(2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?)[\\s]*,){2}[\\s]*(2[0-4]\\d|25[0-5]|[01]?\\d\\d?)[\\s]*[)]{1}$";
                            } else if (/^rgba\(/.test(_value)) {
                                reg_str =
                                    "^[rR][gG][Bb][Aa][(]([\\s]*(2[0-4][0-9]|25[0-5]|[01]?[0-9][0-9]?)[\\s]*,){3}[\\s]*(1|1.0|0|0.[0-9])[\\s]*[)]{1}$";
                            } else if (/^#/.test(_value)) {
                                reg_str = "^#([0-9a-fA-F]{6}|[0-9a-fA-F]{3})$";
                            } else if (/^hsl\(/.test(_value)) {
                                reg_str =
                                    "^[hH][Ss][Ll][(]([\\s]*(2[0-9][0-9]|360｜3[0-5][0-9]|[01]?[0-9][0-9]?)[\\s]*,)([\\s]*((100|[0-9][0-9]?)%|0)[\\s]*,)([\\s]*((100|[0-9][0-9]?)%|0)[\\s]*)[)]$";
                            } else if (/^hsla\(/.test(_value)) {
                                reg_str =
                                    "^[hH][Ss][Ll][Aa][(]([\\s]*(2[0-9][0-9]|360｜3[0-5][0-9]|[01]?[0-9][0-9]?)[\\s]*,)([\\s]*((100|[0-9][0-9]?)%|0)[\\s]*,){2}([\\s]*(1|1.0|0|0.[0-9])[\\s]*)[)]$";
                            }
                            var re = new RegExp(reg_str);
                            if (_value.match(re) == null) {
                                _value = "#000000";
                            }
                        } else {
                            _value = "#000000";
                        }
                        opt[lower_item] = _value;
                        break;
                    case "repeat":
                        //确保是boolean值
                        if (typeof _value != "boolean") {
                            _value += "";
                            _value = _value.toLowerCase();
                            if (_value == "true") {
                                _value = true;
                            } else {
                                _value = false;
                            }
                        }
                        opt[lower_item] = _value;
                        break;
                    case "text":
                    // case 'fontname':
                    case "font":
                    case "imagedatabase64string":
                        //只要是纯文本就行
                        _value += "";
                        var BASE64_MARKER = ";base64,"; //声明文件流编码格式
                        if (
                            lower_item == "imagedatabase64string" &&
                            _value.indexOf(BASE64_MARKER) > -1
                        ) {
                            var base64Index =
                                _value.indexOf(BASE64_MARKER) + BASE64_MARKER.length;
                            _value = _value.substring(base64Index);
                        }
                        opt[lower_item] = _value;
                        break;
                    default:
                        break;
                }
            }
        }
        return opt;
    },


    /**
     * 创建页面设置对话框
     * @param options 页面设置属性
     * @param ctl 编辑器元素
     */
    DocumentSettingsDialog: function (options, ctl, callBack) {
        if (!options || typeof options != "object") {
            // 当未传入值时，获取当前的页面设置数据
            options = ctl.GetDocumentPageSettings();
            console.log(options, '===================options');
        }
        // 装订线
        var gutterOptions = ctl.GetDocumentGutter();
        // 空白文本
        var TerminalTextOptions = ctl.GetDocumentTerminalText();
        //转义字符,
        if (TerminalTextOptions && TerminalTextOptions.Text && TerminalTextOptions.Text === "line:\\") {
            TerminalTextOptions.Text = "line:2";
        }
        if (TerminalTextOptions && TerminalTextOptions.TextInMiddlePage && TerminalTextOptions.TextInMiddlePage === "line:\\") {
            TerminalTextOptions.TextInMiddlePage = "line:2";
        }



        var DocumentSttingsHtml = `
        <!-- Tab导航 -->
        <div class="dc_tab-nav">
            <div class="dc_tab-item active" data-tab="basic">基础设置</div>
            <div class="dc_tab-item" data-tab="advanced">高级设置</div>
        </div>

        <!-- 基础设置Tab -->
        <div class="dc_tab-content active" id="basicTab">
            <div class="dc_modal-content">
                <!-- 左侧设置面板 -->
                <div class="dc_settings-panel">
                    <!-- 页面方向 -->
                    <div class="dc_setting-group">
                        <label class="dc_setting-label">页面方向</label>
                        <div class="dc_radio-group">
                            <label class="dc_radio-item">
                                <input type="radio" name="orientation" value="portrait" class="dc_radio-input" >
                                <span class="dc_radio-label">纵向</span>
                            </label>
                            <label class="dc_radio-item">
                                <input type="radio" name="orientation" value="landscape" class="dc_radio-input">
                                <span class="dc_radio-label">横向</span>
                            </label>
                        </div>
                    </div>

                    <!-- 页面大小 -->
                    <div class="dc_setting-group">
                        <label class="dc_setting-label">页面大小</label>
                        <select class="dc_select" id="pageSize"></select>
                    </div>

                    <!-- 页面尺寸 -->
                    <div class="dc_setting-group">
                        <label class="dc_setting-label">页面尺寸</label>
                        <div class="dc_input-group">
                            <label>高:</label>
                            <input type="number" class="dc_input"  id="pageHeight" value="29.69" step="0.01" min="1" disabled>
                            <span>cm</span>
                        </div>
                        <div class="dc_input-group">
                            <label>宽:</label>
                            <input type="number" class="dc_input" id="pageWidth" value="21.01" step="0.01" min="1" disabled>
                            <span>cm</span>
                        </div>
                    </div>

                    <!-- 页边距 -->
                    <div class="dc_setting-group">
                        <label class="dc_setting-label">页边距</label>
                        <div class="dc_input-group">
                            <label>左:</label>
                            <input type="number" class="dc_input" id="marginLeft"  step="0.1">
                            <span>cm</span>
                        </div>
                        <div class="dc_input-group">
                            <label>右:</label>
                            <input type="number" class="dc_input" id="marginRight"  step="0.1">
                            <span>cm</span>
                        </div>
                        <div class="dc_input-group">
                            <label>上:</label>
                            <input type="number" class="dc_input" id="marginTop"  step="0.1">
                            <span>cm</span>
                        </div>
                        <div class="dc_input-group">
                            <label>下:</label>
                            <input type="number" class="dc_input" id="marginBottom"  step="0.1">
                            <span>cm</span>
                        </div>
                    </div>
                </div>

                <!-- 右侧预览面板 -->
                <div class="dc_preview-panel">
                    <div class="dc_page-preview portrait" id="pagePreview">
                        <div class="dc_printable-area portrait" id="printableArea"></div>
                        <div class="dc_margin-line top"></div>
                        <div class="dc_margin-line bottom"></div>
                        <div class="dc_margin-line left"></div>
                        <div class="dc_margin-line right"></div>
                    </div>
                </div>
            </div>
        </div>

        <!-- 高级设置Tab -->
        <div class="dc_tab-content" id="advancedTab">
            <div class="dc_modal-content">
                <!-- 左侧设置面板 -->
                <div class="dc_settings-panel">
                    <!-- 页眉页脚设置 -->
                    <div class="dc_setting-group">
                        <label class="dc_setting-label">页眉页脚设置</label>
                        <div class="dc_input-group">
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span>页眉高度:</span>
                                    <input type="number" class="dc_input dc_input_number_data_model"
                                            id="headerHeight" min="0"  data-text="HeaderDistance" >
                                    <span>1/100 英寸</span>
                                    <span id="headerHeightDistance" style="color:#ff6767;margin-left:2px"></span>
                                </label>
                            </div>
                        </div>
                        <div class="dc_input-group">
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span>页脚高度:</span>
                                    <input type="number" class="dc_input dc_input_number_data_model"
                                            id="footerHeight" min="0"  data-text="footerDistance" >
                                    <span>1/100 英寸</span>
                                    <span id="footerHeightDistance" style="color:#ff6767;margin-left:2px"></span>
                                </label>
                            </div>
                        </div>
                        <label class="dc_checkbox-item">
                            <input type="checkbox" class="dc_checkbox-input" id="differentFirstPage">
                            <span>首页页眉页脚不同</span>
                        </label>
                    </div>

                    <!-- 装订线设置 -->
                    <div class="dc_setting-group">
                        <div class="dc_setting-label">装订线设置</div>
                        <div class="dc_radio-group">
                            <label class="dc_checkbox-item">
                                <input type="radio" name="GutterStyle" value="Left" data-text="GutterStyle" checked>
                                <span>左</span>
                            </label>
                            <label class="dc_checkbox-item">
                                <input type="radio" name="GutterStyle" value="Top" data-text="GutterStyle">
                                <span>上</span>
                            </label>
                            <label class="dc_checkbox-item">
                                <input type="radio" name="GutterStyle" value="Right" data-text="GutterStyle">
                                <span>右</span>
                            </label>
                        </div>
                        <div class="dc_input-group">
                            <label class="dc_checkbox-item">
                                <span class="dc_txt">装订线距离：</span>
                                <input type="number" min="0"  name="GutterPosition" id="dcGutterPosition" data-text="GutterPosition" class="dc_input dc_input_number_data_model" value="0">
                                <span>1/100 英寸</span>
                                <span id="dcGutterPositionDistance" style="color:#ff6767;margin-left:2px"></span>
                            </label>
                        </div>
                        <label class="dc_checkbox-item">
                            <input type="checkbox" name="ShowGutterLine" data-text="ShowGutterLine">
                            <span>显示装订线</span>
                        </label>
                        <label class="dc_checkbox-item">
                            <input type="checkbox" name="SwapGutter" data-text="SwapGutter">
                            <span>为双面打印切换装订线</span>
                        </label>
                    </div>

                    <!-- 空白占位文本设置 -->
                    <div class="dc_setting-group dc_setting-group-Terminal">
                        <div class="dc_setting-label">空白占位文本设置</div>
                        <div class="dc_setting-group">
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span>最后一页空白文本：</span>
                                    <select class="dc_select dc_input_number_data_model" id="TerminalText">
                                        <option value="none">无</option>
                                        <option value="text">空白文本</option>
                                        <option value="line:/">空白斜线/</option>
                                        <option value="line:2">空白斜线\\</option>
                                        <option value="line:S">空白S线</option>
                                    </select>
                                </label>
                            </div>
                            <div class="dc_input-group" id="TerminalTextGroup">
                                <label class="dc_checkbox-item">
                                    <span>最后一页文本内容：</span>
                                    <input type="text" name="TerminalTextInner" id="TerminalTextInner" class="dc_input" />
                                </label>
                            </div>
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span>中间页面空白文本：</span>
                                    <select class="dc_select dc_input_number_data_model" id="TerminalTextInMiddlePage">
                                        <option value="none">无</option>
                                        <option value="text">空白文本</option>
                                        <option value="line:/">空白斜线/</option>
                                        <option value="line:2">空白斜线\\</option>
                                        <option value="line:S">空白S线</option>
                                    </select>
                                </label>
                            </div>
                            <div class="dc_input-group" id="TerminalTextInMiddlePageGroup">
                                <label class="dc_checkbox-item">
                                    <span>中间空白文本内容：</span>
                                    <input type="text" name="TerminalTextInMiddlePageInner" id="TerminalTextInMiddlePageInner" class="dc_input" />
                                </label>
                            </div>
                           
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span class="dc_txt">空白文本字体样式：</span>
                                    <div class="dc_txt dc_txt_font" >
                                        <select class="dc_select_font_name" id="TerminalTextFontName">
                                            <option value="宋体">宋体</option>
                                            <option value="仿宋">仿宋</option>
                                            <option value="仿宋_GB2312">仿宋_GB2312</option>
                                            <option value="黑体">黑体</option>
                                            <option value="楷体">楷体</option>
                                            <option value="微软雅黑">微软雅黑</option>
                                            <option value="华文仿宋">华文仿宋</option>
                                            <option value="华文楷体">华文楷体</option>
                                            <option value="华文宋体">华文宋体</option>
                                            <option value="华文细黑">华文细黑</option>
                                            <option value="新宋体">新宋体</option>
                                            <option value="Calibri">Calibri</option>
                                            <option value="Arial">Arial</option>
                                            <option value="Times New Roman">Times New Roman</option>
                                            <option value="喜马拉雅">喜马拉雅</option>
                                        </select>
                                        <select class="dc_select_font_name" id="TerminalTextFontSize">
                                            <option value="63">大特号</option>
                                            <option value="54">特号</option>
                                            <option value="42">初号</option>
                                            <option value="36">小初</option>
                                            <option value="26.25">一号</option>
                                            <option value="24">小一</option>
                                            <option value="21.75">二号</option>
                                            <option value="18">小二</option>
                                            <option value="15.75">三号</option>
                                            <option value="15">小三</option>
                                            <option value="14.25">四号</option>
                                            <option value="12">小四</option>
                                            <option value="10.5">五号</option>
                                            <option value="9">小五</option>
                                            <option value="7.5">六号</option>
                                            <option value="6.75">小六</option>
                                            <option value="5.25">七号</option>
                                            <option value="4.5">八号</option>
                                            <option value="8">8</option>
                                            <option value="9">9</option>
                                            <option value="10">10</option>
                                            <option value="11">11</option>
                                            <option value="12">12</option>
                                            <option value="14">14</option>
                                            <option value="16">16</option>
                                            <option value="18">18</option>
                                            <option value="20">20</option>
                                            <option value="22">22</option>
                                            <option value="24">24</option>
                                            <option value="26">26</option>
                                            <option value="28">28</option>
                                            <option value="36">36</option>
                                            <option value="48">48</option>
                                            <option value="72">72</option>
                                        </select>
                                    </div>
                                </label>
                            </div>
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span class="dc_txt">空白文本字体颜色：</span>
                                    <div id="TerminalTextColor" data-value="#000000" style="display: inline-block; width: 160px; height: 14px; border: 1px solid rgb(217, 217, 217); border-radius: 4px; cursor: pointer; vertical-align: middle;  background-color: #000000;"></div>
                                </label>
                            </div>
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span class="dc_txt">最小高度（厘米）：</span>
                                    <input type="number" min="0"  name="TerminalTextMinHeightInCMUnit" id="TerminalTextMinHeightInCMUnit"  class="dc_input dc_input_number_data_model" value="2" disabled>
                                </label>
                            </div> 
                           
                        </div>
                    </div>

                    <div class="dc_setting-group dc_setting-group-Terminal">
                        <div class="dc_setting-label">打印设置</div>
                        <div class="dc_setting-group">
                            <div class="dc_input-group">
                                <label class="dc_checkbox-item">
                                    <span class="dc_txt">拼接打印数：</span>
                                    <input type="number" min="0"  name="JointPrintNumber" id="JointPrintNumber"  class="dc_input dc_input_number_data_model"  >
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- 右侧预览面板 -->
                <div class="dc_preview-panel">
                    <div class="dc_page-preview portrait" id="advancedPagePreview">
                        <div class="dc_printable-area portrait" id="advancedPrintableArea"></div>
                        <div class="dc_header-preview" id="headerPreview"></div>
                        <div class="dc_footer-preview" id="footerPreview"></div>
                        <div class="dc_binding-line left" id="bindingLine" style="display: none;"></div>
                        <div class="dc_margin-line top"></div>
                        <div class="dc_margin-line bottom"></div>
                        <div class="dc_margin-line left"></div>
                        <div class="dc_margin-line right"></div>
                    </div>
                </div>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "页面设置",
            bodyHeight: 504,
            dialogContainerBodyWidth: 700,
            bodyClass: "DocumentSettings",
            bodyHtml: DocumentSttingsHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions, callBack);

        // 页面尺寸配置
        const pageSizes = {
            'A4': { width: 21.01, height: 29.69 },
            'A3': { width: 29.69, height: 42.01 },
            'A5': { width: 14.81, height: 21.01 },
            'B4': { width: 24.99, height: 35.30 },
            'B5': { width: 17.60, height: 24.99 },
            '16K(自定义)': { width: 19.5, height: 27 },
            'Prc16K': { width: 14.61, height: 21.49 },
            'Prc16KRotated': { width: 14.61, height: 21.49 },
            'Custom': { width: 21.01, height: 29.69 }
        };

        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        // 获取新UI的元素
        var orientationRadios = dcPanelBody.find('input[name="orientation"]');
        var pageSizeSelect = dcPanelBody.find('#pageSize');
        var pageHeightInput = dcPanelBody.find('#pageHeight');
        var pageWidthInput = dcPanelBody.find('#pageWidth');
        var marginInputs = {
            left: dcPanelBody.find('#marginLeft'),
            right: dcPanelBody.find('#marginRight'),
            top: dcPanelBody.find('#marginTop'),
            bottom: dcPanelBody.find('#marginBottom')
        };
        var headerHeightInput = dcPanelBody.find('#headerHeight');
        var footerHeightInput = dcPanelBody.find('#footerHeight');
        var differentFirstPageCheckbox = dcPanelBody.find('#differentFirstPage');

        //装订线
        var dcGutterPositionDistance = dcPanelBody.find("#dcGutterPositionDistance");
        var dcGutterPosition = dcPanelBody.find('#dcGutterPosition');

        //空白文本字体
        var TerminalText = dcPanelBody.find('#TerminalText');
        var TerminalTextInMiddlePage = dcPanelBody.find('#TerminalTextInMiddlePage');
        var TerminalTextGroup = dcPanelBody.find('#TerminalTextGroup');
        var TerminalTextInMiddlePageGroup = dcPanelBody.find('#TerminalTextInMiddlePageGroup');
        var TerminalTextInner = dcPanelBody.find('#TerminalTextInner');
        var TerminalTextInMiddlePageInner = dcPanelBody.find('#TerminalTextInMiddlePageInner');

        // 初始化页面大小下拉
        Object.keys(pageSizes).forEach(size => {
            pageSizeSelect.append(`<option value="${size}">${size}</option>`);
        });

        // 更新预览函数
        function updatePreview() {
            const orientation = orientationRadios.filter(':checked').val();
            const pageSize = pageSizeSelect.val();
            const pagePreview = dcPanelBody.find('#pagePreview');
            const printableArea = dcPanelBody.find('#printableArea');

            // 更新页面预览的尺寸和方向
            pagePreview.removeClass('portrait landscape').addClass(orientation);
            printableArea.removeClass('portrait landscape').addClass(orientation);

            // 更新页面尺寸显示
            let dimensions;
            if (pageSize === 'Custom') {
                dimensions = {
                    width: parseFloat(pageWidthInput.val()),
                    height: parseFloat(pageHeightInput.val())
                };
            } else {
                dimensions = pageSizes[pageSize];
                // 更新输入框的值
                if (orientation === 'landscape') {
                    pageWidthInput.val(dimensions.height.toFixed(2));
                    pageHeightInput.val(dimensions.width.toFixed(2));
                } else {
                    pageWidthInput.val(dimensions.width.toFixed(2));
                    pageHeightInput.val(dimensions.height.toFixed(2));
                }
            }

            // 更新页边距预览
            updateMargins(printableArea);
        }

        // 更新高级预览
        function updateAdvancedPreview() {
            const orientation = orientationRadios.filter(':checked').val();
            const pagePreview = dcPanelBody.find('#advancedPagePreview');
            const printableArea = dcPanelBody.find('#advancedPrintableArea');

            // 更新页面预览的尺寸和方向
            pagePreview.removeClass('portrait landscape').addClass(orientation);
            printableArea.removeClass('portrait landscape').addClass(orientation);

            // 更新页边距预览
            updateMargins(printableArea);

        }

        // 更新页边距预览
        function updateMargins(printableArea) {
            const marginLeft = parseFloat(marginInputs.left.val());
            const marginRight = parseFloat(marginInputs.right.val());
            const marginTop = parseFloat(marginInputs.top.val());
            const marginBottom = parseFloat(marginInputs.bottom.val());

            // 缩放比例：将cm转换为px (1cm ≈ 37.8px，但为了预览效果使用更小的比例)
            const scale = 3;

            // 计算可打印区域的位置和大小
            const left = marginLeft * scale;
            const right = marginRight * scale;
            const top = marginTop * scale;
            const bottom = marginBottom * scale;

            // 设置可打印区域的样式
            printableArea.css({
                left: `${left}px`,
                right: `${right}px`,
                top: `${top}px`,
                bottom: `${bottom}px`
            });
        }

        // 添加页眉页脚预览更新函数
        function updateHeaderFooterPreview() {
            const headerHeight = parseFloat(headerHeightInput.val()) || 0;
            const footerHeight = parseFloat(footerHeightInput.val()) || 0;
            const headerPreview = dcPanelBody.find('#headerPreview');
            const footerPreview = dcPanelBody.find('#footerPreview');

            // 将1/100英寸转换为厘米：1/100英寸 = 0.0254厘米
            const headerHeightCM = headerHeight * 0.0254;
            const footerHeightCM = footerHeight * 0.0254;

            // 使用与页边距预览相同的缩放比例
            const scale = 3;

            headerPreview.css('height', `${headerHeightCM * scale}px`);
            footerPreview.css('height', `${footerHeightCM * scale}px`);

        }

        //空白占位文本的禁用状态修改
        function updateTerminalTextState() {
            const TerminalTextValue = jQuery(TerminalText).val();
            const TerminalTextInMiddlePageValue = jQuery(TerminalTextInMiddlePage).val();
            const disabled = (TerminalTextValue === 'none' && TerminalTextInMiddlePageValue === 'none');


            dcPanelBody.find('#TerminalTextFontName').prop('disabled', disabled);
            dcPanelBody.find('#TerminalTextFontSize').prop('disabled', disabled);
            // TerminalTextColor 现在是 div，使用 CSS 来控制禁用状态
            var TerminalTextColorBox = dcPanelBody.find('#TerminalTextColor')[0];
            if (TerminalTextColorBox) {
                if (disabled) {
                    TerminalTextColorBox.style.pointerEvents = 'none';
                    TerminalTextColorBox.style.opacity = '0.5';
                } else {
                    TerminalTextColorBox.style.pointerEvents = 'auto';
                    TerminalTextColorBox.style.opacity = '1';
                }
            }
            dcPanelBody.find('#TerminalTextMinHeightInCMUnit').prop('disabled', disabled);

            if (TerminalTextValue === 'text') {
                TerminalTextGroup.show();
            } else {
                TerminalTextGroup.hide();
            }

            if (TerminalTextInMiddlePageValue === 'text') {
                TerminalTextInMiddlePageGroup.show();
            } else {
                TerminalTextInMiddlePageGroup.hide();
            }
        }

        // 事件监听器
        // Tab切换
        dcPanelBody.find('.dc_tab-item').on('click', function () {
            const targetTab = jQuery(this).data('tab');

            // 移除所有active类
            dcPanelBody.find('.dc_tab-item').removeClass('active');
            dcPanelBody.find('.dc_tab-content').removeClass('active');

            // 添加active类到当前tab
            jQuery(this).addClass('active');
            dcPanelBody.find('#' + targetTab + 'Tab').addClass('active');
        });

        // 页面方向变化
        orientationRadios.on('change', function () {
            updatePreview();
            updateAdvancedPreview();
        });

        // 页面大小变化
        pageSizeSelect.on('change', function () {
            const pageSize = jQuery(this).val();

            // 根据选择启用或禁用页面尺寸输入框
            if (pageSize === 'Custom') {
                pageWidthInput.prop('disabled', false);
                pageHeightInput.prop('disabled', false);
            } else {
                pageWidthInput.prop('disabled', true);
                pageHeightInput.prop('disabled', true);
            }

            updatePreview();
            updateAdvancedPreview();
        });

        // 自定义页面尺寸变化
        [pageWidthInput, pageHeightInput].forEach(input => {
            input.on('input', function () {
                updatePreview();
                updateAdvancedPreview();
            });
        });

        //空白文本变化的禁用状态修改
        [TerminalText, TerminalTextInMiddlePage].forEach(select => {
            select.on('change', function () {
                updateTerminalTextState();
            });
        });



        // 页边距变化
        Object.values(marginInputs).forEach(input => {
            input.on('input', function () {
                updatePreview();
                updateAdvancedPreview();
            });
        });

        // 事件监听器修改
        [headerHeightInput, footerHeightInput, dcGutterPosition].forEach(input => {
            input.on('input', function () {
                // 显示厘米换算值
                if (this.id === 'headerHeight') {
                    const cmValue = (parseFloat(this.value) * 0.0254).toFixed(2);
                    dcPanelBody.find('#headerHeightDistance').text(`≈${cmValue} cm`);
                } else if (this.id === 'footerHeight') {
                    const cmValue = (parseFloat(this.value) * 0.0254).toFixed(2);
                    dcPanelBody.find('#footerHeightDistance').text(`≈${cmValue} cm`);
                } else if (this.id === 'dcGutterPosition') {
                    const cmValue = (parseFloat(this.value) * 0.0254).toFixed(2);
                    dcPanelBody.find('#dcGutterPositionDistance').text(`≈${cmValue} cm`);
                }

                updateHeaderFooterPreview();
            });
        });



        // 设置初始值
        if (options) {
            // 设置页面方向
            if (options.Landscape === true) {
                dcPanelBody.find('input[name="orientation"][value="landscape"]').prop('checked', true);
            } else {
                dcPanelBody.find('input[name="orientation"][value="portrait"]').prop('checked', true);
            }

            // 设置页面大小
            if (options.PaperKind) {
                pageSizeSelect.val(options.PaperKind);
                if (options.PaperKind === 'Custom') {
                    pageWidthInput.prop('disabled', false);
                    pageHeightInput.prop('disabled', false);
                }
            }

            // 设置页面尺寸
            if (options.PaperWidthInCM) pageWidthInput.val(options.PaperWidthInCM.toFixed(2));
            if (options.PaperHeightInCM) pageHeightInput.val(options.PaperHeightInCM.toFixed(2));

            // 设置页边距
            if (options.LeftMarginInCM) marginInputs.left.val(options.LeftMarginInCM.toFixed(2));
            if (options.RightMarginInCM) marginInputs.right.val(options.RightMarginInCM.toFixed(2));
            if (options.TopMarginInCM) marginInputs.top.val(options.TopMarginInCM.toFixed(2));
            if (options.BottomMarginInCM) marginInputs.bottom.val(options.BottomMarginInCM.toFixed(2));


            // 设置页眉页脚
            if (options.HeaderDistance) {
                headerHeightInput.val(options.HeaderDistance);
                const cmValue = (options.HeaderDistance * 0.0254).toFixed(2);
                dcPanelBody.find('#headerHeightDistance').text(`≈${cmValue} cm`);
            }
            if (options.FooterDistance) {
                footerHeightInput.val(options.FooterDistance);
                const cmValue = (options.FooterDistance * 0.0254).toFixed(2);
                dcPanelBody.find('#footerHeightDistance').text(`≈${cmValue} cm`);
            }

            // 设置首页页眉页脚不同
            if (options.HeaderFooterDifferentFirstPage) differentFirstPageCheckbox.prop('checked', options.HeaderFooterDifferentFirstPage);


            // 设置装订线
            if (gutterOptions) {
                // 距离
                if (gutterOptions.GutterPosition || gutterOptions.GutterPosition == 0) {
                    dcGutterPosition.val(gutterOptions.GutterPosition);
                    const cmValue = (gutterOptions.GutterPosition * 0.0254).toFixed(2);
                    dcGutterPositionDistance.text(`≈${cmValue} cm`);
                }
                // 装订线位置
                if (gutterOptions.GutterStyle) {
                    dcPanelBody.find(`input[name="GutterStyle"][value="${gutterOptions.GutterStyle}"]`).prop('checked', true);
                }
                // 是否显示装订线
                if (gutterOptions.ShowGutterLine) {
                    dcPanelBody.find(`input[name="ShowGutterLine"]`).prop('checked', true);
                }
                // 是否双面打印切换装订线
                if (gutterOptions.SwapGutter) {
                    dcPanelBody.find(`input[name="SwapGutter"]`).prop('checked', true);
                }
            }

            //空白占位符
            var TerminalTextValueArr = ["line:/", "line:2", "line:S"];
            //空白文本最后一页字体
            if (TerminalTextOptions && TerminalTextOptions.Text) {
                //判断是否为自定义文本
                if (TerminalTextValueArr.indexOf(TerminalTextOptions.Text) < 0) {
                    TerminalText.val('text');
                    TerminalTextInner.val(TerminalTextOptions.Text);
                } else {
                    TerminalText.val(TerminalTextOptions.Text);
                }
            }
            //空白文本中间字体
            if (TerminalTextOptions && TerminalTextOptions.TextInMiddlePage) {
                //判断是否为自定义文本
                if (TerminalTextValueArr.indexOf(TerminalTextOptions.TextInMiddlePage) < 0) {
                    TerminalTextInMiddlePage.val('text');
                    TerminalTextInMiddlePageInner.val(TerminalTextOptions.TextInMiddlePage);

                } else {
                    TerminalTextInMiddlePage.val(TerminalTextOptions.TextInMiddlePage);
                }
            }
            //空白文本中间字体样式
            if (TerminalTextOptions && TerminalTextOptions.Font && TerminalTextOptions.Font.length) {
                var fontParts = TerminalTextOptions.Font.split(",");
                var TerminalTextFontName = dcPanelBody.find('#TerminalTextFontName');
                TerminalTextFontName.val((fontParts[0] && fontParts[0].trim()) || "宋体");
                var TerminalTextFontSize = dcPanelBody.find('#TerminalTextFontSize');
                TerminalTextFontSize.val(fontParts[1] && fontParts[1].trim() || "12");
            }



            //空白文本字体颜色
            var TerminalTextColorBox = dcPanelBody.find('#TerminalTextColor')[0];
            if (TerminalTextColorBox) {
                // 初始化颜色值
                var colorValue = '#000000';
                if (TerminalTextOptions && TerminalTextOptions.ColorValue) {
                    colorValue = TerminalTextOptions.ColorValue || '#000000';
                } else {
                    // 如果没有提供值，使用HTML中的默认值或当前data-value
                    colorValue = TerminalTextColorBox.getAttribute('data-value') || '#000000';
                }
                TerminalTextColorBox.style.backgroundColor = colorValue;
                TerminalTextColorBox.setAttribute('data-value', colorValue);

                // 添加点击事件处理器
                jQuery(TerminalTextColorBox).off('click').on('click', function () {
                    // 检查是否被禁用
                    if (this.style.pointerEvents === 'none') {
                        return;
                    }
                    var element = this;
                    DC_ColorPickerModule.show({
                        id: 'TerminalTextColor_picker',
                        triggerElement: element,
                        defaultColor: element.getAttribute("data-value") || '#000000'
                    }, function (color) {
                        element.style.backgroundColor = color;
                        element.setAttribute("data-value", color);
                    });
                });
            }

            //空白文本最小高度
            if (TerminalTextOptions && TerminalTextOptions.MinHeightInCMUnit) {
                var TerminalTextMinHeightInCMUnit = dcPanelBody.find('#TerminalTextMinHeightInCMUnit');
                TerminalTextMinHeightInCMUnit.val(TerminalTextOptions.MinHeightInCMUnit);
            }

            if (options && options.JointPrintNumber) {
                dcPanelBody.find('#JointPrintNumber').val(options.JointPrintNumber);
            }

        }

        // 初始化预览
        updatePreview();
        updateAdvancedPreview();
        updateTerminalTextState();
        updateHeaderFooterPreview();



        function successFun() {
            // 更新页面设置
            const orientation = orientationRadios.filter(':checked').val();
            const pageSize = pageSizeSelect.val();
            const margins = {
                left: parseFloat(marginInputs.left.val()),
                right: parseFloat(marginInputs.right.val()),
                top: parseFloat(marginInputs.top.val()),
                bottom: parseFloat(marginInputs.bottom.val())
            };

            // 获取页面尺寸
            let pageDimensions;
            pageDimensions = {
                width: parseFloat(pageWidthInput.val()),
                height: parseFloat(pageHeightInput.val())
            };

            const advanced = {
                headerHeight: parseFloat(headerHeightInput.val()),
                footerHeight: parseFloat(footerHeightInput.val()),
                differentFirstPage: differentFirstPageCheckbox.is(':checked'),
            };
            //拼接打印数
            var JointPrintNumber = dcPanelBody.find('#JointPrintNumber').val();
            if (JointPrintNumber) {
                JointPrintNumber = parseInt(JointPrintNumber);
            } else {
                JointPrintNumber = 1;
            }

            // 转换为原有格式
            const _data = {
                // ...options,
                Landscape: orientation === 'landscape',
                PaperKind: pageSize,
                PaperWidthInCM: pageDimensions.width,
                PaperHeightInCM: pageDimensions.height,
                LeftMarginInCM: margins.left,
                RightMarginInCM: margins.right,
                TopMarginInCM: margins.top,
                BottomMarginInCM: margins.bottom,
                HeaderDistance: advanced.headerHeight,
                FooterDistance: advanced.footerHeight,
                HeaderFooterDifferentFirstPage: advanced.differentFirstPage,
                JointPrintNumber: JointPrintNumber,
            };

            console.log(_data, '===================_data');
            ctl.ChangeDocumentSettings(_data);


            // 更新装订线设置
            var GutterStyle = dcPanelBody.find('input[name="GutterStyle"]:checked').val();
            var GutterPosition = parseFloat(dcGutterPosition.val());
            var ShowGutterLine = dcPanelBody.find('input[name="ShowGutterLine"]:checked').val();
            var SwapGutter = dcPanelBody.find('input[name="SwapGutter"]:checked').val();
            var gutterOptions = {
                ShowGutterLine: ShowGutterLine === "on",
                GutterPosition,
                SwapGutter: SwapGutter === "on",
                GutterStyle
            };
            ctl.SetDocumentGutter(gutterOptions);


            //更新空白占位文本
            var TerminalText = dcPanelBody.find('#TerminalText').val();
            var TerminalTextInMiddlePage = dcPanelBody.find('#TerminalTextInMiddlePage').val();
            var TerminalTextFontName = dcPanelBody.find('#TerminalTextFontName').val();
            var TerminalTextFontSize = dcPanelBody.find('#TerminalTextFontSize').val();
            var TerminalTextFont = TerminalTextFontName + ',' + TerminalTextFontSize;
            // TerminalTextColor 现在是 div，从 data-value 读取值
            var TerminalTextColorBox = dcPanelBody.find('#TerminalTextColor')[0];
            var TerminalTextColor = TerminalTextColorBox ? (TerminalTextColorBox.getAttribute('data-value') || '#000000') : '#000000';
            var TerminalTextMinHeightInCMUnit = dcPanelBody.find('#TerminalTextMinHeightInCMUnit').val();
            //转译字符
            if (TerminalText === 'line:2') {
                TerminalText = 'line:\\';
            }
            if (TerminalTextInMiddlePage === 'line:2') {
                TerminalTextInMiddlePage = 'line:\\';
            }

            var TerminalTextOptions = {
                "Text": TerminalText === 'none' ? null : TerminalText,
                "TextInMiddlePage": TerminalTextInMiddlePage === 'none' ? null : TerminalTextInMiddlePage,
                "Font": TerminalTextFont,
                "ColorValue": TerminalTextColor,
                "MinHeightInCMUnit": TerminalTextMinHeightInCMUnit
            };
            //更新空白占位文本
            if (TerminalTextOptions.Text === 'text') {
                TerminalTextOptions.Text = dcPanelBody.find('#TerminalTextInner').val();
            }
            if (TerminalTextOptions.TextInMiddlePage === 'text') {
                TerminalTextOptions.TextInMiddlePage = dcPanelBody.find('#TerminalTextInMiddlePageInner').val();
            }


            // console.log(TerminalTextOptions, '=====TerminalTextOptions2');
            ctl.SetDocumentTerminalText(TerminalTextOptions);


            // 刷新文档
            ctl.RefreshDocument();
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetDocumentPageSettings();
                ctl.EventDialogChangeProperties(changedOptions);
            }
        }
    },


    /**
     * 创建文档网格线设置对话框
     * @param options 文档网格线属性
     * @param ctl 编辑器元素
     */
    DocumentGridLineDialog: function (options, ctl) {
        if (!options || typeof options != "object") {
            // 当未传入值时，获取当前的文档网格线数据
            options = ctl.GetDocumentGridLine();
        }
        options = keysToLowerCase(options);
        var opts = {
            Visible: "",
            ColorValue: "",
            LineStyle: "",
            GridNumInOnePage: "",
            AlignToGridLine: "",
            Printable: "",
        };
        for (var i in opts) {
            var low_i = i.toLowerCase();
            if (Object.hasOwnProperty.call(options, low_i)) {
                opts[i] = options[low_i];
            }
        }
        var DocumentGridLineHtml = `
        <div class="dcBody-content">
            <label>
                <input type="checkbox" name="Visible" data-text="Visible">
                <span>绘制网格线</span>
            </label>
        </div>
        <form id="dc_DocumentGridLine_form">
            <div class="dcBody-content">
                <label class="dc_changewidth">
                    <span class="dc_txt">网格线颜色：</span>
                    <div id="dc_DocumentGridLine_ColorValue_box" data-value="" data-text="ColorValue" style="display: inline-block; width: 164px; height: 10px; border: 1px solid rgb(217, 217, 217); border-radius: 4px; cursor: pointer; vertical-align: middle; margin-left: 5px;"></div>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_changewidth">
                    <span class="dc_txt">网格线样式：</span>
                    <select name="LineStyle" id="dc_LineStyle" data-text="LineStyle"></select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_changewidth">
                    <span class="dc_txt">每页行数<span class="dc_SpecifyWidth_title" title="每页行数必须大于2">?</span>：</span>
                    <input type="number" name="GridNumInOnePage" data-text="GridNumInOnePage" value="20">
                </label>
            </div>
            <div class="dcBody-content">
                <label>
                    <input type="checkbox" name="AlignToGridLine" data-text="AlignToGridLine" checked>
                    <span>文本是否对齐到网格线</span>
                </label>
            </div>
            <div class="dcBody-content">
                <label>
                    <input type="checkbox" name="Printable" data-text="Printable" checked>
                    <span>是否打印网格线</span>
                </label>
            </div>
        </form>
        `;
        var dialogOptions = {
            title: "文档网格线设置",
            bodyClass: "DocumentGridLine",
            bodyHtml: DocumentGridLineHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var LineStyle_node = dcPanelBody.find("#dc_LineStyle");
        let that = this;

        for (var i = 0; i < DASHSTYLE.length; i++) {
            var _DashStyle = DASHSTYLE[i];
            LineStyle_node.append(
                "<option value='" +
                _DashStyle.name +
                "'>" +
                _DashStyle.show +
                _DashStyle.name +
                "</option>"
            );
        }
        var DocumentGridLine_form = dcPanelBody.find(
            "form#dc_DocumentGridLine_form"
        )[0];
        // 是否绘制网格线点击事件
        dcPanelBody.find("input[data-text=Visible]").on("click", function () {
            var isVisible = jQuery(this).is(":checked");
            that.changeFormDisable(DocumentGridLine_form, !isVisible);
        });

        function DocumentGridLineData(data) {
            var isChange = typeof data == "object";
            var obj = {};
            dcPanelBody.find("[data-text]").each(function () {
                var _el = jQuery(this);
                var _txt = _el.attr("data-text");
                if (this.type == "checkbox") {
                    obj[_txt] = _el.is(":checked");
                    if (isChange) {
                        _el.prop("checked", data[_txt]);
                        if (_txt == "Visible") {
                            //是否绘制网格线
                            that.changeFormDisable(DocumentGridLine_form, !data[_txt]);
                        }
                    }
                } else {
                    // 如果元素是 div 且有 data-value 属性，则从 data-value 读取值
                    var _value;
                    if (this.nodeName === "DIV" && _el.attr("data-value") !== undefined) {
                        _value = _el.attr("data-value") || "";
                    } else {
                        _value = _el.val();
                    }
                    if (this.type == "number") {
                        _value -= 0;
                    }
                    obj[_txt] = _value;
                    if (isChange) {
                        // 如果元素是 div 且有 data-value 属性，则设置 data-value 和 backgroundColor
                        if (this.nodeName === "DIV" && _el.attr("data-value") !== undefined) {
                            var _value = data[_txt] || "";
                            _el.attr("data-value", _value);
                            // 如果是颜色值，同时设置背景色
                            if (_txt && (_txt.toLowerCase().indexOf("color") >= 0 || _txt.toLowerCase().indexOf("colour") >= 0)) {
                                _el[0].style.backgroundColor = _value || "#000000";
                            }
                        } else {
                            _el.val(data[_txt]);
                        }
                    }
                }
            });
            if (isChange) {
                return true;
            } else {
                return obj;
            }
        }
        // console.log("当前文档网格线设置值=>", opts)
        // 添加值
        DocumentGridLineData(opts);

        // 文档网格线颜色 - 点击色块弹出颜色选择器
        const documentGridLineColorBox = jQuery(dcPanelBody).find('#dc_DocumentGridLine_ColorValue_box')[0];
        if (documentGridLineColorBox) {
            // 确保颜色框可见且可点击（如果网格线未启用则会被禁用，但颜色框仍应该可以点击）
            jQuery(documentGridLineColorBox).off('click').on('click', function () {
                if (!jQuery(dcPanelBody).find("input[data-text=Visible]")[0].checked) {
                    return;
                }
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_DocumentGridLine_ColorValue_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#000000'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }

        function successFun() {
            var _data = DocumentGridLineData();
            ctl.SetDocumentGridLine(_data);
            ctl.RefreshDocument();
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetDocumentGridLine();
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建文档装订线设置对话框
     * @param options 文档装订线属性
     * @param ctl 编辑器元素
     */
    DocumentGutterDialog: function (options, ctl) {
        if (!options || typeof options != "object") {
            // 当未传入值时，获取当前的文档装订线数据
            options = ctl.GetDocumentGutter();
        }
        options = keysToLowerCase(options);
        var opts = {
            ShowGutterLine: "",
            GutterPosition: "",
            SwapGutter: "",
            GutterStyle: "",
        };
        for (var i in opts) {
            var low_i = i.toLowerCase();
            if (Object.hasOwnProperty.call(options, low_i)) {
                opts[i] = options[low_i];
            }
        }
        var DocumentGutterHtml = `
        <div class="dcBody-content">
                <label>
                    <input type="checkbox" name="ShowGutterLine" data-text="ShowGutterLine">
                    <span>显示装订线</span>
                </label>
            </div>
            <div class="dcBody-content">
                <label>
                    <span class="dc_txt">装订线距离：</span>
                    <input type="number" name="GutterPosition" data-text="GutterPosition" value="0">
                </label>
            </div>
            <div class="dcBody-content">
                <label>
                    <input type="checkbox" name="SwapGutter" data-text="SwapGutter" checked>
                    <span>为双面打印切换装订线</span>
                </label>
            </div>
            <div class="dcBody-content dc_GutterStyleDiv">
                <span>位置</span>
                <label><input type="radio" name="GutterStyle" value="Left" data-text="GutterStyle" checked><span>左</span></label>
                <label><input type="radio" name="GutterStyle" value="Top" data-text="GutterStyle"><span>上</span></label>
                <label><input type="radio" name="GutterStyle" value="Right" data-text="GutterStyle"><span>右</span></label>
            </div>
            
            
            `;
        var dialogOptions = {
            title: "文档装订线设置",
            bodyClass: "DocumentGutter",
            bodyHtml: DocumentGutterHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        GetOrChangeData(dcPanelBody, opts);
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            // console.log("successFun -> _data", _data)
            ctl.SetDocumentGutter(_data);
            ctl.RefreshDocument();
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetDocumentGutter();
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建单复选框属性对话框
     * @param options 单复选框属性
     * @param ctl 编辑器元素
     */
    CheckboxAndRadioDialog: function (options, ctl, ele) {
        var typename = ctl.GetCurrentElementTypeName();//当前元素的类型名称
        if (!options || typeof options != "object" || JSON.stringify(options) === '{}') {
            if (ele) {
                options = ctl.GetElementProperties(ele);
            } else if (['xtextradioboxelement', 'xtextcheckboxelement'].includes(typename)) {
                options = ctl.GetElementProperties(ctl.CurrentElement(typename));
            }
        }
        if (!options) {
            return false;
        }
        var backupCaptionFlowLayout = options.CaptionFlowLayout;
        var backupParent = options.Parent;

        //获取enableChkIdVal属性，用于判断是否需要进行必填校验
        var enableChkIdVal = ctl.getAttribute('enableChkIdVal') || false;
        ////wyc20231019:防止数据丢失做一个转换
        //if (options.VisualStyle === "SystemDefault") {
        //    options.VisualStyle = "Default";
        //}
        //if (options.VisualStyle === "SystemCheckBox") {
        //    options.VisualStyle = "CheckBox";
        //}
        //if (options.VisualStyle === "SystemRadioBox") {
        //    options.VisualStyle = "RadioBox";
        //}

        var checkboxAndRadioHTML = `
            <!-- 基础属性 -->
            <div class="form-section">
                <div class="section-title">基础属性</div>
                <div class="form-group">
                    <div class="form-row">
                        <label class="form-label"><span class="required-mark" ${enableChkIdVal ? 'style="display: inline-block;"' : 'style="display: none;"'}>*</span>编号：</label>
                        <input type="text" class="form-input" name="ID" data-text="ID">
                    </div>
                    <div class="form-row">
                        <label class="form-label"><span class="required-mark" ${enableChkIdVal ? 'style="display: inline-block;"' : 'style="display: none;"'}>*</span>名称：</label>
                        <input type="text" class="form-input" name="Name" data-text="Name">
                    </div>
                    <div class="form-row">
                        <label class="form-label"><span class="required-mark" ${enableChkIdVal ? 'style="display: inline-block;"' : 'style="display: none;"'}>*</span>文本：</label>
                        <input type="text" class="form-input" name="Text" data-text="Text">
                    </div>
                    <div class="form-row">
                        <label class="form-label"><span class="required-mark" ${enableChkIdVal ? 'style="display: inline-block;"' : 'style="display: none;"'}>*</span>数值：</label>
                        <input type="text" class="form-input" name="Value" data-text="Value">
                    </div>
                    <div class="form-row">  
                        <label class="form-label">提示文本：</label>
                        <input type="text" class="form-input" name="ToolTip" data-text="ToolTip" placeholder="鼠标悬停时显示的提示信息">
                    </div>
                    <div class="form-row" style="margin-bottom: 0;">
                        <label class="form-label">附加数据：</label>
                        <input type="text" class="form-input" name="StringTag" data-text="StringTag" placeholder="可选的附加数据（JSON格式）">
                    </div>
                </div>
            </div>

            <!-- 显示与状态 -->
            <div class="form-section">
                <div class="section-title">显示与状态</div>
                <div class="form-group">
                    <div class="form-row">
                        <label class="form-label">显示样式：</label>
                        <select class="form-select" data-text="VisualStyle">
                            <option value="Default">默认样式</option>
                            <option value="CheckBox">复选框样式</option>
                            <option value="RadioBox">单选框样式</option>
                            <option value="SystemDefault">操作系统默认样式</option>
                            <option value="SystemCheckBox">操作系统默认复选框样式</option>
                            <option value="SystemRadioBox">操作系统默认单选框样式</option>
                        </select>
                    </div>
                    <div class="form-row">
                        <label class="form-label">高亮度状态：</label>
                        <select class="form-select" data-text="EnableHighlight">
                            <option value="Default">默认</option>
                            <option value="Enabled">允许</option>
                            <option value="Disabled">禁止</option>
                        </select>
                    </div>
                    <div class="form-row">
                        <label class="form-label">不勾选时的打印设置：</label>
                        <select class="form-select" data-text="PrintVisibilityWhenUnchecked">
                            <option value="Visible">正常打印</option>
                            <option value="HiddenCheckBoxOnly">不打印勾选框，但仍然打印文本</option>
                            <option value="HiddenAll">不打印</option>
                        </select>
                    </div>
                    <div class="form-row" style="margin-bottom: 0;">
                        <label class="form-label" style="min-width: 90px;">选项：</label>
                        <div class="checkbox-grid" style="flex: 1;">
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="Checked" data-text="Checked" id="chk_Checked">
                                <label class="checkbox-label" for="chk_Checked">选中</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="Deleteable" data-text="Deleteable" id="chk_Deleteable">
                                <label class="checkbox-label" for="chk_Deleteable">允许删除</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="Multiline" data-text="Multiline" id="chk_Multiline">
                                <label class="checkbox-label" for="chk_Multiline">文本多行</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="Enabled" data-text="Enabled" id="chk_Enabled">
                                <label class="checkbox-label" for="chk_Enabled">是否可用</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="CheckAlignLeft" data-text="CheckAlignLeft" id="chk_CheckAlignLeft">
                                <label class="checkbox-label" for="chk_CheckAlignLeft">左对齐</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="Requried" data-text="Requried" id="chk_Requried">
                                <label class="checkbox-label" for="chk_Requried">必勾项</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" name="CaptionFlowLayout" data-text="CaptionFlowLayout" id="chk_CaptionFlowLayout">
                                <label class="checkbox-label" for="chk_CaptionFlowLayout">流式排版</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 表达式 -->
            <div class="data-section">
                <div class="section-title">表达式</div>
                <div class="form-group">
                    <div class="form-row">
                        <label class="form-label">可见性表达式：</label>
                        <div style="flex: 1; display: flex; gap: 8px;">
                            <input data-text="VisibleExpression" class="form-input" type="text" placeholder="">
                            <button class="example-btn dc_visible_expression">示例</button>
                        </div>
                    </div>
                    <div class="form-row" style="margin-bottom: 0;">
                        <label class="form-label">属性表达式：</label>
                        <div style="flex: 1; display: flex; gap: 8px;">
                            <input id="dc_PropertyExpressions_show_input" class="form-input" readonly="readonly" type="text" placeholder="">
                            <button class="example-btn" id="dc_PropertyExpressionsButton">打开</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 可见性配置 -->
            <div class="data-section">
                <div class="section-title">可见性配置</div>
                <div class="form-group">
                    <div class="form-row" style="margin-bottom: 0;">
                        <div id="dc_CheckboxVisibility" class="checkbox-grid" style="flex: 1;">
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" data-value="Hidden" id="vis_Hidden">
                                <label class="checkbox-label" for="vis_Hidden">Hidden</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" data-value="Paint" id="vis_Paint">
                                <label class="checkbox-label" for="vis_Paint">Paint</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" data-value="Print" id="vis_Print">
                                <label class="checkbox-label" for="vis_Print">Print</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" data-value="PDF" id="vis_PDF">
                                <label class="checkbox-label" for="vis_PDF">PDF</label>
                            </div>
                            <div class="checkbox-item">
                                <input type="checkbox" class="form-checkbox" data-value="All" id="vis_All">
                                <label class="checkbox-label" for="vis_All">All</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <!-- 数据源信息 -->
            <div class="data-section" id="dc_datasource_section">
                <div class="section-title">数据源信息</div>
                <div class="form-group" id="dc_datasource_container"></div>
            </div>

            <!-- 自定义属性 -->
            <div class="data-section">
                <div class="section-title">自定义属性</div>
                <div id="dc_attr-box"></div>
            </div>
        `;
        var dialogOptions = {
            title: (typename === 'xtextradioboxelement' ? "单" : "复") + "选框属性",
            bodyHeight: 455,
            bodyClass: "CheckboxAndRadio",
            bodyHtml: checkboxAndRadioHTML,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        this.attributeComponents(
            "#dc_attr-box",
            (options && options.Attributes) || {},
            ctl
        );
        // 将数据源信息插入到指定容器
        var datasourceContainer = dcPanelBody.find("#dc_datasource_container");
        WriterControl_Dialog.appendValueBindingDiv(datasourceContainer);
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);

        //[DUWRITER5_0-3387]20240820 lxy 增加可见性配置
        var allCheckboxVisibility = dcPanelBody.find("#dc_CheckboxVisibility input[data-value]");
        if (options.CheckboxVisibility) {
            let checkValue = options.CheckboxVisibility.toLowerCase();
            for (var i = 0; i < allCheckboxVisibility.length; i++) {
                let itemValue = allCheckboxVisibility[i].getAttribute('data-value');
                itemValue = itemValue.toLowerCase().trim();
                if (checkValue.indexOf(itemValue) > -1) {
                    allCheckboxVisibility[i].checked = true;
                } else {
                    allCheckboxVisibility[i].checked = false;
                }
            }

        }



        //[DUWRITER5_0-3748] 20241025 lxy 新增属性表达式功能
        //属性表达式值回填
        var inputValue = '';
        var propertyExpressionObject = {};
        var propertyShowInput = ctl.ownerDocument.getElementById('dc_PropertyExpressions_show_input');
        var propertyKeyArr = (options.PropertyExpressions && Object.keys(options.PropertyExpressions)) || [];
        RADIOCHECKPROPERTYEXPRESSIONSARRAY.forEach(item => {
            if (propertyKeyArr.length && propertyKeyArr.indexOf && propertyKeyArr.indexOf(item) > -1) {
                propertyExpressionObject[item] = options.PropertyExpressions[item];
                //展示文本
                if (options.PropertyExpressions[item] !== '') {
                    inputValue += `${inputValue === '' ? '' : ','}${item}:${options.PropertyExpressions[item]}`;
                }
            } else {
                propertyExpressionObject[item] = '';
            }
        });

        propertyShowInput.value = inputValue;

        //属性表达式操作对话框

        var propertyExpressionsButton = jQuery(ctl).find("#dc_PropertyExpressionsButton");
        propertyExpressionsButton.click(function () {

            // //判断是否已经存在修改过的属性表达式
            // if (!propertyExpressionObject || Object.keys(propertyExpressionObject).length === 0) {
            //     RADIOCHECKPROPERTYEXPRESSIONSARRAY.forEach(item => {
            //         propertyExpressionObject[item] = '';
            //     });
            // }

            that.PropertyExpressionsDialog(propertyExpressionObject, ctl, function (changedPropertyExpressions) {
                //获取修改后的属性表达式
                propertyExpressionObject = JSON.parse(JSON.stringify(changedPropertyExpressions));
                //更新属性表达式的显示
                var inputValue = '';
                for (let key in changedPropertyExpressions) {
                    if (changedPropertyExpressions[key] !== '' && key !== 'Visible') {
                        inputValue += `${inputValue === '' ? '' : ','}${key}:${changedPropertyExpressions[key]}`;
                    }
                }
                propertyShowInput.value = inputValue;
            });
        });



        //成功的回调函数
        let that = this;
        function successFun() {
            let dcAttrBox = dcPanelBody.find('#dc_attr-box');
            let Attributes = that.attributeComponents_getAttributeObj(dcAttrBox);
            var _data = GetOrChangeData(dcPanelBody);
            _data["Attributes"] = Attributes;
            let CheckboxVisibility = [];
            allCheckboxVisibility.each(function () {
                if (this.checked) {
                    CheckboxVisibility.push(this.getAttribute('data-value'));
                }
            });
            _data["CheckboxVisibility"] = CheckboxVisibility.join(",");

            // [DUWRITER5_0-3748] 20241025 lxy 新增属性表达式功能
            _data['PropertyExpressions'] = {};
            for (var key in propertyExpressionObject) {
                if (propertyExpressionObject[key] !== '') {
                    _data['PropertyExpressions'][key] = propertyExpressionObject[key];
                }
            }

            //可见性表达式赋值
            if (_data && _data.VisibleExpression && _data.VisibleExpression.trim() !== '') {
                _data['PropertyExpressions']['Visible'] = _data.VisibleExpression;
            }

            // 必填校验（当enableChkIdVal为true时）
            if (enableChkIdVal === 'true' || enableChkIdVal === true) {
                // 校验编号
                function validateField(fieldName, displayName) {
                    var $input = dcPanelBody.find(`input[name="${fieldName}"]`);
                    var value = $input.val();
                    if (!value || value.trim() === '') {
                        $input.addClass('error');
                        var $formRow = $input.closest('.form-row');

                        if ($formRow.find(".dc-error-tip").length === 0) {
                            $formRow.append(`<div class='dc-error-tip' style='color: #d32f2f; font-size: 11px; margin-top: 2px;'>${displayName}不能为空</div>`);
                        }

                        $input.off("input.clearError").on("input.clearError", function () {
                            $input.removeClass('error');
                            $formRow.find(".dc-error-tip").remove();
                        });

                        $input.focus();
                        $input[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
                        return false;
                    }
                    return true;
                }

                // 依次校验编号、名称、文本、数值
                if (!validateField('ID', '编号')) {
                    return false;
                }
                if (!validateField('Name', '名称')) {
                    return false;
                }
                if (!validateField('Text', '文本')) {
                    return false;
                }
                if (!validateField('Value', '数值')) {
                    return false;
                }
            }

            ctl.SetElementProperties(ele, _data, true);
            //wyc20231019:更改流式排版属性会导致排版错乱，在此追加一个对父容器的刷新
            if (_data.CaptionFlowLayout !== backupCaptionFlowLayout) {
                ctl.EditorRefreshContainerView(backupParent);
            }
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建插入多个单选框/复选框对话框
     * @param options 单复选框属性
     * @param ctl 编辑器元素
     */
    InsertMultipleCheckBoxOrRadioDialog: function (options, ctl) {
        if (!options || typeof options != "object") {
            options = {}; // 当未传入值时,
        }

        //DUWRITER5_0-4892 20251105 lxy 处理单选框/复选框的列表ID
        var enableChkIdVal = ctl.getAttribute('enableChkIdVal') || false;

        var InsertMultipleCheckBoxOrRadioHtml = `
        <div class="dcBody-content">
            <div class="dc_title">控件类型</div>
            <form class="dc_Box IsRadioBox">
                <div class="dcBody-content">
                    <label class="dc_firstRadio">
                        <input type="radio" name="Type" data-text="Type" value="radio" checked>
                        <span>单选框</span>
                    </label>
                    <label>
                        <input type="radio" name="Type" data-text="Type" value="checkbox">
                        <span>复选框</span>
                    </label>
                </div>
            </form>
        </div>
        <div class="dcBody-content">
            <div class="dc_title" >基础属性</div>
            <div class="dc_Box">
                <label class="dc_flex">
                    <span class="dcTitle-text">名称：</span>
                    <input type="text" class="dc_full" name="Name" id="dc_Name" data-text="Name">
                </label>
                <label class="dc_flex" style="margin-bottom: 0;">
                    <span class="dcTitle-text">显示样式：</span>
                    <select class="dc_full" data-text="VisualStyle">
                        <option value="Default">默认样式</option>
                        <option value="CheckBox">复选框样式</option>
                        <option value="RadioBox">单选框样式</option>
                        <option value="SystemDefault">操作系统默认样式</option>
                        <option value="SystemCheckBox">操作系统默认复选框样式</option>
                        <option value="SystemRadioBox">操作系统默认单选框样式</option>
                    </select>
                </label>
                <label class="dc_flex" style="margin-bottom: 0;">
                    <span class="dcTitle-text">可见性表达式：</span>
                    <input data-text="VisibleExpression" class="dc_full" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>
        </div>
        <div class="dcBody-content">
            <div class="dc_title">选项设置</div>
            <div class="dc_Box">
                <div class="dc_checkboxs">
                    <label>
                        <input type="checkbox" name="Deleteable" data-text="Deleteable" checked>
                        <span>可以删除</span>
                    </label>
                    <label>
                        <input type="checkbox" name="CheckAlignLeft" data-text="CheckAlignLeft" checked>
                        <span>勾选框左对齐</span>
                    </label>
                    <label>
                        <input type="checkbox" name="Multiline" data-text="Multiline">
                        <span>文本多行</span>
                    </label>
                    <label>
                        <input type="checkbox" name="Requried" data-text="Requried">
                        <span>必勾项</span>
                    </label>
                    <label>
                        <input type="checkbox" name="CaptionFlowLayout" checked data-text="CaptionFlowLayout">
                        <span>文本参与流式排版</span>
                    </label>
                </div>
            </div>
        </div>
        <div class="dcBody-content data-section">
            <div class="dc_title" >数值属性</div>
            <div class="dc_Box">
                <div class="dc_tab3Content">
                    <label>
                        <span>数据源名称：</span>
                        <input id="dc_DataSource" type="text" />
                    </label>
                    <label>
                        <span>绑定路径：</span>
                        <input id="dc_BindingPath" type="text" />
                    </label>
                </div>
            </div>
        </div>
        <div class="dcBody-content data-section">
            <form class="">
                <h6 class="dc_title">项目列表</h6>
                <table id="dc_ListItems" data-text="ListItems" data-type="Array" class="dc_scroll-table">
                    <thead>
                        <th>编号</th>
                        <th>文本</th>
                        <th>数值</th>
                        <th class="dc_last">操作</th>
                    </thead>
                    <tbody>
                        <tr>
                            <td><input type="text" data-arraytext="ID"></td>
                            <td><input type="text" data-arraytext="Text"></td>
                            <td><input type="text" data-arraytext="Value"></td>
                            <td class="dc_delete" title="删除">×</td>
                        </tr>
                    </tbody>
                    <template class="dc_template_item">
                        <tr>
                            <td><input type="text" data-arraytext="ID"></td>
                            <td><input type="text" data-arraytext="Text"></td>
                            <td><input type="text" data-arraytext="Value"></td>
                            <td class="dc_delete" title="删除">×</td>
                        </tr>
                    </template>
                </table>
                <button type="button" class="dc-add-row-btn" id="dc-add-row-btn">+ 添加项目</button>
            </form>
        </div>
        `;
        var dialogOptions = {
            title: "插入多个单选框/复选框",
            bodyHeight: 500,
            dialogContainerBodyWidth: 450,
            bodyClass: "InsertMultipleCheckBoxOrRadio",
            bodyHtml: InsertMultipleCheckBoxOrRadioHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        // 增加接口
        dcPanelBody
            .find("#dc_ListItems")
            .on("input", "input[data-arraytext]", function (event) {
                var input = jQuery(this);
                var tr = input.parents("tr");
                if (tr.nextAll("tr").length == 0) {
                    var ListItems_item = input
                        .parents("table")
                        .find("template.dc_template_item")[0];
                    tr.after(ListItems_item.content.cloneNode(true));
                }
            });

        dcPanelBody.find("#dc_ListItems").on("click", "td.dc_delete", function () {
            var tr = jQuery(this).parents("tr");
            var tbody = tr.parent("tbody");

            // 判断tbody下是否只剩一行
            if (tbody.find("tr").length > 1) {
                // 不是只剩一行，可以删除
                tr.remove();
            } else {
                // 只剩一行，不允许删除，可以给提示
                alert("至少保留一行");
            }
        });

        // 添加项目按钮点击事件
        dcPanelBody.find("#dc-add-row-btn").on("click", function (e) {
            e.preventDefault(); // 防止表单提交
            var tbody = dcPanelBody.find("#dc_ListItems tbody");
            var template = dcPanelBody.find("template.dc_template_item")[0];
            if (template) {
                var newRow = template.content.cloneNode(true);
                tbody.append(newRow);
            }
        });

        // 给数据源绑定赋值
        if (options && options.ValueBinding) {
            dcPanelBody
                .find("#dc_DataSource")
                .val(options.ValueBinding.DataSource || "");
            dcPanelBody
                .find("#dc_BindingPath")
                .val(options.ValueBinding.BindingPath || "");
        }
        GetOrChangeData(dcPanelBody, opts);

        //DUWRITER5_0-4892 20251105 lxy 处理单选框/复选框的列表ID
        //生成长度为10的随机数字
        function generateRandomNumber() {
            let result = '';
            for (let i = 0; i < 10; i++) {
                result += Math.floor(Math.random() * 10); // 生成0-9的随机数字
            }
            return result;
        }

        if (enableChkIdVal === 'true' || enableChkIdVal === true) {
            // 获取Name是否存在值，如果没有就给一个随机数
            var Name = dcPanelBody.find("#dc_Name").val();
            if (!Name || Name.trim() == '') {
                Name = 'group_' + generateRandomNumber();
            }
            dcPanelBody.find("#dc_Name").val(Name);

            //处理单选框/复选框的列表ID。获取所有的input[data-arraytext="ID"]
            var inputListItemsId = dcPanelBody.find("input[data-arraytext='ID']");
            Array.from(inputListItemsId).forEach((item, index) => {
                if (!item.value || item.value === '') {
                    // 判断是否是最后一行
                    var isLastItem = index === inputListItemsId.length - 1;

                    if (isLastItem) {
                        // 检查同行的Text和Value是否都为空
                        var $tr = jQuery(item).closest('tr');
                        var textValue = $tr.find("input[data-arraytext='Text']").val() || '';
                        var valueValue = $tr.find("input[data-arraytext='Value']").val() || '';

                        // 如果Text和Value都为空，则不添加ID
                        if (textValue.trim() === '' && valueValue.trim() === '') {
                            return; // 跳过本次循环
                        }
                    }

                    //判断是单选框还是复选框
                    var Type = dcPanelBody.find("input[name='Type']:checked").val();
                    if (Type === 'radio') {
                        item.value = 'rdo_' + generateRandomNumber();
                    } else {
                        item.value = 'chk_' + generateRandomNumber();
                    }
                }
            });
        }




        function successFun() {
            let {
                Type,
                Name,
                ListItems,
                VisualStyle,
                Deleteable,
                CheckAlignLeft,
                Multiline,
                Requried,
                VisibleExpression,
                CaptionFlowLayout
            } = GetOrChangeData(dcPanelBody);
            console.log(options);
            let DataSource = dcPanelBody.find("#dc_DataSource").val();
            let BindingPath = dcPanelBody.find("#dc_BindingPath").val();
            var listItemsOptions = {
                Multiline,
                VisualStyle,
                Deleteable,
                CheckAlignLeft,
                Requried,
                VisibleExpression,
                CaptionFlowLayout
            };
            if (ListItems && ListItems.length) {
                //如果没有原始数据，则直接进行添加
                for (var j = 0; j < ListItems.length; j++) {
                    ListItems[j] = Object.assign(ListItems[j], listItemsOptions);
                    //wyc20250820:修复DUWRITER5_0-4725
                    if (DataSource.length > 0 || BindingPath.length > 0) {
                        ListItems[j]['ValueBinding'] = {
                            DataSource,
                            BindingPath,
                        };
                    }
                }
            }
            // 如果插入时设置了一些对话框中没有的属性，则进行一次数据保留
            if (options && options.ListItems && options.ListItems.length) {
                for (var i = 0; i < options.ListItems.length; i++) {
                    var item = options.ListItems[i];
                    for (var j = 0; j < ListItems.length; j++) {
                        var titem = ListItems[j];
                        if (item.ID === titem.ID) {
                            for (var prop in item) {
                                if (titem[prop] === undefined) {
                                    titem[prop] = item[prop];
                                }
                                //判断是否指定了样式
                                if (item.VisualStyle) {
                                    titem[prop] = item[prop];
                                }
                            }
                            //Object.assign(ListItems[j],item );
                        }
                    }
                }
            }

            //DUWRITER5_0-4892 20251105 lxy 处理单选框/复选框的列表ID
            if (enableChkIdVal === 'true' || enableChkIdVal === true) {

                // 校验名称
                function validateName() {
                    var $dcName = dcPanelBody.find("#dc_Name");
                    var value = $dcName.val();
                    if (!value || value.trim() === '') {
                        // 为名称输入框特殊处理，错误提示显示在 label 外部
                        var $label = $dcName.closest('label.dc_flex');
                        $dcName.addClass('error');

                        if ($label.next(".dc-error-tip").length === 0) {
                            $label.after("<div class='dc-error-tip' style='margin-left: 100px;'>名称不能为空</div>");
                        }

                        $dcName.off("input.clearError").on("input.clearError", function () {
                            $dcName.removeClass('error');
                            $label.next(".dc-error-tip").remove();
                        });

                        $dcName.focus();
                        $dcName[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
                        return false;
                    }
                    return true;
                }

                // 检查最后一行是否为空行
                function isEmptyLastRow($tr) {
                    var textValue = $tr.find("input[data-arraytext='Text']").val() || '';
                    var valueValue = $tr.find("input[data-arraytext='Value']").val() || '';
                    return textValue.trim() === '' && valueValue.trim() === '';
                }

                // 校验列表项ID
                function validateListItemIds() {
                    var inputListItemsId = dcPanelBody.find("input[data-arraytext='ID']");
                    var hasEmptyId = false;
                    var emptyRows = [];

                    // 清除之前的错误状态
                    inputListItemsId.removeClass('error');
                    dcPanelBody.find("#dc_ListItems").next(".dc-error-tip").remove();

                    Array.from(inputListItemsId).forEach((item, index) => {
                        var $item = jQuery(item);
                        if (!item.value || item.value === '') {
                            // 检查当前行的Text和Value是否都为空
                            var $tr = $item.closest('tr');
                            var textValue = $tr.find("input[data-arraytext='Text']").val() || '';
                            var valueValue = $tr.find("input[data-arraytext='Value']").val() || '';

                            // 如果Text和Value都为空，则ID可以为空
                            if (textValue.trim() === '' && valueValue.trim() === '') {
                                return;
                            }

                            // 如果Text或Value有值，但ID为空，则报错
                            hasEmptyId = true;
                            $item.addClass('error');
                            emptyRows.push(index + 1);
                        }
                    });

                    if (hasEmptyId) {
                        var errorMsg = "第 " + emptyRows.join("、") + " 行的编号不能为空";
                        var $table = dcPanelBody.find("#dc_ListItems");
                        $table.after("<div class='dc-error-tip'>" + errorMsg + "</div>");

                        // 滚动到第一个错误位置
                        inputListItemsId.eq(emptyRows[0] - 1)[0].scrollIntoView({ behavior: 'smooth', block: 'center' });
                        inputListItemsId.eq(emptyRows[0] - 1).focus();

                        // 输入时清除错误
                        inputListItemsId.off("input.clearIdError").on("input.clearIdError", function () {
                            jQuery(this).removeClass('error');
                            // 重新检查是否还有错误
                            var stillHasError = false;
                            inputListItemsId.each(function () {
                                if (jQuery(this).hasClass('error')) {
                                    stillHasError = true;
                                    return false;
                                }
                            });
                            if (!stillHasError) {
                                $table.next(".dc-error-tip").remove();
                            }
                        });
                    }

                    return !hasEmptyId;
                }

                // 处理重复ID
                function handleDuplicateIds() {
                    ListItems.forEach(item => {
                        var ID = item.ID;
                        var duplicateIndexes = [];

                        ListItems.forEach((listItem, index) => {
                            if (listItem.ID === ID) {
                                duplicateIndexes.push(index);
                            }
                        });

                        if (duplicateIndexes.length > 1) {
                            for (let i = 1; i < duplicateIndexes.length; i++) {
                                ListItems[duplicateIndexes[i]].ID = ID + "_" + i;
                            }
                        }
                    });
                }

                // 执行验证
                if (!validateName() || !validateListItemIds()) {
                    return false;
                }

                // 处理重复ID
                handleDuplicateIds();
            }

            var newData = {
                ...options,
                Type,
                Name,
                ListItems
            };
            console.log('newData', newData);
            var result = ctl.DCExecuteCommand("insertcheckboxorradio", false, newData);
            if (result) {
                //DUWRITER5_0-3877 20241121 lxy 新增插入多个单选框/复选框后触发事件
                if (ctl.EventInsertMultipleCheckBoxOrRadioAfter && typeof ctl.EventInsertMultipleCheckBoxOrRadioAfter === 'function') {
                    ctl.EventInsertMultipleCheckBoxOrRadioAfter(newData);
                }
            }

        }
    },

    /**
     * 创建文本标签属性对话框
     * @param options 文本标签属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    LabelDialog: function (options, ctl, isInsertMode, ele) {
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = {};
            } else {
                ele = ctl.CurrentElement("xtextlabelelement");
                if (ele == null) {
                    return false;
                }
                options = ctl.GetElementProperties(ele);
                if (options == null) {
                    return false;
                }
            }
        }
        if (!options) {
            return false;
        }
        if (Object.hasOwnProperty.call(options, "Text") == false) {
            // 当数据中不包含Text时，赋值默认
            options.Text = "标签文本";
        }
        var LabelHtml = `
                    <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">编号：</span>
                    <input type="text" class="dc_full" name="ID" data-text="ID">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">名称：</span>
                    <input type="text" class="dc_full" name="Name" data-text="Name">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">可见性表达式：</span>
                    <input data-text="VisibleExpression" class="dc_full"  type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>
   
            <div class="dcBody-content">
                <div class="dc_checkboxs">
                    <label>
                        <input type="checkbox" name="AutoSize"  data-text="AutoSize" >
                        <span>自动大小</span>
                    </label>
                    <label>
                        <input type="checkbox" name="Multiline" data-text="Multiline" >
                        <span>自动换行</span>
                    </label>
                    <label>
                        <input type="checkbox" name="Deleteable" data-text="Deleteable" >
                        <span>能否被删除</span>
                    </label>
                    <label>
                        <input type="checkbox" name="Bold" data-text="Bold" >
                        <span>是否加粗</span>
                    </label>
                </div>
            </div>
            <div class="dcBody-content">
                <form class="dc_Box">
                    <h6 class="dc_title">连接模式设置</h6>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">模式：</span>
                            <select data-text="ContactAction" class="dc_full">
                                <option value="Disable" title="禁止文本连接">Disable</option>
                                <option value="Normal" title="正常模式">Normal</option>
                                <option value="FirstSectionInPage" title="只显示当前页面中第一个文档的文本">FirstSectionInPage</option>
                                <option value="LastSectionInPage" title="只显示当前页面中最后一个文档的文本">LastSectionInPage</option>
                                <option value="TableRow" title="表格行">TableRow</option>
                                <option value="FirstTableRowInPage" title="页面中第一个表格行">FirstTableRowInPage</option>
                                <option value="LastTableRowInPage" title="页面中最后一个表格行">LastTableRowInPage</option>
                            </select>
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">属性名：</span>
                            <input type="text" class="dc_full" name="AttributeNameForContactAction"
                                data-text="AttributeNameForContactAction">
                        </label>
                    </div>
                    <div class="dcBody-content">
                        <label class="dc_flex">
                            <span class="dcTitle-text">连接文本：</span>
                            <input type="text" class="dc_full" name="LinkTextForContactAction"
                                data-text="LinkTextForContactAction">
                        </label>
                    </div>
                </form>
            </div>
            <div class="dcBody-content">
                <label class="dc_blockelement">
                    <div>文本（当文本内容过多时，建议勾选自动大小）：</div>
                    <div>
                        <textarea data-text="Text" value="标签文本"></textarea>
                    </div>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "文本标签元素",
            bodyHeight: 475,
            bodyClass: "labelElement",
            bodyHtml: LabelHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);
        //处理设置后无效的属性
        let checkList = dcPanelBody.find('input[type="checkbox"]');
        let optionKeys = Object.keys(options);
        for (var i = 0; i < checkList.length; i++) {
            let item = checkList[i];
            if (optionKeys.indexOf(item.name) !== -1) {
                if (options[item.name]) {
                    item.setAttribute("checked", true);
                } else {
                    jQuery(item).removeAttr("checked");
                }
            } else {
                jQuery(item).removeAttr("checked");
            }
        }
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            // console.log("successFun -> _data", {
            //     ...options,
            //     ..._data
            // });
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("InsertLabelElement", false, {
                    ...options,
                    ..._data
                });
            } else {
                ctl.SetElementProperties(ele, _data, true);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("xtextlabelelement"));
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }

        }
    },

    /**
     * 创建水平线/分割线属性对话框
     * @param options 水平线/分割线属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    HorizontalLineDialog: function (options, ctl, isInsertMode, ele) {
        // console.log(options, '=========options');
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = {};
            } else {
                ele = ctl.CurrentElement("xtexthorizontallineelement");
                if (ele == null) {
                    return false;
                }
                options = ctl.GetElementProperties(ele);
            }
        }
        if (options == null) {
            return false;
        }
        var HorizontalLineHtml = `
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">编号：</span>
                <input type="text" class="dc_full" name="ID" data-text="ID">
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">可见性表达式：</span>
                <input data-text="VisibleExpression" data-text="VisibleExpression" class="dc_full" type="text">
                <button class="dc_visible_expression">示例</button>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">颜色：</span>
                <div id="dc_HorizontalLine_Color_box" data-text="Color" data-value="#000000" style="display: inline-block; width: 164px; height: 10px; border: 1px solid rgb(217, 217, 217); border-radius: 4px; cursor: pointer; vertical-align: middle; margin-left: 5px; background-color: #000000;"></div>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">线条样式：</span>
                <select class="dc_full" name="Style" data-text="LineStyle">
                    <option value="Solid">Solid</option>
                    <option value="Dash">Dash</option>
                    <option value="Dot">Dot</option>
                    <option value="DashDot">DashDot</option>
                    <option value="DashDotDot">DashDotDot</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">线条粗细：</span>
                <input type="number" class="dc_full" name="Width" data-text="LineSize">
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">线条长度：</span>
                <input type="number" class="dc_full" name="Length" data-text="LineLengthInCM">
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "水平分割线属性",
            bodyHeight: 300,
            bodyClass: "HorizontalLineElement",
            bodyHtml: HorizontalLineHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        // GetOrChangeData(dcPanelBody, options);
        Object.keys(options).forEach(item => {
            var element = dcPanelBody.find(`[data-text="${item}"]`);
            // 如果元素是 div 且有 data-value 属性，则设置 data-value 和 backgroundColor
            if (element.length > 0 && element[0].nodeName === "DIV" && element.attr("data-value") !== undefined) {
                var value = options[item] || "";
                element.attr("data-value", value);
                // 如果是颜色值，同时设置背景色
                if (item && (item.toLowerCase().indexOf("color") >= 0 || item.toLowerCase().indexOf("colour") >= 0)) {
                    element[0].style.backgroundColor = value || "#000000";
                }
            } else {
                element.val(options[item]);
            }
        });

        // 水平分割线颜色选择器 - 点击色块弹出颜色选择器
        const horizontalLineColorBox = jQuery(dcPanelBody).find('#dc_HorizontalLine_Color_box')[0];
        if (horizontalLineColorBox) {
            jQuery(horizontalLineColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_HorizontalLine_Color_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#000000'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            // console.log("successFun -> _data", _data)
            options = {
                ...options,
                ..._data
            };
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("InsertHorizontalLine", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("xtexthorizontallineelement"));
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建页码属性对话框
     * @param options 页码属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    PageNumberDialog: function (options, ctl, isInsertMode, ele) {
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = { PageIndexFix: 0 };
            } else {
                ele = ctl.CurrentElement("xtextpageinfoelement");
                options = ctl.GetElementProperties(ele);
            }
        }
        if (options == null) {
            return false;
        }
        var PageNumberHtml = `
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">编号：</span>
                    <input type="text" class="dc_full" name="ID" data-text="ID">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">宽度：</span>
                    <input type="number" class="dc_full" name="Width" data-text="Width">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">高度：</span>
                    <input type="number" class="dc_full" name="Height" data-text="Height">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">页码修正量：</span>
                    <input type="number" value="0" class="dc_full" name="PageIndexFix" data-text="PageIndexFix">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">可见性表达式：</span>
                    <input data-text="VisibleExpression" class="dc_full" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>
            <div class="dcBody-content">
                <span class="dcTitle-text">内容：</span>
                <input type="hidden" name="ValueType" data-text="ValueType">
                <ul id="dc_ValueType">
                    <li data-value="PageIndex" class="dc_active">页码</li>
                    <li data-value="NumOfPages">总页码</li>
                    <li data-value="LocalPageIndex">本地页码</li>
                    <li data-value="LocalNumOfPages">本地总页码</li>
                </ul>
            </div>
            <div class="dcBody-content" style="display: none;">
                <label class="dc_flex dc_minflex">
                    <span class="dcTitle-text">数字显示格式：</span>
                    <select class="dc_full">
                        <option value="None">无</option>
                        <option value="ListNumberStyle" selected>1. 2. 3. 4.</option>
                        <option value="ListNumberStyleArabic1">1, 2, 3, 4,</option>
                        <option value="ListNumberStyleArabic2">1) 2) 3) 4)</option>
                        <option value="ListNumberStyleLowercaseLetter ">a) b) c) d)</option>
                        <option value="ListNumberStyleLowercaseRoman">i) ii) iii) iv)</option>
                        <option value="ListNumberStyleSimpChinNum1">一. 二. 三. 四.</option>
                        <option value="ListNumberStyleSimpChinNum2">一) 二) 三) 四)</option>
                        <option value="ListNumberStyleNumberInCircle">①, ②, ③, ④,</option>
                        <option value="ListNumberStyleTradChinNum1">壹. 贰. 叁. 肆.</option>
                        <option value="ListNumberStyleTradChinNum2">壹) 贰) 叁) 肆)</option>
                        <option value="ListNumberStyleUppercaseLetter">A) B) C) D)</option>
                        <option value="ListNumberStyleUppercaseRoman">I) II) III) IV)</option>
                        <option value="ListNumberStyleZodiac1">甲, 乙, 丙, 丁,</option>
                        <option value="ListNumberStyleZodiac2">子, 丑, 寅, 卯,</option>
                        <option value="ListNumberStyleArabic3">1、2、3、4、</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_minflex">
                    <span class="dcTitle-text">格式化字符串：</span>
                    <input type="text" class="dc_full" name="FormatString" data-text="FormatString"
                        list="FormatStringList">
                    <datalist>
                        <option value="第[%PageIndex%]页 共[%NumOfPages%]页">第[%PageIndex%]页 共[%NumOfPages%]页</option>
                        <option value="[%PageIndex%]/[%NumOfPages%]">[%PageIndex%]/[%NumOfPages%]</option>
                    </datalist>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_Newline">
                    <span class="dcTitle-text">指定的页码编号文本列表：</span>
                    <input type="text" class="dc_full" name="SpecifyPageIndexTextList"
                        data-text="SpecifyPageIndexTextList">
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "页码属性对话框",
            bodyHeight: 400,
            bodyClass: "HorizontalLineElement",
            bodyHtml: PageNumberHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var ValueTypeInput = dcPanelBody.find("[data-text=ValueType]");
        var lis = dcPanelBody.find("#dc_ValueType li");
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);
        lis.removeClass("dc_active");
        lis
            .filter("[data-value='" + ValueTypeInput.val() + "']")
            .addClass("dc_active");
        if (lis.filter(".dc_active").length == 0) {
            lis.eq(0).addClass("dc_active");
        }
        // 页码内容选择
        lis.on("click", function () {
            jQuery(this).siblings("li").removeClass("dc_active");
            jQuery(this).addClass("dc_active");
            ValueTypeInput.val(jQuery(this).attr("data-value"));
        });
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            // console.log("successFun -> _data", _data)
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("InsertPageInfoElement", false, _data);
            } else {
                ctl.SetElementProperties(ele, _data, true);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("xtextpageinfoelement"));
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建按钮属性对话框
     * @param options 按钮属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    ButtonDialog: function (options, ctl, isInsertMode, ele) {
        let that = this;
        // ctl.CurrentElement('xtextbuttonelement');
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = {};
            } else {
                ele = ctl.CurrentElement("xtextbuttonelement");
                if (ele == null) {
                    return false;
                }
                options = ctl.GetElementProperties(ele);
            }
        }
        if (options == null) {
            return false;
        }
        // console.log(options, "==========options");
        var ButtonHtml = `
        <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">编号：</span>
                    <input type="text" class="dc_full" name="ID" data-text="ID">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">名称：</span>
                    <input type="text" class="dc_full" name="Name" data-text="Name">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">宽度：</span>
                    <input type="number" class="dc_full" name="Width" data-text="Width">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">高度：</span>
                    <input type="number" class="dc_full" name="Height" data-text="Height">
                </label>
            </div>
            <div class="dcBody-content">
                <div class="dc_checkboxs">
                    <label>
                        <input type="checkbox" name="Deleteable" data-text="Deleteable" checked>
                        <span>能否被删除</span>
                    </label>
                    <label>
                        <input type="checkbox" name="Enabled" data-text="Enabled" checked>
                        <span>是否可用</span>
                    </label>
                    <label>
                        <input type="checkbox" name="AutoSize" data-text="AutoSize">
                        <span>自动大小</span>
                    </label>
                    <label>
                        <input type="checkbox" name="PrintAsText" data-text="PrintAsText">
                        <span>以文本方式打印</span>
                    </label>
                </div>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">打印时可见：</span>
                    <select  data-text="PrintVisibility" class="dc_full">
                        <option value="Visible">显示</option>
                        <option value="Hidden">隐藏</option>
                        <option value="None">隐藏而且不占位</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">命令文本：</span>
                    <input type="text" class="dc_full" name="CommandName" data-text="CommandName">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">可见性表达式：</span>
                    <input data-text="VisibleExpression" class="dc_full" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>

            <div class="dcBody-content dcBody-content-wring" >注：下面图片使用png格式图片</div>
            <div class="dcBody-content">
                <label class="dc_flex dc_imgButtonBox">
                    <span class="dcTitle-text">按钮图片：</span>
                    <button class="dc_full" name="ImgBase64" data-text="ImgBase64" data-value="img">
                        <img src="" alt="">
                        <input type="file" accept="image/*">
                    </button>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_imgButtonBox">
                    <span class="dcTitle-text">按下时图片：</span>
                    <button class="dc_full" name="ImgBase64ForDown" data-text="ImgBase64ForDown" data-value="img">
                        <img src="" alt="">
                        <input type="file" accept="image/*">
                    </button>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_imgButtonBox">
                    <span class="dcTitle-text">鼠标悬停时图片：</span>
                    <button class="dc_full" name="ImgBase64ForOver" data-text="ImgBase64ForOver" data-value="img">
                        <img src="" alt="">
                        <input type="file" accept="image/*">
                    </button>
                </label>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">颜色设置：</h6>
                <div class="dc_button_style_box" id="dc_button_style_box">
                    <div class="dc_button_style_box_backgroundcolorstring">
                        <span>背景颜色：</span>
                        <label class="dc_color_label">
                            <div id="dc_backgroundcolorstring_box" data-value="" style="display: inline-block; width: 24px; height: 20px; border: 1px solid rgb(217, 217, 217); border-radius: 4px; cursor: pointer; vertical-align: middle; margin-left: 5px;"></div>
                        </label>
                    </div>
                    <div class="dc_button_style_box_colorstring">
                        <span >文字颜色：</span>
                        <label class="dc_color_label">
                            <div id="dc_colorstring_box" data-value="" style="display: inline-block; width: 24px; height: 20px; border: 1px solid rgb(217, 217, 217); border-radius: 4px; cursor: pointer; vertical-align: middle; margin-left: 5px;"></div>
                        </label>
                    </div>
                </div>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">按钮字体设置：</h6>
                <div class="dc_button_style_box" >
                    <div>
                        <span >字体名称：</span>
                        <select id="dc_button_style_fontname"></select>
                    </div>
                    <div>
                        <span >字体大小：</span>
                        <select  id="dc_button_style_fontsize"></select>
                    </div>
                    <div>
                        <span >加粗：</span>
                        <select  id="dc_button_style_bold" >
                            <option value="false">否</option>
                            <option value="true">是</option>
                        </select>
                    </div>
                   
                </div>
            </div>
            <div class="dcBody-content">
                <label class="dc_blockelement">
                    <div>文本：</div>
                    <div>
                        <textarea data-text="Text"></textarea>
                    </div>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_blockelement">
                    <div>脚本：</div>
                    <div>
                        <textarea data-text="ScriptTextForClick"></textarea>
                    </div>
                </label>
            </div>
            <div class="dcBody-content dc_Box">
                <h6 class="dc_title">自定义属性</h6>
                <div id="dc_attr-box"></div>
            </div>
        `;
        var dialogOptions = {
            title: "按钮属性",
            bodyHeight: 400,
            bodyClass: "ButtonElement",
            bodyHtml: ButtonHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");


        that.attributeComponents("#dc_attr-box", options.Attributes || {}, ctl);

        // 字体样式回填
        var arrFont = [];
        if (
            window.WriterControl_SupportFontFamilys &&
            window.WriterControl_SupportFontFamilys.length
        ) {
            arrFont = window.WriterControl_SupportFontFamilys;
        } else {
            arrFont = window.WriterControl_SupportFontFamilys =
                ctl.getSupportFontFamilys();
        }
        var dc_fontFamily_button = dcPanelBody.find("#dc_button_style_fontname"); //字体样式
        var fontFamilyUlHtml = "";
        arrFont.length && arrFont.forEach(function (obj) {
            if (obj) {
                var styleStr = "font-family:" + obj + ";";
                fontFamilyUlHtml +=
                    "<option class='font-item' style='" + styleStr + "' value='" + obj + "'>" + obj + "</option>";
            }
        });
        dc_fontFamily_button.html(fontFamilyUlHtml);

        //字体大小回填
        var dc_fontSizeUl = dcPanelBody.find("#dc_button_style_fontsize"); //字体大小
        var fontSizeUlHtml = "";
        DATAFONTSIZE.forEach(function (value) {
            if (value) {
                fontSizeUlHtml +=
                    "<option class='font-item' value='" + value + "'>" + value + "</option>";
            }
        });
        dc_fontSizeUl.html(fontSizeUlHtml);


        //背景颜色值修改事件 - 点击色块弹出颜色选择器
        const backgroundColorBox = jQuery(dcPanelBody).find("#dc_backgroundcolorstring_box")[0];
        if (backgroundColorBox) {
            jQuery(backgroundColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_button_style_backgroundcolorstring_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#FFFFFF'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }
        //文本颜色值修改事件 - 点击色块弹出颜色选择器
        const textColorBox = jQuery(dcPanelBody).find("#dc_colorstring_box")[0];
        if (textColorBox) {
            jQuery(textColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_button_style_colorstring_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#000000'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }

        //按钮的部分Style属性(目前弹框中可以修改的属性)
        var buttonStyle = {
            BackgroundColorString: null,
            ColorString: null,
            Bold: null,
            FontName: null,
            FontSize: null
        };

        //按钮样式属性值回填
        if (options && options.Style) {
            Object.keys(options.Style).forEach((key) => {
                var newKey = key.toLowerCase();
                switch (newKey) {
                    case "backgroundcolorstring":
                        //展示色块赋值
                        var dc_backgroundcolorstring_box = dcPanelBody.find(`#dc_backgroundcolorstring_box`);
                        if (dc_backgroundcolorstring_box.length > 0) {
                            var colorValue = options.Style[key] || '#FFFFFF';
                            dc_backgroundcolorstring_box.css("background-color", colorValue);
                            dc_backgroundcolorstring_box.attr("data-value", colorValue);
                        }
                        break;
                    case "colorstring":
                        if (options.Style[key]) {
                            //展示色块赋值
                            var dc_colorstring_box = dcPanelBody.find(`#dc_colorstring_box`);
                            if (dc_colorstring_box.length > 0) {
                                var colorValue = options.Style[key] || '#000000';
                                dc_colorstring_box.css("background-color", colorValue);
                                dc_colorstring_box.attr("data-value", colorValue);
                            }
                        }
                        break;
                    case "fontname":
                    case "fontsize":
                    case "bold":
                        if (newKey === "bold") {
                            options.Style[key] = (options.Style[key] === true ? "true" : "false");
                        }
                        dc_dialogContainer.find(`#dc_button_style_${newKey}`).val(options.Style[key]);
                        break;
                }
            });
        } else {
            //如果是插入按钮，没有Style属性。则置空选择框
            Object.keys(buttonStyle).forEach((key) => {
                var newKey = key.toLowerCase();
                var styleDom = ctl.ownerDocument.getElementById(`dc_button_style_${newKey}`);
                if (styleDom && styleDom.nodeName === "SELECT") {
                    styleDom.selectedIndex = -1;
                }
            });
        }


        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);
        // 图片的默认赋值
        dcPanelBody.find("[data-value='img']").each(function () {
            var imgNode = jQuery(this).find("img");
            var _val = jQuery(this).val();
            if (_val) {
                var str = _val;
                if (_val.indexOf("base64,") == -1) {
                    str = "data:image/png;base64," + str;
                    jQuery(this).val(str);
                }
                imgNode.attr("src", str);
            } else {
                // 没有内容，隐藏
                imgNode.hide();
            }
        });
        // 图片的提交
        dcPanelBody
            .find("[data-value='img'] [type='file']")
            .on("change", function () {
                var files = this.files;
                if (files.length == 0) {
                    return;
                }
                var btnNode = jQuery(this).parent();
                var imgNode = btnNode.find("img");
                if (files[0] && files[0].type.slice(0, 5) == "image") {
                    var fileinfo = files[0];
                    var reader = new FileReader();
                    reader.readAsDataURL(fileinfo);
                    reader.onload = function () {
                        var base64 = reader.result;
                        imgNode.attr("src", base64);
                        imgNode.show();
                        // var str = base64.substr(base64.indexOf("base64,") + 7, base64.length);
                        btnNode.val(base64);
                    };
                    reader.onerror = function (error) {
                        console.log(error);
                    };
                }
            });
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);

            Object.keys(buttonStyle).forEach(key => {
                var newKey = key.toLowerCase();
                var value = dc_dialogContainer.find(`#dc_button_style_${newKey}`).val();
                switch (newKey) {
                    case "backgroundcolorstring":
                        var colorstring = dcPanelBody.find(`#dc_backgroundcolorstring_box`).attr("data-value");
                        buttonStyle[key] = colorstring;
                        break;
                    case "colorstring":
                        var colorstring = dcPanelBody.find(`#dc_colorstring_box`).attr("data-value");
                        buttonStyle[key] = colorstring;
                        break;
                    case "bold":
                        buttonStyle[key] = value === "true";
                        break;
                    default:
                        buttonStyle[key] = value;
                        break;
                }
            });
            _data['Style'] = { ...buttonStyle };
            var dcAttrBox = dcPanelBody.find("#dc_attr-box");
            let Attributes = that.attributeComponents_getAttributeObj(dcAttrBox);
            _data['Attributes'] = Attributes;
            // console.log("successFun -> _data", _data);
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("InsertButton", false, { ...options, ..._data });
            } else {
                ctl.SetElementProperties(ele, _data, true);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("xtextbuttonelement"));
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建二维码属性对话框
     * @param options 二维码属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    QRCodeDialog: function (options, ctl, isInsertMode, ele) {
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = {};
            } else {
                ele = ctl.CurrentElement("xtexttdbarcodeelement");
                if (ele == null) {
                    return false;
                }
                options = ctl.GetElementProperties(ele);
            }
        }

        if (options == null) {
            return false;
        }
        var QRCodeHtml = `
                    <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">编号：</span>
                    <input type="text" class="dc_full" name="ID" data-text="ID">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_blockelement">
                    <div>文本：</div>
                    <div>
                        <textarea data-text="Text"></textarea>
                    </div>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">宽度：</span>
                    <input type="number" class="dc_full" name="Width" data-text="Width">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">高度：</span>
                    <input type="number" class="dc_full" name="Height" data-text="Height">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">类型：</span>
                    <select data-text="BarcodeStyle" class="dc_full">
                        <option value="QR">QR</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">纠错能力：</span>
                    <select  data-text="ErroeCorrectionLevel" class="dc_full">
                        <option value="L">L:7%的字码可被修正</option>
                        <option value="M" selected>M:15%的字码可被修正</option>
                        <option value="Q">Q:25%的字码可被修正</option>
                        <option value="H">H:30%的字码可被修正</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">可见性表达式：</span>
                    <input data-text="VisibleExpression" class="dc_full" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "二维码属性",
            bodyHeight: 420,
            bodyClass: "QRCodeElement",
            bodyHtml: QRCodeHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        WriterControl_Dialog.appendValueBindingDiv(dcPanelBody);
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });

        GetOrChangeData(dcPanelBody, opts);
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            // console.log("successFun -> _data", _data)
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("InsertTDBarcodeElement", false, _data);
            } else {
                ctl.SetElementProperties(ele, _data, true);
            }
            //[DUWRITER5_0-3762] 20241101 lxy 修改EventDialogChangeProperties事件在插入时也触发
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建条形码属性对话框
     * @param options 条形码属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    BarCodeDialog: function (options, ctl, isInsertMode, ele) {
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = {};
            } else {
                ele = ctl.CurrentElement("xtextnewbarcodeelement");
                if (ele == null) {
                    return false;
                }
                options = ctl.GetElementProperties(ele);
            }
        }
        if (options == null) {
            return false;
        }
        // console.log(options, '===========options');

        var BarCodeHtml = `
                    <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">编号：</span>
                    <input type="text" class="dc_full" name="ID" data-text="ID">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">名称：</span>
                    <input type="text" class="dc_full" name="Name" data-text="Name">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">文本内容：</span>
                    <input type="text" class="dc_full" name="Text" data-text="Text">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">宽度：</span>
                    <input type="number" class="dc_full" name="Width" data-text="Width">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">高度：</span>
                    <input type="number" class="dc_full" name="Height" data-text="Height">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">条码样式：</span>
                    <select id="dc_BarcodeStyle" data-text="BarcodeStyle" class="dc_full">
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">文本对齐方式：</span>
                    <select data-text="TextAlignment" class="dc_full">
                        <option value="Near">左对齐</option>
                        <option value="Center" selected="selected">居中对齐</option>
                        <option value="Far">右对齐</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">可见性表达式：</span>
                    <input data-text="VisibleExpression" class="dc_full" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>
            <div class="dcBody-content">
                <label>
                    <input type="checkbox" name="ShowText" data-text="ShowText" checked="checked">
                    <span class="dcTitle-text">是否显示文本</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "条形码属性",
            bodyHeight: 360,
            bodyClass: "BarcodeElement",
            bodyHtml: BarCodeHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var BarcodeStyleSelect = dcPanelBody.find("select#dc_BarcodeStyle");
        WriterControl_Dialog.appendValueBindingDiv(dcPanelBody);
        var BarcodeStyleArr = [
            { Text: "UPCA" },
            { Text: "UPCE" },
            { Text: "SUPP2" },
            { Text: "SUPP5" },
            { Text: "EAN13" },
            { Text: "EAN8" },
            { Text: "Interleaved2of5" },
            { Text: "I2of5" },
            { Text: "Standard2of5" },
            { Text: "Code39" },
            { Text: "Code39Extended" },
            { Text: "Code93" },
            { Text: "Codabar" },
            { Text: "PostNet" },
            { Text: "BOOKLAND" },
            { Text: "ISBN" },
            { Text: "JAN13" },
            { Text: "MSI_Mod10" },
            { Text: "MSI_2Mod10" },
            { Text: "MSI_Mod11" },
            { Text: "MSI_Mod11_Mod10" },
            { Text: "Modified_Plessey" },
            { Text: "CODE11" },
            { Text: "USD8" },
            { Text: "UCC12" },
            { Text: "UCC13" },
            { Text: "LOGMARS" },
            { Text: "Code128A" },
            { Text: "Code128B" },
            { Text: "Code128C", Selected: true },
        ];
        var BarcodeStyleSelectHtml = "";
        for (var i = 0; i < BarcodeStyleArr.length; i++) {
            var style_txt = BarcodeStyleArr[i].Text;
            var optHtml = "<option value='" + style_txt + "'";
            if (BarcodeStyleArr[i].Selected == true) {
                optHtml += " selected='selected'";
            }
            optHtml += ">" + style_txt + "</option>";
            BarcodeStyleSelectHtml += optHtml;
        }
        BarcodeStyleSelect.html(BarcodeStyleSelectHtml);
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            // console.log("successFun -> _data", _data);
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("InsertBarcodeElement", false, _data);
            } else {
                ctl.SetElementProperties(ele, _data, true);
            }
            //[DUWRITER5_0-3762] 20241101 lxy 修改EventDialogChangeProperties事件在插入时也触发
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建字体选择对话框
     * @param options 字体属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    FontSelectionDialog: function (options, ctl, isInsertMode) {
        if (!options || typeof options != "object") {
            options = ctl.getFontObject();
        }
        if (options == null) {
            return false;
        }
        var arrFont = [];
        if (
            window.WriterControl_SupportFontFamilys &&
            window.WriterControl_SupportFontFamilys.length
        ) {
            arrFont = window.WriterControl_SupportFontFamilys;
        } else {
            arrFont = window.WriterControl_SupportFontFamilys =
                ctl.getSupportFontFamilys();
        }
        var fontFormatHtml = `
                <div class="dc_font-content-dialog" id="dc_font-content-dialog">
                   <div class="dc_font-box">
                        字体(F)：
                        <input type="text" data-text="fontFamily">
                        <ul class="dc_ul-content" id="dc_fontFamilyUl"></ul>
                   </div>
                   <div class="dc_font-box">
                        大小(S)：
                        <input type="text" data-text="fontSize">
                        <ul class="dc_ul-content" id="dc_fontSizeUl"></ul>
                   </div>
                </div>  
                <div id="font-check-box">
                    <div class="dc_font-style-content-dialog dc_Box">
                        <h6 class="dc_title">字形</h6>
                        <div>
                            <div class="dc_Body-V"> <label> <input type="checkbox"  data-text="Bold"  id="Bold">粗体</label></div>
                            <div class="dc_Body-V"> <label> <input type="checkbox"  data-text="Italic" id="Italic">斜体</label></div>
                        </div>
                    </div>  
                    <div class="dc_font-style-content-dialog dc_Box">
                        <h6 class="dc_title">效果</h6>
                        <div>
                            <div class="dc_Body-V"> <label> <input type="checkbox"  data-text="Underline"  id="Underline">下划线(U)</label></div>
                            <div class="dc_Body-V"> <label> <input type="checkbox"  data-text="Strikeout"  id="Strikeout">删除线(k)</label></div>
                        </div>
                    </div> 
                </div>
            `;
        var dialogOptions = {
            title: "选择字体对话框",
            bodyHeight: 400,
            bodyClass: "fontStyleElement",
            bodyHtml: fontFormatHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);

        // 字号大小
        var dataFontSize = DATAFONTSIZE;

        var dc_fontFamilyUl = dcPanelBody.find("ul#dc_fontFamilyUl"); //字体样式
        var fontFamilyUlHtml = "";
        arrFont.forEach(function (font) {
            if (font) {
                var styleStr = "font-family:" + font + ";";
                // 图片字体不进行设置样式，避免文字变成特殊字符【DUWRITER5_0-4615】
                if (["Wingdings", "Wingdings 2", "Wingdings 3"].indexOf(font) > -1) {
                    styleStr = "";
                }
                if (font == opts.fontFamily) {
                    styleStr += "background:#0078D7;color:#FFFFFF;";
                }
                fontFamilyUlHtml +=
                    "<li class='font-item' style='" + styleStr + "'>" + font + "</li>";
            }
        });
        dc_fontFamilyUl.html(fontFamilyUlHtml);
        var dc_fontSizeUl = dcPanelBody.find("ul#dc_fontSizeUl"); //字体大小
        var fontSizeUlHtml = "";
        dataFontSize.forEach(function (value) {
            if (value) {
                var styleStr = "";
                if (value == opts.fontSize) {
                    styleStr += "background:#0078D7;color:#FFFFFF;";
                }
                fontSizeUlHtml +=
                    "<li class='font-item' style='" + styleStr + "'>" + value + "</li>";
            }
        });
        dc_fontSizeUl.html(fontSizeUlHtml);
        dcPanelBody
            .find("ul#dc_fontFamilyUl li,ul#dc_fontSizeUl li")
            .click(function () {
                var _fontbox = jQuery(this).parents(".dc_font-box");
                _fontbox.find("input").val(jQuery(this).text());
                jQuery(this)
                    .css({
                        background: "#0078D7",
                        color: "#FFFFFF",
                    })
                    .siblings("li")
                    .css({
                        background: "none",
                        color: "black",
                    });
            });
        function successFun() {
            // var dc_dialogContainer = jQuery(ctl).children('#dc_dialogContainer');
            // var dcPanelBody = jQuery(dc_dialogContainer).find('#dcPanelBody');
            var _data = GetOrChangeData(dcPanelBody);
            ctl.setFontObject(_data);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.getFontObject();
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建输入域属性对话框
     * @param options 输入域属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    //会导致报错先不加

    InputFieldDialog: function (options, ctl, isInsertMode) {
        var ele = ctl.CurrentInputField();
        if (options == null) {
            options = {};
        }
        if (!isInsertMode) {
            if (ele == null) {
                return false;
            }
            options = ctl.GetElementProperties(ele);
        }
        var InnerListSourceName = "";
        if (options && options.InnerListSourceName) {
            var InnerListSourceName = options.InnerListSourceName;
        }

        //必须保证输入域校验有一种校验方式，默认是Text
        if (options && options.ValidateStyle == null) {
            options['ValidateStyle'] = {
                ValueType: "Text"
            };
        } else if (options.ValidateStyle && !options.ValidateStyle.ValueType) {
            options['ValidateStyle']['ValueType'] = "Text";
        } else {
            // 20240329 lixinyu 修复校验选择时间校验不设置时间,再次获取时间变成1980/1/1问题(DUWRITER5_0-2165)
            var ValueType = options && options.ValidateStyle && options.ValidateStyle.ValueType || '';
            if (ValueType && ValueType === "DateTime") {
                var DateTimeMaxValue = options.ValidateStyle.DateTimeMaxValue || '';
                var DateTimeMinValue = options.ValidateStyle.DateTimeMinValue || '';
                if (DateTimeMaxValue === "0001/1/1 上午12:00:00") {
                    options.ValidateStyle.DateTimeMaxValue = null;
                }
                if (DateTimeMinValue === "0001/1/1 上午12:00:00") {
                    options.ValidateStyle.DateTimeMinValue = null;
                }
            }
        }

        //列表项目分隔符转换
        if (options.ListValueSeparatorChar === '\\n' || options.ListValueSeparatorChar === '\n') {
            options.ListValueSeparatorChar = '换行';
        }

        // [DUWRITER5_0-4927] lxy 20251125 是否显示移动端配置
        var IsShowMobileDeviceAttributes = ctl.getAttribute("IsShowMobileDeviceAttributes") || null;
        IsShowMobileDeviceAttributes = (IsShowMobileDeviceAttributes === true) || (IsShowMobileDeviceAttributes === "true");
        //保留一次移动端配置
        var dcMobileConfig = null;
        if (IsShowMobileDeviceAttributes === true) {
            dcMobileConfig = (options && options.Attributes && options.Attributes.dc_mobile_config) || "{}";
            dcMobileConfig = JSON.parse(dcMobileConfig);
        }



        var InputFieldHTML = `

    <div class="dc_InputFieldContent">
       <p id="dc_InputFieldContentButtonBox" class="dc_buttonBox">
            <span showDomId="dc_tab1" class="dc_tabButton dc_active">常规</span>
            <span showDomId="dc_tab2" class="dc_tabButton">格式</span>
            <span showDomId="dc_tab3" class="dc_tabButton">校验</span>
            <span  showDomId="dc_tab4" class="dc_tabButton">其他</span>
            ${IsShowMobileDeviceAttributes ? '<span  showDomId="dc_tab5" class="dc_tabButton">移动端</span>' : ''}
            
        </p>
      
    <div class="dc_InputField_tab_box" >
        <!-- 第一个  -->
        <div id="dc_tab1" class="dc_tab">
            <div class="dc_Box">
                <h6 class="dc_title">基本属性</h6>
                   <div class="dc_tab1Content">
                        <label>
                            <span> *编号(ID)：</span>
                            <input data-text="ID" placeholder="" type="text"></input>
                        </label>
                        <label>
                            <span>*名称(Name)：</span>
                            <input data-text="Name" type="text"></input>
                        </label>

                        <label>
                            <span>内容文本：</span>
                            <input data-text="Text"  type="text"></input>
                        </label>
                        <label>
                            <span>内容的值：</span>
                            <input data-text="InnerValue" type="text"></input>
                        </label>

                        <label>
                            <span>背景文字：</span>
                            <input data-text="BackgroundText"  type="text"></input>
                        </label>
                        <label>
                            <span>提示文字：</span>
                            <input data-text="ToolTip" type="text"></input>
                        </label>
                        
                        <label>
                            <span>边框（左）：</span>
                            <input data-text="StartBorderText" type="text"></input>
                        </label>
                        <label>
                            <span>边框（右）：</span>
                            <input data-text="EndBorderText"  type="text"></input>
                        </label>
                        <label class="dc_SpecifyWidth_label">
                            <span>固定宽度<span class="dc_SpecifyWidth_title" title="若背景文字、边框、标签文本、单位文本的宽度超出固定宽度，则固定宽度无效">?</span>：</span>
                            <input data-text="SpecifyWidth"  class="dc_SpecifyWidth_input dc_input_number_data_model" type="number"></input>
                            <span class="dc-text-model-SpecifyWidth" dc-text-model="SpecifyWidth"></span>
                        </label>
                        <label>
                            <span>内容对齐方式：</span>
                            <select data-text="Alignment">
                                <option value="Near">Near</option>
                                <option value="Center">Center</option>
                                <option value="Far">Far</option>
                            </select>
                        </label>
                        <label>
                            <span>焦点快捷键：</span>
                            <select data-text="MoveFocusHotKey">
                                <option value="None">None</option>
                                <option value="Default">Default</option>
                                <option value="Tab">Tab</option>
                                <option value="Enter">Enter</option>
                            </select>
                        </label>
                        <label>
                            <span>标签文本：</span>
                            <input data-text="LabelText" type="text"></input>
                        </label>
                        <label>
                            <span>单位文本：</span>
                            <input data-text="UnitText" type="text"></input>
                        </label>
                       
                        <label>
                            <span>简单级联：</span>
                            <input data-text="DefaultEventExpression" type="text"></input>
                        </label>
                        <label class="dc_EditorActiveModeButton_label" >
                            <span>激活模式：</span>
                            <p id="dc_EditorActiveModeButton" data-text="EditorActiveMode" > None</p>
                        </label>
                         <label>
                            <span>高亮度状态：</span>
                            <select data-text="EnableHighlight">
                                <option value="Default">默认</option>
                                <option value="Enabled">允许</option>
                                <option value="Disabled">禁止</option>
                            </select>
                        </label>
                          <label>
                            <span>打印显示：</span>
                            <select data-text="PrintVisibility">
                                <option value="Visible">Visible</option>
                                <option value="Hidden">Hidden</option>
                                <option value="None">None</option>
                            </select>
                        </label>
                        <label class="dc_BorderVisible_label">
                            <span>边框是否可见:</span>
                            <select  data-text="BorderVisible" >
                                <option value="Default">默认</option>
                                <option value="Visible">可见</option>
                                <option value="Hidden">隐藏</option>
                                <option value="AlwaysVisible">始终可见</option>
                            </select>
                        </label>
                        <label label >
                            <span>标签单位加粗：</span>
                            <select data-text="LableUnitTextBold">
                                <option value="Default">Default</option>
                                <option value="True">True</option>
                                <option value="False">False</option>
                            </select>
                        </label >
                        <label class="dc_UserFlags">
                            <span>用户标志位：</span>
                            <input data-text="UserFlags"  class="dc_UserFlags_input" type="number"></input>
                        </label>
                   </div>
                </div>


                   <div class="dc_Box">
                        <h6 class="dc_title">权限属性：</h6>
                        <div class="dc_tab2Content" >
                            <label>
                                <input type="checkbox" data-text="HiddenPrintWhenEmpty">为空时打印隐藏</input>
                            </label>
                           <label class="dc_input_MaxInputLength_label" >
                                <span>输入最大字符数:</span>
                                <input class="dc_tab2Content_label_inp" data-text="MaxInputLength" type="number" />
                            </label>
                            <label  class="dc_input_UserEditable_label">
                                <input type="checkbox" data-text="UserEditable" name="running" checked="true">是否可以直接编辑修改内容</input>
                            </label>
                             <label  class="dc_input_ContentReadonly_label">
                                <span  >是否只读:</span>
                                <select class="dc_tab2Content_label_inp" id="dc_ContentReadonly"  data-text="ContentReadonly" >
                                    <option value="Inherit">继承父级元素</option>
                                    <option value="True">是</option>
                                    <option value="False">否</option>
                                </select>
                            </label>
                            <label class="dc_input_Deleteable_label">
                                <input  type="checkbox" data-text="Deleteable" name="running" checked="true">是否允许被删除</input>
                            </label>
                           
                            <label  class="dc_input_ViewEncryptType_label">
                                <span>加密显示:</span>
                                <select class="dc_tab2Content_label_inp" data-text="ViewEncryptType" >
                                    <option value="None">不加密</option>
                                    <option value="Partial">部分加密</option>
                                    <option value="Both">全部加密</option>
                                </select>
                            </label>
                        </div>
                    </div>

                    <div id="dc_ValueBinding" class="dc_Box">
                        <h6 class="dc_title">赋值属性：</h6>
                        <div class="dc_tab3Content" >
                            <label>
                                <span>数据源名称：</span>
                                <input  id="dc_DataSource" data-text="Datasource" type="text" />
                            </label>
                            <label >
                                <span>绑定路径：</span>
                                <input  id="dc_BindingPath" data-text="BindingPath" type="text" />
                            </label>
                            <label>
                                <span>Text绑定路径：</span>
                                <input  id="dc_BindingPathForText" type="text" data-text="BindingPathForText" />
                            </label>
                            <label>
                                <span>执行状态:</span>
                                <select id="dc_ProcessState" data-text="ProcessState" >
                                    <option value="Always">总是执行</option>
                                    <option value="Once">只执行一次</option>
                                    <option value="Never">不执行</option>
                                </select>
                            </label>
                        </div>
                    </div>

                    <div class="dc_Box">
                        <h6 class="dc_title">颜色属性：</h6>
                        <div id="dc_colorContainer" >
                            <div class="dc_TextColor_container">
                                <span>文字颜色：</span>
                                <label class="dc_input_TextColor_label" >
                                    <div data-value="" id="dc_TextColor_box"></div>
                                </label>
                            </div>
                            <div class="dc_BackgroundTextColor_container">
                                <span>背景文字颜色：</span>
                                <label class="dc_input_BackgroundTextColor_label" >
                                    <div data-value="" id="dc_BackgroundTextColor_box"></div>
                                </label>
                            </div>
                            <div class="dc_BackgroundColorString_container" >
                                <span>背景颜色：</span>
                                <label class="dc_input_BackgroundColorString_label">
                                    <div data-value="" id="dc_BackgroundColorString_box"></div>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>

        <!-- 第二个  -->
        <div id="dc_tab2" style="display: none;" class="dc_tab">
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input class="dc_tab2-radio-ipt" type="radio" attrId="Text" name="myRadioGroup"></input>
                        <span>纯文本元素(Text)</span>
                    </label>
                </div>
            </div>
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input id="dc_InnerEditStyle_DropDownList" class="dc_tab2-radio-ipt " attrId="DropdownList" type="radio" name="myRadioGroup" id="DropdownList"></input>
                        <span>下拉列表方式(DorpDownList)</span>
                    </label>
                </div>
                <div class="dc_Check-box" id="dc_dropDownList_formbox">
                    <label class="dc_dc_Check_box_label">
                        <input type="checkbox" name="runnings" data-text="InnerMultiSelect" id="InnerMultiSelect">是否允许多选</input>
                    </label>
                    <label class="dc_dc_Check_box_label">
                        <input type="checkbox" name="runnings" data-text="DynamicListItems" id="DynamicListItems">动态下拉列表</input>
                    </label>
                    <label class="dc_dc_Check_box_label">
                        <input type="checkbox" name="runnings" data-text="RepulsionForGroup" id="RepulsionForGroup">分组互斥</input>
                    </label>
                    <div class="dc_input_ListValueFormatString_label dc_dropDownList_formbox_label">
                        <span>列表格式化:</span>
                        <input type="text" data-text="ListValueFormatString" name="ListValueFormatString" value="" list="dc_ListValueFormatString" autocomplete="off">
                        <datalist id="dc_ListValueFormatString">
                            <option value=""></option>
                            <option value="有[includelist],无[excludelist]"></option>
                        </datalist>
                    </div>
                    <div class="dc_dc_Check_box_label_flex dc_dropDownList_formbox_label">
                        <span>列表项目分割字符:</span>
                        <input type="text" data-text="ListValueSeparatorChar"  id="dc_ListValueSeparatorChar" >
                        <div id="dc_ListValueSeparatorChar_box">
                            <div class="dc_listValueSeparatorChar_item" data-value=",">,</div>
                            <div class="dc_listValueSeparatorChar_item" data-value="、">、</div>
                            <div class="dc_listValueSeparatorChar_item" data-value="|">|</div>
                            <div class="dc_listValueSeparatorChar_item" data-value="#">#</div>
                            <div class="dc_listValueSeparatorChar_item" data-value="*">*</div>
                            <div class="dc_listValueSeparatorChar_item" data-value="。">。</div>
                            <div class="dc_listValueSeparatorChar_item" data-value="换行">换行</div>
                        </div>
                    </div>
                    <label class="dc_StaticSelection_label dc_dropDownList_formbox_label">
                        <span>静态选择项内容：</span>
                        <input type="text" id="dc_StaticSelection" readonly="readonly" name="runnings">
                        <button id="dc_browseTextTableContent" name="runnings">浏览</button>
                    </label>
                </div>
            </div>
     
           
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input class="dc_tab2-radio-ipt" type="radio" name="myRadioGroup" attrId="DateTime"></input>
                        <span>日期时间格式(DataTime)</span>
                    </label>
                </div>
            </div>
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input class="dc_tab2-radio-ipt" type="radio" name="myRadioGroup" attrId="Date"></input>
                        <span>日期格式(Date)</span>
                    </label>
                </div>
            </div>
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input class="dc_tab2-radio-ipt" type="radio" name="myRadioGroup" attrId="Numeric"></input>
                        <span>数字类型(Numeric)</span>
                    </label>
                </div>
            </div>
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input class="dc_tab2-radio-ipt" type="radio" name="myRadioGroup" attrId="Time"></input>
                        <span>时间格式(Time)</span>
                    </label>
                </div>
            </div>
            <div class="dc_Box">
                <div class="dc_title">
                    <label class="dc_tab2-radio-ipt-label">
                        <input class="dc_tab2-radio-ipt" type="radio" name="myRadioGroup" attrId="DateTimeWithoutSecond"></input>
                        <span>日期时间格式(不含秒)(DataTime)</span>
                    </label>
                </div>
                <div class="dc_Check-box dc_DisplayFormat_Style_box" >
                    <div class="dc_DisplayFormat_Style_box_center" >
                        <span>格式类型:</span>
                        <input class="dc_selection" data-text="DisplayFormat.Style" type="text" id="dc_DisplayFormat">
                        <ul id="dc_UI-1" ></ul>
                    </div>
                    <div class="dc_DisplayFormat_Style_box_center">
                        <span >格式:</span>
                        <input class="dc_selectionRight" data-text="DisplayFormat.Format" type="text" id="dc_selectionRight">
                        <ul id="dc_UI-2" ></ul>
                    </div>
                </div>
            </div>
        </div>
          

        <!-- 第3个  -->
        <div id="dc_tab3"  style="display: none;" class="dc_tab">
            <div class="dc_Box">
                <h6 class="dc_title">基础校验</h6>
                <div class="dc_tab3_content">
                    <label class="dc_ValidateStyle_label_item dc_tab3_content_Required_label">
                        <input type="checkbox" data-text="Required">是否必填</input>
                    </label>
                    <label class="dc_ValidateStyle_label_item dc_tab3_content_CustomMessage_label" >
                        <span>错误提示：</span>
                        <input data-text="CustomMessage" type="text"  />
                    </label>
                    <label class="dc_ValidateStyle_label_item dc_tab3_content_ExcludeKeywords_label" >
                        <span>违禁关键字：</span>
                        <input data-text="ExcludeKeywords" type="text" />
                    </label>
                    <label  class="dc_ValidateStyle_label_item dc_tab3_content_IncludeKeywords_label" >
                        <span>允许关键字：</span>
                        <input data-text="IncludeKeywords" type="text" />
                    </label>
                </div>
            </div>

            <div class="dc_Box">
                <label class="dc_ValidateStyle_label">
                    <input class="dc_radio-ipt-choose"  type="radio" name="CheckRule2" attrId="Text">
                    </input>
                    <h6 class="dc_title">纯文本格式校验</h6>
                </label>
                <div class="dc_changeDisabled dc_changeDisabled_BinaryLength">
                    <label class="dc_ValidateStyle_label_item">
                        <input type="checkbox"  data-text="BinaryLength"/>
                        <span>二进制长度</span>
                    </label>
                    <label class="dc_ValidateStyle_label_item">
                        <span>最小长度：</span>
                        <input type="number" data-text="MinLength"  name="runningA"></input>
                    </label>
                    <label class="dc_ValidateStyle_label_item">
                        <span>最大长度：</span>
                        <input type="number" data-text="MaxLength" name="runningA"></input>
                    </label>
                </div>
            </div>

            <div class="dc_Box">
                <label class="dc_ValidateStyle_label">
                    <input class="dc_radio-ipt-choose" type="radio" name="CheckRule2" attrId="Numeric"> </input>
                    <h6 class="dc_title">数值格式校验</h6>
                </label>
               <div class="dc_changeDisabled">
                    <label class="dc_ValidateStyle_label_item">
                        <input type="checkbox" id="DC_ValiNumber_CheckMinValue" data-text="CheckMinValue"/>
                        <span>最小值：</span>
                        <input type="number" data-text="MinValue" name="runningA"></input>
                    </label>
                    <label class="dc_ValidateStyle_label_item">
                        <input type="checkbox" id="DC_ValiNumber_CheckMaxValue" data-text="CheckMaxValue"/>
                        <span>最大值：</span>
                        <input type="number" data-text="MaxValue" name="runningA"></input>
                    </label>
                    <label class="dc_ValidateStyle_label_item">
                        <input type="checkbox" data-text="CheckDecimalDigits"/>
                        <span>最大小数位数：</span>
                        <input type="number" data-text="MaxDecimalDigits" name="runningA" ></input>
                    </label>
                    <label class="dc_ValidateStyle_label_item">
                        <input type="checkbox" id="DCNumericInteger"/>
                        <span>只能输入整数</span>
                    </label>
                </div>
            </div>
           
            <div class="dc_Box">
                <label class="dc_ValidateStyle_label">
                    <input class="dc_radio-ipt-choose" type="radio" name="CheckRule2" attrId="DateTime"> </input>
                    <h6 class="dc_title">日期时间格式校验</h6>
                </label>
                <div class="dc_changeDisabled" >
                    <div class="dc_ValidateStyle_label_item">
                        <input type="checkbox" data-text="CheckMinValue" />
                        <span>不得早于：</span>
                        <input type="datetime-local" data-text="DateTimeMinValue" name="runningB" id="dc_DateTimeMinValue">
                    </div>
                    <div class="dc_ValidateStyle_label_item">
                        <input type="checkbox" data-text="CheckMaxValue" />
                        <span>不得晚于：</span>
                        <input type="datetime-local"  data-text="DateTimeMaxValue" name="runningB" id="dc_DateTimeMaxValue">
                    </div>
                </div>
            </div>

            <div class="dc_Box">
                <label class="dc_ValidateStyle_label">
                    <input class="dc_radio-ipt-choose" type="radio" name="CheckRule2" attrId="RegExpress"></input>
                    <h6 class="dc_title">正则表达式</h6>
                </label>
               <div class="dc_changeDisabled" >
                    <input data-text="RegExpression" name="runningA" type="text" />
                </div>
            </div>
        </div>

        <!-- 第4个  -->
        <div id="dc_tab4"  style="display: none;" class="dc_tab">
            <div class="dc_Box">
                <h6 class="dc_title">表达式：</h6>
                <label class="dc_input_ValueExpression_label" >
                    <span>计算表达式：</span>
                    <input data-text="ValueExpression"   type="text">
                </label>
                <label class="dc_input_VisibleExpression_label" >
                    <span>校验表达式：</span>
                    <input data-text="ValidateStyleExpression"   type="text">
                </label>
                <label class="dc_input_VisibleExpression_label" >
                    <span>可见性表达式：</span>
                    <input data-text="VisibleExpression" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
                <label class="dc_input_PropertyExpressions_label" >
                    <span>属性表达式：</span>
                    <input id="dc_PropertyExpressions_show_input" readonly="readonly" type="text">
                    <button id="dc_PropertyExpressionsButton">打开</button>
                </label>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">内容复制来源：</h6>
                <div id="dc_CopySource">
                    <label class="dc_input_SourceID_label" >
                        <span >复制来源：</span>
                        <input  data-text="SourceID" type="text">
                    </label>
                    <label class="dc_input_SourcePropertyName_label">
                        <span >来源属性：</span>
                        <input data-text="SourcePropertyName"  type="text">
                    </label>
                    <label class="dc_input_DescPropertyName_label">
                        <span >目标属性：</span>
                        <input data-text="DescPropertyName"  type="text">
                    </label>
                </div>
            </div>

            <div class="dc_Box">
                <label class="dc_input_Attributes_label" >
                    <span >自定义属性：</span>
                    <input type="text"  id="dc_Attributes"  readonly="readonly">
                    <button id="dc_browsess" name="">浏览</button>
                </label>

                <label class="dc_input_AcceptChildElementTypes_label" >
                    <span >可包含的内容：</span>
                    <input type="text"  data-text="AcceptChildElementTypes" id="dc_AcceptChildElementTypesInput" readonly="readonly">
                    <button id="dc_AcceptChildElementTypesButton" name="">浏览</button>
                </label>
            </div>

        </div>


        ${IsShowMobileDeviceAttributes ? `
            <!-- 第5个  -->
            <div id="dc_tab5" style="display: none;" class="dc_tab dc_tab_mobile">
                <div class="dc_Box">
                    <h6 class="dc_title">移动端属性</h6>
                    <div class="dc_mobile_attributes_box">
                        <label>
                            <span>移动端可见：</span>
                            <select mobile-attr="mobile_visibility">
                                <option value="true">显示</option>
                                <option value="false">隐藏</option>
                            </select>
                        </label>
                        <label>
                            <span>是否换行：</span>
                            <select mobile-attr="mobile_lineFeed">
                                <option value="true">是</option>
                                <option value="false">否</option>
                            </select>
                        </label>
                        <label>
                            <span>编号：</span>
                            <div class="dc_mobile_attributes_box_item_readonly" mobile-attr="mobile_id"></div>
                        </label>
                        <label>
                            <span>标签名称：</span>
                            <div class="dc_mobile_attributes_box_item_readonly" mobile-attr="mobile_label"></div>
                        </label>
                        <label>
                            <span>数据源名称：</span>
                            <div class="dc_mobile_attributes_box_item_readonly" mobile-attr="mobile_dataSource"></div>
                        </label>
                        <label>
                            <span>绑定路径：</span>
                            <div class="dc_mobile_attributes_box_item_readonly" mobile-attr="mobile_bindingPath"></div>
                        </label>
                        <label>
                            <span>组名称：</span>
                            <input type="text" mobile-attr="mobile_groupName"></input>
                        </label>
                        <label>
                            <span>显示组名称：</span>
                            <select  mobile-attr="mobile_showGroupName">
                                <option value="true">是</option>
                                <option value="false">否</option>
                            </select>
                        </label>
                        <label>
                            <span>标签页名称：</span>
                            <input type="text" mobile-attr="mobile_tabChildName"></input>
                        </label>
                        <label>
                            <span>移动端样式：</span>
                            <select mobile-attr="mobile_style">
                            </select>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_radioStartStr">
                            <span>单选框开始字符：</span>
                            <input type="text" mobile-attr="mobile_radioStartStr"></input>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_radioEndStr">
                            <span>单选框结束字符：</span>
                            <input type="text" mobile-attr="mobile_radioEndStr"></input>
                        </label>
                        
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_unUseSelfPop">
                            <span>不使用内部弹出框：</span>
                            <select mobile-attr="mobile_unUseSelfPop">
                                <option value="true">是</option>
                                <option value="false">否</option>
                            </select>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_usePicUpload">
                            <span>是否启用图片上传：</span>
                            <select mobile-attr="mobile_usePicUpload" id="dc_attr_mobile_usePicUpload">
                                <option value="false">否</option>
                                <option value="true">是</option>
                            </select>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_picUploadURL">
                            <span>图片上传地址：</span>
                            <input mobile-attr="mobile_picUploadURL" type="text"></input>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_picLimit">
                            <span>最大上传数量：</span>
                            <input type="number"  mobile-attr="mobile_picLimit"></input>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_picMaxSize">
                            <span>文件大小限制(MB)：</span>
                            <input type="number"  mobile-attr="mobile_picMaxSize"></input>
                        </label>
                        <label>
                            <span>必填：</span>
                            <select mobile-attr="mobile_required">
                                <option value="true">是</option>
                                <option value="false">否</option>
                            </select>
                        </label>
                        <label class="dc_mobile_attributes_box_item_hide dc_mobile_stopSelectPop">
                            <span>下拉禁止弹窗：</span>
                            <select mobile-attr="mobile_stopSelectPop">
                                <option value="true">是</option>
                                <option value="false">否</option>
                            </select>
                        </label>
                        <label>
                            <span>格式校验：</span>
                            <select mobile-attr="mobile_formatVerification">
                                <option value="number">数字</option>
                                <option value="letter">字母</option>
                                <option value="letterAndNumber">数字字母</option>
                                <option value="mobilePhone">手机号码</option>
                                <option value="email">邮箱</option>
                                <option value="noChinese">非中文字符</option>
                                <option value="chinese">仅中文字符</option>
                                <option value="regExp">正则表达式</option>
                            </select>
                        </label>
                        <label class="dc_mobile_regExpStr">
                            <span>正则表达式：</span>
                            <input type="text"  mobile-attr="mobile_regExpStr"></input>
                        </label>
                    </div>
                </div>
                <div class="dc_Box">
                    <h6 class="dc_title">移动端事件</h6>
                    <div id="dc_mobile_event_box">
                      
                    </div>
                </div>
            </div>
            `: ''}

        
          
    </div>
                            `;
        var dialogOptions = {
            title: "文字输入域属性",
            bodyHeight: 450,
            dialogContainerBodyWidth: 700,
            bodyClass: "InputFieldElement",
            bodyHtml: InputFieldHTML,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);


        domShowAndHide(); //默认渲染
        function domShowAndHide() {
            let showDomId = jQuery(ctl)
                .find("#dc_InputFieldContentButtonBox > .dc_tabButton.dc_active")
                .attr("showDomId");
            jQuery(ctl)
                .find("#" + showDomId)
                .siblings()
                .hide();
            jQuery(ctl)
                .find("#" + showDomId)
                .show();
        }

        //给输出格式填充数据
        //列表数据
        var lbsj = LBSJ;
        //循环创建格式选项卡里的li标签
        var oUl = ctl.ownerDocument.getElementById("dc_UI-1");
        var oUlRight = ctl.ownerDocument.getElementById("dc_UI-2");
        //循环创建li标签
        for (let i = 0; i < lbsj.length; i++) {
            var oLi = ctl.ownerDocument.createElement("li");
            oLi.id = lbsj[i].id;
            oLi.className = "sss";
            oLi.style = "line-height:28px;padding:0 10px;";
            oLi.innerHTML = lbsj[i].text;
            oUl.appendChild(oLi);
        }

        // 给输出格式左侧列表添加点击事件，填充数据
        jQuery(ctl).find("#dc_UI-1 li").on("click", function () {
            if (this.innerHTML == "None") {
                jQuery(ctl).find("#dc_UI-2").hide();
            } else {
                jQuery(ctl).find("#dc_UI-2").show();
            }
            jQuery(ctl).find(".dc_selection").val(this.innerHTML);
            jQuery(ctl).find(".dc_selectionRight").val("");
            jQuery(ctl).find(".sss").css("background", "none");
            jQuery(ctl).find(".sss").css("color", "black");
            this.style.color = "#ffffff"; /*点击的*/
            this.style.backgroundColor = "#4098ff"; /*点击的*/
            // this.style = "color:#000000;backgroundColor:#d7e4f2;"
            oUlRight.innerHTML = "";
            for (let i = 0; i < lbsj.length; i++) {
                if (this.id == lbsj[i].id) {
                    var lbsj2 = lbsj[i].Child;
                    for (let i = 0; i < lbsj2.length; i++) {
                        var oLi = ctl.ownerDocument.createElement("li");
                        oLi.className = "sss2";
                        oLi.id = lbsj2[i].id;
                        oLi.style = "line-height:28px;padding:0 10px;";
                        oLi.innerHTML = lbsj2[i].text;
                        oUlRight.appendChild(oLi);
                    }
                }
            }
        });

        // 输出格式第二列ui列表的点击操作
        jQuery(ctl).find("#dc_UI-2").delegate("li", "click", function () {
            jQuery(ctl).find(".sss2").css({ "background": "none", "color": "black" });
            this.style.cssText = "color:#ffffff;background-color:#4098ff;line-height: 28px;padding: 0px 10px; color: white;";
            jQuery(ctl).find(".dc_selectionRight").val(this.innerHTML);
        });

        //输入域的输入方式的点击事件，用于对下拉方式的内部属性禁用
        jQuery(ctl).find(".dc_tab2-radio-ipt").click(function () {
            let dropDownListFormList = jQuery(ctl).find("#dc_dropDownList_formbox").find("input, select, button");
            if (this.getAttribute('attrId') === "DropdownList") {
                dropDownListFormList.removeAttr("disabled");
            } else {
                dropDownListFormList.attr("disabled", true);
            }
        });

        //校验表单禁用逻辑-tab3互斥单选
        jQuery(ctl).find(".dc_radio-ipt-choose").click(function (e) {
            // 获取当前单选按钮对应的 .dc_changeDisabled 容器
            // 结构是：单选按钮在div中，div的下一个兄弟元素是 .dc_changeDisabled
            var currentRadio = jQuery(this);
            var currentDisabledBox = currentRadio.parent().next('.dc_changeDisabled');

            // 获取所有的 .dc_changeDisabled 容器
            var allDisabledBoxes = jQuery(ctl).find(".dc_changeDisabled");

            // 遍历所有容器
            allDisabledBoxes.each(function () {
                var box = jQuery(this);
                var inputs = box.find('input, select, textarea, button');

                // 如果是当前选中的单选按钮对应的容器，启用所有输入框
                if (box.is(currentDisabledBox)) {
                    inputs.removeAttr("disabled");
                } else {
                    // 否则禁用所有输入框
                    inputs.attr("disabled", true);
                }
            });
        });

        //根据options渲染页面所需数据
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        //输入域属性回显到对话框
        if (options) {
            //先将不需要转换的简单数据进行赋值
            GetOrChangeData(dcPanelBody, options);

            //校验tab渲染options.ValidateStyle
            if (options.ValidateStyle) {
                var dc_tab3 = jQuery(ctl).find("#dc_tab3");
                GetOrChangeData(dc_tab3, options.ValidateStyle);//先将值赋值给对话框
                //其他需要特殊处理的校验逻辑
                if (options.ValidateStyle.ValueType) {
                    //对数值校验进行转换
                    if (options.ValidateStyle.ValueType === 'Integer') {
                        options.ValidateStyle.ValueType = "Numeric";
                        var DCNumericInteger = jQuery(ctl).find('#DCNumericInteger');
                        DCNumericInteger.attr('checked', true);
                    }

                    //选中一个校验格式，并禁用其他校验的内容输入
                    if (options.ValidateStyle.ValueType) {
                        var valuetype = options.ValidateStyle.ValueType;
                        var currentValidateStyleDom = jQuery(ctl).find(`#dc_tab3 .dc_ValidateStyle_label input[name=CheckRule2][attrId=${valuetype}]`);
                        currentValidateStyleDom.click();//获取到对应的校验格式并做选中状态

                        //如果是时间校验，则需要转换日期时间格式校验
                        if (options.ValidateStyle.ValueType === "DateTime") {
                            if (options.ValidateStyle.DateTimeMaxValue) {
                                ctl.ownerDocument.getElementById("dc_DateTimeMaxValue").value =
                                    RangeDate(options.ValidateStyle.DateTimeMaxValue);
                            }
                            if (options.ValidateStyle.DateTimeMinValue) {
                                ctl.ownerDocument.getElementById("dc_DateTimeMinValue").value =
                                    RangeDate(options.ValidateStyle.DateTimeMinValue);
                            }
                        }
                    }
                }
            }

            //绑定路径
            if (options && options.ValueBinding) {
                var dc_ValueBinding = jQuery(ctl).find("#dc_ValueBinding");
                GetOrChangeData(dc_ValueBinding, options.ValueBinding);
            }

            //自定义属性文本值
            if (options && options.Attributes && Object.keys(options.Attributes)) {
                jQuery(ctl).find("#dc_Attributes").val(Object.keys(options.Attributes).length + "items");
            }
            //静态属性文本值
            if (options && options.ListItems) {
                jQuery(ctl).find("#dc_StaticSelection").val(options.ListItems.length + "items");
            }

            //输入校验类型
            var innerEditStyle = options.InnerEditStyle ? options.InnerEditStyle : "Text";//设置输入域默认类型
            var currentInnerEditStyleDom = jQuery(ctl).find(`#dc_tab2 .dc_title>label>input[type="radio"]`);
            //根据属性InnerEditStyle复显输入域的输入类型
            for (var i = 0; i < currentInnerEditStyleDom.length; i++) {
                var itemAttrId = currentInnerEditStyleDom[i].getAttribute('attrid').toLowerCase() || '';
                if (itemAttrId === innerEditStyle.toLowerCase()) {
                    currentInnerEditStyleDom[i].click();
                }
            }

            //输出格式
            if (options.DisplayFormat) {
                if (options.DisplayFormat.Style) {
                    let liList = jQuery(ctl).find("#dc_UI-1 li");
                    for (var i = 0; i < liList.length; i++) {
                        if (liList[i].innerHTML === options.DisplayFormat.Style) {
                            liList[i].click();
                        }
                    }
                    if (options.DisplayFormat.Format) {
                        jQuery(ctl)
                            .find('[data-text="DisplayFormat.Format"]')
                            .val(options.DisplayFormat.Format);
                        let li2List = jQuery(ctl).find("#dc_UI-2 li");
                        for (var i = 0; i < li2List.length; i++) {
                            if (li2List[i].innerHTML === options.DisplayFormat.Format) {
                                li2List[i].click();
                            }
                        }
                    }
                }
            } else {
                jQuery(ctl).find("#dc_UI-2").hide();
            }



            //复制来源值复显
            if (options && options.CopySource) {
                var dc_CopySource = jQuery(ctl).find('#dc_CopySource');
                GetOrChangeData(dc_CopySource, options.CopySource);
            }

            //是否只读
            jQuery(ctl).find("#dc_tab1 #dc_ContentReadonly").attr("checked", options.ContentReadonly && options.ContentReadonly == "True");
        }

        //初始化背景颜色
        if (options && options.Style && options.Style.BackgroundColorString) {
            //颜色框
            jQuery(ctl).find("#dc_BackgroundColorString_box").css("background-color", options.Style.BackgroundColorString);
            jQuery(ctl).find("#dc_BackgroundColorString_box").attr("data-value", options.Style.BackgroundColorString);
        }

        //初始化背景文字颜色
        if (options && options.BackgroundTextColor) {
            //颜色框
            jQuery(ctl).find("#dc_BackgroundTextColor_box").css("background-color", options.BackgroundTextColor);
            jQuery(ctl).find("#dc_BackgroundTextColor_box").attr("data-value", options.BackgroundTextColor);
        }
        //初始化文本颜色
        if (options && options.TextColor) {
            //颜色框
            jQuery(ctl).find("#dc_TextColor_box").css("background-color", options.TextColor);
            jQuery(ctl).find("#dc_TextColor_box").attr("data-value", options.TextColor);
        }
        // 文字颜色 - 点击色块弹出颜色选择器
        jQuery(ctl).find("#dc_TextColor_box").click(function () {
            var element = this;
            DC_ColorPickerModule.show({
                id: 'dc_TextColor_picker',
                triggerElement: element,
                defaultColor: element.getAttribute("data-value") || '#000000'
            }, function (color) {
                element.style.backgroundColor = color;
                element.setAttribute("data-value", color);
            });
        });

        // 背景文字颜色 - 点击色块弹出颜色选择器
        jQuery(ctl).find("#dc_BackgroundTextColor_box").click(function () {
            var element = this;
            DC_ColorPickerModule.show({
                id: 'dc_BackgroundTextColor_picker',
                triggerElement: element,
                defaultColor: element.getAttribute("data-value") || '#FFFFFF'
            }, function (color) {
                element.style.backgroundColor = color;
                element.setAttribute("data-value", color);
            });
        });

        // 背景颜色 - 点击色块弹出颜色选择器
        jQuery(ctl).find("#dc_BackgroundColorString_box").click(function () {
            var element = this;
            DC_ColorPickerModule.show({
                id: 'dc_BackgroundColorString_picker',
                triggerElement: element,
                defaultColor: element.getAttribute("data-value") || '#FFFFFF'
            }, function (color) {
                element.style.backgroundColor = color;
                element.setAttribute("data-value", color);
            });
        });

        //列表项目符号分隔符
        const inputSeparatorChar = ctl.querySelector('#dc_ListValueSeparatorChar');
        const dropdownSeparatorChar = ctl.querySelector('#dc_ListValueSeparatorChar_box');

        inputSeparatorChar.addEventListener("click", () => {
            dropdownSeparatorChar.style.display = "block";
        });

        inputSeparatorChar.addEventListener("focus", () => {
            dropdownSeparatorChar.style.display = "block";
        });

        inputSeparatorChar.addEventListener("blur", () => {
            setTimeout(() => dropdownSeparatorChar.style.display = "none", 200);
        });

        // 点击选项填充输入框
        dropdownSeparatorChar.querySelectorAll("div").forEach(item => {
            item.addEventListener("click", () => {
                inputSeparatorChar.value = item.textContent;
                dropdownSeparatorChar.style.display = "none";
            });
        });


        //激活模式值复显
        if (options && options.EditorActiveMode) {
            jQuery(ctl).find("#dc_EditorActiveModeButton").text(options.EditorActiveMode.length ? options.EditorActiveMode : "None");
            jQuery(ctl).find("#dc_EditorActiveModeButton").prop("title", options.EditorActiveMode.length ? options.EditorActiveMode : "");
        }

        var AcceptChildElementTypes = "";
        if (options && options.AcceptChildElementTypes) {
            AcceptChildElementTypes = options.AcceptChildElementTypes;
        }

        jQuery(ctl).find("#dc_AcceptChildElementTypesButton").click(function () {
            let dc_AcceptChildElementTypesHtml =
                jQuery(` <div id="dc_childrenDialogContainer" class="dc_childrenDialogContainer"></div>
            <div id="dc_AcceptChildElementTypesHtml" >
                                <div class="dc_EditorActiveModeHeader">
                                    <p>可包含的内容</p>
                                    <p class="dc_EditorActiveModeCancelButtonIcon"></p>
                                </div> 
                                <div class="dc_EditorActiveModeContent_Box">
                                    <div>
                                        <input class="dc_radioType" type="radio" id="dc_allType" />所有文档类型
                                    </div>
                                    <div class="dc_Box">
                                        <div> <input class="dc_radioType"  type="radio" id="dc_appointType" />特定文档元素类型</div>
                                        <div id="dc_AcceptChildCheck">
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="Text" />
                                            文本类型
                                        </label>
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="LineBreak" />
                                            换行
                                        </label>
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="Field" />
                                            文本域类型
                                        </label>
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="PageBreak" />
                                            分页符
                                        </label>
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="InputField" />
                                            输入域类型
                                        </label>
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="ParagraphFlag" />
                                            段落
                                        </label>
                                            <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="Table" />
                                            表格类型
                                        </label>
                                            <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="CheckBox" />
                                            单/复选框
                                        </label>
                                            <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="Object" />
                                            对象类型
                                        </label>
                                            <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="Image" />
                                            图片
                                        </label>
                                        <label class="dc_EditorActiveItem" >
                                            <input type="checkbox" value="Button" />
                                            按钮
                                        </label>
                                      </div>
                                    </div>
                                <div class="dc_EditorActiveModeDialogBox">
                                    <p id="dc_EditorActiveModeCancel">取消</p>
                                    <p id="dc_AcceptChildElementTypesHtmlConfom">确认</p>
                                </div>
                                </div>
                            </div>`);
            dc_AcceptChildElementTypesHtml.appendTo(ctl);
            if (
                AcceptChildElementTypes &&
                AcceptChildElementTypes.length &&
                AcceptChildElementTypes != "All"
            ) {
                jQuery(ctl).find("#dc_appointType").prop("checked", true);
                let valuearr = AcceptChildElementTypes.split(",");
                valuearr = valuearr.map((item) => item.trim());
                let allDomCheck = jQuery(ctl)
                    .find("#dc_AcceptChildCheck")
                    .find('input[type="checkbox"]');
                for (var i = 0; i < allDomCheck.length; i++) {
                    let item = allDomCheck[i];
                    if (valuearr.indexOf(item.value) !== -1) {
                        jQuery(item).attr("checked", true);
                    }
                }
            }
            if (AcceptChildElementTypes === "All") {
                jQuery(ctl).find("#dc_allType").prop("checked", true);
                jQuery(ctl)
                    .find("#dc_AcceptChildCheck")
                    .find('input[type="checkbox"]')
                    .attr("disabled", true);
            }
            jQuery(ctl)
                .find(
                    ".dc_EditorActiveModeCancelButtonIcon,#dc_EditorActiveModeCancel"
                )
                .click(function () {
                    jQuery(ctl).find("#dc_AcceptChildElementTypesHtml").remove();
                    jQuery(ctl).find("#dc_childrenDialogContainer").remove();
                });
            jQuery(ctl)
                .find(".dc_radioType")
                .click(function (e) {
                    if (e.target.id == "dc_allType") {
                        jQuery(ctl).find("#dc_appointType").removeAttr("checked");
                        jQuery(ctl)
                            .find("#dc_AcceptChildCheck")
                            .find('input[type="checkbox"]')
                            .attr("disabled", true);
                    } else {
                        jQuery(ctl).find("#dc_allType").removeAttr("checked");
                        jQuery(ctl)
                            .find("#dc_AcceptChildCheck")
                            .find('input[type="checkbox"]')
                            .removeAttr("disabled");
                    }
                });
            jQuery(ctl)
                .find("#dc_AcceptChildElementTypesHtmlConfom")
                .click(function () {
                    if (jQuery(ctl).find("#dc_allType").attr("checked")) {
                        AcceptChildElementTypes = "All";
                    }
                    if (jQuery(ctl).find("#dc_appointType").attr("checked")) {
                        let arrDom = jQuery(ctl)
                            .find("#dc_AcceptChildCheck")
                            .find('input[type="checkbox"]');
                        let str = [];
                        for (var i = 0; i < arrDom.length; i++) {
                            let item = arrDom[i];
                            if (jQuery(item).attr("checked")) {
                                str.push(item.value);
                            }
                        }
                        AcceptChildElementTypes = str.join();
                    }
                    jQuery(ctl)
                        .find("#dc_AcceptChildElementTypesInput")
                        .val(AcceptChildElementTypes);
                    jQuery(ctl).find("#dc_AcceptChildElementTypesHtml").remove();
                    jQuery(ctl).find("#dc_childrenDialogContainer").remove();
                });
        });
        //激活模式点击
        jQuery(ctl).find("#dc_EditorActiveModeButton").click(function () {
            let editorActiveModeSelectHtml =
                jQuery(` <div id="dc_childrenDialogContainer" class="dc_childrenDialogContainer"></div>
            <div id="dc_EditorActiveModeSelect" >
                                <div class="dc_EditorActiveModeHeader">
                                    <p>激活模式选项</p>
                                    <p class="dc_EditorActiveModeCancelButtonIcon"></p>
                                </div>
                                <div class="dc_EditorActiveModeContainer">
                                    <label class="dc_EditorActiveItem" >
                                        <input  type="checkbox" value="Default"></input>默认激活模式，由文档对象的BehaviorOptions,DefaultEditorActiveMode属性值指定
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="Program"></input>应用程序激活
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="F2"></input>按下F2键激活
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="GotFocus"></input>获得输入焦点时就激活
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="MouseDblClick"></input>鼠标双击就激活
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="MouseClick"></input>鼠标单击就激活
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="MouseRightClick"></input>鼠标右击就激活
                                    </label>
                                    <label class="dc_EditorActiveItem">
                                        <input  type="checkbox" value="Enter"></input>键盘Enter键激活
                                    </label>
                                </div>
                                <div class="dc_EditorActiveModeDialogBox">
                                    <p id="dc_EditorActiveModeCancel">取消</p>
                                    <p id="dc_EditorActiveModeConfom">确认</p>
                                </div>
                            </div>`);
            editorActiveModeSelectHtml.appendTo(ctl);
            // console.log(jQuery(ctl).find("#dc_EditorActiveModeButton").text());
            if (jQuery(ctl).find("#dc_EditorActiveModeButton").text()) {
                let EditorActiveModeValueArr = jQuery(ctl)
                    .find("#dc_EditorActiveModeButton")
                    .text();
                let EditorActiveItemArr = jQuery(ctl).find(
                    '.dc_EditorActiveItem>input[type="checkbox"]'
                );
                for (var i = 0; i < EditorActiveItemArr.length; i++) {
                    let item = EditorActiveItemArr[i];
                    if (EditorActiveModeValueArr.includes(item.value)) {
                        item.checked = true;
                    } else {
                        item.checked = false;
                    }
                }
            }
            jQuery(ctl)
                .find(
                    ".dc_EditorActiveModeCancelButtonIcon,#dc_EditorActiveModeCancel"
                )
                .click(function () {
                    jQuery(ctl).find("#dc_EditorActiveModeSelect").remove();
                    jQuery(ctl).find("#dc_childrenDialogContainer").remove();
                });
            jQuery(ctl)
                .find("#dc_EditorActiveModeConfom")
                .click(function () {
                    let EditorActiveItemArr = jQuery(ctl).find(
                        '.dc_EditorActiveItem>input[type="checkbox"]'
                    );
                    let EditorActiveModeValueStr = "";
                    for (var i = 0; i < EditorActiveItemArr.length; i++) {
                        let item = EditorActiveItemArr[i];
                        if (item.checked) {
                            EditorActiveModeValueStr +=
                                (EditorActiveModeValueStr.length > 1 ? "," : "") + item.value;
                        }
                    }
                    jQuery(ctl)
                        .find("#dc_EditorActiveModeButton")
                        .text(
                            EditorActiveModeValueStr.length
                                ? EditorActiveModeValueStr
                                : "None"
                        );
                    jQuery(ctl)
                        .find("#dc_EditorActiveModeButton")
                        .prop("title", EditorActiveModeValueStr);
                    jQuery(ctl).find("#dc_EditorActiveModeSelect").remove();
                    jQuery(ctl).find("#dc_childrenDialogContainer").remove();
                });
        });

        //tab切换
        jQuery(ctl).find("#dc_InputFieldContentButtonBox > .dc_tabButton").click(function () {
            let tabButtonActive = jQuery(ctl).find(
                "#dc_InputFieldContentButtonBox > .dc_tabButton.dc_active"
            );
            if (tabButtonActive[0] !== this) {
                tabButtonActive.removeClass("dc_active");
                this.className = "dc_tabButton dc_active";
                domShowAndHide();
            }
        });



        //静态属性内容二级弹框
        var AttributesC = [];
        if (options && options.ListItems && options.ListItems.length) {
            AttributesC = [...options.ListItems];
        }
        jQuery(ctl).find("#dc_browseTextTableContent").click(function () {
            setBrowseTextTableContent();
        });
        //自定义属性二级弹框
        var AttributesA = {}; //接收自定义属性
        if (
            options &&
            options.Attributes &&
            Object.keys(options.Attributes).length
        ) {
            AttributesA = JSON.parse(JSON.stringify(options.Attributes));
        }
        jQuery(ctl).find("#dc_tab4 #dc_browsess").click(function () {
            setCustomAttributeContent();
        });

        // 静态选择内容弹框
        function setBrowseTextTableContent() {
            let staticDialog = jQuery(`
            <div id="dc_BrowseTextTableDialog" class="dc_childrenDialogContainer"></div>
                <div id="dc_dialogContainer1" class="dc-dialog-container">
                    <div id="dcPanelHeader1" >
                    <span>静态选择项内容</span>
                    <div class="dc_cancel3 dcHeader-tool">
                    <b class="dcTool-close">✖</b>
                </div>
            </div>
                <div id="dcPanelBody1" ></div>
                <div id="dcPanelFooter1">  
                    <button class="dclinkbutton dc_cancel3">取消</button>
                    <button class="dclinkbutton dc_determine3">确认</button> 
                </div>
            </div>
            `);
            staticDialog.appendTo(ctl);

            var watermark1 = `
                <div class="dc_watermark_container"  >
                    <span class="dc_watermarks_text" >字典来源：</span>
                    <input id="dc_InnerListSourceName" data-text="InnerListSourceName" type="text">
                </div> 
                <div class="dc_watermark_container_2">
                    <svg style="cursor: pointer;width:20px;height:20px;" t="1682241871634" class="dc_newlyIncreased" viewBox="0 0 1024 1024" version="1.1" 
                        xmlns="http://www.w3.org/2000/svg" p-id="4289" width="200" height="200">
                        <title>添加一行</title>
                        <path d="M544 480v-298.666667h-64v298.666667h-298.666667v64h298.666667v298.666667h64v-298.666667h298.666667v-64h-298.666667z"
                            fill="#61ea6a" p-id="4290"></path></svg>
                    <svg style="cursor: pointer;width:20px;height:20px;" t="1682241967818" class=" dc_moveUp" viewBox="0 0 1024 1024" version="1.1" 
                        xmlns="http://www.w3.org/2000/svg" p-id="5609" width="200" height="200">
                        <title>向上一行</title>
                        <path d="M489.386667 361.386667a32 32 0 0 1 45.226666 0L813.226667 640 768 685.226667l-256-256-256 256L210.773333 640l278.613334-278.613333z"
                            fill="#1296db" p-id="5610"></path></svg>
                    <svg style="cursor: pointer;width:20px;height:20px;" t="1682241944286" class=" dc_MoveDown" viewBox="0 0 1024 1024" version="1.1" 
                        xmlns="http://www.w3.org/2000/svg" p-id="5319" width="200" height="200">
                        <title>向下一行</title>
                        <path d="M256 338.773333l256 256 256-256L813.226667 384l-278.613334 278.613333a32 32 0 0 1-45.226666 0L210.773333 384 256 338.773333z"
                            fill="#1296db" p-id="5320"></path></svg>
                    <svg style="cursor: pointer;width:20px;height:20px;" t="1682241933018" class=" dc_DeleteIine" viewBox="0 0 1024 1024" version="1.1" 
                        xmlns="http://www.w3.org/2000/svg" p-id="5174" width="200" height="200">
                        <title>删除本行</title>
                        <path d="M557.226667 512l256-256L768 210.773333l-256 256-256-256L210.773333 256l256 256-256 256L256 813.226667l256-256 256 256L813.226667 768l-256-256z"
                            fill="#cf514b" p-id="5175"></path></svg>
                    <svg style="cursor: pointer;width:18px;height:18px;" t="1682241953506" class=" dc_DeleteAll" viewBox="0 0 1024 1024" version="1.1" 
                        xmlns="http://www.w3.org/2000/svg" p-id="5464" width="200" height="200">
                        <title>清空列表项目</title>
                        <path d="M394.666667 128v96h256V128a10.666667 10.666667 0 0 0-10.666667-10.666667H405.333333a10.666667 10.666667 0 0 0-10.666666 10.666667z m-64 96V128c0-41.216 33.450667-74.666667 74.666666-74.666667H640c41.216 0 74.666667 33.450667 74.666667 74.666667v96h213.333333v64h-85.333333V896A74.666667 74.666667 0 0 1 768 970.666667H256A74.666667 74.666667 0 0 1 181.333333 896V288h-85.333333v-64h234.666667z m-85.333334 64V896c0 5.888 4.778667 10.666667 10.666667 10.666667h512a10.666667 10.666667 0 0 0 10.666667-10.666667V288H245.333333z m213.333334 149.333333v320h-64v-320h64z m170.666666 320v-320h-64v320h64z"
                            fill="#d81e06" p-id="5465"></path>
                    </svg>
                </div>
                <table id="dc_batchPlanTable"  class="dc_currentTableDom"  border="1">
                    <tr>
                        <th  class="dc_on-1">序号</th>
                        <th  class="dc_on-2">文本</th>
                        <th  class="dc_on-3">值</th>
                        <th  class="dc_on-3">指定列表文本</th>
                        <th  class="dc_on-3">分组名</th>
                    </tr>
                    <tr id="tr_table" class="dc_tr_ab">
                        <td  id="dc_batchPlanTableon1" class="dc_on-1"></td>
                        <td><input class="dc_on-2" type="text" data-arraytext="Text" ></input></td>
                        <td><input class="dc_on-3" type="text" data-arraytext="Value" ></input></td>
                        <td><input  class="dc_tr-s"  type="text" data-arraytext="TextInList" ></input></td>
                        <td><input  class="dc_tr-g"  type="text" data-arraytext="Group" ></input></td>
                    </tr>
                    <template class="dc_template_item">
                        <tr id="tr_table" class="dc_tr_ab">
                            <td class="dc_on-1"></td>
                            <td><input class="dc_on-2" type="text" data-arraytext="Text" ></input></td>
                            <td><input class="dc_on-3"  type="text" data-arraytext="Value" ></input></td>
                            <td><input class="dc_tr-s" type="text" data-arraytext="TextInList" ></input></td>
                            <td><input class="dc_tr-g" type="text" data-arraytext="Group" ></input></td>
                        </tr>
                    </template>
                </table>`;
            //插入dom结构
            jQuery(ctl).find("#dcPanelBody1").html(watermark1).css("background", "#FAFAFA");
            //优先展示当前用户操作过的列表
            let newListItem = AttributesC && AttributesC.length
                ? AttributesC
                : (options && options.ListItems) || [];

            if (newListItem && newListItem.length) {
                var CDC = jQuery(ctl).find(".dc_tr_ab")[0];
                for (var i = 0; i < newListItem.length; i++) {
                    var tr = ctl.ownerDocument.createElement("tr");
                    tr.className = "dc_tr_ab";
                    tr.innerHTML = `<td  class="dc_on-1">${i + 1}</td>
                            <td><input  class="dc_on-2" type="text" data-arraytext="Text" value="${newListItem[i].Text || ""
                        }" ></input> </td>
                            <td><input  class="dc_on-3" type="text" data-arraytext="Text" value="${newListItem[i].Value || ""
                        }" ></input> </td>
                            <td><input  class="dc_tr-s" type="text" data-arraytext="Text" value="${newListItem[i].TextInList || ""
                        }" ></input></td>
                        <td><input  class="dc_tr-g" type="text" data-arraytext="Text" value="${newListItem[i].Group || ""
                        }" ></input></td>`;
                    CDC.before(tr);
                }

                let dc_batchPlanTableon1 = ctl.ownerDocument.getElementById("dc_batchPlanTableon1");
                if (dc_batchPlanTableon1) {
                    dc_batchPlanTableon1.innerHTML = (newListItem && newListItem.length + 1) || '';
                }
            }
            if (InnerListSourceName) {
                //数据字典回填
                jQuery(ctl).find("#dc_InnerListSourceName").val(InnerListSourceName);
            }


            //自动增加行
            var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer1");
            var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody1");
            dcPanelBody
                .find("#dc_batchPlanTable")
                .on("input", "input[data-arraytext]", function () {
                    var input = jQuery(this);
                    var tr = input.parents("tr");
                    if (tr.nextAll("tr").length == 0) {
                        var ListItems_item = input
                            .parents("table")
                            .find("template.dc_template_item")[0];
                        tr.after(ListItems_item.content.cloneNode(true));
                        let newOn1 = jQuery(ctl).find(".dc_on-1");
                        for (var i = 1; i < newOn1.length; i++) {
                            newOn1[i].innerHTML = i;
                        }
                    }
                });
            //添加自定义属性
            AddCustomProperties();
            //表格行操作 新增
            AddTableRow();
            // 表格行操作 上移
            TableRowMovedUp();
            // 表格行操作 下移
            TableRowDown();
            //表格行操作 删除行
            DeleteLine();
            //表格行操作 全部删除
            dc_DeleteAll();

            // 按下键盘上下左右，控制光标跳转单元格
            function CellInputFocus(event) {
                //键盘监听上下左右键，根据按键跳转单元格输入框
                let cells = dcPanelBody.find("#dc_batchPlanTable input");
                let currentCell = ctl.ownerDocument.activeElement; // 获取当前拥有焦点的单元格
                let index = 0;//默认当前input的下标
                let targetCell = null;//目标input
                if (event.key === 'ArrowUp') {
                    // 切换到上方的单元格
                    index = Array.from(cells).indexOf(currentCell);
                    targetCell = cells[index - 4]; // 每行有4个input
                } else if (event.key === 'ArrowDown') {
                    // 切换到下方的单元格
                    index = Array.from(cells).indexOf(currentCell);
                    targetCell = cells[index + 4]; // 每行有4个input
                } else if (event.key === 'ArrowLeft') {
                    // 判断光标位置
                    if (currentCell.selectionStart === 0 && currentCell.selectionEnd === 0) {
                        // 切换到左边的单元格
                        index = Array.from(cells).indexOf(currentCell);
                        targetCell = cells[index - 1];
                    }
                } else if (event.key === 'ArrowRight') {
                    // 判断光标位置
                    if (currentCell.selectionStart === currentCell.value.length && currentCell.selectionEnd === currentCell.value.length) {
                        // 切换到右边的单元格
                        index = Array.from(cells).indexOf(currentCell);
                        targetCell = cells[index + 1];
                    }
                }
                if (targetCell) {
                    setTimeout(() => {
                        targetCell.focus();
                        targetCell.setSelectionRange(targetCell.value.length, targetCell.value.length);
                    });
                }
            }

            // 确认--->收集数据
            jQuery(ctl)
                .find(".dc_determine3")
                .click(function () {
                    AttributesC = [];
                    InnerListSourceName = jQuery(ctl)
                        .find("#dc_InnerListSourceName")
                        .val();
                    let allTrAb = jQuery(ctl).find(".dc_tr_ab");
                    for (let i = 0; i < jQuery(ctl).find(".dc_tr_ab").length; i++) {
                        var AttributesB = {}; //接收动态列表
                        var ssf = jQuery(ctl).find(".dc_tr_ab")[i].children;
                        for (let u = 0; u < ssf.length; u++) {
                            if (ssf[u].children && ssf[u].children[0]) {
                                if (ssf[u].children[0].className == "dc_on-2") {
                                    AttributesB.Text = jQuery(ssf[u].children[0]).val();
                                }
                                if (ssf[u].children[0].className == "dc_on-3") {
                                    AttributesB.Value = jQuery(ssf[u].children[0]).val();
                                }
                                if (ssf[u].children[0].className == "dc_tr-s") {
                                    AttributesB.TextInList = jQuery(ssf[u].children[0]).val();
                                }
                                if (ssf[u].children[0].className == "dc_tr-g") {
                                    AttributesB.Group = jQuery(ssf[u].children[0]).val();
                                }
                            }
                        }

                        if (i == allTrAb.length - 1) {
                            if (Object.values(AttributesB).join("").length) {
                                AttributesC.push(AttributesB);
                            }
                        } else {
                            AttributesC.push(AttributesB);
                        }
                    }
                    jQuery(ctl)
                        .find("#dc_StaticSelection")
                        .val(AttributesC.length + " " + "items");
                    jQuery(ctl).find("#dc_dialogContainer1").remove();
                    jQuery(ctl).find("#dc_BrowseTextTableDialog").remove();
                    // 删除监听键盘按下事件
                    ctl.ownerDocument.removeEventListener('keydown', CellInputFocus);
                });
            // 关闭
            jQuery(ctl)
                .find(".dc_cancel3,.dcTool-close")
                .click(function () {
                    jQuery(ctl).find("#dc_dialogContainer1").remove();
                    jQuery(ctl).find("#dc_BrowseTextTableDialog").remove();
                    // 删除监听键盘按下事件
                    ctl.ownerDocument.removeEventListener('keydown', CellInputFocus);
                });

            // 监听键盘按下事件
            ctl.ownerDocument.addEventListener('keydown', CellInputFocus);
        }
        let that = this;
        // 自定义属性弹框
        function setCustomAttributeContent() {
            let customAttributeDialog = jQuery(`
            <div id="dc_CustomAttributeTableDialog" class="dc_childrenDialogContainer"></div>
            <div id="dc_dialogContainer2" class="dc-dialog-container">
                <div id="dcPanelHeader2" >
                <span>自定义属性</span>
                <div class="dc_cancel2 dcHeader-tool">
                    <b class= "dcTool-close">✖</b>
                </div>
                </div>
                <div id="dcPanelBody2">
                    <div id="dc_attr-box" ></div>
                </div>
                <div id="dcPanelFooter2" >  
                    <button class="dclinkbutton dc_cancel2">取消</button>
                    <button class="dclinkbutton dc_determine2">确认</button> 
                </div>
            </div>
            `);
            customAttributeDialog.appendTo(ctl);

            that.attributeComponents("#dc_attr-box", AttributesA || {}, ctl);

            //确认
            jQuery(ctl)
                .find(".dc_determine2")
                .click(function () {
                    var dcAttrBox = jQuery(ctl).find("#dc_attr-box");
                    AttributesA = that.attributeComponents_getAttributeObj(dcAttrBox);
                    jQuery(ctl).find("#dc_Attributes").val(Object.values(AttributesA).length + " " + "items");
                    jQuery(ctl).find("#dc_dialogContainer2").remove();
                    jQuery(ctl).find("#dc_CustomAttributeTableDialog").remove();
                });
            // 关闭
            jQuery(ctl)
                .find(".dc_cancel2,.dcTool-close")
                .click(function () {
                    jQuery(ctl).find("#dc_dialogContainer2").remove();
                    jQuery(ctl).find("#dc_CustomAttributeTableDialog").remove();
                });
        }
        //表格行操作 全部删除
        function dc_DeleteAll() {
            jQuery(ctl)
                .find(".dc_DeleteAll")
                .on("click", function () {
                    if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                        var CDC = jQuery(ctl).find(".dc_tr_ab");
                        for (let i = 0; i < CDC.length; i++) {
                            CDC[i].remove();
                        }
                        var tr = ctl.ownerDocument.createElement("tr");
                        tr.className = "dc_tr_ab";
                        tr.innerHTML = `
                        <td  class="dc_on-1">1</td>
                        <td><input class="dc_on-2" type="text" data-arraytext="Text" value="" ></input> </td>
                        <td><input class="dc_on-3" type="text" data-arraytext="Text" value="" ></input> </td>
                        <td><input class="dc_tr-s" type="text" data-arraytext="Text" value="" ></input></td>`;
                        jQuery(ctl).find("#dc_batchPlanTable").append(tr);
                    }
                });
        }
        //表格行操作 删除行
        function DeleteLine() {
            jQuery(ctl)
                .find(".dc_DeleteIine")
                .on("click", function () {
                    if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                        var CDC = jQuery(ctl).find(".dc_tr_ab");
                        for (let i = 0; i < CDC.length; i++) {
                            if (CDC[i].getAttribute("moveh") == "true") {
                                var current = CDC[i];
                                current.remove();
                            }
                        }
                    }
                });
        }
        //表格行操作 下移
        function TableRowDown() {
            jQuery(ctl)
                .find(".dc_MoveDown")
                .on("click", function () {
                    if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                        var CDC = jQuery(ctl).find(".dc_tr_ab");
                        for (let i = 0; i < CDC.length; i++) {
                            if (CDC[i].getAttribute("moveh") == "true") {
                                var current = CDC[i];
                                var prev = current.nextElementSibling;
                                // console.log(CDC[i].rowIndex);
                                jQuery(prev).after(current);
                            }
                        }
                    }
                });
        }
        // 表格行操作 上移
        function TableRowMovedUp() {
            jQuery(ctl)
                .find(".dc_moveUp")
                .on("click", function () {
                    if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                        var CDC = jQuery(ctl).find(".dc_tr_ab");
                        for (let i = 0; i < CDC.length; i++) {
                            if (CDC[i].getAttribute("moveh") == "true") {
                                var current = CDC[i];
                                var prev = current.previousElementSibling;
                                if (CDC[i].rowIndex > 1) {
                                    jQuery(prev).before(current);
                                } else {
                                    // alert("已经到头部了")
                                }
                            }
                        }
                    }
                });
        }
        //表格行操作 新增
        function AddTableRow() {
            jQuery(ctl)
                .find(".dc_newlyIncreased")
                .on("click", function () {
                    if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                        var tr = ctl.ownerDocument.createElement("tr");
                        let newOn1 = jQuery(ctl).find(".dc_on-1");
                        tr.className = "dc_tr_ab";
                        tr.innerHTML = `
                        <td  class="dc_on-1">${newOn1.length}</td>
                        <td><input class="dc_on-2" type="text" data-arraytext="Text" value="" ></input> </td>
                        <td><input class="dc_on-3" type="text" data-arraytext="Text" value="" ></input> </td>
                        <td><input class="dc_on-s" type="text" data-arraytext="Text" value="" ></input> </td>
                        <td><input class="dc_tr-g" type="text" data-arraytext="Text" value="" ></input></td>`;
                        jQuery(ctl).find("#dc_batchPlanTable").append(tr);
                        return;
                    } else {
                        return;
                    }
                });
        }
        //添加自定义属性
        function AddCustomProperties() {
            if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                jQuery(ctl)
                    .find("#dc_batchPlanTable")
                    .delegate(".dc_tr_ab", "click", function () {
                        jQuery(ctl).find(".dc_tr_ab").removeAttr("moveh", false);
                        jQuery(this).attr("moveh", true);
                        // console.log(this);
                    });
            }
        }
        // 处理新增单元格的问题
        //绑定事件需要修改
        ctl.ownerDocument.onkeyup = function () {
            if (jQuery(ctl).find("#dcPanelBody1").css("display") == "block") {
                if (
                    jQuery(ctl).find("table").find("tr:last")[0].children[1].children[0]
                        .value === ""
                ) {
                    return;
                } else {
                    var tr = ctl.ownerDocument.createElement("tr");
                    tr.className = "dc_tr_ab";
                    tr.innerHTML = `
                    <td  class="dc_on-1"></td>
                            <td><input  class="dc_on-2" type="text" data-arraytext="Text" value="" ></input> </td>
                            <td><input  class="dc_on-3" type="text" data-arraytext="Text" value="" ></input> </td>
                            <td><input  class="dc_tr-s" type="text" data-arraytext="Text" value="" ></input></td>`;
                    jQuery(ctl).find("#dc_batchPlanTable").append(tr);
                }
            } else {
                return;
            }
        };

        //[DUWRITER5_0-3748] 20241025 lxy 新增属性表达式功能
        var propertyExpressionObject = {};
        //属性表达式值回填
        var propertyShowInput = ctl.ownerDocument.getElementById('dc_PropertyExpressions_show_input');
        if (options.PropertyExpressions) {
            //防止渲染重复的可见性表达式值
            var inputValue = '';
            var propertyKeyArr = Object.keys(options.PropertyExpressions) || [];
            INPUTFIELDPROPERTYEXPRESSIONSARRAY.forEach(item => {
                if (propertyKeyArr && propertyKeyArr.indexOf(item) > -1) {
                    propertyExpressionObject[item] = options.PropertyExpressions[item];
                    //拼接展示文本
                    if (propertyExpressionObject[item] !== '') {
                        inputValue += `${inputValue === '' ? '' : ','}${item}:${propertyExpressionObject[item]}`;
                    }
                } else {
                    propertyExpressionObject[item] = '';
                }
            });
            propertyShowInput.value = inputValue;
        }

        //属性表达式操作对话框
        var propertyExpressionsButton = jQuery(ctl).find("#dc_tab4 #dc_PropertyExpressionsButton");
        propertyExpressionsButton.click(function () {
            //判断是否已经存在修改过的属性表达式
            if (!propertyExpressionObject || Object.keys(propertyExpressionObject).length === 0) {
                INPUTFIELDPROPERTYEXPRESSIONSARRAY.forEach(item => {
                    propertyExpressionObject[item] = '';
                });
            }

            that.PropertyExpressionsDialog(propertyExpressionObject, ctl, function (changedPropertyExpressions) {
                //获取修改后的属性表达式
                propertyExpressionObject = JSON.parse(JSON.stringify(changedPropertyExpressions));
                //更新属性表达式的显示
                var inputValue = '';
                for (let key in changedPropertyExpressions) {
                    if (changedPropertyExpressions[key] !== '') {
                        inputValue += `${inputValue === '' ? '' : ','}${key}:${changedPropertyExpressions[key]}`;
                    }
                }
                propertyShowInput.value = inputValue;
            });
        });

        // [4927] 20251125 lxy 如果点击的是移动端属性tab5，就要重新获取一遍当前输入域的格式
        function getInputFieldFormat() {
            //获取输入域格式类型tab2
            var InnerEditStyleCheck = jQuery(ctl).find('#dc_tab2 .dc_title>label>input[type="radio"]:checked');
            //当前输入域类型
            var currentInnerEditStyle = InnerEditStyleCheck.attr('attrid');
            currentInnerEditStyle = currentInnerEditStyle.toLowerCase();
            //当前移动端属性样式
            var currentMobileStyle = jQuery(ctl).find('select[mobile-attr="mobile_style"]');
            var mobileTypeOptions = [];
            if (currentInnerEditStyle === "dropdownlist") {
                mobileTypeOptions = [
                    {
                        value: "select",
                        label: "下拉",
                    },
                    {
                        value: "radio",
                        label: "单选",
                    },
                    {
                        value: "checkbox",
                        label: "多选",
                    }
                ];
            } else {
                mobileTypeOptions = [
                    {
                        value: "text",
                        label: "文本",
                    },
                    {
                        value: "textarea",
                        label: "多行文本",
                    },
                    {
                        value: "sign",
                        label: "签名",
                    },
                    {
                        value: "textToSpeech",
                        label: "语音转文字",
                    },
                    {
                        value: "image",
                        label: "图片",
                    },
                ];
            }
            currentMobileStyle.html(mobileTypeOptions.map(item => `<option value="${item.value}">${item.label}</option>`).join(''));
        }
        //[4927] 20251125 lxy 移动端样式属性显隐
        function setMobileAttributesBoxItemHide(selectedValue) {
            //先隐藏所有的关联选项
            var dcMobileAttributesBoxItemHide = jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_attributes_box_item_hide');
            dcMobileAttributesBoxItemHide.css('display', 'none');

            switch (selectedValue) {
                case "radio":
                    jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_radioStartStr').css('display', 'flex');
                    jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_radioEndStr').css('display', 'flex');
                    break;
                case "checkbox":
                    break;
                case "select":
                    jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_stopSelectPop').css('display', 'flex');
                    break;
                case "sign":
                    jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_unUseSelfPop').css('display', 'flex');
                    break;
                case "image":
                    jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_usePicUpload').css('display', 'flex');
                    //判断是否打开图片上传
                    setMobileAttributesusePicUploadHide(jQuery(ctl).find('#dc_attr_mobile_usePicUpload').val());
                    break;
                default:
                    //关闭所有关联的显隐
                    dcMobileAttributesBoxItemHide.css('display', 'none');
                    break;
            }
        }
        //[4927] 20251125 lxy 图片样式显隐
        function setMobileAttributesusePicUploadHide(selectedValue) {
            if (selectedValue === 'true' || selectedValue === true) {
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_picUploadURL').css('display', 'flex');
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_picLimit').css('display', 'flex');
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_picMaxSize').css('display', 'flex');
            } else {
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_picUploadURL').css('display', 'none');
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_picLimit').css('display', 'none');
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_picMaxSize').css('display', 'none');
            }
        }
        //[4927] 20251125 lxy 表达式显隐
        function setMobileFormatVerificationHide(selectedValue) {
            if (selectedValue === "regExp") {
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_regExpStr').css('display', 'flex');
            } else {
                jQuery(ctl).find('.dc_mobile_attributes_box label.dc_mobile_regExpStr').css('display', 'none');
            }
        }
        //[4927] 20251125 lxy 移动端事件显隐
        function setMobileEventShowHide(selectedValue) {
            var mobileEventArr = [];
            switch (selectedValue) {
                case "text":
                case "textarea":
                    mobileEventArr = ["onCreated", "onMounted", "onInput", "onFocus"];
                    break;
                case "sign":
                    mobileEventArr = ["onCreated", "onMounted", "onOpenSignature", "onSignatureChange"];
                    break;
                case "textToSpeech":
                    mobileEventArr = ["onCreated", "onMounted", "onFocus"];
                    break;
                case "image":
                    mobileEventArr = ["onCreated", "onMounted", "onBeforeUpload", "onUploadSuccess", "onChooseFile"];
                    break;
                case "checkbox":
                case "radio":
                case "select":
                    mobileEventArr = ["onCreated", "onMounted", "onChange", "onFocus"];
                    break;
                default:
                    mobileEventArr = ["onCreated", "onMounted", "onInput", "onFocus"];
                    break;
            }
            //设置事件展示
            var dc_mobile_event_box = jQuery(ctl).find('#dc_mobile_event_box');
            dc_mobile_event_box.html(mobileEventArr.map(item => `<div class="dc_mobile_event_item">
                    <span>${item}</span>
                    <span class="dc_mobile_event_item_edit" mobile-event="${item}" >编辑事件</span>
                </div>`).join(''));
        }
        //[4927] 20251125 lxy 判断是否开启移动端属性
        if (IsShowMobileDeviceAttributes) {
            //[4927] 20251125 lxy 给移动端样式选择框一个事件监听，修改值时控制关联的显隐
            var mobileStyleSelect = jQuery(ctl).find('select[mobile-attr="mobile_style"]');
            mobileStyleSelect.on('change', function () {
                var selectedValue = jQuery(this).val();
                //属性显隐
                setMobileAttributesBoxItemHide(selectedValue);
                //事件显隐
                setMobileEventShowHide(selectedValue);
                //判断是否为图片，如果是图片，则设置图片上传的显隐
                if (selectedValue === "image") {
                    var dc_attr_mobile_usePicUpload = jQuery(ctl).find('#dc_attr_mobile_usePicUpload');
                    var dc_attr_mobile_usePicUpload_value = dc_attr_mobile_usePicUpload.val();
                    setMobileAttributesusePicUploadHide(dc_attr_mobile_usePicUpload_value);
                }
            });

            //[4927] 20251125 lxy 给图片样式一个事件监听，修改值时控制关联的显隐
            var dc_attr_mobile_usePicUpload = jQuery(ctl).find('#dc_attr_mobile_usePicUpload');
            dc_attr_mobile_usePicUpload.on('change', function () {
                var selectedValue = jQuery(this).val();
                setMobileAttributesusePicUploadHide(selectedValue);
            });

            //[4927] 20251125 lxy 给表达式一个事件监听，修改值时控制关联的显隐
            var mobileFormatVerification = jQuery(ctl).find('select[mobile-attr="mobile_formatVerification"]');
            mobileFormatVerification.on("change", function () {
                var selectedValue = jQuery(this).val();
                setMobileFormatVerificationHide(selectedValue);
            });

            //[4927] 20251125 lxy 给移动端事件一个事件监听，用于弹出对话框输入事件内容
            // 使用事件委托，绑定到父元素，支持动态添加的元素
            var dc_mobile_event_box = jQuery(ctl).find('#dc_mobile_event_box');
            dc_mobile_event_box.on('click', '.dc_mobile_event_item_edit', function () {
                var mobileEvent = jQuery(this).attr('mobile-event');
                mobileEvent = "mobile_" + mobileEvent;

                var eventContent = dcMobileConfig[mobileEvent];
                mobileEventDialog(mobileEvent, eventContent, function (code, mobileEvent) {
                    //保存事件内容
                    dcMobileConfig[mobileEvent] = code;
                }, function () {
                    console.log('取消');
                });
            });



            // 移动端初始化赋值
            if (IsShowMobileDeviceAttributes === true) {
                getInputFieldFormat();//初始化移动端样式下拉选项
                try {
                    //数据源绑定路径
                    if (options.ValueBinding && options.ValueBinding.BindingPath) {
                        dcMobileConfig['mobile_bindingPath'] = options.ValueBinding.BindingPath || '';
                    }
                    //数据源绑定名称
                    if (options.ValueBinding && options.ValueBinding.DataSource) {
                        dcMobileConfig['mobile_dataSource'] = options.ValueBinding.DataSource || '';
                    }
                    //ID
                    if (options.ID) {
                        dcMobileConfig['mobile_id'] = options.ID || '';
                    }
                    //mobile_label标签名称
                    if (options.Name) {
                        dcMobileConfig['mobile_label'] = options.Name || '';
                    }

                    //移动端属性赋值
                    var dcTab5 = ctl.querySelector('#dc_tab5');
                    var dcMobileConfigDom = dcTab5.querySelectorAll('[mobile-attr]');
                    if (dcMobileConfigDom && dcMobileConfigDom.length) {
                        for (var i = 0; i < dcMobileConfigDom.length; i++) {
                            var dcMobileConfigItem = dcMobileConfigDom[i];
                            var mobileAttr = dcMobileConfigItem.getAttribute('mobile-attr');
                            var mobileAttrValue = dcMobileConfig[mobileAttr];
                            //判断当前元素是否为div(id、name、数据源绑定路径、数据源绑定名称)
                            if (dcMobileConfigItem.tagName === 'DIV') {
                                dcMobileConfigItem.innerHTML = mobileAttrValue || '';
                            } else {
                                dcMobileConfigItem.value = mobileAttrValue || '';
                            }
                        }
                    }

                    //样式显隐
                    setMobileAttributesBoxItemHide(dcMobileConfig['mobile_style']);//初始化样式显隐
                    //判断图片样式是否开启，如果开启，则设置图片上传显隐
                    if (dcMobileConfig['mobile_style'] === 'image') {
                        setMobileAttributesusePicUploadHide(dcMobileConfig['mobile_usePicUpload'] || '');
                    }
                    //表达式显隐
                    setMobileFormatVerificationHide(dcMobileConfig['mobile_formatVerification'] || '');
                    //事件显隐
                    setMobileEventShowHide(dcMobileConfig['mobile_style'] || '');//初始化事件显隐
                } catch (error) {

                }
            }





        }

        //[4927] 20251125 lxy 封装移动端事件对话框
        function mobileEventDialog(mobileEvent, eventContent, confirmCallback, cancelCallback) {
            // 先检查是否已存在对话框，如果存在则先移除
            var existingDialog = ctl.ownerDocument.querySelector('.dc_mobile_event_dialog');
            var existingMask = ctl.ownerDocument.querySelector('.dc_mobile_event_dialog_mask');
            if (existingDialog) existingDialog.remove();
            if (existingMask) existingMask.remove();

            // 创建遮罩层
            var maskDiv = ctl.ownerDocument.createElement("div");
            maskDiv.className = "dc_mobile_event_dialog_mask";

            // 创建对话框
            var mobileEventDialog = ctl.ownerDocument.createElement("div");
            mobileEventDialog.className = "dc_mobile_event_dialog";
            mobileEventDialog.innerHTML = `
                <div class="dc_mobile_event_dialog_header">
                    <h3 class="dc_mobile_event_dialog_title">事件编辑</h3>
                    <button class="dc_mobile_event_dialog_close" title="关闭">×</button>
                </div>
                <div class="dc_mobile_event_dialog_content">
                    <div class="dc_mobile_event_dialog_tip">
                        this为转换后移动端组件本身，this.getFormRef().getEC('myEC')获取移动端渲染器的vue承载组件，可调用承载vue中的自定义方法
                    </div>
                    <div class="dc_mobile_event_dialog_editor_wrapper">
                        <textarea id="dc_mobile_event_editor" class="dc_mobile_event_dialog_editor" placeholder="请输入事件代码...">onCreated(){
    
}</textarea>
                    </div>
                </div>
                <div class="dc_mobile_event_dialog_footer">
                    <div class="dc_mobile_event_dialog_btn dc_mobile_event_dialog_btn_cancel">取消</div>
                    <div class="dc_mobile_event_dialog_btn dc_mobile_event_dialog_btn_confirm">保存</div>
                </div>
            `;

            // 添加到文档
            ctl.ownerDocument.body.appendChild(maskDiv);
            ctl.ownerDocument.body.appendChild(mobileEventDialog);

            // 设置事件内容
            jQuery(mobileEventDialog).find('#dc_mobile_event_editor').val(eventContent);


            // 关闭对话框的函数
            var closeDialog = function () {
                if (mobileEventDialog && mobileEventDialog.parentNode) {
                    mobileEventDialog.parentNode.removeChild(mobileEventDialog);
                }
                if (maskDiv && maskDiv.parentNode) {
                    maskDiv.parentNode.removeChild(maskDiv);
                }
            };

            // 绑定关闭按钮事件
            jQuery(mobileEventDialog).find('.dc_mobile_event_dialog_close').on('click', function () {
                closeDialog();
                cancelCallback && cancelCallback();
            });

            // 绑定遮罩层点击事件（点击遮罩层关闭对话框）
            jQuery(maskDiv).on('click', function (e) {
                if (e.target === maskDiv) {
                    closeDialog();
                    cancelCallback && cancelCallback();
                }
            });

            // 绑定保存按钮事件
            jQuery(mobileEventDialog).find('.dc_mobile_event_dialog_btn_confirm').on('click', function () {
                var editor = jQuery(mobileEventDialog).find('#dc_mobile_event_editor');
                var code = editor.val();
                closeDialog();
                confirmCallback && confirmCallback(code, mobileEvent);
            });

            // 绑定取消按钮事件
            jQuery(mobileEventDialog).find('.dc_mobile_event_dialog_btn_cancel').on('click', function () {
                closeDialog();
                cancelCallback && cancelCallback();
            });

            // 聚焦到编辑器
            setTimeout(function () {
                jQuery(mobileEventDialog).find('#dc_mobile_event_editor').focus();
            }, 100);
        }

        //移动端数据的收集
        function collectMobileData() {
            //属性
            var dcMobileConfigDom = dcTab5.querySelectorAll('[mobile-attr]');
            if (dcMobileConfigDom.length) {
                Array.from(dcMobileConfigDom).forEach(function (dcMobileConfigItem) {
                    var mobileAttr = dcMobileConfigItem.getAttribute('mobile-attr');
                    dcMobileConfig[mobileAttr] = dcMobileConfigItem.tagName === 'DIV'
                        ? dcMobileConfigItem.innerHTML
                        : dcMobileConfigItem.value;
                });
            }
            return dcMobileConfig;
        }


        function successFun() {

            let newOptions = {};
            var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
            var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
            var dcPanelBodyTab3 = jQuery(dc_dialogContainer).find("#dc_tab3");
            var dc_CopySource = jQuery(dc_dialogContainer).find('#dc_CopySource');

            // 获取输入域基本属性
            newOptions = GetOrChangeData(dcPanelBody);

            // 获取输入域校验属性
            newOptions['ValidateStyle'] = GetOrChangeData(dcPanelBodyTab3);

            //获取复制来源
            newOptions['CopySource'] = GetOrChangeData(dc_CopySource);

            // 获取输入域静态资源
            newOptions.Attributes = AttributesA;

            //获取输入域静态资源
            newOptions['ListItems'] = AttributesC && AttributesC.length ? AttributesC : null;

            //获取输入域格式类型tab2
            var InnerEditStyleCheck = jQuery(ctl).find('#dc_tab2 .dc_title>label>input[type="radio"]:checked');
            newOptions["InnerEditStyle"] = InnerEditStyleCheck.attr('attrid');

            //获取输入域的输出格式
            let Style = jQuery(ctl).find("#dc_DisplayFormat").val();
            let Format = jQuery(ctl).find("#dc_selectionRight").val();
            newOptions["DisplayFormat"] = { Style, Format };

            //获取输入域的校验类型
            var validateStyleCheck = jQuery(ctl).find('#dc_tab3 .dc_ValidateStyle_label input[type="radio"]:checked');
            newOptions.ValidateStyle["ValueType"] = validateStyleCheck.attr('attrid');

            if (newOptions.ValidateStyle && newOptions.ValidateStyle.ValueType === "DateTime") {

                //20240329 lixinyu 修复校验选择时间校验不设置时间,再次获取时间变成1980/1/1问题(DUWRITER5_0-2165)
                if (newOptions.ValidateStyle["DateTimeMaxValue"] === '') {
                    newOptions.ValidateStyle["DateTimeMaxValue"] = "0001/1/1 上午12:00:00";
                }
                if (newOptions.ValidateStyle["DateTimeMinValue"] === '') {
                    newOptions.ValidateStyle["DateTimeMinValue"] = "0001/1/1 上午12:00:00";
                }
            } else if (newOptions.ValidateStyle && newOptions.ValidateStyle.ValueType === "Text") {
                newOptions.ValidateStyle["CheckMaxValue"] = true;
                newOptions.ValidateStyle["CheckMinValue"] = true;
            } else if (newOptions.ValidateStyle && newOptions.ValidateStyle.ValueType === "Numeric") {
                var DCNumericInteger = ctl.ownerDocument.getElementById('DCNumericInteger');
                if (DCNumericInteger.checked) {
                    newOptions.ValidateStyle.ValueType = 'Integer';
                }

                var DC_ValiNumber_CheckMaxValue = ctl.ownerDocument.getElementById('DC_ValiNumber_CheckMaxValue');
                var DC_ValiNumber_CheckMinValue = ctl.ownerDocument.getElementById('DC_ValiNumber_CheckMinValue');
                newOptions['ValidateStyle']['CheckMaxValue'] = DC_ValiNumber_CheckMaxValue.checked;
                newOptions['ValidateStyle']['CheckMinValue'] = DC_ValiNumber_CheckMinValue.checked;
            }
            // 获取输入域的数据源属性
            let { BindingPath, BindingPathForText, Datasource, ProcessState } = newOptions;
            newOptions["ValueBinding"] = { BindingPath, BindingPathForText, Datasource, ProcessState };

            // 获取静态资源弹框的字典来源
            newOptions["InnerListSourceName"] = InnerListSourceName;


            //激活模式
            newOptions["EditorActiveMode"] = jQuery(ctl).find("#dc_EditorActiveModeButton").text();

            //删除外层数据源无用数据
            newOptions["BindingPath"] && delete newOptions["BindingPath"];
            newOptions["BindingPathForText"] && delete newOptions["BindingPathForText"];
            newOptions["Datasource"] && delete newOptions["Datasource"];
            newOptions["ProcessState"] && delete newOptions["ProcessState"];

            //20241011 lxy 颜色属性取值
            var TextColor = jQuery(ctl).find("#dc_TextColor_box").attr("data-value") || '';
            var BackgroundTextColor = jQuery(ctl).find("#dc_BackgroundTextColor_box").attr("data-value") || '';
            var BackgroundColorString = jQuery(ctl).find("#dc_BackgroundColorString_box").attr("data-value") || '';
            newOptions['TextColor'] = TextColor;
            newOptions['BackgroundTextColor'] = BackgroundTextColor;
            newOptions['Style'] = newOptions['Style'] ? {
                ...newOptions['Style'],
                BackgroundColorString
            } : {
                BackgroundColorString
            };

            //[DUWRITER5_0-3748] 20241025 lxy 新增属性表达式功能
            newOptions['PropertyExpressions'] = {};
            for (var key in propertyExpressionObject) {
                if (propertyExpressionObject[key] !== '') {
                    newOptions['PropertyExpressions'][key] = propertyExpressionObject[key];
                }
            }
            //计算表达式
            if (newOptions && newOptions.ValueExpression && newOptions.ValueExpression.trim() !== '') {
                newOptions['PropertyExpressions']['FormulaValue'] = newOptions.ValueExpression;
            }

            //可见性表达式
            if (newOptions && newOptions.VisibleExpression && newOptions.VisibleExpression.trim() !== '') {
                newOptions['PropertyExpressions']['Visible'] = newOptions.VisibleExpression;
            }

            //校验表达式
            if (newOptions && newOptions.ValidateStyleExpression && newOptions.ValidateStyleExpression.trim() !== '') {
                newOptions['PropertyExpressions']['ValidateStyle'] = newOptions.ValidateStyleExpression;
            }

            //项目符号分隔符转换
            if (newOptions.ListValueSeparatorChar == "换行" || newOptions.ListValueSeparatorChar == "\n") {
                newOptions.ListValueSeparatorChar = '\\n';
            }

            //[4927] 20251126 lxy 新增移动端配置
            if (IsShowMobileDeviceAttributes === true) {
                var dc_mobile_config = collectMobileData();
                newOptions['Attributes']['dc_mobile_config'] = JSON.stringify(dc_mobile_config);
            }
            console.log("newOptions", newOptions);
            // [DUWRITER5_0-3613] 20240919 lxy 新增插入元素确定后，返回新插入的元素属性
            var insertResult = null;
            if (isInsertMode == true) {
                insertResult = ctl.DCExecuteCommand("InsertInputField", false, newOptions);
            } else {
                ctl.SetElementProperties(ctl.CurrentInputField(), newOptions);
            }
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentInputField());
                ctl.EventDialogChangeProperties(insertResult ? insertResult : changedOptions);
            };

        }
    },


    /**
       * 属性表达式公共弹框
       * @param options 属性表达式属性
       * @param ctl 编辑器元素
       */
    PropertyExpressionsDialog: function (propertyExpressions, ctl, callBack) {
        var PropertyExpressionsTableHtml = "";
        Object.keys(propertyExpressions).forEach(key => {
            PropertyExpressionsTableHtml += `
                <div class="dc_PropertyExpressionsTable_item">
                    <span class="dc_PropertyExpressionsTable_item_left" title="${key}">${key}</span>
                    <input placeholder="请输入表达式内容" type="text" class="dc_PropertyExpressionsTable_input" propertykey="${key}" value="${propertyExpressions[key]}" />
                </div>
            `;
        });
        var PropertyExpressionsDialog = ctl.ownerDocument.createElement("div");
        PropertyExpressionsDialog.className = "dc_PropertyExpressionsBox";
        PropertyExpressionsDialog.innerHTML = `
            <div class="dc_PropertyExpressionsBox_top">
                <span class="dc_PropertyExpressionsBox_title">属性表达式</span>
                <span class="dcTool-close">✖</span>
            </div>
            <div class="dc_PropertyExpressionsBox_center">
                <div class="dc_PropertyExpressionsTable">
                    <div class="dc_PropertyExpressionsTable_item_header">
                        <span class="dc_PropertyExpressionsTable_item_left">属性名称</span>
                        <span class="dc_PropertyExpressionsTable_input">表达式</span>
                    </div>
                    ${PropertyExpressionsTableHtml}
                </div>
            </div>
            <div class="dc_PropertyExpressionsBox_bottom">
                <div class="dc_PropertyExpressionsBox_button" id="dc_PropertyExpressionsBox_bottom_cancel">取消</div>
                <div class="dc_PropertyExpressionsBox_button" id="dc_PropertyExpressionsBox_bottom_confirm">确认</div>
            </div>
        `;
        ctl.appendChild(PropertyExpressionsDialog);
        // 关闭
        jQuery(PropertyExpressionsDialog)
            .find(".dcTool-close")
            .click(function () {
                jQuery(PropertyExpressionsDialog).remove();
            });
        // 取消
        jQuery(PropertyExpressionsDialog)
            .find("#dc_PropertyExpressionsBox_bottom_cancel")
            .click(function () {
                jQuery(PropertyExpressionsDialog).remove();
            });

        // 确认
        jQuery(PropertyExpressionsDialog)
            .find("#dc_PropertyExpressionsBox_bottom_confirm")
            .click(function () {
                //修改后的参数
                var changedProperty = {};
                Object.keys(propertyExpressions).forEach(key => {
                    var input = jQuery(PropertyExpressionsDialog).find(`.dc_PropertyExpressionsTable_input[propertykey="${key}"]`);
                    var inputvalue = input.val();
                    changedProperty[key] = inputvalue;
                });
                callBack && callBack(changedProperty);
                jQuery(PropertyExpressionsDialog).remove();
            });

        // console.log("PropertyExpressionsDialog", PropertyExpressionsDialog);
    },





    // ======医学表达式-start======




    /**
     * 创建胎心图值对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    FetalHeartDialog: function (options, ctl, isInsertMode, ele) {
        if (options == null) {
            return false;
        }

        let arr = this.stringToObject(options.Values);
        var FetalHeartHtml = `
        <table width="100%" id="dc_fetal-heart-table" cellspacing="0">
            <tr>
                <td rowspan="2" class="dc_fetal-heart-table-line-td" />
                <td align="center" class="dc_fetal-heart-table-input">
                    <input  type="text"  data-text="Value1" />
                </td>
                <td rowspan="2" class="dc_fetal-heart-table-border-right" />
                <td rowspan="2" class="dc_fetal-heart-table-border-left" />
                <td align="center"  class="dc_fetal-heart-table-input">
                    <input  type="text"  data-text="Value2" />
                </td>
                <td rowspan="2" class="dc_fetal-heart-table-border-bottom" />
            </tr>
            <tr>
                <td rowspan="2" class="dc_fetal-heart-table-input dc_table-input-border-top" align="center">
                    <input  type="text" data-text="Value3" />
                </td>
                <td rowspan="2" class="dc_fetal-heart-table-input dc_table-input-border-top" align="center">
                    <input  type="text" data-text="Value4" />
                </td>
            </tr>
            <tr>
                <td rowspan="2" class="dc_fetal-heart-table-td-border" >
                </td>
                <td rowspan="2" class="dc_fetal-heart-table-border-top-right" />
                <td rowspan="2" class="dc_fetal-heart-table-border-top-left" />
                <td rowspan="2" class="dc_fetal-heart-table-td-border" />
            </tr>
            <tr>
                <td align="center" class="dc_fetal-heart-table-input" >
                    <input  type="text" data-text="Value5" />
                </td>
                <td align="center" class="dc_fetal-heart-table-input">
                    <input  type="text" data-text="Value6" />
                </td>
            </tr>
        </table>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;

        var dialogOptions = {
            title: "请输入胎心值",
            bodyHeight: 'auto',
            bodyClass: "FetalHeartElement",
            bodyHtml: FetalHeartHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var opts = {};
        let that = this;
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建标尺对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    PainIndexDialog: function (options, ctl, isInsertMode, ele) {
        // if (!options || typeof (options) != "object") {
        //     options = ctl.getFontObject();
        // }
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        for (var i in arr) {
            arr[i] = arr[i] / 10;
        }
        var PainIndexHtml = `
            数字（0-10）：
            <input type="number" data-text="Value1"/>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "标尺（请输入0到10之间的数字）",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 300,
            bodyClass: "dc_PainIndexElement",
            bodyHtml: PainIndexHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);


        //标尺公式只允许输入一位小数
        dcPanelBody.find("[data-text='Value1']").on("input", function (e) {
            var _value = jQuery(this).val();
            //判断小数点后有几位数字
            if (_value.indexOf('.') > -1) {
                var _len = _value.split('.')[1].length;
                if (_len >= 1) {
                    //只保留一位小数
                    var _newvalue = _value.substring(0, _value.indexOf('.') + 2);
                    jQuery(this).val(_newvalue);
                }
            }

        });


        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            _data.Value1 = _data.Value1 * 10;
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 创建眼球突出度
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */

    EyeballProtrusionDialog: function (options, ctl, isInsertMode, ele) {
        let arr = this.stringToObject(options.Values);
        var EyeballProtrusionHtml = `
        <div class="dc_EyeballProtrusionBox"> 
            <div class="dc_EyeballProtrusionContainerLeft">
                <input  data-text="Value1"  class="dc_ValueInput" type="number" />
                <span>mm</span>
            </div>
            <div class="dc_EyeballProtrusionContainerCenter">
                <div class="dc_EyeballProtrusionContainerCenter_value2" >
                    <input  data-text="Value2" class="dc_ValueInput" type="number" />
                    <span>mm</span>
                </div>
                <div class="LineBox">
                    <p class="dc_line dc_LineLeftTop"></p>
                    <p class="dc_line dc_LineLeftBottom"></p>
                    <p class="dc_line dc_LineCenter"></p>
                    <p class="dc_line dc_LineRightTop"></p>
                    <p class="dc_line dc_LineRightBottom"></p>
                </div>
            </div>
            <div class="dc_EyeballProtrusionContainerRight">
                <input  data-text="Value3" class="dc_ValueInput" type="number" />
                <span>mm</span>
            </div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "插入眼球突出度",
            bodyHeight: 'auto',
            dialogContainerBodyWidth: 520,
            bodyClass: "EyeballProtrusion",
            bodyHtml: EyeballProtrusionHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        let that = this;
        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options);
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 创建斜视符号
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    SquintSymbolDialog: function (options, ctl, isInsertMode, ele) {
        let { Value1 } = this.stringToObject(options.Values);
        var SquintSymbolHtml = `<div class="dc_SquintSymbolBox"> 
                <div class="dc_SquintSymbolLeftContainer">
                    <div class="dc_ShowView">
                        <p  class="dc_LeftLineText dc_LeftLine"></p>
                        <p  class="dc_RightLineText dc_RightLine"></p>
                        <p class="dc_CenterRound"></p>
                        <p class="dc_LeftLineText" id="dc_LeftLineText_L" >L</p>
                        <p class="dc_RightLineText" id="dc_LeftLineText_R"  >R</p>
                    </div>
                </div>
                <div class="dc_Box">
                    <h6 class="dc_title">类型</h6>
                    <form>
                        <label class="dc_RadioLabel">
                            <input type="radio" id="L" />
                            <span>L</span>
                        </label>
                        <label class="dc_RadioLabel">
                            <input type="radio" id="R" />
                            <span>R</span>
                        </label>
                        <label class="dc_RadioLabel">
                            <input type="radio" id="LR" />
                            <span>LR</span>
                        </label>
                    </form>
                </div>
            </div>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>`;
        var dialogOptions = {
            title: "插入斜视符号",
            bodyHeight: "auto",
            bodyClass: " SquintSymbol",
            bodyHtml: SquintSymbolHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        if (Value1) {
            dcPanelBody
                .find(".dc_RadioLabel>input[type=radio]")
                .attr("checked", false);
            dcPanelBody.find(`#${Value1}`).attr("checked", true);
            changeShowView(Value1);
        }
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        dcPanelBody.find(".dc_RadioLabel>input[type=radio]").change(function (e) {
            dcPanelBody
                .find(".dc_RadioLabel>input[type=radio]")
                .attr("checked", false);
            this.checked = true;
            changeShowView(this.id);
        });
        function changeShowView(value) {
            switch (value) {
                case "L":
                    dcPanelBody.find(".dc_LeftLineText").show();
                    dcPanelBody.find(".dc_RightLineText").hide();
                    break;
                case "R":
                    dcPanelBody.find(".dc_LeftLineText").hide();
                    dcPanelBody.find(".dc_RightLineText").show();
                    break;
                case "LR":
                    dcPanelBody.find(".dc_LeftLineText").show();
                    dcPanelBody.find(".dc_RightLineText").show();
                    break;
            }
        }

        function successFun() {
            let radioArr = dcPanelBody.find(".dc_RadioLabel>input[type=radio]");
            for (var i = 0; i < radioArr.length; i++) {
                if (radioArr[i].checked) {
                    options["Values"] = `Value1:${radioArr[i].id};`;
                }
            }
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 创建输入分数值对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    FractionDialog: function (options, ctl, isInsertMode, ele) {
        // if (!options || typeof (options) != "object") {
        //     options = ctl.getFontObject();
        // }
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var FractionHtml = `
            <table cellspacing="10">
                <tr class="dc_Fraction_table_tr">
                    <td>
                        A值<input class="dc_Fraction_table_input" type="text" data-text="Value1"/>
                    </td>
                    <td rowspan="2" class="dc_Fraction_table_td" >
                    <strong>/</strong>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr class="dc_Fraction_table_tr" >
                    <td>
                    </td>
                    <td></td>
                    <td>
                        B值<input class="dc_Fraction_table_input" type="text" data-text="Value2"  />
                    </td>
                </tr>
            </table>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "请输入分数值",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 364,
            bodyClass: "dc_FractionElement",
            bodyHtml: FractionHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建输入月经史值对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    FourValuesDialog: function (options, ctl, isInsertMode, ele) {
        // if (!options || typeof (options) != "object") {
        //     options = ctl.getFontObject();
        // }
        if (options == null) {
            return false;
        }
        //[DUWRITER5_0-5057] 20260105 lxy 不使用日期格式
        let FourValuesDoNotUseDateFormats = ctl.getAttribute("FourValuesDoNotUseDateFormats") || false;
        FourValuesDoNotUseDateFormats = FourValuesDoNotUseDateFormats === "true" || FourValuesDoNotUseDateFormats === true;


        let arr = this.stringToObject(options.Values);
        var FourValuesHtml = `
            <table cellspacing="0">
                <tr class="dc_FourValues_table_tr1" >
                    <td rowspan="2" class="dc_FourValues_table_td1_value1" >
                        初潮年龄(岁)
                        <br />
                        <input type="text" id="dc_FourValues_table_td2_value1_type_text" placeholder="初潮年龄(岁)" data-text="Value1" />
                        <input type="date" id="dc_FourValues_table_td2_value1_type_Time"  />
                        <div class="dc_FourValues_table_td2_value_type_checkbox">
                            <input type="checkbox" id="dc_FourValues_table_td2_value1_checkbox" />
                            <span>是否使用日期</span>
                        </div>
                    </td>
                    <td class="dc_FourValues_table_td1_value_border" >经期(天)<br /><input type="text" placeholder="经期(天)"  data-text="Value2" /></td>
                    <td class="dc_FourValues_table_td2_value" rowspan="2" >末次月经/<br />绝经年龄(岁)
                        <br />
                        <input id="dc_FourValues_table_td2_value4_type_text" type="text" placeholder="末次月经/绝经年龄(岁)" data-text="Value4"/>
                        <input type="date" id="dc_FourValues_table_td2_value4_type_Time"  />
                        <div class="dc_FourValues_table_td2_value_type_checkbox" >
                            <input type="checkbox" id="dc_FourValues_table_td2_value4_checkbox" />
                            <span>是否使用日期</span>
                        </div>
                    </td>
                </tr>
                <tr class="dc_FourValues_table_tr2">
                    <td class="dc_FourValues_table_tr2_td">周期(天)<br /><input type="text" placeholder="周期(天)" data-text="Value3"/></td>
                </tr>      
            </table>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "请输入月经史值",
            bodyHeight: 'auto',
            dialogContainerBodyWidth: 500,
            bodyClass: "dc_FourValuesElement",
            bodyHtml: FourValuesHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function handleDateInput(value, timeInputSelector, textInputSelector, checkboxSelector, dataText) {
            var timeInput = dcPanelBody.find(timeInputSelector);
            var textInput = dcPanelBody.find(textInputSelector);

            if (value && value.length && isDate(value) && (FourValuesDoNotUseDateFormats !== true)) {
                timeInput.val(value.replace(/\//g, '-'));
                timeInput.attr('data-text', dataText);
                timeInput.css('display', 'inline-block');

                textInput.val('');
                textInput.css('display', 'none');
                textInput.removeAttr('data-text');
                dcPanelBody.find(checkboxSelector).prop('checked', true);
            }

            dcPanelBody.find(checkboxSelector).change(function (e) {
                var _check = e.target.checked;
                // 更新 data-text 属性
                textInput.removeAttr('data-text');
                timeInput.removeAttr('data-text');

                if (_check) {
                    timeInput.attr('data-text', dataText);
                    timeInput.css('display', 'inline-block');
                    textInput.css('display', 'none');
                } else {
                    textInput.attr('data-text', dataText);
                    textInput.css('display', 'inline-block');
                    timeInput.css('display', 'none');
                }
            });
        }


        // 处理opts.Value1
        handleDateInput(opts.Value1,
            '#dc_FourValues_table_td2_value1_type_Time',
            '#dc_FourValues_table_td2_value1_type_text',
            '#dc_FourValues_table_td2_value1_checkbox', "Value1");

        // 处理opts.Value4
        handleDateInput(opts.Value4,
            '#dc_FourValues_table_td2_value4_type_Time',
            '#dc_FourValues_table_td2_value4_type_text',
            '#dc_FourValues_table_td2_value4_checkbox', "Value4");



        //判断字符串是否为日期格式
        function isDate(str) {
            // 定义正则表达式模式
            const regex = /^\d{4}[-/]\d{2}[-/]\d{2}$/;
            // 检查字符串是否匹配模式
            if (!regex.test(str)) return false;

            // 提取日期部分
            const [year, month, day] = str.split(/[-/]/).map(Number);

            // 检查日期是否有效
            const date = new Date(year, month - 1, day);
            return date.getFullYear() === year && date.getMonth() + 1 === month && date.getDate() === day;
        }


        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            if (FourValuesDoNotUseDateFormats !== true) {
                for (var i in _data) {
                    if ((i == 'Value1' || i == 'Value4') && isDate(_data[i])) {
                        _data[i] = _data[i].replace(/-/g, '/');
                    }
                }
            }
            options.Values = that.ObjectToString(_data);

            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建输入月经史值2对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    FourValues1Dialog: function (options, ctl, isInsertMode, ele) {
        // if (!options || typeof (options) != "object") {
        //     options = ctl.getFontObject();
        // }
        if (options == null) {
            return false;
        }

        let arr = this.stringToObject(options.Values);
        var FourValues1Html = `
        <table border="0" cellspacing="0">
            <tbody>
                <tr>
                    <td class="dc_FourValues_table_tr1_td1 dc_FourValues_table_border_right">初潮年龄(岁)</td>
                    <td class="dc_FourValues_table_border_left" >经期(天)</td>
                </tr>
                <tr>
                    <td class="dc_FourValues_table_border_right dc_FourValues_table_border_bottom">
                        <input type="text" data-text="Value1" ></td>
                    <td
                        class="dc_FourValues_table_border_left dc_FourValues_table_border_bottom">
                        <input type="text" data-text="Value2"></td>
                </tr>
                <tr>
                    <td  class="dc_FourValues_table_border_right dc_FourValues_table_border_right_top">末次月经/绝经年龄(岁)</td>
                    <td class="dc_FourValues_table_border_left dc_FourValues_table_border_left_top">周期(天)</td>
                </tr>
                <tr>
                    <td class="dc_FourValues_table_border_right" >
                        <input type="text" data-text="Value3" >
                        </td>
                    <td class="dc_FourValues_table_border_left" >
                        <input type="text"  data-text="Value4" >
                        </td>
                </tr>
            </tbody>
        </table>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "请输入月经史值",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 500,
            bodyClass: "dc_FourValues1Element",
            bodyHtml: FourValues1Html,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
    * 创建龋齿公式对话框
    * @param options 医学表达式属性
    * @param ctl 编辑器元素
    * @param isInsertMode 是否是插入模式
    */
    DentalCariesDialog: function (options, ctl, isInsertMode, ele) {
        if (options == null) {
            return false;
        }

        let arr = this.stringToObject(options.Values);
        var FourValues1Html = `
        <table border="0" cellspacing="0">
            <tbody>
                <tr>
                    <td class="dc_FourValues_table_tr1_td1 dc_FourValues_table_border_right">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="dc_FourValues_table_border_left" >&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td class="dc_FourValues_table_border_right dc_FourValues_table_border_bottom">
                        <input type="text" data-text="Value1" ></td>
                    <td
                        class="dc_FourValues_table_border_left dc_FourValues_table_border_bottom">
                        <input type="text" data-text="Value2"></td>
                </tr>
                <tr>
                    <td  class="dc_FourValues_table_border_right dc_FourValues_table_border_right_top">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="dc_FourValues_table_border_left dc_FourValues_table_border_left_top">&nbsp;&nbsp;&nbsp;&nbsp;</td>
                </tr>
                <tr>
                    <td class="dc_FourValues_table_border_right" >
                        <input type="text" data-text="Value3" >
                        </td>
                    <td class="dc_FourValues_table_border_left" >
                        <input type="text"  data-text="Value4" >
                        </td>
                </tr>
            </tbody>
        </table>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "请输入龋齿值",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 500,
            bodyClass: "dc_FourValues1Element",
            bodyHtml: FourValues1Html,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 创建输入月经史值2对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    FourValues2Dialog: function (options, ctl, isInsertMode, ele) {
        // if (!options || typeof (options) != "object") {
        //     options = ctl.getFontObject();
        // }
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var FourValues2Html = `
        <table >
            <tr>
                <td></td>
                <td align="center" class="dc_FourValues_table_td" >
                 <label>
                    经期（天）：
                    <input data-text="Value2" class="dc_FourValues_table_input" type="text" autocomplete="off"/></td>
                </label>
                    <td></td>
            </tr>
            <tr>
                <td align="center" class="dc_FourValues_table_td">
                <label>
                    初潮年龄(岁)：
                    <input  data-text="Value1"   class="dc_FourValues_table_input" type="text" autocomplete="off"/></td>
                 </label>
                    <td></td>
                <td align="center" class="dc_FourValues_table_td">

                 <label>
                    周期（天）：
                    <input data-text="Value3"  class="dc_FourValues_table_input" type="text" autocomplete="off"/>
                 </label>
                    
                    </td>
            </tr>
            <tr>
                <td></td>
                <td align="center" class="dc_FourValues_table_td">
                    <label>
                    末次月经/绝经年龄(岁)：
                    <input data-text="Value4"  class="dc_FourValues_table_input" type="text"  autocomplete="off"/></td>
                 </label>
               
                    <td></td>
            </tr>
        </table>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        <div class="dc_LeftLine"></div>
        <div class="dc_RightLine"></div>
        `;
        var dialogOptions = {
            title: "请输入月经史值",
            bodyHeight: "auto",
            bodyClass: "dc_FourValues2Element",
            bodyHtml: FourValues2Html,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建输入月经史值4对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    ThreeValuesDialog: function (options, ctl, isInsertMode, ele) {
        // if (!options || typeof (options) != "object") {
        //     options = ctl.getFontObject();
        // }
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var ThreeValuesHtml = `
            <table cellspacing="0">
                <tr >
                    <td rowspan="2">
                        A值<input type="text" data-text="Value1"/>
                    </td>
                    <td rowspan="2" class="dc_FourValues_table_value1_td">
                    <strong>/</strong>
                    </td>
                    <td class="dc_FourValues_table_value2_td">
                        B值<br />
                    <input type="text" data-text="Value2"/>
                    </td>
                </tr>
                <tr >
                    <td class="dc_FourValues_table_value1_td3">
                        C值<br />
                    <input type="text"  data-text="Value3"/>
                    </td>
                </tr>
            </table>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>`;
        var dialogOptions = {
            title: "请输入月经史值",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 370,
            bodyClass: "dc_ThreeValuesElement",
            bodyHtml: ThreeValuesHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建输入瞳孔图值对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    PupilDialog: function (options, ctl, isInsertMode, ele) {
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var PupilHtml = `
            <table cellspacing="5">
                <tr>
                    <td><input type="text" data-text="Value1" /></td>
                    <td></td>
                    <td><input type="text" data-text="Value2"/></td>
                </tr>
                <tr>
                    <td><input type="text" data-text="Value3"/></td>
                    <td><input type="text" data-text="Value4"/></td>
                    <td><input type="text" data-text="Value5"/></td>
                </tr>
                <tr>
                    <td><input type="text" data-text="Value6"/></td>
                    <td></td>
                    <td><input type="text" data-text="Value7"/></td>
                </tr>       
            </table>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "请输入瞳孔图值",
            dialogContainerBodyWidth: 410,
            bodyHeight: "auto",
            bodyClass: "PupilElement",
            bodyHtml: PupilHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
        * 创建输入视野图对话框
        * @param options 医学表达式属性
        * @param ctl 编辑器元素
        * @param isInsertMode 是否是插入模式
        */
    PerimetricDialog: function (options, ctl, isInsertMode, ele) {
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var PerimetricHtml = `
        <table >
            <tr>
                <td></td>
                <td align="center" class="dc_Perimetric_table_td">
                 <label>
                    <div></div>
                    <input data-text="Value2" type="text"  autocomplete="off"/></td>
                </label>
                    <td></td>
            </tr>
            <tr>
                <td align="center" class="dc_Perimetric_table_td" >
                <label>
                    <input  data-text="Value1"  type="text" autocomplete="off"/></td>
                 </label>
                    <td></td>
                <td align="center" class="dc_Perimetric_table_td">

                 <label>
                    <input data-text="Value3" type="text"   autocomplete="off"/>
                 </label>
                    
                    </td>
            </tr>
            <tr>
                <td></td>
                <td align="center" class="dc_Perimetric_table_td">
                    <label>
                    <input data-text="Value4" type="text"  autocomplete="off"/></td>
                 </label>
               
                    <td></td>
            </tr>
        </table>
        <div class="dc_LeftLine"></div>
        <div class="dc_RightLine"></div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "请输入视野图值",
            bodyHeight: 240,
            bodyClass: "dc_PerimetricDom",
            bodyHtml: PerimetricHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options, '==================');
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 创建输入光定位值对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    LightPositioningDialog: function (options, ctl, isInsertMode, ele) {
        if (options == null) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var LightPositioningHtml = `
           <table  cellspacing="5">
                <tr>
                    <td><input type="text" data-text="Value1"/></td>
                    <td><input type="text" data-text="Value2"/></td>
                    <td><input type="text" data-text="Value3"/></td>
                </tr>
                <tr>
                    <td><input type="text" data-text="Value4"/></td>
                    <td><input type="text" data-text="Value5"td>
                    <td><input type="text" data-text="Value6"/></td>
                </tr>
                <tr>
                    <td><input type="text" data-text="Value7"/></td>
                    <td><input type="text" data-text="Value8"/></td>
                    <td><input type="text" data-text="Value9"/></td>
                </tr>       
            </table>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "请输入光定位值",
            dialogContainerBodyWidth: 410,
            bodyHeight: "auto",
            bodyClass: "dc_LightPositioningElement",
            bodyHtml: LightPositioningHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(arr, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            options.Values = that.ObjectToString(_data);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 创建恒牙牙位图对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    PermanentTeethBitmapDialog: function (options, ctl, isInsertMode, ele) {
        // console.log(options, "=======options");
        if (options == null) {
            return false;
        }
        let arr = options.Values && this.stringToObject(options.Values);
        var PermanentTeethBitmapDialogHtml = `
        <div unselectable="on">
            <!--Table结构，cellspacing控制中间空行 -->
            <div>
                <table cellspacing="0">
                    <tr class="dc_PermanentTeethBitmap_tr1" >
                        <td><span class="dc_PermanentTeethBitmap_span1">上颌</span></td>
                    </tr>
                    <tr class="dc_PermanentTeethBitmap_tr2">
                        <td><span class="dc_PermanentTeethBitmap_span2">牙<br />面</span></td>
                    </tr>
                    <tr class="dc_PermanentTeethBitmap_tr3">
                        <td><span>第<br />三<br />磨<br />牙</span></td>
                        <td><span>第<br />二<br />磨<br />牙</span></td>
                        <td><span>第<br />一<br />磨<br />牙</span></td>
                        <td><span>第<br />二<br />前<br />磨<br />牙</span></td>
                        <td><span>第<br />一<br />前<br />磨<br />牙</span></td>
                        <td><span>尖<br />牙</span></td>
                        <td><span>侧<br />切<br />牙</span>
                        </td>
                        <td><span>中<br />切<br />牙</span>
                        </td>
                        <td><span>中<br />切<br />牙</span>
                        </td>
                        <td><span>侧<br />切<br />牙</span>
                        </td>
                        <td><span>尖<br />牙</span></td>
                        <td><span>第<br />一<br />前<br />磨<br />牙</span></td>
                        <td><span>第<br />二<br />前<br />磨<br />牙</span></td>
                        <td><span>第<br />一<br />磨<br />牙</span></td>
                        <td><span>第<br />二<br />磨<br />牙</span></td>
                        <td><span>第<br />三<br />磨<br />牙</span></td>
                    </tr>
                    <tr class="dc_PermanentTeethBitmap_tr4"  id="dc_P-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_tr4"  id="dc_L-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_tr4"  id="dc_B-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_tr4"  id="dc_D-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_tr4"  id="dc_O-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_tr4"  id="dc_M-permanent-tooth"></tr>
                </table>
            </div>
            <hr class="dc_PermanentTeethBitmap_hr" />
            <!--Table结构，cellspacing控制中间空行 -->
            <div>
                <table class="dc_PermanentTeethBitmap_table2"  cellspacing="0">
                    <tr class="dc_PermanentTeethBitmap_table2_tr1">
                        <td><span >右</span></td>
                    </tr>
                    <tr class="dc_PermanentTeethBitmap_table2_tr2">
                        <td><span>左</span></td>
                    </tr>
                    <tr class="dc_PermanentTeethBitmap_table2_tr3" id="dc_valueNumberBox1"/>
                    <tr class="dc_PermanentTeethBitmap_table2_tr4" id="dc_valueNumberBox2"/>
                </table>
            </div>
            <hr class="dc_PermanentTeethBitmap_hr"/>
            <!--Table结构，cellspacing控制中间空行 -->
            <div>
                <table class="dc_PermanentTeethBitmap_table3"  cellspacing="0">
                    <tr class="dc_PermanentTeethBitmap_table3_tr1">
                        <td><span>牙<br />面</span></td>
                    </tr>
                    <tr class="dc_PermanentTeethBitmap_table3_tr"  id="dc_M-bottom-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_table3_tr"  id="dc_O-bottom-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_table3_tr"  id="dc_D-bottom-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_table3_tr"  id="dc_B-bottom-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_table3_tr"  id="dc_L-bottom-permanent-tooth"></tr>
                    <tr class="dc_PermanentTeethBitmap_table3_tr"  id="dc_P-bottom-permanent-tooth"></tr>
                </table>
            </div>
            <center class="dc_PermanentTeethBitmap_center">
                <span>下颌</span>
            </center>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "恒牙牙位图",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 800,
            bodyClass: "dc_PermanentTeethBitmapElement",
            bodyHtml: PermanentTeethBitmapDialogHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let nameList = NAMELIST;
        let idTypeList = IDTYPELIST;
        let idList = IDLIST;
        let PermanentTeethTop = PERMANENTTEETHTOP;
        let PermanentTeethBottom = PERMANENTTEETHBOTTOM;
        let PermanentTeethtopList = [...PERMANENTTEETHTOP, ...PERMANENTTEETHBOTTOM];
        PermanentTeethtopList.filter((item) => {
            this.PermanentToothPosition(
                item.idPrefix,
                item.parentId,
                item.teethKey,
                item.isTop,
                ctl
            );
        });
        this.PermanentToothValueNumber("#dc_valueNumberBox1", 0, ctl);
        this.PermanentToothValueNumber("#dc_valueNumberBox2", 16, ctl);
        SetValues(arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        dcPanelBody.find("td>input.inp").click(function () {
            if (this.getAttribute("dccheck") == "true") {
                for (var n = 1; n < 33; n++) {
                    if (this.name == "a" + n + "") {
                        this.style.cssText = `width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color:${nameList.includes(this.name) ? "#fff" : "#d7e4f2"
                            } `;
                        this.setAttribute("dccheck", "false");
                    } else if (this.getAttribute("id") == "Value" + n + "") {
                        idTypeList.filter((item) => {
                            ctl.ownerDocument
                                .getElementById(item + n + "")
                                .setAttribute("dccheck", "false");
                            ctl.ownerDocument.getElementById(
                                item + n + ""
                            ).style.cssText = `width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: ${idList.includes(this.getAttribute("id")) ? "#fff;" : "#d7e4f2;"
                            }`;
                        });
                    } else {
                    }
                }
            } else {
                for (var n = 1; n < 33; n++) {
                    if (this.name == "a" + n + "") {
                        ctl.ownerDocument.getElementById("Value" + n + "").style.cssText =
                            "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                        ctl.ownerDocument
                            .getElementById("Value" + n + "")
                            .setAttribute("dccheck", "true");
                    } else {
                        this.style.cssText =
                            "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                        this.setAttribute("dccheck", "true");
                    }
                }
            }
        });
        function successFun() {
            let newArr = GetCurrentDatas();
            let str = "";
            newArr.filter((item, index) => {
                str += `Value${index}:${item};`;
            });
            options.Values = str;
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
        function GetCurrentDatas() {
            var jsonObj = new Array();
            for (var n = 0; n < 32; n++) {
                var vall = "";
                var i = n + 1;
                if (
                    ctl.ownerDocument
                        .getElementById("Value" + i + "")
                        .getAttribute("dccheck") == "true"
                ) {
                    vall = ctl.ownerDocument.getElementById("Value" + i + "").value;
                    //从下标1开始计算
                    for (var j = 1; j < idTypeList.length; j++) {
                        if (
                            ctl.ownerDocument
                                .getElementById(idTypeList[j] + i + "")
                                .getAttribute("dccheck") == "true"
                        ) {
                            vall += ctl.ownerDocument.getElementById(
                                idTypeList[j] + i + ""
                            ).value;
                        }
                    }
                    jsonObj[n + 1] = vall;
                } else {
                    jsonObj[n + 1] = "";
                }
            }
            return jsonObj;
        }
        function SetValues(values) {
            //[DUWRITER5_0-3772] 20241028 lxy 修复恒牙牙位图设置值时，不能正确显示值的bug
            var ValueArr = values != null ? Object.keys(values) : [];
            for (var n = 0; n <= 32; n++) {
                for (var j = 0; j < ValueArr.length; j++) {
                    //当值存在时，设置值
                    if (values[ValueArr[j]] && ValueArr[j] == "Value" + (n + 1)) {
                        var value = values[ValueArr[j]];
                        var id = "Value" + (n + 1);
                        ctl.ownerDocument.getElementById(id).style.cssText =
                            "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                        ctl.ownerDocument.getElementById(id).setAttribute("dccheck", "true");
                        (n <= 15 ? PermanentTeethTop : PermanentTeethBottom).filter(
                            (item) => {
                                if (value.indexOf(item.teethKey) >= 0) {
                                    ctl.ownerDocument.getElementById(
                                        item.idPrefix + (n + 1)
                                    ).style.cssText =
                                        "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                                    ctl.ownerDocument
                                        .getElementById(item.idPrefix + (n + 1))
                                        .setAttribute("dccheck", "true");
                                }
                            }
                        );
                    }
                }
            }
        }
    },

    /**
     * 创建乳牙牙位图对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    DeciduousTeechDialog: function (options, ctl, isInsertMode, ele) {
        if (options == null) {
            return false;
        }
        let arr = options.Values && this.stringToObject(options.Values);
        var DeciduousTeechHtml = `<div unselectable="on">
                <!--Table结构，cellspacing控制中间空行 -->
                <div>
                    <table class="dc_DeciduousTeech_table1" cellspacing="0" >
                        <tr class="dc_DeciduousTeech_table1_tr1"><td><span>上颌</span></td></tr>
                        <tr class="dc_DeciduousTeech_table1_tr2"><td><span>牙<br />面</span></td></tr>
                        <tr class="dc_DeciduousTeech_table1_tr3">
                            <td><span>第<br />二<br />乳<br />磨<br />牙</span></td>
                            <td><span>第<br />一<br />乳<br />磨<br />牙</span></td>
                            <td><span>乳<br />尖<br />牙</span></td>
                            <td><span>乳<br />侧<br />切<br />牙</span></td>
                            <td><span>乳<br />中<br />切<br />牙</span></td>
                            <td><span>乳<br />中<br />切<br />牙</span></td>
                            <td><span>乳<br />侧<br />切<br />牙</span></td>
                            <td><span>乳<br />尖<br />牙</span></td>
                            <td><span>第<br />一<br />乳<br />磨<br />牙</span></td>
                            <td><span>第<br />二<br />乳<br />磨<br />牙</span></td>
                        </tr>
                        <tr class="dc_DeciduousTeech_table1_tr4" id="dc_P-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table1_tr5" id="dc_L-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table1_tr6" id="dc_B-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table1_tr7" id="dc_D-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table1_tr8" id="dc_O-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table1_tr9" id="dc_M-teeth-list"></tr>
                    </table>
                </div>
                <hr class="dc_DeciduousTeech_hr" />
                <div>
                    <table class="dc_DeciduousTeech_table2" cellspacing="0">
                        <tr class="dc_DeciduousTeech_table2_tr1" ><td><span>右</span></td></tr>
                        <tr class="dc_DeciduousTeech_table2_tr2"><td><span>左</span></td></tr>
                        <tr class="dc_DeciduousTeech_table2_tr3" id="dc_roman-top"></tr>
                        <tr class="dc_DeciduousTeech_table2_tr4" id="dc_roman-bottom"></tr> 
                    </table>
                </div>
                <hr class="dc_DeciduousTeech_hr" />
                <!--Table结构，cellspacing控制中间空行 -->
                <div>
                    <table class="dc_DeciduousTeech_table3"  cellspacing="0">
                        <tr class="dc_DeciduousTeech_table3_tr1"><td><span >牙<br />面</span></td></tr>
                        <tr class="dc_DeciduousTeech_table3_tr2" id="dc_M-bottom-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table3_tr3" id="dc_O-bottom-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table3_tr4" id="dc_D-bottom-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table3_tr5" id="dc_B-bottom-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table3_tr6" id="dc_L-bottom-teeth-list"></tr>
                        <tr class="dc_DeciduousTeech_table3_tr7" id="dc_P-bottom-teeth-list"></tr>
                    </table>
                </div>
                <center class="dc_DeciduousTeech_center" >
                    <span>下颌</span>
                </center>
            </div>
            <div class="dc_AdvancedTeech_AutoSize">
                <label>
                    <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "乳牙牙位图",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 800,
            bodyClass: "DeciduousTeechElement",
            bodyHtml: DeciduousTeechHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let teethPostionTopObj = TEETHPOSTIONTOPOBJ;
        //上颌牙位置
        teethPostionTopObj.filter((item) => {
            this.teethPosition(item.idPrefix, item.parentId, item.teethKey, true, ctl);
        });
        // 下颌牙位置
        let teethPostionBottomObj = TEETHPOSTIONBOTTOMOBJ;
        //下颌牙位置
        teethPostionBottomObj.filter((item) => {
            this.teethPosition(item.idPrefix, item.parentId, item.teethKey, false, ctl);
        });
        //罗马牙位（value值）结构渲染
        this.romanteethPosition(1, "#dc_roman-top", ctl);
        this.romanteethPosition(11, "#dc_roman-bottom", ctl);
        //值复显
        SetValues(arr);

        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        dcPanelBody.find("td>input.inp").click(function () {
            let nameArr = [
                "a1",
                "a3",
                "a5",
                "a6",
                "a8",
                "a10",
                "a11",
                "a13",
                "a15",
                "a16",
                "a18",
                "a20",
            ];
            let attributeArr = [
                "Value1",
                "Value3",
                "Value5",
                "Value6",
                "Value8",
                "Value10",
                "Value11",
                "Value13",
                "Value15",
                "Value16",
                "Value18",
                "Value20",
            ];
            if (this.getAttribute("dccheck") == "true") {
                for (var n = 1; n < 21; n++) {
                    if (this.name == "a" + n + "") {
                        this.style.cssText = `width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: ${nameArr.includes(this.name) ? "#fff;" : "#d7e4f2;"
                            };`;
                        this.setAttribute("dccheck", "false");
                    } else if (this.getAttribute("id") == "Value" + n + "") {
                        ["Value", "a", "b", "c", "d", "e", "f"].filter((item) => {
                            ctl.ownerDocument
                                .getElementById(item + n + "")
                                .setAttribute("dccheck", "false");
                            ctl.ownerDocument.getElementById(
                                item + n + ""
                            ).style.cssText = `width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color:${attributeArr.includes(this.getAttribute("id"))
                                ? "#fff;"
                                : "#d7e4f2;"
                            } `;
                        });
                    }
                }
            } else {
                for (var n = 1; n < 21; n++) {
                    if (this.name == "a" + n + "") {
                        ctl.ownerDocument.getElementById("Value" + n + "").style.cssText =
                            "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                        ctl.ownerDocument
                            .getElementById("Value" + n + "")
                            .setAttribute("dccheck", "true");
                    } else {
                        this.style.cssText =
                            "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                        this.setAttribute("dccheck", "true");
                    }
                }
            }
        });
        function successFun() {
            let newArr = GetCurrentDatas();
            let str = "";
            newArr.filter((item, index) => {
                str += `Value${index}:${item};`;
            });
            options.Values = str;
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
        function GetCurrentDatas() {
            var jsonObj = new Array();
            for (var n = 0; n < 20; n++) {
                var vall = "";
                var i = n + 1;
                if (
                    ctl.ownerDocument
                        .getElementById("Value" + i + "")
                        .getAttribute("dccheck") == "true"
                ) {
                    vall = ctl.ownerDocument.getElementById("Value" + i + "").value;
                    ["a", "b", "c", "d", "e", "f"].filter((item) => {
                        if (
                            ctl.ownerDocument
                                .getElementById(item + i + "")
                                .getAttribute("dccheck") == "true"
                        ) {
                            vall += ctl.ownerDocument.getElementById(item + i + "").value;
                        }
                    });
                    jsonObj[n + 1] = vall;
                } else {
                    jsonObj[n + 1] = "";
                }
            }
            return jsonObj;
        }
        function SetValues(values) {
            //[DUWRITER5_0-3772] 20241028 lxy 修复恒牙牙位图设置值时，不能正确显示值的bug
            var ValueArr = values != null ? Object.keys(values) : [];
            for (var i = 0; i < 20; i++) {
                for (var j = 0; j < ValueArr.length; j++) {
                    //当值存在时，设置值
                    var id = "Value" + (i + 1) + "";
                    var value = values[ValueArr[j]];

                    if (values[ValueArr[j]] && ValueArr[j] == id) {
                        ctl.ownerDocument.getElementById(id).style.cssText =
                            "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                        ctl.ownerDocument.getElementById(id).setAttribute("dccheck", "true");
                        let teethKeyObject =
                            i <= 9
                                ? {
                                    //上颌牙
                                    P: "a",
                                    L: "b",
                                    B: "c",
                                    D: "d",
                                    O: "e",
                                    M: "f",
                                }
                                : {
                                    //下颌牙
                                    M: "a",
                                    O: "b",
                                    D: "c",
                                    B: "d",
                                    L: "e",
                                    P: "f",
                                };
                        for (var key in teethKeyObject) {
                            if (value.indexOf(key) >= 0) {
                                ctl.ownerDocument.getElementById(
                                    teethKeyObject[key] + (i + 1) + ""
                                ).style.cssText =
                                    "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #0078d7;";
                                ctl.ownerDocument
                                    .getElementById(teethKeyObject[key] + (i + 1) + "")
                                    .setAttribute("dccheck", "true");
                            }
                        }

                    }
                }
            }
        }
    },

    /**
     * 病变上牙对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     */
    DiseasedTeethTopDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var DiseasedTeethTopHtml = `
        <div class="dc_DiseasedTeethTop_box" >
            <div class="dc_use_value1_block dc_use_value1_1"></div>
            <div  class="dc_use_value1_block dc_use_value1_2"></div>
            <div class="dc_use_value1_3"></div>
            <input class="dc_use_value1_block dc_use_value1_4" type="text" name="Value1" data-text="Value1" >
            <input class="dc_DiseasedTeethTop_input1" type="text" name="Value2" data-text="Value2" >
            <input class="dc_DiseasedTeethTop_input2" type="text" name="Value3" data-text="Value3" >
        </div>
        <label class="dc_use_value1">
            <input type="checkbox" id="dc_use_value1_check">
            使用1号位置值
        </label>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "病变上牙设置",
            bodyHeight: "auto",
            bodyClass: "dc_DiseasedTeethTop",
            bodyHtml: DiseasedTeethTopHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        // //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        GetOrChangeData(dcPanelBody, arr);
        //获取是否需要隐藏value1位置的元素:true隐藏
        var isHideDCUseValue1Block = arr && arr.ValueX && (arr.ValueX === '1');
        isHideDCUseValue1Block && dcTrrigerUseDomList(true);
        jQuery(dcPanelBody).find('#dc_use_value1_check').attr("checked", !isHideDCUseValue1Block);

        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        // 设置隐藏或显示value1位置的元素
        function dcTrrigerUseDomList(isHide) {
            var dcUseDomList = ctl.ownerDocument.querySelectorAll(".dc_use_value1_block");
            dcUseDomList && dcUseDomList.length && dcUseDomList.forEach(item => {
                item && (item.style.display = isHide ? "none" : "block");
            });
        }

        jQuery(dcPanelBody).on('change', '#dc_use_value1_check', function () {
            if (jQuery(this).is(':checked')) {
                // 使用值1
                dcTrrigerUseDomList(false);
            } else {
                // 不使用值1
                dcTrrigerUseDomList(true);
            }
        });

        function successFun() {
            let arr = Object.values(GetOrChangeData(dcPanelBody));
            let str = "";
            arr.filter((item, index) => {
                str += `Value${index + 1 + ""}:${item};`;
            });
            str += 'ValueX:' + (jQuery(dcPanelBody).find('#dc_use_value1_check').is(':checked') ? '' : '1') + ";";
            options.Values = str;
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options, '==========option');
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 病变下牙对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     */
    DiseasedTeethBottonDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var DiseasedTeethBottonHtml = `
        <div class="dc_DiseasedTeethBotton_box" >
            <div class="dc_DiseasedTeethBotton_value1_box" >
                <input  type="text" name="Value1" data-text="Value1" >
            </div>
            <div class="dc_DiseasedTeethBotton_value2_box" >
                    <input type="text" name="Value2" data-text="Value2" >
                <p></p>
                    <input type="text" name="Value3" data-text="Value3" >
            </div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "病变下牙设置",
            bodyHeight: "auto",
            bodyClass: "dc_DiseasedTeethBotton",
            bodyHtml: DiseasedTeethBottonHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        // //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        GetOrChangeData(dcPanelBody, arr);
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            let arr = Object.values(GetOrChangeData(dcPanelBody));
            let str = "";
            arr.filter((item, index) => {
                str += `Value${index + 1 + ""}:${item};`;
            });
            // console.log(str)
            options.Values = str;
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 固定桥牙位图
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     */

    StationaryBridgeTeethDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        var StationaryBridgeTeethHtml = `
        <div class="dc_StationaryBridgeTeethBox">
            <div class="dc_StationaryBridgeTeethTop">上颌</div>
            <div class="dc_StationaryBridgeTeethCenter" id="dc_StationaryBridgeTeethCenter">
                <div class="dc_StationaryBridgeTeethCenter_Top">
                    <div id="dc_StationaryBridgeTeethCenter_Top_value1"></div>
                    <div id="dc_StationaryBridgeTeethCenter_Top_value2"></div>
                </div>
                <div class="dc_StationaryBridgeTeethCenter_Content">
                   <div class="dc_StationaryBridgeTeethCenter_Content_left">
                        <div valueNumber="value1" class="dc_StationaryBridgeTeethCenter_Content_clear">清</div>
                        <div valueNumber="value3" class="dc_StationaryBridgeTeethCenter_Content_clear">清</div>
                   </div>
                    <div class="dc_StationaryBridgeTeethCenter_Center">
                        <div id="dc_StationaryBridgeTeethCenter_Center_value1"></div>
                        <div id="dc_StationaryBridgeTeethCenter_Center_value2"></div>
                        <div class="dc_StationaryBridgeTeethCenter_Center_line"></div>
                        <div id="dc_StationaryBridgeTeethCenter_Center_value3"></div>
                        <div id="dc_StationaryBridgeTeethCenter_Center_value4"></div>
                    </div>
                   <div class="dc_StationaryBridgeTeethCenter_Content_right">
                        <div valueNumber="value2" class="dc_StationaryBridgeTeethCenter_Content_clear">清</div>
                        <div valueNumber="value4" class="dc_StationaryBridgeTeethCenter_Content_clear">清</div>
                   </div>
                </div>
                <div class="dc_StationaryBridgeTeethCenter_Bottom">
                    <div id="dc_StationaryBridgeTeethCenter_Top_value3"></div>
                    <div id="dc_StationaryBridgeTeethCenter_Top_value4"></div>
                </div>
            </div>
            <div class="dc_StationaryBridgeTeethBottom">下颌</div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "固定桥牙位图",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 482,
            bodyClass: "StationaryBridgeTeeth",
            bodyHtml: StationaryBridgeTeethHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        //按钮数据
        var buttonList = TEETHBUTTONLIST;
        //格式化按钮数据
        var toothButtonObject = {};
        var newbuttonList = JSON.parse(JSON.stringify(buttonList));//防止污染源数据

        if (options.Values) {
            let arr = this.stringToObject(options.Values);
            Object.keys(arr).forEach((item) => {
                var newItem = item.toLowerCase();
                var valueArr = arr[item].split('');
                //渲染数字
                if (newItem === 'value1' || newItem === 'value3') {
                    valueArr = arr[item].split('').reverse();
                }
                newbuttonList.forEach((btnItem, index) => {
                    btnItem.value = valueArr[index];
                });
                toothButtonObject[`${newItem}`] = JSON.parse(JSON.stringify(newbuttonList));
            });
        } else {
            //当options中没有Values值时，默认渲染4个值（防止牙位按钮无法渲染）
            let arr = new Array(4).fill().map((_, index) => ("value" + (index + 1))); // 这将创建一个包含四个元素且值为递增的数组
            arr.forEach(item => {
                toothButtonObject[item] = JSON.parse(JSON.stringify(newbuttonList));
            });
        }


        //渲染点击牙位按钮
        Object.keys(toothButtonObject).forEach((key) => {
            var itemTootoothBox = ctl.ownerDocument.getElementById(`dc_StationaryBridgeTeethCenter_Top_${key}`);//按钮
            var itemTootoothNumbox = ctl.ownerDocument.getElementById(`dc_StationaryBridgeTeethCenter_Center_${key}`);//数字
            itemTootoothBox.innerHTML = itemTootoothNumbox.innerHTML = "";
            var strs = ["A", "B", "C", "D", "E"];
            if (['value1', 'value3'].indexOf(key) !== -1) {
                //反向渲染
                for (var i = toothButtonObject[key].length - 1; i >= 0; i--) {
                    var item = toothButtonObject[key][i];
                    itemTootoothBox.innerHTML += `<div valueNumber=${key} valueId=${item.id} valueData="${item.value}" class="dc_StationaryBridgeTeethButton ${item.value === '+' ? "dc_jia_teeth_button" : (item.value === '-' ? "dc_jian_teeth_button" : (strs.indexOf(item.value) >= 0 ? "dc_deciduous_teeth_button" : ""))}">${item.text}</div>`;
                    itemTootoothNumbox.innerHTML += `<div id="dc_StationaryBridgeTeethNum${key}${item.id}" class="dc_StationaryBridgeTeethNum ${item.value === '+' ? "dc_jia_teeth_StationaryBridgeTeethNum" : (item.value === '-' ? "dc_jian_teeth_StationaryBridgeTeethNum" : "")}">${item.id}</div>`;
                }
            } else {
                //正向渲染
                toothButtonObject[key].forEach((item) => {
                    itemTootoothBox.innerHTML += `<div valueNumber=${key} valueId=${item.id} valueData="${item.value}" class="dc_StationaryBridgeTeethButton  ${item.value === '+' ? "dc_jia_teeth_button" : (item.value === '-' ? "dc_jian_teeth_button" : (strs.indexOf(item.value) >= 0 ? "dc_deciduous_teeth_button" : ""))}">${item.text}</div>`;
                    itemTootoothNumbox.innerHTML += `<div id="dc_StationaryBridgeTeethNum${key}${item.id}" class="dc_StationaryBridgeTeethNum ${item.value === '+' ? "dc_jia_teeth_StationaryBridgeTeethNum" : (item.value === '-' ? "dc_jian_teeth_StationaryBridgeTeethNum" : "")}" >${item.id}</div>`;
                });
            }
        });


        var dcStationaryBridgeTeethCenter = ctl.ownerDocument.getElementById('dc_StationaryBridgeTeethCenter');
        dcStationaryBridgeTeethCenter.addEventListener('click', eventClickDispatch);

        //固定桥对话框点击事件派发
        function eventClickDispatch(e) {
            if (e && e.target && e.target.nodeName && e.target.nodeName === "DIV") {
                if (e.target.className.indexOf("dc_StationaryBridgeTeethButton") > -1) {
                    //点击牙位按钮
                    clickTeethButton(e.target);
                } else if (e.target.className.indexOf("dc_StationaryBridgeTeethCenter_Content_clear") > -1) {
                    clickClearButton(e.target);
                }
            }
        }
        //清空选中内容
        function clickClearButton(currentDom) {
            var valueNumber = currentDom.getAttribute('valuenumber');
            toothButtonObject[valueNumber] = JSON.parse(JSON.stringify(buttonList));
            var ItemValues = jQuery(ctl).find(`#dc_StationaryBridgeTeethCenter_Top_${valueNumber} .dc_StationaryBridgeTeethButton`);
            ItemValues.removeClass("dc_jia_teeth_button dc_jian_teeth_button");
            // 清空边框标识
            var ItemBorder = jQuery(ctl).find(`#dc_StationaryBridgeTeethCenter_Center_${valueNumber} .dc_jia_teeth_StationaryBridgeTeethNum,#dc_StationaryBridgeTeethCenter_Center_${valueNumber} .dc_jian_teeth_StationaryBridgeTeethNum`);
            ItemBorder.removeClass("dc_jia_teeth_StationaryBridgeTeethNum dc_jian_teeth_StationaryBridgeTeethNum");

        }

        //牙位图点击事件
        function clickTeethButton(currentDom) {
            let valueNumber = currentDom.getAttribute("valueNumber");
            let valueId = currentDom.getAttribute("valueId");
            var currentValueArr = JSON.parse(JSON.stringify(toothButtonObject[valueNumber]));//获取当前value数组
            var changeBorderDom = ctl.ownerDocument.getElementById("dc_StationaryBridgeTeethNum" + valueNumber + valueId);
            currentValueArr.forEach((item) => {
                //修改数据值
                if (item.id === Number(valueId)) {
                    var strs = ["", "A", "B", "C", "D", "E"];
                    //修改值状态
                    switch (item.value) {
                        case "*":
                            item.value = "+";
                            currentDom.className = "dc_StationaryBridgeTeethButton dc_jia_teeth_button";
                            changeBorderDom.className = "dc_StationaryBridgeTeethNum dc_jia_teeth_StationaryBridgeTeethNum";
                            break;
                        case "+":
                            if (item.id >= 1 && item.id <= 5) {
                                item.value = strs[item.id];
                                currentDom.className = "dc_StationaryBridgeTeethButton dc_deciduous_teeth_button";
                            } else {
                                item.value = "-";
                                currentDom.className = "dc_StationaryBridgeTeethButton dc_jian_teeth_button";
                                changeBorderDom.className = "dc_StationaryBridgeTeethNum dc_jian_teeth_StationaryBridgeTeethNum";
                            }
                            break;
                        case "-":
                            item.value = "*";
                            currentDom.className = "dc_StationaryBridgeTeethButton";
                            changeBorderDom.className = "dc_StationaryBridgeTeethNum";
                            break;
                        default:
                            if (strs.indexOf(item.value) >= 0) {
                                item.value = "-";
                                currentDom.className = "dc_StationaryBridgeTeethButton dc_jian_teeth_button";
                                changeBorderDom.className = "dc_StationaryBridgeTeethNum dc_jian_teeth_StationaryBridgeTeethNum";
                            }
                            break;
                    }
                    currentDom.setAttribute("valueData", item.value);
                }

            });
            toothButtonObject[valueNumber] = JSON.parse(JSON.stringify(currentValueArr));
        }

        function getValuesStringForToothButtonObject() {
            let str = '';
            Object.keys(toothButtonObject).forEach((item, index) => {
                var newItem = item.charAt(0).toUpperCase() + item.slice(1);//将第一个字母转成大写，后台解析需要大写开头
                str += `${newItem}:`;
                let valueArr = toothButtonObject[item];

                //按牙齿顺序排列值
                if (item === 'value1' || item === 'value3') {
                    for (var i = 8; i >= 1; i--) {
                        var item_teeth = valueArr.find(item => item.id === i);
                        str += item_teeth.value;
                    }
                } else {
                    for (var i = 1; i <= 8; i++) {
                        var item_teeth = valueArr.find(item => item.id === i);
                        str += item_teeth.value;
                    }
                }

                //最后一个不拼接逗号
                if (item !== 'Value4') {
                    str += ';';
                }

            });
            return str;
        }

        function successFun() {
            options.Values = getValuesStringForToothButtonObject();
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options.Values, '============options');
            // console.log(options, '============options');
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },


    /**
       * 电活力测试牙位图
       * @param options 医学表达式属性
       * @param ctl 编辑器元素
       */
    ElectricPulpTestingTeethDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        let arr = this.stringToObject(options.Values);
        var ElectricPulpTestingTeethHtml = `
        <div class="dc_ElectricPulpTestingTeeth_Box">
            <div class="dc_ElectricPulpTestingTeeth_top">上颌</div>
            <div class="dc_ElectricPulpTestingTeeth_center">
               
                <div class="dc_ElectricPulpTestingTeeth_center_left">
                    <div class="dc_ElectricPulpTestingTeeth_center_yamian">牙面</div>
                    <div class="dc_ElectricPulpTestingTeeth_center_clean_box">
                        <div id="dc_input_clear_button" class="dc_input_clear_button">清</div>
                    </div>
                    <div class="dc_ElectricPulpTestingTeeth_center_yamian2">牙面</div>
                </div>
                <div id="dc_ElectricPulpTestingTeeth_center_right" class="dc_ElectricPulpTestingTeeth_center_right">
                    <div id="dc_ElectricPulpTestingTeeth_center_right_top" calss="dc_ElectricPulpTestingTeeth_center_right_top">
                        <div id="dc_ElectricPulpTestingTeeth_button_box1"></div>
                        <div id="dc_ElectricPulpTestingTeeth_button_box2"></div>
                    </div>
                    <div id="dc_ElectricPulpTestingTeeth_center_right_center" calss="dc_ElectricPulpTestingTeeth_center_right_center">
                    <div id="dc_ElectricPulpTestingTeeth_input_box1"></div>
                    <div id="dc_ElectricPulpTestingTeeth_input_box2"></div>
                    <div id="dc_ElectricPulpTestingTeeth_input_box3"></div>
                    <div id="dc_ElectricPulpTestingTeeth_input_box4"></div>
                    </div>
                    <div id="dc_ElectricPulpTestingTeeth_center_right_bottom" calss="dc_ElectricPulpTestingTeeth_center_right_bottom">
                        <div id="dc_ElectricPulpTestingTeeth_button_box3"></div>
                        <div id="dc_ElectricPulpTestingTeeth_button_box4"></div>
                    </div>
                </div>
            </div>
            <div class="dc_ElectricPulpTestingTeeth_bottom">下颌</div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "电活力测试牙位图",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 560,
            bodyClass: "ElectricPulpTestingTeeth",
            bodyHtml: ElectricPulpTestingTeethHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //按钮数据
        for (var dotIndex = 1; dotIndex <= 4; dotIndex++) {
            //渲染牙位图
            var dcTeethTextHtml = ``;
            var dcTeethInputHtml = ``;
            var dc_EdcTeethTextHtmlBoxItem = ctl.ownerDocument.getElementById(`dc_ElectricPulpTestingTeeth_button_box${dotIndex}`);
            var dc_ElectricPulpTestingTeeth_InputBox = ctl.ownerDocument.getElementById(`dc_ElectricPulpTestingTeeth_input_box${dotIndex}`);
            if (dotIndex === 2 || dotIndex === 4) {
                //正序
                for (var i = 1; i <= 8; i++) {
                    TEETHBUTTONLIST.forEach(item => {
                        if (item.id === i) {
                            dcTeethTextHtml += `<div class="dc_teeth_text_item">${item.text}</div>`;
                            dcTeethInputHtml += `<input type="number" data-value-name="Value${dotIndex}${item.id}" class="dc_teeth_input_item"></input>`;

                        }
                    });
                }
            } else {
                //倒序
                for (var i = 8; i > 0; i--) {
                    TEETHBUTTONLIST.forEach(item => {
                        if (item.id === i) {
                            dcTeethTextHtml += `<div class="dc_teeth_text_item">${item.text}</div>`;
                            dcTeethInputHtml += `<input type="number" data-value-name="Value${dotIndex}${item.id}"  class="dc_teeth_input_item"></input>`;
                        }
                    });
                }
            }
            dc_EdcTeethTextHtmlBoxItem.innerHTML = dcTeethTextHtml;//正序
            dc_ElectricPulpTestingTeeth_InputBox.innerHTML = dcTeethInputHtml;
        }

        // 获取所有type为number的input元素
        const numberInputs = ctl.ownerDocument.querySelectorAll('.dc_teeth_input_item[type="number"]');
        // 遍历所有numberInputs，限制只能输入1-99之间的数值，并且不能输入小数
        numberInputs.forEach(input => {
            // 添加input事件监听器
            input.addEventListener('keydown', function (event) {
                var nextValue = `${this.value}${event.key}`;//用于判断是否会超出最大最小值
                // 限制只能输入1-99之间的数值，并且不能输入小数
                if ((event.key === '.') || (parseInt(nextValue) < 1) || (parseInt(nextValue) > 99)) {
                    if (event.preventDefault) {
                        event.preventDefault();
                    } else {
                        event.returnValue = false;
                    }
                }
            });
        });


        //牙位图数据值展示
        if (arr && Object.keys(arr).length) {
            Object.keys(arr).forEach(item => {
                var valueItem = jQuery(ctl).find(`input[data-value-name=${item}]`);
                if (valueItem) {
                    valueItem.val(arr[item] !== '' ? Number(arr[item]) : '');
                }
            });
        }
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }


        //清空按钮点击事件
        var clearButton = ctl.ownerDocument.getElementById("dc_input_clear_button");
        clearButton.addEventListener("click", function () {
            var allInputBox = ctl.ownerDocument.querySelectorAll(".dc_teeth_input_item");
            allInputBox.forEach(item => {
                item.value = "";
            });
        });

        function successFun() {
            var newDataObject = {};
            var allDataValueList = ctl.ownerDocument.querySelectorAll('input[data-value-name]');
            if (allDataValueList && allDataValueList.length) {
                allDataValueList.forEach(item => {
                    var valueName = item.getAttribute('data-value-name');
                    newDataObject[valueName] = item.value;
                });
            }
            var newValues = '';
            Object.keys(newDataObject).map(key => newValues += `${key}:${newDataObject[key]};`);
            options.Values = newValues;
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options, '=======options');
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 恒牙乳牙多生牙混合牙位图
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     */
    AdvancedTeechDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        // console.log(options);
        var AdvancedTeechHtml = `
            <div id="dc_AdvancedTeech_Box" class="dc_AdvancedTeech_Box">
                <div class="dc_AdvancedTeech_top">
                    <div id="dc_AdvancedTeech_top_title_box" class="dc_AdvancedTeech_top_title_box"></div>
                    <div id="dc_AdvancedTeech_top_teeth_box" class="dc_AdvancedTeech_top_teeth_box">
                        <div class="dc_AdvancedTeech_top_title_Item">牙面</div>
                        <div id="dc_AdvancedTeech_teeth_content" class="dc_AdvancedTeech_teeth_content"></div>
                    </div>
                </div>
                <div class="dc_AdvancedTeech_cnter">
                    <div class="dc_AdvancedTeech_cnter_left">右</div>
                    <div class="dc_AdvancedTeech_cnter_center">
                        <div id="dc_AdvancedTeech_cnter_permanent_top" class="dc_AdvancedTeech_cnter_permanent_top"></div>
                        <div id="dc_AdvancedTeech_cnter_deciduous_top" class="dc_AdvancedTeech_cnter_deciduous_top"></div>
                        <div id="dc_AdvancedTeech_cnter_supernumerary_top" class="dc_AdvancedTeech_cnter_supernumerary_top"></div>
                        <div id="dc_AdvancedTeech_cnter_supernumerary_bottom" class="dc_AdvancedTeech_cnter_supernumerary_bottom"></div>
                        <div id="dc_AdvancedTeech_cnter_deciduous_bottom" class="dc_AdvancedTeech_cnter_deciduous_bottom"></div>
                        <div id="dc_AdvancedTeech_cnter_permanent_bottom" class="dc_AdvancedTeech_cnter_permanent_bottom"></div>
                    </div>
                    <div class="dc_AdvancedTeech_cnter_right">左</div>
                </div>
                <div class="dc_AdvancedTeech_bottom">
                    <div id="dc_AdvancedTeech_Bootom_teeth_box" class="dc_AdvancedTeech_Bootom_teeth_box">
                        <div class="dc_AdvancedTeech_top_title_Item">牙面</div>
                        <div id="dc_AdvancedTeech_teeth_content_bottom" class="dc_AdvancedTeech_teeth_content"></div>
                    </div>
                </div>
                <div class="dc_AdvancedTeech_AutoSize">
                    <label>
                        <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                        <span>自动调整大小</span>
                    </label>
                </div>
                <div class="dc_AdvancedTeech_title_top">上颌</div>
                <div class="dc_AdvancedTeech_title_bottom">下颌</div>
            </div>
        `;
        var dialogOptions = {
            title: "恒牙乳牙多生牙混合牙位图",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 538,
            bodyClass: "AdvancedTeech",
            bodyHtml: AdvancedTeechHtml,
        };

        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        //数据初始化
        var permanentTeeth = ["M", "O", "D", "B", "L", "P"];//恒牙数据
        var deciduousTeeth = ["Ⅰ", "Ⅱ", "Ⅲ", "Ⅳ", "Ⅴ"];//乳牙数据
        var deciduousTeethReplace = ["U", "V", "W", "X", "Y"];//后期考虑用户可以自定义，与deciduousTeeth对应
        var TeethDescription = ["第四磨牙", "第三磨牙", "第二磨牙", "第一磨牙", "第二前磨牙", "第一前磨牙", "尖牙", "侧切牙", "中切牙",];//牙位描述

        //渲染顶部牙位说明
        var dcAdvancedTeechTopTitleBox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_top_title_box");
        TeethDescription = TeethDescription.concat([...TeethDescription].reverse());
        dcAdvancedTeechTopTitleBox.innerHTML += TeethDescription.map(item => `<div class="dc_AdvancedTeech_top_title_Item">${item}</div>`).join('');


        //上颌牙位图
        var dcTopteethContent = ctl.ownerDocument.getElementById("dc_AdvancedTeech_teeth_content");
        //下颌牙位图
        var dcBottomteethContent = ctl.ownerDocument.getElementById("dc_AdvancedTeech_teeth_content_bottom");
        //上牙恒牙数字标识
        var dcPermanentTopNumber = ctl.ownerDocument.getElementById("dc_AdvancedTeech_cnter_permanent_top");
        //下牙恒牙数字标识
        var dcPermanentBootomNumber = ctl.ownerDocument.getElementById("dc_AdvancedTeech_cnter_permanent_bottom");
        //上乳牙罗马数字
        var dcDeciduousTopNumber = ctl.ownerDocument.getElementById("dc_AdvancedTeech_cnter_deciduous_top");
        //下乳牙罗马数字
        var dcDeciduousBottomNumber = ctl.ownerDocument.getElementById("dc_AdvancedTeech_cnter_deciduous_bottom");
        //上牙多生牙
        var dcSupernumeraryTop = ctl.ownerDocument.getElementById("dc_AdvancedTeech_cnter_supernumerary_top");
        //下牙多生牙
        var dcSupernumeraryBottom = ctl.ownerDocument.getElementById("dc_AdvancedTeech_cnter_supernumerary_bottom");

        for (var j = 1; j <= 4; j++) {
            //用于记录正序或倒序
            let startNum = j === 1 || j === 3 ? 9 : 1;

            //恒牙英文id标识
            var newPermanentTeeth = (j <= 2) ? JSON.parse(JSON.stringify(permanentTeeth)).reverse() : JSON.parse(JSON.stringify(permanentTeeth));
            //开始渲染可以点击的牙位
            for (var i = 1; i <= 9; i++) {
                //渲染牙面列表
                var dcTeethListNumberHtml = newPermanentTeeth.map(item => `<div dc-data-button-type="dentalSurface" id="${j}${startNum}${item}" class="dc_AdvancedTeech_teeth_content_Item">${item}</div>`).join('');
                var dcTeethList = `<div class='dc_AdvancedTeech_teeth_content_List'>${dcTeethListNumberHtml}</div>`;
                (j <= 2) ? (dcTopteethContent.innerHTML += dcTeethList) : (dcBottomteethContent.innerHTML += dcTeethList);//(j <= 2)表示上牙位

                //多生牙（没有29Z、49Z牙位）
                var dcSupernumerary = (['49', '29'].indexOf(`${j}${startNum}`) > -1) ? '' : `<div  dc-data-button-type="supernumeraryTeeth" id="${j}${startNum}Z" class="dc_AdvancedTeech_teeth_triangle_back"><div class="dc_AdvancedTeech_teeth_triangle"></div></div>`;
                (j <= 2) ? (dcSupernumeraryTop.innerHTML += dcSupernumerary) : (dcSupernumeraryBottom.innerHTML += dcSupernumerary);//(j <= 2)表示上牙位

                //对应的数字牙位
                var dcTeethListNumber = `<div dc-data-button-type="permanentTeeth" id="${j}${startNum}" class="dc_AdvancedTeech_teeth_content_Item">${startNum}</div>`;
                (j <= 2) ? (dcPermanentTopNumber.innerHTML += dcTeethListNumber) : (dcPermanentBootomNumber.innerHTML += dcTeethListNumber);//(j <= 2)表示上牙位

                //乳牙罗马数字（只有5个牙位）
                var dcTeethDeciduousListNumberHtml = (startNum <= 5) ? `<div dc-data-button-type="deciduousTeeth" dc-permanent-data-id="${j}${startNum}" id='${j}${deciduousTeethReplace[startNum - 1]}' class="dc_AdvancedTeech_teeth_content_Item">${deciduousTeeth[startNum - 1]}</div>` : '';
                (j <= 2) ? (dcDeciduousTopNumber.innerHTML += dcTeethDeciduousListNumberHtml) : (dcDeciduousBottomNumber.innerHTML += dcTeethDeciduousListNumberHtml);//(j <= 2)表示上牙位

                //用于记录正序或倒序
                startNum = (j === 1 || j === 3) ? --startNum : ++startNum;
            }
        }

        //对弹框绑定点击事件
        var dcAdvancedTeechBox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_Box");
        dcAdvancedTeechBox.addEventListener('click', handleAdvancedTeechClick);
        function handleAdvancedTeechClick(e) {
            //监听整个对话款的点击事件
            e.stopPropagation();
            var targetClass = (e.target && e.target.className) || '';
            var clickDom = null;

            if (targetClass.indexOf('dc_AdvancedTeech_teeth_content_Item') > -1) {
                //点击了牙位图
                clickDom = e.target;
            } else if (targetClass.indexOf('dc_AdvancedTeech_teeth_triangle_back') > -1) {
                //点击了多生牙
                clickDom = e.target;
            } else if (targetClass.indexOf('dc_AdvancedTeech_teeth_triangle') > -1) {
                //点击了多生牙的三角形
                clickDom = e.target.parentNode;
            }

            //修改点击元素的样式
            if (clickDom && clickDom.className) {
                var selectClass = "dc_current_select";//选中时的类名
                var clickDomId = parseInt(clickDom.id);
                var clickDomIdButtonType = clickDom.getAttribute("dc-data-button-type");
                //获取当前点击牙位是否被选中
                var isSelect = clickDom.className.indexOf(selectClass) > -1;
                //获取当前点击牙位对应的乳牙数字是否选中 
                var deciduousTeethTarget = ctl.ownerDocument.querySelector(`div[dc-data-button-type="deciduousTeeth"][dc-permanent-data-id="${clickDomId}"]`);
                var deciduousTeethTargetSelect = (deciduousTeethTarget && deciduousTeethTarget.className.indexOf(selectClass) > -1);
                //获取当前点击牙位对应的恒牙数字是否选中
                var permanentTeethTarget = ctl.ownerDocument.getElementById(`${clickDomId}`);
                var permanentTeethTargetSelect = (permanentTeethTarget && permanentTeethTarget.className.indexOf(selectClass) > -1);

                switch (clickDomIdButtonType) {
                    case "dentalSurface":
                        //点击选中牙面
                        if (isSelect === false) {
                            //乳牙存在的牙位
                            if (deciduousTeethTarget) {
                                //当二者都没选中时，则优先选中对应恒牙数字
                                if (!deciduousTeethTargetSelect && !permanentTeethTargetSelect) {
                                    permanentTeethTarget.classList.add(selectClass);
                                }
                            } else {
                                if (!permanentTeethTargetSelect) {
                                    permanentTeethTarget.classList.add(selectClass);
                                }
                            }
                        }
                        break;
                    case "permanentTeeth":
                        //点击取消恒牙的阿拉伯数字
                        if (isSelect) {
                            if (!deciduousTeethTargetSelect) {
                                // 先判断相同位置乳牙数字是否选中，如果没选中需要将关联数据清空
                                permanentTeeth.forEach(item => {
                                    var dentalSurfaceItem = ctl.ownerDocument.getElementById(`${clickDomId}${item}`);
                                    dentalSurfaceItem && dentalSurfaceItem.classList.remove(selectClass);
                                });
                                // 取消对应的多生牙
                                var supernumeraryTeethItem = ctl.ownerDocument.getElementById(`${clickDomId}Z`);
                                supernumeraryTeethItem && supernumeraryTeethItem.classList.remove(selectClass);
                            }
                        }
                        break;
                    case "deciduousTeeth":
                        //点击取消乳牙的罗马数字
                        if (isSelect) {
                            //获取对应的牙面值
                            var dentalSurfaceNumber = clickDom.getAttribute("dc-permanent-data-id");
                            //获取恒牙
                            var permanentTeethTarget = ctl.ownerDocument.getElementById(`${dentalSurfaceNumber}`);
                            var permanentTeethTargetSelect = (permanentTeethTarget && permanentTeethTarget.className.indexOf(selectClass) > -1);
                            if (!permanentTeethTargetSelect) {
                                //先判断相同位置恒牙数字是否选中，如果没选中需要将关联数据清空
                                permanentTeeth.forEach(item => {
                                    var dentalSurfaceItem = ctl.ownerDocument.getElementById(`${dentalSurfaceNumber}${item}`);
                                    dentalSurfaceItem && dentalSurfaceItem.classList.remove('dc_current_select');
                                });

                                // 取消对应的多生牙
                                var supernumeraryTeethItem = ctl.ownerDocument.getElementById(`${dentalSurfaceNumber}Z`);
                                supernumeraryTeethItem && supernumeraryTeethItem.classList.remove(selectClass);
                            }
                        }
                        break;
                    case "supernumeraryTeeth":
                        //点击多生牙
                        if (isSelect === false) {
                            //获取多生牙对应的下一个位置的牙位
                            var clickDomNextId = ((clickDomId <= 29 && clickDomId >= 21) || (clickDomId <= 49 && clickDomId >= 41)) ? clickDomId + 1 : clickDomId - 1;
                            if (clickDomNextId === 10 || clickDomNextId === 30) {
                                clickDomNextId = clickDomNextId + 11;
                            }

                            //获取多生牙对应的下一个乳牙数字是否选中
                            var deciduousTeethTargetNext = ctl.ownerDocument.querySelector(`div[dc-data-button-type="deciduousTeeth"][dc-permanent-data-id="${clickDomNextId}"]`);
                            var deciduousTeethTargetSelectNext = (deciduousTeethTargetNext && deciduousTeethTargetNext.className.indexOf(selectClass) > -1);

                            //获取多生牙对应的下一个恒牙数字是否选中
                            var permanentTeethTargetNext = ctl.ownerDocument.getElementById(`${clickDomNextId}`);
                            var permanentTeethTargetSelectNext = (permanentTeethTargetNext && permanentTeethTargetNext.className.indexOf(selectClass) > -1);

                            //乳牙存在的牙位
                            if (deciduousTeethTarget) {
                                //当二者都没选中时，则优先选中对应恒牙数字
                                if ((!deciduousTeethTargetSelect || !deciduousTeethTargetSelectNext) && (!permanentTeethTargetSelect || !permanentTeethTargetSelectNext)) {
                                    permanentTeethTarget.classList.add(selectClass);
                                    permanentTeethTargetNext.classList.add(selectClass);
                                }
                            } else {
                                if (!permanentTeethTargetSelect || !permanentTeethTargetSelectNext) {
                                    permanentTeethTarget.classList.add(selectClass);
                                    permanentTeethTargetNext.classList.add(selectClass);

                                }
                            }

                        }
                        break;
                    default:
                        break;
                }
                //对当前点击目标进行样式修改
                isSelect ? clickDom.classList.remove(selectClass) : clickDom.classList.add(selectClass);

            }
        }


        //将数据展示在页面
        let advancedTeechValueObject = this.stringToObject(options.Values);
        if (advancedTeechValueObject && advancedTeechValueObject.Value1) {
            let { Value1 } = advancedTeechValueObject;
            let teethArr = Value1.split(",") || [];
            teethArr.length && teethArr.forEach((item => {
                item = item.trim();
                var itemDom = ctl.ownerDocument.getElementById(item);
                if (itemDom) {
                    itemDom.classList.add('dc_current_select');
                } else {
                    // console.log('未找到元素：', item);
                }
            }));
        }



        function successFun() {
            var allselectListDom = ctl.ownerDocument.querySelectorAll(".dc_current_select");

            var Values = "Value1:";
            allselectListDom.forEach((item) => {
                Values += item.id + ",";
            });

            if (advancedTeechValueObject && advancedTeechValueObject.ValueX) {
                Values += (";" + "ValueX:" + advancedTeechValueObject.ValueX + ";");
            }
            options.Values = Values;
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
     * 出血指数
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     */
    FourValues4Dialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }

        var FourValues4Html = `
        <div class="dc_FourValues4dialog_box" >
            <div class="dc_FourValues4dialog_center1">
                <div class="dc_FourValues4dialog_Value1_box">
                    <input  type="text" data-id="Value1"></input>
                </div>
                <div class="dc_FourValues4dialog_Value_center"></div>
                <div class="dc_FourValues4dialog_Value3_box">
                    <input type="text" data-id="Value3"></input>
                </div>
            </div>
            <div  class="dc_FourValues4dialog_center2">
                <div  class="dc_FourValues4dialog_Value2_box">
                    <input   type="text" data-id="Value2"></input>
                </div>
                <div  class="dc_FourValues4dialog_Value_center">
                    <div></div>
                </div>
                <div  class="dc_FourValues4dialog_Value4_box">
                    <input   type="text" data-id="Value4"></input>
                </div>
            </div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "出血指数设置",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 320,
            bodyClass: "dc_FourValues4",
            bodyHtml: FourValues4Html,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        let arr = this.stringToObject(options.Values);
        // console.log(arr, '================arr');
        if (arr && Object.keys(arr) && Object.keys(arr).length) {
            Object.keys(arr).map(item => {
                var dom = ctl.ownerDocument.querySelector(`input[data-id="${item}"]`);
                dom && (dom.value = arr[item]);
            });
        }
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            var dc_FourValues4_AllValue = ctl.ownerDocument.querySelectorAll(`.dc_FourValues4 input[data-id]`);
            // console.log(dc_FourValues4_AllValue);
            options.Values = '';
            dc_FourValues4_AllValue.forEach(item => {
                var key = item.getAttribute("data-id");
                var value = item.value;
                options.Values += `${key}:${value};`;
            });
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options, '==============出血指数');
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },

    /**
    * 探诊深度
    * @param options 医学表达式属性
    * @param ctl 编辑器元素
    */
    PDTeechDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        var PDTeechHtml = `<div class="dc_PDTeech_content">
            <div class="dc_PDTeech_left">
                <input type="text" data-id="Value7" class="dc_PDTeech_left_input"></input>
            </div>
            <div class="dc_PDTeech_center">
                <div class="dc_PDTeech_center_top">
                    <div class="dc_PDTeech_center_inner">
                        <input type="text" data-id="Value1" class="dc_PDTeech_left_input"></input>
                    </div>
                    <div class="dc_PDTeech_center_inner dc_center_input">
                        <input type="text" data-id="Value2" class="dc_PDTeech_left_input"></input>
                    </div>
                    <div class="dc_PDTeech_center_inner">
                        <input type="text" data-id="Value3" class="dc_PDTeech_left_input"></input>
                    </div>
                </div>
                <div class="dc_PDTeech_center_bottom">
                    <div class="dc_PDTeech_center_inner">
                        <input type="text" data-id="Value4" class="dc_PDTeech_left_input"></input>
                    </div>
                    <div class="dc_PDTeech_center_inner dc_center_input">
                        <input type="text" data-id="Value5" class="dc_PDTeech_left_input"></input>
                    </div>
                    <div class="dc_PDTeech_center_inner">
                        <input type="text" data-id="Value6" class="dc_PDTeech_left_input"></input>
                    </div>
                </div>
            </div>
            <div class="dc_PDTeech_right">
                <input type="text" data-id="Value9" class="dc_PDTeech_left_input"></input>
                <input type="text" data-id="Value8" class="dc_PDTeech_left_input"></input>
                <input type="text" data-id="Value10" class="dc_PDTeech_left_input"></input>
            </div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "探诊深度设置",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 450,
            bodyClass: "dc_PDTeech",
            bodyHtml: PDTeechHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        let arr = this.stringToObject(options.Values);
        var allInput = ctl.ownerDocument.querySelectorAll(`.dc_PDTeech_left_input`);
        // console.log(arr, '================arr');
        if (arr && Object.keys(arr).length) {
            allInput.length && allInput.forEach(item => {
                let key = item.getAttribute("data-id");
                item.value = arr[key];
            });
        }
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            options.Values = "";
            allInput.forEach(item => {
                var key = item.getAttribute("data-id");
                var value = item.value;
                options.Values += `${key}:${value};`;
            });
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options);
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
        * 婚育史
        * @param options 医学表达式属性
        * @param ctl 编辑器元素
        */
    FourValues5Dialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        var FourValues5Html = `<div class="dc_FourValues5_content">
            <div>
                <div>足月数</div>
                <div><input type="number" min="0" value="0"  data-id="Value1" class="dc_FourValues5_input"></input></div>
            </div>
            <div class="dc_FourValues5_line"></div>
            <div>
                <div>早产数</div>
                <div><input type="number"  min="0"  value="0" data-id="Value2" class="dc_FourValues5_input"></input></div>
            </div>
            <div class="dc_FourValues5_line"></div>
            <div>
                <div>流产数</div>
                <div><input type="number" min="0"  value="0" data-id="Value3" class="dc_FourValues5_input"></input></div>
            </div>
            <div class="dc_FourValues5_line"></div>
            <div>
                <div>现有数</div>
                <div><input type="number" min="0"  value="0" data-id="Value4" class="dc_FourValues5_input"></input></div>
            </div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "婚育史",
            bodyHeight: "auto",
            dialogContainerBodyWidth: 440,
            bodyClass: "dc_FourValues5",
            bodyHtml: FourValues5Html,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        let arr = this.stringToObject(options.Values);
        var allInput = ctl.ownerDocument.querySelectorAll(`.dc_FourValues5_input`);

        if (arr && Object.keys(arr).length) {
            allInput.length && allInput.forEach(item => {
                let key = item.getAttribute("data-id");
                item.value = parseFloat(arr[key]);
            });
        }
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        function successFun() {
            options.Values = "";
            allInput.forEach(item => {
                var key = item.getAttribute("data-id");
                var value = item.value;
                options.Values += `${key}:${value};`;
            });
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            // console.log(options);
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 复合牙位图
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     */
    ManyValuesDialog: function (options, ctl, isInsertMode, ele) {
        if (!isInsertMode && (!options || typeof options != "object")) {
            return false;
        }
        var ManyValuesHtml = `
       
        <div class="dc_ManyValues_content">
            <div class="dc_ManyValues_Left">
                <div class="dc_ManyValues_Left_top">
                    <div class="dc_ManyValues_Left_top_number">
                        <div data-id="Value1" class="dc_many_values_tooth">8</div>
                        <div data-id="Value2" class="dc_many_values_tooth">7</div>
                        <div data-id="Value3" class="dc_many_values_tooth">6</div>
                        <div data-id="Value4" class="dc_many_values_tooth">5</div>
                        <div data-id="Value5" class="dc_many_values_tooth">4</div>
                        <div data-id="Value6" class="dc_many_values_tooth">3</div>
                        <div data-id="Value7" class="dc_many_values_tooth">2</div>
                        <div data-id="Value8" class="dc_many_values_tooth">1</div>
                    </div>
                    <div  class="dc_ManyValues_Left_top_text">
                        <div data-id="Value11"  class="dc_many_values_tooth">E</div>
                        <div data-id="Value12"  class="dc_many_values_tooth">D</div>
                        <div data-id="Value13"  class="dc_many_values_tooth">C</div>
                        <div data-id="Value14"  class="dc_many_values_tooth">B</div>
                        <div data-id="Value15"  class="dc_many_values_tooth">A</div>
                    </div>
                </div>
                <div class="dc_ManyValues_Left_Line"></div>
                <div class="dc_ManyValues_Left_bottom">
                    <div class="dc_ManyValues_Left_bottom_text">
                        <div data-id="Value21" class="dc_many_values_tooth">E</div>
                        <div data-id="Value22" class="dc_many_values_tooth">D</div>
                        <div data-id="Value23" class="dc_many_values_tooth">C</div>
                        <div data-id="Value24" class="dc_many_values_tooth">B</div>
                        <div data-id="Value25" class="dc_many_values_tooth">A</div>
                    </div>
                    <div class="dc_ManyValues_Left_bottom_number">
                        <div data-id="Value31" class="dc_many_values_tooth">8</div>
                        <div data-id="Value32" class="dc_many_values_tooth">7</div>
                        <div data-id="Value33" class="dc_many_values_tooth">6</div>
                        <div data-id="Value34" class="dc_many_values_tooth">5</div>
                        <div data-id="Value35" class="dc_many_values_tooth">4</div>
                        <div data-id="Value36" class="dc_many_values_tooth">3</div>
                        <div data-id="Value37" class="dc_many_values_tooth">2</div>
                        <div data-id="Value38" class="dc_many_values_tooth">1</div>
                    </div>
                </div>
            </div>
            <div class="dc_ManyValues_Right">
                <div class="dc_ManyValues_Right_top">
                    <div class="dc_ManyValues_Right_top_number">
                        <div data-id="Value41" class="dc_many_values_tooth">1</div>
                        <div data-id="Value42" class="dc_many_values_tooth">2</div>
                        <div data-id="Value43" class="dc_many_values_tooth">3</div>
                        <div data-id="Value44" class="dc_many_values_tooth">4</div>
                        <div data-id="Value45" class="dc_many_values_tooth">5</div>
                        <div data-id="Value46" class="dc_many_values_tooth">6</div>
                        <div data-id="Value47" class="dc_many_values_tooth">7</div>
                        <div data-id="Value48" class="dc_many_values_tooth">8</div>
                    </div>
                    <div class="dc_ManyValues_Right_top_text">
                        <div data-id="Value51" class="dc_many_values_tooth">A</div>
                        <div data-id="Value52" class="dc_many_values_tooth">B</div>
                        <div data-id="Value53" class="dc_many_values_tooth">C</div>
                        <div data-id="Value54" class="dc_many_values_tooth">D</div>
                        <div data-id="Value55" class="dc_many_values_tooth">E</div>
                    </div>
                </div>
                <div class="dc_ManyValues_Right_Line"></div>
                <div class="dc_ManyValues_Right_bottom">
                    <div class="dc_ManyValues_Right_bottom_text">
                        <div data-id="Value61" class="dc_many_values_tooth">A</div>
                        <div data-id="Value62" class="dc_many_values_tooth">B</div>
                        <div data-id="Value63" class="dc_many_values_tooth">C</div>
                        <div data-id="Value64" class="dc_many_values_tooth">D</div>
                        <div data-id="Value65" class="dc_many_values_tooth">E</div>
                    </div>
                    <div class="dc_ManyValues_Right_bottom_number">
                        <div data-id="Value71" class="dc_many_values_tooth">1</div>
                        <div data-id="Value72" class="dc_many_values_tooth">2</div>
                        <div data-id="Value73" class="dc_many_values_tooth">3</div>
                        <div data-id="Value74" class="dc_many_values_tooth">4</div>
                        <div data-id="Value75" class="dc_many_values_tooth">5</div>
                        <div data-id="Value76" class="dc_many_values_tooth">6</div>
                        <div data-id="Value77" class="dc_many_values_tooth">7</div>
                        <div data-id="Value78" class="dc_many_values_tooth">8</div>
                    </div>
                </div>
            </div>
        </div>
        <div class="dc_AdvancedTeech_AutoSize">
            <label>
                <input type="checkbox" id="dc_AdvancedTeech_AutoSize_checkbox" class="dc_AdvancedTeech_AutoSize_checkbox">
                    <span>自动调整大小</span>
            </label>
        </div>
        `;
        var dialogOptions = {
            title: "复合牙位图",
            bodyHeight: "auto",
            dialogContainerBodyWidth: "auto",
            bodyClass: "dc_ManyValues",
            bodyHtml: ManyValuesHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        let that = this;
        //自动调整大小
        var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
        const hasAutoSize = Object.keys(options).some(key => key.toLowerCase() === 'autosize');
        // 不存在默认值给true
        if (hasAutoSize) {
            autoSizeCheckbox.checked = options.AutoSize || false;
        } else {
            autoSizeCheckbox.checked = true;
        }

        //初始化选中的牙位
        if (options.Values) {
            let arr = that.stringToObject(options.Values);
            console.log(arr, '===================');
            if (arr && Object.keys(arr).length) {
                Object.keys(arr).forEach(item => {
                    if (arr[item] && arr[item] !== '') {
                        var dom = ctl.ownerDocument.querySelector(`.dc_many_values_tooth[data-id="${item}"]`);
                        if (dom) {
                            dom.classList.add("dc_many_values_tooth_active");
                        }

                    }
                });
            }
        }



        //dc_many_values_tooth点击事件
        var dc_many_values_tooth = ctl.ownerDocument.querySelectorAll(".dc_many_values_tooth");
        if (dc_many_values_tooth) {
            dc_many_values_tooth.forEach(item => {
                item.addEventListener("click", function () {
                    if (item.classList.contains("dc_many_values_tooth_active")) {
                        item.classList.remove("dc_many_values_tooth_active");
                    } else {
                        item.classList.add("dc_many_values_tooth_active");
                    }
                });
            });
        }

        //获取当前选中的牙位
        function getCurrentSelectedTooth() {
            var arr = {};
            var currentSelectedTooth = ctl.ownerDocument.querySelectorAll(".dc_many_values_tooth_active");
            if (currentSelectedTooth && currentSelectedTooth.length) {
                currentSelectedTooth.forEach(item => {
                    var id = item.getAttribute("data-id");
                    var value = item.textContent;
                    arr[id] = value;
                });
            }
            return arr;
        }


        function successFun() {
            var currentSelectedTooth = getCurrentSelectedTooth();
            options.Values = that.ObjectToString(currentSelectedTooth);
            //自动调整大小
            var autoSizeCheckbox = ctl.ownerDocument.getElementById("dc_AdvancedTeech_AutoSize_checkbox");
            options['AutoSize'] = autoSizeCheckbox.checked;

            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertmedicalexpression", false, options);
            } else {
                ctl.SetElementProperties(ele, options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }

    },
    /**
    * 打印背景色选择
    * @param options 颜色值
    * @param ctl 
    */
    PrintBackColorDialog: function (options, ctl) {
        if (!ctl) {
            return false;
        }
        var PrintBackColorHtml = `
        <div class="dc_PrintBackColor_content">
           请选择颜色： <input type="color" id='dc_Print_Back_color' />
        </div>
        `;
        var dialogOptions = {
            title: "打印背景色选择",
            bodyHeight: 80,
            dialogContainerBodyWidth: 240,
            bodyClass: "dc_PrintBackColor",
            bodyHtml: PrintBackColorHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var dcPrintBackColor = ctl.ownerDocument.getElementById("dc_Print_Back_color");
        if (dcPrintBackColor) {
            if (options && typeof options === "string") {
                dcPrintBackColor.value = options;
            }
        }

        function successFun() {
            ctl.DCExecuteCommand("PrintBackColor", false, dcPrintBackColor.value);
        }
    },
    /**
     * 打印字体色
     * @param options 颜色值
     * @param ctl 
     */
    PrintColorDialog: function (options, ctl) {
        if (!ctl) {
            return false;
        }
        var PrintColorHtml = `
        <div class="dc_PrintColor_content">
           请选择颜色： <input type="color" id='dc_Print_Back_color' />
        </div>
        `;
        var dialogOptions = {
            title: "选择打印字体色",
            bodyHeight: 80,
            dialogContainerBodyWidth: 240,
            bodyClass: "dc_PrintColor",
            bodyHtml: PrintColorHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var dcPrintColor = ctl.ownerDocument.getElementById("dc_Print_Back_color");
        if (dcPrintColor) {
            if (options && typeof options === "string") {
                dcPrintColor.value = options;
            }
        }

        function successFun() {
            ctl.DCExecuteCommand("PrintColor", false, dcPrintColor.value);
            ctl.DocumentOptions.ViewOptions.BothBlackWhenPrint = false;
            ctl.ApplyDocumentOptions();
        }
    },
    /**
     * 插入ControlHost
     * @param options 
     * @param ctl 
     */
    InsertControlHostDialog: function (options, ctl, isInsertMode) {
        var ele = null;
        if (!options || typeof options != "object") {
            // 当未传入值时
            if (isInsertMode == true) {
                options = {};
            } else {
                ele = ctl.CurrentElement("XTextControlHostElement");
                if (ele == null) {
                    return false;
                }
                options = ctl.GetElementProperties(ele);
                if (options == null) {
                    return false;
                }
            }
        }
        //console.log(options, '===================');
        if (!options) {
            return false;
        }

        var ControlHostHtml = `
        <div class="dc_ControlHost_content">
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">ID：</div>
                <input data-text="id" class="dc_dc_controlHost_item_value" type="text"/>
            </div>
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">Name：</div>
                <input data-text="name" class="dc_dc_controlHost_item_value" type="text"/>
            </div>
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">宽度：</div>
                <input data-text="width" class="dc_dc_controlHost_item_value" type="text"/>
            </div>
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">高度：</div>
                <input data-text="height" class="dc_dc_controlHost_item_value" type="text"/>
            </div>
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">完整名称：</div>
                <input data-text="typefullname" class="dc_dc_controlHost_item_value" type="text"/>
            </div>
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">打印可见性：</div>
                <select data-text="printvisibility" class="dc_dc_controlHost_item_value">
                    <option value="visible">Visible</option>
                    <option value="hidden">Hidden</option>
                    <option value="none">None</option>
                </select>
            </div>
            <div class="dc_controlHost_item">
                <div class="dc_controlHost_item_title">允许调整大小：</div>
                <select data-text="allowuserresize" class="dc_dc_controlHost_item_value" type="text">
                    <option value="fixsize">FixSize</option>
                    <option value="width">Width</option>
                    <option value="height">Height</option>
                    <option value="widthandheight">WidthAndHeight</option>
                </select>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "承载控件属性设置",
            bodyHeight: 380,
            dialogContainerBodyWidth: 320,
            bodyClass: "dc_ControlHost",
            bodyHtml: ControlHostHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        if (options && Object.keys(options).length) {
            Object.keys(options).map(item => {
                var dom = ctl.ownerDocument.querySelector(`[data-text="${item.toLowerCase()}"]`);
                if (dom) {
                    if (dom.nodeName && dom.nodeName === "SELECT") {
                        dom.value = options[item] && options[item].toLowerCase && options[item].toLowerCase();
                    } else {
                        dom.value = options[item];
                    }
                }
            });
        }
        function successFun() {
            let allDataDom = ctl.ownerDocument.querySelectorAll('.dc_ControlHost_content [data-text]');
            let data = {};
            if (allDataDom) {
                allDataDom.forEach(item => {
                    let key = item.getAttribute("data-text");
                    let value = item.value;
                    data[key] = value;
                });
            }
            if (isInsertMode == true) {
                ctl.DCExecuteCommand("insertcontrolhost", false, {
                    ...options,
                    ...data
                });
            } else {
                ctl.SetElementProperties(ele, {
                    ...options,
                    ...data
                });
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("XTextControlHostElement"));
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            }
        }
    },
    /**
     * 医学表达式通用值转换方法（字符串转换为对象）
     * @param values 医学表达式values默认值的字符串
     * @return arr 处理完成的对象
     */
    stringToObject: function (values) {
        let arr = {};
        if (values) {
            let newValues = values.split(";");
            newValues.filter((item) => {
                if (item) {
                    let keyName = item.slice(0, item.indexOf(":"));
                    let keyvalue = item.slice(item.indexOf(":") + 1, item.length);
                    arr[keyName] = keyvalue;
                }
            });
        }
        return arr;
    },

    /**
     * 医学表达式通用值转换方法（字符串转换为对象）
     * @param _data 获取的输入库数据
     * @return str 处理完成的字符串
     */
    ObjectToString: function (_data) {
        let str = "";
        for (var i in _data) {
            str += `${i}:${_data[i]};`;
        }
        return str;
    },

    /**
     * 牙位生成函数
     * @param idPrefix id绑定的前缀
     * @param parentId 父元素id
     * @param teethKey 牙位标识
     * @param isTop 是否为上颌（用于区分上下颌）
     * @return
     */
    teethPosition: function (idPrefix, parentId, teethKey, isTop = true, ctl) {
        let newPTeethList = "";
        let namePArr = isTop
            ? ["a1", "a2", "a3", "a4", "a5", "a6", "a7", "a8", "a9", "a10"]
            : ["a11", "a12", "a13", "a14", "a15", "a16", "a17", "a18", "a19", "a20"];
        let idNum = isTop ? 1 : 11;
        for (var i = 0; i < namePArr.length; i++) {
            newPTeethList += `<td><input class="inp" dccheck="false" readonly="readonly" unselectable="on" name="${namePArr[i]
                }" type="text" id="${idPrefix + (i + idNum) + ""
                }" value="${teethKey}" style="width:20px; height:20px;text-align:center;border: 1px solid rgb(169, 169, 169);
        background-color: rgb(255, 255, 255); ${[1, 3, 6, 8].includes(i)
                    ? "border:1px solid #a9a9a9;background-color: #d7e4f2;"
                    : ""
                }" /></td>`;
        }
        jQuery(ctl).find(parentId).append(jQuery(newPTeethList));
    },

    /**
     * 恒牙牙位生成函数
     * @param idPrefix id绑定的前缀
     * @param parentId 父元素id
     * @param teethKey 牙位标识
     * @param isTop 是否为上颌（用于区分上下颌）
     * @return
     */
    PermanentToothPosition: function (
        idPrefix,
        parentId,
        teethKey,
        isTop = true,
        ctl
    ) {
        let num = isTop ? 1 : 17;
        let newRomanTeethList = "";
        for (var i = 0; i < 16; i++) {
            newRomanTeethList += `<td><input class="inp" dccheck="false" readonly="readonly" unselectable="on" name="a${i + num + ""
                }" type="text" id="${idPrefix + (i + num) + ""
                }" value="${teethKey}" style="width:20px; height:20px;text-align:center;${[1, 3, 5, 7, 8, 10, 12, 14].includes(i)
                    ? 'border:1px solid #a9a9a9;background-color: #d7e4f2;"'
                    : ""
                }" /></td>`;
        }
        jQuery(ctl).find(parentId).append(jQuery(newRomanTeethList));
    },

    /**
     * 恒牙牙位图，value值dom生成函数
     */
    PermanentToothValueNumber: function (parentId, valueNum, ctl) {
        let newNumberValueHtml = "";
        for (var i = 8; i > 0; i--) {
            newNumberValueHtml += ` <td><input class="inp" dccheck="false" readonly="readonly" unselectable="on"
                            type="text" id="Value${valueNum + (9 - i)
                }" value="${i}"
                            style="${i % 2 != 0
                    ? "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #d7e4f2;"
                    : "width:20px; height:20px;text-align:center;"
                }"
                            /></td>`;
        }
        for (var i = 1; i <= 8; i++) {
            newNumberValueHtml += `<td><input class="inp" dccheck="false" readonly="readonly" unselectable="on"
                type="text" id="Value${valueNum + (i + 8)}" value="${i}"
                style="${i % 2 != 0
                    ? "width:20px; height:20px;text-align:center;border:1px solid #a9a9a9;background-color: #d7e4f2;"
                    : "width:20px; height:20px;text-align:center;"
                }"
                /></td>`;
        }
        jQuery(ctl).find(parentId).append(jQuery(newNumberValueHtml));
        // console.log(jQuery('#dc_valueNumberBox1'))
    },

    /**
     * 罗马数字牙位生成函数
     * @param  id绑定的前缀
     * @param valueNum value值的数字后缀
     * @param parentId 父元素id
     * @return
     */
    romanteethPosition: function (valueNum, parentId, ctl) {
        let newRomanTeethList = "";
        let romanArr = ["Ⅴ", "Ⅳ", "Ⅲ", "Ⅱ", "Ⅰ", "Ⅰ", "Ⅱ", "Ⅲ", "Ⅳ", "Ⅴ"];
        for (var i = 0; i < romanArr.length; i++) {
            newRomanTeethList += `<td><input class="inp" dccheck="false" readonly="readonly" unselectable="on" type="text" id="Value${i + valueNum + ""
                }" data-text="Value${i + valueNum + ""}" value="${romanArr[i]
                }" style="width:20px; height:20px;text-align:center;border: 1px solid rgb(169, 169, 169);
        background-color: rgb(255, 255, 255);${[1, 3, 6, 8].includes(i)
                    ? "border:1px solid #a9a9a9;background-color: #d7e4f2;"
                    : ""
                }"/></td>`;
        }
        jQuery(ctl).find(parentId).append(jQuery(newRomanTeethList));
    },

    /**
     * 派发医学表达式写值对话框
     * @param options 医学表达式属性
     * @param ctl 编辑器元素
     * @param isInsertMode 是否是插入模式
     */
    DCDispatchMedicalExpressionExecuteCommand: function (options, ctl, isInsertMode = false, ele) {
        if ((options && options.ExpressionStyle && options.ExpressionStyle.trim() != '') === false) {
            //不存在元素属 或者expressionStyle为空，则终止操作
            return false;
        }
        let ExpressionStyle = options.ExpressionStyle.trim().toLowerCase();
        switch (ExpressionStyle) {
            // 月经史公式
            case "fourvalues":
                WriterControl_Dialog.FourValuesDialog(options, ctl, isInsertMode, ele);
                break;
            // 月经史公式1
            case "fourvalues1":
                //如果自定义属性中带有参数ISPERIMETRIC,则表示为龋齿公式
                if (options && options.Attributes && options.Attributes['ISPERIMETRIC'] && options.Attributes['ISPERIMETRIC'] === 'true') {
                    WriterControl_Dialog.DentalCariesDialog(options, ctl, isInsertMode, ele);
                } else {
                    //月经史1
                    WriterControl_Dialog.FourValues1Dialog(options, ctl, isInsertMode, ele);
                }
                break;
            // 月经史公式2
            case "fourvalues2":
                //如果自定义属性中带有参数ISPERIMETRIC,则表示为视野图公式
                if (options && options.Attributes && options.Attributes['ISPERIMETRIC'] && options.Attributes['ISPERIMETRIC'] === 'true') {
                    WriterControl_Dialog.PerimetricDialog(options, ctl, isInsertMode, ele);
                } else {
                    //月经史2
                    WriterControl_Dialog.FourValues2Dialog(options, ctl, isInsertMode, ele);
                }
                break;
            // 月经史公式4
            case "threevalues":
                WriterControl_Dialog.ThreeValuesDialog(options, ctl, isInsertMode, ele);
                break;
            // 瞳孔
            case "pupil":
                WriterControl_Dialog.PupilDialog(options, ctl, isInsertMode, ele);
                break;
            // 胎心值
            case "fetalheart":
                WriterControl_Dialog.FetalHeartDialog(options, ctl, isInsertMode, ele);
                break;
            // 标尺
            case "painindex":
                WriterControl_Dialog.PainIndexDialog(options, ctl, isInsertMode, ele);
                break;
            // 眼球突出度
            case "threevalues2":
                WriterControl_Dialog.EyeballProtrusionDialog(options, ctl, isInsertMode, ele);
                break;
            // 斜视符号
            case "strabismussymbol":
                WriterControl_Dialog.SquintSymbolDialog(options, ctl, isInsertMode, ele);
                break;
            // 恒牙牙位图
            case "permanentteethbitmap":
                WriterControl_Dialog.PermanentTeethBitmapDialog(options, ctl, isInsertMode, ele);
                break;
            // 乳牙牙位图
            case "deciduousteech":
                WriterControl_Dialog.DeciduousTeechDialog(options, ctl, isInsertMode, ele);
                break;
            // 分数公式
            case "fraction":
                WriterControl_Dialog.FractionDialog(options, ctl, isInsertMode, ele);
                break;
            // 光定位
            case "lightpositioning":
                WriterControl_Dialog.LightPositioningDialog(options, ctl, isInsertMode, ele);
                break;
            // 病变上牙
            case "diseasedteethtop":
                WriterControl_Dialog.DiseasedTeethTopDialog(options, ctl, isInsertMode, ele);
                break;
            // 病变下牙
            case "diseasedteethbotton":
                WriterControl_Dialog.DiseasedTeethBottonDialog(options, ctl, isInsertMode, ele);
                break;
            //固定桥牙位图
            case "stationarybridgeteeth":
                WriterControl_Dialog.StationaryBridgeTeethDialog(options, ctl, isInsertMode, ele);
                break;
            //电活力测试牙位图
            case "electricpulptestingteeth":
                WriterControl_Dialog.ElectricPulpTestingTeethDialog(options, ctl, isInsertMode, ele);
                break;
            //恒牙乳牙多生牙混合牙位图
            case "advancedteech":
                WriterControl_Dialog.AdvancedTeechDialog(options, ctl, isInsertMode, ele);
                break;
            //出血指数
            case "fourvalues4":
                WriterControl_Dialog.FourValues4Dialog(options, ctl, isInsertMode, ele);
                break;
            //探诊深度
            case "pdteech":
                WriterControl_Dialog.PDTeechDialog(options, ctl, isInsertMode, ele);
                break;
            //婚育史
            case "fourvalues5":
                WriterControl_Dialog.FourValues5Dialog(options, ctl, isInsertMode, ele);
                break;
            //婚育史
            case "manyvalues":
                WriterControl_Dialog.ManyValuesDialog(options, ctl, isInsertMode, ele);
                break;
        }
    },
    /**
   * 医学表达式属性对话框
   * @param options 医学表达式属性
   * @param ctl 编辑器元素
   * @param isInsertMode 是否是插入模式
   */
    MedicalExpressionDialog: function (options, ctl, isInsertMode = false, ele) {
        if (!options && !isInsertMode) {
            //非新增模式，且没有传入options，则终止操作
            return false;
        }
        if (!options) {
            options = {};
        }
        console.log(options, '===============options');

        var MedicalExpressionHtml = `
        <div id="dcMedicalExpression">
            <!-- 配置区域 -->
            ${options.showConfig === false ? '' : `<div class="dc_MedicalExpression_form">
                <div class="config-title-row">
                    <div class="config-title">表达式配置</div>
                    <div class="config-tip">推荐默认Times New Roman字体，默认勾选自适应大小</div>
                </div>
                <div class="config-form">
                    <!-- 第一行：ID -->
                    <div class="config-row">
                        <div class="config-item id-item">
                            <label class="config-label">ID：</label>
                            <input type="text" class="config-input" id="dc_MedicalExpression_configId" placeholder="自动生成" data-text="ID" />
                        </div>
                    </div>
                    <!-- 第二行：字体、自适应大小、宽高 -->
                    <div class="config-row">
                        <div class="config-item font-item">
                            <label class="config-label">字体：</label>
                            <select id="dc_MedicalExpression_form_font" data-text="FontName" class="config-select">
                                <option value="Times New Roman" selected>Times New Roman</option>
                            </select>
                        </div>
                        <div class="config-item">
                            <input type="checkbox" class="config-checkbox" id="dc_MedicalExpression_form_autoSize" checked>
                            <label class="config-checkbox-label" for="dc_MedicalExpression_form_autoSize">自适应大小</label>
                        </div>
                        <div class="config-item size-item">
                            <label class="config-label">宽高：</label>
                            <div class="size-inputs-wrapper">
                                <input type="number" class="config-input" id="dc_MedicalExpression_configWidth" data-text="Width" min="0.5" max="10" step="0.1">
                                <span class="size-separator">×</span>
                                <input type="number" class="config-input" id="dc_MedicalExpression_configHeight" data-text="Height" min="0.5" max="10" step="0.1">
                            </div>
                        </div>
                    </div>
                </div>
            </div>`}

            <!-- 表达式选择区域 -->
            <div class="dc_MedicalExpression_type">
                <!-- 搜索和分类 -->
                <div class="search-section">
                    <div class="search-wrapper">
                        <input type="text" class="search-input" id="dc_MedicalExpression_searchInput" placeholder="搜索公式名称...">
                        <svg class="search-icon" viewBox="0 0 16 16" fill="none" xmlns="http://www.w3.org/2000/svg">
                            <path d="M11.5 10.5L14 13M12.5 7.5C12.5 10.2614 10.2614 12.5 7.5 12.5C4.73858 12.5 2.5 10.2614 2.5 7.5C2.5 4.73858 4.73858 2.5 7.5 2.5C10.2614 2.5 12.5 4.73858 12.5 7.5Z" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round"/>
                        </svg>
                    </div>
                    <div class="category-tabs" id="dc_MedicalExpression_categoryTabs">
                        <button class="category-tab active" data-category="all">全部</button>
                        <button class="category-tab" data-category="menstrual">月经史</button>
                        <button class="category-tab" data-category="dental">牙科</button>
                        <button class="category-tab" data-category="ophthalmic">眼科</button>
                        <button class="category-tab" data-category="other">其他</button>
                    </div>
                </div>
                <div id="MedicalExpressionChooseIMGBox"></div>
                <div class="empty-message hidden" id="dc_MedicalExpression_emptyMessage">未找到匹配的表达式</div>
            </div>
        </div>
            `;

        var dialogOptions = {
            title: "医学表达式",
            bodyHeight: 474,
            dialogContainerBodyWidth: 550,
            bodyClass: "dcMedicalExpressionElement",
            bodyHtml: MedicalExpressionHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        // 获取新的DOM元素
        var configId = ctl.ownerDocument.getElementById('dc_MedicalExpression_configId');
        var configWidth = ctl.ownerDocument.getElementById('dc_MedicalExpression_configWidth');
        var configHeight = ctl.ownerDocument.getElementById('dc_MedicalExpression_configHeight');
        var configAutoSize = ctl.ownerDocument.getElementById('dc_MedicalExpression_form_autoSize');

        // 生成随机ID
        function generateRandomId() {
            var prefix = 'dcexpr_';
            var timestamp = Date.now().toString(36);
            var random = Math.random().toString(36).substring(2, 8);
            var id = prefix + timestamp + random;
            if (configId) {
                configId.value = id;
            }
            return id;
        }

        // 切换宽高配置项的显示/隐藏
        function toggleSizeConfig() {
            var sizeItems = ctl.ownerDocument.querySelectorAll('.config-item.size-item');
            var autoSize = configAutoSize ? configAutoSize.checked : true;

            if (sizeItems && sizeItems.length > 0) {
                for (var i = 0; i < sizeItems.length; i++) {
                    if (autoSize) {
                        sizeItems[i].classList.remove('show');
                    } else {
                        sizeItems[i].classList.add('show');
                    }
                }
            }
        }

        // 判断是否显示配置区域
        var showConfigSection = options.showConfig !== false; // 默认 true

        //填充字体（仅在配置区域显示时）
        var dc_font = null;
        if (showConfigSection) {
            var FontFamilysArray = ctl.getSupportFontFamilys() || [];
            if (!FontFamilysArray || FontFamilysArray.length == 0) {
                FontFamilysArray = ["宋体", "黑体", "微软雅黑", "楷体"];
            }

            dc_font = jQuery(ctl).find('#dc_MedicalExpression_form_font');
            if (dc_font && dc_font.length > 0) {
                for (var f = 0; f < FontFamilysArray.length; f++) {
                    if (FontFamilysArray[f] !== "Times New Roman") {
                        dc_font.append(`<option value="${FontFamilysArray[f]}">${FontFamilysArray[f]}</option>`);
                    }
                }
            }
        }

        // 自适应大小复选框事件（仅在配置区域显示时）
        if (configAutoSize && showConfigSection) {
            configAutoSize.addEventListener('change', toggleSizeConfig);
        }

        // 分类映射函数
        function getExpressionCategory(img) {
            var expressionStyle = img.expressionStyle;

            // 判断 FourValues2 是否为视野图值（带有 ISPERIMETRIC: "true"）
            if (expressionStyle === "FourValues2") {
                if (img.Attributes && img.Attributes.ISPERIMETRIC && img.Attributes.ISPERIMETRIC === 'true') {
                    return "ophthalmic"; // 视野图值归为眼科
                } else {
                    return "menstrual"; // 月经史公式
                }
            }

            // 月经史
            if (expressionStyle === "FourValues" || expressionStyle === "FourValues1" ||
                expressionStyle === "ThreeValues") {
                return "menstrual";
            }
            // 牙科
            if (expressionStyle === "PermanentTeethBitmap" || expressionStyle === "DeciduousTeech" ||
                expressionStyle === "DiseasedTeethTop" || expressionStyle === "DiseasedTeethBotton" ||
                expressionStyle === "ElectricPulpTestingTeeth" || expressionStyle === "StationaryBridgeTeeth" ||
                expressionStyle === "PDTeech" || expressionStyle === "FourValues4" ||
                expressionStyle === "AdvancedTeech") {
                return "dental";
            }
            // 眼科
            if (expressionStyle === "Pupil" || expressionStyle === "StrabismusSymbol" ||
                expressionStyle === "LightPositioning" || expressionStyle === "ThreeValues2") {
                return "ophthalmic";
            }
            // 其他
            return "other";
        }

        // 为表达式添加分类属性
        if (MEDICALCHARACTERSIMGOBJECT && MEDICALCHARACTERSIMGOBJECT.length) {
            for (var i = 0; i < MEDICALCHARACTERSIMGOBJECT.length; i++) {
                var img = MEDICALCHARACTERSIMGOBJECT[i];
                if (!img.category) {
                    img.category = getExpressionCategory(img);
                }
            }
        }

        // 填充图片 
        var MedicalExpressionChooseIMGBox = ctl.ownerDocument.getElementById("MedicalExpressionChooseIMGBox");
        var searchInput = ctl.ownerDocument.getElementById("dc_MedicalExpression_searchInput");
        var categoryTabs = ctl.ownerDocument.getElementById("dc_MedicalExpression_categoryTabs");
        var emptyMessage = ctl.ownerDocument.getElementById("dc_MedicalExpression_emptyMessage");
        var filteredExpressions = MEDICALCHARACTERSIMGOBJECT ? [...MEDICALCHARACTERSIMGOBJECT] : [];

        // 渲染表达式列表
        function renderExpressions() {
            if (!MedicalExpressionChooseIMGBox) return;

            // 清空现有内容
            MedicalExpressionChooseIMGBox.innerHTML = '';

            if (filteredExpressions.length === 0) {
                if (emptyMessage) {
                    emptyMessage.classList.remove('hidden');
                }
                return;
            }

            if (emptyMessage) {
                emptyMessage.classList.add('hidden');
            }

            // 设置网格布局样式
            MedicalExpressionChooseIMGBox.style.display = 'grid';
            MedicalExpressionChooseIMGBox.style.gridTemplateColumns = 'repeat(4, 1fr)';
            MedicalExpressionChooseIMGBox.style.gap = '10px';
            MedicalExpressionChooseIMGBox.style.padding = '4px 0';

            for (var i = 0; i < filteredExpressions.length; i++) {
                var img = filteredExpressions[i];
                var MedicalExpressionChooseDiv = ctl.ownerDocument.createElement("div");
                MedicalExpressionChooseDiv.setAttribute('expressionStyle', img.expressionStyle);
                MedicalExpressionChooseDiv.setAttribute('class', "dc_MedicalExpressionChooseDiv");
                MedicalExpressionChooseDiv.id = "dc_MedicalExpressionChooseDiv_" + img.expressionStyle;

                // 创建图标容器
                var iconWrapper = ctl.ownerDocument.createElement("div");
                iconWrapper.style.width = '2cm';
                iconWrapper.style.height = '1cm';
                iconWrapper.style.marginBottom = '6px';
                iconWrapper.style.display = 'flex';
                iconWrapper.style.alignItems = 'center';
                iconWrapper.style.justifyContent = 'center';
                iconWrapper.style.backgroundColor = 'white';
                iconWrapper.style.borderRadius = '2px';

                var imgElement = ctl.ownerDocument.createElement("img");
                imgElement.src = img.base64ImgSrc;
                imgElement.style.width = '100%';
                imgElement.style.height = '100%';
                imgElement.style.objectFit = 'contain';
                imgElement.style.display = 'block';
                iconWrapper.appendChild(imgElement);

                // 创建标题
                var titleDiv = ctl.ownerDocument.createElement("div");
                titleDiv.textContent = img.title;
                titleDiv.style.fontSize = '12px';
                titleDiv.style.color = '#333';
                titleDiv.style.textAlign = 'center';
                titleDiv.style.fontWeight = '500';

                MedicalExpressionChooseDiv.appendChild(iconWrapper);
                MedicalExpressionChooseDiv.appendChild(titleDiv);

                //判断是视野图值或者月经史公式2
                if (img.expressionStyle === "FourValues2") {
                    if (img.Attributes && img.Attributes.ISPERIMETRIC && img.Attributes.ISPERIMETRIC === 'true') {
                        //增加一个自定义属性，标识为视野图公式
                        MedicalExpressionChooseDiv.setAttribute('ISPERIMETRIC', "true");
                    }
                }
                MedicalExpressionChooseIMGBox.appendChild(MedicalExpressionChooseDiv);
            }
        }

        // 获取当前选中的分类
        function getSelectedCategory() {
            if (!categoryTabs) return 'all';
            var activeTab = categoryTabs.querySelector('.category-tab.active');
            return activeTab ? activeTab.dataset.category : 'all';
        }

        // 保存当前选中的表达式样式
        var selectedExpressionStyle = null;

        // 过滤表达式
        function filterExpressions() {
            var category = getSelectedCategory();
            var keyword = searchInput ? searchInput.value.trim().toLowerCase() : '';

            filteredExpressions = (MEDICALCHARACTERSIMGOBJECT || []).filter(function (img) {
                // 如果有搜索关键词，则在所有分类中搜索
                if (keyword) {
                    return img.title && img.title.toLowerCase().indexOf(keyword) !== -1;
                }
                // 如果没有搜索关键词，则按分类过滤
                return category === 'all' || img.category === category;
            });

            renderExpressions();

            // 恢复选中状态
            if (selectedExpressionStyle) {
                var selectedDiv = ctl.ownerDocument.getElementById("dc_MedicalExpressionChooseDiv_" + selectedExpressionStyle);
                if (selectedDiv) {
                    selectedDiv.classList.add("dc_MedicalExpressionChooseDiv_active");
                }
            }
        }

        // 初始化渲染
        if (MedicalExpressionChooseIMGBox) {
            renderExpressions();
        }

        // 搜索框事件
        if (searchInput) {
            searchInput.addEventListener('input', filterExpressions);
        }

        // 分类标签事件
        if (categoryTabs) {
            categoryTabs.addEventListener('click', function (e) {
                var tab = e.target.closest('.category-tab');
                if (tab) {
                    // 移除所有活动状态
                    var tabs = categoryTabs.querySelectorAll('.category-tab');
                    for (var i = 0; i < tabs.length; i++) {
                        tabs[i].classList.remove('active');
                    }
                    // 添加当前活动状态
                    tab.classList.add('active');
                    filterExpressions();
                }
            });
        }

        //选中对应的医学表达式类型
        var expressionStyle = options && options.ExpressionStyle;
        if (expressionStyle) {
            selectedExpressionStyle = expressionStyle;
        }
        // 延迟选中，等待渲染完成
        setTimeout(function () {
            var MedicalExpressionChooseDiv = ctl.ownerDocument.getElementById("dc_MedicalExpressionChooseDiv_" + expressionStyle);
            if (MedicalExpressionChooseDiv) {
                MedicalExpressionChooseDiv.classList.add("dc_MedicalExpressionChooseDiv_active");
            } else {
                //如果没有找到对应的表达式类型，则默认选择第一个
                var firstMedicalExpressionChooseDiv = ctl.ownerDocument.querySelector(".dc_MedicalExpressionChooseDiv");
                if (firstMedicalExpressionChooseDiv) {
                    firstMedicalExpressionChooseDiv.classList.add("dc_MedicalExpressionChooseDiv_active");
                    selectedExpressionStyle = firstMedicalExpressionChooseDiv.getAttribute("expressionStyle");
                }
            }
        }, 100);

        //设置字体
        if (options && options.Style && options.Style.FontName) {
            options['FontName'] = options.Style.FontName;
            //设置字体下拉框的值
            var dc_MedicalExpression_form_font = ctl.ownerDocument.getElementById('dc_MedicalExpression_form_font');
            if (dc_MedicalExpression_form_font) {
                dc_MedicalExpression_form_font.value = options.Style.FontName;
            }
        } else {
            options['FontName'] = "";
        }

        //如果存在autosize，就转换成布尔值（用于复选框）
        if (Object.keys(options).indexOf('AutoSize') > -1) {
            options['AutoSize'] = options.AutoSize === true || options.AutoSize === "true";
        } else {
            options['AutoSize'] = true;
        }

        // 设置ID，如果没有则自动生成（仅在配置区域显示时）
        if (showConfigSection) {
            if (!options.ID || options.ID === '') {
                generateRandomId();
            } else if (configId) {
                configId.value = options.ID;
            }

            // 设置自适应大小复选框
            if (configAutoSize) {
                // 判断 AutoSize 是否为 true，如果是则勾选，否则取消勾选
                configAutoSize.checked = options.AutoSize === true || options.AutoSize === "true";
                toggleSizeConfig(); // 初始化宽高配置显示状态
            }

            //回显值（使用旧的GetOrChangeData方法，但需要适配新的结构）
            // 为了兼容，我们需要将新结构的数据映射到旧结构
            var oldOptions = {};
            if (options.ID) oldOptions.ID = options.ID;
            if (options.Width) oldOptions.Width = options.Width;
            if (options.Height) oldOptions.Height = options.Height;
            if (options.FontName) oldOptions.FontName = options.FontName;
            oldOptions.AutoSize = options.AutoSize ? "true" : "false";

            GetOrChangeData(dcPanelBody, oldOptions);

            // 手动设置新结构的值
            if (configId && options.ID) {
                configId.value = options.ID;
            }

            // 如果 AutoSize 为 false，回显宽高值
            if (options.AutoSize === false || options.AutoSize === "false") {
                if (configWidth && options.Width) {
                    configWidth.value = options.Width;
                }
                if (configHeight && options.Height) {
                    configHeight.value = options.Height;
                }
            }

            if (dc_font && dc_font.length > 0 && options.FontName) {
                dc_font.val(options.FontName);
            }
        }

        //选择医学表达式类型的事件
        MedicalExpressionChooseIMGBox.addEventListener('click', function (event) {
            var target = event.target;
            if (target.id === 'MedicalExpressionChooseIMGBox') {
                return;
            }

            // 查找最近的医学表达式容器
            var expressionDiv = null;
            if (target.classList && target.classList.contains("dc_MedicalExpressionChooseDiv")) {
                expressionDiv = target;
            } else {
                // 向上查找，找到包含 dc_MedicalExpressionChooseDiv 类的元素
                var current = target;
                while (current && current !== MedicalExpressionChooseIMGBox) {
                    if (current.classList && current.classList.contains("dc_MedicalExpressionChooseDiv")) {
                        expressionDiv = current;
                        break;
                    }
                    current = current.parentNode;
                }
            }

            if (expressionDiv) {
                //删除上一次选中
                var prevChoose = ctl.ownerDocument && ctl.ownerDocument.querySelector && ctl.ownerDocument.querySelector(".dc_MedicalExpressionChooseDiv_active");
                if (prevChoose) {
                    prevChoose.classList.remove("dc_MedicalExpressionChooseDiv_active");
                }
                // 选中当前项
                expressionDiv.classList.add("dc_MedicalExpressionChooseDiv_active");
                // 保存选中的表达式样式
                selectedExpressionStyle = expressionDiv.getAttribute("expressionStyle");
            }
        });

        function successFun() {
            var chooseDiv = MedicalExpressionChooseIMGBox.querySelector(".dc_MedicalExpressionChooseDiv_active");
            var expressionStyle = chooseDiv && chooseDiv.getAttribute("expressionStyle");
            if (expressionStyle === "FourValues2") {
                //判断是否为视野图公式
                var ISPERIMETRIC = chooseDiv.getAttribute("ISPERIMETRIC");
                if (ISPERIMETRIC && ISPERIMETRIC === 'true') {
                    options.Attributes = {
                        ISPERIMETRIC: "true"
                    };
                }
            }
            options.ExpressionStyle = expressionStyle;

            // 获取新结构的表单值（如果配置区域隐藏，使用默认值）
            var showConfigSection = options.showConfig !== false;
            var expressionId = showConfigSection && configId && configId.value.trim() ? configId.value.trim() : generateRandomId();
            var width = showConfigSection && configWidth && configWidth.value ? parseFloat(configWidth.value) : null;
            var height = showConfigSection && configHeight && configHeight.value ? parseFloat(configHeight.value) : null;
            var font = showConfigSection && dc_font && dc_font.length > 0 && dc_font.val() ? dc_font.val() : (options.FontName || 'Times New Roman');
            var autoSize = showConfigSection && configAutoSize ? configAutoSize.checked : (options.AutoSize !== undefined ? options.AutoSize : true);

            // 设置ID
            options.ID = expressionId;

            // 设置宽高（只有在未勾选自适应大小时才设置）
            if (!autoSize) {
                if (width) options.Width = width;
                if (height) options.Height = height;
            } else {
                // 自适应大小时，清除宽高
                delete options.Width;
                delete options.Height;
            }

            //设置字体
            if (options && options.style) {
                options.style['FontName'] = font;
            } else {
                options.style = {
                    'FontName': font
                };
            }

            //设置自适应大小（布尔值）
            options.AutoSize = autoSize;

            if (options.ExpressionStyle) {
                if (isInsertMode) {
                    ctl.DCExecuteCommand("insertmedicalexpression", false, options);
                } else {
                    ele && ctl.SetElementProperties(ele, options);
                    if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                        var changedOptions = ctl.GetElementProperties(ctl.CurrentElement("XTextNewMedicalExpressionElement"));
                        ctl.EventDialogChangeProperties(changedOptions);
                    };
                }
            }
        }
    },



    // ======医学表达式-end======



    /***
     * Border pattern边框和底纹
     * @param options 单元格属性
     * @param ctl 编辑器元素 
     */
    BorderPatternDialog: function (options, ctl) {
        //获取页面设置属性
        var pageBorder = ctl.GetDocumentPageSettings();
        if (pageBorder && pageBorder.PageBorderBackground) {
            pageBorder = pageBorder.PageBorderBackground;
        }
        if (!pageBorder) {
            pageBorder = {
                BorderRange: "None",
                BorderStyle: "Solid",
                BorderWidth: 1,
                BackgroundColor: "#FFFFFFFF",
                BorderBottomColor: "#000000",
                BorderLeftColor: "#000000",
                BorderRightColor: "#000000",
                BorderTopColor: "#000000",
                LeftBorder: false,
                RightBorder: false,
                TopBorder: false,
                BottomBorder: false
            };
        }
        //获取单元格属性
        var currentCellBorder = {};
        var cells = ctl.GetSelectTableCells();
        if (cells && cells.length === 1) {
            var cell = cells[0];
            if (cells[0] && cells[0].Style) {
                currentCellBorder = cells[0].Style;

            }
        }

        var BorderPatternHtml = `
           <!-- 对话框内容 -->
            <div class="dc_border_pattern_dialog-content">
                <!-- 选项卡 -->
                <div class="dc_border_pattern_tab-container">
                    <div class="dc_border_pattern_tab active" onclick="dc_border_pattern_switchTab('border')">边框(B)
                    </div>
                    <div class="dc_border_pattern_tab" onclick="dc_border_pattern_switchTab('shading')">底纹(S)</div>
                    <div class="dc_border_pattern_tab" onclick="dc_border_pattern_switchTab('page')">页面边框(P)</div>
                </div>

                <!-- 边框选项卡 -->
                <div id="dc_border_pattern_borderTab" class="dc_border_pattern_tab-content active">
                    <div class="dc_border_pattern_border-section">
                        <div class="dc_border_pattern_border-left">
                            <!-- 设置 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">设置</div>
                                <div class="dc_border_pattern_border-style-options">
                                    <div class="dc_border_pattern_border-style-option dc_border_pattern_selected"
                                        onclick="dc_border_pattern_selectBorderType('None')">
                                        <div class="dc_border_pattern_border-style-icon"></div>
                                        <span>无边框</span>
                                    </div>
                                    <div class="dc_border_pattern_border-style-option"
                                        onclick="dc_border_pattern_selectBorderType('Rectangle')">
                                        <div class="dc_border_pattern_border-style-icon">▢</div>
                                        <span>外边框</span>
                                    </div>
                                    <div class="dc_border_pattern_border-style-option"
                                        onclick="dc_border_pattern_selectBorderType('Both')">
                                        <div class="dc_border_pattern_border-style-icon">▦</div>
                                        <span>全部边框</span>
                                    </div>
                                    <div class="dc_border_pattern_border-style-option"
                                        onclick="dc_border_pattern_selectBorderType('Custom')">
                                        <div class="dc_border_pattern_border-style-icon">◐</div>
                                        <span>自定义(U)</span>
                                    </div>
                                </div>
                            </div>

                            <!-- 线型 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">线型(Y)</div>
                                <div class="dc_border_pattern_line-style-container">
                                    <div class="dc_border_pattern_line-style-option dc_border_pattern_selected"
                                        onclick="dc_border_pattern_selectLineStyle('Solid')">
                                        <span>———————Solid</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectLineStyle('Dash')">
                                        <span>------------------Dash</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectLineStyle('Dot')">
                                        <span>▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪Dot</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectLineStyle('DashDot')">
                                        <span>-▪-▪--▪-▪-▪--▪-▪-▪-DashDot</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectLineStyle('DashDotDot')">
                                        <span>-▪▪-▪▪-▪▪-▪▪-▪▪-▪▪-DashDotDot</span>
                                    </div>
                                    
                                </div>
                            </div>

                            <!-- 颜色和宽度设置 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">颜色</div>

                                <!-- 统一颜色设置 -->
                                <div style="margin-bottom: 8px;">
                                    <div class="dc_border_pattern_checkbox-item">
                                        <input type="checkbox" class="dc_border_pattern_checkbox-input"
                                            id="dc_border_pattern_unifiedColorCheck"
                                            onchange="dc_border_pattern_toggleUnifiedColor()" checked>
                                        <span class="dc_border_pattern_checkbox-label">统一颜色</span>
                                    </div>
                                </div>

                                <!-- 统一颜色选择器 -->
                                <div style="display: flex; gap: 8px; align-items: center;"
                                    id="dc_border_pattern_unifiedColorRow">
                                    <div class="dc_border_pattern_color-picker-group" style="flex: 1;">
                                        <select class="dc_border_pattern_color-width-input"
                                            id="dc_border_pattern_unifiedBorderColorSelect"
                                            onchange="dc_border_pattern_updateUnifiedBorderColor()" style="flex: 1;">
                                            <option value="auto" selected>自动</option>
                                            <option value="black">黑色</option>
                                            <option value="red">红色</option>
                                            <option value="blue">蓝色</option>
                                            <option value="green">绿色</option>
                                            <option value="custom">自定义...</option>
                                        </select>
                                        <div class="dc_border_pattern_color-preview"
                                            id="dc_border_pattern_unifiedBorderColorPreview"
                                            style="background-color: #000000;">
                                            <div data-value="" id="dc_border_pattern_unifiedBorderCustomColor"></div>
                                        </div>
                                    </div>
                                    
                                </div>

                                <!-- 单独边框颜色设置 -->
                                <div id="dc_border_pattern_individualColorRows" style="display: none;">
                                    <div class="dc_border_pattern_individual-color-grid">
                                        <span class="dc_border_pattern_border-direction-label">上:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_topBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_topBorderCustomColor"></div>
                                        </div>

                                        <span class="dc_border_pattern_border-direction-label">右:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_rightBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_rightBorderCustomColor"></div>
                                        </div>

                                        <span class="dc_border_pattern_border-direction-label">下:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_bottomBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_bottomBorderCustomColor"></div>
                                        </div>

                                        <span class="dc_border_pattern_border-direction-label">左:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_leftBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_leftBorderCustomColor"></div>
                                        </div>
                                    </div>
                                   
                                </div>
                                <div class="dc_border_pattern_setting-title">宽度</div>
                                <div style="width: 100%;">
                                    <input type="number"
                                        class="dc_border_pattern_width-input"
                                        id="dc_border_pattern_borderWidthSelect"
                                        value="1"
                                        min="0"
                                        max="1000"
                                        step="1"
                                        oninput="dc_border_pattern_updateBorderWidth()"
                                        onchange="dc_border_pattern_updateBorderWidth()"
                                        placeholder="1">
                                </div>
                                <div id="dc_border_pattern_borderWidthUnit" class="dc_border_pattern_width-unit" style="text-align: right; color: red; font-weight: 500;">≈0.08mm</div>
                            </div>
                        </div>

                        <div class="dc_border_pattern_border-right">
                            <!-- 预览区域 -->
                            <div class="dc_border_pattern_preview-section">
                                <div class="dc_border_pattern_preview-title">预览</div>
                                <div class="dc_border_pattern_preview-instruction">单击下方图示或按钮可设置边框</div>

                                <div class="dc_border_pattern_preview-area">
                                    <div class="dc_border_pattern_preview-container">
                                        <div class="dc_border_pattern_preview-table-container">
                                            <!-- 左侧纵向排列的横线按钮 -->
                                            <div class="dc_border_pattern_preview-left-column">
                                                <div class="dc_border_pattern_preview-button"
                                                    onclick="dc_border_pattern_toggleBorder('top')" title="上边框">─</div>
                                                <div class="dc_border_pattern_preview-button"
                                                    onclick="dc_border_pattern_toggleBorder('innerH')" title="内部水平线">─</div>
                                                <div class="dc_border_pattern_preview-button"
                                                    onclick="dc_border_pattern_toggleBorder('bottom')" title="下边框">─</div>
                                            </div>
                                            
                                            <!-- 表格 -->
                                            <table class="dc_border_pattern_preview-table"
                                                id="dc_border_pattern_borderPreviewTable">
                                                <tr>
                                                    <td>A</td>
                                                    <td>B</td>
                                                </tr>
                                                <tr>
                                                    <td>C</td>
                                                    <td>D</td>
                                                </tr>
                                            </table>
                                        </div>
                                        
                                        <!-- 底部横向排列的竖线按钮 -->
                                        <div class="dc_border_pattern_preview-bottom-row">
                                            <div class="dc_border_pattern_preview-button"
                                                onclick="dc_border_pattern_toggleBorder('left')" title="左边框">│</div>
                                            <div class="dc_border_pattern_preview-button"
                                                onclick="dc_border_pattern_toggleBorder('innerV')" title="内部垂直线">│</div>
                                            <div class="dc_border_pattern_preview-button"
                                                onclick="dc_border_pattern_toggleBorder('right')" title="右边框">│</div>
                                        </div>
                                    </div>
                                </div>
                      

                                <!-- 应用于设置 -->
                                <div class="dc_border_pattern_apply-to-group">
                                    <span class="dc_border_pattern_apply-to-label">应用于</span>
                                    <select class="dc_border_pattern_apply-to-select"
                                        id="dc_border_pattern_borderApplyToSelect"
                                        onchange="dc_border_pattern_handleApplyToChange()">
                                        <option value="Cell" selected>单元格</option>
                                        <option value="Table">表格</option>
                                        <option value="Text">输入域</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- 底纹选项卡 -->
                <div id="dc_border_pattern_shadingTab" class="dc_border_pattern_tab-content">
                    <div class="dc_border_pattern_shading-section">
                        <div class="dc_border_pattern_shading-left">
                            <!-- 填充颜色 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">填充颜色</div>
                                <div class="dc_border_pattern_color-grid" id="dc_border_pattern_fillColorGrid">
                                    <div class="dc_border_pattern_color-option" style="background-color: #ffffff;"
                                        onclick="dc_border_pattern_selectFillColor('#ffffff')" title="无填充"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #000000;"
                                        onclick="dc_border_pattern_selectFillColor('#000000')" title="黑色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #808080;"
                                        onclick="dc_border_pattern_selectFillColor('#808080')" title="深灰"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #c0c0c0;"
                                        onclick="dc_border_pattern_selectFillColor('#c0c0c0')" title="浅灰"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #ff0000;"
                                        onclick="dc_border_pattern_selectFillColor('#ff0000')" title="红色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #008000;"
                                        onclick="dc_border_pattern_selectFillColor('#008000')" title="绿色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #0000ff;"
                                        onclick="dc_border_pattern_selectFillColor('#0000ff')" title="蓝色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #ffff00;"
                                        onclick="dc_border_pattern_selectFillColor('#ffff00')" title="黄色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #ffa500;"
                                        onclick="dc_border_pattern_selectFillColor('#ffa500')" title="橙色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #800080;"
                                        onclick="dc_border_pattern_selectFillColor('#800080')" title="紫色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #00ffff;"
                                        onclick="dc_border_pattern_selectFillColor('#00ffff')" title="青色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #ffc0cb;"
                                        onclick="dc_border_pattern_selectFillColor('#ffc0cb')" title="粉色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #f0f8ff;"
                                        onclick="dc_border_pattern_selectFillColor('#f0f8ff')" title="淡蓝"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #f5f5dc;"
                                        onclick="dc_border_pattern_selectFillColor('#f5f5dc')" title="米色"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #ffe4e1;"
                                        onclick="dc_border_pattern_selectFillColor('#ffe4e1')" title="淡粉"></div>
                                    <div class="dc_border_pattern_color-option" style="background-color: #e6ffe6;"
                                        onclick="dc_border_pattern_selectFillColor('#e6ffe6')" title="淡绿"></div>
                                    <!-- 自定义颜色选项 -->
                                    <div class="dc_border_pattern_color-option dc_border_pattern_custom-color-option"
                                        id="dc_border_pattern_customFillColor" title="自定义颜色">
                                        <span
                                            style="font-size: 16px; color: #666; position: relative; z-index: 1; pointer-events: none;">+</span>
                                        <input type="color" id="dc_border_pattern_fillCustomColorInput"
                                            class="dc_border_pattern_color-input-hidden"
                                            onchange="dc_border_pattern_updateCustomFillColor()">
                                    </div>
                                </div>

                                <!-- 当前颜色显示 -->
                                <div class="dc_border_pattern_current-color-display">
                                    <div class="dc_border_pattern_current-color-label">当前选择：</div>
                                    <div class="dc_border_pattern_current-color-info">
                                        <div class="dc_border_pattern_current-color-preview"
                                            id="dc_border_pattern_currentFillColorPreview"></div>
                                        <div class="dc_border_pattern_current-color-value"
                                            id="dc_border_pattern_currentFillColorValue">
                                            #FFFFFF</div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="dc_border_pattern_shading-right">
                            <!-- 预览区域 -->
                            <div class="dc_border_pattern_preview-section">
                                <div class="dc_border_pattern_preview-title">预览</div>
                                <div class="dc_border_pattern_preview-area">
                                    <table class="dc_border_pattern_preview-table"
                                        id="dc_border_pattern_shadingPreviewTable">
                                        <tr>
                                            <td>A</td>
                                            <td>B</td>
                                        </tr>
                                        <tr>
                                            <td>C</td>
                                            <td>D</td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- 页面边框选项卡 -->
                <div id="dc_border_pattern_pageTab" class="dc_border_pattern_tab-content">
                    <div class="dc_border_pattern_page-border-section">
                        <div class="dc_border_pattern_page-border-left">
                            <!-- 边框类型 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">边框类型</div>
                                <div class="dc_border_pattern_radio-group" style="flex-direction: column; gap: 8px;">
                                    <label class="dc_border_pattern_radio-item">
                                        <input type="radio" name="dc_border_pattern_pageBorderType" value="None"
                                            class="dc_border_pattern_radio-input" checked
                                            onchange="dc_border_pattern_selectPageBorderTypeRadio('None')">
                                        <span class="dc_border_pattern_radio-label">无边框</span>
                                    </label>
                                    <label class="dc_border_pattern_radio-item">
                                        <input type="radio" name="dc_border_pattern_pageBorderType" value="Body"
                                            class="dc_border_pattern_radio-input"
                                            onchange="dc_border_pattern_selectPageBorderTypeRadio('Body')">
                                        <span class="dc_border_pattern_radio-label">正文边框</span>
                                    </label>
                                    <label class="dc_border_pattern_radio-item">
                                        <input type="radio" name="dc_border_pattern_pageBorderType" value="Page"
                                            class="dc_border_pattern_radio-input"
                                            onchange="dc_border_pattern_selectPageBorderTypeRadio('Page')">
                                        <span class="dc_border_pattern_radio-label">页面边框</span>
                                    </label>
                                    
                                </div>
                            </div>

                            <!-- 线型 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">边框线型</div>
                                <div class="dc_border_pattern_line-style-container">
                                    <div class="dc_border_pattern_line-style-option dc_border_pattern_selected"
                                        onclick="dc_border_pattern_selectPageLineStyle('Solid')">
                                        <div class="dc_border_pattern_line-style-preview"
                                            style="border-top: 1px solid #000;"></div>
                                        <span>———————Solid</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectPageLineStyle('Dash')">
                                        <div class="dc_border_pattern_line-style-preview"
                                            style="border-top: 1px dashed #000;"></div>
                                        <span>------------------Dash</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectPageLineStyle('Dot')">
                                        <div class="dc_border_pattern_line-style-preview"
                                            style="border-top: 1px dotted #000;"></div>
                                        <span>▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪▪Dot</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectPageLineStyle('DashDot')">
                                        <div class="dc_border_pattern_line-style-preview"
                                            style="border-top: 1px dashed #000; background-image: repeating-linear-gradient(to right, transparent 0px, transparent 8px, #000 8px, #000 9px, transparent 9px, transparent 12px, #000 12px, #000 13px); background-size: 20px 1px;">
                                        </div>
                                        <span>-▪-▪--▪-▪-▪--▪-▪-▪-DashDot</span>
                                    </div>
                                    <div class="dc_border_pattern_line-style-option"
                                        onclick="dc_border_pattern_selectPageLineStyle('DashDotDot')">
                                        <div class="dc_border_pattern_line-style-preview"
                                            style="border-top: 1px dashed #000; background-image: repeating-linear-gradient(to right, transparent 0px, transparent 8px, #000 8px, #000 9px, transparent 9px, transparent 10px, #000 10px, #000 11px, transparent 11px, transparent 12px, #000 12px, #000 13px, transparent 13px, transparent 16px); background-size: 24px 1px;">
                                        </div>
                                        <span>-▪▪-▪▪-▪▪-▪▪-▪▪-▪▪-DashDotDot</span>
                                    </div>
                                </div>
                            </div>

                            <!-- 边框颜色 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">边框颜色</div>

                                <!-- 统一颜色设置 -->
                                <div style="margin-bottom: 8px;">
                                    <div class="dc_border_pattern_checkbox-item">
                                        <input type="checkbox" class="dc_border_pattern_checkbox-input"
                                            id="dc_border_pattern_pageUnifiedColorCheck"
                                            onchange="dc_border_pattern_togglePageUnifiedColor()" checked>
                                        <span class="dc_border_pattern_checkbox-label">统一颜色</span>
                                    </div>
                                </div>

                                <!-- 统一颜色选择器 -->
                                <div style="display: flex; gap: 8px; align-items: center;"
                                    id="dc_border_pattern_pageUnifiedColorRow">
                                    <div class="dc_border_pattern_color-picker-group" style="flex: 1;">
                                        <select class="dc_border_pattern_color-width-input"
                                            id="dc_border_pattern_pageBorderColorSelect"
                                            onchange="dc_border_pattern_updatePageBorderColor()" style="flex: 1;">
                                            <option value="auto" selected>自动</option>
                                            <option value="black">黑色</option>
                                            <option value="red">红色</option>
                                            <option value="blue">蓝色</option>
                                            <option value="green">绿色</option>
                                            <option value="custom">自定义...</option>
                                        </select>
                                        <div class="dc_border_pattern_color-preview"
                                            id="dc_border_pattern_pageBorderColorPreview"
                                            style="background-color: #000000;">
                                            <div data-value="" id="dc_border_pattern_pageBorderCustomColor"></div>
                                        </div>
                                    </div>
                                </div>

                                <!-- 单独边框颜色设置 -->
                                <div id="dc_border_pattern_pageIndividualColorRows" style="display: none;">
                                    <div class="dc_border_pattern_individual-color-grid">
                                        <span class="dc_border_pattern_border-direction-label">上:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_pageTopBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_pageTopBorderCustomColor"></div>
                                        </div>

                                        <span class="dc_border_pattern_border-direction-label">右:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_pageRightBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_pageRightBorderCustomColor"></div>
                                        </div>

                                        <span class="dc_border_pattern_border-direction-label">下:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_pageBottomBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_pageBottomBorderCustomColor"></div>
                                        </div>

                                        <span class="dc_border_pattern_border-direction-label">左:</span>
                                        <div class="dc_border_pattern_color-preview dc_border_pattern_border-color-preview-mini"
                                            id="dc_border_pattern_pageLeftBorderColorPreview">
                                            <div data-value="" id="dc_border_pattern_pageLeftBorderCustomColor"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <!-- 边框宽度 -->
                            <div class="dc_border_pattern_setting-group">
                                <div class="dc_border_pattern_setting-title">宽度</div>
                                <div style="width: 100%;">
                                    <input type="number"
                                        class="dc_border_pattern_width-input"
                                        id="dc_border_pattern_pageBorderWidthSelect"
                                        value="1"
                                        min="0"
                                        max="1000"
                                        step="1"
                                        oninput="dc_border_pattern_updatePageBorderWidth()"
                                        onchange="dc_border_pattern_updatePageBorderWidth()"
                                        placeholder="1">
                                </div>
                                <div id="dc_border_pattern_pageBorderWidthUnit" class="dc_border_pattern_width-unit" style="text-align: right; color: red; font-weight: 500;">≈0.08mm</div>

                            </div>
                        </div>

                        <div class="dc_border_pattern_page-border-right">
                            <!-- 预览区域 -->
                            <div class="dc_border_pattern_preview-section">
                                <div class="dc_border_pattern_preview-title">预览</div>
                                <div class="dc_border_pattern_preview-instruction">单击下方按钮可设置边框</div>

                                <div class="dc_border_pattern_preview-area">
                                    <!-- 页面边框预览 -->
                                    <div id="dc_border_pattern_pageOuterBorder"
                                        style="width: 140px; height: 180px; border: 1px solid #e0e0e0; display: flex; align-items: center; justify-content: center; background: #f9f9f9; border-radius: 4px; position: relative; margin: 0 auto;">
                                        <!-- 正文边框预览 -->
                                        <div id="dc_border_pattern_contentBorder"
                                            style="position: absolute; display: none; width: 90px; height: 130px; border: 2px dashed #999; background: rgba(255, 255, 255, 0.9);">
                                        </div>
                                        <div style="font-size: 10px; color: #666; text-align: center; line-height: 1.4; z-index: 1;">
                                            <div id="dc_border_pattern_borderTypeLabel">无边框</div>
                                            <div style="margin-top: 8px; font-size: 9px; color: #999;">预览示例</div>
                                        </div>
                                    </div>

                                    <!-- 边框控制按钮 -->
                                    <div class="dc_border_pattern_page-border-buttons">
                                        <button class="dc_border_pattern_page-border-btn"
                                            onclick="dc_border_pattern_togglePageBorder('top')" title="上边框">
                                            上
                                        </button>
                                        <button class="dc_border_pattern_page-border-btn"
                                            onclick="dc_border_pattern_togglePageBorder('left')" title="左边框">
                                            左
                                        </button>
                                        <button class="dc_border_pattern_page-border-btn"
                                            onclick="dc_border_pattern_togglePageBorder('bottom')" title="下边框">
                                            下
                                        </button>
                                        <button class="dc_border_pattern_page-border-btn"
                                            onclick="dc_border_pattern_togglePageBorder('right')" title="右边框">
                                            右
                                        </button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        `;
        var dialogOptions = {
            title: "边框和底纹",
            bodyHeight: 450,
            dialogContainerBodyWidth: 560,
            bodyClass: "BorderPattern",
            bodyHtml: BorderPatternHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions, null, false);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        // 全局状态
        let dc_border_pattern_currentTab = 'border';

        // 辅助函数：处理颜色字符串（去除透明度）
        function processColorString(colorString) {
            if (!colorString) return '#000000';
            // 如果是 #RRGGBBAA 格式，去掉最后两位透明度
            if (colorString.length === 9 && colorString.startsWith('#')) {
                return colorString.substring(0, 7);
            }
            return colorString;
        }

        // 从单元格边框数据初始化设置
        let dc_border_pattern_borderSettings = {
            type: 'None',
            style: 'Solid',
            color: 'auto',
            customColor: '#000000',
            width: 1,
            borders: {
                top: false,
                right: false,
                bottom: false,
                left: false,
                innerH: false,
                innerV: false,
                outer: false
            },
            colors: {
                top: { value: 'auto', custom: '#000000' },
                right: { value: 'auto', custom: '#000000' },
                bottom: { value: 'auto', custom: '#000000' },
                left: { value: 'auto', custom: '#000000' }
            }
        };

        // 如果有单元格边框数据，复显到对话框
        if (currentCellBorder && Object.keys(currentCellBorder).length > 0) {
            // 边框样式
            if (currentCellBorder.BorderStyle) {
                dc_border_pattern_borderSettings.style = currentCellBorder.BorderStyle;
            }

            // 边框宽度
            if (currentCellBorder.BorderWidth !== undefined) {
                dc_border_pattern_borderSettings.width = currentCellBorder.BorderWidth;
            }

            // 边框状态
            if (currentCellBorder.BorderTop !== undefined) {
                dc_border_pattern_borderSettings.borders.top = currentCellBorder.BorderTop;
            }
            if (currentCellBorder.BorderRight !== undefined) {
                dc_border_pattern_borderSettings.borders.right = currentCellBorder.BorderRight;
            }
            if (currentCellBorder.BorderBottom !== undefined) {
                dc_border_pattern_borderSettings.borders.bottom = currentCellBorder.BorderBottom;
            }
            if (currentCellBorder.BorderLeft !== undefined) {
                dc_border_pattern_borderSettings.borders.left = currentCellBorder.BorderLeft;
            }

            // 边框颜色
            if (currentCellBorder.BorderTopColorString) {
                const topColor = processColorString(currentCellBorder.BorderTopColorString);
                dc_border_pattern_borderSettings.colors.top = { value: 'custom', custom: topColor };
            }
            if (currentCellBorder.BorderRightColorString) {
                const rightColor = processColorString(currentCellBorder.BorderRightColorString);
                dc_border_pattern_borderSettings.colors.right = { value: 'custom', custom: rightColor };
            }
            if (currentCellBorder.BorderBottomColorString) {
                const bottomColor = processColorString(currentCellBorder.BorderBottomColorString);
                dc_border_pattern_borderSettings.colors.bottom = { value: 'custom', custom: bottomColor };
            }
            if (currentCellBorder.BorderLeftColorString) {
                const leftColor = processColorString(currentCellBorder.BorderLeftColorString);
                dc_border_pattern_borderSettings.colors.left = { value: 'custom', custom: leftColor };
            }

            // 判断边框类型
            const hasTop = dc_border_pattern_borderSettings.borders.top;
            const hasRight = dc_border_pattern_borderSettings.borders.right;
            const hasBottom = dc_border_pattern_borderSettings.borders.bottom;
            const hasLeft = dc_border_pattern_borderSettings.borders.left;

            if (hasTop && hasRight && hasBottom && hasLeft) {
                dc_border_pattern_borderSettings.type = 'Rectangle';
            } else if (hasTop || hasRight || hasBottom || hasLeft) {
                dc_border_pattern_borderSettings.type = 'Custom';
            } else {
                dc_border_pattern_borderSettings.type = 'None';
            }
        }

        let dc_border_pattern_shadingSettings = {
            fillColor: pageBorder.BackgroundColor || '#ffffff'
        };

        // 如果有单元格背景色，使用单元格背景色
        if (currentCellBorder && currentCellBorder.BackgroundColorString) {
            dc_border_pattern_shadingSettings.fillColor = processColorString(currentCellBorder.BackgroundColorString);
        }

        // 从获取的页面边框数据初始化设置
        let dc_border_pattern_pageBorderSettings = {
            type: pageBorder.BorderRange || 'None', // None: 无边框, Page: 页面边框, Body: 正文边框
            style: pageBorder.BorderStyle || 'Solid',
            color: 'auto',
            customColor: '#000000',
            width: pageBorder.BorderWidth || 1,
            borders: {
                top: pageBorder.TopBorder || false,
                right: pageBorder.RightBorder || false,
                bottom: pageBorder.BottomBorder || false,
                left: pageBorder.LeftBorder || false
            },
            colors: {
                top: { value: 'custom', custom: pageBorder.BorderTopColor || '#000000' },
                right: { value: 'custom', custom: pageBorder.BorderRightColor || '#000000' },
                bottom: { value: 'custom', custom: pageBorder.BorderBottomColor || '#000000' },
                left: { value: 'custom', custom: pageBorder.BorderLeftColor || '#000000' }
            }
        };


        // 切换选项卡
        window.dc_border_pattern_switchTab = function (tabName) {
            // 隐藏所有选项卡内容
            jQuery(dcPanelBody).find('.dc_border_pattern_tab-content').removeClass('active');

            // 移除所有选项卡的激活状态
            jQuery(dcPanelBody).find('.dc_border_pattern_tab').removeClass('active');

            // 显示选中的选项卡
            jQuery(dcPanelBody).find('#dc_border_pattern_' + tabName + 'Tab').addClass('active');
            jQuery(event.target).addClass('active');

            dc_border_pattern_currentTab = tabName;
        };

        // 切换统一/单独颜色设置
        window.dc_border_pattern_toggleUnifiedColor = function () {
            const isUnified = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedColorCheck').is(':checked');
            jQuery(dcPanelBody).find('#dc_border_pattern_unifiedColorRow').css('display', isUnified ? 'flex' : 'none');
            jQuery(dcPanelBody).find('#dc_border_pattern_individualColorRows').css('display', isUnified ? 'none' : 'block');
        };

        // 更新统一边框颜色
        window.dc_border_pattern_updateUnifiedBorderColor = function () {
            const colorSelect = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderColorSelect')[0];
            const colorPreview = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderColorPreview')[0];
            const customColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderCustomColor')[0];
            const value = colorSelect.value;

            if (value === 'custom') {
                // 显示颜色选择器
                if (customColorBox) {
                    customColorBox.click();
                }
            } else {
                const color = dc_border_pattern_getColorValue(value, '#000000');
                colorPreview.style.backgroundColor = color;
                if (customColorBox) {
                    customColorBox.style.backgroundColor = color;
                    customColorBox.setAttribute('data-value', color);
                }

                // 应用到所有边框
                ['top', 'right', 'bottom', 'left'].forEach(direction => {
                    dc_border_pattern_borderSettings.colors[direction].value = value;
                    dc_border_pattern_borderSettings.colors[direction].custom = color;
                    const preview = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderColorPreview')[0];
                    const colorBox = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderCustomColor')[0];
                    if (preview) {
                        preview.style.backgroundColor = color;
                    }
                    if (colorBox) {
                        colorBox.style.backgroundColor = color;
                        colorBox.setAttribute('data-value', color);
                    }
                });

                dc_border_pattern_updateBorderPreview();
            }
        };

        // 更新统一边框自定义颜色
        window.dc_border_pattern_updateUnifiedBorderCustomColor = function (color) {
            const customColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderCustomColor')[0];
            const colorPreview = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderColorPreview')[0];
            const colorSelect = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderColorSelect')[0];

            // 如果没有传入颜色，从元素获取
            if (!color && customColorBox) {
                color = customColorBox.getAttribute('data-value') ||
                    window.getComputedStyle(customColorBox).backgroundColor || '#000000';
            }

            colorSelect.value = 'custom';
            if (colorPreview) {
                colorPreview.style.backgroundColor = color;
            }
            if (customColorBox) {
                customColorBox.style.backgroundColor = color;
                customColorBox.setAttribute('data-value', color);
            }

            // 应用到所有边框
            ['top', 'right', 'bottom', 'left'].forEach(direction => {
                dc_border_pattern_borderSettings.colors[direction].value = 'custom';
                dc_border_pattern_borderSettings.colors[direction].custom = color;
                const preview = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderColorPreview')[0];
                const colorBox = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderCustomColor')[0];
                if (preview) {
                    preview.style.backgroundColor = color;
                }
                if (colorBox) {
                    colorBox.style.backgroundColor = color;
                    colorBox.setAttribute('data-value', color);
                }
            });

            dc_border_pattern_updateBorderPreview();
        };

        // 获取颜色值
        function dc_border_pattern_getColorValue(colorName, defaultColor) {
            const colorMap = {
                'auto': '#000000',
                'black': '#000000',
                'white': '#ffffff',
                'red': '#ff0000',
                'green': '#008000',
                'blue': '#0000ff',
                'yellow': '#ffff00',
                'gray': '#808080',
                'orange': '#ffa500',
                'purple': '#800080',
                'cyan': '#00ffff',
                'pink': '#ffc0cb'
            };
            return colorMap[colorName] || defaultColor;
        }

        // 处理"应用于"下拉框变更
        window.dc_border_pattern_handleApplyToChange = function () {
            const applyToSelect = jQuery(dcPanelBody).find('#dc_border_pattern_borderApplyToSelect')[0];
            const applyToValue = applyToSelect ? applyToSelect.value : 'Cell';

            // 更新边框类型选项的可用状态
            dc_border_pattern_updateBorderTypeOptions(applyToValue);
        };

        // 更新边框类型选项的可用状态
        function dc_border_pattern_updateBorderTypeOptions(applyToValue) {
            // "全部边框"选项
            const bothOption = jQuery(dcPanelBody).find('[onclick*="selectBorderType(\'Both\')"]');
            if (bothOption.length > 0) {
                if (applyToValue === 'Text') {
                    bothOption.css('opacity', '0.5');
                    bothOption.css('pointer-events', 'none');
                    bothOption.css('cursor', 'not-allowed');
                } else {
                    bothOption.css('opacity', '1');
                    bothOption.css('pointer-events', 'auto');
                    bothOption.css('cursor', 'pointer');
                }
            }

            // "自定义"选项
            const customOption = jQuery(dcPanelBody).find('[onclick*="selectBorderType(\'Custom\')"]');
            if (customOption.length > 0) {
                if (applyToValue === 'Text') {
                    customOption.css('opacity', '0.5');
                    customOption.css('pointer-events', 'none');
                    customOption.css('cursor', 'not-allowed');
                } else {
                    customOption.css('opacity', '1');
                    customOption.css('pointer-events', 'auto');
                    customOption.css('cursor', 'pointer');
                }
            }

            // 内部水平线按钮
            const innerHButton = jQuery(dcPanelBody).find('[onclick*="dc_border_pattern_toggleBorder(\'innerH\')"]');
            if (innerHButton.length > 0) {
                if (applyToValue === 'Text') {
                    innerHButton.css('opacity', '0.5');
                    innerHButton.css('pointer-events', 'none');
                    innerHButton.css('cursor', 'not-allowed');
                } else {
                    innerHButton.css('opacity', '1');
                    innerHButton.css('pointer-events', 'auto');
                    innerHButton.css('cursor', 'pointer');
                }
            }

            // 内部垂直线按钮
            const innerVButton = jQuery(dcPanelBody).find('[onclick*="dc_border_pattern_toggleBorder(\'innerV\')"]');
            if (innerVButton.length > 0) {
                if (applyToValue === 'Text') {
                    innerVButton.css('opacity', '0.5');
                    innerVButton.css('pointer-events', 'none');
                    innerVButton.css('cursor', 'not-allowed');
                } else {
                    innerVButton.css('opacity', '1');
                    innerVButton.css('pointer-events', 'auto');
                    innerVButton.css('cursor', 'pointer');
                }
            }

            // 如果当前选择的是"Text"，且当前边框类型是"Both"或"Custom"，则切换到"无边框"
            if (applyToValue === 'Text') {
                if (dc_border_pattern_borderSettings.type === 'Both' || dc_border_pattern_borderSettings.type === 'Custom') {
                    dc_border_pattern_selectBorderType('None');
                }
                // 禁用内部线
                dc_border_pattern_borderSettings.borders.innerH = false;
                dc_border_pattern_borderSettings.borders.innerV = false;
                dc_border_pattern_updateBorderPreviewButtons();
                dc_border_pattern_updateBorderPreview();
            }
        }

        // 边框相关函数
        window.dc_border_pattern_selectBorderType = function (type) {
            // 检查是否选择了"输入域"，如果是，则只允许"None"和"Rectangle"
            const applyToSelect = jQuery(dcPanelBody).find('#dc_border_pattern_borderApplyToSelect')[0];
            const applyToValue = applyToSelect ? applyToSelect.value : 'Cell';

            if (applyToValue === 'Text' && (type === 'Both' || type === 'Custom')) {
                // 如果选择的是"输入域"，不允许选择"全部边框"或"自定义"
                return;
            }

            dc_border_pattern_borderSettings.type = type;

            // 更新选中状态
            jQuery(dcPanelBody).find('.dc_border_pattern_border-style-option').removeClass('dc_border_pattern_selected');
            // 查找对应的边框类型选项并添加选中状态
            const targetOption = jQuery(dcPanelBody).find(`[onclick*="selectBorderType('${type}')"]`).first();
            if (targetOption.length > 0) {
                targetOption.addClass('dc_border_pattern_selected');
            } else if (window.event && window.event.target) {
                // 如果找不到，尝试使用event.target（用于onclick调用）
                jQuery(window.event.target).closest('.dc_border_pattern_border-style-option').addClass('dc_border_pattern_selected');
            }

            // 根据类型设置默认边框
            switch (type) {
                case 'None':
                    Object.keys(dc_border_pattern_borderSettings.borders).forEach(key => {
                        dc_border_pattern_borderSettings.borders[key] = false;
                    });
                    break;
                case 'Rectangle':
                    dc_border_pattern_borderSettings.borders = {
                        top: true, right: true, bottom: true, left: true,
                        innerH: false, innerV: false, outer: false
                    };
                    break;
                case 'Both':
                    Object.keys(dc_border_pattern_borderSettings.borders).forEach(key => {
                        dc_border_pattern_borderSettings.borders[key] = true;
                    });
                    break;
                case 'Custom':
                    // 保持当前设置，但需要更新按钮状态
                    break;
            }

            dc_border_pattern_updateBorderPreviewButtons();
            dc_border_pattern_updateBorderPreview();
        };

        window.dc_border_pattern_selectLineStyle = function (style) {
            dc_border_pattern_borderSettings.style = style;

            // 更新选中状态
            jQuery(dcPanelBody).find('.dc_border_pattern_line-style-option').removeClass('dc_border_pattern_selected');
            jQuery(event.target).closest('.dc_border_pattern_line-style-option').addClass('dc_border_pattern_selected');

            dc_border_pattern_updateBorderPreview();
        };

        // 获取CSS线型样式
        function dc_border_pattern_getLineStyleCSS(style) {
            switch (style) {
                case 'Solid':
                    return 'solid';
                case 'Dash':
                    return 'dashed';
                case 'Dot':
                    return 'dotted';
                case 'DashDot':
                    return 'dashed'; // 使用dashed作为基础，配合background-image
                case 'DashDotDot':
                    return 'dashed'; // 使用dashed作为基础，配合background-image
                default:
                    return 'solid';
            }
        }


        // 更新方向边框自定义颜色
        window.dc_border_pattern_updateBorderDirectionCustomColor = function (direction, color) {
            const customColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderCustomColor')[0];
            const colorPreview = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderColorPreview')[0];

            // 如果没有传入颜色，从元素获取
            if (!color && customColorBox) {
                color = customColorBox.getAttribute('data-value') ||
                    window.getComputedStyle(customColorBox).backgroundColor || '#000000';
            }

            dc_border_pattern_borderSettings.colors[direction].custom = color;
            dc_border_pattern_borderSettings.colors[direction].value = 'custom';

            if (colorPreview) {
                colorPreview.style.backgroundColor = color;
            }
            if (customColorBox) {
                customColorBox.style.backgroundColor = color;
                customColorBox.setAttribute('data-value', color);
            }

            dc_border_pattern_updateBorderPreview();
        };

        // 获取方向边框颜色值
        function dc_border_pattern_getBorderDirectionColorValue(direction) {
            const colorMap = {
                'auto': '#000000',
                'black': '#000000',
                'white': '#ffffff',
                'red': '#ff0000',
                'green': '#008000',
                'blue': '#0000ff',
                'yellow': '#ffff00',
                'gray': '#808080',
                'orange': '#ffa500',
                'purple': '#800080',
                'cyan': '#00ffff',
                'pink': '#ffc0cb',
                'custom': dc_border_pattern_borderSettings.colors[direction].custom
            };
            return colorMap[dc_border_pattern_borderSettings.colors[direction].value] || '#000000';
        }

        window.dc_border_pattern_updateBorderWidth = function () {
            const widthInput = jQuery(dcPanelBody).find('#dc_border_pattern_borderWidthSelect')[0];
            const widthUnitDisplay = jQuery(dcPanelBody).find('#dc_border_pattern_borderWidthUnit')[0];

            if (widthInput) {
                // 获取输入值并转换为三百分之一英寸
                const value = parseInt(widthInput.value) || 0;
                dc_border_pattern_borderSettings.width = value;

                // 更新单位显示
                if (widthUnitDisplay) {
                    if (value === 0) {
                        widthUnitDisplay.style.display = 'none';
                    } else {
                        widthUnitDisplay.style.display = '';
                        // 计算毫米值：1个单位 = 1/300英寸 = 25.4/300毫米
                        const millimeters = (value * 25.4 / 300).toFixed(2);
                        widthUnitDisplay.textContent = '≈' + millimeters + 'mm';
                    }
                }
            }

            dc_border_pattern_updateBorderPreview();
        };

        window.dc_border_pattern_toggleBorder = function (borderType) {
            // 检查是否选择了"输入域"，如果是，则不允许切换内部线
            const applyToSelect = jQuery(dcPanelBody).find('#dc_border_pattern_borderApplyToSelect')[0];
            const applyToValue = applyToSelect ? applyToSelect.value : 'Cell';

            if (applyToValue === 'Text' && (borderType === 'innerH' || borderType === 'innerV')) {
                // 如果选择的是"输入域"，不允许切换内部水平线或内部垂直线
                return;
            }

            if (dc_border_pattern_borderSettings.type === 'Custom') {
                dc_border_pattern_borderSettings.borders[borderType] = !dc_border_pattern_borderSettings.borders[borderType];
                dc_border_pattern_updateBorderPreviewButtons();
                dc_border_pattern_updateBorderPreview();
            }
        };

        function dc_border_pattern_updateBorderPreviewButtons() {
            Object.keys(dc_border_pattern_borderSettings.borders).forEach(borderType => {
                const button = jQuery(dcPanelBody).find(`[onclick="dc_border_pattern_toggleBorder('${borderType}')"]`)[0];
                if (button) {
                    if (dc_border_pattern_borderSettings.borders[borderType]) {
                        jQuery(button).addClass('active');
                    } else {
                        jQuery(button).removeClass('active');
                    }
                }
            });
        }


        function dc_border_pattern_updateBorderPreview() {
            const table = jQuery(dcPanelBody).find('#dc_border_pattern_borderPreviewTable')[0];
            if (!table) return;
            const cells = table.querySelectorAll('td');
            // 预览使用固定宽度，不需要精确转换，只显示大概效果
            const width = '2px';
            const lineStyle = dc_border_pattern_getLineStyleCSS(dc_border_pattern_borderSettings.style);

            // 清除所有边框
            cells.forEach(cell => {
                cell.style.border = 'none';
                cell.style.backgroundColor = 'white';
                cell.style.backgroundImage = 'none';
            });
            table.style.border = 'none';
            table.style.backgroundImage = 'none';

            // 应用边框
            if (dc_border_pattern_borderSettings.type !== 'none') {
                // 应用单元格边框 - 分别处理每个边
                cells.forEach((cell, index) => {
                    const row = Math.floor(index / 2);
                    const col = index % 2;

                    // 上边框：第一行的单元格
                    if (dc_border_pattern_borderSettings.borders.top && row === 0) {
                        const color = dc_border_pattern_getBorderDirectionColorValue('top');
                        cell.style.borderTop = `${width} ${lineStyle} ${color}`;
                    }

                    // 下边框：最后一行的单元格
                    if (dc_border_pattern_borderSettings.borders.bottom && row === 1) {
                        const color = dc_border_pattern_getBorderDirectionColorValue('bottom');
                        cell.style.borderBottom = `${width} ${lineStyle} ${color}`;
                    }

                    // 左边框：第一列的单元格
                    if (dc_border_pattern_borderSettings.borders.left && col === 0) {
                        const color = dc_border_pattern_getBorderDirectionColorValue('left');
                        cell.style.borderLeft = `${width} ${lineStyle} ${color}`;
                    }

                    // 右边框：最后一列的单元格
                    if (dc_border_pattern_borderSettings.borders.right && col === 1) {
                        const color = dc_border_pattern_getBorderDirectionColorValue('right');
                        cell.style.borderRight = `${width} ${lineStyle} ${color}`;
                    }

                    // 内部水平线：第一行的下边框（在top和bottom之间）
                    if (dc_border_pattern_borderSettings.borders.innerH && row === 0) {
                        const color = dc_border_pattern_getBorderDirectionColorValue('top');
                        cell.style.borderBottom = `${width} ${lineStyle} ${color}`;
                    }

                    // 内部垂直线：第一列的右边框（在left和right之间）
                    if (dc_border_pattern_borderSettings.borders.innerV && col === 0) {
                        const color = dc_border_pattern_getBorderDirectionColorValue('left');
                        cell.style.borderRight = `${width} ${lineStyle} ${color}`;
                    }
                });
            }
        }

        // 底纹相关函数
        window.dc_border_pattern_selectFillColor = function (color) {
            dc_border_pattern_shadingSettings.fillColor = color;

            // 更新选中状态
            jQuery(dcPanelBody).find('#dc_border_pattern_fillColorGrid .dc_border_pattern_color-option').removeClass('dc_border_pattern_selected');
            jQuery(event.target).addClass('dc_border_pattern_selected');

            dc_border_pattern_updateCurrentFillColorDisplay(color);
            dc_border_pattern_updateShadingPreview();
        };

        // 更新自定义填充颜色
        window.dc_border_pattern_updateCustomFillColor = function () {
            const customColorInput = jQuery(dcPanelBody).find('#dc_border_pattern_fillCustomColorInput')[0];
            const color = customColorInput.value;
            const customColorOption = jQuery(dcPanelBody).find('#dc_border_pattern_customFillColor')[0];

            // 更新设置
            dc_border_pattern_shadingSettings.fillColor = color;

            // 更新自定义颜色选项的背景
            customColorOption.style.background = color;
            customColorOption.style.borderStyle = 'solid';
            customColorOption.innerHTML = '';

            // 更新选中状态
            jQuery(dcPanelBody).find('#dc_border_pattern_fillColorGrid .dc_border_pattern_color-option').removeClass('dc_border_pattern_selected');
            jQuery(customColorOption).addClass('dc_border_pattern_selected');

            dc_border_pattern_updateCurrentFillColorDisplay(color);
            dc_border_pattern_updateShadingPreview();
        };

        // 更新当前颜色显示
        function dc_border_pattern_updateCurrentFillColorDisplay(color) {
            const preview = jQuery(dcPanelBody).find('#dc_border_pattern_currentFillColorPreview')[0];
            const value = jQuery(dcPanelBody).find('#dc_border_pattern_currentFillColorValue')[0];

            if (preview && value) {
                preview.style.backgroundColor = color;
                value.textContent = color.toUpperCase();
            }
        }

        function dc_border_pattern_updateShadingPreview() {
            const table = jQuery(dcPanelBody).find('#dc_border_pattern_shadingPreviewTable')[0];
            if (!table) return;
            const cells = table.querySelectorAll('td');

            cells.forEach(cell => {
                cell.style.backgroundColor = dc_border_pattern_shadingSettings.fillColor;
            });
        }

        // 页面边框相关函数
        window.dc_border_pattern_selectPageBorderTypeRadio = function (type) {
            dc_border_pattern_pageBorderSettings.type = type;

            // 如果选择无边框，清除所有边框的选中状态
            if (type === 'None') {
                dc_border_pattern_pageBorderSettings.borders.top = false;
                dc_border_pattern_pageBorderSettings.borders.right = false;
                dc_border_pattern_pageBorderSettings.borders.bottom = false;
                dc_border_pattern_pageBorderSettings.borders.left = false;
            } else if (type === 'Page' || type === 'Body') {
                // 如果选择正文边框或页面边框，自动勾选所有边框
                dc_border_pattern_pageBorderSettings.borders.top = true;
                dc_border_pattern_pageBorderSettings.borders.right = true;
                dc_border_pattern_pageBorderSettings.borders.bottom = true;
                dc_border_pattern_pageBorderSettings.borders.left = true;
            }

            dc_border_pattern_updatePageBorderPreviewButtons();
            dc_border_pattern_updatePageBorderPreview();
        };

        window.dc_border_pattern_selectPageLineStyle = function (style) {
            dc_border_pattern_pageBorderSettings.style = style;

            jQuery(dcPanelBody).find('.dc_border_pattern_page-border-left .dc_border_pattern_line-style-option').removeClass('dc_border_pattern_selected');
            jQuery(event.target).closest('.dc_border_pattern_line-style-option').addClass('dc_border_pattern_selected');

            dc_border_pattern_updatePageBorderPreview();
        };

        window.dc_border_pattern_updatePageBorderColor = function () {
            const colorSelect = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderColorSelect')[0];
            const colorPreview = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderColorPreview')[0];
            const customColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderCustomColor')[0];
            const value = colorSelect.value;

            if (value === 'custom') {
                // 显示颜色选择器
                if (customColorBox) {
                    customColorBox.click();
                }
            } else {
                const color = dc_border_pattern_getColorValue(value, '#000000');
                colorPreview.style.backgroundColor = color;
                if (customColorBox) {
                    customColorBox.style.backgroundColor = color;
                    customColorBox.setAttribute('data-value', color);
                }
                dc_border_pattern_pageBorderSettings.color = value;
                dc_border_pattern_pageBorderSettings.customColor = color;

                // 应用到所有边框方向
                ['top', 'right', 'bottom', 'left'].forEach(direction => {
                    dc_border_pattern_pageBorderSettings.colors[direction].value = value;
                    dc_border_pattern_pageBorderSettings.colors[direction].custom = color;
                    const preview = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderColorPreview')[0];
                    const colorBox = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderCustomColor')[0];
                    if (preview) {
                        preview.style.backgroundColor = color;
                    }
                    if (colorBox) {
                        colorBox.style.backgroundColor = color;
                        colorBox.setAttribute('data-value', color);
                    }
                });

                dc_border_pattern_updateCurrentPageBorderColorDisplay(color);
                dc_border_pattern_updatePageBorderPreview();
            }
        };

        window.dc_border_pattern_updatePageBorderCustomColor = function (color) {
            const customColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderCustomColor')[0];
            const colorPreview = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderColorPreview')[0];
            const colorSelect = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderColorSelect')[0];

            // 如果没有传入颜色，从元素获取
            if (!color && customColorBox) {
                color = customColorBox.getAttribute('data-value') ||
                    window.getComputedStyle(customColorBox).backgroundColor || '#000000';
            }

            dc_border_pattern_pageBorderSettings.customColor = color;
            dc_border_pattern_pageBorderSettings.color = 'custom';
            colorSelect.value = 'custom';
            if (colorPreview) {
                colorPreview.style.backgroundColor = color;
            }
            if (customColorBox) {
                customColorBox.style.backgroundColor = color;
                customColorBox.setAttribute('data-value', color);
            }

            // 应用到所有边框方向
            ['top', 'right', 'bottom', 'left'].forEach(direction => {
                dc_border_pattern_pageBorderSettings.colors[direction].value = 'custom';
                dc_border_pattern_pageBorderSettings.colors[direction].custom = color;
                const preview = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderColorPreview')[0];
                const colorBox = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderCustomColor')[0];
                if (preview) {
                    preview.style.backgroundColor = color;
                }
                if (colorBox) {
                    colorBox.style.backgroundColor = color;
                    colorBox.setAttribute('data-value', color);
                }
            });

            dc_border_pattern_updateCurrentPageBorderColorDisplay(color);
            dc_border_pattern_updatePageBorderPreview();
        };

        window.dc_border_pattern_updatePageBorderWidth = function () {
            const widthInput = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderWidthSelect')[0];
            const widthUnitDisplay = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderWidthUnit')[0];

            if (widthInput) {
                // 获取输入值并转换为三百分之一英寸
                const value = parseInt(widthInput.value) || 0;
                dc_border_pattern_pageBorderSettings.width = value;

                // 更新单位显示
                if (widthUnitDisplay) {
                    if (value === 0) {
                        widthUnitDisplay.style.display = 'none';
                    } else {
                        widthUnitDisplay.style.display = '';
                        // 计算毫米值：1个单位 = 1/300英寸 = 25.4/300毫米
                        const millimeters = (value * 25.4 / 300).toFixed(2);
                        widthUnitDisplay.textContent = '≈' + millimeters + 'mm';
                    }
                }
            }

            dc_border_pattern_updatePageBorderPreview();
        };

        // 切换页面边框统一/单独颜色设置
        window.dc_border_pattern_togglePageUnifiedColor = function () {
            const isUnified = jQuery(dcPanelBody).find('#dc_border_pattern_pageUnifiedColorCheck').is(':checked');
            jQuery(dcPanelBody).find('#dc_border_pattern_pageUnifiedColorRow').css('display', isUnified ? 'flex' : 'none');
            jQuery(dcPanelBody).find('#dc_border_pattern_pageIndividualColorRows').css('display', isUnified ? 'none' : 'block');
        };

        // 更新页面边框方向颜色
        window.dc_border_pattern_updatePageBorderDirectionCustomColor = function (direction, color) {
            const customColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderCustomColor')[0];
            const colorPreview = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderColorPreview')[0];

            // 如果没有传入颜色，从元素获取
            if (!color && customColorBox) {
                color = customColorBox.getAttribute('data-value') ||
                    window.getComputedStyle(customColorBox).backgroundColor || '#000000';
            }

            dc_border_pattern_pageBorderSettings.colors[direction].custom = color;
            dc_border_pattern_pageBorderSettings.colors[direction].value = 'custom';

            if (colorPreview) {
                colorPreview.style.backgroundColor = color;
            }
            if (customColorBox) {
                customColorBox.style.backgroundColor = color;
                customColorBox.setAttribute('data-value', color);
            }

            dc_border_pattern_updateCurrentPageBorderColorDisplay(color);
            dc_border_pattern_updatePageBorderPreview();
        };

        // 切换页面边框显隐
        window.dc_border_pattern_togglePageBorder = function (borderType) {
            dc_border_pattern_pageBorderSettings.borders[borderType] = !dc_border_pattern_pageBorderSettings.borders[borderType];
            dc_border_pattern_updatePageBorderPreviewButtons();
            dc_border_pattern_updatePageBorderPreview();
        };

        // 更新页面边框预览按钮状态
        function dc_border_pattern_updatePageBorderPreviewButtons() {
            Object.keys(dc_border_pattern_pageBorderSettings.borders).forEach(borderType => {
                const button = jQuery(dcPanelBody).find(`[onclick="dc_border_pattern_togglePageBorder('${borderType}')"]`)[0];
                if (button) {
                    if (dc_border_pattern_pageBorderSettings.borders[borderType]) {
                        jQuery(button).addClass('active');
                    } else {
                        jQuery(button).removeClass('active');
                    }
                }
            });
        }

        // 获取页面边框方向颜色值
        function dc_border_pattern_getPageBorderDirectionColorValue(direction) {
            const colorMap = {
                'auto': '#000000',
                'black': '#000000',
                'white': '#ffffff',
                'red': '#ff0000',
                'green': '#008000',
                'blue': '#0000ff',
                'yellow': '#ffff00',
                'gray': '#808080',
                'orange': '#ffa500',
                'purple': '#800080',
                'cyan': '#00ffff',
                'pink': '#ffc0cb',
                'custom': dc_border_pattern_pageBorderSettings.colors[direction].custom
            };
            return colorMap[dc_border_pattern_pageBorderSettings.colors[direction].value] || '#000000';
        }

        // 更新当前页面边框颜色显示
        function dc_border_pattern_updateCurrentPageBorderColorDisplay(color) {
            const preview = jQuery(dcPanelBody).find('#dc_border_pattern_currentPageBorderColorPreview')[0];
            const value = jQuery(dcPanelBody).find('#dc_border_pattern_currentPageBorderColorValue')[0];

            if (preview && value) {
                preview.style.backgroundColor = color;
                value.textContent = color.toUpperCase();
            }
        }

        function dc_border_pattern_getPageBorderColorValue() {
            return dc_border_pattern_getColorValue(dc_border_pattern_pageBorderSettings.color, dc_border_pattern_pageBorderSettings.customColor);
        }

        function dc_border_pattern_updatePageBorderPreview() {
            const pageOuterBorder = jQuery(dcPanelBody).find('#dc_border_pattern_pageOuterBorder')[0];
            const contentBorder = jQuery(dcPanelBody).find('#dc_border_pattern_contentBorder')[0];
            const borderTypeLabel = jQuery(dcPanelBody).find('#dc_border_pattern_borderTypeLabel')[0];
            if (!pageOuterBorder || !contentBorder || !borderTypeLabel) return;

            const width = '2px';
            const lineStyle = dc_border_pattern_getLineStyleCSS(dc_border_pattern_pageBorderSettings.style);

            // 清除边框
            pageOuterBorder.style.border = 'none';
            pageOuterBorder.style.backgroundImage = 'none';
            contentBorder.style.border = 'none';

            if (dc_border_pattern_pageBorderSettings.type === 'None') {
                // 无边框
                pageOuterBorder.style.border = '1px solid #e0e0e0';
                pageOuterBorder.style.background = '#f9f9f9';
                contentBorder.style.display = 'none';
                borderTypeLabel.textContent = '无边框';
            } else if (dc_border_pattern_pageBorderSettings.type === 'Page') {
                // 页面边框：应用单独边框到外层
                pageOuterBorder.style.background = 'white';
                contentBorder.style.display = 'none';
                borderTypeLabel.textContent = '页面边框';

                // 分别应用每个方向的边框
                if (dc_border_pattern_pageBorderSettings.borders.top) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('top');
                    pageOuterBorder.style.borderTop = `${width} ${lineStyle} ${color}`;
                }
                if (dc_border_pattern_pageBorderSettings.borders.right) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('right');
                    pageOuterBorder.style.borderRight = `${width} ${lineStyle} ${color}`;
                }
                if (dc_border_pattern_pageBorderSettings.borders.bottom) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('bottom');
                    pageOuterBorder.style.borderBottom = `${width} ${lineStyle} ${color}`;
                }
                if (dc_border_pattern_pageBorderSettings.borders.left) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('left');
                    pageOuterBorder.style.borderLeft = `${width} ${lineStyle} ${color}`;
                }
            } else if (dc_border_pattern_pageBorderSettings.type === 'Body') {
                // 正文边框：外层显示为页面，内层显示边框
                pageOuterBorder.style.border = '1px solid #e0e0e0';
                pageOuterBorder.style.background = '#f9f9f9';
                contentBorder.style.display = 'block';
                contentBorder.style.background = 'white';
                borderTypeLabel.textContent = '正文边框';

                // 分别应用每个方向的边框
                if (dc_border_pattern_pageBorderSettings.borders.top) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('top');
                    contentBorder.style.borderTop = `${width} ${lineStyle} ${color}`;
                }
                if (dc_border_pattern_pageBorderSettings.borders.right) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('right');
                    contentBorder.style.borderRight = `${width} ${lineStyle} ${color}`;
                }
                if (dc_border_pattern_pageBorderSettings.borders.bottom) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('bottom');
                    contentBorder.style.borderBottom = `${width} ${lineStyle} ${color}`;
                }
                if (dc_border_pattern_pageBorderSettings.borders.left) {
                    const color = dc_border_pattern_getPageBorderDirectionColorValue('left');
                    contentBorder.style.borderLeft = `${width} ${lineStyle} ${color}`;
                }
            }
        }

        // 收集数据函数
        function GetOrChangeData(dcPanelBody) {
            // 从输入框获取最新的宽度值
            const widthInput = jQuery(dcPanelBody).find('#dc_border_pattern_borderWidthSelect')[0];
            const currentWidth = widthInput ? parseInt(widthInput.value) || 1 : dc_border_pattern_borderSettings.width;

            // 收集所有设置数据
            const allSettings = {
                // 边框设置
                border: {
                    type: dc_border_pattern_borderSettings.type,
                    style: dc_border_pattern_borderSettings.style,
                    color: dc_border_pattern_borderSettings.color,
                    customColor: dc_border_pattern_borderSettings.customColor,
                    width: currentWidth,
                    borders: { ...dc_border_pattern_borderSettings.borders },
                    colors: {
                        top: { ...dc_border_pattern_borderSettings.colors.top },
                        right: { ...dc_border_pattern_borderSettings.colors.right },
                        bottom: { ...dc_border_pattern_borderSettings.colors.bottom },
                        left: { ...dc_border_pattern_borderSettings.colors.left }
                    },
                    applyTo: jQuery(dcPanelBody).find('#dc_border_pattern_borderApplyToSelect').val(),
                    isUnifiedColor: jQuery(dcPanelBody).find('#dc_border_pattern_unifiedColorCheck').is(':checked')
                },
                // 底纹设置
                shading: {
                    fillColor: dc_border_pattern_shadingSettings.fillColor,
                    applyTo: jQuery(dcPanelBody).find('#dc_border_pattern_shadingApplyToSelect').val()
                },
                // 页面边框设置
                pageBorder: {
                    type: dc_border_pattern_pageBorderSettings.type,
                    style: dc_border_pattern_pageBorderSettings.style,
                    color: dc_border_pattern_pageBorderSettings.color,
                    customColor: dc_border_pattern_pageBorderSettings.customColor,
                    colorValue: dc_border_pattern_getPageBorderColorValue(), // 获取实际的颜色值
                    width: (function () {
                        const widthInput = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderWidthSelect')[0];
                        return widthInput ? parseInt(widthInput.value) || 1 : dc_border_pattern_pageBorderSettings.width;
                    })(),
                    borders: { ...dc_border_pattern_pageBorderSettings.borders },
                    colors: {
                        top: { ...dc_border_pattern_pageBorderSettings.colors.top },
                        right: { ...dc_border_pattern_pageBorderSettings.colors.right },
                        bottom: { ...dc_border_pattern_pageBorderSettings.colors.bottom },
                        left: { ...dc_border_pattern_pageBorderSettings.colors.left }
                    },
                    isUnifiedColor: jQuery(dcPanelBody).find('#dc_border_pattern_pageUnifiedColorCheck').is(':checked')
                },
                // 当前激活的选项卡
                currentTab: dc_border_pattern_currentTab
            };


            return allSettings;
        }

        // 初始化函数
        function dc_border_pattern_init() {
            // 复显单元格边框类型
            jQuery(dcPanelBody).find('.dc_border_pattern_border-style-option').removeClass('dc_border_pattern_selected');
            const borderTypeOption = jQuery(dcPanelBody).find('.dc_border_pattern_border-style-option').filter(function () {
                return jQuery(this).attr('onclick') && jQuery(this).attr('onclick').includes(`'${dc_border_pattern_borderSettings.type}'`);
            })[0];
            if (borderTypeOption) {
                jQuery(borderTypeOption).addClass('dc_border_pattern_selected');
            }

            // 复显单元格边框线型
            jQuery(dcPanelBody).find('.dc_border_pattern_border-left .dc_border_pattern_line-style-option').removeClass('dc_border_pattern_selected');
            const borderLineStyleOption = jQuery(dcPanelBody).find('.dc_border_pattern_border-left .dc_border_pattern_line-style-option').filter(function () {
                return jQuery(this).attr('onclick') && jQuery(this).attr('onclick').includes(`'${dc_border_pattern_borderSettings.style}'`);
            })[0];
            if (borderLineStyleOption) {
                jQuery(borderLineStyleOption).addClass('dc_border_pattern_selected');
            }

            // 复显页面边框类型（单选框）
            const pageBorderTypeRadio = jQuery(dcPanelBody).find(`input[name="dc_border_pattern_pageBorderType"][value="${dc_border_pattern_pageBorderSettings.type}"]`)[0];
            if (pageBorderTypeRadio) {
                pageBorderTypeRadio.checked = true;
            }

            // 复显页面边框线型
            jQuery(dcPanelBody).find('.dc_border_pattern_page-border-left .dc_border_pattern_line-style-option').removeClass('dc_border_pattern_selected');
            const pageLineStyleOption = jQuery(dcPanelBody).find('.dc_border_pattern_page-border-left .dc_border_pattern_line-style-option').filter(function () {
                return jQuery(this).attr('onclick') && jQuery(this).attr('onclick').includes(`'${dc_border_pattern_pageBorderSettings.style}'`);
            })[0];
            if (pageLineStyleOption) {
                jQuery(pageLineStyleOption).addClass('dc_border_pattern_selected');
            }

            // 初始化统一边框颜色预览和输入框
            const unifiedPreview = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderColorPreview')[0];
            const unifiedColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderCustomColor')[0];
            const unifiedColorCheck = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedColorCheck')[0];

            // 检查是否所有边框颜色相同
            const topColor = dc_border_pattern_borderSettings.colors.top.custom;
            const rightColor = dc_border_pattern_borderSettings.colors.right.custom;
            const bottomColor = dc_border_pattern_borderSettings.colors.bottom.custom;
            const leftColor = dc_border_pattern_borderSettings.colors.left.custom;

            const allColorsSame = (topColor === rightColor && rightColor === bottomColor && bottomColor === leftColor);

            if (unifiedPreview && unifiedColorBox) {
                if (allColorsSame) {
                    unifiedPreview.style.backgroundColor = topColor;
                    unifiedColorBox.style.backgroundColor = topColor;
                    unifiedColorBox.setAttribute('data-value', topColor);
                    if (unifiedColorCheck) {
                        unifiedColorCheck.checked = true;
                    }
                } else {
                    unifiedPreview.style.backgroundColor = '#000000';
                    unifiedColorBox.style.backgroundColor = '#000000';
                    unifiedColorBox.setAttribute('data-value', '#000000');
                    if (unifiedColorCheck) {
                        unifiedColorCheck.checked = false;
                    }
                }
            }

            // 根据是否统一颜色显示/隐藏相应的区域
            if (allColorsSame) {
                jQuery(dcPanelBody).find('#dc_border_pattern_unifiedColorRow').css('display', 'flex');
                jQuery(dcPanelBody).find('#dc_border_pattern_individualColorRows').css('display', 'none');

                // 设置统一颜色下拉框
                const unifiedColorSelect = jQuery(dcPanelBody).find('#dc_border_pattern_unifiedBorderColorSelect')[0];
                if (unifiedColorSelect) {
                    unifiedColorSelect.value = 'custom';
                }
            } else {
                jQuery(dcPanelBody).find('#dc_border_pattern_unifiedColorRow').css('display', 'none');
                jQuery(dcPanelBody).find('#dc_border_pattern_individualColorRows').css('display', 'block');
            }

            // 初始化方向边框颜色预览和输入框
            ['top', 'right', 'bottom', 'left'].forEach(direction => {
                const preview = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderColorPreview')[0];
                const colorBox = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderCustomColor')[0];
                const color = dc_border_pattern_getBorderDirectionColorValue(direction);
                if (preview) {
                    preview.style.backgroundColor = color;
                }
                if (colorBox) {
                    colorBox.style.backgroundColor = color;
                    colorBox.setAttribute('data-value', color);
                }
            });

            // 初始化页面边框统一颜色预览和输入框（使用第一个边框的颜色作为统一颜色）
            const pagePreview = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderColorPreview')[0];
            const pageColorBox = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderCustomColor')[0];
            const pageColor = dc_border_pattern_pageBorderSettings.colors.top.custom;
            if (pagePreview) {
                pagePreview.style.backgroundColor = pageColor;
            }
            if (pageColorBox) {
                pageColorBox.style.backgroundColor = pageColor;
                pageColorBox.setAttribute('data-value', pageColor);
            }

            // 更新页面边框颜色下拉框为自定义
            const pageColorSelect = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderColorSelect')[0];
            if (pageColorSelect) {
                pageColorSelect.value = 'custom';
            }

            // 初始化填充颜色选中状态
            const shadingFillColor = dc_border_pattern_shadingSettings.fillColor.toLowerCase();
            const fillColorOption = jQuery(dcPanelBody).find(`#dc_border_pattern_fillColorGrid .dc_border_pattern_color-option[style*="${shadingFillColor}"]`)[0];
            if (fillColorOption) {
                jQuery(fillColorOption).addClass('dc_border_pattern_selected');
            } else {
                // 如果是自定义颜色，选中自定义颜色选项
                const customFillColorOption = jQuery(dcPanelBody).find('#dc_border_pattern_customFillColor')[0];
                if (customFillColorOption) {
                    customFillColorOption.style.background = shadingFillColor;
                    customFillColorOption.style.borderStyle = 'solid';
                    customFillColorOption.innerHTML = '';
                    jQuery(customFillColorOption).addClass('dc_border_pattern_selected');
                }
            }
            // 初始化填充颜色输入框
            const fillInput = jQuery(dcPanelBody).find('#dc_border_pattern_fillCustomColorInput')[0];
            if (fillInput) {
                fillInput.value = shadingFillColor;
            }

            // 初始化宽度输入框
            const widthInput = jQuery(dcPanelBody).find('#dc_border_pattern_borderWidthSelect')[0];
            if (widthInput) {
                widthInput.value = dc_border_pattern_borderSettings.width;
                // 初始化时更新毫米显示
                dc_border_pattern_updateBorderWidth();
            }

            // 初始化页面边框宽度输入框
            const pageWidthInput = jQuery(dcPanelBody).find('#dc_border_pattern_pageBorderWidthSelect')[0];
            if (pageWidthInput) {
                pageWidthInput.value = dc_border_pattern_pageBorderSettings.width;
                // 初始化时更新毫米显示
                dc_border_pattern_updatePageBorderWidth();
            }

            // 初始化页面边框方向颜色预览和输入框
            ['top', 'right', 'bottom', 'left'].forEach(direction => {
                const preview = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderColorPreview')[0];
                const colorBox = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderCustomColor')[0];
                const color = dc_border_pattern_getPageBorderDirectionColorValue(direction);
                if (preview) {
                    preview.style.backgroundColor = color;
                }
                if (colorBox) {
                    colorBox.style.backgroundColor = color;
                    colorBox.setAttribute('data-value', color);
                }
            });

            // 初始化当前颜色显示
            dc_border_pattern_updateCurrentFillColorDisplay(dc_border_pattern_shadingSettings.fillColor);
            dc_border_pattern_updateCurrentPageBorderColorDisplay(dc_border_pattern_pageBorderSettings.colors.top.custom);

            dc_border_pattern_updateBorderPreview();
            dc_border_pattern_updateBorderPreviewButtons();
            dc_border_pattern_updateShadingPreview();
            dc_border_pattern_updatePageBorderPreview();
            dc_border_pattern_updatePageBorderPreviewButtons();

            // 初始化边框类型选项状态（根据"应用于"的值）
            const applyToSelect = jQuery(dcPanelBody).find('#dc_border_pattern_borderApplyToSelect')[0];
            if (applyToSelect) {
                dc_border_pattern_updateBorderTypeOptions(applyToSelect.value);
            }

            // 统一边框颜色选择器 - 点击色块弹出颜色选择器
            const unifiedColorBoxElement = jQuery(dcPanelBody).find("#dc_border_pattern_unifiedBorderCustomColor")[0];
            if (unifiedColorBoxElement) {
                // 设置样式，确保元素可点击
                unifiedColorBoxElement.style.cssText = `
                    display: block;
                    width: 100%;
                    height: 100%;
                    cursor: pointer;
                    border-radius: 4px;
                    position: relative;
                    z-index: 1;
                `;

                jQuery(unifiedColorBoxElement).off('click').on('click', function (e) {
                    e.stopPropagation(); // 阻止事件冒泡到父元素
                    var element = this;
                    DC_ColorPickerModule.show({
                        id: 'dc_border_pattern_unifiedBorderColor_picker',
                        triggerElement: element,
                        defaultColor: element.getAttribute("data-value") || '#000000'
                    }, function (color) {
                        element.style.backgroundColor = color;
                        element.setAttribute("data-value", color);
                        dc_border_pattern_updateUnifiedBorderCustomColor(color);
                    });
                });
            }

            // 方向边框颜色选择器 - 点击色块弹出颜色选择器
            ['top', 'right', 'bottom', 'left'].forEach(direction => {
                const directionColorBoxElement = jQuery(dcPanelBody).find('#dc_border_pattern_' + direction + 'BorderCustomColor')[0];
                if (directionColorBoxElement) {
                    // 设置样式，确保元素可点击
                    directionColorBoxElement.style.cssText = `
                        display: block;
                        width: 100%;
                        height: 100%;
                        cursor: pointer;
                        border-radius: 4px;
                        position: relative;
                        z-index: 1;
                    `;

                    jQuery(directionColorBoxElement).off('click').on('click', function (e) {
                        e.stopPropagation(); // 阻止事件冒泡到父元素
                        var element = this;
                        DC_ColorPickerModule.show({
                            id: 'dc_border_pattern_' + direction + 'BorderColor_picker',
                            triggerElement: element,
                            defaultColor: element.getAttribute("data-value") || '#000000'
                        }, function (color) {
                            element.style.backgroundColor = color;
                            element.setAttribute("data-value", color);
                            dc_border_pattern_updateBorderDirectionCustomColor(direction, color);
                        });
                    });
                }
            });

            // 页面边框统一颜色选择器 - 点击色块弹出颜色选择器
            const pageUnifiedColorBoxElement = jQuery(dcPanelBody).find("#dc_border_pattern_pageBorderCustomColor")[0];
            if (pageUnifiedColorBoxElement) {
                // 设置样式，确保元素可点击
                pageUnifiedColorBoxElement.style.cssText = `
                    display: block;
                    width: 100%;
                    height: 100%;
                    cursor: pointer;
                    border-radius: 4px;
                    position: relative;
                    z-index: 1;
                `;

                jQuery(pageUnifiedColorBoxElement).off('click').on('click', function (e) {
                    e.stopPropagation(); // 阻止事件冒泡到父元素
                    var element = this;
                    DC_ColorPickerModule.show({
                        id: 'dc_border_pattern_pageUnifiedBorderColor_picker',
                        triggerElement: element,
                        defaultColor: element.getAttribute("data-value") || '#000000'
                    }, function (color) {
                        element.style.backgroundColor = color;
                        element.setAttribute("data-value", color);
                        dc_border_pattern_updatePageBorderCustomColor(color);
                    });
                });
            }

            // 页面边框方向颜色选择器 - 点击色块弹出颜色选择器
            ['top', 'right', 'bottom', 'left'].forEach(direction => {
                const pageDirectionColorBoxElement = jQuery(dcPanelBody).find('#dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderCustomColor')[0];
                if (pageDirectionColorBoxElement) {
                    // 设置样式，确保元素可点击
                    pageDirectionColorBoxElement.style.cssText = `
                        display: block;
                        width: 100%;
                        height: 100%;
                        cursor: pointer;
                        border-radius: 4px;
                        position: relative;
                        z-index: 1;
                    `;

                    jQuery(pageDirectionColorBoxElement).off('click').on('click', function (e) {
                        e.stopPropagation(); // 阻止事件冒泡到父元素
                        var element = this;
                        DC_ColorPickerModule.show({
                            id: 'dc_border_pattern_page' + direction.charAt(0).toUpperCase() + direction.slice(1) + 'BorderColor_picker',
                            triggerElement: element,
                            defaultColor: element.getAttribute("data-value") || '#000000'
                        }, function (color) {
                            element.style.backgroundColor = color;
                            element.setAttribute("data-value", color);
                            dc_border_pattern_updatePageBorderDirectionCustomColor(direction, color);
                        });
                    });
                }
            });

        }

        // 调用初始化
        setTimeout(() => dc_border_pattern_init(), 100);

        function successFun() {
            let params = GetOrChangeData(dcPanelBody);

            if (params.border.applyTo === "Text") {
                var inputParameter = {
                    "BackgroundColorString": params.shading.fillColor,
                    "BorderTop": params.border.borders.top,
                    "BorderRight": params.border.borders.right,
                    "BorderLeft": params.border.borders.left,
                    "BorderBottom": params.border.borders.bottom,
                    "BorderBottomColorString": params.border.colors.bottom.custom,
                    "BorderRightColorString": params.border.colors.right.custom,
                    "BorderLeftColorString": params.border.colors.left.custom,
                    "BorderTopColorString": params.border.colors.top.custom,
                    "BorderStyle": params.border.style,
                    "BorderWidth": params.border.width,
                };

                //给当前输入域设置边框
                var currentInput = ctl.CurrentElement();
                if (currentInput) {
                    ctl.SetElementProperties(currentInput, {
                        Style: inputParameter
                    });
                }
            } else {
                // 表格边框和颜色
                var Elements = [];
                if (params.border.applyTo === 'Cell') {
                    var SelectTableCells = ctl.GetSelectTableCells();
                    if (SelectTableCells && SelectTableCells.length) {
                        for (var i = 0; i < SelectTableCells.length; i++) {
                            Elements.push(SelectTableCells[i].NativeHandle);
                        }
                    }
                }

                var parameter = {
                    ApplyRange: params.border.applyTo,
                    BorderSettingsStyle: params.border.type,
                    BorderStyle: params.border.style,
                    BorderWidth: params.border.width,
                    BackgroundColor: params.shading.fillColor,
                    BorderBottomColor: params.border.colors.bottom.custom,
                    BorderLeftColor: params.border.colors.left.custom,
                    BorderRightColor: params.border.colors.right.custom,
                    BorderTopColor: params.border.colors.top.custom,
                    Elements,
                    EnabledBackgroundColor: true,
                    EnabledBorderSettings: true,
                    MiddleHorizontalBorder: params.border.borders.innerH,
                    CenterVerticalBorder: params.border.borders.innerV,
                    LeftBorder: params.border.borders.left,
                    RightBorder: params.border.borders.right,
                    TopBorder: params.border.borders.top,
                    BottomBorder: params.border.borders.bottom
                };
                ctl.DCExecuteCommand("BorderBackgroundFormat", false, parameter);

            }


            // 页面边框和颜色
            var pageBorderParameter = {
                BorderRange: params.pageBorder.type,
                BorderStyle: params.pageBorder.style,
                BorderWidth: params.pageBorder.width,
                BackgroundColor: params.shading.fillColor,
                BorderBottomColor: dc_border_pattern_getPageBorderDirectionColorValue('bottom'),
                BorderLeftColor: dc_border_pattern_getPageBorderDirectionColorValue('left'),
                BorderRightColor: dc_border_pattern_getPageBorderDirectionColorValue('right'),
                BorderTopColor: dc_border_pattern_getPageBorderDirectionColorValue('top'),
                LeftBorder: params.pageBorder.borders.left,
                RightBorder: params.pageBorder.borders.right,
                TopBorder: params.pageBorder.borders.top,
                BottomBorder: params.pageBorder.borders.bottom
            };

            ctl.DCExecuteCommand("PageBorderBackgroundFormat", false, pageBorderParameter);
        }
    },




    /**
     * 创建表格/单元格边框设置对话框
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    borderShadingcellDialog: function (options, ctl, showTableOption = false, tableOptions = null) {
        // console.log(showTableOption);
        let { title, type } = options;
        let ele = null;
        if (type && type === "tableCell") {
            ele = ctl.CurrentTableCell();
        } else if (type && type === "table") {
            ele = ctl.CurrentTable();
        }
        if (!ele) {
            return;
        }
        options = ctl.GetElementProperties(ele);
        let SetTabletyle = options.Style ? options.Style : {};
        var bordersShadingHtml = `
        <div class="dc_bordersShading_dialog">
            <div class="dc_bordersShading_border_box dc_Box">
                <h6 class="dc_title">边框</h6>
                <div class="dc_bordershading_border_box_content">
                    <label class="dc_border_BorderTop_label">
                        <input type="checkbox" name="BorderTop" data-text="BorderTop" checked="checked">
                        <span class="dcTitle-text">上</span>
                    </label>
                    <label class="dc_border_BorderBottom_label">
                        <input type="checkbox" name="BorderBottom" data-text="BorderBottom" checked="checked">
                        <span class="dcTitle-text">下</span>
                    </label>
                    <label class="dc_border_BorderLeft_label">
                        <input type="checkbox" name="BorderLeft" data-text="BorderLeft" checked="checked">
                        <span class="dcTitle-text">左</span>
                        </label>
                    <label class="dc_border_BorderRight_label">
                        <input type="checkbox" name="BorderRight" data-text="BorderRight" checked="checked">
                        <span class="dcTitle-text">右</span>
                    </label>
                </div>
            </div>

            <div class="dc_Box dc_bordersShading_color_box"  >
                <h6 class="dc_title">颜色</h6>
                <div id="dc_bordershading_color_box_content" class="dc_bordershading_color_box_content" >
                    <div>
                         <label class="dc_border_BorderTopColor_label" >
                            <div class="dc_border_show_box" data-value="" id="dc_border_BorderTopColor_box"></div>
                            <input type="color" data-text="BorderTopColorString" name="BorderTopColor" dc-target-id="dc_border_BorderTopColor_box"  >
                        </label>
                        <span class="dcTitle-text">上</span>
                    </div>
                    <div>
                         <label class="dc_border_BorderBottomColor_label" >
                            <div data-value="" class="dc_border_show_box" id="dc_border_BorderBottomColorString_box"></div>
                            <input type="color" data-text="BorderBottomColorString" dc-target-id="dc_border_BorderBottomColorString_box"  >
                        </label>
                        <span class="dcTitle-text">下</span>
                    </div>
                    <div>
                         <label class="dc_border_BorderLeftColor_label" >
                            <div data-value=""  class="dc_border_show_box" id="dc_border_BorderLeftColorString_box"></div>
                            <input type="color" data-text="BorderLeftColorString" dc-target-id="dc_border_BorderLeftColorString_box"  >
                        </label>
                        <span class="dcTitle-text">左</span>
                    </div>
                    <div>
                         <label class="dc_border_BorderRightColor_label" >
                            <div data-value=""  class="dc_border_show_box" id="dc_border_BorderRightColorString_box"></div>
                            <input type="color" data-text="BorderRightColorString" dc-target-id="dc_border_BorderRightColorString_box"  >
                        </label>
                        <span class="dcTitle-text">右</span>
                    </div>
                </div>
            </div>
                <label class="dc_BorderStyle_label" >
                    <span class="dc_txt">网格线样式：</span>
                    <select name="BorderStyle" id="dc_BorderStyle" data-text="BorderStyle"></select>
                </label>

                <label class="dc_BorderWidth_label" >
                    <span class="dcTitle-text">宽度
                        <span class="dc_SpecifyWidth_title" title="单位：三百分之一英寸">?</span>：
                    </span>
                    <input type="number" data-text="BorderWidth" name="BorderWidth">
                </label>

                <label class="dc_Apply_label" >
                    <span class="dcTitle-text">应用于：</span>
                    <select  id="dc_borderApply" >
                        <option value="table">表格</option>
                        <option value="cell">单元格</option>
                    </select>
                </label>
        </div>
        `;
        var dialogOptions = {
            title,
            bodyHeight: 280,
            bodyClass: "bordersShading",
            bodyHtml: bordersShadingHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions, function () {
            //次函数用于点击取消按钮后判断是否展示表格弹框
            if (showTableOption) {
                ctl.tableDialog(tableOptions, ctl);
            }
        });
        // //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        var LineStyle_node = dcPanelBody.find("#dc_BorderStyle");
        for (var i = 0; i < DASHSTYLE.length; i++) {
            var _DashStyle = DASHSTYLE[i];
            LineStyle_node.append(
                "<option value='" +
                _DashStyle.name +
                "'>" +
                _DashStyle.show +
                _DashStyle.name +
                "</option>"
            );
        }
        GetOrChangeData(dcPanelBody, SetTabletyle);

        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        //获取对话框元素，复显值
        var colorContainer = dcPanelBody.find("#dc_bordershading_color_box_content");
        if (colorContainer) {
            var allborderInput = colorContainer.find("input[type='color']");
            if (allborderInput && allborderInput.length > 0) {
                for (var i = 0; i < allborderInput.length; i++) {
                    var itemInput = allborderInput[i];
                    var borderColorType = itemInput.getAttribute("data-text");
                    var targetDivId = itemInput.getAttribute("dc-target-id");
                    var targetDiv = dcPanelBody.find("#" + targetDivId)[0];
                    if (targetDiv) {
                        targetDiv.setAttribute("data-value", SetTabletyle[borderColorType] || '');
                        targetDiv.style.backgroundColor = SetTabletyle[borderColorType] || '';
                    }
                }
            }
            //监听input颜色值改变
            allborderInput.change(function () {
                var targetDivId = this.getAttribute("dc-target-id");
                var targetDiv = dcPanelBody.find("#" + targetDivId)[0];
                if (targetDiv) {
                    targetDiv.setAttribute("data-value", this.value);
                    targetDiv.style.backgroundColor = this.value;
                }
            });
        }

        if (type == "tableCell") {
            ctl.ownerDocument.getElementById("dc_borderApply").value = "cell";
        } else if (type == "table") {
            ctl.ownerDocument.getElementById("dc_borderApply").value = "table";
        }
        function successFun() {
            var styleOpt = {
                Style: GetOrChangeData(dcPanelBody),
            };
            var colorContainer = dcPanelBody.find("#dc_bordershading_color_box_content");
            if (colorContainer) {
                var allborderInput = colorContainer.find("input[type='color']");
                if (allborderInput && allborderInput.length > 0) {
                    for (var i = 0; i < allborderInput.length; i++) {
                        var itemInput = allborderInput[i];
                        var borderColorType = itemInput.getAttribute("data-text");
                        var targetDivId = itemInput.getAttribute("dc-target-id");
                        var targetDiv = dcPanelBody.find("#" + targetDivId)[0];
                        if (targetDiv) {
                            styleOpt.Style[borderColorType] = targetDiv.getAttribute("data-value") || '';
                        }
                    }
                }
            }


            let applyType = ctl.ownerDocument.getElementById("dc_borderApply").value;
            if (applyType && applyType === "cell") {
                ctl.SetSelectTableCellBorder(styleOpt); //支持设置选择的多个单元格，或光标定位在单元格内
            } else if (applyType && applyType === "table") {
                ele = ctl.CurrentTable();
                ctl.SetTableBorder(ele, styleOpt["Style"]);
            }
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                ctl.EventDialogChangeProperties(changedOptions);
            };
            // console.log(showTableOption);
            if (showTableOption) {
                ctl.tableDialog(tableOptions, ctl);
            }
        }
    },

    /**
     * 插入表格
     * @param options 表格属性
     * @param ctl 编辑器元素
     */
    insertTableDialog: function (options, ctl, isInsertMode, callBack) {

        var insertTableHtml = `
        <div>
            <div class="dc_insertTable_content" >
                <label class="dc_inserttable_TableID_label dc_flex" >
                    <h6>编号：</h6>
                    <input type="text" id="dc_TableID" data-text="TableID">
                </label>
                 <label class="dc_inserttable_RowCount_label dc_flex">
                    <h6>行数：</h6>
                    <input type="number" value="2" id="dc_RowCount" class="dc_tableRowAndColumns" data-text="RowCount">
                </label>
                <label  class="dc_inserttable_ColumnCount_label dc_flex">
                    <h6>列数：</h6>
                    <input type="number" value="3" id="dc_ColumnCount" class="dc_tableRowAndColumns" data-text="ColumnCount">
                </label>
            </div>
            <div class="dc_Box dc_inserttable_Box_footer">
                <h6 class="dc_title">预览</h6>
                <table id="dc_tableBox"></table>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "插入表格",
            bodyHeight: "auto",
            bodyClass: "insertTable",
            bodyHtml: insertTableHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions, callBack, false);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");


        //判断是否带有参数
        if (options && (options.RowCount || options.ColumnCount || options.TableID)) {
            //当参数为对象时
            if (options.RowCount) {
                dcPanelBody.find("#dc_RowCount").val(options.RowCount);
            }
            if (options.ColumnCount) {
                dcPanelBody.find("#dc_ColumnCount").val(options.ColumnCount);
            }
            if (options.TableID) {
                dcPanelBody.find('#dc_TableID').val(options.TableID);
            }
            createTable(options.RowCount || 2, options.ColumnCount || 3);
        } else if (options && (typeof options === 'string')) {
            //当参数为文本时
            var params = options.split(',');
            if (params.length > 0) {
                dcPanelBody.find("#dc_RowCount").val(params[0]);
            }
            if (params.length > 1) {
                dcPanelBody.find("#dc_ColumnCount").val(params[1]);
            }
            createTable(params[0] || 2, params[1] || 3);
        } else {
            createTable(2, 3);
        }



        function successFun() {
            let params = GetOrChangeData(dcPanelBody);
            if (!params.RowCount || !params.ColumnCount) {
                return alert(window.__DCSR.TableRowClolumnMastBePositiveInteger);
            }
            // console.log(params, '========params');
            ctl.DCExecuteCommand("InsertTable", false, params);
        }
        dcPanelBody.find(".dc_tableRowAndColumns").change(function () {
            let rowNum = dcPanelBody.find("#dc_RowCount").val();
            let columnNum = dcPanelBody.find("#dc_ColumnCount").val();
            createTable(rowNum, columnNum);
        });
        function createTable(rowNum = 2, columnNum = 3) {
            var box = ctl.ownerDocument.getElementById("dc_tableBox");
            box.innerHTML && (box.innerHTML = "");
            for (var i = 0; i < rowNum; i++) {
                var tr = ctl.ownerDocument.createElement("tr");
                for (var j = 0; j < columnNum; j++) {
                    var td = ctl.ownerDocument.createElement("td");
                    tr.appendChild(td);
                }
                box.appendChild(tr);
            }
        }
    },

    /**
     * 拆分单元格
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    splitCellDialog: function (options, ctl) {
        var splitCellHtml = `
        <div class="dc_splitCell_dialog">
            <label class="dc_flex" >
                <h6 >行数(R)：</h6>
                <input type="number" value="1" id="dc_RowNum" class="dc_tableRowAndColumns" data-text="Value2">
            </label>
            <label class="dc_flex" >
                <h6 >列数(C)：</h6>
                <input type="number" value="1" id="dc_ColumnsNum" class="dc_tableRowAndColumns" data-text="Value1">
            </label>
            <div id="dc_detachable_rows"></div>
        </div>
        `;
        var dialogOptions = {
            title: "拆分单元格",
            dialogContainerBodyWidth: 250,
            bodyHeight: 140,
            bodyClass: "splitCell",
            bodyHtml: splitCellHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions, null, false);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        if (options) {
            let rowstr = options.split(",")[0];
            let columstr = options.split(",")[1];
            dcPanelBody.find("#dc_RowNum").val(rowstr);
            dcPanelBody.find("#dc_ColumnsNum").val(columstr);
        }

        var selectTableCell = ctl.GetSelectTableCells() || [];
        var selectRow = [];
        if (selectTableCell && selectTableCell.length > 1) {
            selectTableCell.forEach((cell) => {
                if (selectRow.indexOf(cell.RowIndex) === -1) {
                    selectRow.push(cell.RowIndex);
                }
            });
        }

        //当前单元格属性
        var currentTableRow = ctl.GetElementProperties(ctl.CurrentTableCell());
        if (currentTableRow) {
            var rowspan = selectRow && selectRow.length || currentTableRow.RowSpan;
            var rowAllChooseArr = [];
            for (var i = 1; i <= rowspan; i++) {
                if ((rowspan % i) == 0) {
                    rowAllChooseArr.push(i);
                }
            }
            ctl.ownerDocument.getElementById('dc_detachable_rows').innerHTML = '行数可选值为：' + rowAllChooseArr.join();
        }
        function successFun() {
            let RowNum = dcPanelBody.find("#dc_RowNum").val();
            let columsNum = dcPanelBody.find("#dc_ColumnsNum").val();
            var selectTableCell = ctl.GetSelectTableCells() || [];
            if (selectTableCell && selectTableCell.length > 1) {
                if (selectTableCell.indexOf(RowNum) === -1) {
                    // console.log('行数可选值为：' + rowAllChooseArr.join());
                    return false;
                }
                ctl.DCExecuteCommand("Table_MergeCell", false, null);
            }

            let str = "" + RowNum + "," + columsNum + "";
            ctl.DCExecuteCommand("Table_SplitCellExt", false, str);
        }
    },
    /**
     * 字符套圈
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    CharacterCircleDialog: function (options, ctl, isInsertMode) {
        // console.log(ctl.CurrentStyle);
        let optionValue = "";
        if (ctl && ctl.CurrentStyle && ctl.CurrentStyle.CharacterCircle) {
            optionValue = ctl.CurrentStyle.CharacterCircle;
        }
        var CharacterCircleHtml = `
             <div class="dc_CharacterCircle_dialog">
                <label>
                    <input class="dc_CharacterCircleinput" checked type="radio" value="None" />
                    <span>无字符套圈</span>
                </label>
                <br />
                <label>
                    <input  class="dc_CharacterCircleinput" type="radio" value="Circle" />
                    <span>圆形字符套圈</span>
                </label>
                <br />
                <label>
                    <input  class="dc_CharacterCircleinput" type="radio" value="Rectangle"  />
                    <span>矩形字符套圈</span>
                </label>
             </div>
            `;
        var dialogOptions = {
            title: "字符套圈",
            dialogContainerBodyWidth: 250,
            bodyHeight: 120,
            bodyClass: "CharacterCircle",
            bodyHtml: CharacterCircleHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        let arr = dcPanelBody.find(".dc_CharacterCircleinput");
        renderRadio(optionValue);
        dcPanelBody.find(".dc_CharacterCircleinput").click(function (e) {
            if (e.target.value) {
                renderRadio(e.target.value);
                optionValue = e.target.value;
            }
        });
        //渲染单选框
        function renderRadio(optionValue1) {
            if (optionValue1 !== "" || optionValue1 !== "None") {
                for (var i = 0; i < arr.length; i++) {
                    if (arr[i].value === optionValue1) {
                        jQuery(arr[i]).prop("checked", true);
                    } else {
                        jQuery(arr[i]).removeAttr("checked");
                    }
                }
            }
        }

        function successFun() {
            ctl.DCExecuteCommand("CharacterCircle", false, optionValue);
        }
    },
    /**
     * 插入特殊字符
     * @param options 属性
     * @param ctl 编辑器元素
     */
    InsertSpecifyCharacterDialog: function (options, ctl, isInsertMode) {
        var CharacterType = Object.keys(this.InsertSpecifyCharacterObj);
        //为了不污染源数据,这里进行克隆
        var InsertSpecifyCharacterObjClone = JSON.parse(JSON.stringify(this.InsertSpecifyCharacterObj));
        if (options && options.CustomCharArray && options.CustomCharArray.length > 0) {
            if (!InsertSpecifyCharacterObjClone.SpecialCharacters || InsertSpecifyCharacterObjClone.SpecialCharacters.length === 0) {
                InsertSpecifyCharacterObjClone['SpecialCharacters'] = [];
            }
            options.CustomCharArray.forEach(charItem => {
                InsertSpecifyCharacterObjClone.SpecialCharacters.push(charItem);
            });
        }
        let value = "";
        var InsertSpecifyCharacterHtml = `
               <div id="dc_tabButton">
                    <p class="dc_tabButtonItem dc_SpecialCharacters dc_active" tabId="SpecialCharacters">特殊字符</p>
                    <p class="dc_tabButtonItem" tabId="RomanCharacters">罗马字符</p>
                    <p class="dc_tabButtonItem" tabId="NumericCharacters">数字字符</p>
                    <p class="dc_tabButtonItem" tabId="MedicalCharacters">医学字符</p>
               </div>
               <div id="dc_tabDomBox"></div>
            `;
        var dialogOptions = {
            title: "插入特殊字符",
            dialogContainerBodyWidth: 500,
            bodyHeight: 464,
            bodyClass: "InsertSpecifyCharacter",
            bodyHtml: InsertSpecifyCharacterHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var TabDomList = ``;
        for (var i = 0; i < CharacterType.length; i++) {
            var charSpanDom = ``;
            for (
                var j = 0;
                j < InsertSpecifyCharacterObjClone[CharacterType[i]].length;
                j++
            ) {
                charSpanDom += `
                <span class="dc_charSpanDomItem" title="${InsertSpecifyCharacterObjClone[CharacterType[i]][j]
                    }">${InsertSpecifyCharacterObjClone[CharacterType[i]][j]}</span>
                `;
            }
            TabDomList += `
                <div class="dc_tabDomBoxItem" style="display:${CharacterType[i] === "SpecialCharacters" ? "" : "none"
                }" id="${CharacterType[i]}">${charSpanDom}</div>
            `;
        }
        ctl.ownerDocument.getElementById("dc_tabDomBox").innerHTML = TabDomList;
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        dcPanelBody.find(".dc_tabButtonItem").on("click", function () {
            dcPanelBody.find(".dc_tabButtonItem.dc_active").removeClass("dc_active");
            jQuery(this).addClass("dc_active");
            dcPanelBody.find(".dc_tabDomBoxItem").hide();
            dcPanelBody.find(`#${this.getAttribute("tabId")}`).show();
        });
        dcPanelBody.find(".dc_charSpanDomItem").on("click", function () {
            value = "" + this.innerHTML + "";
            // console.log(value);
            ctl.DCExecuteCommand("InsertSpecifyCharacter", false, value);
            // 关闭对话框
            var dc_dialogMark = jQuery(ctl).children("#dc_dialogMark"); //蒙版元素
            var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer"); //对话框元素
            dc_dialogMark.remove();
            dc_dialogContainer.remove();
        });
        function successFun() { }
    },

    /**
     * 编辑文档批注
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    EditDocumentCommentsDialog: function (options, ctl, isInsertMode) {
        var EditDocumentCommentsHtml = `
            <div class="dc_Box dc_EditDocumentComments_dialog">
                <h6 class="dc_title">批注内容</h6>
                 <textarea id="dc_Text" data-text="Text" ></textarea>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">颜色设置</h6>
                <label>
                    <span>背景颜色:</span>
                    <input type="color" value="#f6e6e6" id="dc_BackColor"  data-text="BackColor" />
                </label>
                <label>
                    <span>前景颜色:</span>
                    <input type="color" value="#121111" id="dc_ForeColor"  data-text="ForeColor" />
                </label>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">作者</h6>
                <p>姓名：<span id="dc_Author"></span></p>
                <p>编号：<span id="dc_AuthorID"></span></p>
            </div>
            <div class="dc_Box dcBody-content">
                <h6 class="dc_title">自定义属性</h6>
                <div id="dc_attr-box"></div>
            </div>
            `;
        var dialogOptions = {
            title: "编辑文档批注",
            bodyHeight: 400,
            bodyClass: "dc_EditDocumentComments",
            bodyHtml: EditDocumentCommentsHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        //打开对话框做数据回填
        if (options) {
            //不可修改的用户属性，只用span做展示
            let Author = options.Author || options.author;
            dcPanelBody.find("#dc_Author").text(Author);
            dcPanelBody.find("#dc_AuthorID").text(options.AuthorID);

            //可修改的文本框、input等
            var keys = Object.keys(options);
            keys.length && keys.map(item => {
                var currentInput = ctl.ownerDocument.getElementById('dc_' + item);
                if (currentInput && currentInput.tagName) {
                    if (['INPUT', 'TEXTAREA'].indexOf(currentInput.tagName) > -1) {
                        if (currentInput.type == "color" && typeof (options[item]) == "string") {
                            // 颜色选择器,将颜色字符串转换为十六进制格式，防止失效【DUWRITER5_0-3694】
                            options[item] = DCTools20221228.colorToHex(options[item]);
                        }
                        currentInput.value = options[item];
                    }
                }

            });
        }
        //渲染自定义属性框
        this.attributeComponents(
            "#dc_attr-box",
            (options && options.Attributes) || {},
            ctl
        );

        var that = this;
        function successFun() {
            var dcAttrBox = dcPanelBody.find("#dc_attr-box");
            let Attributes = that.attributeComponents_getAttributeObj(dcAttrBox);
            var _data = GetOrChangeData(dcPanelBody);
            options = {
                ...options,
                ..._data,
                Attributes
            };
            if (!isInsertMode) {
                ctl.SetCurrentComment(options);
                if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                    var changedOptions = ctl.GetCurrentComment();
                    ctl.EventDialogChangeProperties(changedOptions);
                };
            } else {
                ctl.DCExecuteCommand("insertcomment", false, options);
            }
        }
    },

    /**
     * 表单模式
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    formModeDialog: function (options, ctl, isInsertMode) {
        let formMode = ctl.FormView();
        var formModeHtml = `
            <form>
                <label>
                    <input class="dc_radioItem" type="radio" data-text="formDisable" ${formMode && formMode == "Disable" && "checked"
            } name="Disable">
                    <span>不处于表单视图模式</span>
                </label>
                <label>
                    <input class="dc_radioItem" type="radio" data-text="formNormal" ${formMode && formMode == "Normal" && "checked"
            } name="Normal">
                    <span>普通表单视图模式</span>
                </label>
                <label>
                    <input class="dc_radioItem" type="radio" data-text="formStrict" ${formMode && formMode == "Strict" && "checked"
            } name="Strict">
                    <span>严格表单视图模式</span>
                </label>
            </form>
        `;
        var dialogOptions = {
            title: "表单模式",
            bodyHeight: 140,
            bodyClass: "dc_formMode",
            bodyHtml: formModeHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var newDomArr = ctl.ownerDocument.getElementsByClassName("dc_radioItem");
        jQuery(ctl)
            .find(".dc_radioItem")
            .click(function () {
                for (var i = 0; i < newDomArr.length; i++) {
                    newDomArr[i].checked = false;
                }
                this.checked = true;
            });
        function successFun() {
            for (var i = 0; i < newDomArr.length; i++) {
                if (newDomArr[i].checked) {
                    var result = ctl.ExecuteCommand("FormViewMode", false, newDomArr[i].name);
                    ctl.DocumentOptions.BehaviorOptions.FormView = result;
                    ctl.ApplyDocumentOptions();//更改选项的值
                }
            }
        }
    },

    /**
     * 内容保护模式
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    contentProtectedModeDialog: function (options, ctl, isInsertMode) {
        let contentProtectedMode = ctl.ProtectType();
        var contentProtectedModeHtml = `
           <form>
                <label>
                    <input class="dc_radioItem" type="radio" ${contentProtectedMode &&
            contentProtectedMode == "None" &&
            "checked"
            } data-text="Value1"  name="None">
                    <span>不保护内容。</span>
                </label>
                 <label>
                    <input class="dc_radioItem" type="radio" ${contentProtectedMode &&
            contentProtectedMode == "Content" &&
            "checked"
            }  data-text="Value2"  name="Content">
                    <span>保护内容，但可以在中间插入新内容。</span>
                </label>
                <label>
                    <input class="dc_radioItem" type="radio" ${contentProtectedMode &&
            contentProtectedMode == "Range" &&
            "checked"
            }  data-text="Value3"  name="Range">
                    <span>保护区域，中间不能插入新内容。</span>
                </label>
            </form>
        `;
        var dialogOptions = {
            title: "内容保护模式",
            bodyHeight: 140,
            bodyClass: "dc_contentProtectedMode",
            bodyHtml: contentProtectedModeHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        jQuery(ctl)
            .find(".dc_radioItem")
            .click(function () {
                var newDomArr =
                    ctl.ownerDocument.getElementsByClassName("dc_radioItem");
                for (var i = 0; i < newDomArr.length; i++) {
                    newDomArr[i].checked = false;
                }
                this.checked = true;
            });
        function successFun() {
            var newDomArr = ctl.ownerDocument.getElementsByClassName("dc_radioItem");
            for (var i = 0; i < newDomArr.length; i++) {
                if (newDomArr[i].checked) {
                    ctl.ExecuteCommand("ContentProtect", false, newDomArr[i].name);
                }
            }
        }
    },

    /**
     * 用户登录
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    loginDialog: function (options, ctl, isInsertMode) {
        // if (!options || typeof (options) != "object") {
        //     return false
        // }
        var loginHtml = `
           <div>
                <label class="dc_flex">
                    <span>用户编号：</span>
                    <input type="text" data-text="Value1">
                </label>
                <label class="dc_flex">
                    <span>姓名：</span>
                    <input type="text" data-text="Value2">
                </label>
                <label class="dc_flex">
                    <span>等级：</span>
                    <input type="number" data-text="Value3">
                </label>
            </div>
        `;
        var dialogOptions = {
            title: "用户登录",
            bodyHeight: 120,
            dialogContainerBodyWidth: 250,
            bodyClass: "dc_login_dialog",
            bodyHtml: loginHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        function successFun() {
            // console.log(jQuery('#textareaBox').val())
        }
    },

    /**
     * 段落
     * @param options 单元格属性
     * @param ctl 编辑器元素
     */
    paragraphDialog: function (options, ctl, isInsertMode) {
        if (!options || typeof options != "object") {
            options = ctl.GetCurrentParagraphStyle();
        }
        // console.log(options, "段落属性");
        var paragraphHtml = `
        <div class="dc_paragraph_item">
            <div class="dc_paragraph_item_label">大纲级别:</div>
            <select id="dc_ParagraphOutlineLevel" data-text="ParagraphOutlineLevel">
                <option value="-1">正文文本</option>
                <option value="0">1级</option>
                <option value="1">2级</option>
                <option value="2">3级</option>
                <option value="3">4级</option>
                <option value="4">5级</option>
                <option value="5">6级</option>
                <option value="6">7级</option>
                <option value="7">8级</option>
            </select>
        </div>
        <div class="dc_paragraph_item">
            <div class="dc_paragraph_item_label">段落列表样式:</div>
            <select id="dc_paragraphStyle" data-text="ParagraphListStyle"></select>
        </div>
        <label class="dc_paragraph_item">
            <input id="dc_ParagraphMultiLevel" type="checkbox" data-text="ParagraphMultiLevel"></input>
            <div class="dc_paragraph_item_label">多层段落列表</div>
        </label>
        <div class="dc_Box ">
            <h6 class="dc_title">间距</h6>
            <div class="dc_paragraph_item"  style="margin-bottom:0;">
                <div class="dc_paragraph_item_label">左侧缩进量:</div>
                <input  class="dc_input_number_data_model" type="number" data-text="LeftIndent"></input>
            </div>
            <div class="dc_paragraph_item">
                <div class="dc_paragraph_item_label"></div>
                <span class="dc-data-model" dc-text-model="LeftIndent"></span>
            </div>
            <div class="dc_paragraph_item"  style="margin-bottom:0;">
                <div class="dc_paragraph_item_label" >首行缩进量:</div>
                <input  class="dc_input_number_data_model" type="number" data-text="FirstLineIndent"></input>
            </div>
            <div class="dc_paragraph_item">
                <div class="dc_paragraph_item_label"></div>
                <span class="dc-data-model" dc-text-model="FirstLineIndent"></span>
            </div>
            <div class="dc_paragraph_item" style="margin-bottom:0;">
                <div class="dc_paragraph_item_label" >段落前间距:</div>
                <input  class="dc_input_number_data_model" type="number" data-text="SpacingBeforeParagraph"></input>
            </div>
            <div class="dc_paragraph_item">
                <div class="dc_paragraph_item_label"></div>
                <span class="dc-data-model" dc-text-model="SpacingBeforeParagraph"></span>
            </div>
            <div class="dc_paragraph_item"  style="margin-bottom:0;">
                <div class="dc_paragraph_item_label" >段落后间距:</div>
                <input  class="dc_input_number_data_model" type="number" data-text="SpacingAfterParagraph"></input>
            </div>
            <div class="dc_paragraph_item">
                <div class="dc_paragraph_item_label"></div>
                <span class="dc-data-model" dc-text-model="SpacingAfterParagraph"></span>
            </div>

        </div>
        <div class="dc_paragraph_item" >
            <div class="dc_paragraph_item_label" >行距:</div>
            <select id="dc_LineSpacingStyle" class="space" data-text="LineSpacingStyle">
                <option value="SpaceSingle">单倍行距</option>
                <option value="Space1pt5">1.5倍行距</option>
                <option value="SpaceDouble">2倍行距</option>
                <option value="SpaceExactly">最小值</option>
                <option value="SpaceSpecify">固定值</option>
                <option value="SpaceMultiple">多倍行距</option>
            </select>
        </div>
        <div id="dc_LineSpacingBox" class="dc_paragraph_item" >
            <div class="dc_paragraph_item_label" >设置值:</div>
            <input type="number"  data-text="LineSpacing"></input>
        </div>
        `;
        var dialogOptions = {
            title: "段落",
            bodyHeight: 442,
            dialogContainerBodyWidth: 320,
            bodyClass: "dc_paragraph",
            bodyHtml: paragraphHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素，复显值
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        //动态生成下拉节点
        let domStr = "";
        BULLETEDLIST.filter((item) => {
            domStr += `<option title="${item.title}" value="${item.title}">${item.data}</option>`;
        });
        dcPanelBody.find("#dc_paragraphStyle").append(domStr);
        options &&
            options.LineSpacingStyle &&
            showLineSpacFn(options.LineSpacingStyle);
        GetOrChangeData(dcPanelBody, options);
        dcPanelBody.find("#dc_LineSpacingStyle").bind("change", function (e) {
            showLineSpacFn(dcPanelBody.find("#dc_LineSpacingStyle").val());
        });
        function showLineSpacFn(value) {
            if (["SpaceSpecify", "SpaceMultiple"].includes(value)) {
                dcPanelBody.find("#dc_LineSpacingBox").show();
                dcPanelBody.find("#dc_LineSpacingUnit").innerHTML =
                    value === "SpaceSpecify" ? "值" : "倍";
            } else {
                dcPanelBody.find("#dc_LineSpacingBox").hide();
            }
        }


        function successFun() {
            let newOptions = GetOrChangeData(dcPanelBody);
            // console.log("段落", newOptions);

            newOptions = {
                ...options,
                ...newOptions,
            };
            ctl.SetCurrentParagraphStyle(newOptions);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetCurrentParagraphStyle();
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 表格
     * @param options 查找替换属性
     * @param ctl 编辑器元素
     */
    tableDialog: function (options, ctl, isInsertMode) {
        if (!options || typeof options != "object") {
            var ele = ctl.CurrentTable();
            options = ctl.GetElementProperties(ele);
            if (options == null) {
                return false;
            }
        }
        let optionsID = (options && options.ID) || "";
        var LabelHtml = `
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">表格ID：</span>
                <input class="dc_full" type="text" data-text="ID" />
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text">内容只读保护：</span>
                <select  class="dc_full" data-text="ContentReadonly">
                    <option value="Inherit">继承上级设置</option>
                    <option value="True">只读</option>
                    <option value="False">不只读</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text" >启用授权控制：</span>
                <select  class="dc_full" data-text="EnablePermission">
                    <option value="Inherit">继承上级设置</option>
                    <option value="True">是</option>
                    <option value="False">否</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span class="dcTitle-text" >打印显示：</span>
                <select class="dc_full" data-text="PrintVisibility">
                    <option value="Visible">显示</option>
                    <option value="Hidden">隐藏</option>
                    <option value="None">隐藏而且不占位</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <div>
                <label>
                    <input type="checkbox"  data-text="AllowUserToResizeRows">
                    <span>用户可调整行高</span>
                </label>
            </div>
            <div class="dc_table_AllowUserToResizeColumns_box">
                <label>
                    <input type="checkbox" data-text="AllowUserToResizeColumns">
                    <span> 用户可调整列宽</span>
                </label>
            </div>
            <div class="dc_table_AllowUserInsertRow_box">
                <label>
                    <input type="checkbox"  data-text="AllowUserInsertRow">
                    <span>用户可新增表格行</span>
                </label>
            </div>
            <div class="dc_table_AllowUserDeleteRow_box">
                <label>
                    <input type="checkbox"  data-text="AllowUserDeleteRow">
                    <span> 用户可删除表格行</span>
                </label>
            </div>
            <div class="dc_table_Deleteable_box">
                <label>
                    <input type="checkbox"  data-text="Deleteable">
                    <span>用户可删除表格</span>
                </label>
            </div> 
            <div class="dc_table_CompressOwnerLineSpacing_box">
                <label>
                    <input type="checkbox"  data-text="CompressOwnerLineSpacing">
                    <span>压缩行间距</span>
                </label>
            </div>
            <div class="dc_table_buttons_box">
                <button id="dctableSetTableBorder">表格边框</button>
                <button id="dctableAutoFixTableWidth">自适应宽度</button>
                <button id="dctableAverageTableRows">平均分布各行</button>
                <button id="dctableAverageTableColumns">平均分布各列</button>
            </div>
            <div class="dc_Box">
                <h6 class="dc_title">表达式：</h6>
                <label class="dc_table_VisibleExpression_label" >
                    <span>可见性表达式：</span>
                    <input data-text="VisibleExpression" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
                <label class="dc_table_PrintVisibilityExpression_label">
                    <span>打印可见性表达式：</span>
                     <input data-text="PrintVisibilityExpression" type="text">
                    <button class="dc_visible_expression">示例</button>
                </label>
            </div>
            <div class="dc_Box dc_table_ValueBinding_box">
                <h6 class="dc_title">赋值属性：</h6>
                <div class="dc_tab3Content">
                    <label class="dc_table_DataSource_label">
                        <span>数据源名称：</span>
                        <input id="dc_DataSource" type="text" />
                    </label>
                    <label class="dc_table_BindingPath_label">
                        <span>绑定路径：</span>
                        <input id="dc_BindingPath"  type="text" />
                    </label>
                </div>
            </div>
            <div class="dc_Box dc_table_color_box">
                <h6 class="dc_title">背景颜色属性：</h6>
                <div id="dc_TableBackground">
                   <div>
                        <label>
                            <div id="dc_TableBackgroundText_box" data-value=""></div>
                        </label>
                   </div>
                </div>
            </div>
            <div class="dcBody-content dc_Box dc_table_custom_attr_box">
                <h6 class="dc_title">自定义属性</h6>
                <div id="dc_attr-box"></div>
            </div>`;

        var dialogOptions = {
            title: "表格属性对话框",
            bodyHeight: 444,
            bodyClass: "dc_tableDialog",
            bodyHtml: LabelHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        let that = this;

        ctl.ownerDocument.getElementById('dctableSetTableBorder').addEventListener('click', function (e) {
            var tableOptions = GetTabDialogOptions();
            // console.log(tableOptions, '========tableOptions');
            that.borderShadingcellDialog({
                title: "单元格边框设置",
                type: "tableCell"
            }, ctl, true, tableOptions);
        });
        ctl.ownerDocument.getElementById('dctableAutoFixTableWidth').addEventListener('click', function () {
            ctl.AutoFixTableWidth();
        });
        ctl.ownerDocument.getElementById('dctableAverageTableRows').addEventListener('click', function () {
            ctl.AverageTableRows(optionsID);
        });
        ctl.ownerDocument.getElementById('dctableAverageTableColumns').addEventListener('click', function () {
            ctl.AverageTableColumns(optionsID);
        });
        //渲染自定义属性框
        this.attributeComponents(
            "#dc_attr-box",
            (options && options.Attributes) || {},
            ctl
        );
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        if (options && options.ValueBinding) {
            dcPanelBody
                .find("#dc_DataSource")
                .val(options.ValueBinding.DataSource || "");
            dcPanelBody
                .find("#dc_BindingPath")
                .val(options.ValueBinding.BindingPath || "");
        }

        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, opts);
        if (options && options.Style && options.Style.BackgroundColorString) {
            jQuery(ctl).find('#dc_TableBackgroundText_box').css('background-color', options.Style.BackgroundColorString);
            jQuery(ctl).find('#dc_TableBackgroundText_box').attr('data-value', options.Style.BackgroundColorString);
        }

        //表格背景颜色 - 点击色块弹出颜色选择器
        const tableBackgroundColorBox = jQuery(ctl).find('#dc_TableBackgroundText_box')[0];
        if (tableBackgroundColorBox) {
            jQuery(tableBackgroundColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_TableBackgroundText_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#FFFFFF'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }


        function GetTabDialogOptions() {
            var tableOptions = {};
            var dcAttrBox = dcPanelBody.find("#dc_attr-box");
            let Attributes = that.attributeComponents_getAttributeObj(dcAttrBox);
            var _data = GetOrChangeData(dcPanelBody);
            let DataSource = dcPanelBody.find("#dc_DataSource").val();
            let BindingPath = dcPanelBody.find("#dc_BindingPath").val();
            let BackgroundColorString = jQuery(ctl).find('#dc_TableBackgroundText_box').attr('data-value');

            tableOptions = {
                ..._data,
                ValueBinding: {
                    DataSource,
                    BindingPath,
                },
                Attributes,
                Style: {
                    BackgroundColorString//设置背景颜色
                }
            };

            return tableOptions;
        }


        function successFun() {
            var newOptions = GetTabDialogOptions();
            // console.log(newOptions, "========newOptions");
            //循环每一列设置背景颜色
            var columns = options.Columns || [];
            if (columns && columns.length) {
                for (var i = 0; i < columns.length; i++) {
                    ctl.HighlightTableRowColumn(ctl.CurrentTable(), -1, i, newOptions.Style.BackgroundColorString, false);
                }
            }
            ctl.SetElementProperties(ctl.CurrentTable(), newOptions);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTable());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 单元格
     * @param options 把绑定数据源元素插入到该元素位置最后面
     * @param ctl 编辑器元素
     */
    tableCellDialog: function (options, ctl) {
        var ele = ctl.CurrentTableCell();
        if (!options || typeof options != "object") {
            options = ctl.GetElementProperties(ele);
            if (options == null) {
                return false;
            }
        }

        if (options.Style && options.Style.Align && options.Style.VerticalAlign) {
            //wyc20230711:修改单元格获取水平对齐的逻辑
            var crtpStyle = ctl.GetCurrentParagraphStyle();
            options["Align"] = crtpStyle.Align;
            options["VerticalAlign"] = options.Style.VerticalAlign;
        }
        if (options.ValueExpression === null || options.ValueExpression == undefined) {
            //lixinyu20240701:修复数值表达式不生效问题
            options["ValueExpression"] = (options.PropertyExpressions && options.PropertyExpressions.FormulaValue) || null;
        }
        var LabelHtml = `
        <div class="dcBody-content">
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_Id_label">
                    <span class="dcTitle-text">ID：</span>
                    <input class="dc_full" data-text="ID" />
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_ContentReadonly_label">
                    <span class="dcTitle-text">内容只读保护：</span>
                    <select  class="dc_full" data-text="ContentReadonly">
                        <option value="Inherit">继承上级设置</option>
                        <option value="True">只读</option>
                        <option value="False">不只读</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_EnablePermission_label">
                    <span class="dcTitle-text">启用授权控制：</span>
                    <select  class="dc_full" data-text="EnablePermission">
                        <option value="Inherit">继承上级设置</option>
                        <option value="True">是</option>
                        <option value="False">否</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_CloneType_label">
                    <span class="dcTitle-text">复制模式：</span>
                    <select  id="dc_CloneType" class="dc_full" data-text="CloneType">
                        <option value="Default">继承上级设置</option>
                        <option value="ContentWithClearField">复制内容，但删除输入域中的内容</option>
                        <option value="Complete"> 完整的复制，包括输入域中的内容</option>
                        <option value="ClearDirectContentAndFieldContent">清空复制的普通内容和输入域的内容</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_table_cell_MoveFocusHotKey_label dc_flex">
                    <span class="dcTitle-text">焦点快捷键：</span>
                    <select class="dc_full" data-text="MoveFocusHotKey">
                        <option value="None">None</option>
                        <option value="Default">Default</option>
                        <option value="Tab">Tab</option>
                        <option value="Enter">Enter</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_AutoFixFontSizeMode_label">
                    <span class="dcTitle-text">缩小字体填充：</span>
                    <select class="dc_full" data-text="AutoFixFontSizeMode">
                        <option value="None">不启用</option>
                        <option value="SingleLine">单行模式</option>
                        <option value="MultiLine">多行模式</option>
                       
                    </select>
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_ValueExpression_label">
                    <span class="dcTitle-text">数值表达式：</span>
                    <input class="dc_full" data-text="ValueExpression" type="text" />
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex dc_table_cell_PrintVisibility_label">
                    <span class="dcTitle-text" >打印显示：</span>
                    <select class="dc_full" data-text="PrintVisibility">
                        <option value="Visible">显示</option>
                        <option value="Hidden">隐藏</option>
                        <option value="None">隐藏而且不占位</option>
                    </select>
                </label>
            </div>
            <div class="dcBody-content dc_table_cell_algin_box">
                <span class="dcTitle-text" >对齐方式：</span>
                <div class="dc_table_cell_algin_box_container">
                    <label class="dc_table_cell_Align_label" for="dc_Align" disabled>水平对齐方式:</label>
                        <select class="dc_table_cell_Align_select" disabled id="dc_Align" data-text="Align" >
                            <option value="Left">左对齐</option>
                            <option value="Right">右对齐</option>
                            <option value="Center">居中对齐</option>
                        </select>
                    <label class="dc_table_cell_VerticalAlign_label" for="dc_vertical">垂直对齐方式:</label>
                    <select class="dc_table_cell_VerticalAlign_select" id="dc_vertical" data-text="VerticalAlign">
                        <option value="Top">顶端对齐</option>
                        <option value="Bottom">底端对齐</option>
                        <option value="Middle">居中对齐</option>
                    </select>
                </div>
            </div>
        </div>
        <div class="dc_Box dc_table_cell_padding_box">
            <h6 class="dc_title">内边距：</h6>
            <div class="dc_table_cell_padding_box_container">
                <label class="dc_table_cell_PaddingTop_label">
                    <span>上边距：</span>
                    <input id="dc_PaddingTop" data-text="PaddingTop" class="dc_input_number_data_model" type="number" />
                    <span dc-text-model="PaddingTop"></span>

                </label>
                <label class="dc_table_cell_PaddingBottom_label">
                    <span>下边距：</span>
                    <input id="dc_PaddingBottom" data-text="PaddingBottom" class="dc_input_number_data_model" type="number" />
                    <span dc-text-model="PaddingBottom"></span>
                </label>
                <label class="dc_table_cell_PaddingLeft_label">
                    <span>左边距：</span>
                    <input id="dc_PaddingLeft" data-text="PaddingLeft" class="dc_input_number_data_model" type="number" />
                    <span dc-text-model="PaddingLeft"></span>
                </label>
                <label  class="dc_table_cell_PaddingRight_label">
                    <span>右边距：</span>
                    <input id="dc_PaddingRight" data-text="PaddingRight" class="dc_input_number_data_model" type="number" />
                    <span dc-text-model="PaddingRight"></span>
                </label>               
            </div>
        </div>
        <div id="dc_BorderRenderVisibility" class="dc_Box" >
            <h6 class="dc_title">边框可见性:</h6>
            <div class="dc_table_cell_border_box_container">
                <label class="dc_table_cell_Hidden_label">
                    <input attrId='0' attrValue='Hidden' type="checkbox" />
                    <span >Hidden</span>
                </label>
                <label class="dc_table_cell_Paint_label">
                    <input attrId='1' attrValue='Paint' type="checkbox" />
                    <span >Paint</span>
                </label>   
                <label class="dc_table_cell_Print_label">
                    <input attrId='2' attrValue='Print' type="checkbox" />
                    <span>Print</span>
                </label>   
                <label class="dc_table_cell_PDF_label">
                    <input attrId='4' attrValue='PDF' type="checkbox" />
                    <span>PDF</span>
                </label>  
                <label class="dc_table_cell_All_label">
                    <input attrId='8'  attrValue='All' type="checkbox" />
                    <span>All</span>
                </label>  
                <span class="dc_table_cell_border_wring">注：此属性值不保存到XML中</span>

            </div>
        </div>
        <div id="dc_ContentRenderVisibility" class="dc_Box">
            <h6 class="dc_title">内容可见性:</h6>
            <div class="dc_table_cell_ContentRenderVisibility_box_container" >
                <label class="dc_table_cell_Content_Hidden_label">
                    <input attrId='0' attrValue='Hidden'    type="checkbox" />
                    <span >Hidden</span>
                </label>
                <label class="dc_table_cell_Content_Paint_label" >
                    <input attrId='1' attrValue='Paint' type="checkbox" />
                    <span>Paint</span>
                </label>   
                <label class="dc_table_cell_Content_Print_label" >
                    <input attrId='2' attrValue='Print'  type="checkbox" />
                    <span>Print</span>
                </label>   
                <label class="dc_table_cell_Content_PDF_label">
                    <input attrId='4' attrValue='PDF' type="checkbox" />
                    <span>PDF</span>
                </label>  
                <label class="dc_table_cell_Content_All_label">
                    <input attrId='8'  attrValue='All' type="checkbox" />
                    <span>All</span>
                </label> 
                <span class="dc_table_cell_border_wring">注：此属性值不保存到XML中</span>
            </div>
        </div>
        <div class="dc_Box dc_table_cell_Data_box">
            <h6 class="dc_title">赋值属性：</h6>
            <div class="dc_tab3Content">
                <label class="dc_table_cell_DataSource_label">
                    <span>数据源名称：</span>
                    <input id="dc_DataSource" type="text" />
                </label>
                <label  class="dc_table_cell_BindingPath_label">
                    <span>绑定路径：</span>
                    <input id="dc_BindingPath"  type="text" />
                </label>
            </div>
        </div>
        <div class="dc_Box dc_table_cell_color_box">
            <h6 class="dc_title">背景颜色属性：</h6>
            <div>
                <div style="display:flex;align-items:center;">
                    背景色：
                    <label class="dc_TableCellBackgroundText_label">
                        <div id="dc_TableCellBackgroundText_box" data-value=""></div>
                    </label>
                </div>
            </div>
            
        </div>
        <div class="dcBody-content Box">
            <h6 class="dc_title">自定义属性</h6>
            <div id="dc_attr-box"></div>
        </div>  `;

        var dialogOptions = {
            title: "单元格属性对话框",
            bodyHeight: 476,
            bodyClass: "dc_tableCellElementBox",
            bodyHtml: LabelHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //渲染自定义属性框
        this.attributeComponents(
            "#dc_attr-box",
            (options && options.Attributes) || {},
            ctl
        );
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        GetOrChangeData(dcPanelBody, options);
        if (options && options.ValueBinding) {
            dcPanelBody
                .find("#dc_DataSource")
                .val(options.ValueBinding.DataSource || "");
            dcPanelBody
                .find("#dc_BindingPath")
                .val(options.ValueBinding.BindingPath || "");
        }
        if (options.Style && options.Style) {
            ctl.ownerDocument.getElementById("dc_PaddingTop").value =
                options.Style.PaddingTop;
            ctl.ownerDocument.getElementById("dc_PaddingBottom").value =
                options.Style.PaddingBottom;
            ctl.ownerDocument.getElementById("dc_PaddingLeft").value =
                options.Style.PaddingLeft;
            ctl.ownerDocument.getElementById("dc_PaddingRight").value =
                options.Style.PaddingRight;
        }
        if (options && options.BorderRenderVisibility) {
            SetBorderOrContentRenderVisibility(
                "#dc_BorderRenderVisibility",
                options.BorderRenderVisibility
            );
        }
        if (options && options.ContentRenderVisibility) {
            SetBorderOrContentRenderVisibility(
                "#dc_ContentRenderVisibility",
                options.ContentRenderVisibility
            );
        }
        let that = this;
        function getBorderOrContentRenderVisibility(id) {
            let arr = dcPanelBody.find(id).find('input[type="checkbox"]');
            let valueArr = [];
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].checked) {
                    valueArr.push(arr[i].getAttribute("attrValue"));
                }
            }
            return valueArr.join(",");
        }
        function SetBorderOrContentRenderVisibility(id, RenderVisibility) {
            let attrValue = RenderVisibility.split(",");
            for (var i = 0; i < attrValue.length; i++) {
                let itemDom = dcPanelBody
                    .find(id)
                    .find(`input[attrValue=${attrValue[i]}]`);
                jQuery(itemDom).prop("checked", true);
            }
            let arr = dcPanelBody.find(id).find('input[type="checkbox"]');
        }
        //背景色赋值
        if (options && options.Style && options.Style.BackgroundColorString) {
            var dc_TableCellBackgroundText_box = jQuery(ctl).find('#dc_TableCellBackgroundText_box');
            dc_TableCellBackgroundText_box.css("background-color", options.Style.BackgroundColorString);
            dc_TableCellBackgroundText_box.attr("data-value", options.Style.BackgroundColorString);
        }

        //单元格背景颜色 - 点击色块弹出颜色选择器
        const tableCellBackgroundColorBox = jQuery(ctl).find('#dc_TableCellBackgroundText_box')[0];
        if (tableCellBackgroundColorBox) {
            jQuery(tableCellBackgroundColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_TableCellBackgroundText_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#FFFFFF'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }

        //[DUWRITER5_0-2632]20240515 lxy 判断是否选中了多个单元格，如果选中多个单元格，则禁用所有输入框，仅支持设置垂直对齐方式
        var selectTableCells = ctl.GetSelectTableCells();
        if (selectTableCells && selectTableCells.length >= 2) {
            dcPanelBody.find('input,select').attr('disabled', true);//禁用所有的输入框
            dcPanelBody.find('input').val('');//清空所有输入框
            // dcPanelBody.find('input').prop('checked', false);//取消所有勾选的输入框
            var selectAll = ctl.ownerDocument.querySelectorAll(".dc_tableCellElementBox select");
            selectAll.length && selectAll.forEach(item => item.selectedIndex = -1);//清空所有的下拉框
            //放开垂直对齐方式的输入框
            dcPanelBody.find("#dc_vertical").prop("disabled", false);
            //放开内边距输入框
            dcPanelBody.find("#dc_PaddingTop").prop("disabled", false);
            dcPanelBody.find("#dc_PaddingBottom").prop("disabled", false);
            dcPanelBody.find("#dc_PaddingLeft").prop("disabled", false);
            dcPanelBody.find("#dc_PaddingRight").prop("disabled", false);
            //放开复制模式的输入框

            dcPanelBody.find("#dc_CloneType").prop("disabled", false);
            dcPanelBody.find("#dc_CloneType").val("ClearDirectContentAndFieldContent");


        }

        function successFun() {
            //如果选中的是多个单元格，则需要对选中单元格循环设置属性
            if (selectTableCells && selectTableCells.length >= 2) {
                let vertical = dcPanelBody.find("#dc_vertical").val();//水平对齐方式
                //内边距
                let PaddingBottom = dcPanelBody.find("#dc_PaddingBottom").val();
                let PaddingLeft = dcPanelBody.find("#dc_PaddingLeft").val();
                let PaddingRight = dcPanelBody.find("#dc_PaddingRight").val();
                let PaddingTop = dcPanelBody.find("#dc_PaddingTop").val();
                let CloneType = dcPanelBody.find("#dc_CloneType").val();
                //设置属性
                let selectAllOptions = {
                    CloneType,
                    Style: {
                        VerticalAlign: vertical,
                        PaddingBottom,
                        PaddingLeft,
                        PaddingRight,
                        PaddingTop
                    }
                };
                selectTableCells.forEach(item => {
                    ctl.SetElementProperties(item.NativeHandle, selectAllOptions);
                });
                return;
            }

            let BorderRenderVisibility = getBorderOrContentRenderVisibility(
                "#dc_BorderRenderVisibility"
            );
            let ContentRenderVisibility = getBorderOrContentRenderVisibility(
                "#dc_ContentRenderVisibility"
            );
            let dcAttrBox = dcPanelBody.find('#dc_attr-box');
            let Attributes = that.attributeComponents_getAttributeObj(dcAttrBox);
            var _data = GetOrChangeData(dcPanelBody);
            let DataSource = dcPanelBody.find("#dc_DataSource").val();
            let BindingPath = dcPanelBody.find("#dc_BindingPath").val();
            let { Align, VerticalAlign, ValueExpression } = _data;
            //单元格内间距
            let PaddingTop = ctl.ownerDocument.getElementById("dc_PaddingTop").value;
            let PaddingBottom =
                ctl.ownerDocument.getElementById("dc_PaddingBottom").value;
            let PaddingLeft =
                ctl.ownerDocument.getElementById("dc_PaddingLeft").value;
            let PaddingRight =
                ctl.ownerDocument.getElementById("dc_PaddingRight").value;
            options = {
                ...options,
                ..._data,
                Attributes,
                ValueBinding: {
                    DataSource,
                    BindingPath,
                },
                Style: {
                    Align,
                    VerticalAlign,
                    PaddingTop,
                    PaddingBottom,
                    PaddingLeft,
                    PaddingRight,
                },
                PropertyExpressions: {
                    FormulaValue: ValueExpression
                },
                ContentRenderVisibility,
                BorderRenderVisibility,
            };
            delete options.Align;
            delete options.VerticalAlign;

            //设置背景颜色
            var dc_TableCellBackgroundText_box = jQuery(ctl).find('#dc_TableCellBackgroundText_box');
            if (dc_TableCellBackgroundText_box.attr("data-value")) {
                options['Style']['BackgroundColorString'] = dc_TableCellBackgroundText_box.attr("data-value");
            }


            ctl.SetElementProperties(ele, options);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTableCell());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 表格行
     * @param options 表格行属性
     * @param ctl 编辑器元素
     */
    tableRowDialog: function (options, ctl) {
        var ele = ctl.CurrentTableRow();
        if (options && options.ID) {
            ele = options.ID;
        }
        if (!options || typeof options != "object") {
            options = ctl.GetElementProperties(ele);
            if (options == null) {
                return false;
            }
        }

        var LabelHtml = `
        <div class="dcBody-content">
            <label class="dc_flex">
                <span>ID：</span>
                <input class="dc_full"  type="text" data-text="ID" />
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span>固定高度：</span>
                <input class="dc_full dc_full_SpecifyHeight dc_input_number_data_model"  type="number" data-text="SpecifyHeight" id="dc_SpecifyHeight" />
                <span  class="dc_data-text-model" dc-text-model="SpecifyHeight"></span>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span>复制模式：</span>
                <select class="dc_full" data-text="CloneType">
                    <option value="Default">继承上级设置</option>
                    <option value="ContentWithClearField">复制内容，但删除输入域中的内容</option>
                    <option value="Complete"> 完整的复制，包括输入域中的内容</option>
                    <option value="ClearDirectContentAndFieldContent">清空复制的普通内容和输入域的内容</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span>打印显示：</span>
                <select class="dc_full" data-text="PrintVisibility">
                    <option value="Visible">显示</option>
                    <option value="Hidden">隐藏</option>
                    <option value="None">隐藏而且不占位</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span >内容只读保护：</span>
                <select  class="dc_full" data-text="ContentReadonly">
                    <option value="Inherit">继承上级设置</option>
                    <option value="True">只读</option>
                    <option value="False">不只读</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span >启用授权控制：</span>
                <select  class="dc_full" data-text="EnablePermission">
                    <option value="Inherit">继承上级设置</option>
                    <option value="True">是</option>
                    <option value="False">否</option>
                </select>
            </label>
        </div>
        <div class="dcBody-content">
            <label class="dc_flex">
                <span >允许用户调整高度：</span>
                <select  class="dc_full" data-text="AllowUserToResizeHeight">
                   <option value="Inherit">继承上级设置</option>
                    <option value="True">是</option>
                    <option value="False">否</option>
                </select>
            </label>
        </div>
        
        
        <div class="dcBody-content">
            <div>
                <label>
                    <input type="checkbox" data-text="HeaderStyle">
                    <span>在各页顶端以标题形式重复出现</span>
                </label>
            </div>
            <div>
                <label>
                    <input type="checkbox" data-text="NewPage">
                    <span>强制分页</span>
                </label>
            </div> 
            <div>
                <label>
                    <input type="checkbox" data-text="CanSplitByPageLine">
                    <span>是否允许跨页</span>
                </label>
            </div> 
            <div>
                <label>
                    <input type="checkbox" data-text="PrintCellBorder">
                    <span>打印单元格边框</span>
                </label>
            </div> 
        </div>
        <div class="dc_Box">
            <h6 class="dc_title">表达式：</h6>
            <label>
                <span>可见性表达式：</span>
                <input id="dc_VisibleExpression" data-text="VisibleExpression"  type="text">
                <button class="dc_visible_expression">示例</button>
            </label>
            <label>
                <span>打印可见性表达式：</span>
                <input id="dc_PrintVisibilityExpression" data-text="PrintVisibilityExpression" type="text">
                <button class="dc_visible_expression">示例</button>
            </label>
        </div>
        <div class="dc_Box">
            <h6 class="dc_title">赋值属性：</h6>
            <div class="dc_tab3Content">
                <label>
                    <span>数据源名称：</span>
                    <input  id="dc_DataSource" data-text="Datasource" type="text" />
                </label>
                <label>
                    <span>绑定路径：</span>
                    <input id="dc_BindingPath" data-text="BindingPath" type="text" />
                </label>
            </div>
        </div>
        <div class="dc_Box" >
            <h6 class="dc_title">背景颜色属性：</h6>
            <div id="dc_TableRowBackground">
                <div style="display:flex;align-items:center;">
                    表格行背景色：
                    <label style="display:flex;align-items:center;">
                        <div id="dc_TableRowBackgroundText_box" data-value="" ></div>
                    </label>
                </div>
            </div>
        </div>
        <div class="dc_Box dcBody-content">
                <h6 class="dc_title">自定义属性</h6>
                <div id="dc_attr-box"></div>
        </div>  
`;
        var dialogOptions = {
            title: "表格行属性对话框",
            bodyHeight: 400,
            bodyClass: "dc_tableRow",
            bodyHtml: LabelHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");

        //获取是否选中多个表格行
        var selectTableCells = ctl.GetSelectTableCells();
        //判断选中的单元格是否为不同的表格行
        var selectTableRow = [];
        if (selectTableCells && selectTableCells.length > 1) {
            for (var i = 0; i < selectTableCells.length; i++) {
                let selectCellItem = selectTableCells[i];
                if (selectCellItem && selectCellItem.TypeName && selectCellItem.TypeName === "XTextTableCellElement") {
                    if (selectTableRow.indexOf(selectCellItem.RowIndex) == -1) {
                        selectTableRow.push(selectCellItem.RowIndex);
                    }
                }
            }
        }


        //渲染自定义属性框
        this.attributeComponents(
            "#dc_attr-box",
            (options && options.Attributes) || {},
            ctl
        );


        var Box2 = dcPanelBody.find(".dcBody-contentflex").find("#Box2")[0];
        var that = this;
        var opts = {};
        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(options, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(opts, _txt, _value);
        });
        // 设置禁用
        dc_dialogContainer.find("#Visible").change(function () {
            that.changeFormDisable(Box2, !this.checked);
        });
        GetOrChangeData(dcPanelBody, opts);
        if (options && options.ValueBinding) {
            dcPanelBody
                .find("#dc_DataSource")
                .val(options.ValueBinding.DataSource || "");
            dcPanelBody
                .find("#dc_BindingPath")
                .val(options.ValueBinding.BindingPath || "");
        }
        //可见性表达式 DUWRITER5_0-3053 VisibleExpression和PropertyExpressions.VisibleExpression都指向可见性表达式属性，VisibleExpression优先级更高
        if (options.VisibleExpression === null || options.VisibleExpression === undefined) {
            dcPanelBody
                .find("#dc_VisibleExpression")
                .val((options.PropertyExpressions && options.PropertyExpressions.Visible) || "");
        }
        //打印可见性表达式 DUWRITER5_0-3053
        if (options.PrintVisibilityExpression === null || options.PrintVisibilityExpression === undefined) {
            dcPanelBody
                .find("#dc_PrintVisibilityExpression")
                .val((options.PropertyExpressions && options.PropertyExpressions.PrintVisibility) || "");
        }

        //背景色赋值
        if (options && options.Style && options.Style.BackgroundColorString) {
            var dc_TableRowBackgroundText_box = jQuery(ctl).find('#dc_TableRowBackgroundText_box');
            dc_TableRowBackgroundText_box.css("background-color", options.Style.BackgroundColorString);
            dc_TableRowBackgroundText_box.attr("data-value", options.Style.BackgroundColorString);
        }

        //表格行背景颜色 - 点击色块弹出颜色选择器
        const tableRowBackgroundColorBox = jQuery(ctl).find('#dc_TableRowBackgroundText_box')[0];
        if (tableRowBackgroundColorBox) {
            jQuery(tableRowBackgroundColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_TableRowBackgroundText_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#FFFFFF'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }


        //如果是选中了多个表格行
        if (selectTableRow.length > 1) {
            dcPanelBody.find('input,select').attr('disabled', true);//禁用所有的输入框
            dcPanelBody.find('input').val('');//清空所有输入框
            dcPanelBody.find('input').prop('checked', false);//取消所有勾选的输入框
            //清空选中
            var selectAll = ctl.ownerDocument.querySelectorAll("select.dc_full");
            selectAll.length && selectAll.forEach(item => item.selectedIndex = -1);//清空所有的下拉框
            //放开固定高度输入框
            dcPanelBody.find('#dc_SpecifyHeight').attr('disabled', false);//禁用所有的输入框
            dcPanelBody.find('#dc_SpecifyHeight').val(0);//禁用所有的输入框
        }


        function successFun() {
            //当选中多个表格行，只设置选中行的高度
            if (selectTableRow.length > 1) {
                var rowHeightVal = dcPanelBody.find('#dc_SpecifyHeight').val();
                rowHeightVal = parseInt(rowHeightVal);
                var currentTableProp = ctl.GetElementProperties(ctl.CurrentTable());
                let RowsHeight = currentTableProp.RowsHeight;
                for (var i = 0; i < selectTableRow.length; i++) {
                    let index = selectTableRow[i];
                    RowsHeight[index] = rowHeightVal;
                }
                ctl.SetElementProperties(currentTableProp.NativeHandle, { RowsHeight });
                return;
            }

            let dcAttrBox = dcPanelBody.find('#dc_attr-box');
            let Attributes = that.attributeComponents_getAttributeObj(dcAttrBox);
            let DataSource = dcPanelBody.find("#dc_DataSource").val();
            let BindingPath = dcPanelBody.find("#dc_BindingPath").val();
            var _data = GetOrChangeData(dcPanelBody);
            let { PrintVisibilityExpression, VisibleExpression } = _data;
            options = {
                ...options,
                ..._data,
                Attributes,
                ValueBinding: {
                    DataSource, BindingPath
                },
                PropertyExpressions: {
                    PrintVisibility: PrintVisibilityExpression,
                    Visible: VisibleExpression
                },
            };

            // //设置背景颜色

            var dc_TableRowBackgroundText_box = jQuery(ctl).find('#dc_TableRowBackgroundText_box');
            if (dc_TableRowBackgroundText_box.attr("data-value")) {
                options['Style']['BackgroundColorString'] = dc_TableRowBackgroundText_box.attr("data-value");
            }

            ctl.SetElementProperties(ctl.CurrentTableRow(), options);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTableRow());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 表格列
     * @param options 把绑定数据源元素插入到该元素位置最后面
     * @param ctl 编辑器元素
     */
    tableColumnDialog: function (options, ctl) {
        var ele = ctl.CurrentTableColumn();
        if (!options || typeof options != "object") {
            options = ctl.GetElementProperties(ele);
            if (options == null) {
                return false;
            }
        }
        var LabelHtml = `
         <div class="dc_Box">
            <h6 class="dc_title">赋值属性：</h6>
            <div class="dc_tab3Content">
                <label>
                    <span>数据源名称：</span>
                    <input  id="dc_DataSource" data-text="Datasource" type="text" />
                </label>
                <label>
                    <span>绑定路径：</span>
                    <input  id="dc_BindingPath" data-text="BindingPath" type="text" />
                </label>
            </div>
        </div>
        <div class="dc_Box" >
            <h6 class="dc_title">背景颜色属性：</h6>
            <div id="dc_TableColumnBackground" >
                <span>表格列背景色：</span>
                <label>
                    <div id="dc_TableColumnBackgroundText_box" data-value="" ></div>
                </label>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "表格列属性对话框",
            bodyHeight: 210,
            bodyClass: "dc_tableColumn",
            bodyHtml: LabelHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //渲染自定义属性框
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        if (options && options.ValueBinding) {
            dcPanelBody
                .find("#dc_DataSource")
                .val(options.ValueBinding.DataSource || "");
            dcPanelBody
                .find("#dc_BindingPath")
                .val(options.ValueBinding.BindingPath || "");
        }

        //背景色赋值
        if (options && options.Style && options.Style.BackgroundColorString) {
            var dc_TableColumnBackgroundText_box = jQuery(ctl).find('#dc_TableColumnBackgroundText_box');
            dc_TableColumnBackgroundText_box.css("background-color", options.Style.BackgroundColorString);
            dc_TableColumnBackgroundText_box.attr("data-value", options.Style.BackgroundColorString);
        }

        //表格列背景颜色 - 点击色块弹出颜色选择器
        const tableColumnBackgroundColorBox = jQuery(ctl).find('#dc_TableColumnBackgroundText_box')[0];
        if (tableColumnBackgroundColorBox) {
            jQuery(tableColumnBackgroundColorBox).off('click').on('click', function () {
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_TableColumnBackgroundText_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#FFFFFF'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }



        function successFun() {
            let DataSource = dcPanelBody.find("#dc_DataSource").val();
            let BindingPath = dcPanelBody.find("#dc_BindingPath").val();
            var BackgroundColorString = null;
            // //设置背景颜色
            var dc_TableColumnBackgroundText_box = jQuery(ctl).find('#dc_TableColumnBackgroundText_box');
            if (dc_TableColumnBackgroundText_box.attr("data-value")) {
                BackgroundColorString = dc_TableColumnBackgroundText_box.attr("data-value");
            }

            var index = options.Index;
            //修改表格列背景颜色
            ctl.HighlightTableRowColumn(ctl.CurrentTable(), -1, index, BackgroundColorString, false);
            options = {
                ValueBinding: {
                    DataSource,
                    BindingPath,
                },
                Style: {
                    BackgroundColorString
                }
            };
            ctl.SetElementProperties(ele, options);
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTableColumn());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },
    /**
        * 表格列宽度属性对话框
        * @param options 把绑定数据源元素插入到该元素位置最后面
        * @param ctl 编辑器元素
        */
    tableColumnWidthDialog: function (options, ctl) {
        var ele = ctl.CurrentTableColumn();
        if (!options || typeof options != "object") {
            options = ctl.GetElementProperties(ele);
            if (options == null) {
                return false;
            }
        }
        var tableColumnWidthHtml = `
            <div>
                <span class="dc_tableColumnWidth_title">请输入列宽度（像素）：</span>
                <input id="dc_ColumnWidth" min="1" max="1000" class="dc_tableColumnWidth_input" type="number"/>
                <span class="dc_tableColumnWidth_tips">请输入1-1000之间的数值，单位：(1/300英寸)</span>
            </div>
        `;
        var dialogOptions = {
            title: "表格列宽",
            bodyHeight: 150,
            dialogContainerBodyWidth: 410,
            bodyClass: "dc_tableColumnWidth",
            bodyHtml: tableColumnWidthHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //渲染自定义属性框
        var dc_ColumnWidth = jQuery(ctl).find("#dc_ColumnWidth");
        dc_ColumnWidth.val(options.Width || 100);


        function successFun() {
            var dc_ColumnWidth = jQuery(ctl).find("#dc_ColumnWidth");
            var ColumnWidth = dc_ColumnWidth.val();
            var cells = ctl.GetSelectTableCells();
            if (cells && cells.length && cells.length > 1) {
                //批量设置表格列宽度
                var table = ctl.GetElementProperties(ctl.CurrentTable());
                const result = cells.map(item => ({ ColIndex: item.ColIndex }));
                const uniqueArr = [...new Set(result.map(item => item.ColIndex))].map(value => ({ ColIndex: value }));
                uniqueArr.forEach(colindex => {
                    ctl.SetElementProperties(table.Columns[colindex.ColIndex], { Width: ColumnWidth });
                });
            } else {
                //单个设置表格列宽度
                ctl.SetElementProperties(ele, { Width: ColumnWidth });
            }




            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTableColumn());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 单元格网格线
     * @param options 属性
     * @param ctl 编辑器元素
     */
    cellGridlineDialog: function (options, ctl, isInsertMode) {
        let cell = ctl.CurrentTableCell();
        if (!cell) {
            return;
        }
        options = ctl.GetElementProperties(cell);

        var cellGridlineHtml = `
        <div class="dc_cellGridlineBox">
            <div>
                <input type="checkbox" name="Visible" id="dc_cellGridlineVisible" data-text="Visible">
                <span>网格是否显示</span>
            </div>
            <div id="dc_cellGridlineContent" class="dc_cellGridlineContent dc_Box">
                <h6 class="dc_title">网格线属性</h6>
                <div>
                    <span class="dc_cellGridlineBox-span">网格线样式:</span>
                    <select name="LineStyle" id="dc_LineStyle" data-text="LineStyle"></select>
                </div>
                <div>
                    <span class="dc_cellGridlineBox-span">网格线颜色:</span>
                    <div id="dc_cellGridlineColor_box" data-value="" data-text="ColorValue" style="display: inline-block;width: 164px;height: 10px;border: 1px solid rgb(217, 217, 217);border-radius: 4px;cursor: pointer;vertical-align: middle;margin-left: 5px;"></div>
                </div>
                <div>
                    <span class="dc_cellGridlineBox-span">网格线宽度(1/300英寸):</span>
                    <input class="dc_cellGridlineBox-input"  type="number" name="LineWidth" data-text="LineWidth">
                </div>
                <div>
                    <span class="dc_cellGridlineBox-span">网格线之间的跨度(CM):</span>
                    <input class="dc_cellGridlineBox-input" type="number" name="GridSpanInCM" data-text="GridSpanInCM">
                </div>
                <div>
                    <input type="checkbox" name="AlignToGridLine" data-text="AlignToGridLine">
                    <span>文本行对齐到网格线</span>
                </div>
                <div>
                    <input type="checkbox" name="Printable" data-text="Printable">
                    <span>打印预览是否显示</span>
                </div>
            </div>
           
        </div>
        `;
        var dialogOptions = {
            title: "单元格网格线",
            bodyClass: "dc_cellGridline",
            bodyHtml: cellGridlineHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        for (var i = 0; i < DASHSTYLE.length; i++) {
            dcPanelBody
                .find("#dc_LineStyle")
                .append(
                    "<option value = '" +
                    DASHSTYLE[i].name +
                    "' > " +
                    DASHSTYLE[i].show +
                    DASHSTYLE[i].name +
                    "</option >"
                );
        }
        let GridLineOptions = options.GridLine
            ? options.GridLine
            : {
                AlignToGridLine: true, //文本行对齐到网格线
                ColorValue: "", //网格线颜色
                GridSpanInCM: 1, //网格线之间的宽度
                LineStyle: "Solid", //网格线样式
                LineWidth: 1, //网格线宽度
                Printable: true, //打印预览是否显示
                Visible: true, //网格是否显示
            };
        //初始化禁用网格线相关输入框
        var selectArr = dcPanelBody.find("#dc_cellGridlineContent").find("select");
        let inputArr = dcPanelBody.find("#dc_cellGridlineContent").find("input");
        for (var i = 0; i < inputArr.length; i++) {
            inputArr[i].disabled = !GridLineOptions.Visible;
        }
        for (var i = 0; i < selectArr.length; i++) {
            selectArr[i].disabled = !GridLineOptions.Visible;
        }


        dcPanelBody.find("input[data-text=Visible]").on("click", function (e) {
            var isVisible = jQuery(this).is(":checked");
            var selectArr = dcPanelBody.find("#dc_cellGridlineContent").find("select");
            let inputArr = dcPanelBody.find("#dc_cellGridlineContent").find("input");
            dcPanelBody.find("#dc_LineStyle").attr("disabled", !isVisible);
            for (var i = 0; i < inputArr.length; i++) {
                inputArr[i].disabled = !isVisible;
            }
            for (var i = 0; i < selectArr.length; i++) {
                selectArr[i].disabled = !isVisible;
            }
        });

        dcPanelBody.find("[data-text]").each(function () {
            var _el = jQuery(this);
            var _txt = _el.attr("data-text");
            var low_txt = _txt.toLowerCase();
            var _value = getDown(GridLineOptions, low_txt);
            if (_value == undefined) {
                _value = "";
            }
            getDown(GridLineOptions, _txt, _value);
        });
        GetOrChangeData(dcPanelBody, GridLineOptions);

        // 网格线颜色 - 点击色块弹出颜色选择器
        const gridlineColorBox = jQuery(dcPanelBody).find('#dc_cellGridlineColor_box')[0];
        if (gridlineColorBox) {
            // 初始化颜色显示框
            const colorValue = GridLineOptions.ColorValue || '#000000';
            gridlineColorBox.style.backgroundColor = colorValue;
            gridlineColorBox.setAttribute('data-value', colorValue);

            jQuery(gridlineColorBox).off('click').on('click', function () {
                if (!jQuery(dcPanelBody).find('#dc_cellGridlineVisible')[0].checked) {
                    return;
                }
                var element = this;
                DC_ColorPickerModule.show({
                    id: 'dc_cellGridlineColor_picker',
                    triggerElement: element,
                    defaultColor: element.getAttribute("data-value") || '#000000'
                }, function (color) {
                    element.style.backgroundColor = color;
                    element.setAttribute("data-value", color);
                });
            });
        }

        //如果没有表格行则重置选择
        if (!options.GridLine) {
            // console.log(111);
            // console.log(dcPanelBody.find("input[data-text=Visible]")[0]);
            dcPanelBody.find("input[data-text=Visible]")[0].click();
        }
        function successFun() {
            var cell = ctl.CurrentTableCell();
            var _data = GetOrChangeData(dcPanelBody);
            //wyc20230713:该对话框改成只设置网格线不处理其它属性了
            options = {
                GridLine: _data,
            };
            console.log(options, '=================');
            //判断是否为选中多个单元格
            var selectTableCells = ctl.GetSelectTableCells() || [];
            if (selectTableCells && selectTableCells.length && selectTableCells.length > 1) {
                ctl.SetSelectTableCellGridLineInfo(options);
                // console.log('设置选择多个单元格的网格线', _data);
            } else {
                ctl.SetElementProperties(cell, options);
            }
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTableCell());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 单元格斜分线
     * @param options 属性
     * @param ctl 编辑器元素
     */
    cellDiagonalLineDialog: function (options, ctl, isInsertMode) {
        let cell = ctl.CurrentTableCell();
        if (!cell) {
            return;
        }
        options = ctl.GetElementProperties(cell);
        let { SlantSplitLineStyle } = options;
        var cellDiagonalLineHtml = `
        <div class="dc_cellDiagonalLineBox">
           <div class="dc_slantsplitlinestyle-box"> 
                <span>斜分线样式:</span>
                <p id="dc_slantsplitlinestyle">None</p>
            </div>
            <div class="dc_slantsplitlinestyle-item" attrId='None'> 
               <div class="dc_None"></div> 
               <span> None </span>
            </div>
            <div  class="dc_slantsplitlinestyle-item" attrId='TopLeftOneLine'>
                <div class="dc_TopLeftOneLine">
                    <p></p>
                </div>
                <span> TopLeftOneLine </span>
            </div>

            <div  class="dc_slantsplitlinestyle-item" attrId='TopLeftTwoLines'>
                <div class="dc_TopLeftTwoLines">
                    <p></p>
                    <p></p>
                </div>
                <span>TopLeftTwoLines</span>
            </div>

            <div  class="dc_slantsplitlinestyle-item" attrId='TopRightOneLine'>
                <div class="dc_TopRightOneLine">
                    <p></p>
                </div>
                <span>TopRightOneLine</span>
            </div>
            <div  class="dc_slantsplitlinestyle-item" attrId='TopRightTwoLines'>
                <div class="dc_TopRightTwoLines">
                    <p></p>
                    <p></p>
                </div>
                <span>TopRightTwoLines</span>
            </div>
            <div  class="dc_slantsplitlinestyle-item" attrId='BottomRightOneLine'>
                <div class="dc_BottomRightOneLine">
                    <p></p>
                </div>
                <span>BottomRightOneLine</span>
            </div>
            <div  class="dc_slantsplitlinestyle-item" attrId='BottomRigthTwoLines'>
                <div class="dc_BottomRigthTwoLines">
                    <p></p>
                    <p></p>
                </div>
                <span>BottomRigthTwoLines</span>
            </div>
            <div  class="dc_slantsplitlinestyle-item" attrId='BottomLeftOneLine'>
                <div class="dc_BottomLeftOneLine">
                    <p></p>
                </div>
                <span>BottomLeftOneLine</span>
            </div>
            <div  class="dc_slantsplitlinestyle-item" attrId='BottomLeftTwoLines'>
                <div class="dc_BottomLeftTwoLines">
                    <p></p>
                    <p></p>
                </div>
                <span>BottomLeftTwoLines</span>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "单元格斜分线",
            bodyClass: "dc_cellDiagonalLine",
            bodyHtml: cellDiagonalLineHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        let slantsplitlinestyleArr = jQuery(ctl).find(
            ".dc_slantsplitlinestyle-item"
        );
        if (SlantSplitLineStyle) {
            for (var i = 0; i < slantsplitlinestyleArr.length; i++) {
                if (
                    slantsplitlinestyleArr[i].getAttribute("attrId") ===
                    SlantSplitLineStyle
                ) {
                    slantsplitlinestyleArr[i].style = "background:#d7e4f2;";
                    jQuery(ctl)
                        .find("#dc_slantsplitlinestyle")
                        .html(slantsplitlinestyleArr[i].id);
                }
            }
        }
        slantsplitlinestyleArr.click(function () {
            for (var i = 0; i < slantsplitlinestyleArr.length; i++) {
                slantsplitlinestyleArr[i].style = "background:#fafafa";
            }
            this.style = "background:#d7e4f2;";
            jQuery(ctl)
                .find("#dc_slantsplitlinestyle")
                .html(this.getAttribute("attrId"));
        });
        function successFun() {
            let SlantSplitLineStyle = jQuery(ctl).find("#dc_slantsplitlinestyle").html();
            SlantSplitLineStyle = SlantSplitLineStyle ? SlantSplitLineStyle : "None";
            ctl.SetElementProperties(ctl.CurrentTableCell(), { SlantSplitLineStyle });
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentTableCell());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 编辑图片对话框fabric.js
     * @param options 图片属性
     * @param ctl 编辑器元素
     */
    imgEditDialog: function (options, ctl, isInsertMode) {
        //[DUWRITER5_0-2346]20240423 lxy 如果没有图片属性、或者有图片属性但是图片的路径是空，则不弹出图片编辑对话框
        if (!options || (options && !options.Src)) {
            return false;
        }
        if (ctl.ownerDocument.defaultView.frameElement) {
            fabric.document = ctl.ownerDocument;
        } else {
            fabric.document = window.document;
        }
        //[DUWRITER5_0-2025]20240314 lxy 判断指定元素能否修改;
        var canModify = options && ctl.GetCanModify(options.NativeHandle);
        if (canModify === false) {
            return false;
        }
        var imgEditHtml = `
        <div id="dc_canvas_box">
            <div class="dc_img_tools_one">
                <div id="dc_img_zoom_box">
                    <div class="zoomBtn" step="0.1" id="dc_img_zoomIn" titlt="放大">
                        <svg class="icon" width="20px" height="20px" viewBox="0 0 1024 1024" version="1.1"><path fill="#707070" d="M469.333333 469.333333V234.666667a21.333333 21.333333 0 0 1 21.333334-21.333334h42.666666a21.333333 21.333333 0 0 1 21.333334 21.333334V469.333333h234.666666a21.333333 21.333333 0 0 1 21.333334 21.333334v42.666666a21.333333 21.333333 0 0 1-21.333334 21.333334H554.666667v234.666666a21.333333 21.333333 0 0 1-21.333334 21.333334h-42.666666a21.333333 21.333333 0 0 1-21.333334-21.333334V554.666667H234.666667a21.333333 21.333333 0 0 1-21.333334-21.333334v-42.666666a21.333333 21.333333 0 0 1 21.333334-21.333334H469.333333z"/></svg>
                    </div>
                    <select id="zoomSelect">
                        <option value=""></option>
                        <option value="0.1">10%</option>
                        <option value="0.3">30%</option>
                        <option value="0.5">50%</option>
                        <option value="1" selected>100%</option>
                        <option value="1.5">150%</option>
                        <option value="2">200%</option>
                        <option value="4">400%</option>
                        <option value="autowidth">适应宽度</option>
                        <option value="autoheight">适合页面大小</option>
                    </select>
                    <div class="zoomBtn" step="-0.1" id="dc_img_zoomOut" titlt="缩小">
                        <svg class="icon" width="20px" height="20px" viewBox="0 0 1024 1024" version="1.1">
                            <path fill="#707070" d="M213.333333 469.333333m21.333334 0l554.666666 0q21.333333 0 21.333334 21.333334l0 42.666666q0 21.333333-21.333334 21.333334l-554.666666 0q-21.333333 0-21.333334-21.333334l0-42.666666q0-21.333333 21.333334-21.333334Z"/>
                        </svg>
                    </div>
                </div>
                <div class="dc_img_tools_full_box">
                    <div id="dc_imgFullScreen">${IMGEDITSVGOBJECT.QUANPING}</div>
                    <div id="dc_imgCancelFullScreen">${IMGEDITSVGOBJECT.QUXIAOQUANPING}</div>
                </div>
            </div>
            <div id="dc_wrap">
                
                <div id="dc_wrap_imgBox">
                    <canvas width="300" height="200" id="dc_show_canvas" >
                        <p>不支持canvas</p>
                    </canvas>
                </div>



                <div class="dc_Box dc_imgEdit_Content">
                    <div class="dc_list_box">
                        <div class="dc_cg">
                            <div class="dc_mouseMode_box_title">
                                <div class="dc_mouseMode_box_title_line"></div>
                                <div class="dc_mouseMode_box_title_text">常规</div>
                                <div class="dc_mouseMode_box_title_line"></div>
                            </div>
                            <div class="dc_mouseMode_box">
                                <button class="dc_undoBtn dc_mouseModeBtn" title="撤销">${IMGEDITSVGOBJECT.CHEXIAO}</button>
                                <button class="dc_redoBtn dc_mouseModeBtn" title="重做">${IMGEDITSVGOBJECT.CHONGZUO}</button>
                                <button id="dc_del" class="dc_mouseModeBtn" title="删除">${IMGEDITSVGOBJECT.SHANCHU}</button>
                            </div>
                            <div class="dc_mouseMode_box">
                              <label title="填充背景色" class="dc_imgEdit_fill_label">
                                    ${IMGEDITSVGOBJECT.TIANCHONG}
                                    <input type="color" name="fill" id="dc_fill_color">
                                </label>
                                <label title="边框色" class="dc_imgEdit_stroke_label">
                                    ${IMGEDITSVGOBJECT.BIANKUANGSE}
                                    <input type="color" name="stroke" id="dc_stroke_color">
                                </label>
                                <button class="dc_mouseMode" value="SprayBrushMode" title="喷枪">${IMGEDITSVGOBJECT.PENQIANG}</button>
                            </div>
                            <div class="dc_mouseMode_box">
                                <button class="dc_mouseMode" value="Line" title="画直线">${IMGEDITSVGOBJECT.XIANDUAN}</button>
                                <button class="dc_mouseMode" value="draw" title="画笔">${IMGEDITSVGOBJECT.HUABI}</button>
                                <button class="dc_mouseMode" value="Triangle" title="箭头">${IMGEDITSVGOBJECT.JIANTOU}</button>
                            </div>
                            <div class="dc_mouseMode_box_title" style="margin-top:20px;">
                                <div class="dc_mouseMode_box_title_line"></div>
                                <div class="dc_mouseMode_box_title_text">图案</div>
                                <div class="dc_mouseMode_box_title_line"></div>
                            </div>
                             <div class="dc_mouseMode_box">
                                <button class="dc_mouseMode" value="GLY" >
                                    <img src="${IMGEDITSVGOBJECT.GLY}" />
                                </button>
                                <button class="dc_mouseMode" value="GY">
                                    <img src="${IMGEDITSVGOBJECT.GY}" />
                                </button>
                                <button class="dc_mouseMode" value="SLY">
                                    <img src="${IMGEDITSVGOBJECT.SLY}" />
                                </button>
                                <button class="dc_mouseMode" value="SY">
                                    <img src="${IMGEDITSVGOBJECT.SY}" />
                                </button>
                                 <button class="dc_mouseMode" value="ZY" >
                                    <img src="${IMGEDITSVGOBJECT.ZY}" />
                                </button>
                            </div>
                            <div class="dc_mouseMode_box_title" style="margin-top:20px;">
                                <div class="dc_mouseMode_box_title_line"></div>
                                <div class="dc_mouseMode_box_title_text">图形</div>
                                <div class="dc_mouseMode_box_title_line"></div>
                            </div>

                            <div class="dc_mouseMode_box">
                                <button class="dc_mouseMode" value="Rect" title="画矩形">${IMGEDITSVGOBJECT.JUXING}</button>
                                <button class="dc_mouseMode" value="Ellipse" title="画椭圆">${IMGEDITSVGOBJECT.TUOYUAN}</button>
                                <button class="dc_mouseMode" value="TriangleShape" title="画三角形">${IMGEDITSVGOBJECT.SANJIAO}</button>
                            </div>
                            <div>
                                <label class="dc_mouseMode_label" title="图形绘制时是否添加默认文字">
                                    文本：<input type="checkbox" id="dc_default_text" />
                                </label>
                                <label class="dc_mouseMode_label" title="图形绘制时是否添加底纹">
                                    底纹：<select title="底纹填充" id="dc_back_img_color">
                                            <option value="0">
                                                空白
                                            </option>
                                            <option value="1">
                                                触觉减退
                                            </option>
                                            <option value="2">
                                                触觉消失
                                            </option>
                                            <option value="3">
                                                触觉过敏或异常
                                            </option>
                                            <option value="4">
                                                痛觉减退
                                            </option>
                                            <option value="5">
                                                痛觉消失
                                            </option>
                                            <option value="6">
                                                痛觉过敏或异常
                                            </option>
                                            <option value="7">
                                                震动觉减退或异常
                                            </option>
                                            <option value="8">
                                                位置觉减退或异常
                                            </option>
                                            <option value="9">
                                                浅感觉全部消失
                                            </option>
                                            <option value="10">
                                                深浅感觉全部消失
                                            </option>
                                            <option value="11">
                                                Ⅰ度
                                            </option>
                                            <option value="12">
                                                Ⅱ度
                                            </option>
                                            <option value="13">
                                                深Ⅱ度
                                            </option>
                                            <option value="14">
                                                Ⅲ度
                                            </option>
                                        </select>
                                </label>
                            </div>
                            </div>
                          </div>
                        <div class="dc_mouseMode_box_title" style="margin-top:20px;">
                            <div class="dc_mouseMode_box_title_line"></div>
                            <div class="dc_mouseMode_box_title_text">文本</div>
                            <div class="dc_mouseMode_box_title_line"></div>
                        </div>
                        <div class="dc_wz">
                            <button class="dc_mouseMode" id="dc_InsertText" title="插入文本"  value="SpecialText">${IMGEDITSVGOBJECT.CHARU}</button>
                            <div class="dc_imgEditFont_box">
                                <label title="字号：" class="dc_imgEdit_fontsize_label">
                                    <div style="padding-left:4px;">
                                    ${IMGEDITSVGOBJECT.ZIHAO}：</div>
                                    <select id="dc_fontSize" name="fontSize">
                                    </select>
                                </label>
                                <label title="字体样式：" class="dc_imgEdit_fontsize_label">
                                <div style="padding-left:4px;margin:4px 0;">
                                    ${IMGEDITSVGOBJECT.ZITIYANGSHI}：</div>
                                    <select id="dc_fontFamily" name="fontFamily">
                                    </select>
                                </label>
                                <label title="字体色" class="dc_imgEdit_fontcolor_label">
                                  <div style="padding-left:6px;">
                                    ${IMGEDITSVGOBJECT.ZITIYANSE} ：</div>   
                                    <input type="color" id="dc_fontColor" name="fontColor">
                                </label>
                                <div class="dc_font_base_label" style="font-size:12px;color:#606266;margin-top:6px;">
                                <div> 内容：</div>   
                                    <select id="dc_font_base_select">
                                        <option value="默认文字">默认文字</option>
                                        <option value="◇">◇</option>
                                        <option value="◆">◆</option>
                                        <option value="×">×</option>
                                        <option value="＋">＋</option>
                                        <option value="●">●</option>
                                        <option value="○">○</option>
                                        <option value="△">△</option>
                                        <option value="★">★</option>
                                        <option value="←">←</option>
                                        <option value="→">→</option>
                                        <option value="↑">↑</option>
                                        <option value="↓">↓</option>
                                        <option value="Ⅰ°">Ⅰ°</option>
                                        <option value="Ⅱ°">Ⅱ°</option>
                                        <option value="Ⅲ°">Ⅲ°</option>
                                        <option value="Ⅳ°">Ⅳ°</option>
                                        <option value="Ⅴ°">Ⅴ°</option>
                                    </select>
                                </div>
                            </div>
                        </div>

                        <div class="dc_mouseMode_box_title" style="margin-top:20px;">
                            <div class="dc_mouseMode_box_title_line"></div>
                            <div class="dc_mouseMode_box_title_text">其他</div>
                            <div class="dc_mouseMode_box_title_line"></div>
                        </div>
                        <div class="dc_mouseMode_box">
                            <button class="dc_mouseMode" value="rotateLeft" id="dc_rotate_left" title="向左旋转">${IMGEDITSVGOBJECT.XIANGZUOXUANZHUAN}</button>
                            <button class="dc_mouseMode" value="rotateRight" id="dc_rotate_right" title="向右旋转">${IMGEDITSVGOBJECT.XIANGYOUXUANZHUAN}</button>
                        </div>
                      
                        <div class="dc_mouseMode_box" style="margin-top:10px;">
                            <button class="dc_mouseMode" value="cut" id="dc_cut" title="剪切">${IMGEDITSVGOBJECT.JIANQIE}</button>
                            <div class="dc_cut_line"></div>
                            <div id="dc_cut_cencal" title="取消剪裁">${IMGEDITSVGOBJECT.QUXIAO}</div>
                            <div id="dc_cut_confirm" class="dc_cut_confirm" title="使用剪裁" style="color:#259e84">${IMGEDITSVGOBJECT.QUEREN}应用</div>
                        </div>
                        
                </div>
            </div>
        </div>`;

        var dialogOptions = {
            title: "图片编辑对话框",
            bodyHeight: 600,
            dialogContainerBodyWidth: 700,
            bodyClass: "dc_imgEdit",
            bodyHtml: imgEditHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        /** 撤销&重做 */
        var ActionBackNext = {
            state: {
                // 指针标记当前位置
                pointer: -1,
                // 操作记录
                operateList: [],
                // 深度，记录步骤次数
                // deep: 20,
            },
            constructor(canvas) {
                // 保存 canvas 对象
                this.state["canvas"] = canvas;
                // 绑定键盘事件
                this.bindKeyBoard(canvas);
                // 添加也要保存
                this.operateData();
                //鼠标选中事件
                canvas.on("selection:created", function (e) {
                    //当前选中了元素
                    jQuery(ctl).find("#dc_del").removeAttr("disabled");

                });
                // 监听没有选中任何元素的事件
                canvas.on('selection:cleared', function (event) {
                    jQuery(ctl).find("#dc_del").attr("disabled", "disabled");
                });
            },
            /**
             * 修改按钮是否可以用
             * @param canvas
             */
            changeBtnState() {
                // console.log("changeBtnState")
                if (this.state.pointer > 0) {
                    jQuery(ctl).find(".dc_undoBtn").removeAttr("disabled");
                } else {
                    jQuery(ctl).find(".dc_undoBtn").attr("disabled", "disabled");
                }
                if (this.state.pointer + 1 >= this.state.operateList.length) {
                    jQuery(ctl).find(".dc_redoBtn").attr("disabled", "disabled");
                } else {
                    jQuery(ctl).find(".dc_redoBtn").removeAttr("disabled");
                }
            },
            /**
             * 绑定键盘事件
             * @param canvas
             */
            bindKeyBoard(canvas) {
                // jQuery(document).on('keydown', (e) => {
                //   const key = e.originalEvent.keyCode;
                //   switch (key) {
                //     case KeyCode.W: // 上一步
                //       console.log('back');
                //       this.prevStepOperate();
                //       break;
                //     case KeyCode.E: // 下一步
                //       console.log('next');
                //       this.nextStepOperate();
                //       break;
                //   }
                // });
                canvas.on("object:modified", (e) => {
                    // 为了方便保存，调整图形直接触发保存
                    this.operateData();
                });
            },
            /**
             * 操作保存的数据
             */
            operateData() {
                const { canvas, operateList, pointer, deep } = this.state;
                let max = deep;
                let list = [...operateList];
                // 当前状态
                let currentPointer = pointer;
                const json = canvas.toJSON();
                // 更新指针位置
                currentPointer += 1;
                // 考虑到可能存在后续动作，插入队列操作
                list.splice(currentPointer, 0, json);
                if (max && max < list.length) {
                    // 深度存在，则判断当前队列长，超出则从头移出队列
                    list.shift();
                    currentPointer -= 1;
                }
                // 保存数据
                this.setState({
                    operateList: list,
                    pointer: currentPointer,
                });
                this.changeBtnState();
                // console.log('save');
            },
            /**
             * 合并更新
             * @param obj
             */
            setState(obj) {
                this.state = Object.assign(this.state, obj);
            },
            /**
             * 上一步
             */
            prevStepOperate() {
                const { canvas, operateList, pointer } = this.state;
                let list = [...operateList];
                let currentPointer = pointer;
                if (currentPointer > 0) {
                    // 加载前一步
                    currentPointer -= 1;
                    canvas.loadFromJSON(list[currentPointer]).renderAll();
                }
                this.setState({
                    operateList: [...list],
                    pointer: currentPointer,
                });
                this.changeBtnState();
            },
            /**
             * 下一步
             */
            nextStepOperate() {
                const { canvas, operateList, pointer } = this.state;
                let list = [...operateList];
                let currentPointer = pointer;
                // 指针移动
                currentPointer += 1;
                if (currentPointer >= list.length) {
                    this.changeBtnState();
                    return;
                }
                canvas.loadFromJSON(list[currentPointer]).renderAll();
                this.setState({
                    operateList: [...list],
                    pointer: currentPointer,
                });
                this.changeBtnState();
            },
        };
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = dc_dialogContainer.find("#dcPanelBody");
        var canvasElement = dcPanelBody.find("#dc_show_canvas")[0];
        var canvas = new fabric.Canvas(canvasElement, {
            containerClass: "canvasElementContainer",
        });
        var wrap = dcPanelBody.find("#dc_wrap_imgBox")[0];
        var wrapperEl = canvas.wrapperEl;
        var img = new Image();
        if (options && options.Src && options.Src.indexOf("http") == 0) {
            img.setAttribute("crossOrigin", "Anonymous");
        }
        img.src = "data:image/png;base64," + options.Src;
        //保留一遍原始图片的宽高
        var imgOptions = null;
        //用于记录旋转后的宽高
        var imgRotateOptions = null;

        img.onload = function () {
            //使用实际图片宽高

            imgOptions = {
                width: img.width,
                height: img.height,
            };
            // 设置画布的宽高
            canvas.setDimensions({
                width: img.width,
                height: img.height,
            });
            wrapperEl.setAttribute("native-width", img.width);
            wrapperEl.setAttribute("native-height", img.height);

            if (
                options &&
                options.Attributes &&
                options.Attributes.inneradditionshape
            ) {
                var loadobj = JSON.parse(options.Attributes.inneradditionshape);
                canvas.loadFromJSON(loadobj, function () {
                    canvas.renderAll();
                    ActionBackNext.constructor(canvas);
                });
            } else {
                // 将base64图片设置成背景
                canvas.setBackgroundImage(img.src, function () {
                    canvas.renderAll(); // 刷新画布
                    ActionBackNext.constructor(canvas);
                });
            }
            dcPanelBody.find(".dc_mouseMode").click(handleMouseModeChange);

            // 监听颜色输入框变化，更新选中对象的颜色
            dcPanelBody.find("#dc_fill_color").on("change", function () {
                var activeObject = canvas.getActiveObject();
                if (activeObject && (activeObject.type === 'rect' || activeObject.type === 'ellipse' || activeObject.type === 'triangle')) {
                    activeObject.set('fill', this.value);
                    canvas.renderAll();
                }
            });
            dcPanelBody.find("#dc_stroke_color").on("change", function () {
                var activeObject = canvas.getActiveObject();
                if (activeObject && (activeObject.type === 'rect' || activeObject.type === 'ellipse' || activeObject.type === 'triangle')) {
                    activeObject.set('stroke', this.value);
                    canvas.renderAll();
                }
            });

            // , {
            // scaleX: canvas.width / options.Width, scaleY: canvas.height / options.Height
            // }
        };
        /**
         * 放大缩小图片编辑
         * @param {*} zoom 放大缩小倍数
         * @returns 
         */
        var SetCanvasZoom = function (zoom) {
            if (typeof (zoom) != "number") {
                return;
            }
            // 控制缩放范围在 0.01~20 的区间内
            if (zoom > 20) zoom = 20;
            if (zoom < 0.01) zoom = 0.01;
            // 设置画布缩放比例
            canvas.setZoom(zoom);
            // 设置画布的宽高
            canvas.setDimensions({
                width: parseFloat(wrapperEl.getAttribute("native-width")) * zoom,
                height: parseFloat(wrapperEl.getAttribute("native-height")) * zoom
            });
        };
        var mouseMode = "Rect";
        /**
         * 监听模式改变事件
         * @param {*} event 事件Event
         * @returns {*} null
         */
        var handleMouseModeChange = function (event) {
            var clickedMode = this.value;
            // 检查当前点击的按钮是否已经选中（有active类）
            var isAlreadyActive = this.classList.contains("active");
            // 对于喷枪、画直线、画笔、箭头、图案、矩形、椭圆、三角形、文本这些工具，如果已经选中，则取消选中并停止绘制
            var toggleableModes = ['SprayBrushMode', 'Line', 'draw', 'Triangle', 'GLY', 'GY', 'SLY', 'SY', 'ZY', 'Rect', 'Ellipse', 'TriangleShape', 'IText', 'SpecialText'];
            if (isAlreadyActive && toggleableModes.indexOf(clickedMode) !== -1) {
                // 取消选中状态
                this.classList.remove("active");
                // 清除所有事件并停止绘制
                clearAllEvents();
                //剪切功能清除
                canvas.remove(selectionRect);
                selectionRect = null;
                mouseMode = null; // 重置模式
                return; // 直接返回，不执行后续绘制逻辑
            }
            if (!clickedMode) return;
            mouseMode = clickedMode;
            clearAllEvents();
            //剪切功能清除
            canvas.remove(selectionRect);
            selectionRect = null;
            // 选择模式
            switch (mouseMode) {
                case "Rect":
                    handleRectMode();
                    break;
                case "Ellipse":
                    handleEllipseMode();
                    break;
                case "TriangleShape":
                    handleTriangleShapeMode();
                    break;
                case "Line":
                    handleLineMode();
                    break;
                case "IText":
                    handleTextMode();
                    break;
                case "SpecialText":
                    var font = dcPanelBody.find("#dc_font_base_select").val();
                    handleTextMode(font);
                    break;
                case 'SprayBrushMode':
                    handleSprayBrushMode();
                    break;
                case 'draw':
                    handleDraw();
                    break;
                case 'Triangle':
                    handleTriangle();
                    break;
                case 'cut':
                    handleCut();
                    break;
                case 'rotateLeft':
                    handleRotate('left');
                    break;
                case 'rotateRight':
                    handleRotate('right');
                    break;
                case 'GLY':
                case 'GY':
                case 'SLY':
                case 'SY':
                case 'ZY':
                    handlePattern(mouseMode);
                    break;
                default:
                    break;
            }
            var mouseModeBtns = jQuery(ctl).find(".dc_mouseMode");
            for (var i = 0; i < mouseModeBtns.length; i++) {
                if (mouseModeBtns[i] == this) {
                    mouseModeBtns[i].classList.add("active");
                } else {
                    mouseModeBtns[i].classList.remove("active");
                }
            }
        };
        /**
         * 将所有事件清除掉
         * @returns {*} null
         */
        var clearAllEvents = function () {
            // 在添加事件之前先把该事件清除掉，以免重复添加
            canvas.off("mouse:down");
            canvas.off("mouse:move");
            canvas.off("mouse:up");
            canvas.isDrawingMode = false;//停止绘制
            var mouseModeBtns = jQuery(ctl).find(".dc_mouseMode.active");
            for (var i = 0; i < mouseModeBtns.length; i++) {
                mouseModeBtns[i].classList.remove("active");
            }
        };


        /**
         * 监听鼠标矩形事件
         * @returns {*} null
         */
        var handleRectMode = function () {
            clearAllEvents();
            var isMouseDown = false; //是否鼠标按下
            var zoom = canvas.getZoom();
            var rect;
            var rectObj = {};
            canvas.on("mouse:down", function (options) {
                if (options.target) {
                    return;
                }
                var left = options.pointer.x / zoom;
                var top = options.pointer.y / zoom;
                let fill = dcPanelBody.find("#dc_fill_color").val();
                let stroke = dcPanelBody.find("#dc_stroke_color").val();
                isMouseDown = true;
                rect = null; // 重置rect变量，避免影响之前的矩形
                rectObj = {
                    left: left,
                    top: top,
                    fill,
                    stroke,
                    opacity: 0.6,
                };
                rect = new fabric.Rect(rectObj);
                // 添加矩形到画布上
                canvas.add(rect);
            });
            canvas.on("mouse:move", function (options) {
                if (isMouseDown) {
                    var move_left = options.pointer.x / zoom - rect.left;
                    var move_top = options.pointer.y / zoom - rect.top;
                    rect.set({
                        width: move_left,
                        height: move_top,
                    });
                    canvas.renderAll();
                }
            });
            canvas.on("mouse:up", function (options) {
                isMouseDown = false;
                // console.log(rect, "======rect");
                if (rect) {
                    if (rect.get("width") == 0 || rect.get("height") == 0) {
                        canvas.remove(rect); // 移除这个矩形
                    } else {
                        ActionBackNext.operateData();

                        //[DUWRITER5_0-3980] 20241217 增加椭圆中带有文本的功能
                        var textId = 'text_rect_' + new Date().getTime();
                        rect.set({ 'targetTextId': textId });

                        var isHasText = dcPanelBody.find("#dc_default_text")[0].checked;
                        isHasText && addCenterText(rect, rectObj, canvas);
                    }
                    rect = null; // 绘制完成后重置rect变量，避免下次绘制时影响已完成的矩形
                }
                // 移除 clearAllEvents() 以支持连续绘制
            });
        };

        /**
        * 监听鼠标椭圆形事件
        * @returns {*} null
        */
        var handleEllipseMode = function () {
            clearAllEvents();
            var isMouseDown = false; //是否鼠标按下
            var zoom = canvas.getZoom();
            var Ellipse;
            var downPointer;
            var EllipseObj = null;
            canvas.on("mouse:down", function (options) {
                if (options.target) {
                    return;
                }
                downPointer = options.pointer;
                var left = options.pointer.x / zoom;
                var top = options.pointer.y / zoom;
                let fill = dcPanelBody.find("#dc_fill_color").val();
                let stroke = dcPanelBody.find("#dc_stroke_color").val();
                isMouseDown = true;
                Ellipse = null; // 重置Ellipse变量，避免影响之前的椭圆
                EllipseObj = {
                    left,
                    top,
                    fill,
                    stroke,
                    opacity: 0.6,
                };
                Ellipse = new fabric.Ellipse(EllipseObj);
                // 添加椭圆形到画布上
                canvas.add(Ellipse);
            });
            canvas.on("mouse:move", function (options) {
                if (isMouseDown) {
                    var move_left = options.pointer.x / zoom - downPointer.x / zoom;
                    var move_top = options.pointer.y / zoom - downPointer.y / zoom;
                    if (move_left != 0 || move_top != 0) {
                        EllipseObj = {
                            left: Math.min(options.pointer.x / zoom, downPointer.x / zoom),
                            top: Math.min(options.pointer.y / zoom, downPointer.y / zoom),
                            rx: Math.abs(move_left) / 2,
                            ry: Math.abs(move_top) / 2,
                        };
                        Ellipse.set(EllipseObj);
                        canvas.renderAll();
                    }
                }
            });
            canvas.on("mouse:up", function (options) {
                isMouseDown = false;

                isHasText = dcPanelBody.find("#dc_default_text")[0].checked;
                // 修复图片编辑弹框报错问题【DUWRITER5_0-2993】
                if (Ellipse) {
                    if ((Ellipse.get("rx") == 0 || Ellipse.get("ry") == 0)) {
                        canvas.remove(Ellipse); // 移除这个椭圆形
                    } else {
                        ActionBackNext.operateData();
                        //[DUWRITER5_0-3980] 20241217 增加椭圆中带有文本的功能
                        var textId = 'text_Ellipse_' + new Date().getTime();
                        Ellipse.set({ 'targetTextId': textId });

                        var isHasText = dcPanelBody.find("#dc_default_text")[0].checked;
                        isHasText && addCenterText(Ellipse, EllipseObj, canvas);
                    }
                    Ellipse = null; // 绘制完成后重置Ellipse变量，避免下次绘制时影响已完成的椭圆
                }
                // 移除 clearAllEvents() 以支持连续绘制
            });
        };

        /**
         * 监听鼠标三角形事件
         * @returns {*} null
         */
        var handleTriangleShapeMode = function () {
            clearAllEvents();
            var isMouseDown = false; //是否鼠标按下
            var zoom = canvas.getZoom();
            var Triangle;
            var downPointer;
            var TriangleObj = null;
            canvas.on("mouse:down", function (options) {
                if (options.target) {
                    return;
                }
                downPointer = options.pointer;
                isMouseDown = true;
                Triangle = null; // 重置Triangle变量，避免影响之前的三角形
                TriangleObj = null;
            });
            canvas.on("mouse:move", function (options) {
                if (isMouseDown) {
                    var move_left = options.pointer.x / zoom - downPointer.x / zoom;
                    var move_top = options.pointer.y / zoom - downPointer.y / zoom;
                    if (move_left != 0 || move_top != 0) {
                        // 只有在鼠标移动时才创建三角形
                        if (!Triangle) {
                            // 默认透明填充，黑色边框，和矩形椭圆一样使用颜色选择器的值
                            let stroke = dcPanelBody.find("#dc_stroke_color").val();
                            var left = Math.min(options.pointer.x / zoom, downPointer.x / zoom);
                            var top = Math.min(options.pointer.y / zoom, downPointer.y / zoom);
                            TriangleObj = {
                                left,
                                top,
                                strokeWidth: 2,//线宽
                                fill: 'transparent', // 使用颜色选择器的值，如果没有则透明
                                stroke: '#000000', // 使用颜色选择器的值，如果没有则黑色
                                opacity: 0.6, // 和矩形椭圆一样保持透明度
                            };
                            Triangle = new fabric.Triangle(TriangleObj);
                            // 添加三角形到画布上
                            canvas.add(Triangle);
                        }
                        // 更新三角形的大小
                        TriangleObj = {
                            left: Math.min(options.pointer.x / zoom, downPointer.x / zoom),
                            top: Math.min(options.pointer.y / zoom, downPointer.y / zoom),
                            width: Math.abs(move_left),
                            height: Math.abs(move_top),
                        };
                        Triangle.set(TriangleObj);
                        canvas.renderAll();
                    }
                }
            });
            canvas.on("mouse:up", function (options) {
                isMouseDown = false;

                isHasText = dcPanelBody.find("#dc_default_text")[0].checked;
                if (Triangle) {
                    if ((Triangle.get("width") == 0 || Triangle.get("height") == 0)) {
                        canvas.remove(Triangle); // 移除这个三角形
                    } else {
                        // 和矩形椭圆一样，保持透明度不变
                        ActionBackNext.operateData();
                        //[DUWRITER5_0-3980] 20241217 增加三角形中带有文本的功能
                        var textId = 'text_Triangle_' + new Date().getTime();
                        Triangle.set({ 'targetTextId': textId });

                        var isHasText = dcPanelBody.find("#dc_default_text")[0].checked;
                        isHasText && addCenterText(Triangle, TriangleObj, canvas);
                    }
                    Triangle = null; // 绘制完成后重置Triangle变量，避免下次绘制时影响已完成的三角形
                }
                // 移除 clearAllEvents() 以支持连续绘制
            });
        };

        /**
         * 增加一个居中文本给椭圆、矩形  
         *  //[DUWRITER5_0-3980] 20241217 增加椭圆中带有文本的功能
         * @returns {*} null
         */
        var addCenterText = function (targetEle, targetEleObj, canvas) {
            // 在添加事件之前先把该事件清除掉，以免重复添加
            clearAllEvents();

            //获取这个目标图形的坐标
            var Left = targetEleObj.left;
            var Top = targetEleObj.top;
            // 给椭圆添加文本,并设置文本对于椭圆的位置，要求文本在椭圆的中心位置，水平和垂直都居中，如果超出椭圆可以在适当位置换行
            var text = new fabric.IText("默认文字", {
                left: Left,
                top: Top,
                fontFamily: dcPanelBody.find("#dc_fontFamily").val(),
                fontSize: dcPanelBody.find("#dc_fontSize").val(),
                fill: dcPanelBody.find("#dc_fontColor").val(),
                textId: targetEle.targetTextId,
            });
            canvas.add(text);
            // text.set({
            //     textId: targetEle.targetTextId,
            // });
            canvas.renderAll();
            ActionBackNext.operateData();
            // 将文本设置为活动对象
            canvas.setActiveObject(text);
            text.enterEditing();  // 进入编辑模式
            if (text) {
                // 监听修改文本完成后再次修正位置为居中;
                text.on("editing:exited", function () {
                    //重新获取这个目标图形的坐标
                    Left = targetEle.left;
                    Top = targetEle.top;
                    var targetEleWidth = targetEle.width;
                    var targetEleHeight = targetEle.height;
                    var textWidth = text.width;
                    var textHeight = text.height;
                    var textLeft = (targetEleWidth - textWidth) / 2;
                    var textTop = (targetEleHeight - textHeight) / 2;
                    text.set({
                        top: Top + textTop,
                        left: Left + textLeft,
                    });
                    canvas.renderAll();
                    canvas.setActiveObject(text);
                });

                // //将targetEle和text互相关联，互相跟随移动
                text.on("moving", function () {
                    var notSelectedObjects = [];
                    canvas.getObjects().forEach(function (obj) {
                        if (obj && !obj.selected) {//判断是否为选中状态
                            notSelectedObjects.push(obj);
                        }
                    });

                    var targetObj = notSelectedObjects.find(function (obj) {
                        return obj.targetTextId == text.textId;
                    });

                    if (targetObj) {
                        //跟随文本的中心点移动椭圆
                        var left = text.left;
                        var top = text.top;
                        var textWidth = text.width;
                        var textHeight = text.height;
                        var targetObjWidth = targetObj.width;
                        var targetObjHeigth = targetObj.height;

                        targetObj.set({
                            left: left + ((textWidth - targetObjWidth) / 2),
                            top: top + ((textHeight - targetObjHeigth) / 2),
                        });
                        //文本元素置于最上层
                        canvas.bringToFront(text);
                    }
                });


                //给椭圆添加事件监听，在移动椭圆形的时候，跟随移动文本
                targetEle.on("moving", function (e) {
                    //获取所有选中的元素
                    var notSelectedObjects = [];
                    canvas.getObjects().forEach(function (obj) {
                        if (obj && !obj.selected) {//判断是否为选中状态
                            notSelectedObjects.push(obj);
                        }
                    });
                    //获取没有被移动的对应文本，使文本跟随椭圆形移动（防止多选元素移动时，重复操作的移动）
                    var targetText = notSelectedObjects.find(function (obj) {
                        return obj.textId == targetEle.targetTextId;
                    });
                    if (targetText) {
                        var textWidth = text.width;
                        var textHeight = text.height;
                        var textLeft = (targetEle.width - textWidth) / 2;
                        var textTop = (targetEle.height - textHeight) / 2;
                        targetText.set({
                            top: targetEle.top + textTop,
                            left: targetEle.left + textLeft,
                        });
                        //文本元素置于最上层
                        canvas.bringToFront(text);
                    }
                });
            }
        };
        /**
         * 监听鼠标线段事件
         * @returns {*} null
         */
        var handleLineMode = function () {
            clearAllEvents();
            var isMouseDown = false; //是否鼠标按下
            var zoom = canvas.getZoom();
            var Line;
            var downPointer;
            canvas.on("mouse:down", function (options) {
                if (options.target) {
                    return;
                }
                downPointer = options.pointer;
                // var left = options.pointer.x;
                // var top = options.pointer.y;
                isMouseDown = true;
                Line = null; // 重置Line变量，避免删除之前已完成的线段
                // Line = new fabric.Line([left, top],{
                //   stroke: 'black', // 笔触颜色
                // });
                // 添加椭圆形到画布上
                // canvas.add(Line);
            });
            canvas.on("mouse:move", function (options) {
                if (isMouseDown) {
                    var move_left = options.pointer.x / zoom - downPointer.x / zoom;
                    var move_top = options.pointer.y / zoom - downPointer.y / zoom;
                    // 只有当Line存在时才移除，避免删除之前已完成的线段
                    if (Line) {
                        canvas.remove(Line);
                    }
                    if (move_left != 0 || move_top != 0) {
                        var obj = {
                            x2: options.pointer.x / zoom,
                            y2: options.pointer.y / zoom
                        };
                        Line = new fabric.Line([downPointer.x / zoom, downPointer.y / zoom, obj.x2, obj.y2], {
                            stroke: 'black', // 笔触颜色
                        });
                        // 添加椭圆形到画布上
                        canvas.add(Line);
                        // Line.set(obj);
                        canvas.renderAll();
                    }
                }
            });
            canvas.on("mouse:up", function (options) {
                isMouseDown = false;
                // clearAllEvents();
                if (Line) {
                    ActionBackNext.operateData();
                    Line = null; // 绘制完成后重置Line变量，避免下次绘制时删除已完成的线段
                }
            });
        };

        /**
         * 监听鼠标添加文字事件
         * @returns {*} null
         */
        var handleTextMode = function (font) {
            // 在添加事件之前先把该事件清除掉，以免重复添加
            clearAllEvents();
            // canvas.on('mouse:down', function (options) {
            // });
            // canvas.on('mouse:move', function (options) {
            // });
            canvas.on("mouse:up", function (options) {
                if (options.target) {
                    // 如果点击到已有对象，不清除事件，保持可以继续绘制
                    return;
                }
                var dc_active = canvas.getActiveObject();
                if (dc_active) {
                    // 如果有激活对象，不清除事件，保持可以继续绘制
                    return;
                }
                var zoom = canvas.getZoom();
                var left = options.pointer.x / zoom;
                var top = options.pointer.y / zoom;
                var IText = new fabric.IText(font ? font : "默认文字", {
                    left: left,
                    top: top,
                    fontFamily: dcPanelBody.find("#dc_fontFamily").val(),
                    fontSize: dcPanelBody.find("#dc_fontSize").val(),
                    fill: dcPanelBody.find("#dc_fontColor").val(),
                });
                canvas.add(IText).setActiveObject(IText);
                font ? null : IText.exitEditing();
                // 移除 clearAllEvents() 以支持连续绘制
                ActionBackNext.operateData();
            });
        };

        /**
        * 监听鼠标喷枪事件
        * @returns {*} null
        */
        var handleSprayBrushMode = function () {
            clearAllEvents();
            var isSpraying = false;
            var sprayDensity = 40; // 喷雾密度，可以根据需要进行调整

            canvas.on("mouse:down", function (options) {
                isSpraying = true;
                spray(options.pointer);
            });

            canvas.on("mouse:move", function (options) {
                if (isSpraying) {
                    spray(options.pointer);
                }
            });

            canvas.on("mouse:up", function (options) {
                isSpraying = false;
                // clearAllEvents();
                ActionBackNext.operateData();
            });
            //喷雾绘制
            function spray(pointer) {
                var zoom = canvas.getZoom();
                var x = pointer.x / zoom;
                var y = pointer.y / zoom;
                for (var i = 0; i < sprayDensity; i++) {
                    var offsetX = fabric.util.getRandomInt(-40, 40);
                    var offsetY = fabric.util.getRandomInt(-40, 40);
                    var sprayPoint = new fabric.Circle({
                        radius: 2,
                        fill: "black",
                        selectable: true
                    });
                    sprayPoint.left = x + offsetX;
                    sprayPoint.top = y + offsetY;
                    canvas.add(sprayPoint);
                    canvas.discardActiveObject().renderAll();
                }
            }
        };

        /**
        * 绘制
        * @returns {*} null
        */
        function handleDraw() {
            clearAllEvents();
            // 设置绘制时的线颜色
            var color = ctl.ownerDocument.getElementById('dc_stroke_color').value;
            canvas.freeDrawingBrush.color = color;

            // 设置绘制时的线段粗细
            canvas.freeDrawingBrush.width = 3;

            canvas.isDrawingMode = true;
            canvas.on("mouse:move", function (options) {
                canvas.discardActiveObject().renderAll();
            });
            canvas.on("mouse:up", function (options) {
                ActionBackNext.operateData();
                // 移除 canvas.isDrawingMode = false; 以保持绘制模式开启，支持连续绘制
                // clearAllEvents();
                var objects = canvas.getObjects();
                if (objects.length > 0) {
                    var lastObject = objects[objects.length - 1];
                    canvas.setActiveObject(lastObject);
                }
            });
        }

        /**
        * 箭头
        * @returns {*} null
        */
        function handleTriangle() {
            clearAllEvents(); // 清除事件监听
            let fill = dcPanelBody.find("#dc_fill_color").val();
            var isMouseDown = false;
            var arrow;
            var startPoint;
            canvas.on("mouse:down", function (options) {
                if (options.target) {
                    return;
                }
                isMouseDown = true;
                arrow = null; // 重置arrow变量，避免删除之前已完成的箭头
                startPoint = canvas.getPointer(options.e);
            });
            canvas.on("mouse:move", function (options) {
                if (isMouseDown) {
                    var pointer = canvas.getPointer(options.e);
                    var angle = Math.atan2(pointer.y - startPoint.y, pointer.x - startPoint.x) + Math.PI / 2; // 加上90度
                    var arrowBaseX = pointer.x - 10 * Math.cos(angle); // 调整箭头位置使其居中
                    var arrowBaseY = pointer.y - 10 * Math.sin(angle); // 调整箭头位置使其居中
                    // 移除旧箭头
                    if (arrow) {
                        canvas.remove(arrow);
                    }
                    // 创建线段
                    var line = new fabric.Line([startPoint.x, startPoint.y, pointer.x, pointer.y], {
                        stroke: fill,
                        strokeWidth: 2,
                    });
                    // 创建三角形箭头
                    var triangle = new fabric.Triangle({
                        left: arrowBaseX,
                        top: arrowBaseY,
                        width: 20,
                        height: 30,
                        fill: fill,
                        angle: angle * 180 / Math.PI,
                    });
                    // 将线段和三角形组合为一个元素
                    arrow = new fabric.Group([line, triangle], {
                        selectable: true,
                    });
                    canvas.add(arrow);
                    canvas.renderAll();
                }
            });
            canvas.on("mouse:up", function () {
                var objects = canvas.getObjects();
                if (objects.length > 0) {
                    var lastObject = objects[objects.length - 1];
                    canvas.setActiveObject(lastObject);
                }
                ActionBackNext.operateData();
                isMouseDown = false;
                arrow = null; // 绘制完成后重置arrow变量，避免下次绘制时删除已完成的箭头
                // clearAllEvents(); // 清除事件监听
            });
        }

        /**
         * 剪切
         * @returns {*} null
         */
        var selectionRect = null;
        function handleCut() {
            clearAllEvents(); // 清除事件监听
            var isDrawing = false;
            var startX, startY, endX, endY;

            canvas.on({
                'mouse:down': function (e) {
                    isDrawing = true;
                    startX = e.pointer.x;
                    startY = e.pointer.y;
                    selectionRect = new fabric.Rect({
                        left: startX,
                        top: startY,
                        originX: 'left',
                        originY: 'top',
                        fill: '#00000000',
                        // stroke: '#409eff',
                        strokeWidth: 1,
                        width: 1,
                        height: 1,
                        selectable: true,
                        evented: true,// 确保矩形可以调整大小
                        hasRotatingPoint: true// 确保矩形可以旋转
                    });
                    canvas.add(selectionRect);
                    selectionRect.on('scaling', function (options) {
                        // 在缩放事件中更新宽度和高度
                        var scaleX = selectionRect.scaleX;
                        var scaleY = selectionRect.scaleY;
                        var newWidth = selectionRect.width * scaleX;
                        var newHeight = selectionRect.height * scaleY;
                        selectionRect.set({
                            width: newWidth,
                            height: newHeight,
                            scaleX: 1,
                            scaleY: 1
                        });
                        canvas.renderAll();
                    });

                    selectionRect.on('rotating', function (options) {
                        // 在旋转事件中更新角度
                        var angle = selectionRect.angle;
                        selectionRect.set({
                            angle: angle
                        });
                        canvas.renderAll();
                    });

                    selectionRect.on('moving', function (options) {
                        // 在移动事件中更新左上角位置
                        var left = selectionRect.left;
                        var top = selectionRect.top;
                        selectionRect.set({
                            left: left,
                            top: top
                        });
                        canvas.renderAll();
                    });

                },
                'mouse:move': function (e) {
                    if (!isDrawing) return;
                    const endX = e.pointer.x;
                    const endY = e.pointer.y;
                    selectionRect.set({
                        width: Math.abs(endX - startX),
                        height: Math.abs(endY - startY),
                        left: Math.min(startX, endX),
                        top: Math.min(startY, endY),
                    });
                    canvas.renderAll();
                },
                'mouse:up': function (e) {
                    isDrawing = false;
                    clearAllEvents(); // 清除事件监听
                }
            });

        }
        //剪切的确认事件
        dcPanelBody.find("#dc_cut_confirm").click(function () {
            //将selectionRect区域中的内容截取为图片base64
            if (!selectionRect) { return; }
            var imgData = canvas.toDataURL({
                format: 'png',
                left: selectionRect.left - 1,
                top: selectionRect.top - 1,
                width: selectionRect.width + 1,
                height: selectionRect.height + 1,
            });

            // 重置画布背景图
            var img = new Image();
            img.src = imgData;
            img.onload = function () {

                // console.log(imgOptions, img.width, img.height);
                // imgRotateOptions = {
                //     width: img.width,
                //     height: img.height,
                // };
                //修改canvas的宽高
                canvas.setDimensions({
                    width: img.width,
                    height: img.height,
                });
                wrapperEl.setAttribute("native-width", img.width);
                wrapperEl.setAttribute("native-height", img.height);
                // //用于记录旋转后的宽高
                imgRotateOptions = {
                    width: img.width,
                    height: img.height,
                };

                // 将base64图片设置成背景
                canvas.setBackgroundImage(img.src, function () {
                    canvas.renderAll(); // 刷新画布
                    canvas.remove(selectionRect);
                    selectionRect = null;
                    ActionBackNext.constructor(canvas);

                });
            };
        });
        //剪切取消事件
        dcPanelBody.find("#dc_cut_cencal").click(function () {
            canvas.remove(selectionRect);
            selectionRect = null;
        });



        //旋转
        function handleRotate(type) {
            clearAllEvents(); // 清除事件监听

            // 先获取当前的背景图
            var backgroundImage = canvas.backgroundImage;
            if (backgroundImage) {
                // 获取背景图的 base64 编码字符串
                var base64Image = backgroundImage.toDataURL({
                    format: 'png', // 你可以根据需要选择格式，例如 'jpeg'
                    quality: 1 // 图像质量，1 是最高质量
                });




                if (type === 'left' || type === 'right') {
                    // 重置画布背景图
                    var img = new Image();
                    img.src = base64Image;
                    img.onload = function () {
                        //旋转前先设置画布为旋转后的大小,防止旋转后canvas放不下图片
                        canvas.setDimensions({
                            width: img.height,
                            height: img.width,
                        });
                        wrapperEl.setAttribute("native-width", img.height);
                        wrapperEl.setAttribute("native-height", img.width);
                        // //用于记录旋转后的宽高
                        imgRotateOptions = {
                            width: img.height,
                            height: img.width,
                        };
                        //获取旋转后的图片
                        rotateBase64Image(base64Image, type === 'left' ? -90 : 90) // 旋转90度
                            .then(newBase64String => {
                                // 将旋转后的图片设置成canvas的背景图
                                canvas.setBackgroundImage(newBase64String, canvas.renderAll.bind(canvas));
                            })
                            .catch(err => {
                                console.error('图片旋转失败:', err);
                            });
                    };
                }
            } else {
                console.log("没有背景图");
            }

        };
        //旋转图片
        function rotateBase64Image(base64String, angle) {
            return new Promise((resolve, reject) => {
                // 创建一个新的Image对象
                const img = new Image();

                // 设置图片加载完成后的处理函数
                img.onload = () => {
                    // 创建一个canvas元素
                    const canvas = document.createElement('canvas');
                    const ctx = canvas.getContext('2d');

                    // 计算旋转后canvas的尺寸
                    canvas.width = img.height;
                    canvas.height = img.width;

                    // 保存当前canvas的上下文状态
                    ctx.save();

                    // 将canvas的原点移动到中心
                    ctx.translate(canvas.width / 2, canvas.height / 2);

                    // 旋转canvas
                    ctx.rotate(angle * Math.PI / 180);

                    // 绘制图片
                    ctx.drawImage(img, -img.width / 2, -img.height / 2);

                    // 恢复canvas的上下文状态
                    ctx.restore();

                    // 将canvas内容转换为新的Base64字符串
                    const newBase64String = canvas.toDataURL(img.src.split(';')[0].split(':')[1]);
                    resolve(newBase64String);
                };

                // 设置图片加载错误的处理函数
                img.onerror = (err) => {
                    reject(err);
                };

                // 设置图片的src属性为Base64字符串
                img.src = base64String;
            });
        }

        //插入图案
        function handlePattern(type) {
            // 在添加事件之前先把该事件清除掉，以免重复添加
            clearAllEvents();
            canvas.on("mouse:up", function (options) {
                if (options.target) {
                    // 如果点击到已有对象，不清除事件，保持可以继续绘制
                    return;
                }
                var dc_active = canvas.getActiveObject();
                if (dc_active) {
                    // 如果有激活对象，不清除事件，保持可以继续绘制
                    return;
                }
                var zoom = canvas.getZoom();
                var left = options.pointer.x / zoom;
                var top = options.pointer.y / zoom;
                var imgurl = IMGEDITSVGOBJECT[type];

                // 创建一个新的 Image 对象
                fabric.Image.fromURL(imgurl, function (oImg) {
                    oImg.set({
                        left: left,
                        top: top,
                        // 保留原始宽高
                        width: oImg.width,
                        height: oImg.height
                    });
                    canvas.add(oImg).setActiveObject(oImg);
                });
                // 移除 clearAllEvents() 以支持连续绘制
                ActionBackNext.operateData();
            });
        }




        // 切换tab页
        dcPanelBody.find(".dc_list li").click(function () {
            // 修改样式
            jQuery(this).addClass("dc_imgEdit_active").siblings("li").removeClass("dc_imgEdit_active");
            var name = jQuery(this).attr("name");
            dcPanelBody.find(".dc_list_box > div").hide();
            dcPanelBody.find(".dc_list_box > div." + name).show();
        });
        // 模拟点击第一个tab页
        dcPanelBody.find(".dc_list li:first").click();
        /**
        * 改变颜色
        * @param {*} color_str 颜色字符串
        * @returns {*} null
        */
        var changeColor = function (color_str, isBackColor = "fill") {
            var active = canvas.getActiveObject();
            if (active) {
                // console.log(active.type);
                var name = isBackColor;
                // 设置填充颜色或者边框颜色
                // 矩形 椭圆形 线段 圆形 折线
                if (active.type == "rect" || active.type == "ellipse" || active.type == "line" || active.type == "circle" || active.type == "path") {
                    var obj = {};
                    obj[name] = color_str;
                    active.set(obj);
                    canvas.renderAll();
                    ActionBackNext.operateData();
                } else if (active.type == "activeSelection" || active.type == "group") {
                    // 选中多个内容 || 组，目前只有箭头
                    active.forEachObject(function (obj) {
                        var setobj = {};
                        setobj[name] = color_str;
                        obj.set(setobj);
                    });
                    canvas.renderAll();
                    ActionBackNext.operateData();
                }
            }
        };
        // 更新填充颜色
        dcPanelBody.find("#dc_fill_color").change(function () {
            // console.log("fill color change");
            var dc_active = canvas.getActiveObject();
            if (dc_active) {
                changeColor(this.value, "fill");
            }
            let svgPath = dcPanelBody.find(".dc_imgEdit_fill_label svg path");
            svgPath && svgPath.css("fill", this.value);
        });

        // 更新边框颜色
        dcPanelBody.find("#dc_stroke_color").change(function () {
            var dc_active = canvas.getActiveObject();
            if (dc_active) {
                changeColor(this.value, "stroke");
            }
            let svgPath = dcPanelBody.find(".dc_imgEdit_stroke_label svg path");
            svgPath && svgPath.css("fill", this.value);
        });

        // 更新字体颜色
        dcPanelBody.find("#dc_fontColor").change(function () {
            var dc_active = canvas.getActiveObject();
            if (dc_active) {
                changeColor(this.value, "fill");
            }
            let svgPath = dcPanelBody.find(".dc_imgEdit_fontcolor_label svg path");
            svgPath && svgPath.css("fill", this.value);
        });


        //更新矢量图
        dcPanelBody.find("#dc_back_img_color").change(function () {
            var fillImgType = this.value;
            let activeElement = canvas.getActiveObject();
            if (activeElement) {
                //当前选中了元素
                if (activeElement.type == "activeSelection" || activeElement.type == "group") {
                    //选中了一组
                    activeElement.getObjects().forEach(function (activeElementItem) {
                        //更新图片
                        refreshEditElementFill(fillImgType, activeElementItem);
                    });
                } else {
                    //更新图片
                    refreshEditElementFill(fillImgType, activeElement);
                }
            }
        });

        //更新背景图
        function refreshEditElementFill(fillImgType, activeElement) {
            if (activeElement.type == "rect" || activeElement.type == "ellipse") {
                if (fillImgType === '14') {
                    //深三度，黑色填充
                    activeElement.set({
                        opacity: 1,
                        fill: "#000000",
                        // _cacheProperties: {
                        //     _fillImgType: "14",
                        // }
                    });
                    activeElement.set('_fillImgType', "14");

                    canvas.renderAll();

                } else if (fillImgType === '0') {
                    //空白，恢复默认
                    activeElement.set({
                        fill: '#000000',
                        opacity: 0.6,
                        // _cacheProperties: {
                        //     _fillImgType: "0",
                        // }
                    });
                    activeElement.set('_fillImgType', "0");

                    canvas.renderAll();

                } else {
                    //backgrounImg
                    var fillImgSrc = getImgEditElementFill(fillImgType, activeElement);
                    if (fillImgSrc) {
                        var img = new Image();
                        img.src = fillImgSrc;
                        // 等待图像加载完成
                        img.onload = function () {
                            // 计算平均缩放比例
                            var pattern = new fabric.Pattern({
                                source: img,
                            });
                            activeElement.set({
                                fill: pattern,
                                opacity: 0.6,
                                // _cacheProperties: {
                                //     _fillImgType: fillImgType,
                                // }
                                // _fillImgType: fillImgType,
                            });

                            activeElement.set('_fillImgType', fillImgType);

                            canvas.renderAll();

                            // console.log(activeElement, '==============activeElement');

                        };
                    }
                }
            }


        }
        //获取背景图片
        function getImgEditElementFill(typeNumber, canvasElement) {
            var canvasFill = ctl.ownerDocument.createElement("canvas");

            // 默认使用元素的宽高，getBoundingRect防止元素被拉伸后导致图片变形
            var canvasElementWidth = (canvasElement.getBoundingRect && canvasElement.getBoundingRect().width) || canvasElement.width;
            var canvasElementHeight = (canvasElement.getBoundingRect && canvasElement.getBoundingRect().height) || canvasElement.height;

            // var canvasElementWidth = canvasElement.width;
            // var canvasElementHeight = canvasElement.height;

            canvasFill.width = canvasElementWidth;
            canvasFill.height = canvasElementHeight;

            var ctxFill = canvasFill.getContext('2d');
            ctxFill.clearRect(0, 0, canvasFill.width, canvasFill.height);


            var imgSrc = null;
            var rectWidth = 5; // 矩形宽度
            var rectHeight = 3; // 矩形高度
            var minSpacing = 2; // 最小水平间距
            var maxSpacing = 5; // 最大水平间距
            var verticalSpacing = 3; // 垂直间距
            var x = 0;
            var y = 0;
            switch (typeNumber) {
                case "1": //触觉减退

                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.fillStyle = 'black';
                        ctxFill.fillRect(x, y, rectWidth, rectHeight);
                        x += rectWidth + Math.floor(Math.random() * (maxSpacing - minSpacing + 1) + minSpacing);
                        if (x + rectWidth > canvasElementWidth) {
                            x = Math.floor(Math.random() * (maxSpacing - minSpacing + 1) + minSpacing);
                            y += rectHeight + verticalSpacing;
                        }
                    }


                    break;
                case "2": //触觉消失
                    rectWidth = 4; // 菱形宽度
                    rectHeight = 4; // 菱形高度
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvas.height) {
                        ctxFill.strokeStyle = 'black';
                        ctxFill.beginPath();
                        ctxFill.moveTo(x + rectWidth / 2, y);
                        ctxFill.lineTo(x + rectWidth, y + rectHeight / 2);
                        ctxFill.lineTo(x + rectWidth / 2, y + rectHeight);
                        ctxFill.lineTo(x, y + rectHeight / 2);
                        ctxFill.closePath();
                        ctxFill.stroke();

                        x += rectWidth + 6;//6水平间距
                        if (x + rectWidth > canvasElementWidth) {
                            x = 0;
                            y += rectHeight + 4;//4垂直间距
                        }
                    }
                    break;

                case "3": //触觉过敏或异常
                    rectWidth = 4; // 菱形宽度
                    rectHeight = 4; // 菱形高度
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.strokeStyle = 'black';
                        ctxFill.beginPath();
                        ctxFill.moveTo(x, y);
                        ctxFill.lineTo(x + 4, y + 4);
                        ctxFill.moveTo(x + 4, y);
                        ctxFill.lineTo(x, y + 4);
                        ctxFill.closePath();
                        ctxFill.stroke();
                        x += 10;
                        if (x + rectWidth > canvasElementWidth) {
                            x = 0;
                            y += 10;
                        }
                    }
                    break;

                case "4": //痛觉减退
                    rectWidth = 6; // 菱形宽度
                    rectHeight = 5; // 菱形高度
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.strokeStyle = 'black';
                        ctxFill.beginPath();
                        ctxFill.moveTo(x + 6, y);
                        ctxFill.lineTo(x, y + 5);
                        ctxFill.closePath();
                        ctxFill.stroke();
                        x += 8;
                        if (x + rectWidth > canvasElementWidth) {
                            x = 0;
                            y += 8;
                        }
                    }
                    break;

                case "5": //痛觉消失
                    rectWidth = 8; // 菱形宽度
                    rectHeight = 10; // 菱形高度
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvas.height) {
                        ctxFill.strokeStyle = 'black';
                        //修改线宽
                        ctxFill.lineWidth = 2;
                        ctxFill.beginPath();
                        ctxFill.moveTo(x + rectWidth / 2, y);
                        ctxFill.lineTo(x + rectWidth, y + rectHeight / 2);
                        ctxFill.lineTo(x + rectWidth / 2, y + rectHeight);
                        ctxFill.lineTo(x, y + rectHeight / 2);
                        ctxFill.closePath();
                        ctxFill.stroke();

                        x += rectWidth + 2;//6水平间距
                        if (x + rectWidth > canvasElementWidth) {
                            x = 0;
                            y += rectHeight + 3;//4垂直间距
                        }
                    }
                    break;
                case "6": //痛觉过敏或异常
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.fillStyle = 'black';
                        ctxFill.lineWidth = 4;
                        ctxFill.beginPath();
                        ctxFill.moveTo(x, y);
                        ctxFill.lineTo(x + canvasElementWidth, y);
                        ctxFill.closePath();
                        ctxFill.stroke();
                        x = 0;
                        y += 4 + 4;
                    }
                    break;
                case "7": //震动觉减退或异常
                    rectWidth = 4; // V型宽度
                    rectHeight = 6; // V型高度
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.strokeStyle = 'black';
                        ctxFill.beginPath();

                        // // 画倒V型
                        // ctxFill.moveTo(x + rectWidth / 2, y);
                        // ctxFill.lineTo(x + rectWidth, y + rectHeight);

                        // ctxFill.moveTo(x, y + rectHeight);
                        // ctxFill.lineTo(x + rectWidth / 2, y);

                        // 画正向V型
                        ctxFill.moveTo(x, y);
                        ctxFill.lineTo(x + rectWidth / 2, y + rectHeight);

                        ctxFill.moveTo(x + rectWidth / 2, y + rectHeight);
                        ctxFill.lineTo(x + rectWidth, y);

                        ctxFill.stroke();

                        x += 8;
                        if (x + rectWidth > canvasElementWidth) {
                            x = 0;
                            y += 8;
                        }
                    }

                    break;

                case "8": //位置觉减退或异常
                    rectWidth = 6; // 菱形宽度
                    rectHeight = 6; // 菱形高度
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.strokeStyle = 'black';
                        ctxFill.beginPath();

                        ctxFill.moveTo(x, y + rectHeight);
                        ctxFill.lineTo(x + rectWidth / 2, y);
                        ctxFill.lineTo(x + rectWidth, y + rectHeight);
                        ctxFill.closePath();
                        ctxFill.stroke();

                        x += 9;
                        if (x + rectWidth > canvasElementWidth) {
                            x = 0;
                            y += 9;
                        }
                    }
                    break;


                case "9": //浅感觉全部消失
                    while (x + rectWidth <= canvasElementWidth) {
                        ctxFill.fillStyle = 'black';
                        ctxFill.lineWidth = 4;
                        ctxFill.beginPath();
                        ctxFill.moveTo(x, y);
                        ctxFill.lineTo(x, y + canvasElementHeight);
                        ctxFill.closePath();
                        ctxFill.stroke();
                        x += 10;
                        y += 0;
                    }

                    // while (y + rectHeight <= canvasElementHeight) {
                    //     ctxFill.fillStyle = 'black';
                    //     ctxFill.lineWidth = 2;
                    //     ctxFill.beginPath();
                    //     ctxFill.moveTo(x, y);
                    //     ctxFill.lineTo(x + canvasElementWidth, y);

                    //     ctxFill.moveTo(x + 4, y);
                    //     ctxFill.lineTo(x + 4 + canvasElementWidth, y);

                    //     ctxFill.closePath();
                    //     ctxFill.stroke();
                    //     x = 0;
                    //     y += 4 + 6;
                    // }


                    break;
                case "10": //深浅感觉全部消失
                    // 横线
                    while (x + rectWidth <= canvasElementWidth) {
                        ctxFill.fillStyle = 'black';
                        ctxFill.lineWidth = 1;
                        ctxFill.beginPath();
                        ctxFill.moveTo(x, y);
                        ctxFill.lineTo(x, y + canvasElementHeight);
                        ctxFill.closePath();
                        ctxFill.stroke();
                        x += 10;
                        y += 0;
                    }
                    // 竖线
                    x = 0;
                    y = 0;
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.fillStyle = 'black';
                        ctxFill.lineWidth = 1;
                        ctxFill.beginPath();
                        ctxFill.moveTo(x, y);
                        ctxFill.lineTo(x + canvasElementWidth, y);
                        ctxFill.closePath();
                        ctxFill.stroke();
                        x = 0;
                        y += 9;
                    }


                    break;
                case "11": //一度
                    rectWidth = 2; // 矩形宽度
                    rectHeight = 4; // 矩形高度
                    minSpacing = 5; // 最小水平间距
                    maxSpacing = 10; // 最大水平间距
                    verticalSpacing = 6; // 垂直间距
                    while (y + rectHeight <= canvasElementHeight) {
                        ctxFill.fillStyle = 'black';
                        ctxFill.fillRect(x, y, rectWidth, rectHeight);
                        x += rectWidth + Math.floor(Math.random() * (maxSpacing - minSpacing + 1) + minSpacing);
                        if (x + rectWidth > canvasElementWidth) {
                            x = Math.floor(Math.random() * (maxSpacing - minSpacing + 1) + minSpacing);
                            y += rectHeight + verticalSpacing;
                        }
                    }
                    break;
                case "12": //二度
                    //画铺满矩形的线左倾斜线
                    var numLines = Math.ceil(canvasElementWidth / 2); // 计算斜线数量

                    // 画斜线
                    for (var i = 0; i < numLines; i++) {
                        var startX = canvasElementWidth / 2 + i * 8 + 32;
                        var startY = canvasElementHeight / 2 + i * 8 + 32;
                        ctxFill.beginPath();
                        ctxFill.moveTo(startX, -canvasElementHeight - 20);
                        ctxFill.lineTo(-canvasElementWidth - 20, startY);
                        ctxFill.stroke();
                    }
                    break;
                case "13": //深二度
                    //画铺满矩形的线左倾斜线
                    var numLines = Math.ceil(canvasElementWidth / 2); // 计算斜线数量
                    for (var i = 0; i < numLines; i++) {
                        // 画左斜线
                        var startXLeft = canvasElementWidth / 2 + i * 8 + 32;
                        var startYLeft = canvasElementHeight / 2 + i * 8 + 32;
                        ctxFill.beginPath();
                        ctxFill.moveTo(startXLeft, -canvasElementHeight - 20);
                        ctxFill.lineTo(-canvasElementWidth - 20, startYLeft);
                        ctxFill.stroke();
                        // 画右斜线
                        var startXRight = canvasElementWidth / 2 - i * 8 - 100;
                        var startYRight = canvasElementHeight / 2 + i * 8 - 100;
                        ctxFill.beginPath();
                        ctxFill.moveTo(startXRight, -canvasElementHeight - 20);
                        ctxFill.lineTo(canvasElementWidth + 20, startYRight);
                        ctxFill.stroke();
                    }
                    break;
                case "14":

                    break;
                default:
                    break;
            }
            imgSrc = canvasFill.toDataURL();
            canvasFill.remove();
            return imgSrc;
        }

        // ====================放大缩小STRAT==========================
        dcPanelBody.find(".zoomBtn").click(function () {
            var zoom = canvas.getZoom();
            var zoom_step = parseFloat(this.getAttribute("step"));
            zoom += zoom_step;
            SetCanvasZoom(zoom);

            // 选择放大倍数的设置为空
            dcPanelBody.find("#zoomSelect").val("");
        });
        dcPanelBody.find("#zoomSelect").change(function () {
            var zoom;
            wrap.style.overflow = "scroll";
            switch (this.value) {
                case "autowidth":
                    // 适应宽度
                    zoom = wrap.clientWidth / parseFloat(wrapperEl.getAttribute("native-width"));
                    break;
                case "autoheight":
                    // 适合页面大小
                    zoom = wrap.clientHeight / parseFloat(wrapperEl.getAttribute("native-height"));
                    break;
                default:
                    zoom = parseFloat(this.value);
                    break;
            }
            wrap.style.overflow = "auto";
            if (zoom) {
                SetCanvasZoom(zoom);
            }
        });
        // =====================放大缩小END===========================
        // ====================填充文字字体下拉START====================
        var FontFamilysArray = ctl.getSupportFontFamilys();
        if (!FontFamilysArray || FontFamilysArray.length == 0) {
            FontFamilysArray = ["宋体", "黑体", "微软雅黑", "楷体"];
        }
        var dc_fontFamily = dcPanelBody.find("#dc_fontFamily");
        for (var i = 0; i < FontFamilysArray.length; i++) {
            var option = jQuery("<option></option>");
            option.text(FontFamilysArray[i]);
            option.val(FontFamilysArray[i]);
            option.css("font-family", FontFamilysArray[i]);
            dc_fontFamily.append(option);
        }
        dc_fontFamily.val("黑体");
        // 绑定事件
        dc_fontFamily.change(function () {
            let fontFamilyStr = this.value;
            dc_fontFamily.css("font-family", fontFamilyStr);
            let activeTxt = canvas.getActiveObject();
            if (!activeTxt || activeTxt.get("type") != "i-text") return;
            if (activeTxt.isEditing) {
                // 编辑状态
                activeTxt.setSelectionStyles({ "fontFamily": fontFamilyStr });
            } else {
                activeTxt.fontFamily = fontFamilyStr;
                let s = activeTxt.styles;
                // 遍历行和列
                for (let i in s) {
                    for (let j in s[i]) {
                        s[i][j].fontFamily = fontFamilyStr; // 针对每个字设置字号
                    }
                }
                activeTxt.dirty = true;
            }
            canvas.renderAll();
            ActionBackNext.operateData();
        });
        // =====================填充文字字体下拉END=====================
        // ====================填充文字字号下拉START====================
        // 字号大小
        var dataFontSize = [
            { "title": "大特号", "number": "63" },
            { "title": "特号", "number": "54" },
            { "title": "初号", "number": "42" },
            { "title": "小初", "number": "36" },
            { "title": "一号", "number": "26.25" },
            { "title": "小一", "number": "24" },
            { "title": "二号", "number": "21.75" },
            { "title": "小二", "number": "18" },
            { "title": "三号", "number": "15.75" },
            { "title": "小三", "number": "15" },
            { "title": "四号", "number": "14.25" },
            { "title": "小四", "number": "12" },
            { "title": "五号", "number": "10.5" },
            { "title": "小五", "number": "9" },
            { "title": "六号", "number": "7.5" },
            { "title": "小六", "number": "6.75" },
            { "title": "七号", "number": "5.25" },
            { "title": "八号", "number": "4.5" },
            { "title": "8", "number": "8" },
            { "title": "9", "number": "9" },
            { "title": "10", "number": "10" },
            { "title": "11", "number": "11" },
            { "title": "12", "number": "12" },
            { "title": "14", "number": "14" },
            { "title": "16", "number": "16" },
            { "title": "18", "number": "18" },
            { "title": "20", "number": "20" },
            { "title": "22", "number": "22" },
            { "title": "24", "number": "24" },
            { "title": "26", "number": "26" },
            { "title": "28", "number": "28" },
            { "title": "36", "number": "36" },
            { "title": "40", "number": "40" },
            { "title": "48", "number": "48" },
            { "title": "72", "number": "72" },
        ];
        var dc_fontSize = dcPanelBody.find("#dc_fontSize");
        for (var i = 0; i < dataFontSize.length; i++) {
            var option = jQuery("<option></option>");
            option.text(dataFontSize[i].title);
            option.val(dataFontSize[i].number);
            dc_fontSize.append(option);
        }
        //[DUWRITER5_0-4547]20250624 lxy 增加默认字号设置
        var defaultFontSize = parseFloat(ctl.getAttribute('DefaultFontSizeForImageEditing')) || 40;
        dc_fontSize.val(defaultFontSize);

        // 绑定事件
        dc_fontSize.change(function () {
            let fontSizeStr = this.value;
            let activeTxt = canvas.getActiveObject();
            if (!activeTxt || activeTxt.get("type") != "i-text") return;
            if (activeTxt.isEditing) {
                // 编辑状态
                activeTxt.setSelectionStyles({ "fontSize": fontSizeStr });
            } else {
                activeTxt.fontSize = fontSizeStr;
                let s = activeTxt.styles;
                // 遍历行和列
                for (let i in s) {
                    for (let j in s[i]) {
                        s[i][j].fontSize = fontSizeStr; // 针对每个字设置字号
                    }
                }
                activeTxt.dirty = true;
            }
            canvas.renderAll();
            ActionBackNext.operateData();
        });
        // =====================填充文字字号下拉END=====================
        // ====================更新文字颜色START====================
        dcPanelBody.find("#dc_fontColor").change(function () {
            let fontColorStr = this.value;
            let activeTxt = canvas.getActiveObject();
            if (!activeTxt || activeTxt.get("type") != "i-text") return;
            if (activeTxt.isEditing) {
                // 编辑状态
                activeTxt.setSelectionStyles({ "fill": fontColorStr });
            } else {
                activeTxt.fill = fontColorStr;
                let s = activeTxt.styles;
                // 遍历行和列
                for (let i in s) {
                    for (let j in s[i]) {
                        s[i][j].fill = fontColorStr; // 针对每个字设置字号
                    }
                }
                activeTxt.dirty = true;
            }
            canvas.renderAll();
            ActionBackNext.operateData();
        });
        // =====================更新文字颜色END=====================
        // 删除元素
        dcPanelBody.find("#dc_del").click(function () {
            var dc_active = canvas.getActiveObject();
            if (dc_active) {
                canvas.remove(dc_active);
                if (dc_active.type == "activeSelection") {
                    dc_active.getObjects().forEach(function (x) {
                        canvas.remove(x);
                    });
                    canvas.discardActiveObject().renderAll();
                }
                ActionBackNext.operateData();
            }
        });
        dcPanelBody.find(".dc_undoBtn").click(function () {
            ActionBackNext.prevStepOperate();
            canvas.remove(selectionRect);
        });
        dcPanelBody.find(".dc_redoBtn").click(function () {
            ActionBackNext.nextStepOperate();
            canvas.remove(selectionRect);
        });
        dcPanelBody.find("#dc_imgFullScreen").click(function () {
            // console.log("全屏-------------------------");
            dc_dialogContainer.css({
                width: "100%",
                height: "100%",
                left: 0,
                top: 0,
                transform: "none",
            });
            dc_dialogContainer.find("#dcPanelBody").css({
                height: "calc(100% - 130px)",
                width: "100%",
            });
            dcPanelBody.find("#dc_imgCancelFullScreen").show();
            dcPanelBody.find("#dc_imgFullScreen").hide();
        });
        dcPanelBody.find("#dc_imgCancelFullScreen").click(function () {
            // console.log("取消全屏-------------------------");
            dc_dialogContainer.css({
                width: "600px",
                height: "620px",
                top: "50%",
                left: "50%",
                transform: "translate(-50%, -50%)",
            });
            dc_dialogContainer.find("#dcPanelBody").css({
                height: "550px",
                width: "100%",
            });
            dcPanelBody.find("#dc_imgFullScreen").show();
            dcPanelBody.find("#dc_imgCancelFullScreen").hide();
        });
        function successFun() {
            // 还原画布缩放比例
            SetCanvasZoom(1);
            //获取图片编辑后的base64
            // let ctx = canvas.getContext("2d");
            // ctx.drawImage(img, 0, 0);


            //根据旋转后的比例修改容器宽高。imgOptions：原本的图片宽高。imgRotateOptions：旋转后的图片宽高。
            // 计算缩放比例
            var newoptionswidth = options.Width;// 原容器宽
            var newoptionsheight = options.Height;// 原容器高
            if (imgOptions && imgRotateOptions) {
                var scalewidth = (imgRotateOptions.width / imgOptions.width) || 1;
                var scaleheight = (imgRotateOptions.height / imgOptions.height) || 1;
                if (scaleheight && scalewidth) {
                    newoptionswidth = newoptionswidth * scalewidth;
                    newoptionsheight = newoptionsheight * scaleheight;
                }
            }

            // 转编译一定要在图像绘制完毕以后
            let base64 = canvas.toDataURL("image/jpeg", 0.1);
            // console.log(base64, '=============base64');
            let index = base64.indexOf(",");
            let Src = "";
            if (index !== -1) {
                Src = base64.slice(index + 1, base64.length);
            }

            var data = {
                // ID: options.ID,
                Src,
                Height: newoptionsheight,
                Width: newoptionswidth,
                Attributes: {
                    inneradditionshape: JSON.stringify(canvas.toJSON()),
                },
            };
            // console.log(data, '=============data');
            // 如果图片存在{保持长宽比}时先取消{保持长宽比}再还原【DUWRITER5_0-4587】
            var _KeepWidthHeightRate = options.KeepWidthHeightRate;
            if (_KeepWidthHeightRate == true) {
                data.KeepWidthHeightRate = false;
                ctl.SetElementProperties(options.NativeHandle, data, false);
                ctl.SetElementProperties(options.NativeHandle, { KeepWidthHeightRate: true });
            } else {
                ctl.SetElementProperties(options.NativeHandle, data);
            }
            if (ctl.EventDialogChangeProperties && typeof ctl.EventDialogChangeProperties === 'function') {
                var changedOptions = ctl.GetElementProperties(ctl.CurrentElement());
                ctl.EventDialogChangeProperties(changedOptions);
            };
        }
    },

    /**
     * 创建执行编辑器命令对话框
     * @param options 执行命令属性
     * @param ctl 编辑器元素
     */
    DCExecuteCommandDialog: function (ctl) {
        var DCExecuteCommandHtml = `
        <div class="dc_DCExecuteCommandTable_container">
            <div class="dc_navigation_buttons">
                <button class="dc_nav_button" id="dc_nav_button_property">属性</button>
                <button class="dc_nav_button" id="dc_nav_button_open_local_file">打开本地文件</button>
                <button class="dc_nav_button" id="dc_nav_button_export">导出</button>
                <button class="dc_nav_button" id="dc_nav_button_about">关于</button>
                <button class="dc_nav_button" id="dc_nav_button_help">帮助</button>
            </div>
            
            <div id="dc_DCExecuteCommandTable_search_box">
                <input type="text" id="dc_DCExecuteCommandTable_search_input" placeholder="请输入命令名称">
                <button id="dc_DCExecuteCommandTable_search_btn">搜索</button>
            </div>
            
            <div class="dc_available_commands_title">可用命令</div>
            
            <div id="dc_DCExecuteCommandTable">
                <table>
                    <thead>
                        <tr>
                            <th>名称</th>
                            <th>说明</th>
                        </tr>
                    </thead>
                    <tbody> </tbody>
                </table>
            </div>
            
            <div class="dc_dc_DCExecuteCommand_options_box">
                <div class="dc_DCExecuteCommand_options_title">参数</div>
                <textarea id="dc_dc_DCExecuteCommand_options" placeholder="请输入命令参数 (可选)"></textarea>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "执行命令对话框",
            bodyHeight: 400,
            dialogContainerBodyWidth: 600,
            bodyClass: "dc_DCExecuteCommandsElement",
            bodyHtml: DCExecuteCommandHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions, null, false);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        var opts = {};

        //渲染表格
        renderCommandTable();

        dcPanelBody.find('#dc_DCExecuteCommandTable_search_input').focus();
        dcPanelBody.find('#dc_DCExecuteCommandTable_search_input').on('input', function () {
            searchCommand();
        });

        // dcPanelBody.find('#dc_DCExecuteCommandTable_search_input').keypress(function (event) {
        //     if (event.which === 13) {
        //         searchCommand();
        //     }
        // });
        dcPanelBody.find("#dc_DCExecuteCommandTable_search_btn").click(searchCommand);

        // 导航按钮点击事件
        dcPanelBody.find(".dc_nav_button").click(function () {
            var dc_nav_button_id = jQuery(this).attr("id");
            if (dc_nav_button_id === "dc_nav_button_property") {
                ctl.DCExecuteCommand("ElementProperties", true, null);
            } else if (dc_nav_button_id === "dc_nav_button_open_local_file") {
                ctl.DCExecuteCommand("fileopen", true, null);
                // 打开本地文件后关闭对话框
                setTimeout(() => {
                    var dc_dialogMark = jQuery(ctl).children("#dc_dialogMark");
                    var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
                    dc_dialogMark.remove();
                    dc_dialogContainer.remove();
                }, 100);
            } else if (dc_nav_button_id === "dc_nav_button_export") {
                ctl.DownLoadFile('xml');
            } else if (dc_nav_button_id === "dc_nav_button_about") {
                ctl.ShowAboutDialog();
            } else if (dc_nav_button_id === "dc_nav_button_help") {
                window.open("https://www.dcwriter.cn/", "_blank");
            }
        });

        function searchCommand() {
            var searchInput = dcPanelBody.find("#dc_DCExecuteCommandTable_search_input");
            var searchValue = searchInput.val().trim();
            if (searchValue == "") {
                // 没有输入内容，显示所有行
                renderCommandTable();
            } else {
                let searchCommandArr = [];
                MOCKARRAY.forEach(item => {
                    let ItemName = item.name.toLowerCase();
                    let searchItem = searchValue.toLowerCase();
                    //判断字符串是否以搜索内容开头
                    if (ItemName.startsWith(searchItem)) {
                        searchCommandArr.push(item);
                    }
                });
                // 渲染查找后的数据
                renderCommandTable(searchCommandArr);
            }
        }

        function renderCommandTable(CommandArr = MOCKARRAY) {
            opts = {};
            dcPanelBody.find('.ClickLine').removeClass('ClickLine');
            var mockArray = JSON.parse(JSON.stringify(CommandArr));
            // 根据英文首字母进行排序
            mockArray.sort(function (a, b) {
                return (a.name + "").localeCompare(b.name + "");
            });

            //循环创建元素
            var tbodyHtml = "";
            for (var i = 0; i < mockArray.length; i++) {
                var TRHtml = `
            <tr commandname="${mockArray[i].name}" >
                    <td class="dc_name">${mockArray[i].name}</td>
                    <td class="dc_description">${mockArray[i].description}</td>
            </tr>
            `;
                tbodyHtml += TRHtml;
            }
            dcPanelBody.find("#dc_DCExecuteCommandTable tbody").html(tbodyHtml);

            // 所有的表格行
            var trs = dcPanelBody.find("#dc_DCExecuteCommandTable tr[commandname]");
            // tr点击事件
            trs.click(function () {
                trs.removeClass("ClickLine");
                jQuery(this).addClass("ClickLine");
                var tds = jQuery(this).find("td");
                opts = {
                    name: tds.filter(".dc_name").html(),
                    description: tds.filter(".dc_description").html(),
                };
                Object.keys(DCEXECUTECOMMANDDEFAULTOPTIONS).forEach(item => {
                    if (item.toLowerCase().trim() === opts.name.toLowerCase().trim()) {
                        if (Object.prototype.toString.call(DCEXECUTECOMMANDDEFAULTOPTIONS[item]) === '[object Object]') {
                            dc_dialogContainer.find("#dc_dc_DCExecuteCommand_options").val(JSON.stringify(DCEXECUTECOMMANDDEFAULTOPTIONS[item]));
                        } else {
                            dc_dialogContainer.find("#dc_dc_DCExecuteCommand_options").val(DCEXECUTECOMMANDDEFAULTOPTIONS[item]);
                        }
                    }
                });
            });
            // 命令对话框中tr双击事件模拟点击确定按钮
            trs.dblclick(function () {
                var dc_submitValue = dc_dialogContainer.find("#dc_submitValue");
                dc_submitValue.click();
            });
        }

        function successFun() {
            var DCExecuteCommandOptions = dc_dialogContainer.find("#dc_dc_DCExecuteCommand_options").val();
            DCExecuteCommandOptions = DCExecuteCommandOptions.trim();
            // if (DCExecuteCommandOptions && DCExecuteCommandOptions.length) {
            try {
                DCExecuteCommandOptions = JSON.parse(DCExecuteCommandOptions);
            } catch (error) {
                console.log('命令参数格式不是一个对象', DCExecuteCommandOptions);
            }
            // }
            if (opts) {
                if (opts.name === "AboutControl") {
                    //设置弹框关闭后在弹出alert关于
                    // setTimeout(() => {
                    ctl.ShowAboutDialog();
                    // }, 0);
                } else if (opts.name === "TextSurroundings" || opts.name === "EmbedInText") {
                    //图片环绕和嵌入文本
                    ctl.DCExecuteCommand(opts.name, false, DCExecuteCommandOptions === null ? 'true' : DCExecuteCommandOptions);
                } else if (["Table_DeleteColumn", "Table_DeleteRow", "DocumentValueValidate", 'InputFieldUnderLine', 'Insertunorderedlist', 'Table_InsertRowDown', 'Table_InsertRowUp', 'Table_MergeCell'].indexOf(opts.name) !== -1) {
                    //参数必须为null的命令
                    ctl.DCExecuteCommand(opts.name, false, null);
                } else if (opts.name === "InsertChartElement") {
                    //    插入空图表
                    var options = { 'ID': 'chart1', 'Name': 'chartName', 'Width': 1200, 'Height': 1000 };
                    ctl.DCExecuteCommand(opts.name, true, options);
                } else if (opts.name === "rowspacing" && opts.description == '设置段前距') {
                    ctl.DCExecuteCommand("rowspacing", false, DCExecuteCommandOptions + ',top');
                } else if (opts.name === "rowspacing" && opts.description == '设置段后距') {
                    ctl.DCExecuteCommand("rowspacing", false, DCExecuteCommandOptions + ',bottom');
                } else if (opts.name === "DocumentSettingsDialog") {
                    ctl.DocumentSettingsDialog();
                } else if (opts.name === "BorderPatternDialog") {
                    ctl.BorderPatternDialog();
                } else {
                    if (opts.name != null && opts.name.toLowerCase().trim() === 'fontsize') {
                        DCExecuteCommandOptions = DCExecuteCommandOptions.toString();
                    }
                    ctl.DCExecuteCommand(opts.name, true, DCExecuteCommandOptions);
                }
            }
        }
    },

    /**
     * 创建查找&替换设置对话框
     * @param options 查找替换属性
     * @param ctl 编辑器元素
     */
    SearchAndReplaceDialog: function (options, ctl) {
        // 当SearchID为true时只能进行查找，无法替换
        var isSearchID = false;
        if (options && typeof (options.SearchID) == "boolean") {
            isSearchID = options.SearchID;
        }
        // var options = {
        //     "searchstring": "",//要查找的字符串
        //     "enablereplacestring": "true",//是否启用替换
        //     "replacestring": "李四",//要替换的字符串
        //     "backward": "true",//是否向后替换
        //     "ignorecase": "true",//是否区分大小写
        //     "logundo": "true",//记录撤销操作信息
        //     "excludebackgroundtext": "true",//忽略掉背景文字
        //     "SearchID": "false"//是否限制为查询元素编号
        // }
        // console.log(options);

        var SearchAndReplaceHtml = `
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">查找内容：</span>
                    <input type="text" id="dc_searchstring" class="dc_full" data-text="searchstring">
                </label>
            </div>
            <div class="dcBody-content">
                <label class="dc_flex">
                    <span class="dcTitle-text">
                    <label>
                        <input type="checkbox" id="dc_enablereplacestring" data-text="enablereplacestring" >
                        <span>替换为：</span>
                    </label>
                    </span>
                    <input type="text" class="dc_full" id="dc_replacestring" data-text="replacestring" disabled>
                </label>
            </div>
            <div class="dcBody-contents">
                <form class="dc_Box">
                    <h6 class="dc_title">方向</h6>
                    <div class="dcBody-content">
                        <label>
                            <input type="radio" id="dc_upward" name="radios">
                            <span>向上</span>
                        </label>
                        <label>
                            <input type="radio" id="dc_backward" name="radios" checked>
                            <span>向下</span>
                        </label>
                    </div>
                </form>
                <div class="dc_checkboxs">
                    <label>
                        <input type="checkbox" id="dc_ignorecase" data-text="ignorecase" >
                        <span>不区分大小写</span>
                    </label>
                    <br>
                    <label>
                        <input type="checkbox" id="dc_excludebackgroundtext" data-text="excludebackgroundtext" checked >
                        <span>忽略输入背景文字</span>
                    </label>
                    <br>
                    <label>
                        <input type="checkbox" id="dc_SearchID" data-text="SearchID" >
                        <span>限制为查找文档元素编号</span>
                    </label>
                    <br>
                    <label>
                        <input type="checkbox" id="dc_logundo" data-text="logundo" >
                        <span>记录撤销操作信息</span>
                    </label>
                </div>
            </div>
         
        `;
        var dialogOptions = {
            title: "查找和替换",
            bodyHeight: 310,
            bodyClass: "SearchAndReplace",
            bodyHtml: SearchAndReplaceHtml,
        };
        this.pageAppendDialog(ctl, function () { }, dialogOptions);
        // DUWRITER5_0-927：像word一样查找替换的时候选择其他字
        jQuery(ctl).children("#dc_dialogMark").css({
            opacity: 0,
            "pointer-events": "none",
        });
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = dc_dialogContainer.find("#dcPanelBody");
        var dcPanelFooter = dc_dialogContainer.find("#dcPanelFooter");
        //重新设置按钮
        dcPanelFooter.html(` 
            <button id="dc_search" class="foot_btn" disabled>查找(s)</button>
            <button id="dc_replace" class="foot_btn" disabled>替换(r)</button>
            <button id="dc_ReplaceAll" class="foot_btn" disabled>全部替换</button>
            <button id="dc_cancel" class="foot_btn">取消(c)</button>
        `);
        var searchInput = dcPanelBody.find("#dc_searchstring"); //查找内容输入框
        searchInput.focus();
        var replaceCheckbox = dcPanelBody.find("#dc_enablereplacestring"); //替换复选框
        var replaceInput = dcPanelBody.find("#dc_replacestring"); //替换内容输入框
        var SearchIDBtn = dcPanelBody.find("#dc_SearchID"); //限制为查找文档元素编号复选框
        var btns = dcPanelFooter.find("button.foot_btn:not(#dc_cancel)"); //查找、替换、全部替换按钮
        if (isSearchID == true) {
            // 查找替换对话框中阅读模式下不允许替换【DUWRITER5_0-4510】
            replaceCheckbox.prop("disabled", true);
        }
        // 查找内容输入框输入事件
        searchInput.on("input", function () {
            // 选择查找编号
            if (SearchIDBtn.is(":checked")) {
                // 所有不启用
                btns.prop("disabled", true);
                // 查找按钮需要用查找内容输入框是否为空来判断
                btns.filter("#dc_search").prop("disabled", jQuery(this).val() == "");
                return;
            }
            var isChecked = replaceCheckbox.is(":checked"); // 替换复选框是否选择
            if (jQuery(this).val() != "") {
                // 查找内容输入框不为空
                // 替换是否启用来确定按钮是否启用
                btns.prop("disabled", !isChecked);
                btns.filter("#dc_search").prop("disabled", false); //查找按钮一定启用
            } else {
                // 为空
                btns.prop("disabled", true);
            }
        });
        // 替换复选框切换事件
        replaceCheckbox.change(function () {
            var isChecked = jQuery(this).is(":checked"); // 替换复选框是否选择
            // 选择查找编号
            if (SearchIDBtn.is(":checked")) {
                return;
            }
            // 设置替换内容输入框是否可用
            replaceInput.prop("disabled", !isChecked);
            // 查找内容输入框不为空
            if (searchInput.val() != "") {
                // 查找内容输入框为空
                btns.filter("#dc_replace,#dc_ReplaceAll").prop("disabled", !isChecked);
            }
        });
        // 限制为查找文档元素编号复选框切换事件
        SearchIDBtn.change(function () {
            var isSearchID = SearchIDBtn.is(":checked");
            dcPanelBody
                .find(
                    "#dc_upward,#dc_backward,#dc_ignorecase,#dc_excludebackgroundtext,#dc_logundo"
                )
                .prop("disabled", isSearchID);
            if (replaceCheckbox.is(":checked")) {
                replaceInput.prop("disabled", isSearchID);
                if (searchInput.val() != "") {
                    btns
                        .filter("#dc_replace,#dc_ReplaceAll")
                        .prop("disabled", isSearchID);
                }
            }
        });
        // 按钮点击事件
        dcPanelFooter.find("button.foot_btn").click(function () {
            var _data = GetOrChangeData(dcPanelBody);
            var dc_backward = ctl.ownerDocument.getElementById('dc_backward');
            _data['backward'] = dc_backward.checked;
            console;
            var PromptJumpBackForSearch = ctl.DocumentOptions.BehaviorOptions.PromptJumpBackForSearch;
            var FindReplaceNotFoundWrinText = ctl.getAttribute('FindReplaceNotFoundWrinText');
            FindReplaceNotFoundWrinText = (FindReplaceNotFoundWrinText && FindReplaceNotFoundWrinText === 'true');
            switch (this.id) {
                case "dc_search":
                    // 查找
                    //20240102lxy:增加查找不到内容的提示DUWRITER5_0-1580
                    var result = ctl.Search(_data);
                    if (PromptJumpBackForSearch === false && result === -1 && FindReplaceNotFoundWrinText) {
                        alert(window.__DCSR.SearchReplaceNotFound);
                    }
                    break;
                case "dc_replace":
                    // 替换
                    var result = ctl.Reaplace(_data);
                    if (PromptJumpBackForSearch === false && result === -1 && FindReplaceNotFoundWrinText) {
                        alert(window.__DCSR.SearchReplaceNotFound);
                    }
                    break;
                case "dc_ReplaceAll":
                    // 全部替换
                    var result = ctl.ReplaceAll(_data);
                    if (PromptJumpBackForSearch === false && result === 0 && FindReplaceNotFoundWrinText) {
                        alert(window.__DCSR.SearchReplaceNotFound);
                    }
                    break;
                case "dc_cancel":
                    // 取消
                    ctl.ClearTextHighlight();
                    jQuery(ctl).children("#dc_dialogMark,#dc_dialogContainer").remove();
                    break;
                default:
                    break;
            }
        });
    },
    /**
    * 前景色对话框
    * @param options 属性
    * @param ctl 编辑器元素
    * @param isInsertMode 是否是插入模式
    */
    ColorDialog: function (options, ctl, isInsertMode, ele) {
        var ColorHtml = `
                <div class="dc_back_color_box">
                    <span>请选择前景色：</span>
                    <input type="color" id='dc_color' />
                </div>
        `;
        var dialogOptions = {
            title: "设置前景色属性",
            bodyHeight: 70,
            bodyClass: "dc_ColorElement",
            bodyHtml: ColorHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        function successFun() {
            var color = dcPanelBody.find("#dc_color").val();
            ctl.DCExecuteCommand('color', false, color);
        }
    },
    /**
    * 背景景色对话框
    * @param options 属性
    * @param ctl 编辑器元素
    * @param isInsertMode 是否是插入模式
    */
    BackColorDialog: function (options, ctl, isInsertMode, ele) {
        var BackColorHtml = `
              <div class="dc_back_color_box">
                    <span>请选择背景色：</span>
                    <input type="color" id='dc_back_color' />
                </div>
        `;
        var dialogOptions = {
            title: "设置背景色属性",
            bodyHeight: 70,
            bodyClass: "dc_BackColorElement",
            bodyHtml: BackColorHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        function successFun() {
            var color = dcPanelBody.find("#dc_back_color").val();
            ctl.DCExecuteCommand('BackColor', false, color);
        }
    },
    /**
    * 下划线属性对话框
    * @param ctl 编辑器元素
    */
    UnderlineStyleDialog: function (options, ctl, isInsertMode, ele) {
        var UnderlineStyleHtml = `
            <div class="dc_underline_box">
                <div class="dc_underline_color_box">
                    <span>下划线颜色：</span>
                    <input type="color" id='dc_underline_color' />
                </div>
                <div class="dc_underline_style_box">
                    <span>下划线样式：</span>
                    <select id="dc_underline_style">
                        <option value="None">None</option>
                        <option value="Single">Single</option>
                        <option value="Thick">Thick</option>
                        <option value="Dash">Dash</option>
                        <option value="Dot">Dot</option>
                        <option value="DashDot">DashDot</option>
                        <option value="DashDotDot">DashDotDot</option>
                        <option value="Double">Double</option>
                        <option value="Wavy">Wavy</option>
                        <option value="WavyDouble">WavyDouble</option>
                        <option value="WavyHeavy">WavyHeavy</option>
                    </select>
                </div>
            </div>
        `;
        var dialogOptions = {
            title: "设置下划线样式",
            bodyClass: "dc_UnderlineElement",
            bodyHeight: 100,
            dialogContainerBodyWidth: 200,
            bodyHtml: UnderlineStyleHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        if (options && Object.keys(options).length) {
            dcPanelBody.find("#dc_underline_color").val(options.color);
            dcPanelBody.find("#dc_underline_style").val(options.textunderlinestyle);
        }
        function successFun() {
            var color = dcPanelBody.find("#dc_underline_color").val();
            var textunderlinestyle = dcPanelBody.find("#dc_underline_style").val();
            ctl.DCExecuteCommand('UnderlineStyle', false, {
                color,
                textunderlinestyle
            });
        }
    },
    //查看错误信息对话框
    ReportExceptionDialog: function (ctl) {
        var ReportExceptionHtml = `
        <div class="dc_ReportExceptions_Box">
            <div id="dc_ReportExceptionRefreshBox">
                <span class="dc_ReportExceptionRefresh" >刷新</span>
            </div>
            <table>
                <thead>
                    <tr>
                        <th>序号</th>
                        <th>来源名称</th>
                        <th>异常信息</th>
                         <th>错误等级</th>

                    </tr>
                </thead>
                <tbody id="dc_ReportExceptionBox"> </tbody>
            </table>
            <div id="dc_ReportExceptionErrorBox" >
                <div id="dc_ReportExceptionItemTopBox"><span id="dc_ReportExceptionItemTop">✖</span></div>
                <pre id="dc_ReportExceptionItem"></pre>
            </div>
        </div>
        `;
        var dialogOptions = {
            title: "查看错误信息对话框",
            bodyHeight: 325,
            dialogContainerBodyWidth: 550,
            bodyClass: "dc_ReportExceptionsElement",
            bodyHtml: ReportExceptionHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);
        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        function renderReportException() {
            if (
                window &&
                window.ReportExceptionArr &&
                window.ReportExceptionArr.length
            ) {
                let arr = window.ReportExceptionArr;
                let arrHTML = ``;
                for (var i = 0; i < arr.length; i++) {
                    let item = arr[i];
                    arrHTML += `
                    <tr class="dc_ReportExceptionsTr">
                        <td>${i + 1}</td>
                        <td><span class="dc_ReportExceptionsTd" title="${item.strSourceName
                        }">${item.strSourceName}</span></td>
                        <td><span id="${i}" class="dc_ReportExceptionsTd dc_ReportExceptionsTd3 dc_ReportExceptionItemButton" title="${item.strExceptionMessage
                        }">${item.strExceptionMessage}</span></td>
                        <td><span class="dc_ReportExceptionsTd dc_ReportExceptionsTd2" title="${item.intLevel
                        }">${item.intLevel}</span></td>
                        </tr>
                    `;
                }
                jQuery(dc_dialogContainer).find("#dc_ReportExceptionBox")[0].innerHTML =
                    arrHTML;
            }
        }
        renderReportException();
        jQuery(dc_dialogContainer)
            .find("#dc_ReportExceptionRefreshBox")
            .click(function (e) {
                if (e.target && e.target.className === "dc_ReportExceptionRefresh") {
                    renderReportException();
                }
            });
        jQuery(dc_dialogContainer)
            .find("#dc_ReportExceptionBox")
            .click(function (e) {
                if (
                    e.target &&
                    e.target.className.indexOf("dc_ReportExceptionItemButton") !== -1
                ) {
                    jQuery(dc_dialogContainer).find(
                        "#dc_ReportExceptionErrorBox"
                    )[0].style.display = "block";
                    jQuery(dc_dialogContainer).find(
                        "#dc_ReportExceptionItem"
                    )[0].innerHTML =
                        window.ReportExceptionArr[e.target.id].strSourceName +
                        `<br />` +
                        window.ReportExceptionArr[e.target.id].strExceptionMessage +
                        `<br />` +
                        window.ReportExceptionArr[e.target.id].strExceptionString;
                }
            });
        jQuery(dc_dialogContainer)
            .find("#dc_ReportExceptionErrorBox")
            .click(function (e) {
                if (e.target && e.target.id === "dc_ReportExceptionItemTop") {
                    jQuery(dc_dialogContainer).find(
                        "#dc_ReportExceptionErrorBox"
                    )[0].style.display = "none";
                }
            });

        function successFun() { }
    },

    /**
        * 插入目录对话框
        * @param options 属性
        * @param ctl 编辑器元素
        */
    InsertDirectoryFieldDialog: function (options, ctl) {
        if (!options || !Object.keys(options).length) {
            options = {
                ID: "directory",
                DisplayLevel: 3,//层级默认为3
                ShowPageIndex: true,
            };
        }

        var DirectoryFieldHtml = `
           <div class="dc_DirectoryField_Content">
                <label class="dc_flex dc_DirectoryField_Content_item">
                    <span class="dcTitle-text">编号：</span>
                    <input placeholder="请输入编号ID" type="text" class="dc_DirectoryField_Content_item dc_full"   data-text="ID" />
                </label>
                <label class="dc_flex dc_DirectoryField_Content_DisplayLevel ">
                    <span class="dcTitle-text">显示级别：</span>
                    <select data-text="DisplayLevel" class="dc_DirectoryField_Content_item dc_full">
                            <option value="1">1</option>
                            <option value="2">2</option>
                            <option value="3">3</option>
                            <option value="4">4</option>
                            <option value="5">5</option>
                            <option value="6">6</option>
                            <option value="7">7</option>
                            <option value="8">8</option>
                            <option value="9">9</option>
                    </select>
                </label>
                <label class="dc_flex dc_DirectoryField_Content_item">
                    <input  type="checkbox" data-text="ShowPageIndex" />
                    <span class="dc_DirectoryField_ShowPageIndex"> 显示页码</span>
                </label>
           </div>
        `;
        var dialogOptions = {
            title: "插入目录",
            bodyClass: "dc_DirectoryField_Element",
            bodyHeight: 170,
            dialogContainerBodyWidth: 260,
            bodyHtml: DirectoryFieldHtml,
        };
        this.pageAppendDialog(ctl, successFun, dialogOptions);

        //获取对话框元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer");
        var dcPanelBody = jQuery(dc_dialogContainer).find("#dcPanelBody");
        //回显值
        // if (options && Object.keys(options).length) {
        GetOrChangeData(dcPanelBody, options);
        // } 

        function successFun() {
            var _data = GetOrChangeData(dcPanelBody);
            if (_data) {
                for (var key in _data) {
                    options[key] = _data[key];
                }
            }
            ctl.DCExecuteCommand("InsertDirectoryField", false, options);
        }
    },

    //自定义属性公共组件
    attributeComponents: function (parentId = "", attributes = {}, ctl) {
        //DUWRITER5_0-3015，兼容四代数组的方式
        if (Array.isArray(attributes)) {
            let dc_arrayListattributes = JSON.parse(JSON.stringify(attributes));
            attributes = {};
            dc_arrayListattributes.forEach((item) => {
                attributes[item.Name] = item.Value;
            });
        }
        jQuery(ctl).find("#dc_attr-table-box").on('keydown');
        let dataList = [];
        // 对象转换为数组
        if (
            attributes &&
            Object.keys(attributes) &&
            Object.keys(attributes).length
        ) {
            let keys = Object.keys(attributes);
            keys.map((item) => {
                dataList.push({
                    key: item,
                    val: attributes[item],
                });
            });
        }
        let attrHtml = `
       
        <div class="dc_attribute_dialog_box" id="${parentId}">
          <p class="dc_attribute_dialog_title"> 
            <span id="dc_deletButton">清空</span>
          </p>  
          <div class="dc_attribute_dialog_table_box">
            <table id="dc_attr-table-box" class="dc_currentTableDom" border="1">
                <tr>
                    <th class="dc_ons-2">名称</th>
                    <th class="dc_ons-3">值</th>
                    <th class="dc_ons-4">操作</th>
                </tr>
                <tr class="dc_tr_abs">
                    <td class="dc_ons-2 dc_input-dom"><input class="dc_ons-2" type="text" data-arraytext="Text"></input></td>
                    <td class="dc_ons-3 dc_input-dom"><input class="dc_ons-3" type="text" data-arraytext="Text"></input></td>
                    <td class="dc_ons-4 dc_delete-button">×</td>
                </tr>
            </table>
          </div>
          <button class="dc_add_attr_button" id="dc_addButton">+ 添加自定义属性</button>
        </div>`;
        jQuery(ctl).find("#dc_attr-box").html(attrHtml);

        if (dataList && dataList.length) {
            var CDC = jQuery(ctl).find(".dc_tr_abs")[0];
            for (var i = 0; i < dataList.length; i++) {
                var tr = ctl.ownerDocument.createElement("tr");
                var trKey = dataList[i].key && dataList[i].key.replace ? dataList[i].key.replace(/"/g, '&quot;').replace(/'/g, '&apos;') : dataList[i].key;
                var trVal = dataList[i].val && dataList[i].val.replace ? dataList[i].val.replace(/"/g, '&quot;').replace(/'/g, '&apos;') : dataList[i].val;
                tr.className = "dc_tr_abs";
                tr.innerHTML = '<td class="dc_ons-2"><input class="dc_ons-2 dc_input-dom" type="text" data-arraytext="Text" value="' + trKey + '"></input></td><td class="dc_ons-3"><input class="dc_ons-3 dc_input-dom" type="text" data-arraytext="Text" value="' + trVal + '"></input></td><td class="dc_ons-4 dc_delete-button">×</td>';
                CDC.before(tr);
            }
        }
        jQuery(ctl).find("#dc_deletButton").click(function () {
            var CDC = jQuery(ctl).find(".dc_tr_abs");
            for (let i = 0; i < CDC.length; i++) {
                CDC[i].remove();
            }
            jQuery(ctl).find("#dc_attr-table-box").append(tr_template());
        });
        jQuery(ctl).find("#dc_addButton").click(function () {
            let trArr = jQuery(ctl).find(".dc_tr_abs");
            let last = trArr[trArr.length - 1];
            last.after(tr_template());
        });
        jQuery(ctl).find("#dc_attr-table-box").on("input", "input", function () {
            var input = jQuery(this);
            var tr = input.parents("tr");
            if (tr.nextAll("tr").length == 0) {
                tr.after(tr_template());
            }
        });
        jQuery(ctl).find("#dc_attr-table-box").on("click", "td", function () {
            let trArr = jQuery(ctl).find(".dc_tr_abs");
            if (this.className.includes("dc_delete-button")) {
                if (trArr.length <= 1) {
                    return alert(window.__DCSR.InputAttributeTableDelete);
                }
                this.parentNode.remove();
            }
        });
        //定义表格行公用模板
        var tr_template = function () {
            let templateHtml = `
            <td class="dc_ons-2"><input class="dc_ons-2 dc_input-dom" type="text" data-arraytext="Text" value=""></input></td>
            <td class="dc_ons-3"><input class="dc_ons-3 dc_input-dom" type="text" data-arraytext="Text" value=""></input></td>
            <td class="dc_ons-4 dc_delete-button">×</td>`;
            var newtr = ctl.ownerDocument.createElement("tr");
            newtr.className = "dc_tr_abs";
            newtr.innerHTML = templateHtml;
            return newtr;
        };
        // 按下键盘上下左右，控制光标跳转单元格
        function AttributeCellInputFocus(event) {
            //键盘监听上下左右键，根据按键跳转单元格输入框
            let cells = jQuery(ctl).find(`${parentId} input`);
            let currentCell = ctl.ownerDocument.activeElement; // 获取当前拥有焦点的单元格
            let index = 0;//默认当前input的下标
            let targetCell = null;//目标input
            if (event.key === 'ArrowUp') {
                // 切换到上方的单元格
                index = Array.from(cells).indexOf(currentCell);
                targetCell = cells[index - 2]; // 每行有2个input
            } else if (event.key === 'ArrowDown') {
                // 切换到下方的单元格
                index = Array.from(cells).indexOf(currentCell);
                targetCell = cells[index + 2]; // 每行有2个input
            } else if (event.key === 'ArrowLeft') {
                // 判断光标位置
                if (currentCell.selectionStart === 0 && currentCell.selectionEnd === 0) {
                    // 切换到左边的单元格
                    index = Array.from(cells).indexOf(currentCell);
                    targetCell = cells[index - 1];
                }
            } else if (event.key === 'ArrowRight') {
                // 判断光标位置
                if (currentCell.selectionStart === currentCell.value.length && currentCell.selectionEnd === currentCell.value.length) {
                    // 切换到右边的单元格
                    index = Array.from(cells).indexOf(currentCell);
                    targetCell = cells[index + 1];
                }
            }
            if (targetCell) {
                targetCell.setSelectionRange(targetCell.value.length, targetCell.value.length);
                setTimeout(() => {
                    targetCell.focus();
                });
            }
        }
        // 监听键盘按下事件
        jQuery(ctl).find("#dc_attr-table-box").on('keydown', AttributeCellInputFocus);
    },

    //获取自定义属性
    attributeComponents_getAttributeObj: function (parentDom) {
        let tableBox = jQuery(parentDom).find("table")[0];
        let trList = jQuery(tableBox).find(".dc_tr_abs");
        let attributes = {};
        for (var i = 0; i < trList.length; i++) {
            let key = trList[i].children[0].children[0].value;
            let val = trList[i].children[1].children[0].value;
            if (key !== "" || val !== "") {
                attributes = {
                    ...attributes,
                    [key]: val,
                };
            }
        }
        return attributes;
    },

    /**
     * 取消浏览器默认事件
     * @param eventObject 事件Event
     */
    completeEvent: function (eventObject) {
        if (eventObject == null) {
            if (window.event) {
                eventObject = window.event;
            }
        }
        if (eventObject != null) {
            eventObject.cancelBubble = true;
            if (eventObject.stopPropagation) {
                eventObject.stopPropagation();
            }
            if (eventObject.stopImmediatePropagation) {
                eventObject.stopImmediatePropagation();
            }
            if (eventObject.preventDefault) {
                eventObject.preventDefault();
            }
            eventObject.returnValue = false;
        }
    },

    /**
     * 创建的对话框方法
     * @param ctl 编辑器元素
     * @param successFun 确定按钮触发事件
     * @param options 对话框一些设置
     * @param isUseDialogReadOnly 是否使用对话框只读属性，默认使用
     */
    pageAppendDialog: function (ctl, successFun, options, callBack, isUseDialogReadOnly = true) {

        // [DUWRITER5_0-4737] 20250825 增加参数isUseDialogReadOnly，默认使用，用于在编辑器中使用对话框时，不使用对话框只读属性
        if (isUseDialogReadOnly) {
            var IsDialogReadOnly = ctl.getAttribute('IsDialogReadOnly');
        } else {
            var IsDialogReadOnly = false;
        }

        //创建包裹html
        var containerInnerHtml = `<div id="dc_dialogMark"></div><div id="dc_dialogContainer" class="dc-dialog-container">
        <div id="dcPanelHeader">
            <h3 class="dcHeader-title"></h3>
            <span class="dcTool-close-btn">×</span>
        </div>
        <div id="dcPanelBody">
            
        </div>
        <div id="dcPanelFooter">
            <span class="dcButton-left dclinkbutton" id="dc_removeDialog">
                取消
            </span>
            <span class="dcButton-left dc-primary-button dclinkbutton ${IsDialogReadOnly === 'true' || IsDialogReadOnly === true ? 'dc_submitValue_Readonly' : ''}"   title="${IsDialogReadOnly === 'true' || IsDialogReadOnly === true ? '只读模式下禁止修改' : ''}" id="dc_submitValue">
                确认
            </span>
        </div>
    </div>`;
        // 创建对话框时清空编辑器的title【DUWRITER5_0-1189】
        ctl.title = "";
        //创建css样式
        var docHead = ctl.ownerDocument.head;
        var dialogLink = docHead.querySelector("style#dialogStyle");
        if (!dialogLink) {
            // 防止多次插入样式元素
            dialogLink = ctl.ownerDocument.createElement("style");
            dialogLink.setAttribute("id", "dialogStyle");
            dialogLink.innerHTML = DIALOGSTYLE;
            docHead.appendChild(dialogLink);
        }
        //确保页面中只有一个对话框元素
        jQuery(ctl).children("#dc_dialogMark").remove();
        jQuery(ctl).children("#dc_dialogContainer").remove();
        //判断右键菜单是否展示
        var hasContextMenu = ctl.querySelector('#dcContextMenu');
        if (hasContextMenu) {
            hasContextMenu.remove();
        }
        //页面中插入对话框
        jQuery(ctl).append(containerInnerHtml);
        // 弹出对话框的同时取消光标和下拉
        var dropdown = ctl.querySelector("#divDropdownContainer20230111");
        var caret = ctl.querySelector("#divCaret20221213");
        if (dropdown != null) {
            dropdown.CloseDropdown();
        }
        //关闭表格下拉输入域
        var dropdownTable = ctl.querySelector(`#DCTableControl20240625151400`);
        if (dropdownTable && dropdownTable.CloseDropdownTable) {
            dropdownTable.CloseDropdownTable();
        }
        //关闭知识库
        var divknowledgeBase = ctl.querySelector('#divknowledgeBase20240103');
        if (divknowledgeBase && divknowledgeBase.DistroyKnowledgeBase) {
            divknowledgeBase.DistroyKnowledgeBase();
        }
        if (caret != null) {
            caret.style.display = "none";
            clearInterval(caret.handleTimer);
        }
        var dc_dialogMark = jQuery(ctl).children("#dc_dialogMark"); //蒙版元素
        var dc_dialogContainer = jQuery(ctl).children("#dc_dialogContainer"); //对话框元素
        var dcPanelBody = dc_dialogContainer.find("#dcPanelBody"); //对话框正文元素
        // 对话框属性设置
        if (options && typeof options == "object") {
            // 修改标题数据
            if (options.title) {
                dc_dialogContainer.find(".dcHeader-title").html(options.title);
            }
            // 修改对话框正文元素高度
            if (options.bodyHeight) {
                dcPanelBody.height(options.bodyHeight);
            }
            // 修改对话框元素宽度
            if (options.dialogContainerBodyWidth) {
                dc_dialogContainer.width(options.dialogContainerBodyWidth);
            }
            // 对话框正文元素添加class名称
            if (options.bodyClass) {
                dcPanelBody.addClass(options.bodyClass);
            }
            // 给对话框正文元素赋值
            if (options.bodyHtml) {
                dcPanelBody.html(options.bodyHtml).promise().done(function () {
                    var dcDataModel = dcPanelBody.find('.dc_input_number_data_model');
                    if (dcDataModel && dcDataModel.length) {
                        setTimeout(() => {//展示计算结果
                            for (var i = 0; i < dcDataModel.length; i++) {
                                var item = dcDataModel[i];
                                updateDataModelValue(item);//延时计算厘米值
                            }
                        }, 0);
                    }
                });;
            }
        }
        //遮罩层取消掉鼠标事件和键盘事件
        dc_dialogMark.on("mousedown click keydown", function (e) {
            // this.completeEvent(e);
        });
        dc_dialogContainer.on("mousedown click keydown", function (e) {
            e.stopPropagation();
        });
        // 暂时处理在对话框中输入框等获得焦点时会取消光标，增加取消光标事件的判断【DUWRITER5_0-5206】
        dc_dialogContainer.on("focus", "input,textarea,select,button,[contenteditable],a[href]", function () {
            var caret = ctl.querySelector("#divCaret20221213");
            if (caret != null) {
                caret.style.display = "none";
                clearInterval(caret.handleTimer);
                caret.handleTimer = null;
            }
        });
        //点击x图标的事件
        var closeIcon = dc_dialogContainer.find(".dcTool-close-btn");
        closeIcon.on("click", function () {
            dc_dialogMark.remove();
            dc_dialogContainer.remove();
        });
        //点击确认的事件
        var dc_submitValue = dc_dialogContainer.find("#dc_submitValue");
        dc_submitValue.on("click", function () {
            if (IsDialogReadOnly === 'true' || IsDialogReadOnly === true) {
                return;
            }
            //DUWRITER5_0-4892 20251105 lxy 处理确认按钮的返回值，如果返回false，则不关闭对话框
            var isClose = true;
            if (!!successFun && typeof successFun == "function") {
                isClose = successFun();
            }
            if (callBack) {
                typeof callBack == "function" ? callBack() : null;
            }
            if (isClose === false) {
                return;
            }
            dc_dialogMark.remove();
            dc_dialogContainer.remove();

        });
        //点击取消的事件
        var dc_removeDialog = dc_dialogContainer.find("#dc_removeDialog");
        dc_removeDialog.on("click", function () {
            dc_dialogMark.remove();
            dc_dialogContainer.remove();
            if (options.bodyClass === 'bordersShading') {
                callBack && callBack();
            }
        });

        //弹框拖拽
        let drag = ctl.ownerDocument.getElementById("dc_dialogContainer");
        let dragContent = ctl.ownerDocument.getElementById("dcPanelHeader");
        let dialogBox = ctl.ownerDocument.getElementById("dc_dialogMark");
        let SearchAndReplaceDialog = (options && options.bodyClass && options.bodyClass === 'SearchAndReplace');
        var isDragging = false;
        var offsetX = 0;
        var offsetY = 0;
        dragContent.addEventListener("mousedown", function (e) {
            //[DUWRITER5_0-3923] 增加判断，编辑器宽高小于弹框宽高时，才允许拖拽
            var dragRect = drag.getBoundingClientRect();//对护框的大小
            var ctlRect = ctl.getBoundingClientRect();//编辑器的大小
            if (ctlRect.width > dragRect.width || ctlRect.height > dragRect.height) {
                isDragging = true;
                offsetX = e.clientX - drag.offsetLeft;
                offsetY = e.clientY - drag.offsetTop;
            }
            SearchAndReplaceDialog ? dialogBox.style["pointer-events"] = "auto" : null; //在查找与替换时设置遮罩层不允许穿透
        });
        ctl.ownerDocument.addEventListener("mousemove", function (e) {
            if (isDragging) {
                var posX = e.clientX - offsetX;
                var posY = e.clientY - offsetY;
                // 限制有问题暂时不用
                posX = Math.max(
                    drag.offsetWidth / 2,
                    Math.min(posX, window.innerWidth - drag.offsetWidth / 2)
                );
                posY = Math.max(
                    0,
                    Math.min(posY, window.innerHeight - drag.offsetHeight / 2)
                );
                //重新设置禁止拖拽至可视区域之外
                if (posY < drag.offsetHeight / 2) {
                    posY = drag.offsetHeight / 2;
                }
                drag.style.left = posX + "px";
                drag.style.top = posY + "px";
            }
        });
        ctl.ownerDocument.addEventListener("mouseup", function () {
            isDragging = false;
            SearchAndReplaceDialog ? dialogBox.style["pointer-events"] = "none" : null; //查找弹框时设置遮罩可穿透属性
        });

        let that = this;
        // 可见性表达式鼠标点击展示说明内容
        var dcvisibleexpression = jQuery(ctl).find('.dc_visible_expression');
        if (dcvisibleexpression && dcvisibleexpression.length) {
            for (var i = 0; i < dcvisibleexpression.length; i++) {
                var item = dcvisibleexpression[i];
                item.addEventListener('click', function () {
                    that.visibleexpressionDialog(ctl);
                });
            }
        }

        dialogBox.addEventListener('mouseover', function (event) {
            // 鼠标滑过元素时要执行的操作
            // 在这里可以添加你的代码逻辑
            // 例如，可以修改元素的样式或执行其他操作
            event.stopPropagation(); // 阻止事件冒泡到其他元素
        });

        //监听所有需要转换显示1/300英寸为厘米的输入框
        var dcDataModel = dcPanelBody.find('.dc_input_number_data_model');
        dcDataModel.on('input', function () {
            if (this.value && this.value > 0) {
                updateDataModelValue(this);
            }
        });

        // 计算预估值并更新显示
        function updateDataModelValue(inputElement) {
            var key = inputElement.getAttribute("data-text");
            var datamodelDom = dcPanelBody.find(`[dc-text-model=${key}]`)[0] || null;
            if (datamodelDom) {

                datamodelDom.style.color = "#ff6767";
                datamodelDom.style.marginLeft = "2px";

                var value = parseFloat(inputElement.value);
                if (!isNaN(value) && value > 0) {
                    // 计算预估值
                    var datamodelValua = ((value / 300) * 2.54).toFixed(2);
                    datamodelDom.innerText = `≈${datamodelValua}（厘米）`;
                } else {
                    datamodelDom.innerText = '';
                }
            }
        }






    },
    /**
    * 可见性表达式的提示对话框
    * @param ctl 编辑器元素
    */
    visibleexpressionDialog: function (ctl) {
        var visibleexpressionHtml = `
        <div class="dc_visibleexpression_header">
            <span>表达式介绍</span>
            <div class="dcHeader-tool">
                    <b class="dcTool-close dc_visible_expression_table_close">✖</b>
                </div>
        </div>
        <div class="dc_visibleexpression_container">

          <table class="dc_visibleexpression_table_content" cellpadding="0" cellspacing="0" width="100%">
            <thead>
                <tr class="dc_visibleexpression_header_td">
                    <td>函数</td>
                    <td>解释说明</td>
                    <td>用法</td>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>ABS(V)</td>
                    <td>获得绝对值</td>
                    <td>ABS(V)</td>
                </tr>
                <tr>
                    <td>ACOS(V) </td>
                    <td>计算反余弦值。</td>
                    <td>ACOS(V) </td>
                </tr>
                <tr>
                    <td>ASIN(V)</td>
                    <td>计算反正弦值。</td>
                    <td>ASIN(V)</td>
                </tr>
                <tr>
                    <td>ATAN(V)</td>
                    <td>计算反正切值。</td>
                    <td>ATAN(V)</td>
                </tr>
                <tr>
                    <td>ATAN2(X,Y)</td>
                    <td>计算反正切值。</td>
                    <td>ATAN2(X,Y)</td>
                </tr>
                <tr>
                    <td>AVERAGE(X1，X2...) </td>
                    <td>计算算术平均值。</td>
                    <td>示例：输入域数值表达式：AVERAGE([field1],[field2])--代表当前输入域值为输入域ID为field1和ID为field2之和的平均值。（10、20=15）</td>
                </tr>
                <tr>
                    <td>CDOUBLE(V,DefaultValue) </td>
                    <td>将指定数据转换为浮点数，第二个参数为转换失败后的返回的默认值。</span> </td>
                    <td>CDOUBLE(V,DefaultValue) </td>
                </tr>
                <tr>
                    <td>CEILING(V) </td>
                    <td>获得大于等于指定数值的最小整数。</td>
                    <td>CEILING(V) </td>
                </tr>
                <tr>
                    <td>CINT(V,DefaultValue) </td>
                    <td>将指定数据转换为整数，第二个参数为转换失败后返回的默认值。</span> </td>
                    <td>CINT(V,DefaultValue) </td>
                </tr>
                <tr>
                    <td>COS(V)</td>
                    <td>返回指定角度的余弦值。 </td>
                    <td>COS(V)</td>
                </tr>
                <tr>
                    <td>COUNT(X1,X2,...)</td>
                    <td>返回参数的个数 </td>
                    <td>示例：输入域数值表达式：COUNT([field1],[field3])--代表当前输入域值为该函数里面的个数（10,11,12=3）</td>
                </tr>
                <tr>
                    <td>EXP(V)</td>
                    <td>返回e的n次方。</td>
                    <td>EXP(V)</td>
                </tr>
                <tr>
                    <td>FLOOR(V)</td>
                    <td>返回小于等于指定数字的整数。</td>
                    <td>FLOOR(V)</td>
                </tr>
                <tr>
                    <td>INT(V)</td>
                    <td>四舍五入的数字取整。 </td>
                    <td>示例：输入域数值表达式：INT([field1])--代表当前输入域值为输入域ID-field1的整数值(12.4=12)</td>
                </tr>
                <tr>
                    <td>LOG(A,BASE) </td>
                    <td>返回指定底数的对数值。 </td>
                    <td>LOG(A,BASE) </td>
                </tr>
                <tr>
                    <td>LOG(V)</td>
                    <td>返回以10为底数的对数值。 </td>
                    <td>LOG(V)</td>
                </tr>
                <tr>
                    <td>MAX(V1，V2...) </td>
                    <td>返回最大值。</td>
                    <td>示例：输入域数值表达式：MAX([field1],[field2])--代表当前输入域值为输入域ID为field1、ID为field2值的最大值（20、40=40）
                    </td>
                </tr>
                <tr>
                    <td>MIN(V1，V2...) </td>
                    <td>返回最小值。</td>
                    <td>示例：输入域数值表达式：MIN([field1],[field2])--代表当前输入域值为输入域ID为field1、ID为field2值的最小值(20、40=20)
                    </td>
                </tr>
                <tr>
                    <td>MOD(V,DIVISOR)</td>
                    <td>返回两数相除的余数。 </td>
                    <td>示例：输入域数值表达式：MOD([field1],[field2])--代表当前输入域值为输入域ID为field1和ID为field2相除的余数（20/6=2）
                    </td>
                </tr>
                <tr>
                    <td>ODD(V)</td>
                    <td>将正（负）数向上（下）舍入到最接近的奇数。</span> </td>
                    <td>ODD(V)</td>
                </tr>
                <tr>
                    <td>POW(NUMER,POWER)</td>
                    <td>返回某数的乘幂。</td>
                    <td>示例：输入域数值表达式：POW([field1],[field2])--代表当前输入域值为输入域ID为field1的乘幂、ID为field2的输入域值为底数（6^</span><sup
                           class="dc_visible_expression_POW_table_sup">2</sup>=64</span>）</td>
                </tr>
                <tr>
                    <td>PRODUCT(V1,V2,V3...) </td>
                    <td>返回所有参数的乘积。 </td>
                    <td>示例：输入域数值表达式：PRODUCT([field1],[field2])--代表当前输入域值为输入域ID为field1、输入域ID为field2的乘积。（3*4=12）
                    </td>
                </tr>
                <tr>
                    <td>RADIANS(V) </td>
                    <td>将角度转换为弧度。 </td>
                    <td>RADIANS(V) </td>
                </tr>
                <tr>
                    <td>RAND()</td>
                    <td>返回一个介于0到1之间的随机数。</td>
                    <td>RAND()</td>
                </tr>
                <tr>
                    <td>ROUND(V)</td>
                    <td>进行四舍五入计算。 </td>
                    <td>示例：输入域数值表达式：ROUND([field1])--代表当前输入域值为输入域ID为field1进行四舍五入。（11.3=11）（11.5=12）
                    </td>
                </tr>
                <tr>
                    <td>ROUNDDOWN(V) </td>
                    <td>向下舍入数字。</td>
                    <td>示例：输入域数值表达式：ROUNDDOWN([field1])--代表当前输入域值为输入域ID为field1的值小数位去掉（11.3=11）（11.899=11）
                    </td>
                </tr>
                <tr>
                    <td>ROUNDUP(V) </td>
                    <td>向上舍入数字。</td>
                    <td>示例：输入域数值表达式：ROUNDDOWN([field1])--代表当前输入域值为输入域ID为field1的值小数位向上加一（11.011=12）（11.899=12）
                    </td>
                </tr>
                <tr>
                    <td>SIGN(V)</td>
                    <td>为正数返回1，为零返回0，为负数返回-1。</span> </td>
                    <td>示例：输入域数值表达式：ROUNDDOWN([field1])--代表当前输入域值为输入域ID为field1的值小数位向上加一（11.011=1）（0=0）(-12=-1)
                    </td>
                </tr>
                <tr>
                    <td>SIN(V)</td>
                    <td>返回指定角度的正弦值。 </td>
                    <td>SIN(V)</td>
                </tr>
                <tr>
                    <td>SQRT(V)</td>
                    <td>返回数值的平方根。 </td>
                    <td>示例：输入域数值表达式：ROUNDDOWN([field1])--代表当前输入域值为输入域ID为field1的平方根（</span><span dcopi="2"
                        class="dc_visible_expression_SQRT_table">√￣</span>4=2）
                    </td>
                </tr>
                <tr>
                    <td>SUM(V1,V2...) </td>
                    <td>返回所有参数的和。 </td>
                    <td>示例：输入域数值表达式：POW([field1],[field2])--代表当前输入域值为输入域ID为field1、ID为field2的输入域值之和（1+2=3）<br
                            dcpf="1" />单元格数值表达式：SUM([C1:C3])--代表单元格背景编号C1-C3值之和</td>
                </tr>
                <tr>
                    <td>TAN(V)</td>
                    <td>返回指定角度的正切值。 </td>
                    <td>TAN(V)</td>
                </tr>
                <tr>
                    <td>PARAMETER </td>
                    <td></td>
                    <td>PARAMETER </td>
                </tr>
                <tr>
                    <td>CINT</td>
                    <td>将数据转换为一个整数 </td>
                    <td>CINT</td>
                </tr>
                <tr>
                    <td>CDOUBLE</td>
                    <td>将数据转换为一个双精度浮点数</td>
                    <td>CDOUBLE</td>
                </tr>
                <tr>
                    <td>LEN</td>
                    <td></td>
                    <td>LEN</td>
                </tr>
                <tr>
                    <td>FIND</td>
                    <td>函数FIND和FINDB用于在第二个文本串中定位第一个文本串，并返回第一个文本串的</span>
                    </td>
                    <td>示例：输入域可见性表达式：FIND('男',[field1])&gt;=0--代表当前输入域值为多选下拉输入域ID为field1值包含男，该输入域就显示，否则隐藏。
                    </td>
                </tr>
                <tr>
                    <td>LOOKUP</td>
                    <td>进行数组比较，返回比较结果。</td>
                    <td>示例：输入域数值表达式：LOOKUP([field1],0,'不及格',60,'及格',70,'中',80,'良',90,'优')--代表当前输入域值为输入域ID为field1值所属某个区间的值（45=不及格）（81=良）
                    </td>
                </tr>
                <tr>
                    <td>IF</td>
                    <td>对一个参数值转换为布尔值，如果为true则返回第二个参数值，如果为false则返回第三个参数值。</td>
                    <td>示例：输入域可见性表达式：if([field1]='',true,false)--代表输入域ID为field1值为空时，当前输入域显示，不为空的时候，当前输入域隐藏。示例：输入域数值表达式if([field1]='',0,2)--代表当前输入域值为输入域ID为field1值为空时显示0，否则显示2
                    </td>
                </tr>
                <tr>
                    <td>AGE(V)</td>
                    <td>计算周岁年龄。参数为表示时间日期数值。</td>
                    <td>示例：输入域数值表达式AGE([field1])--代表当前输入域值为输入域id为field1日期值的周岁（20201122=3）
                    </td>
                </tr>
                <tr>
                    <td>AGEMONTH(V) </td>
                    <td>计算月龄。参数为表示时间日期的数值。</td>
                    <td>示例：输入域数值表达式AGEMONTH([field1])--代表当前输入域值为输入域id为field1日期值的月龄（2020-12-31=34）
                    </td>
                </tr>
                <tr>
                    <td>AGEWEEK(V) </td>
                    <td>计算周龄。参数为表示时间日期的数值。</td>
                    <td>示例：输入域数值表达式AGEWEEK([field1])--代表当前输入域值为输入域id为field1日期值的月龄（2020-11-01=157）
                    </td>
                </tr>
                <tr>
                    <td>AGEHOUR(V) </td>
                    <td>计算小时龄。参数为表示时间日期的数值。</td>
                    <td>示例：输入域数值表达式AGEHOUR([field1])--代表当前输入域值为输入域id为field1日期值的月龄（2020-11-30=25724）
                    </td>
                </tr>
                <tr>
                    <td>SUNINNERVALUE(V1,V2) </td>
                    <td>返回所有参数的INNERVALUE之和</td>
                    <td>示例：输入域数值表达式SUNINNERVALUE([aa])--代表当前输入域值为复选框组name值为aa的勾选之和。</td>
                </tr>
                <tr>
                    <td>性别-月经史级联</td>
                    <td></td>
                    <td>示例：输入域可见性表达式[field1]='男'--当输入域id为男的时候，该输入域显示，否则隐藏</td>
                </tr>
            </tbody>
        </table>
        </div>
        <div class="dc_visible_expression_table_footer">
                <span class="dc_visible_expression_table_close">关闭</span>
        </div>
        `;
        var dc_visible_expression_table = jQuery(ctl).find('#dc_visible_expression_table');
        //判断是否已经有表达式关于弹框
        if (dc_visible_expression_table.length === 0) {
            var visibleexpression = ctl.ownerDocument.createElement('div');
            visibleexpression.id = "dc_visible_expression_table";
            visibleexpression.innerHTML = visibleexpressionHtml;
            jQuery(ctl).append(visibleexpression);
            var expressionDom = jQuery(ctl).find('#dc_visible_expression_table')[0];
            expressionDom.addEventListener('click', function (e) {
                if (e && e.target) {
                    if (e.target.classList.contains('dc_visible_expression_table_close')) {
                        expressionDom.remove();
                    }
                }
            });
        }
    },

    /**
     * 设置form表单元素是否可用
     * @param formNode 表单元素
     * @param isDisable 是否可以使用，true表示不可用
     */
    changeFormDisable: function (formNode, isDisable) {
        if (!formNode || formNode.nodeName != "FORM") {
            return;
        }
        var els = formNode.elements;
        if (els && els.length > 0) {
            for (var i = 0; i < els.length; i++) {
                els[i].disabled = isDisable ? true : false;
            }
        }
    },

    /**
         * 删除表格行或者表格列的对话框
         * @param rootElement 编辑器对象
         * @param callBack 对话框处理完成的回调事件，用于处理防抖
         */
    DeleteRowOfColumnsDialog: function (rootElement, callBack) {
        //样式
        var queryDeleteRowOfColumnsStyle = rootElement.querySelector && rootElement.querySelector('#dc_query_delete_row_of_columns_mask_style') || null;
        if (!queryDeleteRowOfColumnsStyle) {
            queryDeleteRowOfColumnsStyle = rootElement.ownerDocument.createElement("style");
            queryDeleteRowOfColumnsStyle.id = 'dc_query_delete_row_of_columns_mask_style';
            queryDeleteRowOfColumnsStyle.innerHTML = `
                #dc_maskDiv{
                    width:100%;
                    height:100%;
                    background-color:#000000;
                    position:relative;
                    z-index:10000;
                    top:-100%;
                    opacity:0.2;
                }
                #dc_queryDeleteRowOfColumnsBox_Box{
                    width: 230px;
                    height: 150px;
                    position:absolute;
                    top: 50%;
                    left: 50%;
                    background-color: #fff;
                    border: 1px solid #ccc;
                    z-index: 10001;
                    margin-left: -120px;
                    margin-top: -100px;
                    display: flex;
                    flex-direction: column;
                }
                #dc_queryDeleteRowOfColumnsBox_Box .dc_queryDeleteRowOfColumnsBox_header{
                    padding: 6px 10px;
                    box-sizing: border-box;
                    background:linear-gradient(to bottom, #ffffff 0, #eeeeee 100%);
                    border-bottom: 1px solid #c6c6c6;
                    color:#0E2D5F;
                    font-size: 12px;
                    font-weight: bold;
                }
                #dc_queryDeleteRowOfColumnsBox_Box .dc_queryDeleteRowOfColumnsBox_Container{
                    padding: 10px;
                    box-sizing: border-box;
                    flex:1;
                    display: flex;
                    justify-content: space-evenly;
                    align-items: center;
                }
                #dc_queryDeleteRowOfColumnsBox_Box .dc_queryDeleteRowOfColumnsBox_footer{
                    padding: 6px 10px;
                    box-sizing: border-box;
                    background-color: #f5f5f5;
                    border-top: 1px solid #ccc;
                    display: flex;
                    justify-content: center;
                    align-items: center;
                }
                #dc_queryDeleteRowOfColumnsBox_Box .dc_queryDeleteRowOfColumnsBox_footer > div{
                    padding: 0 5px;
                    box-sizing: border-box;
                    font-size: 12px;
                    margin: 0 4px;
                    cursor: pointer;
                    background: linear-gradient(to bottom, #ffffff 0, #eeeeee 100%);
                    border: 1px solid #bbb;
                    color: #444;
                    border-radius: 3px;
                }
                #dc_queryDeleteRowOfColumnsBox_Box .dc_queryDeleteRowOfColumnsBox_footer > div:hover{
                    background-color: #ccc;
                }
            `;
            rootElement.appendChild(queryDeleteRowOfColumnsStyle);


            // 遮罩
            var maskDiv = rootElement.querySelector("#dc_maskDiv") || null;
            if (!maskDiv) {
                maskDiv = rootElement.ownerDocument.createElement("div");
                maskDiv.id = "dc_maskDiv";
                rootElement.appendChild(maskDiv);
            }

            //对话框内容
            var dialogContentDiv = rootElement.querySelector && rootElement.querySelector('#dc_queryDeleteRowOfColumnsBox_Box') || null;
            if (!dialogContentDiv) {
                dialogContentDiv = rootElement.ownerDocument.createElement("div");
                dialogContentDiv.id = "dc_queryDeleteRowOfColumnsBox_Box";
                dialogContentDiv.innerHTML = `
                <div class="dc_queryDeleteRowOfColumnsBox_header">请选择删除操作</div>
                <div class="dc_queryDeleteRowOfColumnsBox_Container">
                    <label>
                        <input type="radio" name="operation" value="deleteRow" checked> 删除表格行
                    </label>
                    <label>
                        <input type="radio" name="operation" value="deleteColumn"> 删除表格列
                    </label>
                </div>
                <div class="dc_queryDeleteRowOfColumnsBox_footer">
                    <div id="dc_queryDeleteRowOfColumnsBox_footer_cancelbtn">取消</div>
                    <div id="dc_queryDeleteRowOfColumnsBox_footer_confirmbtn">确认</div>
                </div>
            `;
                rootElement.appendChild(dialogContentDiv);
                // 取消按钮
                var cancelBtn = dialogContentDiv.querySelector && dialogContentDiv.querySelector("#dc_queryDeleteRowOfColumnsBox_footer_cancelbtn");
                cancelBtn.addEventListener("click", function () {
                    RemoveDeleteRowOfColumns();
                    rootElement.Focus();
                });
                // 确认按钮
                var confirmBtn = dialogContentDiv.querySelector && dialogContentDiv.querySelector("#dc_queryDeleteRowOfColumnsBox_footer_confirmbtn");
                confirmBtn.addEventListener("click", function () {
                    var queryDeleteRowOfColumnsMask = rootElement.querySelector && rootElement.querySelector("#dc_queryDeleteRowOfColumnsBox_Box") || null;
                    if (queryDeleteRowOfColumnsMask) {
                        let removeValue = queryDeleteRowOfColumnsMask.querySelector && queryDeleteRowOfColumnsMask.querySelector("input[name='operation']:checked").value || null;
                        if (removeValue) {
                            if (removeValue === 'deleteRow') {
                                rootElement.DCExecuteCommand("Table_DeleteRow", false, null);
                            } else if (removeValue === 'deleteColumn') {
                                rootElement.DCExecuteCommand("Table_DeleteColumn", false, null);
                            }
                        }

                        // 删除对话框
                        RemoveDeleteRowOfColumns();
                    }
                });

                function RemoveDeleteRowOfColumns() {
                    //移除遮罩层
                    var maskDiv = rootElement.querySelector && rootElement.querySelector("#dc_maskDiv") || null;
                    maskDiv && maskDiv.remove();

                    //移除对话框内容
                    var dialogContentDiv = rootElement.querySelector && rootElement.querySelector('#dc_queryDeleteRowOfColumnsBox_Box') || null;
                    dialogContentDiv && dialogContentDiv.remove();

                    //移除样式
                    var queryDeleteRowOfColumnsStyle = rootElement.querySelector && rootElement.querySelector('#dc_query_delete_row_of_columns_mask_style') || null;
                    queryDeleteRowOfColumnsStyle && queryDeleteRowOfColumnsStyle.remove();

                    //调用回调函数
                    callBack && callBack();

                }


            }
        }
    }
};

/**
 * 将原始日期字符串转换为Date对象
 * @param originalDate 输入域目前已知时间校验字符串的格式有："01/6/2024 10:56:00"、"2024/2/1 下午1:47:00"
 * @return convertedDate 转换后的时间字符串：'2024-01-06 10:56:00'
 * DUWRITER5_0-1886:20240201,lxy,增加一个种带有中文的校验格式："2024/2/1 下午1:47:00"
 */
var RangeDate = function (originalDate) {
    var isAdd12HoursFlag = false;
    if (originalDate.indexOf('上午') > -1) {
        originalDate = originalDate.replace("上午", "");
    } else if (originalDate.indexOf('下午') > -1) {
        isAdd12HoursFlag = true;
        originalDate = originalDate.replace("下午", "");
    }
    var dateObj = new Date(originalDate);

    // 获取年、月、日、小时、分钟和秒
    var year = dateObj.getFullYear();
    var month = ("0" + (dateObj.getMonth() + 1)).slice(-2);
    var day = ("0" + dateObj.getDate()).slice(-2);
    var hours = isAdd12HoursFlag ? ("0" + (dateObj.getHours() + 12)).slice(-2) : ("0" + dateObj.getHours()).slice(-2);
    var minutes = ("0" + dateObj.getMinutes()).slice(-2);
    var seconds = ("0" + dateObj.getSeconds()).slice(-2);

    // 判断是否需要进位
    if (hours == "24") {
        dateObj.setDate(dateObj.getDate() + 1);
        year = dateObj.getFullYear();
        month = ("0" + (dateObj.getMonth() + 1)).slice(-2);
        day = ("0" + dateObj.getDate()).slice(-2);
        hours = "00";
    }

    var convertedDate = year + "-" + month + "-" + day + " " + hours + ":" + minutes + ":" + seconds;

    return convertedDate;
};

/**
 * 将对象的所有键转换为小写
 * @param obj 需要处理的对象
 * @return obj 处理完成的对象
 */
var keysToLowerCase = function (obj) {
    var keys = Object.keys(obj);
    var n = keys.length;
    while (n--) {
        var key = keys[n]; // "cache" it, for less lookups to the array
        if (key !== key.toLowerCase()) {
            // might already be in its lower case version
            obj[key.toLowerCase()] = obj[key]; // swap the value to a new lower case key
            delete obj[key]; // delete the old key
        }
    }
    return obj;
};

/**
 * 获取或者添加最下面的数据
 * @param data 需要处理的对象
 * @param txt 键值对中的键，可以是"b.c",获取的是 data["b"]["c"]
 * @param value 键值对中的值，可以是"b.c",获取的是 data["b"]["c"]
 */
var getDown = function getDown(data, txt, value) {
    if (!data || typeof data != "object") {
        return;
    }
    if (value == undefined) {
        data = keysToLowerCase(JSON.parse(JSON.stringify(data)));
        txt = txt.toLowerCase();
    }
    var _index = txt.indexOf(".");
    if (_index > -1) {
        var objArr = [txt.slice(0, _index), txt.slice(_index + 1, txt.length)];
        if (!data[objArr[0]] && value != undefined) {
            data[objArr[0]] = {};
        }
        return getDown(data[objArr[0]], objArr[1], value);
    } else {
        if (value == undefined) {
            return data[txt];
        } else {
            data[txt] = value;
        }
    }
};

/**
 * 获取或者修改数据
 * @param dcPanelBody 获取元素的父元素JQUEY对象
 * @param data 需要修改的数据
 * @return obj 处理完成的对象
 */
var GetOrChangeData = function (dcPanelBody, data, specialTreatmentFunc) {
    if (!dcPanelBody) {
        return;
    }
    var isChange = typeof data == "object";
    var obj = {};
    dcPanelBody.find("[data-text]").each(function () {
        var _el = jQuery(this);
        var _txt = _el.attr("data-text");
        if (!!specialTreatmentFunc && typeof specialTreatmentFunc == "function") {
            if (specialTreatmentFunc.call(this, _txt, isChange) == false) {
                return true;
            }
        }
        if (this.type == "checkbox") {
            getDown(obj, _txt, _el.is(":checked"));
            if (isChange) {
                var isChecked = getDown(data, _txt);
                if (typeof isChecked == "boolean") {
                    _el.prop("checked", isChecked);
                    if (!!_el.change && typeof _el.change == "function") {
                        _el.change();
                    }
                }
            }
        } else if (this.type == "radio") {
            if (_el.is(":checked")) {
                getDown(obj, _txt, _el.val());
            }
            if (isChange && _el.val() == getDown(data, _txt)) {
                _el.prop("checked", true);
                if (!!_el.change && typeof _el.change == "function") {
                    _el.change();
                }
            }
        } else {
            // 获取或者接受的数据类型
            switch (_el.attr("data-type")) {
                case "Object":
                    //{}
                    break;
                case "Array":
                    //[{}]
                    var tbody = _el.find("tbody");
                    var trs = tbody.find("tr");
                    if (isChange) {
                        var item = _el.find("template.dc_template_item")[0].content;
                        var item_contents = getDown(data, _txt);
                        if (
                            Object.prototype.toString.call(item_contents) === "[object Array]"
                        ) {
                            // 数据是数组
                            trs.remove();
                            for (var i = 0; i < item_contents.length; i++) {
                                var item_obj = item_contents[i];
                                var clone_item = item.cloneNode(true);
                                var inputs = clone_item.querySelectorAll("[data-arraytext]");
                                for (var j = 0; j < inputs.length; j++) {
                                    var input = inputs[j];
                                    var _arraytext = input.getAttribute("data-arraytext");
                                    input.value = item_obj[_arraytext];
                                }
                                tbody.append(clone_item);
                            }
                            tbody.append(item.cloneNode(true));
                        }
                    } else {
                        var item_arr = [];
                        trs.each(function () {
                            var item_obj = {};
                            var isPush = false; //是否存储
                            jQuery(this)
                                .find("[data-arraytext]")
                                .each(function () {
                                    var _arraytext = jQuery(this).attr("data-arraytext");
                                    var _arrayvalue = jQuery(this).val();
                                    if (_arrayvalue) {
                                        // 当存在一个数据时就存储
                                        isPush = true;
                                    }
                                    item_obj[_arraytext] = _arrayvalue;
                                });
                            if (isPush) {
                                item_arr.push(item_obj);
                            }
                        });
                        getDown(obj, _txt, item_arr);
                    }
                    break;
                default:
                    // 如果元素是 div 且有 data-value 属性，则从 data-value 读取值
                    var _value;
                    if (this.nodeName === "DIV" && _el.attr("data-value") !== undefined) {
                        _value = _el.attr("data-value") || "";
                    } else {
                        _value = _el.val();
                    }
                    if (this.type == "number") {
                        _value -= 0;
                    }
                    getDown(obj, _txt, _value);
                    if (isChange) {
                        var _value = getDown(data, _txt);
                        if (this.type == "number") {
                            _value = parseFloat(_value);
                        }
                        if (this.nodeName == "SELECT" && _value == "") {
                            // 是下拉，并且值为空
                            return true;
                        }
                        // 如果元素是 div 且有 data-value 属性，则设置 data-value 和 backgroundColor
                        if (this.nodeName === "DIV" && _el.attr("data-value") !== undefined) {
                            if (_value && typeof _value == "object") {
                                _el.attr("data-value", JSON.stringify(_value));
                            } else {
                                _el.attr("data-value", _value || "");
                                // 如果是颜色值，同时设置背景色
                                if (_txt && (_txt.toLowerCase().indexOf("color") >= 0 || _txt.toLowerCase().indexOf("colour") >= 0)) {
                                    _el[0].style.backgroundColor = _value || "#000000";
                                }
                            }
                        } else {
                            if (_value && typeof _value == "object") {
                                _el.val(JSON.stringify(_value));
                            } else {
                                _el.val(_value);
                            }
                        }
                    }
                    break;
            }
        }
    });
    if (isChange) {
        return true;
    } else {
        return obj;
    }
};

/**
 * 为对话框添加颜色选择器
 * */
var DC_ColorPickerModule = (function () {
    // 解析RGBA字符串
    function parseRGBA(rgbaString) {
        var match = rgbaString.match(/rgba?\((\d+),\s*(\d+),\s*(\d+)(?:,\s*([\d.]+))?\)/);
        if (match) {
            return {
                r: parseInt(match[1]),
                g: parseInt(match[2]),
                b: parseInt(match[3]),
                a: match[4] ? parseFloat(match[4]) : 1
            };
        }
        return null;
    }

    // RGB转HEX
    function rgbToHex(r, g, b) {
        return "#" + ((1 << 24) + (r << 16) + (g << 8) + b).toString(16).slice(1).toUpperCase();
    }

    // 获取初始颜色
    function getInitialColor(triggerElement, defaultColor) {
        if (!triggerElement) return defaultColor;

        var bgColor = window.getComputedStyle(triggerElement).backgroundColor;
        if (bgColor) {
            var rgba = parseRGBA(bgColor);
            if (rgba) {
                return rgbToHex(rgba.r, rgba.g, rgba.b);
            }
        }
        return defaultColor;
    }

    // 显示颜色选择器
    function showColorPicker(options, callback) {
        options = options || {};
        var triggerElement = options.triggerElement || null;
        var defaultColor = options.defaultColor || '#409EFF';

        // 状态变量
        var currentColor = getInitialColor(triggerElement, defaultColor);
        var selectedSwatch = null;
        var overlay = null;
        var dialog = null;
        var colorInput = null;

        // 删除颜色选择器元素（通过ID删除）
        function removeColorPickerElements() {
            var oldOverlay = document.getElementById('dcColorPickerOverlayContainer20251113');
            var oldDialog = document.getElementById('dcColorPickerDialogContainer20251113');
            if (oldOverlay) oldOverlay.parentNode.removeChild(oldOverlay);
            if (oldDialog) oldDialog.parentNode.removeChild(oldDialog);
        }

        // 创建对话框
        function createDialog() {
            // 删除已存在的旧元素
            removeColorPickerElements();

            // 创建新的遮罩层
            overlay = document.createElement('div');
            overlay.className = 'dc-color-picker-overlay';
            overlay.id = 'dcColorPickerOverlayContainer20251113';

            // 创建新的对话框
            dialog = document.createElement('div');
            dialog.className = 'dc-color-picker-dialog';
            dialog.id = 'dcColorPickerDialogContainer20251113';

            dialog.innerHTML = `
                            <style>
                                .dc-color-picker-overlay {
                                    display: none;
                                    position: fixed;
                                    top: 0;
                                    left: 0;
                                    right: 0;
                                    bottom: 0;
                                    background-color: transparent;
                                    z-index: 99998;
                                }

                                .dc-color-picker-overlay.active {
                                    display: block;
                                }

                                .dc-color-picker-dialog {
                                    display: none;
                                    position: absolute;
                                    background-color: white;
                                    border-radius: 6px;
                                    box-shadow: 0 2px 12px rgba(0, 0, 0, 0.15);
                                    padding: 10px;
                                    z-index: 999999;
                                }

                                .dc-color-picker-dialog.active {
                                    display: block;
                                }

                                .dc-color-picker-header {
                                    display: flex;
                                    justify-content: space-between;
                                    align-items: center;
                                    margin-bottom: 8px;
                                    padding-bottom: 6px;
                                    border-bottom: 1px solid #e0e0e0;
                                }

                                .dc-color-preview-area {
                                    display: flex;
                                    align-items: center;
                                    gap: 8px;
                                    margin-bottom: 8px;
                                    padding: 8px;
                                    background-color: #f9f9f9;
                                    border-radius: 4px;
                                }

                                .dc-current-color-preview {
                                    width: 40px;
                                    height: 40px;
                                    border: 2px solid #ddd;
                                    border-radius: 4px;
                                    flex-shrink: 0;
                                    transition: border-color 0.2s;
                                }

                                .dc-current-color-info {
                                    flex: 1;
                                    display: flex;
                                    flex-direction: column;
                                    gap: 2px;
                                }

                                .dc-current-color-label {
                                    font-size: 10px;
                                    color: #999;
                                    text-align:left;
                                }

                                .dc-current-color-value {
                                    font-size: 13px;
                                    font-weight: bold;
                                    color: #333;
                                    font-family: 'Courier New', monospace;
                                    text-align:left;
                                }

                                .dc-color-picker-content {
                                    display: flex;
                                    gap: 10px;
                                    align-items: flex-start;
                                }

                                .dc-color-picker-left {
                                    flex: 1;
                                }

                                .dc-color-picker-right {
                                    width: 0;
                                    height: 0;
                                    position: absolute;
                                    right: 0;
                                    top: 96px;
                                }

                                .dc-color-picker-title {
                                    font-size: 12px;
                                    font-weight: bold;
                                    color: #333;
                                }

                                .dc-color-picker-close {
                                    background: none;
                                    border: none;
                                    font-size: 16px;
                                    cursor: pointer;
                                    color: #999;
                                    padding: 0px;
                                    width: 16px;
                                    height: 16px;
                                    line-height: 16px;
                                    text-align: center;
                                }

                                .dc-color-picker-close:hover {
                                    color: #333;
                                }

                                .dc-preset-colors-section {
                                    margin-bottom: 6px;
                                }

                                .dc-section-label {
                                    font-size: 11px;
                                    color: #666;
                                    margin-bottom: 4px;
                                    text-align:left;
                                }

                                .dc-preset-colors-grid {
                                    display: grid;
                                    grid-template-columns: repeat(10, 24px);
                                    gap: 3px;
                                    margin-bottom: 6px;
                                }

                                .dc-color-swatch {
                                    width: 20px;
                                    height: 20px;
                                    border: 2px solid #ddd;
                                    cursor: pointer;
                                    transition: transform 0.1s;
                                }

                                .dc-color-swatch:hover {
                                    transform: scale(1.15);
                                    box-shadow: 0 1px 3px rgba(0, 0, 0, 0.2);
                                }

                                .dc-color-swatch.dc-color-selected {
                                    border: 2px solid #409EFF;
                                    box-shadow: 0 0 0 1px rgba(64, 158, 255, 0.3);
                                }

                                .dc-standard-colors {
                                    display: grid;
                                    grid-template-columns: repeat(10, 24px);
                                    gap: 3px;
                                }

                                .dc-native-color-picker {
                                    width: 0;
                                    height: 0;
                                    border: 0;
                                    opacity: 0;
                                    border-radius: 4px;
                                    cursor: pointer;
                                    transition: border-color 0.2s;
                                }

                                .dc-native-color-picker:hover {
                                    border-color: #409EFF;
                                }

                                .dc-native-color-picker::-webkit-color-swatch-wrapper {
                                    padding: 2px;
                                }

                                .dc-native-color-picker::-webkit-color-swatch {
                                    border: none;
                                    border-radius: 3px;
                                }

                                .dc-native-color-picker::-moz-color-swatch {
                                    border: none;
                                    border-radius: 3px;
                                }

                                .dc-picker-actions {
                                    display: flex;
                                    justify-content: flex-end;
                                    gap: 6px;
                                    margin-top: 8px;
                                    padding-top: 8px;
                                    border-top: 1px solid #e0e0e0;
                                }

                                .dc-picker-btn {
                                    padding: 5px 12px;
                                    border: none;
                                    border-radius: 3px;
                                    cursor: pointer;
                                    font-size: 11px;
                                    transition: all 0.2s;
                                }

                                .dc-picker-btn-cancel {
                                    background-color: #f5f5f5;
                                    color: #666;
                                }

                                .dc-picker-btn-cancel:hover {
                                    background-color: #e8e8e8;
                                }

                                .dc-picker-btn-confirm {
                                    background-color: #409EFF;
                                    color: white;
                                }

                                .dc-picker-btn-confirm:hover {
                                    background-color: #66b1ff;
                                }
                                div#dc-more-colors-section {
                                    border: 1px solid #ccc;
                                    padding: 7px;
                                    text-align: center;
                                    font-size: 12px;
                                    cursor: pointer;
                                    font-weight: bold;
                                    margin-top: 10px;
                                    margin-bottom: 10px;
                                    background-color: #f5f5f5;
                                }
                    </style>
                        <div class="dc-color-picker-header">
                            <div class="dc-color-picker-title">选择颜色</div>
                            <button class="dc-color-picker-close">×</button>
                        </div>
                        
                        <div class="dc-color-preview-area">
                            <div class="dc-current-color-preview" data-color-preview style="background-color: ${currentColor};"></div>
                            <div class="dc-current-color-info">
                                <div class="dc-current-color-label">当前颜色</div>
                                <div class="dc-current-color-value" data-color-value>${currentColor}</div>
                            </div>
                        </div>
                        
                        <div class="dc-color-picker-content">
                            <div class="dc-color-picker-left">
                                <div class="dc-preset-colors-section">
                                    <div class="dc-section-label">主题颜色</div>
                                    <div class="dc-preset-colors-grid" data-preset-colors></div>
                                </div>
                                
                                <div class="dc-preset-colors-section">
                                    <div class="dc-section-label">标准色</div>
                                    <div class="dc-standard-colors" data-standard-colors></div>
                                </div>
                                <div class="dc-preset-colors-section" id="dc-more-colors-section">
                                    更多颜色
                                </div>
                            </div>
                            
                            <div class="dc-color-picker-right">
                                <input type="color" class="dc-native-color-picker" data-color-input value="${currentColor}">
                            </div>
                        </div>
                        
                        <div class="dc-picker-actions">
                            <button class="dc-picker-btn dc-picker-btn-cancel">取消</button>
                            <button class="dc-picker-btn dc-picker-btn-confirm">确定</button>
                        </div>
                     `;

            document.body.appendChild(overlay);
            document.body.appendChild(dialog);

            colorInput = dialog.querySelector('[data-color-input]');
            generatePresetColors();
            generateStandardColors();
        }

        // 生成预定义颜色
        function generatePresetColors() {
            var container = dialog.querySelector('[data-preset-colors]');
            var colors = [
                '#FFFFFF', '#010002', '#4B5265', '#3F71FC', '#3CA4F3', '#469959', '#D63733', '#E98209', '#EFC500', '#9631DD',
                '#F2F0F3', '#7F7D80', '#F5F3F6', '#E6EFFB', '#E4FAF8', '#EDF8F0', '#FCE7EC', '#FAF3EB', '#F8F9E0', '#FBEAFB',
                '#DAD8DB', '#5B595C', '#CAC7CF', '#CADBFD', '#D0EDFF', '#CBE5D4', '#F9C9C9', '#F9DCC3', '#FFEFA9', '#EDC9FD',
                '#BFBDC0', '#3F3D40', '#86889E', '#A0BEFC', '#A5DCFE', '#A2D6B4', '#F6979A', '#F6B785', '#FCE261', '#CD8EFF',
                '#A5A3A6', '#272527', '#262427', '#2253BA', '#2D74A0', '#337C4F', '#941D15', '#AE6203', '#998208', '#54288F',
                '#959396', '#09070A', '#212024', '#182F76', '#18405B', '#27472F', '#4C110B', '#5B2D0C', '#5C5006', '#371347'
            ];

            var html = '';
            for (var i = 0; i < colors.length; i++) {
                html += '<div class="dc-color-swatch" style="background-color: ' + colors[i] + '" data-color="' + colors[i] + '"></div>';
            }
            container.innerHTML = html;
        }

        // 生成标准色
        function generateStandardColors() {
            var container = dialog.querySelector('[data-standard-colors]');
            var colors = [
                "#af0308", "#f10300", "#f7c003", "#fffb00", "#9cd04a",
                "#37b246", "#39b1f7", "#2372b6", "#0d1d63", "#6a319b"
            ];

            var html = '';
            for (var i = 0; i < colors.length; i++) {
                html += '<div class="dc-color-swatch" style="background-color: ' + colors[i] + '" data-color="' + colors[i] + '"></div>';
            }
            container.innerHTML = html;
        }

        // 选择颜色
        function selectColor(color, swatchElement) {
            currentColor = color;

            if (selectedSwatch) {
                selectedSwatch.classList.remove('dc-color-selected');
            }

            if (swatchElement) {
                swatchElement.classList.add('dc-color-selected');
                selectedSwatch = swatchElement;
            }

            updatePreview();

            if (colorInput) {
                colorInput.value = color;
            }
        }

        // 更新预览区域
        function updatePreview() {
            var previewBox = dialog.querySelector('[data-color-preview]');
            var valueDisplay = dialog.querySelector('[data-color-value]');

            if (previewBox) {
                previewBox.style.backgroundColor = currentColor;
            }

            if (valueDisplay) {
                valueDisplay.textContent = currentColor;
            }
        }

        // 调整位置
        function adjustPosition() {
            if (!triggerElement) return;

            var rect = triggerElement.getBoundingClientRect();
            var dialogRect = dialog.getBoundingClientRect();
            var dialogWidth = dialogRect.width;
            var dialogHeight = dialogRect.height;

            var left = rect.right + 10;
            var top = rect.top;

            if (left + dialogWidth > window.innerWidth - 10) {
                left = rect.left - dialogWidth - 10;
            }

            if (left < 10) {
                left = Math.max(10, rect.left);
                top = rect.bottom + 10;
            }

            if (left + dialogWidth > window.innerWidth - 10) {
                left = window.innerWidth - dialogWidth - 10;
            }

            if (left < 10) {
                left = 10;
            }

            if (top < 10) {
                top = 10;
            }

            if (top + dialogHeight > window.innerHeight - 10) {
                top = Math.max(10, window.innerHeight - dialogHeight - 10);
            }

            dialog.style.left = left + 'px';
            dialog.style.top = top + 'px';
        }

        // 确认
        function confirm() {
            if (callback) {
                callback(currentColor);
            }
            destroy();
        }

        // 取消
        function cancel() {
            destroy();
        }

        // 销毁
        function destroy() {
            if (overlay) overlay.classList.remove('active');
            if (dialog) dialog.classList.remove('active');

            setTimeout(function () {
                removeColorPickerElements();
            }, 50);
        }

        // 绑定事件
        function bindEvents() {
            overlay.onclick = function () {
                cancel();
            };

            // 阻止对话框内的点击事件冒泡到 overlay
            dialog.onclick = function (e) {
                e.stopPropagation();

                // 使用事件委托处理色块点击
                var target = e.target;
                if (target.classList.contains('dc-color-swatch')) {
                    var color = target.getAttribute('data-color');
                    if (color) {
                        selectColor(color, target);
                    }
                }
            };

            var closeBtn = dialog.querySelector('.dc-color-picker-close');
            closeBtn.onclick = function () {
                cancel();
            };

            var cancelBtn = dialog.querySelector('.dc-picker-btn-cancel');
            cancelBtn.onclick = function () {
                cancel();
            };

            var confirmBtn = dialog.querySelector('.dc-picker-btn-confirm');
            confirmBtn.onclick = function () {
                confirm();
            };

            var moreColorsBtn = dialog.querySelector('#dc-more-colors-section');
            if (moreColorsBtn) {
                moreColorsBtn.onclick = function () {
                    colorInput.click();
                };
            }

            colorInput.oninput = function (e) {
                currentColor = e.target.value.toUpperCase();
                updatePreview();

                if (selectedSwatch) {
                    selectedSwatch.classList.remove('dc-color-selected');
                    selectedSwatch = null;
                }
            };
        }

        // 初始化
        createDialog();
        bindEvents();
        overlay.classList.add('active');
        dialog.classList.add('active');
        adjustPosition();
    }

    // 导出公共API
    return {
        /**
         * 显示颜色选择器
         * @param {Object} options - 配置选项
         * @param {HTMLElement} options.triggerElement - 触发元素
         * @param {string} options.defaultColor - 默认颜色
         * @param {Function} callback - 回调函数，参数为选中的颜色值
         */
        show: function (options, callback) {
            showColorPicker(options, callback);
        }
    };
})();
