"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const protractor_1 = require("protractor");
xdescribe('Protractor Demo App', function () {
    var firstNumber = protractor_1.element(protractor_1.by.model('first'));
    var secondNumber = protractor_1.element(protractor_1.by.model('second'));
    var goButton = protractor_1.element(protractor_1.by.id('gobutton'));
    var latestResult = protractor_1.element(protractor_1.by.binding('latest'));
    beforeEach(function () {
        protractor_1.browser.get('http://juliemr.github.io/protractor-demo/');
    });
    xit('should have a title', function () {
        protractor_1.browser.getTitle().then(function (text) {
            expect(text).toEqual('Super Calculator');
        });
    });
});
