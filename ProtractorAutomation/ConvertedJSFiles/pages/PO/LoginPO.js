"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const protractor_1 = require("protractor");
class LoginPO {
    // using method
    feelingLucky() {
        return protractor_1.element(protractor_1.by.name("btnI"));
    }
}
// using variables
LoginPO.userName = protractor_1.element(protractor_1.by.name("username"));
LoginPO.password = protractor_1.element(protractor_1.by.name("password"));
LoginPO.loginBtn = protractor_1.element(protractor_1.by.css("button.btn.btn-danger.ng-binding"));
exports.LoginPO = LoginPO;
