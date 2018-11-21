"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const protractor_1 = require("protractor");
class HomeDashboardPO {
    constructor() {
        // using objects
        this.leftmenu_homedashboard = protractor_1.element(protractor_1.by.css("li#dashboard > a"));
        this.leftmenu_csr = protractor_1.element(protractor_1.by.css("li#csr > a"));
        this.leftmenu_districtmeteringanalysis = protractor_1.element(protractor_1.by.css("li#districtmeteringanalysis > a"));
    }
    // using method
    lefmenuselect(menuName) {
        console.log('Left Panel menu selction');
        switch (menuName.toLowerCase()) {
            case 'csr':
                console.log('Selecting CSR dashboard');
                this.leftmenu_csr.click();
                break;
            case 'districtmeteringanalysis':
                console.log('Selecting districtmeteringanalysis dashboard');
                this.leftmenu_districtmeteringanalysis.click();
                break;
            case 'homedashboard':
                console.log('Selecting homedashboard dashboard');
                this.leftmenu_homedashboard.click();
                break;
            default:
                console.log('Mane name not matched, so could not select any menu');
        }
    }
}
exports.HomeDashboardPO = HomeDashboardPO;
