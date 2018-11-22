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
fdescribe("CSR Functionality", function(){
  browser.ignoreSynchronization = true; // for non-angular websites
  var originalTimeout;

    beforeEach(function() {
        originalTimeout = jasmine.DEFAULT_TIMEOUT_INTERVAL,
        jasmine.DEFAULT_TIMEOUT_INTERVAL = 2500000
    });

    afterEach(function() {
      jasmine.DEFAULT_TIMEOUT_INTERVAL = originalTimeout;
    });
  fit("CSR Basic Search Validation",function(){
    let assertionLib=new AssertionLib();
    browser.get("https://ia-test-auto-3.devanalytics.com/AnalyticsPortal_T1/#/")
    browser.waitForAngular();
    var EC = browser.ExpectedConditions;
    // Wait for new page url to contain newPageName
    browser.wait(EC.urlContains('https://ia-test-auto-3.devanalytics.com/AnalyticsPortal_T1/#/login'), 120000); 
    loginLib.LoginToApp("","");
    browser.wait(EC.urlContains('#/dashboard'), 120000);
    browser.sleep(5000);
    assertionLib.GetTitleValidate('Home Dashboard')

    homedashboardPO.lefmenuselect("csr")
    browser.sleep(5000);
    assertionLib.GetTitleValidate('Customer Service')

    csrPO.csr_txt_accountNumber.sendKeys('Auto');
    csrPO.csr_txt_accountNumber.clear()

    csrPO.csr_txt_accountNumber.sendKeys('Automation');
    browser.sleep(5000);

    
  });
  
});