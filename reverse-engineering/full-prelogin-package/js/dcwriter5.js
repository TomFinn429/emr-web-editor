//
// 2026-3-27   202603271430-20260318分支
// 第五代WEB编辑器启动脚本
// 南京都昌信息科技有限公司
// 当配合5代文件发布器 DCWriter5FileDownload 时，对本文件作出任何改变，导致文件修改时间发生改变时，
// 浏览器都会自动重新下载所有程序文件（WSAM/DLL/GZ）等，而无需清空浏览器的缓存。
//
"use strict";
(async function () {
    if (window.__DCWriter5Started == true) {
        // 避免重复调用
        return;
    }
    let allFileContents = window.__DCAllFileContents;
    window.__DCAllFileContents = null;
    //在此处创建CreateTemperatureControlForWASM方法
    window.CreateTemperatureControlForWASM = function (rootElement) {
        if (typeof rootElement == "string") {
            rootElement = document.getElementById(rootElement);
        }
        if (!rootElement) {
            return "未找到正确的时间轴元素";
        }
        //在内部判断是否
        if (window.StartGlobal) {
            CreateWriterControlForWASM(rootElement, "TemperatureControl");
        } else {
            rootElement.LoadStartGlobal = function (rootElement) {
                CreateWriterControlForWASM(rootElement, "TemperatureControl");
            };
        }
    };
    // 在此处创建产程图CreateFlowControlForWASM方法;
    window.CreateFlowControlForWASM = function (rootElement) {
        if (typeof rootElement == "string") {
            rootElement = document.getElementById(rootElement);
        }
        if (!rootElement) {
            return "未找到正确的产程图元素";
        }
        //在内部判断是否
        if (window.StartGlobal) {
            CreateWriterControlForWASM(rootElement, "DCFlowControlForWASM");
        } else {
            rootElement.LoadStartGlobal = function (rootElement) {
                CreateWriterControlForWASM(rootElement, "DCFlowControlForWASM");
            };
        }
    };
    window.__DCWriter5Started = true;
    window.__DCWriter5FullLoaded = false;
    const strAppVersion = "20260327143150_409";
    window.strAppVersion = strAppVersion;
    // 获得资源基础路径
    let strBasePath = "_framework/";
    let bolDebugMode = false;
    let strServicePageUrl = null;
    let requestDLLUsingBase64 = false;
    // 是否将文本输出到控制台
    let enableConsoleOutput = false;
    // 是否在IFrame模式下运行
    let bolIFrameMode = false;
    // 允许在外部通过 window._DCWriter5EnableConsoleOutput 预先设置

    function convertToBoolean(strValue, defaultValue) {
        if (strValue == null || strValue.length === 0) return defaultValue;
        const val = String(strValue).trim().toLowerCase();
        if (val === "true") return true;
        if (val === "false") return false;
        return defaultValue;
    }

    try {
        if (typeof window !== "undefined" && typeof window._DCWriter5EnableConsoleOutput !== "undefined") {
            const flag = window._DCWriter5EnableConsoleOutput;
            enableConsoleOutput = typeof flag === "boolean" ? flag : convertToBoolean(flag, false);
        }
    } catch (ex) { }

    if (document.currentScript) {
        bolDebugMode = convertToBoolean(document.currentScript.getAttribute("debugmode"), false);
        bolIFrameMode = convertToBoolean(document.currentScript.getAttribute("iframemode"), false);
        strBasePath = document.currentScript.getAttribute("src") || strBasePath;
        strServicePageUrl = document.currentScript.getAttribute("servicepageurl") || strServicePageUrl;
    }
    // 试图设置编辑器程序文件下载基础路径
    if (!strBasePath && window._DCWriter5SpecifyBasePath) {
        strBasePath = window._DCWriter5SpecifyBasePath;
    }
    // 试图设置服务器页面地址路径
    if (!strServicePageUrl && window._DCWriter5SpecifyServicePageUrl) {
        strServicePageUrl = window._DCWriter5SpecifyServicePageUrl;
    }
    /**
     * 获取原始 window 对象（兼容 micro-app / Qiankun 等微前端沙箱）
     * @returns {Window} 原始 window 对象
     */
    function getWindow() {
        var w = window;
        if (w.rawWindow) return w.rawWindow;
        if (w.__MICRO_APP_ENVIRONMENT__ && w.__MICRO_APP_BASE_APPLICATION__) {
            if (w.__MICRO_APP_PROXY__) return w.__MICRO_APP_PROXY__;
            if (w.__MICRO_APP_ORIGINAL_WINDOW__) return w.__MICRO_APP_ORIGINAL_WINDOW__;
        }
        if (w.__POWERED_BY_QIANKUN__) {
            if (w.__QIANKUN_ORIGINAL_WINDOW__) return w.__QIANKUN_ORIGINAL_WINDOW__;
            try {
                if (document.defaultView && document.defaultView !== w) return document.defaultView;
            } catch (e) { }
        }
        return w;
    }
    // 统一日志封装
    function emit(method, args) {
        try {
            if (method === "error" || method === "warn" || DCWriterConsole.enableConsoleOutput === true) {
                if (typeof console !== "undefined" && typeof console[method] === "function") {
                    console[method].apply(console, Array.prototype.slice.call(args));
                }
            }
        } catch (e) { }
    }
    /**
     * DCWriter控制台日志对象
     * 提供统一的日志输出接口，error和warn始终输出，其他日志需要enableConsoleOutput为true
     */
    const DCWriterConsole = {
        enableConsoleOutput: enableConsoleOutput,
        log: function () { emit("log", arguments); },
        info: function () { emit("info", arguments); },
        warn: function () { emit("warn", arguments); },
        error: function () { emit("error", arguments); },
        debug: function () { emit("debug", arguments); }
    };
    // 导出DCWriterConsole对象到全局window对象
    const win = getWindow() || window;
    win.DCWriterConsole = DCWriterConsole;
    const PARAM_BASE64 = "&dcloaddllusingbase64=1";
    if (strBasePath && strBasePath.length > 0) {
        if (strBasePath.includes(PARAM_BASE64)) {
            strBasePath = strBasePath.replace(PARAM_BASE64, "");
            requestDLLUsingBase64 = true;
        }
        const qIndex = strBasePath.lastIndexOf("?");
        if (qIndex > 0) {
            strServicePageUrl = strBasePath.substring(0, qIndex).trim();
        } else {
            const sepIndex = Math.max(strBasePath.lastIndexOf("/"), strBasePath.lastIndexOf("\\"));
            strBasePath = sepIndex < 0 ? "./" : strBasePath.substring(0, sepIndex + 1);
        }
        strBasePath = strBasePath.trim();
        if (strBasePath.startsWith("./")) {
            strBasePath = strBasePath.slice(2);
        }
    } else {
        strBasePath = "_framework/";
    }
    window.strBasePath = strServicePageUrl;
    if (strServicePageUrl && strServicePageUrl.length > 0) {
        const index5 = strServicePageUrl.indexOf("?");
        if (index5 > 0) {
            strServicePageUrl = strServicePageUrl.substring(0, index5);
        }
    }
    if (strServicePageUrl != null && strServicePageUrl.length > 0) {
        DCWriterConsole.info("DCWriter5全局服务器页面地址:" + strServicePageUrl);
        window.__DCWriterServicePageUrl = strServicePageUrl;
    } else {
        DCWriterConsole.info("DCWriter5基础路径:" + strBasePath);
    }
    if (bolIFrameMode == true) {
        // 运行在IFrame模式下
        if (window.top.__DCWriter5SrcWindow20250912 == null
            || window.top.__DCWriter5SrcWindow20250912.SrcWindow == window) {
            // 还没有初始化
            window.top.__DCWriter5SrcWindow20250912 = new Object();
        }
        else {
            DCWriterConsole.warn("DCWriter5运行在iframe模式，这种模式容易出错，不推荐。");
            const pkg = window.top.__DCWriter5SrcWindow20250912;
            window.WriterControl_Main = pkg.WriterControl_Main;
            window.WriterControl_Paint = pkg.WriterControl_Paint;
            window.WriterControl_UI = pkg.WriterControl_UI;
            window.WriterControl_Task = pkg.WriterControl_Task;
            window.WriterControl_Rule = pkg.WriterControl_Rule;
            window.WriterControl_Event = pkg.WriterControl_Event;
            window.DCTools20221228 = pkg.DCTools20221228;
            window.WriterControl_Dialog = pkg.WriterControl_Dialog;
            window.WriterControl_DOMPackage = pkg.WriterControl_DOMPackage;
            window.CreateWriterControlForWASM = pkg.WriterControl_Main.CreateWriterControlForWASM;
            //window.CreateTemperatureControlForWASM = WriterControl_Main.CreateWriterControlForWASM;
            window.WriterControl_EF = pkg.WriterControl_EF;
            window.DisposeDCWriterDocument = pkg.WriterControl_API.DisposeDCWriterDocument;
            window.DotNet = pkg.DotNet;
            // 入口点程序集名称
            window.DCWriterEntryPointAssemblyName = pkg.DCWriterEntryPointAssemblyName;
            window.DCWriterStaticInvokeMethod = pkg.DCWriterStaticInvokeMethod;
            window.__DCWriter5FullLoaded = true;
            return;
        }
    }
    let strResourceBasePath = strBasePath;
    let strSrcBW;
    if (strServicePageUrl && strServicePageUrl.length > 0) {
        const strFlag = strServicePageUrl + "@" + window.location.origin;
        let totalValue = 0;
        for (let i = 0; i < strFlag.length; i++) {
            const c = strFlag.charCodeAt(i);
            totalValue += c;
            if ((i & 1) === 0) totalValue += c;
            if (i > 0 && (i & 1) === 1) totalValue += c * strFlag.charCodeAt(i - 1);
        }
        strResourceBasePath = strServicePageUrl + "?wasmres={0}&ver=" + strAppVersion +
            "&flag=" + totalValue + "&wasmrootpath=" + encodeURIComponent(strServicePageUrl);
        strSrcBW = strResourceBasePath.replace("{0}", "blazor.webassembly.js");
    } else {
        strSrcBW = strResourceBasePath + "blazor.webassembly.js";
    }

    strSrcBW = new URL(strSrcBW, document.baseURI).href;
    const jsScript = document.createElement("script");
    jsScript.setAttribute("language", "javascript");
    jsScript.src = strSrcBW;

    if (window.__DCResourceBasePath == null) {
        window.__DCResourceBasePath = strResourceBasePath;
    }

    let strEnvironment = strResourceBasePath;
    // 在此处判断是否为chrome 71一下的版本
    const ua = navigator.userAgent.toLowerCase();
    if (ua.indexOf("chrome") > -1) {
        const match = ua.match(/chrome\/([\d.]+)/);
        if (match && parseInt(match[1]) < 71) {
            window.globalThis = typeof self !== "undefined" ? self :
                typeof window !== "undefined" ? window :
                    typeof global !== "undefined" ? global : null;
            if (!window.globalThis) {
                throw new Error("unable to locate global object");
            }
        }
    }

    const ENVIRONMENT_IS_NODE = typeof process === "object" &&
        typeof process.versions === "object" &&
        typeof process.versions.node === "string";
    if (ENVIRONMENT_IS_NODE) {
        globalThis.__process = globalThis.process;
        delete globalThis.process;
    }
    function getBrowserInfo() {
        const ua = navigator.userAgent;
        let name = "Unknown", version = "Unknown";
        const matchVersion = function (re) {
            var m = ua.match(re);
            return (m && m[1] != null) ? m[1] : "Unknown";
        };
        // 检测顺序：Edge > Chrome > Firefox > Safari > IE
        if (ua.includes("Edg/")) {
            name = "Microsoft Edge (Chromium)";
            version = matchVersion(/Edg\/([\d.]+)/);
        } else if (ua.includes("Chrome")) {
            name = "Google Chrome";
            version = matchVersion(/Chrome\/([\d.]+)/);
        } else if (ua.includes("Firefox")) {
            name = "Mozilla Firefox";
            version = matchVersion(/Firefox\/([\d.]+)/);
        } else if (ua.includes("Safari") && ua.includes("Version/")) {
            name = "Apple Safari";
            version = matchVersion(/Version\/([\d.]+)/);
        } else if (ua.includes("MSIE") || ua.includes("Trident/")) {
            name = "Internet Explorer";
            const msie = matchVersion(/MSIE (\d+)/);
            version = msie !== "Unknown" ? msie : matchVersion(/rv:(\d+)/);
        }
        return { name, version };
    }
    /**
     * 检查浏览器的最低版本号，如果条件不足则显示提示信息并抛出异常
     * @param {number} runtimeVersion 运行时的版本号，可以为7、8、9
     */
    function checkBrowserMinVersion(runtimeVersion) {
        // 此处检查浏览器的版本号是否满足最低条件
        // 需要检查谷歌浏览器、火狐浏览器和苹果浏览器
        // 还可能需要测试操作系统的一些条件。
        // 判断条件源自测试组的测试结果。
        if (typeof runtimeVersion !== "number") return;
        const browserInfo = getBrowserInfo();
        DCWriterConsole.log("浏览器版本:", browserInfo);
        // !!! 如果条件不足则显示提示信息并抛出异常!!!
    }
    let mapBase64BlobUrl = null;

    /**
     * 兼容性 Gzip 解压：优先 DecompressionStream（Chrome 80+），降级为 pako/fflate（Chrome 70+）
     * @param {Uint8Array} input - Gzip 压缩数据
     * @returns {Promise<Uint8Array>} 解压后的数据
     */
    async function decompressGzip(input) {
        const inputArray = input instanceof Uint8Array ? input : new Uint8Array(input);
        if (typeof DecompressionStream !== "undefined" && typeof Blob !== "undefined" && typeof Blob.prototype.stream === "function") {
            try {
                const sourceStream = new Blob([inputArray]).stream();
                const ds = new DecompressionStream("gzip");
                const decompressedStream = sourceStream.pipeThrough(ds);
                const blob = await new Response(decompressedStream).blob();
                const buf = await blob.arrayBuffer();
                return new Uint8Array(buf);
            } catch (e) {
                console.warn("DecompressionStream 失败，尝试 pako 降级:", e);
            }
        }
        // Gzip 格式必须用 ungzip，inflate 仅用于 raw deflate，用错会导致“incorrect header check”或刷新后二次启动失败
        if (typeof window.pako !== "undefined") {
            const pakoFn = window.pako.ungzip || window.pako.gunzip || window.pako.inflate;
            if (pakoFn) {
                try {
                    return pakoFn.call(window.pako, inputArray);
                } catch (e) {
                    console.warn("pako 解压失败:", e);
                }
            }
        }
        if (typeof fflate !== "undefined" && fflate.gunzip) {
            return new Promise(function (resolve, reject) {
                try {
                    fflate.gunzip(inputArray, function (err, data) {
                        if (err) reject(err);
                        else resolve(new Uint8Array(data));
                    });
                } catch (e) {
                    reject(e);
                }
            });
        }
        throw new Error("当前浏览器不支持 Gzip 解压。Chrome 70 请先引入 pako 库或者fflate库，例如: pako.min.js或者pako_inflate.min.js或fflate.min.js");
    }

    if (allFileContents != null) {
        function getContentType(name) {
            if (name.endsWith('.wasm')) return 'application/wasm';
            if (name.endsWith('.dll')) return 'application/octet-stream';
            if (name.endsWith('.json')) return 'application/json';
            if (name.endsWith('.js')) return 'application/javascript';
            return 'application/octet-stream';
        }
        async function base64ToBlobUrl(strBase64String, strFileName) {
            try {
                const binaryStr = atob(strBase64String);
                const gzipData = new Uint8Array(binaryStr.length);
                for (let i = 0; i < binaryStr.length; i++) {
                    gzipData[i] = binaryStr.charCodeAt(i);
                }
                const decompressedData = await decompressGzip(gzipData);
                const mimeType = getContentType(strFileName);
                return URL.createObjectURL(new Blob([decompressedData], { type: mimeType }));
            } catch (error) {
                console.error("Base64/Gzip 转换失败:", error);
                throw error;
            }
        }
        // 加载资源
        for (const key in allFileContents) {
            const blobUrl = await base64ToBlobUrl(allFileContents[key], key);
            if (blobUrl && blobUrl.length > 0) {
                if (!mapBase64BlobUrl) mapBase64BlobUrl = {};
                mapBase64BlobUrl[key] = blobUrl;
                if (key === "Merge.js") {
                    strEnvironment = blobUrl;
                } else if (key === "blazor.webassembly.js") {
                    jsScript.src = blobUrl;
                }
            }
        }
    }
    allFileContents = null;
    jsScript.setAttribute("autostart", "false");
    jsScript.onload = function () {
        checkBrowserMinVersion(window.__DCRuntimeVersion);
        Blazor.start({
            environment: strEnvironment,
            //configureRuntime: dotnet => { dotnet.withRuntimeOptions(["--memory-profiler"]); dotnet.withDebugging(true); },
            loadBootResource: function (type, name, defaultUri, integrity) {
                if (name === "blazor.boot.json") {
                    //对微前端框架MicroApp的支持
                    if (window.__MICRO_APP_WINDOW__) {
                        window.__MICRO_APP_WINDOW__.document.defaultView.Blazor = window.Blazor;
                        window.__MICRO_APP_WINDOW__.document.defaultView.DotNet = window.DotNet;
                        if (window.rawWindow) {
                            window.rawWindow.Blazor = window.Blazor;
                            window.rawWindow.DotNet = window.DotNet;
                        }
                    }
                }
                //对微前端框架QianKun的支持
                if (window.__POWERED_BY_QIANKUN__) {
                    window.document.defaultView.Blazor = window.Blazor;
                    window.document.defaultView.DotNet = window.DotNet;
                }
                if (mapBase64BlobUrl != null) {
                    // 启用本地Base64资源
                    const localUrl = mapBase64BlobUrl[name];
                    if (localUrl && localUrl.length > 0) {
                        if (bolDebugMode === true) {
                            console.log("DCWriter5加载资源:" + name + "=>" + localUrl);
                        }
                        return localUrl;
                    }
                }
                const runtimeUrl = strResourceBasePath.indexOf("{0}") > 0
                    ? strResourceBasePath.replace("{0}", name)
                    : strResourceBasePath + name;
                if (bolDebugMode) {
                    DCWriterConsole.log("DCWriter5加载资源:" + runtimeUrl);
                }
                if (type !== "dotnetjs" && name !== "blazor.boot.json" && strServicePageUrl && strServicePageUrl.length > 0) {
                    // 如果遇到使用服务器页面的情况，则允许启用本地缓存
                    //wyc20240828:隐藏wasmres远程请求的url信息DUWRITER5_0-3459
                    let finalUrl = runtimeUrl;
                    if (requestDLLUsingBase64) {
                        const parts = runtimeUrl.split("?");
                        finalUrl = parts[0] + "?wasmres=" + window.btoa(parts[1]);
                    }
                    const promise = fetch(finalUrl, {
                        method: "GET",
                        credentials: "include",
                        cache: "default"
                    });
                    if (promise && promise.constructor && promise.constructor.name === "Promise") {
                        return promise;
                    }
                    return runtimeUrl;
                }
                return new URL(runtimeUrl, document.baseURI).href;
            }
        }).then(function () {
            // 延迟 revoke，避免 Blazor 懒加载资源时 Blob URL 已失效导致刷新后二次启动报错
            if (mapBase64BlobUrl) {
                setTimeout(function () {
                    for (const key in mapBase64BlobUrl) {
                        try { URL.revokeObjectURL(mapBase64BlobUrl[key]); } catch (e) { }
                    }
                    mapBase64BlobUrl = null;
                }, 30000);
            }
            // 修复nw.js和WASM的冲突，在Blazor启动后将全局变量process更改回来
            if (ENVIRONMENT_IS_NODE) {
                globalThis.process = globalThis.__process;
                delete globalThis.__process;
            }
        });
    };
    document.head.appendChild(jsScript);
})();
