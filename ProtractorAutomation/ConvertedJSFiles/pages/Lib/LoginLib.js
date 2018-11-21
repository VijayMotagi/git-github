"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const LoginPO_1 = require("../PO/LoginPO");
class LoginLib {
    LoginToApp(userid, pwd) {
        LoginPO_1.LoginPO.userName.sendKeys(userid);
        LoginPO_1.LoginPO.password.sendKeys(pwd);
        LoginPO_1.LoginPO.loginBtn.click();
    }
}
exports.LoginLib = LoginLib;
