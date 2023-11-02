# AutomationFrameWork

Your goal is to automate the test case using Selenium + C#. Please follow all best practices and patterns that can be applied to the current task.

Test case:


Navigate to https://www.ebay.com/
In the ‘Search’ field enter “Iphone 14 pro max 128gb” and click Search button


Check that all results on the first page meet the search criteria
Open one of the advertisements
Select ‘Color’ and ‘Quantity’


Click the ‘Add to cart’ button


Check that the selected item is added to your cart with the correct price.

## Exception Handled

* 1. Checkout as guest popup appears sometime
* 2. Login page appears sometimes
  3. Removed "chrome is controlled by automation software banner" which will cause less captcha verificaiton
 
## Unhandled Exception
* 1 capcha verification if appear. verify manually and re-run case

## TO DO
* if i get time, i need to introduce config file to read variables instead of hardcoded values
* some more refactoring
  
