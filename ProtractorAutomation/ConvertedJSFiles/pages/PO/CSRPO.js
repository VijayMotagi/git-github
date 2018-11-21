"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const protractor_1 = require("protractor");
class CSRPO {
    constructor() {
        // using variables
        this.basicSearchDropDown = protractor_1.element(protractor_1.by.xpath("//select[@id='csr_basic_search_field']"));
        this.basicSearchDropDownItems = protractor_1.element.all(protractor_1.by.options("field.queryName as field.displayName for field in vm.simpleSearchAttribute | orderBy: 'displayName' "));
    }
}
exports.CSRPO = CSRPO;
