"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const protractor_1 = require("protractor");
class AssertionLib {
    //constructor  accepts dropdown as element
    constructor(e = null, eAll = null) {
        this.element = e;
        this.elements = eAll;
    }
    CountValidate(count) {
        console.log("Assertion to validate count Expected " + count);
        this.elements.count().then(function name(value) {
            console.log("Actual count " + value);
            expect(count).toEqual(value, "Failed to validate count for the assertion Expected " + count + " Actual " + value);
        });
    }
    GetTextValidate(text) {
        console.log("Assertion to validate text Expected " + text);
        let textReturn = null;
        this.element.getText().then(function name(value) {
            textReturn = value;
            expect(text).toEqual(value, "Failed to validate text Actual text" + value + " Expected text " + text);
            return value;
        });
        return textReturn;
    }
    GetTitleValidate(value) {
        protractor_1.browser.getTitle().then(function (text) {
            expect(value).toEqual(text);
        });
    }
    ValidateElementisDisplayed(value) {
        this.element.isDisplayed().then(function (value) {
            expect(value).toBe(true);
            return value;
        });
        return !value;
    }
}
exports.AssertionLib = AssertionLib;
