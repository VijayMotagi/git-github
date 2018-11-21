import { browser, element, by } from "protractor";
import { LoginLib } from "../../pages/Lib/LoginLib";
import { LoginPO } from "../../pages/PO/LoginPO";
import { HomeDashboardPO } from "../../pages/PO/HomeDashboardPO"
import { Select } from "../../common/WebDriverLib/SelectLib";
import { CSRPO } from "../../pages/PO/CSRPO";
import { AssertionLib } from "../../common/AssertionLib/AssertionLib";
let loginLib = new LoginLib()
let loginPO =new LoginPO()
let csrPO=new CSRPO();
let homedashboardPO=new HomeDashboardPO()
describe("Page Object Model in Protractor", function(){
  browser.ignoreSynchronization = true; // for non-angular websites
  var originalTimeout;

    beforeEach(function() {
        originalTimeout = jasmine.DEFAULT_TIMEOUT_INTERVAL,
        jasmine.DEFAULT_TIMEOUT_INTERVAL = 2500000
    });

    afterEach(function() {
      jasmine.DEFAULT_TIMEOUT_INTERVAL = originalTimeout;
    });
  it("Login page test case",function(){
    let assertionLib=new AssertionLib();
    browser.get("https://ia-test-auto-3.devanalytics.com/AnalyticsPortal_T1/#/")
    browser.waitForAngular();
    var EC = browser.ExpectedConditions;
    // Wait for new page url to contain newPageName
    browser.wait(EC.urlContains('https://ia-test-auto-3.devanalytics.com/AnalyticsPortal_T1/#/login'), 120000); 
    loginLib.LoginToApp("iaserviceuser","1tronIap!");
    browser.wait(EC.urlContains('#/dashboard'), 120000); 
    browser.sleep(5000);
    
    assertionLib.GetTitleValidate('Home Dashboard')

    // element(by.id("dashboard")).isDisplayed().then(function (value) {
    //   console.log("Element is displayed " + value)
    //   expect(value).toBe(true);
    //   //return value
    // });
    assertionLib=new AssertionLib(element(by.id("dashboard")))
    assertionLib.ValidateElementisDisplayed(true);
    
    browser.sleep(5000);
    
    homedashboardPO.lefmenuselect("csr")
    assertionLib.GetTitleValidate('Customer Service')
    
    browser.sleep(5000);
    
    var allOptions = csrPO.basicSearchDropDownItems;
    
    assertionLib =new AssertionLib(null,allOptions);
    assertionLib.CountValidate(7);

    var firstOption = allOptions.first();
    
    assertionLib=new AssertionLib(firstOption);
    assertionLib.GetTextValidate("Account Name");
    
    let sel:Select = new Select(csrPO.basicSearchDropDown);
    sel.selectByVisibleText("Service Point")
    
    sel = new Select(csrPO.basicSearchDropDown);
    sel.selectByVisibleText("Account Name")

    sel = new Select(csrPO.basicSearchDropDown);
    sel.selectByVisibleText("Account Number")
    
    sel = new Select(csrPO.basicSearchDropDown);
    sel.selectByVisibleText("Service Point")
    
    browser.sleep(5000)
    
    homedashboardPO.lefmenuselect("homedashboard")
    assertionLib.GetTitleValidate('Home Dashboard')


  });
  xit("click operation",function(){
    browser.get("https://google.com")
    loginPO.feelingLucky().click()
  });
});