"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.config = {
    seleniumAddress: 'http://localhost:4444/wd/hub',
    //This is for Multiple instances
    // multiCapabilities: [{
    //   browserName: 'firefox'
    // }, {
    //   browserName: 'chrome'
    // }],
    // This is for Single instance
    capabilities: {
        'browserName': 'chrome',
        'chromeOptions': {
            args: ['--disable-browser-side-navigation']
        }
    },
    framework: 'jasmine',
    specs: ['./specs/**/*.js', './specs/TestSuites/**/*.js'],
    jasmineNodeOpts: {
        defaultTimeoutInterval: 2500000
    },
    onPrepare: () => {
        let globals = require('protractor');
        let browser = globals.browser;
        browser.manage().window().maximize();
        browser.manage().timeouts().implicitlyWait(60000);
    }
};
