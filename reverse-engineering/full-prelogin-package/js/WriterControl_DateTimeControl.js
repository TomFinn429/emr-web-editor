"use strict";
//import { es6laydate as laydate } from './js/laydate.js'

export let WriterControl_DateTimeControl = {
    //创建时间选择界面
    CreateDateTimeControl: function (divContainer, dtmInputValue, rootElement, intStyle, callBack) {
        if (dtmInputValue == null) {
            dtmInputValue = new Date();
        }
        if (intStyle != 5) {
            //替换文本
            dtmInputValue = new Date(dtmInputValue);
            const year = dtmInputValue.getFullYear();
            const month = dtmInputValue.getMonth() + 1; // 由于月份从0开始，因此需加1
            const day = dtmInputValue.getDate();
            const hour = dtmInputValue.getHours();
            const minute = dtmInputValue.getMinutes();
            const second = dtmInputValue.getSeconds();
            function pad(timeEl, total = 2, str = '0') {
                return timeEl.toString().padStart(total, str);
            }
            dtmInputValue = `${pad(year, 4)}-${pad(month)}-${pad(day)} ${pad(hour)}:${pad(minute)}:${pad(second)}`;
        }
        WriterControl_DateTimeControl.rootElement = rootElement;
        //对divContainer添加一个隐藏的输入域
        var hiddenInput = rootElement.ownerDocument.createElement('input');
        hiddenInput.style.cssText = 'padding:0px;height:0px;border:0px;vertical-align: top;';
        hiddenInput.setAttribute('readonly', true);
        hiddenInput.id = 'DCDateTime_calendar';
        hiddenInput.value = dtmInputValue;
        divContainer.appendChild(hiddenInput);
        //判断参数
        var dateType = 'datetime';
        var dateFormat = 'Y-m-d H:i:s';
        switch (intStyle) {
            case 2:
                dateType = 'date';
                dateFormat = 'Y-m-d';
                break;
            case 3:
                dateType = 'datetime';
                dateFormat = 'Y-m-d H:i:s';
                break;
            case 4:
                dateType = 'datetime';
                dateFormat = 'Y-m-d H:i';
                break;
            case 5:
                dateType = 'time';
                dateFormat = 'H:i:s';
                break;
            default:
                var dateType = 'datetime';
                dateFormat = 'Y-m-d H:i:s';
                break;
        }
        var startDate = new Date().getFullYear() - 100;
        var isMinDateTodayForDateFieldElement = false;
        //获取当前元素中的自定义属性isMinDateTodayForDateFieldElement="true"
        var currentElement = rootElement.GetElementProperties(rootElement.CurrentElement());
        if (currentElement && currentElement.Attributes && currentElement.Attributes.isMinDateTodayForDateFieldElement) {
            isMinDateTodayForDateFieldElement = currentElement.Attributes.isMinDateTodayForDateFieldElement;
        }
        isMinDateTodayForDateFieldElement = (isMinDateTodayForDateFieldElement === "true" || isMinDateTodayForDateFieldElement === true);
        if (isMinDateTodayForDateFieldElement && (dateType === 'date' || dateType === 'datetime')) {
            //当天日期作为最小日期，禁用今天之前的日期
            var today = new Date();
            today.setHours(0, 0, 0, 0);
            var year = today.getFullYear();
            var month = String(today.getMonth() + 1).padStart(2, '0');
            var day = String(today.getDate()).padStart(2, '0');
            startDate = year + '-' + month + '-' + day;
        }

        var thisApi = WriterControl_DateTimeControl.rootElement.ownerDocument.cxCalendar.attach(hiddenInput, {
            startDate,
            endDate: new Date().getFullYear() + 100
        });
        thisApi.setOptions({
            type: dateType,
            //format: 'Y-m-d H:i:s'
            format: dateFormat,
            lockRow: true
            //baseClass: 'not_secs',
        });
        if (dateFormat.indexOf('s') < 0) {
            thisApi.setOptions({
                baseClass: 'dc_not_secs',
            });
        }
        hiddenInput.addEventListener('change', function (e) {
            callBack && callBack(e.target.value);
            callBack = null;
        });
        thisApi.show(rootElement);
        divContainer.thisApi = thisApi;
        //var hasScale = window.getComputedStyle(divContainer, null).getPropertyValue("transform").slice(7, 'matrix(0.826923, 0, 0, 0.826923, 0, 0)'.length - 1).split(', ')[0]
        //if (hasScale && hasScale != '0') {
        //    thisApi.dom.panel.style.transform = "scale(" + hasScale + ")";
        //    thisApi.dom.panel.style.top = thisApi.dom.panel.offsetTop - (((1 - hasScale) * 0.5) * thisApi.dom.panel.offsetHeight) + 'px';
        //    thisApi.dom.panel.style.left = thisApi.dom.panel.offsetLeft - (((1 - hasScale) * 0.5) * thisApi.dom.panel.offsetWidth)  + 'px';
        //}
    },

    CreateCalendarCss: function (rootElement) {
        var calendarCssString = `/*!
        * cxCalendar
        * ------------------------------ */
       /* 火狐浏览器兼容样式 */
        @-moz-document url-prefix() {
            .dc_cxcalendar {
               //width:254px !important;
            }
            .dc_cxcalendar_hd .times input{
                padding: 0 !important;
            }
        }
        .dc_cxcalendar {
        --cxcalendar-bg: #fff;
        --cxcalendar-border: #e4e4e4;
        --cxcalendar-item-bg: #e4e4e4;
        --cxcalendar-text-color: #333;
        --cxcalendar-days-color: #666;
        --cxcalendar-sat-color: #4a89dc;
        --cxcalendar-sun-color: #da4453;
        --cxcalendar-other-color: #ccc;
        --cxcalendar-note-color: #aaa;
        --cxcalendar-now-bg: #f3f3f3;
        --cxcalendar-set-bg: #70a9ce;
        --cxcalendar-range-bg: #dceffc;
        --cxcalendar-range-set-bg: #70a9ce;
        --cxcalendar-btn-color: #fff;
        --cxcalendar-btn-bg: #666;
        --cxcalendar-confirm-bg: #4a89dc;
        --cxcalendar-gap-out: 4px;
        --cxcalendar-text-size: 14px;
        --cxcalendar-title-size: 16px;
        --cxcalendar-unit-size: 10px;
        --cxcalendar-btn-size: 12px;
        position: absolute;
        z-index: 10000;
        top: -999px;
        left: -999px;
        width: 370px;
        border: 1px solid var(--cxcalendar-border);
        border-radius: 3px;
        background-color: var(--cxcalendar-bg);
        box-shadow: 1px 2px 3px rgba(0,0,0,.2);
        color: var(--cxcalendar-text-color);
        font-size: var(--cxcalendar-text-size);
        opacity: 0;
        transform: translate(0,5%) scale(0.9);
        transition-property: opacity,transform;
        transform-origin: top left;
        /* transition-duration: .3s; */
        -webkit-user-select: none;
        user-select: none
        box-sizing: border-box;
        display: flex;
        }
        .dc_cxcalendar *{
        box-sizing: border-box;
        font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
        }
        .dc_cxcalendar_mask {
        display: none;
        position: fixed;
        z-index: 9999;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        background-color: rgba(0,0,0,0)
        }
        .dc_cxcalendar.dc_show {
        opacity: 1;
        transform: translate(0,0) scale(0.9);
        }
        .dc_cxcalendar.dc_show + .dc_cxcalendar_mask {
        display: block
        }
        .dc_cxcalendar_content{
        width: 100%;
        border-left: 1px solid var(--cxcalendar-border);
        }
        .dc_cxcalendar_wp {
        }
        .dc_cxcalendar_wp_body {
        //  margin-left:70px;
        }
        .dc_cxcalendar_sb{
        position: relative;
        top: 0;
        // width: 378px;
        box-sizing: border-box;
        // padding-top: 6px;
        background-color: #f8f9fa;
        // overflow: auto;
        // width: 70px;
        }
        .dc_cxcalendar_sb ul{
        text-align: left;
        padding: 6px 4px;
        width:70px;
        list-style: none;
        }
        .dc_cxcalendar_sb ul li{
        // margin-top:5px;
        
        // line-height: 28px;
        }
        .dc_cxcalendar_sb ul li span{
            font-size:14px;
            display: block;
            border-radius: 2px;
            min-width: 50px;
            border: 1px solid var(--cxcalendar-border);
            text-align: center;
            /* margin-top: 10px; */
            /* padding: 0px 13px; */
            padding: 4px 4px;
            margin-bottom: 4px;
            background: white;
        }
        .dc_cxcalendar_sb ul li:first-child span{
            //  margin-top: 2px;
        }
        .dc_cxcalendar_sb ul li:hover{
        cursor: pointer;
        color:var(--cxcalendar-confirm-bg);
        }
        .dc_cxcalendar_hd {
        position: relative;
        height: 40px;
        //padding:0 var(--cxcalendar-gap-out);
        padding-bottom: 0;
        font-size: var(--cxcalendar-title-size);
        line-height: 40px;
        text-align: center;
        //zoom: 0.8
        }
        .dc_cxcalendar_hd .next,
        .dc_cxcalendar_hd .prev {
        position: absolute;
        top: var(--cxcalendar-gap-out);
        width: 30px;
        height: 30px;
        padding: 0;
        border: 1px solid transparent;
        border-radius: 3px;
        color: var(--cxcalendar-text-color);
        font-size: 0;
        line-height: 0;
        text-decoration: none;
        outline: 0;
        transition-property: border-color,background-color;
        transition-duration: .2s;
        margin-top:38px;
        }
        .dc_cxcalendar_hd .prev {
        left: var(--cxcalendar-gap-out)
        }
        .dc_cxcalendar_hd .next {
        right: var(--cxcalendar-gap-out)
        }
        .dc_cxcalendar_hd .next:before,
        .dc_cxcalendar_hd .prev:before {
        content: "";
        height: 10px;
        width: 10px;
        top: 12px;
        border-width: 1px 1px 0 0;
        border-color: black;
        border-style: solid;
        position: absolute;
        }
        
        .dc_cxcalendar_hd .prev:before {
        transform: matrix(-0.71, -0.71, 0.71, -0.71, 0, 0);
        }
        .dc_cxcalendar_hd .next:before {
        transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);
        }

        .dc_prev-next-box-group,.dc_prev-next-box{
            display:flex;
            justify-content: space-around;
            // margin: 0 13px;
        }
        .dc_prev-next-box{
            width:40px;
        }
        .dc_prev-next-box-group .dc_prev-next-box:last-child{
            margin-right: 40px;
        }
        .dc_prev-next-box-group .dc_prev-next-box:first-child{
            margin-left: 30px;
        }
            
        .dc_prevYear,.dc_prevMonth,.dc_nextMonth,.dc_nextYear :hover{
            cursor: pointer;
        }
        .dc_nextYear .dc_arrow-right::after,.dc_arrow-left::before{
            height: 6px;
            width: 6px;
            top: 13px;
        }

        .dc_prevYear .dc_arrow-left::before{
            height: 6px;
            width: 6px;
            top: 13px;
        }
        .dc_arrow-left,.dc_arrow-right{
            height: 22px;
            display :inline-block;
            position: relative;
          }
          .dc_arrow-right::after,.dc_arrow-left::before {
            content: "";
            height: 8px;
            width: 8px;
            top: 12px;
            border-width: 1px 1px 0 0;
            border-color: #303133;
            border-style: solid;
            position: absolute;
          }
          .dc_arrow-right::after {
            transform: matrix(0.71, 0.71, -0.71, 0.71, 0, 0);
          }
          .dc_arrow-left::before {
            transform: matrix(-0.71, -0.71, 0.71, -0.71, 0, 0);
          }

        .dc_cxcalendar_hd,.dc_cxcalendar_bd{
        // border-left: 1px solid var(--cxcalendar-border);
        border-bottom: 1px solid var(--cxcalendar-border);
        }
        .dc_times input,.dc_times select,
        .dc_cxcalendar_hd select {
        display: inline-block;
        box-sizing: border-box;
        height: 40px;
        margin: 0;
        padding: 0 .5em;
        border: 1px solid transparent;
        border-radius: 3px;
        background: 0 0;
        color: var(--cxcalendar-text-color);
        font-weight: 400;
        font-size: var(--cxcalendar-title-size);
        line-height: 30px;
        text-align: center;
        vertical-align: top;
        outline: 0;
        cursor: pointer;
        transition-property: border-color,background-color;
        transition-duration: .2s;
        -webkit-appearance: none;
        appearance: none;
        width:auto;
        }
        .dc_times input{
        height:30px;
        width: 34px;
        // background-color: #f3f3f3;
        padding: 0px;
        font-size: var(--cxcalendar-text-size);
        -webkit-appearance: none;
        background-color: #f8f9fa;
        background-image: none;
        border-radius: 4px;
        border: 1px solid #eee;
        box-sizing: border-box;
        color: #606266;
        display: inline-block;
        // font-size: inherit;
        outline: none;
        // padding: 0 15px;
        transition: border-color .2s cubic-bezier(.645,.045,.355,1);
        }
        .dc_cxcalendar_hd em {
        display: inline-block;
        padding: 0 1px;
        font-style: normal
        }
        .dc_cxcalendar_hd .dc_year + em:after {
        content: '年'
        }
        .dc_cxcalendar_hd .dc_month + em:after {
        content: '月'
        }
        /* 自定义下拉组件样式 */
        .dc_custom_select {
        position: relative;
        display: inline-block;
        box-sizing: border-box;
        height: 36px;
        margin: 0;
        padding: 0 .5em;
        border: 1px solid transparent;
        border-radius: 3px;
        background: 0 0;
        color: var(--cxcalendar-text-color);
        font-weight: 400;
        font-size: var(--cxcalendar-title-size);
        line-height: 30px;
        text-align: center;
        vertical-align: bottom;
        outline: 0;
        cursor: pointer;
        transition-property: border-color,background-color;
        transition-duration: .2s;
        width: auto;
        min-width: 50px;
        }
        .dc_custom_select:hover {
        border-color: var(--cxcalendar-border);
        background: var(--cxcalendar-item-bg)
        }
        .dc_custom_select.dc_open {
        border-color: var(--cxcalendar-border);
        background: var(--cxcalendar-item-bg)
        }
        .dc_custom_select .dc_select_display {
        display: block;
        overflow: hidden;
        text-overflow: ellipsis;
        white-space: nowrap;
        }
        .dc_custom_select .dc_select_dropdown {
        position: absolute;
        top: 100%;
        left: 0;
        right: 0;
        z-index: 10001;
        max-height: 200px;
        overflow-y: auto;
        overflow-x: hidden;
        background: var(--cxcalendar-bg);
        border: 1px solid var(--cxcalendar-border);
        border-radius: 3px;
        box-shadow: 0 2px 8px rgba(0,0,0,.15);
        margin-top: 2px;
        display: none;
        }
        .dc_custom_select.dc_open .dc_select_dropdown {
        display: block;
        }
        .dc_custom_select .dc_select_option {
        padding: 0;
        cursor: pointer;
        transition-property: background-color;
        transition-duration: .2s;
        text-align: center;
        }
        .dc_custom_select .dc_select_option:hover {
        background-color: var(--cxcalendar-item-bg);
        }
        .dc_custom_select .dc_select_option.dc_selected {
        background-color: var(--cxcalendar-confirm-bg);
        color: var(--cxcalendar-btn-color);
        }
        .dc_custom_select .dc_select_dropdown::-webkit-scrollbar {
        width: 6px;
        }
        .dc_custom_select .dc_select_dropdown::-webkit-scrollbar-track {
        background: #f1f1f1;
        }
        .dc_custom_select .dc_select_dropdown::-webkit-scrollbar-thumb {
        background: #888;
        border-radius: 3px;
        }
        .dc_custom_select .dc_select_dropdown::-webkit-scrollbar-thumb:hover {
        background: #555;
        }
        .dc_cxcalendar_hd .dc_fill {
        font-weight: 400;
        font-size: var(--cxcalendar-text-size)
        }
        .dc_cxcalendar_hd .dc_fill span {
        padding: 0 4px
        }
        .dc_times select:hover,
        .dc_cxcalendar_hd .dc_next:hover,
        .dc_cxcalendar_hd .dc_prev:hover,
        .dc_cxcalendar_hd select:hover {
        border-color: var(--cxcalendar-border);
        background: var(--cxcalendar-item-bg)
        }
        .dc_cxcalendar_bd {
        position: relative;
        padding: var(--cxcalendar-gap-out);
        padding-top: 0;
        z-index: 1;
        //margin-top: 12px;
        // border-top: 1px solid var(--cxcalendar-border);
        //zoom:0.8
        }
        .dc_cxcalendar_bd ul {
        position: relative;
        margin: 0;
        margin-bottom: 7px;
        padding: 0;
        list-style: none;
        color: var(--cxcalendar-days-color);
        line-height: 32px;
        text-align: center;
        display: flex;
        flex-wrap: wrap;
        justify-content: center;
        align-content: flex-start;
        }
        .dc_cxcalendar_bd ul li {
        box-sizing: border-box;
        position: relative;
        height: 28px;
        font-size: 14px;
        margin: 0;
        padding: 0;
        //border: 2px solid var(--cxcalendar-bg);
        border-radius: 5px;
        cursor: pointer;
        // flex: none;
        transition-property: background-color,color;
        transition-duration: .2s;
        display: flex;
        align-items: center;
        justify-content: center;
        }
        .dc_cxcalendar_bd ul li.del,
        .dc_cxcalendar_bd ul li.dc_del,
        .dc_cxcalendar_bd ul li.week {
        cursor: default
        }
        .dc_cxcalendar_bd ul li.del,
        .dc_cxcalendar_bd ul li.dc_del,
        .dc_cxcalendar_bd ul li.del.holiday,
        .dc_cxcalendar_bd ul li.dc_del.holiday,
        .dc_cxcalendar_bd ul li.del.now,
        .dc_cxcalendar_bd ul li.dc_del.now,
        .dc_cxcalendar_bd ul li.del.sat,
        .dc_cxcalendar_bd ul li.dc_del.sat,
        .dc_cxcalendar_bd ul li.del.sun,
        .dc_cxcalendar_bd ul li.dc_del.sun {
            color: var(--cxcalendar-other-color);
            cursor: not-allowed;
        }
        .dc_cxcalendar_bd ul li.now {
        /* background-color: var(--cxcalendar-now-bg) */
        }
        .dc_cxcalendar_bd ul li.del:hover,
        .dc_cxcalendar_bd ul li.dc_del:hover,
        .dc_cxcalendar_bd ul li.now.del,
        .dc_cxcalendar_bd ul li.now.dc_del,
        .dc_cxcalendar_bd ul li.week:hover {
            background: 0 0
        }
        .cxcalendar_bd ul li:hover {
        background-color: var(--cxcalendar-item-bg)
        }
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected,
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected.dc_holiday,
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected.dc_other,
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected.dc_sat,
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected.dc_sun,
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected:hover {
        /* background-color: var(--cxcalendar-set-bg); */
        background-color: var(--cxcalendar-confirm-bg);
        color: var(--cxcalendar-btn-color);
        //color: var(--cxcalendar-text-color)
        }
        .dc_cxcalendar_bd ul li.del:after,
        .dc_cxcalendar_bd ul li.dc_del:after,
        .dc_cxcalendar_bd ul li.DCcxCalendarSelected:after {
        color: inherit
        }
        .dc_cxcalendar_bd .dc_days li {
        flex-basis: 14%
        }
        .dc_cxcalendar_bd .dc_days .dc_sat {
        /* color: var(--cxcalendar-sat-color) */
        color: var(--cxcalendar-days-color)
        }
        .dc_cxcalendar_bd .dc_days .dc_holiday,
        .dc_cxcalendar_bd .dc_days .dc_sun {
        /* color: var(--cxcalendar-sun-color) */
        color: var(--cxcalendar-days-color)
        }
        /* 禁用的周六周日也要置灰 */
        .dc_cxcalendar_bd .dc_days .dc_sat.dc_del,
        .dc_cxcalendar_bd .dc_days .dc_sun.dc_del {
        color: var(--cxcalendar-other-color);
        }
        .dc_cxcalendar_bd .dc_days .dc_other {
        color: var(--cxcalendar-other-color)
        }
        .dc_cxcalendar_bd .dc_days li.dc_week.dc_sat,
        .dc_cxcalendar_bd .dc_days li.dc_week.dc_sun {
        color: inherit
        }
        .dc_week{
            font-weight: 700;
            color:var(--cxcalendar-text-color);
        }
        .dc_cxcalendar_bd .dc_months li {
        flex-basis: 33%
        }
        .dc_cxcalendar_bd .dc_years li {
        flex-basis: 25%
        }
        .dc_cxcalendar_bd .dc_months li:after,
        .dc_cxcalendar_bd .dc_years li:after {
        content: '月';
        display: inline-block;
        margin-left: 2px;
        color: var(--cxcalendar-note-color);
        font-size: var(--cxcalendar-unit-size);
        vertical-align: top
        }
        .dc_cxcalendar_bd .dc_years li:after {
        content: '年'
        }
        .dc_times {
        position: relative;
        //margin-top: var(--cxcalendar-gap-out);
        // padding-top: var(--cxcalendar-gap-out);
        //padding: var(--cxcalendar-gap-out) var(--cxcalendar-gap-out) 0;
        padding: 10px 8px 8px;
        margin: -5px -4px;
        border-top: 1px solid var(--cxcalendar-border);
        color: var(--cxcalendar-note-color);
        line-height: 32px;
        display: flex;
        background-color: #f8f9fa;
        }
        .dc_times:before {
        content: '';
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        height: 1px;
        //background: linear-gradient(to right,rgba(0,0,0,0) 0,rgba(0,0,0,.1) 15%,rgba(0,0,0,.1) 85%,rgba(0,0,0,0) 100%)
        }
        .dc_times:only-child:before {
        display: none
        }
        .dc_times section {
        flex: 1;
        display: flex;
        justify-content: center;
        height: 31.99px;
        margin-bottom: var(--cxcalendar-gap-out);
        }
        .dc_times section:before {
        content: '';
        margin-right: 3px;
        font-size: 13px;
        }
        .dc_times select {
        font-weight: 400;
        font-size: var(--cxcalendar-text-size)
        }
        .dc_times i {
        padding: 0 1px;
        font-style: normal
        }
        .dc_times .dc_time-group i:after {
        content: ':'
        }
        .dc_times .dc_date-group i:after {
        content: '-'
        }
        .dc_times .dc_date-group i:first-child:after {
        content: '年'
        }

        .dc_times .dc_date-group input:first-child {
        width:50px;
        }
        .dc_cxcalendar_acts {
        padding: var(--cxcalendar-gap-out) 5px;
        border-top: 1px solid var(--cxcalendar-border);
        border-radius: 0 0 3px 3px;
        /* background-color: var(--cxcalendar-item-bg); */
        font-size: 15px;
        line-height: 30px;
        display: flex;
        justify-content: flex-end;
        //zoom: 0.8;
        }
        .dc_cxcalendar_acts a {
        font-weight: 500;
        padding: 0 15px;
        border-radius: 3px;
        /* background-color: var(--cxcalendar-btn-bg); */
        //background-color: var(--cxcalendar-now-bg);
        /* color: var(--cxcalendar-btn-color); */
        color: var(--cxcalendar-text-color);
        text-decoration: none;
        text-align: center;
        transition-property: opacity;
        transition-duration: .2s;
        //height: 30px;
        font-size: 15px;
        border: 1px solid #ddd;

        }
        .dc_cxcalendar_acts a + a {
        margin-left: 15px
        }
        .dc_cxcalendar_acts a:hover {
        /* color: var(--cxcalendar-btn-color); */
        //color: var(--cxcalendar-text-color);
        background-color: var(--cxcalendar-now-bg);
        //opacity: .6
        }
        .dc_cxcalendar_acts .dc_today:before {
        content: '今天'
        }
        .dc_cxcalendar_acts .dc_clear {
        height:100%
        }
        .dc_cxcalendar_acts .dc_clear:before {
        content: '清除'
        }
        .dc_cxcalendar_acts .dc_confirm {
        background-color: var(--cxcalendar-confirm-bg);
        color:#fff;
        height: 100%;
        }
        .dc_cxcalendar_acts .dc_confirm:hover {
            background-color: #106ebe;
        }
        .dc_cxcalendar_acts .dc_confirm:before {
        content: '确定'
        }
        .dc_cxcalendar.m_datetime .dc_cxcalendar_acts .dc_today:before,
        .dc_cxcalendar.dc_m_time .dc_cxcalendar_acts .dc_today:before {
        content: '现在'
        }
        .dc_cxcalendar.m_year .dc_cxcalendar_acts .dc_today:before {
        content: '今年'
        }
        .dc_cxcalendar.m_month .dc_cxcalendar_acts .dc_today:before {
        content: '本月'
        }
        .dc_cxcalendar.dc_at_end .dc_cxcalendar_hd .dc_next,
        .dc_cxcalendar.dc_at_start .dc_cxcalendar_hd .prev {
        color: var(--cxcalendar-other-color);
        cursor: default
        }
        .dc_cxcalendar.dc_at_end .dc_cxcalendar_hd .dc_next:hover,
        .dc_cxcalendar.dc_at_start .dc_cxcalendar_hd .dc_prev:hover {
        border-color: transparent;
        background: 0 0
        }
        .dc_cxcalendar.dc_range {
        width: 524px
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd .dc_days,
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd .dc_months,
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd .dc_years,
        .dc_cxcalendar.dc_range .dc_cxcalendar_hd {
        display: flex
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul,
        .dc_cxcalendar.dc_range .dc_cxcalendar_hd section {
        flex: 1
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul + ul {
        margin-left: var(--cxcalendar-gap-out)
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul + ul:before {
        content: '';
        position: absolute;
        top: 0;
        bottom: 0;
        left: -4px;
        width: 1px;
        background: linear-gradient(to bottom,rgba(0,0,0,0) 0,rgba(0,0,0,.1) 35%,rgba(0,0,0,.1) 65%,rgba(0,0,0,0) 100%)
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul li.dc_other {
        visibility: hidden
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul li.dc_DCcxCalendarSelected {
        background-color: var(--cxcalendar-range-bg);
        color: var(--cxcalendar-days-color)
        }
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul li.dc_DCcxCalendarSelected.dc_end,
        .dc_cxcalendar.dc_range .dc_cxcalendar_bd ul li.dc_DCcxCalendarSelected.dc_start {
        background-color: var(--cxcalendar-range-set-bg);
        color: var(--cxcalendar-btn-color)
        }
        .dc_cxcalendar.dc_range .dc_times section:first-child:before {
        content: '开始时间'
        }
        .dc_cxcalendar.dc_range .dc_times section:nth-child(2):before {
        content: '结束时间'
        }
        .dc_cxcalendar.dc_fixed {
        position: fixed;
        top: auto;
        bottom: -500px;
        left: 0;
        right: 0;
        width: auto;
        border: none;
        border-radius: 0;
        box-shadow: none;
        opacity: 1;
        transform: none;
        transition-property: bottom
        }
        .dc_cxcalendar.dc_fixed + .dc_cxcalendar_mask {
        display: block;
        background-color: rgba(0,0,0,0);
        transform: translate(0,-100%);
        transition-property: background-color,transform;
        transition-duration: .3s,0s;
        transition-delay: 0s,0.3s
        }
        .dc_cxcalendar.dc_fixed.dc_show {
        bottom: 0
        }
        .dc_cxcalendar.dc_fixed.dc_show + .dc_cxcalendar_mask {
        background-color: rgba(0,0,0,.4);
        transform: translate(0,0);
        transition-delay: 0s
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_bd ul:nth-child(2),
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_hd section:nth-child(2) {
        display: none
        }
        .dc_cxcalendar.dc_fixed .dc_times {
        display: block
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_hd .dc_prev {
        left: 24px
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_hd .dc_next {
        right: 24px
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_bd {
        padding-bottom: 20px
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_bd ul {
        line-height: 36px
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_bd ul li {
        height: 40px
        }
        .dc_cxcalendar.dc_fixed .dc_times {
        padding-top: 10px;
        padding-bottom: 10px
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_acts {
        position: absolute;
        top: auto;
        left: auto;
        bottom: 100%;
        right: 10px;
        width: auto;
        padding: 0;
        border: none;
        background: 0 0;
        line-height: 32px;
        display: flex
        }
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_acts a {
        border-radius: 3px 3px 0 0
        }
        .dc_cxcalendar.dc_has_weeknum .dc_cxcalendar_bd .dc_days ul {
        padding-left: 24px
        }
        .dc_cxcalendar.dc_has_weeknum .dc_cxcalendar_bd .dc_days li[data-week-num]:before {
        content: attr(data-week-num);
        position: absolute;
        top: 50%;
        left: -16px;
        width: 16px;
        margin-top: -8px;
        margin-left: -8px;
        border-radius: 3px;
        background-color: rgba(0,0,0,.1);
        color: #fff;
        font-size: var(--cxcalendar-unit-size);
        line-height: 16px;
        text-align: center;
        pointer-events: none
        }
        .dc_cxcalendar.dc_not_secs .dc_times .dc_mint + i,
        .dc_cxcalendar.dc_not_secs .dc_times .dc_secs {
        display: none
        }
        .dc_cxcalendar.dc_not_acts .dc_cxcalendar_acts {
        display: none
        }
        .dc_cxcalendar.dc_en .dc_cxcalendar_bd .dc_months li:after,
        .dc_cxcalendar.dc_en .dc_cxcalendar_bd .dc_years li:after,
        .dc_cxcalendar.dc_en .dc_cxcalendar_hd .dc_month + em:after,
        .dc_cxcalendar.dc_en .dc_cxcalendar_hd .dc_year + em:after {
        content: ''
        }
        .dc_cxcalendar.dc_en .dc_times section:before {
        content: 'Time:'
        }
        .dc_cxcalendar.dc_en .dc_cxcalendar_acts .dc_today:before {
        content: 'Now'
        }
        .dc_cxcalendar.dc_en .dc_cxcalendar_acts .dc_clear:before {
        content: 'Clear'
        }
        .dc_cxcalendar.dc_en .dc_cxcalendar_acts .dc_confirm:before {
        content: 'Ok'
        }
        .dc_cxcalendar.dc_en.dc_range .dc_times section:first-child:before {
        content: 'Start Time:'
        }
        .dc_cxcalendar.dc_en.dc_range .dc_times section:nth-child(2):before {
        content: 'End Time:'
        }

        .dc_only-time {
            width: 230px;
        }

        .dc_only-time .dc_cxcalendar_wp_body{
            margin-left: 0px;
        }
        .dc_only-time .dc_cxcalendar_hd{
            height: 45px;
        }
        .dc_only-time .dc_cxcalendar_acts{
            justify-content: center;
        }
        .dc_only-time .dc_cxcalendar_bd{
            display:none;
        }

        .dc_only-time .dc_times input{
            width: 50px;
        }   
        .dc_only-time .dc_times{
            padding: 7px 8px 0px;
            margin:0px;
        }

        @media (min-width:640px) {
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_bd ul:nth-child(2),
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_hd section:nth-child(2) {
        display: inherit
        }
        .dc_cxcalendar.dc_fixed .dc_times {
        display: flex
        }
        }
        @media (width:375px) and (height:812px),
        (width:414px) and (height:896px),
        (width:390px) and (height:844px),
        (width:428px) and (height:926px) {
        .dc_cxcalendar.dc_fixed .dc_cxcalendar_bd {
        padding-bottom: env(safe-area-inset-bottom)
        }
        }
        `;
        let oldCxcalendar = rootElement.ownerDocument.querySelector('.dc_cxcalendar');
        if (oldCxcalendar) {
            return;
        }
        let oldCss = rootElement.ownerDocument.getElementById('dc_calendarCss');
        if (!oldCss) {
            var calendarCss = rootElement.ownerDocument.createElement('style');
            rootElement.ownerDocument.head.appendChild(calendarCss);
            calendarCss.id = 'dc_calendarCss';
            calendarCss.innerHTML = calendarCssString;
        }
        /**
         * cxCalendar
         * @version 3.0.5
         * @author ciaoca
         * @email ciaoca@gmail.com
         * @site https://github.com/ciaoca/cxCalendar
         * @license Released under the MIT license
         */
        (function (rootElement, factory) {
            //typeof exports === 'object' && typeof module !== 'undefined' ? module.exports = factory() :
            //    typeof define === 'function' && define.amd ? define(factory) :
            //        (global = typeof globalThis !== 'undefined' ? globalThis : global || self, global.cxCalendar = factory());
            // global = typeof globalThis !== 'undefined' ? globalThis : global || self, global.cxCalendar = factory();
            rootElement.ownerDocument.cxCalendar = factory();
        })(rootElement, (function () {
            'use strict';

            const theTool = {
                dom: {},
                reg: {
                    isYear: /^\d{4}$/,
                    isTime: /^\d{1,2}(\:\d{1,2}){1,2}$/
                },
                cxId: 1,
                bindFuns: {},
                cacheDate: {},
                cacheApi: null,

                // 默认语言
                language: {
                    am: '上午',
                    pm: '下午',
                    monthList: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12'],
                    weekList: ['日', '一', '二', '三', '四', '五', '六'],
                },

                isElement: (o) => {
                    if (o && (typeof HTMLElement === 'function' || typeof HTMLElement === 'object') && o instanceof HTMLElement) {
                        return true;
                    } else {
                        return (o && o.nodeType && o.nodeType === 1) ? true : false;
                    }
                },
                isInteger: (value) => {
                    if (typeof value === 'string' && /^\-?\d+$/.test(value)) {
                        value = parseInt(value, 10);
                    } return typeof value === 'number' && isFinite(value);
                },
                isObject: (value) => {
                    if (value === undefined || value === null || Object.prototype.toString.call(value) !== '[object Object]') {
                        return false;
                    }
                    if (value.constructor && !Object.prototype.hasOwnProperty.call(value.constructor.prototype, 'isPrototypeOf')) {
                        return false;
                    }
                    return true;
                },
                isDate: (value) => {
                    return (value instanceof Date || Object.prototype.toString.call(value) === '[object Date]') && isFinite(value.getTime());
                },
            };

            // 合并对象
            theTool.extend = function (target, ...sources) {
                const self = this;

                if (!self.isObject(target)) {
                    return;
                }
                for (let x of sources) {
                    if (!self.isObject(x)) {
                        continue;
                    }
                    for (let y in x) {
                        if (Array.isArray(x[y])) {
                            target[y] = [].concat(x[y]);

                        } else if (self.isObject(x[y])) {
                            if (!self.isObject(target[y])) {
                                target[y] = {};
                            } self.extend(target[y], x[y]);

                        } else {
                            target[y] = x[y];
                        }
                    }
                }
                return target;
            };

            // 补充前置零
            theTool.fillLeadZero = function (value, num) {
                let str = String(value);

                if (str.length < num) {
                    str = Array(num - str.length).fill(0).join('') + value;
                }
                return str;
            };

            // 获取当年每月的天数
            theTool.getMonthDays = function (year) {
                const leapYearDay = ((year % 4 === 0 && year % 100 !== 0) || year % 400 === 0) ? 1 : 0;
                return [31, 28 + leapYearDay, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
            };

            // 获取周数
            theTool.getWeekNum = function (dateObj) {
                const self = this;
                const curTime = dateObj.getTime();
                const yearFirstDate = new Date(dateObj.getFullYear(), 0, 1, 0, 0, 0, 0);
                let weekFirstTime = yearFirstDate.getTime();
                let weekDay = yearFirstDate.getDay();
                let weekNum = 0;

                if (weekDay === 0) {
                    weekDay = 7;
                }
                if (weekDay > 4) {
                    weekFirstTime += (8 - weekDay) * 86400000;
                } else {
                    weekFirstTime += (1 - weekDay) * 86400000;
                }
                if (curTime < weekFirstTime) {
                    weekNum = self.getWeekNum(new Date(dateObj.getFullYear() - 1, 11, 31));
                } else {
                    weekNum = Math.floor((curTime - weekFirstTime) / 86400000) + 1;
                    weekNum = Math.ceil(weekNum / 7);
                }
                return weekNum;
            };

            /**
             * 解析日期
             * 默认支持 ISO 8601 格式，和以下格式
             * y
             * y-m
             * y-m-d
             * y-m-d h:i
             * y-m-d h:i:s
             * m-d
             * m-d h:i
             * m-d h:i:s
             * h:i
             * h:i:s
             * 
             * 日期连接符 '-' 可替换为 '.' 或 '/'
            **/
            theTool.parseDate = function (value, mustDef) {
                const self = this;
                let theDate = new Date();

                if (self.reg.isYear.test(value)) {
                    theDate.setFullYear(parseInt(value, 10));

                } else if (self.isInteger(value)) {
                    theDate.setTime(parseInt(value, 10));

                } else if (typeof value === 'string' && value.length) {
                    let tags;

                    if (self.reg.isTime.test(value)) {
                        tags = value.split(':').map((x) => {
                            return parseInt(x, 10);
                        });

                        if (tags.length < 4) {
                            tags = tags.concat(Array(4 - tags.length).fill(0));
                        } else if (tags.length > 4) {
                            tags.length = 4;
                        }
                        theDate.setHours.apply(theDate, tags);

                    } else {
                        value = value.replace(/[\.\/]/g, '-');
                        if (/^\d{1,2}-\d{1,2}/.test(value)) {
                            value = theDate.getFullYear() + '-' + value;
                        } else if (/^\d{4}-\d{1,2}$/.test(value)) {
                            value += '-1';
                        }
                        tags = value.split(/[\-\sT\:]/).map((x) => {
                            return parseInt(x, 10);
                        });

                        if (tags.length > 1) {
                            tags[1] -= 1;
                        }
                        if (tags.length < 7) {
                            tags = tags.concat(Array(7 - tags.length).fill(0));
                        } else if (tags.length > 7) {
                            tags.length = 7;
                        }
                        theDate.setFullYear.apply(theDate, tags.slice(0, 3));
                        theDate.setHours.apply(theDate, tags.slice(3));
                    }
                } else {
                    theDate = null;
                }
                if (mustDef === true && !self.isDate(theDate)) {
                    theDate = new Date();
                }
                return theDate;
            };

            // 格式化日期值
            theTool.formatDate = function (style, time, language) {
                const self = this;
                const theDate = self.parseDate(time);
                const lang = self.extend({}, self.language);

                if (self.isObject(language)) {
                    self.extend(lang, language);
                }
                if (typeof style !== 'string' || !self.isDate(theDate)) {
                    return time;
                }
                const attr = {
                    Y: theDate.getFullYear(),
                    n: theDate.getMonth() + 1,
                    j: theDate.getDate(),
                    G: theDate.getHours(),
                    timestamp: theDate.getTime(),
                };

                attr.y = attr.Y.toString(10).slice(-2);
                attr.m = self.fillLeadZero(attr.n, 2);
                attr.d = self.fillLeadZero(attr.j, 2);
                attr.W = self.getWeekNum(theDate);

                attr.H = self.fillLeadZero(attr.G, 2);
                attr.g = attr.G > 12 ? attr.G - 12 : attr.G;
                attr.h = self.fillLeadZero(attr.g, 2);
                attr.i = self.fillLeadZero(theDate.getMinutes(), 2);
                attr.s = self.fillLeadZero(theDate.getSeconds(), 2);
                attr.a = attr.G > 12 ? lang.pm : lang.am;

                const keys = ['timestamp', 'Y', 'y', 'm', 'n', 'd', 'j', 'W', 'H', 'h', 'G', 'g', 'i', 's', 'a'];
                const reg = new RegExp('(' + keys.join('|') + ')', 'g');
                let str = style;

                // 转义边界符号
                str = str.replace(/([\{\}])/g, '\\$1');

                // 转义关键词
                str = str.replace(reg, (match, p1) => {
                    return '{{' + p1 + '}}';
                });

                // 还原转义字符
                str = str.replace(/\\\{\{(.)\}\}/g, '$1');

                // 替换关键词
                for (let x of keys) {
                    str = str.replace(new RegExp('{{' + x + '}}', 'g'), attr[x]);
                }
                // 还原转义内容
                str = str.replace(/\\(.)/g, '$1');

                return str;
            };

            // 获取语言配置
            theTool.getLanguage = function (name) {
                const self = this;
                const lang = {};

                if (self.isObject(name)) {
                    return self.extend(lang, self.language, name);
                }
                if (typeof name !== 'string' || !name.length) {
                    if (typeof navigator.language === 'string') {
                        name = navigator.language;
                    } else if (typeof navigator.browserLanguage === 'string') {
                        name = navigator.browserLanguage;
                    }
                }
                if (typeof name === 'string' && name.length && window.cxCalendar && self.isObject(window.cxCalendar.languages)) {
                    name = name.toLowerCase();
                    if (self.isObject(window.cxCalendar.languages[name])) {
                        self.extend(lang, window.cxCalendar.languages[name]);
                    } else if (self.isObject(window.cxCalendar.languages.default)) {
                        self.extend(lang, window.cxCalendar.languages.default);
                    }
                }
                if (!Object.keys(lang).length) {
                    self.extend(lang, self.language);
                }
                return lang;
            };

            theTool.init = function () {
                const self = this;
                self.buildStage();
                self.bindEvent();
            };

            // 构建选择器
            theTool.buildStage = function () {
                const self = this;

                self.dom.maskBg = rootElement.ownerDocument.createElement('div');
                self.dom.maskBg.classList.add('dc_cxcalendar_mask');

                self.dom.panel = rootElement.ownerDocument.createElement('div');
                self.dom.panel.classList.add('dc_cxcalendar');

                // self.dom.sidebar = rootElement.ownerDocument.createElement('div');
                // self.dom.sidebar.classList.add('dc_cxcalendar_sidebar');

                self.dom.content = rootElement.ownerDocument.createElement('div');
                self.dom.content.classList.add('dc_cxcalendar_content');

                self.dom.wrapper = rootElement.ownerDocument.createElement('div');
                self.dom.wrapper.classList.add('dc_cxcalendar_wp');

                self.dom.wrapperBody = rootElement.ownerDocument.createElement('div');
                self.dom.wrapperBody.classList.add('dc_cxcalendar_wp_body');

                self.dom.sidebar = rootElement.ownerDocument.createElement('div');
                self.dom.sidebar.classList.add('dc_cxcalendar_sb');

                self.dom.head = rootElement.ownerDocument.createElement('div');
                self.dom.head.classList.add('dc_cxcalendar_hd');

                self.dom.main = rootElement.ownerDocument.createElement('div');
                self.dom.main.classList.add('dc_cxcalendar_bd');

                self.dom.footer = rootElement.ownerDocument.createElement('div');
                self.dom.footer.classList.add('dc_cxcalendar_ft');

                self.dom.acts = rootElement.ownerDocument.createElement('div');
                self.dom.acts.classList.add('dc_cxcalendar_acts');

                self.dom.dateSet = rootElement.ownerDocument.createElement('div');

                self.dom.timeSet = rootElement.ownerDocument.createElement('div');
                self.dom.timeSet.classList.add('dc_times');
                //self.dom.main.insertAdjacentElement('beforeend', self.dom.timeSet);
                self.dom.wrapperBody.insertAdjacentElement('beforeend', self.dom.main);

                self.dom.wrapper.insertAdjacentElement('beforeend', self.dom.wrapperBody);


                self.dom.content.insertAdjacentElement('beforeend', self.dom.wrapper);
                // self.dom.panel.insertAdjacentElement('beforeend', self.dom.sidebar);
                self.dom.panel.insertAdjacentElement('beforeend', self.dom.content);

                rootElement.ownerDocument.body.insertAdjacentElement('beforeend', self.dom.panel);

                self.dom.panel.insertAdjacentElement('afterend', self.dom.maskBg);
            };

            // 绑定事件
            theTool.bindEvent = function () {
                const self = this;

                // 关闭面板
                self.dom.maskBg.addEventListener('click', () => {
                    self.hidePanel();
                });

                self.dom.panel.addEventListener('click', (e) => {
                    const el = e.target;
                    const nodeName = el.nodeName.toLowerCase();
                    if (nodeName === 'a' && el.rel) {
                        // 时间下拉框按下确定避免报错
                        if (e.preventDefault) {
                            e.preventDefault();
                        }

                        switch (el.rel) {
                            // 上个月
                            case 'dc_prev':
                                self.gotoPrev();
                                break;

                            // 下个月
                            case 'dc_next':
                                self.gotoNext();
                                break;

                            // 今日
                            case 'dc_today':
                                self.hidePanel();
                                self.cacheApi.setDate(new Date().getTime());
                                break;

                            // 清除
                            case 'dc_clear':
                                self.hidePanel();
                                self.cacheApi.clearDate();
                                break;

                            // 确认
                            case 'dc_confirm':
                                self.hidePanel();
                                if (self.cacheApi.settings.mode === 'range') {
                                    self.confirmRange();
                                } else {
                                    self.confirmTime();
                                }
                                break;


                        }
                        // 选择日期
                    } else if (nodeName === 'li' && el.dataset.date) {
                        // 如果日期被禁用（有dc_del类），阻止默认行为
                        if (el.classList.contains('dc_del') || el.classList.contains('del')) {
                            return;
                        }

                        const dateText = el.dataset.date;

                        if (typeof dateText !== 'string' || !dateText.length) {
                            return;
                        }
                        for (let x of el.parentNode.parentNode.querySelectorAll('li')) {
                            x.classList.remove('DCcxCalendarSelected');
                        } el.classList.add('DCcxCalendarSelected');

                        // 范围选择，需手动确认
                        if (self.cacheApi.settings.mode === 'range') {
                            const theDate = self.parseDate(dateText);
                            theDate.setHours(0, 0, 0, 0);
                            const theTime = theDate.getTime();

                            if (typeof self.cacheDate.startTime === 'number' && typeof self.cacheDate.endTime === 'number') {
                                if ((theTime >= self.cacheDate.startTime && theTime <= self.cacheDate.endTime)) {
                                    delete self.cacheDate.startTime;
                                    delete self.cacheDate.endTime;
                                } else {
                                    self.cacheDate.startTime = theTime;
                                    delete self.cacheDate.endTime;
                                }
                            } else if (typeof self.cacheDate.startTime === 'number') {
                                if (theTime === self.cacheDate.startTime) {
                                    delete self.cacheDate.startTime;
                                } else if (theTime > self.cacheDate.startTime) {
                                    self.cacheDate.endTime = theTime;
                                } else {
                                    self.cacheDate.startTime = theTime;
                                }
                            } else {
                                self.cacheDate.startTime = theTime;
                            }
                            self.gotoDate();
                            return;
                        }
                        // 时间选择，需手动确认
                        if (self.cacheApi.settings.type === 'datetime') {
                            self.cacheDate.time = self.parseDate(dateText).getTime();
                            self.setDateValues(self.cacheDate.time);

                            //[DUWRITER5_0-4247] 20250320   lxy 修改时间日期选择为：点击日期即可确认，无需再次点击确认按钮
                            var DataTimeInputFieldElementClickToAssignValue = WriterControl_DateTimeControl.rootElement.getAttribute('DataTimeInputFieldElementClickToAssignValue');
                            if (DataTimeInputFieldElementClickToAssignValue === 'true' || DataTimeInputFieldElementClickToAssignValue === true) {
                                self.hidePanel();
                                self.confirmTime();
                            }
                            return;
                        }
                        self.hidePanel();
                        self.cacheApi.setDate(dateText);

                    }
                });

                // 选择年月
                self.dom.panel.addEventListener('change', (e) => {
                    const el = e.target;
                    const nodeName = el.nodeName.toLowerCase();

                    if ((nodeName === 'select' || el.classList.contains('dc_custom_select')) && ['year', 'month'].indexOf(el.name) >= 0) {
                        self.rebuildMonthSelect();
                        self.gotoDate();
                    }
                });
                // 屏蔽日期时间选择框的右键菜单20230928
                self.dom.panel.addEventListener('contextmenu', function (e) {
                    e.preventDefault();
                });
                // 屏蔽日期弹出框的遮罩层右键菜单20230928  修改写法不然初始化报错
                //let cxcalendar_mask = document.getElementsByClassName('cxcalendar_mask')[0]
                self.dom.maskBg.addEventListener('contextmenu', function (e) {
                    e.preventDefault();
                });

                // 左侧按钮事件
                self.dom.sidebar.addEventListener('click', function (e) {
                    const el = e.target;
                    // const nodeName = el.nodeName.toLowerCase();
                    const headerYearSelect = self.findSelectElement(self.dom.head, 'dc_year');
                    const headerMonthSelect = self.findSelectElement(self.dom.head, 'dc_month');
                    const today = new Date();
                    let selectDate;
                    switch (el.className) {
                        case 'dc_today':
                            //年月下拉框赋值
                            if (headerYearSelect) {
                                headerYearSelect.value = today.getFullYear();
                            }
                            if (headerMonthSelect) {
                                headerMonthSelect.value = today.getMonth() + 1;
                            }

                            //日期输入框赋值
                            self.setDateValues(today);
                            //跳转指定日历
                            self.gotoDate();
                            //格式化日期，定位日历
                            selectDate = theTool.formatDate('Y-m-d', today.getTime());
                            self.locateDay(selectDate);
                            break;
                        case 'dc_yesterday':
                            //获取昨天日期
                            let yesterdayDate = new Date(today.getTime() - 24 * 60 * 60 * 1000);
                            //年月下拉框赋值
                            if (headerYearSelect) {
                                headerYearSelect.value = yesterdayDate.getFullYear();
                            }
                            if (headerMonthSelect) {
                                headerMonthSelect.value = yesterdayDate.getMonth() + 1;
                            }
                            //日期输入框赋值
                            self.setDateValues(yesterdayDate);
                            //跳转指定日历
                            self.gotoDate();
                            //格式化昨日日期，定位日历
                            selectDate = theTool.formatDate('Y-m-d', (today.getTime() - 24 * 60 * 60 * 1000));
                            self.locateDay(selectDate);
                            break;
                        case 'dc_lastMonth':
                            self.gotoPrev();
                            break;
                        case 'dc_nextMonth':
                            self.gotoNext();
                            break;

                        default:
                            break;
                    }
                });
            };

            // 获取内部选框控件
            // 辅助函数：查找自定义下拉组件或原生 select
            theTool.findSelectElement = function (container, className) {
                const self = this;
                // 从类名中提取名称（例如 'dc_year' -> 'year', 'dc_month' -> 'month'）
                const name = className.replace('dc_', '');

                // 先查找自定义下拉组件（通过 data-name 属性或类名）
                const customSelect = container.querySelector('.dc_custom_select[data-name="' + name + '"]') ||
                    container.querySelector('.dc_custom_select.' + className);
                if (customSelect) {
                    return customSelect;
                }
                // 兼容原生 select
                const nativeSelect = container.querySelector('select.' + className);
                return nativeSelect || null;
            };

            // 创建自定义下拉组件
            theTool.createCustomSelect = function (name, options, selectedValue) {
                const self = this;
                const selectId = 'dc_custom_select_' + name + '_' + Date.now() + '_' + Math.random().toString(36).substr(2, 9);
                let html = '<div class="dc_custom_select" data-name="' + name + '" id="' + selectId + '">';
                html += '<div class="dc_select_display">' + (selectedValue || '') + '</div>';
                html += '<div class="dc_select_dropdown">';

                for (let i = 0; i < options.length; i++) {
                    const option = options[i];
                    const value = option.value;
                    const text = option.text;
                    const isSelected = option.selected || value == selectedValue;
                    html += '<div class="dc_select_option' + (isSelected ? ' dc_selected' : '') + '" data-value="' + value + '">' + text + '</div>';
                }

                html += '</div></div>';

                // 创建元素
                const tempDiv = document.createElement('div');
                tempDiv.innerHTML = html;
                const selectElement = tempDiv.firstElementChild;

                // 添加属性以模拟 select 元素
                selectElement.name = name;
                selectElement.options = options.map((opt, idx) => ({
                    value: opt.value,
                    text: opt.text,
                    selected: opt.selected || opt.value == selectedValue,
                    index: idx
                }));
                let currentSelectedIndex = options.findIndex(opt => opt.selected || opt.value == selectedValue);
                if (currentSelectedIndex < 0) currentSelectedIndex = 0;

                // 添加 selectedIndex 属性
                // 使用 selectElement 上的属性来控制是否触发事件
                selectElement._suppressChangeEvent = false;
                Object.defineProperty(selectElement, 'selectedIndex', {
                    get: function () {
                        const selectedOption = this.querySelector('.dc_select_option.dc_selected');
                        if (selectedOption) {
                            const options = Array.from(this.querySelectorAll('.dc_select_option'));
                            return options.indexOf(selectedOption);
                        }
                        return 0;
                    },
                    set: function (index) {
                        const options = this.querySelectorAll('.dc_select_option');
                        const display = this.querySelector('.dc_select_display');

                        if (index >= 0 && index < options.length) {
                            // 移除所有选中状态
                            options.forEach(opt => opt.classList.remove('dc_selected'));

                            // 设置新的选中项
                            const selectedOption = options[index];
                            if (selectedOption) {
                                selectedOption.classList.add('dc_selected');
                                if (display) {
                                    display.textContent = selectedOption.textContent;
                                }

                                // 只有在不抑制事件时才触发 change 事件
                                if (!this._suppressChangeEvent) {
                                    const changeEvent = new Event('change', { bubbles: true });
                                    this.dispatchEvent(changeEvent);
                                }
                            }
                        }
                    }
                });

                // 初始化 selectedIndex（不触发 change 事件）
                selectElement._suppressChangeEvent = true;
                selectElement.selectedIndex = currentSelectedIndex;
                selectElement._suppressChangeEvent = false;

                // 添加 value 属性
                Object.defineProperty(selectElement, 'value', {
                    get: function () {
                        const selectedOption = this.querySelector('.dc_select_option.dc_selected');
                        return selectedOption ? selectedOption.getAttribute('data-value') : '';
                    },
                    set: function (val) {
                        const options = this.querySelectorAll('.dc_select_option');
                        let newSelectedOption = null;
                        const currentValue = this.value; // 获取当前值

                        // 如果值没有变化，直接返回，避免不必要的更新和事件触发
                        if (currentValue == val) {
                            return;
                        }

                        options.forEach(opt => {
                            if (opt.getAttribute('data-value') == val) {
                                opt.classList.add('dc_selected');
                                this.querySelector('.dc_select_display').textContent = opt.textContent;
                                newSelectedOption = opt;
                            } else {
                                opt.classList.remove('dc_selected');
                            }
                        });

                        // 更新 selectedIndex（但不触发 change 事件，避免循环）
                        const newIndex = Array.from(options).findIndex(opt => opt.getAttribute('data-value') == val);
                        if (newIndex >= 0) {
                            // 抑制 change 事件，直接更新内部状态
                            this._suppressChangeEvent = true;
                            // 直接更新内部状态，避免通过 selectedIndex setter 触发事件
                            const currentOptions = this.querySelectorAll('.dc_select_option');
                            currentOptions.forEach(opt => opt.classList.remove('dc_selected'));
                            if (currentOptions[newIndex]) {
                                currentOptions[newIndex].classList.add('dc_selected');
                            }
                            this._suppressChangeEvent = false;

                            // 手动触发 change 事件（只触发一次）
                            const changeEvent = new Event('change', { bubbles: true });
                            this.dispatchEvent(changeEvent);
                        }

                        // 如果下拉框是打开的，滚动到新选中的选项
                        if (this.classList.contains('dc_open') && newSelectedOption) {
                            setTimeout(() => {
                                newSelectedOption.scrollIntoView({
                                    behavior: 'auto',
                                    block: 'nearest',
                                    inline: 'nearest'
                                });
                            }, 10);
                        }
                    }
                });

                // 添加 length 属性
                Object.defineProperty(selectElement, 'length', {
                    get: function () {
                        return this.querySelectorAll('.dc_select_option').length;
                    }
                });

                // 添加事件监听
                const display = selectElement.querySelector('.dc_select_display');
                const dropdown = selectElement.querySelector('.dc_select_dropdown');
                const optionElements = selectElement.querySelectorAll('.dc_select_option');

                // 点击显示/隐藏下拉框
                display.addEventListener('click', function (e) {
                    e.stopPropagation();
                    const isOpen = selectElement.classList.contains('dc_open');
                    // 关闭所有其他下拉框
                    document.querySelectorAll('.dc_custom_select.dc_open').forEach(el => {
                        if (el !== selectElement) {
                            el.classList.remove('dc_open');
                        }
                    });
                    selectElement.classList.toggle('dc_open', !isOpen);

                    // 如果打开下拉框，滚动到已选中的选项
                    if (!isOpen) {
                        // 使用 setTimeout 确保下拉框已经显示
                        setTimeout(function () {
                            const selectedOption = dropdown.querySelector('.dc_select_option.dc_selected');
                            if (selectedOption) {
                                // 滚动到选中选项，使其可见
                                selectedOption.scrollIntoView({
                                    behavior: 'auto',
                                    block: 'nearest',
                                    inline: 'nearest'
                                });
                            }
                        }, 10);
                    }
                });

                // 点击选项
                optionElements.forEach((option, index) => {
                    option.addEventListener('click', function (e) {
                        e.stopPropagation();
                        const value = this.getAttribute('data-value');
                        const text = this.textContent;

                        // 更新选中状态
                        optionElements.forEach(opt => opt.classList.remove('dc_selected'));
                        this.classList.add('dc_selected');
                        display.textContent = text;
                        selectElement.selectedIndex = index;

                        // 触发 change 事件
                        const changeEvent = new Event('change', { bubbles: true });
                        selectElement.dispatchEvent(changeEvent);

                        // 关闭下拉框
                        selectElement.classList.remove('dc_open');
                    });
                });

                // 点击外部关闭下拉框
                document.addEventListener('click', function (e) {
                    if (!selectElement.contains(e.target)) {
                        selectElement.classList.remove('dc_open');
                    }
                });

                return selectElement;
            };

            theTool.getSelects = function (list, values) {
                const self = this;
                const selects = {};

                // 查找自定义下拉组件
                for (let x of self.dom.head.querySelectorAll('.dc_custom_select')) {
                    if (list.indexOf(x.name) >= 0) {
                        selects[x.name] = x;

                        if (self.isObject(values)) {
                            values[x.name] = parseInt(x.value, 10);
                        }
                    }
                }

                // 兼容原有的 select 元素
                for (let x of self.dom.head.querySelectorAll('select')) {
                    if (list.indexOf(x.name) >= 0 && !selects[x.name]) {
                        selects[x.name] = x;

                        if (self.isObject(values)) {
                            values[x.name] = parseInt(x.value, 10);
                        }
                    }
                }
                return selects;
            };

            // 创建面板
            theTool.buildPanel = function (rootElement) {
                const self = this;

                if (self.cacheApi.settings.date) {
                    self.cacheDate = {
                        time: self.cacheApi.defDate.time,
                    };

                    if (typeof self.cacheApi.defDate.start === 'number' && typeof self.cacheApi.defDate.end === 'number') {
                        self.cacheDate.startTime = self.cacheApi.defDate.start;
                        self.cacheDate.endTime = self.cacheApi.defDate.end;
                    }
                } else {
                    self.cacheDate = {};
                }
                //格式化innerHTML
                self.dom.sidebar.innerHTML = '';
                self.dom.wrapper.innerHTML = '';
                self.dom.head.innerHTML = '';
                self.dom.main.innerHTML = '';
                self.dom.timeSet.innerHTML = '';
                // 基础样式
                const classValue = ['dc_cxcalendar', 'm_' + self.cacheApi.settings.type];

                if (self.cacheApi.settings.mode === 'range') {
                    classValue.push('dc_range');
                }
                if (typeof self.cacheApi.settings.baseClass === 'string' && self.cacheApi.settings.baseClass.length) {
                    classValue.push(self.cacheApi.settings.baseClass);
                }
                self.dom.panel.className = classValue.join(' ');

                const splitHtml = '<em></em>';
                // const prevNextHtml = '<a class="prev" href="javascript://" rel="prev"></a><a class="next" href="javascript://" rel="next"></a>';
                const prevHtml = `<div class='dc_prev-next-box'>
                                    <div class='dc_prevYear' name='prevYear'>
                                        <span class="dc_arrow-left"></span>
                                        <span class="dc_arrow-left"></span>
                                    </div>
                                    <div class='dc_prevMonth'>
                                        <span class="dc_arrow-left" name='prev'></span>
                                    </div>
                                 </div>`;

                const prevNextHtml = `<div class='dc_prev-next-box'>
                                        <div class='dc_nextMonth' >
                                            <span class="dc_arrow-right" name='next'></span>
                                        </div>
                                        <div class='dc_nextYear' name='next'>
                                            <span class="dc_arrow-right"></span>
                                            <span class="dc_arrow-right"></span>
                                        </div>
                                    </div>`;

                const fillHtml = self.cacheApi.settings.mode === 'range' ? '<section class="dc_fill"></section>' : '';


                let html = `<div class='dc_prev-next-box-group'>` + prevHtml + '<section>';
                // let html ='<div><section>';

                // 年份选择框 - 使用自定义下拉组件
                let yearSelectElement = null;
                let monthSelectElement = null;

                if (['month', 'date', 'datetime'].indexOf(self.cacheApi.settings.type) >= 0) {
                    const yearOptions = [];
                    for (let i = self.cacheApi.minDate.year; i <= self.cacheApi.maxDate.year; i++) {
                        yearOptions.push({ value: i, text: i.toString() });
                    }
                    yearSelectElement = self.createCustomSelect('year', yearOptions, self.cacheApi.defDate.year);
                    yearSelectElement.className += ' dc_year';

                } else if (self.cacheApi.settings.type === 'year') {
                    const start = Math.floor(self.cacheApi.minDate.year / 10) * 10;
                    const yearOptions = [];
                    for (let i = start; i <= self.cacheApi.maxDate.year; i += self.cacheApi.settings.yearNum) {
                        const end = i + self.cacheApi.settings.yearNum - 1;
                        yearOptions.push({ value: i, text: i + ' - ' + end });
                    }
                    yearSelectElement = self.createCustomSelect('year', yearOptions, start);
                    yearSelectElement.className += ' dc_year';
                }

                if (['date', 'datetime'].indexOf(self.cacheApi.settings.type) >= 0) {
                    html += splitHtml;
                    // 月份选择框将在 rebuildMonthSelect 中创建
                    html += '<span class="dc_month_placeholder"></span>';
                    html += splitHtml;
                    html += '</section>';
                    html += fillHtml;
                    html += prevNextHtml;
                    html += '</div>';

                    self.dom.head.innerHTML = html;

                    // 插入年份选择框
                    if (yearSelectElement) {
                        const section = self.dom.head.querySelector('section');
                        if (section) {
                            section.insertBefore(yearSelectElement, section.firstChild);
                        }
                    }
                    self.dom.dateSet.className = 'dc_days';

                    self.dom.main.insertAdjacentElement('beforeend', self.dom.dateSet);
                    self.dom.wrapperBody.insertAdjacentElement('beforeend', self.dom.main);
                    self.dom.wrapperBody.insertAdjacentElement('afterbegin', self.dom.head);
                    self.dom.wrapper.insertAdjacentElement('afterbegin', self.dom.wrapperBody);
                    self.buildFlipFunc();
                    if (self.cacheApi.settings.type === 'datetime') {
                        self.buildDateTimes();

                    } else {
                        self.buildDate();
                    }
                    self.rebuildMonthSelect();
                    self.gotoDate([self.cacheApi.defDate.year, self.cacheApi.defDate.month].join('-'));

                    // 检查是否需要隐藏"昨天"和"上月"按钮
                    var isMinDateTodayForDateFieldElement = false;
                    //获取当前元素中的自定义属性isMinDateTodayForDateFieldElement="true"
                    var currentElement = rootElement.GetElementProperties(rootElement.CurrentElement());
                    if (currentElement && currentElement.Attributes && currentElement.Attributes.isMinDateTodayForDateFieldElement) {
                        isMinDateTodayForDateFieldElement = currentElement.Attributes.isMinDateTodayForDateFieldElement;
                    }
                    isMinDateTodayForDateFieldElement = (isMinDateTodayForDateFieldElement === "true" || isMinDateTodayForDateFieldElement === true);

                    var shouldHideYesterdayAndLastMonth = isMinDateTodayForDateFieldElement && (self.cacheApi.settings.type === 'date' || self.cacheApi.settings.type === 'datetime');

                    var sidebarHTML = `<ul><li><span class='dc_today'>今天</span></li>`;
                    if (!shouldHideYesterdayAndLastMonth) {
                        sidebarHTML += `<li><span class='dc_yesterday'>昨天</span></li><li><span class='dc_lastMonth'>上月</span></li>`;
                    }
                    sidebarHTML += `<li><span class='dc_nextMonth'>下月</span></li></ul>`;
                    self.dom.sidebar.innerHTML = sidebarHTML;
                    self.dom.panel.insertAdjacentElement('afterbegin', self.dom.sidebar);

                } else if (self.cacheApi.settings.type === 'time') {
                    //if (self.dom.wrapperBody.contains(self.dom.head)) {
                    //    self.dom.wrapperBody.removeChild(self.dom.head);
                    //    //self.dom.wrapper.insertAdjacentElement('afterbegin', self.dom.wrapperBody);
                    //}
                    self.dom.wrapperBody.insertAdjacentElement('afterbegin', self.dom.head);
                    self.dom.panel.className += ' dc_only-time';
                    self.dom.wrapper.insertAdjacentElement('afterbegin', self.dom.wrapperBody);
                    self.buildTimes();

                } else if (self.cacheApi.settings.type === 'month') {
                    html += splitHtml;
                    html += '</section>';
                    html += fillHtml;
                    html += prevNextHtml;
                    html += '</div>';

                    self.dom.head.innerHTML = html;
                    self.dom.dateSet.className = 'dc_months';

                    self.dom.main.insertAdjacentElement('beforeend', self.dom.dateSet);
                    self.dom.wrapperBody.insertAdjacentElement('beforeend', self.dom.main);
                    self.dom.wrapperBody.insertAdjacentElement('afterbegin', self.dom.head);
                    self.dom.wrapper.insertAdjacentElement('afterbegin', self.dom.wrapperBody);
                    self.buildFlipFunc();

                    self.gotoDate(self.cacheApi.defDate.year);

                } else if (self.cacheApi.settings.type === 'year') {
                    html += '</section>';
                    html += fillHtml;
                    html += prevNextHtml;
                    html += '</div>';

                    self.dom.head.innerHTML = html;

                    // 插入年份选择框
                    if (yearSelectElement) {
                        const section = self.dom.head.querySelector('section');
                        if (section) {
                            section.insertBefore(yearSelectElement, section.firstChild);
                        }
                    }

                    self.dom.dateSet.className = 'dc_years';

                    self.dom.main.insertAdjacentElement('beforeend', self.dom.dateSet);
                    self.dom.wrapperBody.insertAdjacentElement('beforeend', self.dom.main);
                    self.dom.wrapperBody.insertAdjacentElement('afterbegin', self.dom.head);
                    self.dom.wrapper.insertAdjacentElement('afterbegin', self.dom.wrapperBody);
                    self.buildFlipFunc();

                    self.gotoDate(self.cacheApi.defDate.year);
                }

                self.buildActs();
            };

            // 构建操作按钮
            theTool.buildActs = function () {
                const self = this;
                const nowDate = new Date();
                const nowTime = nowDate.getTime();
                const list = [];

                if (self.cacheApi.settings.button.today !== false && self.cacheApi.settings.mode !== 'range' && self.cacheApi.minDate.time <= nowTime && self.cacheApi.maxDate.time >= nowTime) {
                    list.push('dc_today');
                }
                if (self.cacheApi.settings.button.clear !== false) {
                    list.push('dc_clear');
                }
                if (self.cacheApi.settings.mode === 'range' || ['datetime', 'time', 'date'].indexOf(self.cacheApi.settings.type) >= 0) {
                    list.push('dc_confirm');
                }
                let html = '';

                for (let x of list) {
                    html += '<a class="' + x + '" href="javascript://" rel="' + x + '"></a>';
                }
                if (html.length) {
                    self.dom.acts.innerHTML = html;
                    self.dom.content.insertAdjacentElement('beforeend', self.dom.acts);

                } else if (self.dom.content.contains(self.dom.acts)) {
                    self.dom.content.removeChild(self.dom.acts);
                }
            };

            // 重新构建月份选项
            theTool.rebuildMonthSelect = function () {
                const self = this;
                const values = {};
                const selects = self.getSelects(['year', 'month'], values);
                let start = 1;
                let end = 12;

                if (values.year === self.cacheApi.minDate.year && values.year === self.cacheApi.maxDate.year) {
                    start = self.cacheApi.minDate.month;
                    end = self.cacheApi.maxDate.month;
                } else if (values.year === self.cacheApi.minDate.year) {
                    start = self.cacheApi.minDate.month;
                } else if (values.year === self.cacheApi.maxDate.year) {
                    end = self.cacheApi.maxDate.month;
                }

                // 构建月份选项
                const monthOptions = [];
                for (let i = start; i <= end; i++) {
                    monthOptions.push({
                        value: i,
                        text: self.cacheApi.settings.language.monthList[i - 1],
                        selected: values.month === i
                    });
                }

                // 如果是自定义下拉组件，更新或创建
                if (selects.month && selects.month.classList && selects.month.classList.contains('dc_custom_select')) {
                    // 更新现有自定义下拉组件
                    const currentValue = selects.month.value || values.month || start;
                    const dropdown = selects.month.querySelector('.dc_select_dropdown');
                    const display = selects.month.querySelector('.dc_select_display');

                    // 清空选项
                    dropdown.innerHTML = '';

                    // 添加新选项
                    monthOptions.forEach((opt, index) => {
                        const optionEl = document.createElement('div');
                        optionEl.className = 'dc_select_option' + (opt.selected ? ' dc_selected' : '');
                        optionEl.setAttribute('data-value', opt.value);
                        optionEl.textContent = opt.text;

                        // 添加点击事件
                        optionEl.addEventListener('click', function (e) {
                            e.stopPropagation();
                            const value = this.getAttribute('data-value');
                            const text = this.textContent;

                            // 更新选中状态
                            dropdown.querySelectorAll('.dc_select_option').forEach(opt => opt.classList.remove('dc_selected'));
                            this.classList.add('dc_selected');
                            display.textContent = text;
                            selects.month.selectedIndex = index;

                            // 触发 change 事件
                            const changeEvent = new Event('change', { bubbles: true });
                            selects.month.dispatchEvent(changeEvent);

                            // 关闭下拉框
                            selects.month.classList.remove('dc_open');
                        });

                        dropdown.appendChild(optionEl);
                    });

                    // 更新显示值和选中索引（不触发 change 事件，因为这是内部更新）
                    const selectedOption = monthOptions.find(opt => opt.selected) || monthOptions[0];
                    display.textContent = selectedOption.text;
                    // 直接更新内部状态，避免触发 change 事件
                    const selectedIndex = monthOptions.findIndex(opt => opt.selected);
                    const finalIndex = selectedIndex >= 0 ? selectedIndex : 0;
                    const allOptions = dropdown.querySelectorAll('.dc_select_option');
                    allOptions.forEach(opt => opt.classList.remove('dc_selected'));
                    if (allOptions[finalIndex]) {
                        allOptions[finalIndex].classList.add('dc_selected');
                    }
                    // 更新 selectedIndex 属性（但不触发事件）
                    selects.month._suppressChangeEvent = true;
                    // 通过设置 selectedIndex 来更新内部状态，但由于抑制了事件，不会触发 change
                    selects.month.selectedIndex = finalIndex;
                    selects.month._suppressChangeEvent = false;

                    // 更新 options 属性
                    selects.month.options = monthOptions.map((opt, idx) => ({
                        value: opt.value,
                        text: opt.text,
                        selected: opt.selected,
                        index: idx
                    }));

                    // 如果下拉框是打开的，滚动到已选中的选项
                    if (selects.month.classList.contains('dc_open')) {
                        setTimeout(function () {
                            const selectedOption = dropdown.querySelector('.dc_select_option.dc_selected');
                            if (selectedOption) {
                                selectedOption.scrollIntoView({
                                    behavior: 'auto',
                                    block: 'nearest',
                                    inline: 'nearest'
                                });
                            }
                        }, 10);
                    }

                } else if (selects.month) {
                    // 兼容原有的 select 元素
                    let html = '';
                    for (let i = start; i <= end; i++) {
                        html += '<option value="' + i + '"';
                        if (values.month === i) {
                            html += ' selected';
                        }
                        html += '>' + self.cacheApi.settings.language.monthList[i - 1] + '</option>';
                    }
                    selects.month.innerHTML = html;
                } else {
                    // 创建新的自定义下拉组件
                    const placeholder = self.dom.head.querySelector('.dc_month_placeholder');
                    if (placeholder) {
                        const selectedValue = values.month || start;
                        const monthSelectElement = self.createCustomSelect('month', monthOptions, selectedValue);
                        monthSelectElement.className += ' dc_month';
                        placeholder.parentNode.replaceChild(monthSelectElement, placeholder);
                    }
                }
            };

            // 构建日期列表
            theTool.buildDays = function (year, month) {
                const self = this;

                if (!self.isInteger(year) || !self.isInteger(month)) {
                    return;
                }
                const theDate = new Date(year, month - 1, 1);
                year = theDate.getFullYear();
                month = theDate.getMonth() + 1;

                if (year < self.cacheApi.minDate.year || (year === self.cacheApi.minDate.year && month < self.cacheApi.minDate.month)) {
                    year = self.cacheApi.minDate.year;
                    month = self.cacheApi.minDate.month;

                    // } else if (year > self.cacheApi.maxDate.year || (year === self.cacheApi.maxDate.year && month > self.cacheApi.maxDate.month)) {
                    //   year = self.cacheApi.maxDate.year;
                    //   month = self.cacheApi.maxDate.month;
                }
                const jsMonth = month - 1;
                const monthDays = self.getMonthDays(year);
                const sameMonthDate = new Date(year, jsMonth, 1);
                const nowDate = new Date();
                const nowText = [nowDate.getFullYear(), nowDate.getMonth() + 1, nowDate.getDate()].join('-');
                const selectedText = self.formatDate('Y-n-j', self.cacheDate.time);

                // 获取当月第一天
                let monthFirstDay = sameMonthDate.getDay() - self.cacheApi.settings.weekStart;
                if (monthFirstDay < 0) {
                    monthFirstDay += 7;
                }
                // 获取周末位置
                const saturday = 6 - self.cacheApi.settings.weekStart;
                const sunday = (7 - self.cacheApi.settings.weekStart) % 7;

                // 自适应或固定行数
                const monthDayMax = self.cacheApi.settings.lockRow ? 42 : Math.ceil((monthDays[jsMonth] + monthFirstDay) / 7) * 7;

                // 日期范围值
                const rangeValue = {};
                let rangeMaxTime = 0;

                if (typeof self.cacheDate.startTime === 'number') {
                    rangeValue.start = parseInt(self.formatDate('Ymd', self.cacheDate.startTime), 10);

                    if (typeof self.cacheApi.settings.rangeMaxDay === 'number' && self.cacheApi.settings.rangeMaxDay) {
                        rangeMaxTime = self.cacheDate.startTime + self.cacheApi.settings.rangeMaxDay * 86400000;
                    }
                    if (typeof self.cacheDate.endTime === 'number') {
                        rangeValue.end = parseInt(self.formatDate('Ymd', self.cacheDate.endTime), 10);
                    } else {
                        rangeValue.end = rangeValue.start;
                    }
                }
                let html = '<ul>';

                // 星期排序
                for (let i = 0; i < 7; i++) {
                    html += '<li class="dc_week';

                    // 高亮周末
                    if (i === saturday) {
                        html += ' sat';
                    } else if (i === sunday) {
                        html += ' sun';
                    }
                    html += '">' + self.cacheApi.settings.language.weekList[(i + self.cacheApi.settings.weekStart) % 7] + '</li>';
                }
                for (let i = 0; i < monthDayMax; i++) {
                    const classValue = [];
                    let todayYear = year;
                    let todayMonth = month;
                    let todayNum = i - monthFirstDay + 1;

                    // 填充上月和下月的日期
                    if (todayNum <= 0) {
                        classValue.push('dc_other');

                        if (todayMonth <= 1) {
                            todayYear--;
                            todayMonth = 12;
                            todayNum = monthDays[11] + todayNum;
                        } else {
                            todayMonth--;
                            todayNum = monthDays[jsMonth - 1] + todayNum;
                        }
                    } else if (todayNum > monthDays[jsMonth]) {
                        classValue.push('dc_other');

                        if (todayMonth >= 12) {
                            todayYear++;
                            todayMonth = 1;
                            todayNum = todayNum - monthDays[0];
                        } else {
                            todayMonth++;
                            todayNum -= monthDays[jsMonth];
                        }
                    }
                    const todayDate = new Date(todayYear, todayMonth - 1, todayNum);
                    const todayTime = todayDate.getTime();
                    const todayText = [todayYear, todayMonth, todayNum].join('-');
                    const todayInt = parseInt([todayYear, self.fillLeadZero(todayMonth, 2), self.fillLeadZero(todayNum, 2)].join(''), 10);
                    let todayName = '';

                    // 高亮已选择
                    if (self.cacheApi.settings.mode === 'range') {
                        if (todayInt === rangeValue.start || todayInt === rangeValue.end || (todayInt >= rangeValue.start && todayInt <= rangeValue.end)) {
                            classValue.push('DCcxCalendarSelected');

                            if (todayInt === rangeValue.start) {
                                classValue.push('dc_start');
                            } if (todayInt === rangeValue.end) {
                                classValue.push('dc_end');
                            }
                        }
                    } else if (todayText === selectedText) {
                        classValue.push('DCcxCalendarSelected');
                    }
                    // 高亮今天
                    if (todayText === nowText) {
                        classValue.push('dc_now');
                    }
                    // 高亮周末
                    if (i % 7 === saturday) {
                        classValue.push('dc_sat');
                    } else if (i % 7 === sunday) {
                        classValue.push('dc_sun');
                    }
                    if (rangeMaxTime && todayTime > rangeMaxTime) {
                        classValue.push('dc_del');

                        // 超出范围的无效日期
                    } else if (todayTime < self.cacheApi.minDate.time || todayTime > self.cacheApi.maxDate.time) {
                        classValue.push('dc_del');

                        // 不可选择的日期（星期）
                    } else if (Array.isArray(self.cacheApi.settings.disableWeek) && self.cacheApi.settings.disableWeek.length && self.cacheApi.settings.disableWeek.indexOf((i + self.cacheApi.settings.weekStart) % 7) >= 0) {
                        classValue.push('dc_del');

                        // 不可选择的日期
                    } else if (Array.isArray(self.cacheApi.settings.disableDay) && self.cacheApi.settings.disableDay.length) {
                        if (self.cacheApi.settings.disableDay.indexOf(String(todayNum)) >= 0 || self.cacheApi.settings.disableDay.indexOf([todayMonth, todayNum].join('-')) >= 0 || self.cacheApi.settings.disableDay.indexOf([todayYear, todayMonth, todayNum].join('-')) >= 0) {
                            classValue.push('dc_del');
                        }
                    }
                    // 判断是否有节假日
                    if (self.cacheApi.holiday) {
                        const keys = [
                            [todayYear, todayMonth, todayNum].join('-'),
                            [todayMonth, todayNum].join('-'),
                        ];

                        for (let x of keys) {
                            if (typeof self.cacheApi.holiday[x] === 'string') {
                                classValue.push('dc_holiday');
                                todayName = self.cacheApi.holiday[x];
                                break;
                            }
                        }
                    }
                    html += '<li';

                    if (classValue.length) {
                        html += ' class="' + classValue.join(' ') + '"';
                    }
                    if (classValue.indexOf('del') === -1) {
                        html += ' data-date="' + todayText + '"';
                    }
                    if (todayName.length) {
                        html += ' data-title="' + todayName + '"';
                    }
                    if (i % 7 === 0) {
                        html += ' data-week-num="' + self.getWeekNum(todayDate) + '"';
                    }
                    html += '>' + todayNum + '</li>';
                }
                html += '</ul>';

                return html;
            };

            // 构建时间选择
            theTool.buildTimes = function () {
                const self = this;
                const splitHtml = '<i></i>';
                let html = `<section class='dc_time-group'>`;

                html += '<input name="hour" class="dc_hour" min="0" max="23" autocomplete="off"/>';
                //html += '<select name="hour" class="hour" >';

                //for (let i = 0; i < 24; i += self.cacheApi.settings.hourStep) {
                //    const optionValue = self.fillLeadZero(i, 2);
                //    html += '<option value="' + optionValue + '">' + optionValue + '</option>';
                //}
                //html += '</select>';
                html += splitHtml;
                html += '<input name="mint" class="dc_mint" min="0" max="59" autocomplete="off"/>';
                //html += '<select name="mint" class="mint" >';

                //for (let i = 0; i < 60; i += self.cacheApi.settings.minuteStep) {
                //    const optionValue = self.fillLeadZero(i, 2);
                //    html += '<option value="' + optionValue + '">' + optionValue + '</option>';
                //}
                //html += '</select>';
                html += splitHtml;
                html += '<input name="secs" class="dc_secs" min="0" max="59" autocomplete="off"/>';

                //html += '<select name="secs" class="secs">';

                //for (let i = 0; i < 60; i += self.cacheApi.settings.secondStep) {
                //    const optionValue = self.fillLeadZero(i, 2);
                //    html += '<option value="' + optionValue + '">' + optionValue + '</option>';
                //}
                //html += '</select>';
                html += '</section>';

                if (self.cacheApi.settings.mode === 'range') {
                    html += html;
                }
                self.dom.timeSet.innerHTML += html;
                self.dom.head.insertAdjacentElement('afterbegin', self.dom.timeSet);
                //self.dom.main.insertAdjacentElement('beforeend', self.dom.timeSet);
                var hourEle = self.dom.timeSet.querySelector('.dc_hour');//时
                var mintEle = self.dom.timeSet.querySelector('.dc_mint');//分
                var secsEle = self.dom.timeSet.querySelector('.dc_secs');//秒

                function hourInput(e) {
                    if (e.target.value && e.target.value.length > 0) {
                        if (isNaN(e.target.value)) {
                            e.target.value = '0';
                        } else {
                            if (e.target.value > 23) {
                                e.target.value = '23';
                            } else if (e.target.value < 0) {
                                e.target.value = '0';
                            }
                            if (e.target.value.length > 1 && e.data) {
                                if (e.target.value > 9) {
                                    e.target.value = parseInt(e.target.value);
                                }
                                if (mintEle) {
                                    mintEle.select();
                                    mintEle.focus();
                                }
                            }
                            if (e.target.value.length < 2 && e.target.value < 10 && e.target.value != '0') {
                                e.target.value = '0' + e.target.value;
                            }
                        }
                    }
                }
                function mintInput(e) {
                    if (e.target.value && e.target.value.length > 0) {

                        if (isNaN(e.target.value)) {
                            e.target.value = '0';
                        } else {
                            if (e.target.value > 59) {
                                e.target.value = '59';
                            } else if (e.target.value < 0) {
                                e.target.value = '0';
                            }
                            if (e.target.value.length > 1 && e.data) {
                                if (e.target.value > 9) {
                                    e.target.value = parseInt(e.target.value);
                                }
                                if (secsEle) {
                                    secsEle.select();
                                    secsEle.focus();
                                }
                            }
                            if (e.target.value.length < 2 && e.target.value < 10 && e.target.value != '0') {
                                e.target.value = '0' + e.target.value;
                            }
                        }
                    }
                }
                function secsInput(e) {
                    if (e.target.value && e.target.value.length > 0) {
                        e.target.value = parseInt(e.target.value);
                        if (isNaN(e.target.value)) {
                            e.target.value = '0';
                        } else {
                            if (e.target.value > 59) {
                                e.target.value = '59';
                            } else if (e.target.value < 0) {
                                e.target.value = '0';
                            }
                            if (e.target.value < 10) {
                                e.target.value = '0' + e.target.value;
                            }
                        }
                    }
                }

                if (hourEle) {
                    hourEle.addEventListener('input', function (e) {
                        hourInput(e);
                    });
                    hourEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38) {
                            e.target.value = parseInt(e.target.value) + 1;
                            hourInput(e);
                        }
                        if (key === 40) {
                            e.target.value = parseInt(e.target.value) - 1;
                            hourInput(e);
                        }
                    });
                }
                // var mintEle = self.dom.timeSet.querySelector('.mint');
                if (mintEle) {
                    mintEle.addEventListener('input', function (e) {
                        mintInput(e);
                    });
                    mintEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38) {
                            e.target.value = parseInt(e.target.value) + 1;
                            mintInput(e);
                        }
                        if (key === 40) {
                            e.target.value = parseInt(e.target.value) - 1;
                            mintInput(e);
                        }
                    });
                }
                // var secsEle = self.dom.timeSet.querySelector('.secs');
                if (secsEle) {
                    secsEle.addEventListener('input', function (e) {
                        secsInput(e);
                    });
                    secsEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38) {
                            e.target.value = parseInt(e.target.value) + 1;
                            secsInput(e);
                        }
                        if (key === 40) {
                            e.target.value = parseInt(e.target.value) - 1;
                            secsInput(e);
                        }
                    });
                }
                self.setDateValues();
                self.setTimesValues();
            };
            // 日期下拉年月日输入框绑定事件
            theTool.bindYearMonthDayInputEvents = function () {
                const self = this;
                const yearEle = self.dom.timeSet.querySelector('.dc_year');// 年
                const monthEle = self.dom.timeSet.querySelector('.dc_month');// 月
                const dayEle = self.dom.timeSet.querySelector('.dc_day');// 日

                // 获取指定年月的最大天数
                const getMaxDayInMonth = function (year, month) {
                    if (!year || !month) return 31;
                    const monthDays = theTool.getMonthDays(parseInt(year, 10));
                    return monthDays[parseInt(month, 10) - 1] || 31;
                };

                if (yearEle) {
                    const yearInputEvent = function (e) {
                        const target = e.target;
                        const valueStr = String(target.value || '');
                        if (valueStr && valueStr.length > 0) {
                            const numValue = parseInt(valueStr, 10);
                            const minYear = 1900;
                            const maxYear = 2300;
                            if (isNaN(numValue)) {
                                const currentTime = new Date();
                                target.value = String(currentTime.getFullYear());
                            } else {
                                let finalYear = numValue;
                                if (finalYear < minYear) finalYear = minYear;
                                if (finalYear > maxYear) finalYear = maxYear;
                                target.value = String(finalYear);

                                // 如果输入了4位数字，自动跳转到月份输入框
                                if (valueStr.length >= 4 && e.data && monthEle) {
                                    monthEle.select();
                                    monthEle.focus();
                                }
                            }
                        }
                    };
                    yearEle.addEventListener('input', function (e) {
                        yearInputEvent(e);
                    });
                    yearEle.addEventListener('change', function (e) {
                        const headerYearSelect = self.findSelectElement(self.dom.head, 'dc_year');
                        if (headerYearSelect) {
                            headerYearSelect.value = e.target.value;
                        }
                        self.gotoDate();
                        const dateStr = e.target.value + '-' + monthEle.value + '-' + dayEle.value;
                        const selectDate = theTool.formatDate('Y-m-d', dateStr);
                        self.locateDay(selectDate);
                    });
                    yearEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        const headerYearSelect = self.findSelectElement(self.dom.head, 'dc_year');
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38 || key === 40) {
                            const increment = key === 38 ? 1 : -1;
                            const minYear = 1900;
                            const maxYear = 2300;
                            let newYear = parseInt(e.target.value, 10) + increment;
                            if (newYear < minYear) newYear = minYear;
                            if (newYear > maxYear) newYear = maxYear;
                            e.target.value = String(newYear);
                            if (headerYearSelect) {
                                headerYearSelect.value = newYear;
                            }
                            self.gotoDate();
                            const dateStr = newYear + '-' + monthEle.value + '-' + dayEle.value;
                            const selectDate = theTool.formatDate('Y-m-d', dateStr);
                            self.locateDay(selectDate);
                            yearInputEvent(e);
                        }
                    });
                }
                if (monthEle) {
                    const monthInputEvent = function (e) {
                        const minValue = 1;
                        const maxValue = 12;
                        const target = e.target;
                        let valueStr = String(target.value || '');
                        if (valueStr && valueStr.length > 0) {
                            const numValue = parseInt(valueStr, 10);
                            if (isNaN(numValue)) {
                                target.value = String(minValue);
                            } else {
                                let finalValue = numValue;
                                if (finalValue > maxValue) {
                                    finalValue = maxValue;
                                } else if (finalValue < minValue) {
                                    finalValue = minValue;
                                }
                                valueStr = String(finalValue);
                                target.value = valueStr;

                                if (valueStr.length > 1 && e.data) {
                                    if (finalValue > 9) {
                                        target.value = String(finalValue);
                                        valueStr = target.value;
                                    }
                                    if (dayEle) {
                                        dayEle.select();
                                        dayEle.focus();
                                    }
                                }
                                if (valueStr.length < 2 && finalValue < 10 && finalValue != 0) {
                                    target.value = '0' + valueStr;
                                }
                            }
                        }
                    };
                    monthEle.addEventListener('input', function (e) {
                        monthInputEvent(e);
                    });
                    monthEle.addEventListener('change', function (e) {
                        e.target.value = self.fillLeadZero(e.target.value, 2);
                        const headerMonthSelect = self.findSelectElement(self.dom.head, 'dc_month');
                        if (headerMonthSelect) {
                            headerMonthSelect.value = parseInt(e.target.value, 10);
                        }
                        self.gotoDate();
                        const dateStr = yearEle.value + '-' + e.target.value + '-' + dayEle.value;
                        const selectDate = theTool.formatDate('Y-m-d', dateStr);
                        self.locateDay(selectDate);
                    });
                    monthEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        const headerMonthSelect = self.findSelectElement(self.dom.head, 'dc_month');
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38 || key === 40) {
                            const increment = key === 38 ? 1 : -1;
                            let newMonth = parseInt(e.target.value, 10) + increment;
                            // 判断是否允许月份循环，默认为false（不允许循环）
                            const allowMonthCycle = false;
                            if (allowMonthCycle) {
                                // 允许循环：1变成12，12变成1
                                if (newMonth < 1) newMonth = 12;
                                if (newMonth > 12) newMonth = 1;
                            } else {
                                // 不允许循环：限制在1-12范围内
                                if (newMonth < 1) newMonth = 1;
                                if (newMonth > 12) newMonth = 12;
                            }
                            e.target.value = self.fillLeadZero(String(newMonth), 2);
                            if (headerMonthSelect) {
                                headerMonthSelect.value = newMonth;
                            }
                            self.gotoDate();
                            const dateStr = yearEle.value + '-' + newMonth + '-' + dayEle.value;
                            const selectDate = theTool.formatDate('Y-m-d', dateStr);
                            self.locateDay(selectDate);
                            monthInputEvent(e);
                        }
                    });
                }
                if (dayEle) {
                    const dayInputEvent = function (e) {
                        const target = e.target;
                        const valueStr = String(target.value || '');
                        if (valueStr && valueStr.length > 0) {
                            const numValue = parseInt(valueStr, 10);
                            if (isNaN(numValue)) {
                                target.value = '01';
                            } else {
                                const year = parseInt(yearEle ? yearEle.value : new Date().getFullYear(), 10);
                                const month = parseInt(monthEle ? monthEle.value : new Date().getMonth() + 1, 10);
                                const maxDay = getMaxDayInMonth(year, month);
                                const minValue = 1;

                                let finalValue = numValue;
                                if (finalValue > maxDay) {
                                    finalValue = maxDay;
                                } else if (finalValue < minValue) {
                                    finalValue = minValue;
                                }
                                target.value = self.fillLeadZero(String(finalValue), 2);
                            }
                        }
                    };
                    dayEle.addEventListener('input', function (e) {
                        dayInputEvent(e);
                    });
                    dayEle.addEventListener('change', function (e) {
                        e.target.value = self.fillLeadZero(e.target.value, 2);
                        const dateStr = yearEle.value + '-' + monthEle.value + '-' + e.target.value;
                        const selectDate = theTool.formatDate('Y-m-d', dateStr);
                        self.locateDay(selectDate);
                    });
                    dayEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38 || key === 40) {
                            const increment = key === 38 ? 1 : -1;
                            const year = parseInt(yearEle ? yearEle.value : new Date().getFullYear(), 10);
                            const month = parseInt(monthEle ? monthEle.value : new Date().getMonth() + 1, 10);
                            const maxDay = getMaxDayInMonth(year, month);
                            let newDay = parseInt(e.target.value, 10) + increment;
                            const allowDayCycle = false;
                            if (allowDayCycle) {
                                // 允许循环：1变成31，31变成1
                                if (newDay < 1) newDay = maxDay;
                                if (newDay > maxDay) newDay = 1;
                            } else {
                                // 不允许循环：限制在1-maxDay范围内
                                if (newDay < 1) newDay = 1;
                                if (newDay > maxDay) newDay = maxDay;
                            }
                            e.target.value = self.fillLeadZero(String(newDay), 2);
                            dayInputEvent(e);
                            const dateStr = yearEle.value + '-' + monthEle.value + '-' + e.target.value;
                            const selectDate = theTool.formatDate('Y-m-d', dateStr);
                            self.locateDay(selectDate);
                        }
                    });
                }
            };
            // 构建日期选择
            theTool.buildDate = function () {
                const self = this;
                let html = `<section class='dc_date-group'>`;
                html += '<input name="year" class="dc_year" min="1900" max="2300" autocomplete="off"/>';
                html += '<span>年</span>';
                html += '<input name="month" class="dc_month" min="1" max="12" autocomplete="off"/>';
                html += '<span>月</span>';
                html += '<input name="day" class="dc_day" min="1" max="31" autocomplete="off"/>';
                html += '<span>日</span>';
                html += '</section>';
                if (self.cacheApi.settings.mode === 'range') {
                    html += html;
                }
                self.dom.timeSet.innerHTML = html;
                //self.dom.head.insertAdjacentElement('afterbegin', self.dom.timeSet);
                self.dom.main.insertAdjacentElement('beforeend', self.dom.timeSet);
                self.bindYearMonthDayInputEvents();
                self.setDateValues();
            };
            // 构建日期时间选择
            theTool.buildDateTimes = function () {
                const self = this;
                const splitHtml = '<i></i>';
                // 日期
                let html = `<section class='dc_date-group'>`;
                html += '<input name="year" class="dc_year" min="1900" max="2300" autocomplete="off"/>';
                html += '<span>年</span>';
                html += '<input name="month" class="dc_month" min="1" max="12" autocomplete="off"/>';
                html += '<span>月</span>';
                html += '<input name="day" class="dc_day" min="1" max="31" autocomplete="off"/>';
                html += '<span>日</span>';
                html += '</section>';
                // 时间
                html += `<section class='dc_time-group'>`;
                html += '<input name="hour" class="dc_hour" min="0" max="23" autocomplete="off"/>';
                html += splitHtml;
                html += '<input name="mint" class="dc_mint" min="0" max="59" autocomplete="off"/>';
                html += splitHtml;
                html += '<input name="secs" class="dc_secs" min="0" max="59" autocomplete="off"/>';
                html += '</section>';
                if (self.cacheApi.settings.mode === 'range') {
                    html += html;
                }
                self.dom.timeSet.innerHTML = html;
                //self.dom.head.insertAdjacentElement('afterbegin', self.dom.timeSet);
                self.dom.main.insertAdjacentElement('beforeend', self.dom.timeSet);
                self.bindYearMonthDayInputEvents();
                var hourEle = self.dom.timeSet.querySelector('.dc_hour');//时
                var mintEle = self.dom.timeSet.querySelector('.dc_mint');//分
                var secsEle = self.dom.timeSet.querySelector('.dc_secs');//秒
                function hourInput(e) {
                    if (e.target.value && e.target.value.length > 0) {
                        //e.target.value = parseInt(e.target.value);
                        if (isNaN(e.target.value)) {
                            e.target.value = '0';
                        } else {
                            if (e.target.value > 23) {
                                e.target.value = '23';
                            } else if (e.target.value < 0) {
                                e.target.value = '0';
                            }
                            if (e.target.value.length > 1 && e.data) {
                                if (e.target.value > 9) {
                                    e.target.value = parseInt(e.target.value);
                                }
                                if (mintEle) {
                                    mintEle.select();
                                    mintEle.focus();
                                }
                            }
                            if (e.target.value.length < 2 && e.target.value < 10 && e.target.value != '0') {
                                e.target.value = '0' + e.target.value;
                            }
                        }
                    } else {
                        //e.target.value = '0';
                    }
                }
                function mintInput(e) {
                    if (e.target.value && e.target.value.length > 0) {
                        // console.log(e.target.value);
                        //e.target.value = parseInt(e.target.value);

                        if (isNaN(e.target.value)) {
                            e.target.value = '0';
                        } else {
                            if (e.target.value > 59) {
                                e.target.value = '59';
                            } else if (e.target.value < 0) {
                                e.target.value = '0';
                            }
                            if (e.target.value.length > 1 && e.data) {
                                if (e.target.value > 9) {
                                    e.target.value = parseInt(e.target.value);
                                }
                                if (secsEle) {
                                    secsEle.select();
                                    secsEle.focus();
                                }
                            }
                            if (e.target.value.length < 2 && e.target.value < 10 && e.target.value != '0') {
                                e.target.value = '0' + e.target.value;
                            }
                        }
                    } else {
                        //e.target.value = '0';
                    }
                }
                function secsInput(e) {
                    if (e.target.value && e.target.value.length > 0) {
                        e.target.value = parseInt(e.target.value);
                        if (isNaN(e.target.value)) {
                            e.target.value = '0';
                        } else {
                            if (e.target.value > 59) {
                                e.target.value = '59';
                            } else if (e.target.value < 0) {
                                e.target.value = '0';
                            }
                            if (e.target.value < 10) {
                                e.target.value = '0' + e.target.value;
                            }
                        }
                    } else {
                        //e.target.value = '0';
                    }
                }
                if (hourEle) {
                    hourEle.addEventListener('input', function (e) {
                        hourInput(e);
                    });
                    hourEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38) {
                            e.target.value = parseInt(e.target.value) + 1;
                            hourInput(e);
                        }
                        if (key === 40) {
                            e.target.value = parseInt(e.target.value) - 1;
                            hourInput(e);
                        }
                    });
                }
                // var mintEle = self.dom.timeSet.querySelector('.mint');
                if (mintEle) {
                    mintEle.addEventListener('input', function (e) {
                        mintInput(e);
                    });
                    mintEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38) {
                            e.target.value = parseInt(e.target.value) + 1;
                            mintInput(e);
                        }
                        if (key === 40) {
                            e.target.value = parseInt(e.target.value) - 1;
                            mintInput(e);
                        }
                    });
                }
                // var secsEle = self.dom.timeSet.querySelector('.secs');
                if (secsEle) {
                    secsEle.addEventListener('input', function (e) {
                        secsInput(e);
                    });
                    secsEle.addEventListener('keydown', function (e) {
                        const key = e.keyCode || e.which;
                        if (key === 13) {
                            e.target.blur();
                            e.preventDefault();
                            self.confirmTime();
                        }
                        if (key === 38) {
                            e.target.value = parseInt(e.target.value) + 1;
                            secsInput(e);
                        }
                        if (key === 40) {
                            e.target.value = parseInt(e.target.value) - 1;
                            secsInput(e);
                        }
                    });
                }
                self.setDateValues();
                self.setTimesValues();
            };
            // 定位日期
            theTool.locateDay = function (dateValue) {
                const self = this;
                if (!dateValue) {
                    return;
                }
                for (let x of self.dom.dateSet.querySelectorAll('li')) {
                    x.classList.remove('DCcxCalendarSelected');
                    if (dateValue == theTool.formatDate('Y-m-d', x.dataset.date)) {
                        x.classList.add('DCcxCalendarSelected');
                    }
                }
                // if (self.cacheApi.settings.type === 'datetime') {
                //     self.cacheDate.time = self.parseDate(dateValue).getTime();
                //     return
                // }
                // self.cacheApi.setDate(dateValue);

                self.cacheDate.time = self.parseDate(dateValue).getTime();
            };
            // 构建翻页函数
            theTool.buildFlipFunc = function () {
                const self = this;
                var prevYearEle = self.dom.head.querySelector('.dc_prevYear');//上一年
                var prevMonthEle = self.dom.head.querySelector('.dc_prevMonth');//上一月
                var nextMonthEle = self.dom.head.querySelector('.dc_nextMonth');//下一月
                var nextYearEle = self.dom.head.querySelector('.dc_nextYear');//下一年

                if (prevYearEle) {
                    prevYearEle.addEventListener('click', function (e) {
                        self.gotoPrevYear();
                    });
                }
                if (prevMonthEle) {
                    prevMonthEle.addEventListener('click', function (e) {
                        self.gotoPrev();
                    });
                }
                if (nextMonthEle) {
                    nextMonthEle.addEventListener('click', function (e) {
                        self.gotoNext();
                    });
                }
                if (nextYearEle) {
                    nextYearEle.addEventListener('click', function (e) {
                        self.gotoNextYear();
                    });
                }
            };

            // 赋值时间选择
            theTool.setTimesValues = function () {
                const self = this;
                const values = [];

                if (self.cacheDate.startTime && self.cacheDate.endTime) {
                    values.push(self.cacheDate.startTime, self.cacheDate.endTime);
                } else if (self.cacheDate.startTime) {
                    values.push(self.cacheDate.startTime, self.cacheDate.startTime);
                } else {
                    values.push(self.cacheApi.defDate.time, self.cacheApi.defDate.time);
                }
                const times = {
                    hour: [],
                    mint: [],
                    secs: [],
                };

                if (self.cacheApi.settings.type === 'time') {
                    var dataInput = WriterControl_DateTimeControl.rootElement.ownerDocument.querySelector('#DCDateTime_calendar');
                    if (dataInput && dataInput.value) {
                        var d = new Date(dataInput.value);
                        times.hour.push(self.fillLeadZero(d.getHours(), 2));
                        times.mint.push(self.fillLeadZero(d.getMinutes(), 2));
                        times.secs.push(self.fillLeadZero(d.getSeconds(), 2));
                    }
                    // console.log(times, '=============times');
                } else {
                    for (let x of values) {
                        const d = new Date(x);
                        times.hour.push(self.fillLeadZero(d.getHours(), 2));
                        times.mint.push(self.fillLeadZero(d.getMinutes(), 2));
                        times.secs.push(self.fillLeadZero(d.getSeconds(), 2));
                    }

                }

                for (let x of self.dom.timeSet.querySelectorAll('.dc_time-group input')) {
                    if (times[x.name] && times[x.name].length) {
                        x.value = times[x.name].shift();
                    }
                }

            };

            // 赋值日期选择框
            theTool.setDateValues = function (dataValue) {
                const self = this;
                const values = [];

                if (dataValue) {
                    values.push(dataValue);
                }
                else if (self.cacheDate.startTime && self.cacheDate.endTime) {
                    values.push(self.cacheDate.startTime, self.cacheDate.endTime);
                } else if (self.cacheDate.startTime) {
                    values.push(self.cacheDate.startTime, self.cacheDate.startTime);
                } else {
                    values.push(self.cacheApi.defDate.time, self.cacheApi.defDate.time);
                }
                const date = {
                    year: [],
                    month: [],
                    day: [],
                };

                for (let x of values) {
                    const d = new Date(x);
                    date.year.push(d.getFullYear());
                    date.month.push(self.fillLeadZero(d.getMonth() + 1, 2));
                    date.day.push(self.fillLeadZero(d.getDate(), 2));
                }
                for (let x of self.dom.timeSet.querySelectorAll('.dc_date-group input')) {
                    if (date[x.name] && date[x.name].length) {
                        x.value = date[x.name].shift();
                    }
                }
            };

            // 构建月份列表
            theTool.buildMonths = function (year) {
                const self = this;

                if (!self.isInteger(year)) {
                    return;
                }
                const nowDate = new Date();
                const nowText = [nowDate.getFullYear(), nowDate.getMonth() + 1].join('-');
                const selectedText = self.formatDate('Y-n', self.cacheDate.time);
                const maxInt = parseInt(self.cacheApi.maxDate.year + self.fillLeadZero(self.cacheApi.maxDate.month, 2), 10);
                const minInt = parseInt(self.cacheApi.minDate.year + self.fillLeadZero(self.cacheApi.minDate.month, 2), 10);

                // 日期范围值
                const rangeValue = {};
                let rangeMaxInt = 0;

                if (typeof self.cacheDate.startTime === 'number') {
                    rangeValue.start = parseInt(self.formatDate('Ym', self.cacheDate.startTime), 10);

                    if (typeof self.cacheApi.settings.rangeMaxMonth === 'number' && self.cacheApi.settings.rangeMaxMonth) {
                        const rangeDate = new Date(self.cacheDate.startTime);
                        rangeDate.setMonth(rangeDate.getMonth() + self.cacheApi.settings.rangeMaxMonth);
                        rangeMaxInt = parseInt(self.formatDate('Ym', rangeDate.getTime()), 10);
                    }
                    if (typeof self.cacheDate.endTime === 'number') {
                        rangeValue.end = parseInt(self.formatDate('Ym', self.cacheDate.endTime), 10);
                    } else {
                        rangeValue.end = rangeValue.start;
                    }
                }
                let html = '<ul>';

                for (let i = 1; i <= 12; i++) {
                    const classValue = [];
                    const todayText = year + '-' + i;
                    const todayInt = parseInt(year + self.fillLeadZero(i, 2), 10);

                    if (self.cacheApi.settings.mode === 'range') {
                        if (todayInt === rangeValue.start || todayInt === rangeValue.end || (todayInt >= rangeValue.start && todayInt <= rangeValue.end)) {
                            classValue.push('DCcxCalendarSelected');

                            if (todayInt === rangeValue.start) {
                                classValue.push('dc_start');
                            } if (todayInt === rangeValue.end) {
                                classValue.push('dc_end');
                            }
                        }
                    } else if (todayText === selectedText) {
                        classValue.push('DCcxCalendarSelected');
                    }
                    if (todayText === nowText) {
                        classValue.push('dc_now');
                    }
                    if (rangeMaxInt && todayInt > rangeMaxInt) {
                        classValue.push('dc_del');

                    } else if (todayInt < minInt || todayInt > maxInt) {
                        classValue.push('dc_del');
                    }
                    html += '<li';

                    if (classValue.length) {
                        html += ' class="' + classValue.join(' ') + '"';
                    }
                    if (classValue.indexOf('dc_del') === -1) {
                        html += ' data-date="' + todayText + '"';
                    }
                    html += '>' + self.cacheApi.settings.language.monthList[i - 1] + '</li>';
                }
                html += '</ul>';

                return html;
            };

            // 构建年份列表
            theTool.buildYears = function (year) {
                const self = this;
                let start = self.cacheApi.minDate.year;
                let end;
                let diff;

                if (!self.isInteger(year)) {
                    return;
                }
                const nowDate = new Date();
                const nowYear = nowDate.getFullYear();
                const selectedText = parseInt(self.formatDate('Y', self.cacheDate.time), 10);

                if (year < self.cacheApi.minDate.year) {
                    start = self.cacheApi.minDate.year;
                }
                start = Math.floor(start / 10) * 10;
                diff = year - start;

                if (diff >= self.cacheApi.settings.yearNum) {
                    start += Math.floor(diff / self.cacheApi.settings.yearNum) * self.cacheApi.settings.yearNum;
                }
                end = start + self.cacheApi.settings.yearNum - 1;

                // if (end > self.cacheApi.maxDate.year) {
                //   end = self.cacheApi.maxDate.year;
                // };

                // 日期范围值
                const rangeValue = {};
                let rangeMaxYear = 0;

                if (typeof self.cacheDate.startTime === 'number') {
                    rangeValue.start = parseInt(self.formatDate('Y', self.cacheDate.startTime), 10);

                    if (typeof self.cacheApi.settings.rangeMaxYear === 'number' && self.cacheApi.settings.rangeMaxYear) {
                        rangeMaxYear = rangeValue.start + self.cacheApi.settings.rangeMaxYear;
                    }
                    if (typeof self.cacheDate.endTime === 'number') {
                        rangeValue.end = parseInt(self.formatDate('Y', self.cacheDate.endTime), 10);
                    } else {
                        rangeValue.end = rangeValue.start;
                    }
                }
                let html = '<ul>';

                for (let i = start; i <= end; i++) {
                    const classValue = [];

                    if (self.cacheApi.settings.mode === 'range') {
                        if (i === rangeValue.start || i === rangeValue.end || (i >= rangeValue.start && i <= rangeValue.end)) {
                            classValue.push('DCcxCalendarSelected');

                            if (i === rangeValue.start) {
                                classValue.push('dc_start');
                            } if (i === rangeValue.end) {
                                classValue.push('dc_end');
                            }
                        }
                    } else if (i === selectedText) {
                        classValue.push('DCcxCalendarSelected');
                    }
                    if (i === nowYear) {
                        classValue.push('dc_now');
                    }
                    if (rangeMaxYear && i > rangeMaxYear) {
                        classValue.push('dc_del');

                    } else if (i < self.cacheApi.minDate.year || i > self.cacheApi.maxDate.year) {
                        classValue.push('dc_del');
                    }
                    html += '<li';

                    if (classValue.length) {
                        html += ' class="' + classValue.join(' ') + '"';
                    }
                    if (classValue.indexOf('dc_del') === -1) {
                        html += ' data-date="' + i + '"';
                    }
                    html += '>' + i + '</li>';
                }
                html += '</ul>';

                return html;
            };

            // 跳转到日期
            theTool.gotoDate = function (value) {
                const self = this;
                const values = {};
                const selects = self.getSelects(['year', 'month'], values);

                if (value === undefined) {
                    value = values.year;

                    if (values.month) {
                        value += '-' + values.month;
                    }
                }
                const theDate = self.parseDate(value, true);
                const theTime = theDate.getTime();

                if (theTime < self.cacheApi.minDate.time) {
                    theDate.setTime(self.cacheApi.minDate.time);
                } else if (theTime > self.cacheApi.maxDate.time) {
                    theDate.setTime(self.cacheApi.maxDate.time);
                }
                let theYear = theDate.getFullYear();
                let theMonth = theDate.getMonth() + 1;

                if (self.cacheApi.settings.type === 'year') {
                    let startYear = theYear;

                    for (let x of selects.year.options) {
                        const val = parseInt(x.value, 10);

                        if (val <= theYear) {
                            startYear = val;
                        } else {
                            break;
                        }
                    }
                    theYear = startYear;

                    if (startYear !== values.year) {
                        selects.year.value = startYear;
                    }
                } else if (theYear !== values.year) {
                    selects.year.value = theYear;
                }
                if (selects.month) {
                    if (theYear !== values.year || theMonth !== values.month) {
                        self.rebuildMonthSelect();
                        selects.month.value = theMonth;
                    }
                }
                const atState = {
                    start: true,
                    end: true,
                };

                for (let x in selects) {
                    if (selects[x].selectedIndex !== 0) {
                        atState.start = false;
                    } if (selects[x].selectedIndex !== selects[x].length - 1) {
                        atState.end = false;
                    }
                }
                for (let x in atState) {
                    if (atState[x]) {
                        self.dom.panel.classList.add('dc_at_' + x);
                    } else if (self.dom.panel.classList.contains('dc_at_' + x)) {
                        self.dom.panel.classList.remove('dc_at_' + x);
                    }
                }
                let html = '';
                let fillHtml = '';

                switch (self.cacheApi.settings.type) {
                    case 'date':
                    case 'datetime':
                        html = self.buildDays(theYear, theMonth);

                        if (self.cacheApi.settings.mode === 'range') {
                            let fillMonth = theMonth + 1;

                            if (fillMonth > 12) {
                                fillMonth = 1;
                            }
                            fillHtml = '<span class="dc_year">' + theYear + '</span><em></em>';
                            fillHtml += '<span class="dc_month">' + self.cacheApi.settings.language.monthList[fillMonth - 1] + '</span><em></em>';
                            html += self.buildDays(theYear, theMonth + 1);
                        } break;

                    case 'month':
                        html = self.buildMonths(theYear);

                        if (self.cacheApi.settings.mode === 'range') {
                            fillHtml = '<span class="dc_year">' + (theYear + 1) + '</span><em></em>';
                            html += self.buildMonths(theYear + 1);
                        } break;

                    case 'year':
                        html = self.buildYears(theYear);

                        if (self.cacheApi.settings.mode === 'range') {
                            fillHtml = '<span class="dc_year">' + (theYear + self.cacheApi.settings.yearNum) + ' - ' + (theYear + self.cacheApi.settings.yearNum * 2 - 1) + '</span>';
                            html += self.buildYears(theYear + self.cacheApi.settings.yearNum);
                        } break;
                }
                self.dom.dateSet.innerHTML = html;

                if (self.cacheApi.settings.mode === 'range') {
                    const el = self.dom.head.querySelectorAll('section');

                    if (el.length > 1) {
                        el[1].innerHTML = fillHtml;
                    }
                }
            };

            // 向前翻页（月）
            theTool.gotoPrev = function () {
                const self = this;
                const selects = self.getSelects(['year', 'month']);

                switch (self.cacheApi.settings.type) {
                    case 'date':
                    case 'datetime':
                        const monthIndex = selects.month.selectedIndex;

                        if (monthIndex > 0) {
                            selects.month.selectedIndex -= 1;
                            self.gotoDate();

                        } else if (monthIndex === 0) {
                            if (selects.year.selectedIndex > 0) {
                                selects.year.selectedIndex -= 1;

                                self.rebuildMonthSelect();
                                selects.month.selectedIndex = selects.month.length - 1;
                                self.gotoDate();
                            }
                        } break;

                    case 'month':
                    case 'year':
                        if (selects.year.selectedIndex > 0) {
                            selects.year.selectedIndex -= 1;
                            self.gotoDate();
                        } break;
                }
            };

            // 向后翻页（月）
            theTool.gotoNext = function () {
                const self = this;
                const selects = self.getSelects(['year', 'month']);

                switch (self.cacheApi.settings.type) {
                    case 'date':
                    case 'datetime':
                        const monthIndex = selects.month.selectedIndex;
                        const monthMax = selects.month.length - 1;

                        if (monthIndex < monthMax) {
                            selects.month.selectedIndex += 1;
                            self.gotoDate();

                        } else if (monthIndex === monthMax) {
                            if (selects.year.selectedIndex < selects.year.length - 1) {
                                selects.year.selectedIndex += 1;

                                self.rebuildMonthSelect();
                                selects.month.selectedIndex = 0;
                                self.gotoDate();
                            }
                        } break;

                    case 'month':
                    case 'year':
                        if (selects.year.selectedIndex < selects.year.length - 1) {
                            selects.year.selectedIndex += 1;
                            self.gotoDate();
                        } break;
                }
            };

            // 向前翻页（年）
            theTool.gotoPrevYear = function () {
                const self = this;
                const selects = self.getSelects(['year', 'month']);

                switch (self.cacheApi.settings.type) {
                    case 'date':
                    case 'datetime':
                        const yearIndex = selects.year.selectedIndex;

                        if (yearIndex > 0) {
                            selects.year.selectedIndex -= 1;
                            self.gotoDate();
                        } break;

                    case 'month':
                    case 'year':
                        if (selects.year.selectedIndex > 0) {
                            selects.year.selectedIndex -= 1;
                            self.gotoDate();
                        } break;
                }
            };

            // 向后翻页（年）
            theTool.gotoNextYear = function () {
                const self = this;
                const selects = self.getSelects(['year', 'month']);

                switch (self.cacheApi.settings.type) {
                    case 'date':
                    case 'datetime':
                        const yearIndex = selects.year.selectedIndex;
                        const yearMax = selects.year.length - 1;

                        if (yearIndex < yearMax) {
                            selects.year.selectedIndex += 1;
                            self.gotoDate();
                        }
                        break;

                    case 'month':
                    case 'year':
                        if (selects.year.selectedIndex < selects.year.length - 1) {
                            selects.year.selectedIndex += 1;
                            self.gotoDate();
                        } break;
                }
            };

            // 显示面板
            theTool.showPanel = function (rootElement) {
                const self = this;

                if (self.delayHide) {
                    clearTimeout(self.delayHide);
                }
                const win = rootElement.ownerDocument.defaultView;
                const doc = rootElement.ownerDocument;
                const pos = self.cacheApi.settings.position;

                // 避免滚动条影响位置，先获取不包含滚动条的宽度和高度【DUWRITER5_0-4216】
                const winWidth = doc.documentElement.clientWidth || doc.body.clientWidth || win.innerWidth;
                const winHeight = doc.documentElement.clientHeight || doc.body.clientHeight || win.innerHeight;

                const elRect = self.cacheApi.input.getBoundingClientRect();
                const elWidth = elRect.width;
                let elHeight = elRect.height;
                let elClientTop = elRect.top;
                // 获取到页面的焦点的位置
                const caretEle = WriterControl_DateTimeControl.rootElement.querySelector('#divCaret20221213');
                if (caretEle) {
                    const caretEleRect = caretEle.getBoundingClientRect();
                    if (elHeight == 0) {
                        elHeight = caretEleRect.height;
                        elClientTop -= caretEleRect.height;
                    }
                }
                const elClientLeft = elRect.left;
                const elTop = elClientTop + win.pageYOffset - doc.documentElement.clientTop;
                const elLeft = elClientLeft + win.pageXOffset - doc.documentElement.clientLeft;
                const panelRect = self.dom.panel.getBoundingClientRect();
                const panelWidth = panelRect.width;
                const panelHeight = panelRect.height;
                // let panelTop = elTop + elHeight - 20;
                // let panelTop = (elClientTop + elHeight + panelHeight > winHeight && elTop - panelHeight >= 0) ? elTop - panelHeight : elTop + elHeight - 20;
                // 修改时间下拉的弹出显示不全的问题【DUWRITER5_0-4216】
                let panelTop = (elClientTop + elHeight + panelHeight > winHeight && elTop - panelHeight >= 0) ? elTop - panelHeight : elTop + elHeight;
                // 修改时间下拉在上下都显示不全展示的位置【未处理时间下拉高度大于页面高度的情况】【DUWRITER5_0-4318】
                // 判断时间下拉是否超出页面
                if (panelTop < elTop - elClientTop) {
                    // 上超出
                    panelTop = elTop - elClientTop;
                }
                if (panelTop + panelHeight > elTop - elClientTop + winHeight) {
                    // 下超出
                    panelTop = elTop - elClientTop + winHeight - panelHeight;
                }
                // if (caretEle) {
                //     //如果焦点距离顶部比日期框距离顶部远 说明 日期框弹出在上面
                //     let caretEleRect = caretEle.getBoundingClientRect();
                //     if (caretEleRect.top > elClientTop) {
                //         //去掉一个间距
                //         panelTop -= 10;
                //         //日期格式下，divContainer的高度有变化，所以先在此处调整位置
                //         var CurrentElement = rootElement.GetElementProperties(rootElement.CurrentElement());
                //         if (CurrentElement && CurrentElement.InnerEditStyle && CurrentElement.InnerEditStyle == "Date") {
                //             panelTop -= 35;
                //         }
                //     }
                // }
                let panelLeft = (elClientLeft + panelWidth > winWidth && elLeft - panelWidth >= 0) ? elLeft - panelWidth + elWidth : elLeft;
                // 修改时间下拉在左右都显示不全展示的位置【未处理时间下拉宽度大于页面宽度的情况】
                // 判断时间下拉是否超出页面
                if (panelLeft < elLeft - elClientLeft) {
                    // 左超出
                    panelLeft = elTop - elClientLeft;
                }
                if (panelLeft + panelWidth > elLeft - elClientLeft + winWidth) {
                    // 右超出
                    panelLeft = elLeft - elClientLeft + winWidth - panelWidth;
                }
                if (typeof pos === 'string' && pos.length) {
                    switch (pos) {
                        case 'fixed':
                            panelTop = null;
                            panelLeft = null;
                            break;

                        case 'top':
                            panelTop = elTop - panelHeight;
                            break;

                        case 'bottom':
                            panelTop = elTop + elHeight;
                            break;

                        case 'left':
                        case 'right':
                            panelTop = ((elClientTop + elHeight + panelHeight) > winHeight) ? elTop + elHeight - panelHeight : elTop;
                            panelLeft = (pos === 'left') ? elLeft - panelWidth : elLeft + elWidth;
                            break;
                    }
                }

                if (typeof panelTop === 'number' && typeof panelLeft === 'number') {
                    self.dom.panel.style.top = panelTop + 'px';
                    self.dom.panel.style.left = panelLeft + 'px';
                }
                self.dom.panel.classList.add('dc_show');
            };

            // 隐藏面板
            theTool.hidePanel = function () {
                const self = this;
                self.dom.panel.classList.remove('dc_show');
                let selects = self.dom.head.querySelectorAll('select');
                if (selects.length > 0) {
                    for (let i = 0; i < selects.length; i++) {
                        let s = selects[i];
                        while (s.options.length > 0) {
                            s.remove(0);
                        }
                    }
                }
                self.delayHide = setTimeout(() => {
                    self.dom.panel.removeAttribute('style');
                }, 300);
            };

            // 确认选择日期范围
            theTool.confirmRange = function () {
                const self = this;
                let values = [];

                if (self.cacheDate.startTime && self.cacheDate.endTime) {
                    values.push(self.cacheDate.startTime, self.cacheDate.endTime);
                } else if (self.cacheDate.startTime) {
                    values.push(self.cacheDate.startTime, self.cacheDate.startTime);
                } else {
                    values.push(self.cacheApi.defDate.time, self.cacheApi.defDate.time);
                }
                if (['datetime', 'time'].indexOf(self.cacheApi.settings.type) >= 0) {
                    const times = {
                        hour: [],
                        mint: [],
                        secs: [],
                    };

                    for (let x of self.dom.timeSet.querySelectorAll('input')) {
                        if (times[x.name]) {
                            times[x.name].push(parseInt(x.value));
                        }
                    }
                    // 日期对比时间顺序
                    if (self.cacheApi.settings.type === 'datetime') {
                        const diffTime = [];

                        for (let i = 0, l = values.length; i < l; i++) {
                            diffTime.push(parseInt([1, times.hour[i], times.mint[i], times.secs[i]].join(''), 10));
                        }
                        if (diffTime[0] > diffTime[1]) {
                            for (let x in times) {
                                if (times[x].length > 1) {
                                    times[x][1] = times[x][0];
                                }
                            }
                        }
                    }
                    values = values.map((val, index) => {
                        const d = new Date(val);
                        d.setHours(times.hour[index], times.mint[index], times.secs[index], 0);
                        return d.getTime();
                    });
                }
                self.cacheApi.setDate(values.join(self.cacheApi.settings.rangeSymbol));
            };

            // 确认选择
            theTool.confirmTime = function () {
                const self = this;
                const theDate = new Date();
                let theTime = self.cacheApi.defDate.time;
                // console.log('defDate.time',self.cacheApi.defDate.time);
                // if (self.cacheApi.settings.type === 'datetime' && typeof self.cacheDate.time === 'number') {
                //     theTime = self.cacheDate.time;
                // }
                // console.log('self.cacheDate.time',self.cacheDate.time);
                theTime = self.cacheDate.time;
                theDate.setTime(theTime);

                // 时分秒
                const times = Array(4).fill(0);
                const map = {
                    hour: 0,
                    mint: 1,
                    secs: 2,
                };

                for (let x of self.dom.timeSet.querySelectorAll('input')) {
                    if (x.name in map) {
                        times[map[x.name]] = parseInt(x.value ? x.value : '00');
                    }
                }
                theDate.setHours(...times);
                self.cacheApi.setDate(theDate.getTime());
            };

            // 解除绑定
            theTool.detach = function (el) {
                const self = this;

                if (!self.isElement(el)) {
                    return;
                }
                const alias = 'id_' + el.dataset.cxCalendarId;
                delete el.dataset.cxCalendarId;

                if (typeof self.bindFuns[alias] === 'function') {
                    el.removeEventListener('click', self.bindFuns[alias]);
                    delete self.bindFuns[alias];
                }
            };

            // document.addEventListener('DOMContentLoaded', () => {
            //   theTool.init();
            // });
            theTool.init();

            // 选择器实例
            const picker = function () {
                const self = this;
                let options = {};
                let isAttach = false;

                // 分配参数
                for (let x of arguments) {
                    if (theTool.isElement(x)) {
                        self.input = x;
                    } else if (theTool.isObject(x)) {
                        options = x;
                    } else if (typeof x === 'boolean') {
                        isAttach = x;
                    }
                }
                if (!self.input || !self.input.nodeName || ['input', 'textarea'].indexOf(self.input.nodeName.toLowerCase()) === -1) {
                    console.warn('[cxCalendar] Not input element.');
                    return;
                }
                // 合并输入框参数
                const keys = [
                    'baseClass',
                    'disableWeek',
                    'disableDay',
                    'endDate',
                    'format',
                    'hourStep',
                    'language',
                    'lockRow',
                    'minuteStep',
                    'position',
                    'mode',
                    'rangeSymbol',
                    'rangeMaxDay',
                    'rangeMaxMonth',
                    'rangeMaxYear',
                    'secondStep',
                    'startDate',
                    'type',
                    'weekStart',
                    'yearNum',
                ];
                const inputSettings = {};

                for (let x of keys) {
                    if (typeof self.input.dataset[x] !== 'string' || !self.input.dataset[x].length) {
                        continue;
                    }
                    switch (x) {
                        case 'hourStep':
                        case 'minuteStep':
                        case 'secondStep':
                        case 'rangeMaxDay':
                        case 'rangeMaxMonth':
                        case 'rangeMaxYear':
                        case 'weekStart':
                        case 'yearNum':
                            inputSettings[x] = parseInt(self.input.dataset[x], 10);
                            break;

                        case 'lockRow':
                            inputSettings[x] = Boolean(parseInt(self.input.dataset[x], 10));
                            break;

                        case 'disableWeek':
                        case 'disableDay':
                            inputSettings[x] = self.input.dataset[x].split(',');
                            break;

                        default:
                            inputSettings[x] = self.input.dataset[x];
                            break;
                    }
                }
                if (Array.isArray(inputSettings.disableWeek)) {
                    inputSettings.disableWeek = inputSettings.disableWeek.map((val) => {
                        return parseInt(val, 10);
                    });
                }
                self.settings = theTool.extend({}, options, inputSettings);
                self.setOptions();

                let alias = 'id_' + self.input.dataset.cxCalendarId;

                if (typeof theTool.bindFuns[alias] === 'function') {
                    theTool.detach(self.input);
                }
                self.eventChange = new CustomEvent('change', {
                    bubbles: true
                });

                if (isAttach) {
                    self.input.dataset.cxCalendarId = theTool.cxId;
                    alias = 'id_' + theTool.cxId;
                    theTool.cxId++;
                    theTool.bindFuns[alias] = self.show.bind(self);

                    self.input.addEventListener('click', theTool.bindFuns[alias]);

                } else {
                    self.show();
                }
            };

            picker.prototype.setOptions = function (options) {
                const self = this;
                let maxDate;
                let minDate;
                let defDate;

                if (theTool.isObject(options)) {
                    theTool.extend(self.settings, options);
                }
                // 结束日期（默认为当前日期）
                if (theTool.reg.isYear.test(self.settings.endDate)) {
                    maxDate = new Date(self.settings.endDate, 11, 31);
                } else {
                    maxDate = theTool.parseDate(self.settings.endDate, true);
                }
                maxDate.setHours(23, 59, 59);

                self.maxDate = {
                    year: maxDate.getFullYear(),
                    month: maxDate.getMonth() + 1,
                    day: maxDate.getDate(),
                    time: maxDate.getTime()
                };

                // 起始日期（默认为当前日期的前一年）
                if (theTool.reg.isYear.test(self.settings.startDate)) {
                    minDate = new Date(self.settings.startDate, 0, 1);
                } else {
                    minDate = theTool.parseDate(self.settings.startDate);
                }
                if (!theTool.isDate(minDate)) {
                    minDate = new Date();
                    minDate.setFullYear(minDate.getFullYear() - 1);
                }
                // 若超过结束日期，则设为结束日期的前一年
                if (minDate.getTime() > self.maxDate.time) {
                    minDate = new Date(self.maxDate.year - 1, self.maxDate.month - 1, self.maxDate.day);
                }
                minDate.setHours(0, 0, 0, 0);

                self.minDate = {
                    year: minDate.getFullYear(),
                    month: minDate.getMonth() + 1,
                    day: minDate.getDate(),
                    time: minDate.getTime()
                };

                const rangeValue = {};

                // 默认日期
                if (self.settings.mode === 'range') {
                    const dateSp = String(self.settings.date).split(self.settings.rangeSymbol);

                    if (dateSp.length === 2) {
                        defDate = theTool.parseDate(dateSp[0], true);

                        const rangeEndDate = theTool.parseDate(dateSp[1], true);
                        rangeValue.start = defDate.getTime();
                        rangeValue.end = rangeEndDate.getTime();
                    }
                }
                if (!defDate) {
                    defDate = theTool.parseDate(self.settings.date, true);
                }
                if (defDate.getTime() < self.minDate.time) {
                    defDate = theTool.parseDate(self.minDate.time, true);
                } else if (defDate.getTime() > self.maxDate.time) {
                    defDate = theTool.parseDate(self.maxDate.time, true);
                }
                self.defDate = {
                    year: defDate.getFullYear(),
                    month: defDate.getMonth() + 1,
                    day: defDate.getDate(),
                    hour: defDate.getHours(),
                    mint: defDate.getMinutes(),
                    secs: defDate.getSeconds(),
                    time: defDate.getTime(),
                    start: rangeValue.start,
                    end: rangeValue.end,
                };

                // 星期的起始位置
                self.settings.weekStart %= 7;

                // 语言配置
                self.settings.language = theTool.getLanguage(self.settings.language);

                // 统计节假日
                if (Array.isArray(self.settings.language.holiday) && self.settings.language.holiday.length) {
                    self.holiday = {};

                    for (let x of self.settings.language.holiday) {
                        self.holiday[x.day] = x.name;
                    }
                }
            };

            picker.prototype.show = function (rootElement) {
                const self = this;

                if (self.input.value || !self.settings.date) {
                    self.settings.date = self.input.value;
                } self.setOptions();

                theTool.cacheApi = self;
                theTool.buildPanel(rootElement);
                theTool.showPanel(rootElement);
            };

            picker.prototype.hide = function () {
                theTool.hidePanel();
            };

            picker.prototype.getDate = function (style) {
                const self = this;
                const oldValue = self.input.value;
                const dateList = [];

                if (typeof style !== 'string' || !style.length) {
                    style = self.settings.format;
                }
                if (self.settings.mode === 'range') {
                    const dateSp = String(oldValue).split(self.settings.rangeSymbol);

                    if (dateSp.length === 2) {
                        dateList.push(...dateSp);
                    }
                } else {
                    dateList.push(oldValue);
                }
                let newValue = [];

                for (let x of dateList) {
                    const theDate = theTool.parseDate(x);

                    if (!theTool.isDate(theDate)) {
                        newValue = [];
                        break;
                    }
                    newValue.push(theTool.formatDate(style, theDate.getTime(), self.settings.language));
                }
                newValue = self.settings.mode === 'range' ? newValue.join(self.settings.rangeSymbol) : newValue.join('');

                return newValue;
            };

            picker.prototype.setDate = function (value) {
                // console.log(value);
                const self = this;
                const oldValue = self.input.value;
                const dateList = [];

                if (self.settings.mode === 'range') {
                    const dateSp = String(value).split(self.settings.rangeSymbol);

                    if (dateSp.length === 2) {
                        dateList.push(...dateSp);
                    }
                } else {
                    dateList.push(value);
                }
                let newValue = [];

                for (let x of dateList) {
                    const theDate = theTool.parseDate(x);

                    if (!theTool.isDate(theDate)) {
                        newValue = [];
                        break;
                    }
                    let theTime = theDate.getTime();

                    if (theTime < self.minDate.time) {
                        theTime = self.minDate.time;
                    } else if (theTime > self.maxDate.time) {
                        theTime = self.maxDate.time;
                    }
                    newValue.push(theTool.formatDate(self.settings.format, theTime, self.settings.language));
                }
                newValue = self.settings.mode === 'range' ? newValue.join(self.settings.rangeSymbol) : newValue.join('');

                //if (oldValue !== newValue) {

                //}
                self.input.value = newValue;
                self.input.dispatchEvent(self.eventChange);
            };

            picker.prototype.clearDate = function () {
                const self = this;
                const oldValue = self.input.value;

                if (oldValue && oldValue.length) {
                    self.input.value = '';
                    self.input.dispatchEvent(self.eventChange);
                }
            };

            const cxCalendar = function (el, options, isAttach) {
                if (theTool.isObject(options)) {
                    options = theTool.extend({}, cxCalendar.defaults, options);
                } else {
                    options = theTool.extend({}, cxCalendar.defaults);
                }
                const result = new picker(el, options, isAttach);

                if (isAttach) {
                    result.theTool = theTool;
                    return result;
                }
            };

            cxCalendar.attach = function (el, options) {
                return this(el, options, true);
            };

            cxCalendar.detach = function (el) {
                theTool.detach(el);
            };

            // 默认配置
            cxCalendar.defaults = {
                startDate: undefined,   // 开始日期
                endDate: undefined,     // 结束日期
                date: undefined,        // 默认日期
                type: 'date',           // 日期类型
                format: 'Y-m-d',        // 日期值格式
                weekStart: 0,           // 星期开始于周几
                lockRow: false,         // 固定日期的行数
                yearNum: 20,            // 年份每页条数
                hourStep: 1,            // 小时间隔
                minuteStep: 1,          // 分钟间隔
                secondStep: 1,          // 秒间隔
                disableWeek: [],        // 不可选择的日期（星期值）
                disableDay: [],         // 不可选择的日期
                mode: 'single',         // 选择模式
                rangeSymbol: ' - ',     // 日期范围拼接符号
                rangeMaxDay: 0,         // 日期范围最长间隔
                rangeMaxMonth: 0,       // 月份范围最长间隔
                rangeMaxYear: 0,        // 年份范围最长间隔
                button: {},             // 操作按钮
                position: undefined,    // 面板位置
                baseClass: undefined,   // 基础样式
                language: undefined     // 语言配置
            };

            return cxCalendar;

        }));
    }
}



