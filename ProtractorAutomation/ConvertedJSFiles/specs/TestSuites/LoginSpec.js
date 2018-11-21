"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const protractor_1 = require("protractor");
const LoginLib_1 = require("../../pages/Lib/LoginLib");
const LoginPO_1 = require("../../pages/PO/LoginPO");
const HomeDashboardPO_1 = require("../../pages/PO/HomeDashboardPO");
const SelectLib_1 = require("../../common/WebDriverLib/SelectLib");
const CSRPO_1 = require("../../pages/PO/CSRPO");
const AssertionLib_1 = require("../../common/AssertionLib/AssertionLib");
let loginLib = new LoginLib_1.LoginLib();
let loginPO = new LoginPO_1.LoginPO();
let csrPO = new CSRPO_1.CSRPO();
let homedashboardPO = new HomeDashboardPO_1.HomeDashboardPO();
fdescribe("Page Object Model in Protractor", function () {
    protractor_1.browser.ignoreSynchronization = true; // for non-angular websites
    var originalTimeout;
    beforeEach(function () {
        originalTimeout = jasmine.DEFAULT_TIMEOUT_INTERVAL,
            jasmine.DEFAULT_TIMEOUT_INTERVAL = 2500000;
    });
    afterEach(function () {
        jasmine.DEFAULT_TIMEOUT_INTERVAL = originalTimeout;
    });
    fit("Login page test case", function () {
        let assertionLib = new AssertionLib_1.AssertionLib();
        protractor_1.browser.get("https://ia-test-auto-3.devanalytics.com/AnalyticsPortal_T1/#/");
        protractor_1.browser.waitForAngular();
        var EC = protractor_1.browser.ExpectedConditions;
        // Wait for new page url to contain newPageName
        protractor_1.browser.wait(EC.urlContains('https://ia-test-auto-3.devanalytics.com/AnalyticsPortal_T1/#/login'), 120000);
        loginLib.LoginToApp("iaserviceuser", "1tronIap!");
        protractor_1.browser.wait(EC.urlContains('#/dashboard'), 120000);
        protractor_1.browser.sleep(5000);
        assertionLib.GetTitleValidate('Home Dashboard');
        // element(by.id("dashboard")).isDisplayed().then(function (value) {
        //   console.log("Element is displayed " + value)
        //   expect(value).toBe(true);
        //   //return value
        // });
        assertionLib = new AssertionLib_1.AssertionLib(protractor_1.element(protractor_1.by.id("dashboard")));
        assertionLib.ValidateElementisDisplayed(true);
        protractor_1.browser.sleep(5000);
        homedashboardPO.lefmenuselect("csr");
        assertionLib.GetTitleValidate('Customer Service');
        protractor_1.browser.sleep(5000);
        var allOptions = csrPO.basicSearchDropDownItems;
        assertionLib = new AssertionLib_1.AssertionLib(null, allOptions);
        assertionLib.CountValidate(7);
        var firstOption = allOptions.first();
        assertionLib = new AssertionLib_1.AssertionLib(firstOption);
        assertionLib.GetTextValidate("Account Name");
        let sel = new SelectLib_1.Select(csrPO.basicSearchDropDown);
        sel.selectByVisibleText("Service Point");
        sel = new SelectLib_1.Select(csrPO.basicSearchDropDown);
        sel.selectByVisibleText("Account Name");
        sel = new SelectLib_1.Select(csrPO.basicSearchDropDown);
        sel.selectByVisibleText("Account Number");
        sel = new SelectLib_1.Select(csrPO.basicSearchDropDown);
        sel.selectByVisibleText("Service Point");
        protractor_1.browser.sleep(5000);
        homedashboardPO.lefmenuselect("homedashboard");
        assertionLib.GetTitleValidate('Home Dashboard');
    });
    xit("click operation", function () {
        protractor_1.browser.get("https://google.com");
        loginPO.feelingLucky().click();
    });
});
