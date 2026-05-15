import assert from "node:assert/strict";
import fs from "node:fs";
import test from "node:test";
import vm from "node:vm";

function loadNormalizer(path) {
    const source = fs.readFileSync(path, "utf8");
    const startIndex = source.indexOf("const INPUT_FIELD_BACKGROUND_TEXT_PATTERN");
    const endIndex = source.indexOf("export let WriterControl_IO");

    assert.notEqual(startIndex, -1);
    assert.notEqual(endIndex, -1);

    const normalizerSource = source
        .slice(startIndex, endIndex)
        .replace("export function NormalizeInputFieldXmlForCanvas", "function NormalizeInputFieldXmlForCanvas");
    const context = {};
    vm.createContext(context);
    vm.runInContext(`${normalizerSource}\nthis.NormalizeInputFieldXmlForCanvas = NormalizeInputFieldXmlForCanvas;`, context);

    return context.NormalizeInputFieldXmlForCanvas;
}

const normalizeSourceXml = loadNormalizer(new URL("../renderer-source/_framework/WriterControl_IO.js", import.meta.url));
const normalizeRuntimeXml = loadNormalizer(new URL("../renderer-runtime/_framework/WriterControl_IO.js", import.meta.url));

const normalizers = [
    ["renderer-source", normalizeSourceXml],
    ["renderer-runtime", normalizeRuntimeXml],
];

for (const [name, normalize] of normalizers) {
    test(`${name} fills blank BackgroundText for SpecifyWidth 50 input fields`, () => {
        const xml = '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>gender</ID><SpecifyWidth>50</SpecifyWidth><Name>gender</Name><BackgroundText> </BackgroundText><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>';

        assert.equal(
            normalize(xml),
            '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>gender</ID><SpecifyWidth>50</SpecifyWidth><Name>gender</Name><InnerValue>&#12288;</InnerValue><BackgroundText>&#12288;</BackgroundText><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>',
        );
    });

    test(`${name} inserts BackgroundText when SpecifyWidth 50 input fields omit it`, () => {
        const xml = '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>care</ID><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>firstCare</Name><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>';

        assert.equal(
            normalize(xml),
            '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>care</ID><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>firstCare</Name><InnerValue>&#12288;</InnerValue><BackgroundText>&#12288;</BackgroundText><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>',
        );
    });

    test(`${name} inserts measurable placeholder for blank fixed-width box fields`, () => {
        const xml = '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>firstCare</ID><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>firstCare</Name><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>';

        assert.equal(
            normalize(xml),
            '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>firstCare</ID><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>firstCare</Name><InnerValue>&#12288;</InnerValue><BackgroundText>&#12288;</BackgroundText><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>',
        );
    });

    test(`${name} normalizes appendix care day boxes from the real record shape`, () => {
        const xml = '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>field138_4</ID><ValueBinding><DataSource>sheetPatient</DataSource><BindingPath>premiumCare</BindingPath></ValueBinding><ContentReadonly>False</ContentReadonly><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>特级护理天数</Name><EnableHighlight>Default</EnableHighlight><EditorActiveMode>MouseDblClick MouseClick</EditorActiveMode></Element><Element xsi:type="XInputField" StyleIndex="18"><ID>field145_1</ID><ValueBinding><DataSource>sheetPatient</DataSource><BindingPath>followUp</BindingPath></ValueBinding><ContentReadonly>False</ContentReadonly><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>随访</Name><EnableHighlight>Default</EnableHighlight><EditorActiveMode>MouseDblClick MouseClick</EditorActiveMode></Element></XTextDocument>';

        assert.equal(
            normalize(xml),
            '<XTextDocument><Element xsi:type="XInputField" StyleIndex="3"><ID>field138_4</ID><ValueBinding><DataSource>sheetPatient</DataSource><BindingPath>premiumCare</BindingPath></ValueBinding><ContentReadonly>False</ContentReadonly><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>特级护理天数</Name><InnerValue>&#12288;</InnerValue><BackgroundText>&#12288;</BackgroundText><EnableHighlight>Default</EnableHighlight><EditorActiveMode>MouseDblClick MouseClick</EditorActiveMode></Element><Element xsi:type="XInputField" StyleIndex="18"><ID>field145_1</ID><ValueBinding><DataSource>sheetPatient</DataSource><BindingPath>followUp</BindingPath></ValueBinding><ContentReadonly>False</ContentReadonly><SpecifyWidth>50</SpecifyWidth><Alignment>Center</Alignment><Name>随访</Name><InnerValue>&#12288;</InnerValue><BackgroundText>&#12288;</BackgroundText><EnableHighlight>Default</EnableHighlight><EditorActiveMode>MouseDblClick MouseClick</EditorActiveMode></Element></XTextDocument>',
        );
    });

    test(`${name} leaves non-empty BackgroundText and other widths unchanged`, () => {
        const xml = '<XTextDocument><Element xsi:type="XInputField"><SpecifyWidth>50</SpecifyWidth><Name>payMethod</Name><BackgroundText>payMethod</BackgroundText><EnableHighlight>Default</EnableHighlight></Element><Element xsi:type="XInputField"><SpecifyWidth>40</SpecifyWidth><Name>week</Name><EnableHighlight>Default</EnableHighlight></Element></XTextDocument>';

        assert.equal(normalize(xml), xml);
    });

    test(`${name} ignores non-writer strings`, () => {
        assert.equal(normalize("<div></div>"), "<div></div>");
        assert.equal(normalize(null), null);
    });
}
