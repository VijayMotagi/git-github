import { LoginPO } from "../PO/LoginPO";
export class LoginLib{
    LoginToApp(userid :string, pwd:string){
        LoginPO.userName.sendKeys(userid)
        LoginPO.password.sendKeys(pwd)
        LoginPO.loginBtn.click();

        
    }
}

