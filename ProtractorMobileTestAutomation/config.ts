import { ProtractorBrowser, Config } from 'protractor';
export let config: Config = {
  seleniumAddress: 'http://127.0.0.1:4723/wd/hub',
  //This is for Multiple instances
  // multiCapabilities: [{
  //   browserName: 'firefox'
  // }, {
  //   browserName: 'chrome'
  // }],
  // This is for Single instance
  capabilities: {
    'browserName': 'chrome',
    'platformName':'Android',
    'deviceName': 'emulator-5554', //'52004f54ea7ba441'
    //'appium-version':'1.9.1',
    //'platformVersion':'8.1.0',
    //'automationName':'Appium',
    //'newCommandTimeout':'300000',
    //'autoWebview':true,
    //'autoWebviewTimeout':'20000',
    //'chromedriverExecutable':'C:\\Users\\Vmotagi\\AppData\\Roaming\\npm\\node_modules\\appium\\node_modules\\appium-chromedriver\\chromedriver\\win\\chromedriver.exe',
    //'chromedriver-executable':'C:\\Personal Workspace\\VSCode\\Android\\chromedriver.exe',
    //'chrome.switches':'--proxy-server=http://127.0.0.1:4723/wd/hub',
    //'chromedriver-port':'4723'
    },
  framework: 'jasmine',
  specs: ['./specs/**/*.js','./specs/TestSuites/**/*.js'],
  jasmineNodeOpts: {
    defaultTimeoutInterval: 2500000
  },
  onPrepare: () => {
   let globals = require('protractor');
   let browser = globals.browser;
   //browser.manage().window().maximize();
   browser.manage().timeouts().implicitlyWait(60000);
 }
}
