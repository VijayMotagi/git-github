import {browser, by, ElementFinder, ElementArrayFinder } from "protractor";
export class AssertionLib {
    // element
    element:ElementFinder;
    elements:ElementArrayFinder;
    //constructor  accepts dropdown as element
    constructor(e:ElementFinder=null,eAll:ElementArrayFinder=null) {
       this.element = e;
       this.elements=eAll;
    }
    
    public CountValidate(count:Number)
    {
        console.log("Assertion to validate count Expected " + count)
       this.elements.count().then(function name(value:Number) {
            console.log("Actual count " + value)
            expect(count).toEqual(value,"Failed to validate count for the assertion Expected " + count +" Actual " + value)           
          })
    }

    public  GetTextValidate (text:String) : String
    {
        console.log("Assertion to validate text Expected " + text)
        let textReturn: String =null;

        this.element.getText().then(function name(value:String) {
            textReturn=value;
            expect(text).toEqual(value,"Failed to validate text Actual text" + value + " Expected text " + text)
            return value
          })  
          return textReturn;
    }
    
    public GetTitleValidate(value:String)
    {
        browser.getTitle().then(function (text) {
            expect(value).toEqual(text);
          });
    }

    public ValidateElementisDisplayed(value:Boolean): Boolean
    {
        this.element.isDisplayed().then(function (value) {
            expect(value).toBe(true);
            return value
          });
          return !value
    }
}