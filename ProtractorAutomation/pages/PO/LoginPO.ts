import { browser, element, by } from "protractor";
export class LoginPO{
    // using variables
   
    public static userName = element(by.name("username"))
    public static password = element(by.name("password"))
    public static loginBtn = element(by.css("button.btn.btn-danger.ng-binding"))
    // using method
    feelingLucky(){
        return element(by.name("btnI"))
    }
}