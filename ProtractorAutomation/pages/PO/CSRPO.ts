import { browser, element, by } from "protractor";
export class CSRPO{
    // using variables
   
    public basicSearchDropDown = element(by.xpath("//select[@id='csr_basic_search_field']"))

    public basicSearchDropDownItems=element.all(by.options("field.queryName as field.displayName for field in vm.simpleSearchAttribute | orderBy: 'displayName' "));
    
    public csr_txt_accountNumber=element(by.id('csr_txt_accountNumber'))
    
}