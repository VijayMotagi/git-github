import {browser, by, ElementFinder } from "protractor";
export class Select {
    // dropdown
    dropdown:ElementFinder;
    //constructor  accepts dropdown as element
    constructor(dropdownElement:ElementFinder) {
       this.dropdown = dropdownElement;
       // click the dropdown
       dropdownElement.click()
       browser.sleep(1000)
    }
    public  isMultiple(visibleText:string){
        console.log("returning all options  : "+visibleText)
        // select the option
        this.dropdown.getAttribute("multiple").then(function(multipleOrNot){
            if(multipleOrNot){
                return true
            }else{
                return false;
            }
        })
    }
    public getOptions(visibleText:string){
        console.log("returning all options  : "+visibleText)
        // select the option
        this.dropdown.all(by.css("option"))
    }
    public selectByVisibleText(visibleText:string){
        console.log("Selecting element based text  : "+visibleText)
        // select the option
         this.dropdown.all(by.tagName('option')).filter
            (function optionsFilter(elem,index)
                {return elem.getText().then(function(text)
                    {return text == visibleText})}
            ).first().click();
        this.dropdown.click();       
        //browser.element(by.xpath("//select[@id='csr_basic_search_fitemield']/option[text()='Service Point']")).click();
    }

    public selectByValue(value:string){
        console.log("Selecting element based value  : "+value)
        // select the option
        this.dropdown.all(by.tagName('option')).filter
            (function optionsFilter(elem,index)
                {return elem.getAttribute("value").then(function(text)
                    {return text == value})}
            ).first().click();
        this.dropdown.click();  
        //this.dropdown.element(by.css("option[value='"+value+"']")).click()
    }
    public selectByIndex(index:number){
        index = index+1;
        console.log("Selecting element based index : "+index)
        // select the option
        this.dropdown.element(by.css("option:nth-child("+index+")")).click()
    }
 }