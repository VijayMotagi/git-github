import { ElementFinder, browser, by, element } from 'protractor';
xdescribe('Protractor Demo App', function() {
  var firstNumber = element(by.model('first'));
  var secondNumber = element(by.model('second'));
  var goButton = element(by.id('gobutton'));
  var latestResult = element(by.binding('latest'));

  beforeEach(function() {
    browser.get('http://juliemr.github.io/protractor-demo/');
  });

  xit('should have a title', function() {
      
       
       browser.getTitle().then(function (text) {
        expect(text).toEqual('Super Calculator');
      });
  });

  xit('should add one and two', function() {
    firstNumber.sendKeys(1);
    secondNumber.sendKeys(2);

    goButton.click();

    //expect(latestResult.getText().then.toString()).toEqual('3');
    latestResult.getText().then(function (text) {
      expect(text).toEqual('3');
    });
  });

  xit('should add four and six', function() {
    // Fill this in.
    firstNumber.sendKeys(4);
    secondNumber.sendKeys(6);
    goButton.click();
    //expect(latestResult.getText().then.toString()).toEqual('10');
    latestResult.getText().then(function (text) {
      console.log(text);
      expect(text).toEqual('10');
    });
  });

  xit('should read the value from an input', function() {
    firstNumber.sendKeys(1);
    //expect(firstNumber.getAttribute('value').then.toString()).toEqual('1');
    firstNumber.getAttribute('value').then(function (text) {
      expect(text).toEqual('1');
    });
  });
});