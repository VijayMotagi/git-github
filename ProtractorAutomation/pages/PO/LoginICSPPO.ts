import { browser, by, element, protractor } from 'protractor';
import { Locator } from 'protractor/built/locators';

export class Login {
    private emailInput = element(<Locator>by.css('[type="email"]'));
    private passwordInput = element(<Locator>by.css('[type="password"]'));
    private submitButton = element(<Locator>by.css('[type="submit"]'));
    private backButton = element(<Locator>by.css('*[id=\'idBtn_Back\']'));
    private expectedConditions = protractor.ExpectedConditions;

    public login(auth, url) {
        const maxTimeout = 20 * 1000;
        browser.get(url);
        browser.wait(this.expectedConditions.visibilityOf(this.emailInput), maxTimeout)
            .then(() => {
                this.emailInput.sendKeys(auth.email).then(() => {
                    this.submitButton.click();
                    browser.driver.wait(this.expectedConditions.visibilityOf(this.passwordInput), maxTimeout)
                        .then(() => {
                            this.passwordInput.sendKeys(auth.password).then(() => {
                                this.submitButton.click();
                                browser.driver.wait(this.expectedConditions.visibilityOf(this.backButton), maxTimeout)
                                    .then(() => {
                                        this.backButton.click();
                                        return true;
                                    });
                            });
                        });
                });
            });
    }
}