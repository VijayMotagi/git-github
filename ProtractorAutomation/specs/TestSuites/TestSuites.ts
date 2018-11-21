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

 
});