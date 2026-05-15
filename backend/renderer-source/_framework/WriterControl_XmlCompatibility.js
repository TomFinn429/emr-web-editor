"use strict";

const BACKGROUND_TEXT_PATTERN = /<BackgroundText>([\s\S]*?)<\/BackgroundText>/;
const INNER_VALUE_PATTERN = /<InnerValue>([\s\S]*?)<\/InnerValue>/;
const MEASURABLE_PLACEHOLDER = "&#12288;";

function insertBeforeKnownTail(elementBody, markup) {
    if (elementBody.indexOf("<BackgroundText>") >= 0) {
        return elementBody.replace("<BackgroundText>", markup + "<BackgroundText>");
    }

    if (elementBody.indexOf("<EnableHighlight>") >= 0) {
        return elementBody.replace("<EnableHighlight>", markup + "<EnableHighlight>");
    }

    return elementBody + markup;
}

function normalizeInputFieldBody(elementBody) {
    if (elementBody.indexOf("<SpecifyWidth>50</SpecifyWidth>") < 0) {
        return elementBody;
    }

    var hasBlankBackgroundText = false;
    var hasBackgroundText = BACKGROUND_TEXT_PATTERN.test(elementBody);
    if (hasBackgroundText) {
        elementBody = elementBody.replace(BACKGROUND_TEXT_PATTERN, function (backgroundMatch, value) {
            hasBlankBackgroundText = value.trim().length == 0;
            return hasBlankBackgroundText
                ? "<BackgroundText>" + MEASURABLE_PLACEHOLDER + "</BackgroundText>"
                : backgroundMatch;
        });
    }

    if (hasBackgroundText == false || hasBlankBackgroundText) {
        if (INNER_VALUE_PATTERN.test(elementBody)) {
            elementBody = elementBody.replace(INNER_VALUE_PATTERN, function (innerValueMatch, value) {
                return value.trim().length == 0
                    ? "<InnerValue>" + MEASURABLE_PLACEHOLDER + "</InnerValue>"
                    : innerValueMatch;
            });
        }
        else {
            elementBody = insertBeforeKnownTail(elementBody, "<InnerValue>" + MEASURABLE_PLACEHOLDER + "</InnerValue>");
        }
    }

    return hasBackgroundText
        ? elementBody
        : insertBeforeKnownTail(elementBody, "<BackgroundText>" + MEASURABLE_PLACEHOLDER + "</BackgroundText>");
}

export function NormalizeInputFieldXmlForCanvas(xml) {
    if (typeof xml !== "string"
        || xml.indexOf("<XTextDocument") < 0
        || xml.indexOf('xsi:type="XInputField"') < 0
        || xml.indexOf("<SpecifyWidth>50</SpecifyWidth>") < 0) {
        return xml;
    }

    return xml.replace(/(<Element\b[^>]*\bxsi:type="XInputField"[^>]*>)([\s\S]*?)(<\/Element>)/g, function (match, startTag, elementBody, endTag) {
        if (elementBody.indexOf("<SpecifyWidth>50</SpecifyWidth>") < 0) {
            return match;
        }

        return startTag + normalizeInputFieldBody(elementBody) + endTag;
    });
}
