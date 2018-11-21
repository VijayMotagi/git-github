import { browser, element, by } from "protractor";
export class HomeDashboardPO{
    // using objects
   
    public leftmenu_homedashboard = element(by.css("li#dashboard > a"))
    public leftmenu_csr = element(by.css("li#csr > a"))
    public leftmenu_districtmeteringanalysis = element(by.css("li#districtmeteringanalysis > a"))
    // using method
    lefmenuselect(menuName:string){
        console.log('Left Panel menu selction')
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