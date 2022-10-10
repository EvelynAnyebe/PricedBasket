# PricedBasket

This is a program that can price a basket of goods whilst allowing for special offers.

## Assumptions
- This program assumes that a store already exists with goods/products and special offers defined.
- The current special offer runs for this week

## The store data
```
Currently available goods are: 
 
•	Beans – 98p per tin - 10
•	Bread – 84p per loaf - 10
•	Milk – £1.50 per bottle - 10
•	Oranges – £1.90 per bag - 10
```
 
```
Current special offers are: 

•	Oranges have 20% discount this week 
•	Multi-buy offer – buy 2 tins of beans and get a half price loaf of bread 
```

This application is designed such that the BasketManager can receive data from a database and initialize its store as needed.

## Design

Classes:

- Product
- OfferType
- SpecialOffer

Are models that represents tha data objects in the store.

### Message Manager
This is a messaging module or component to handle message sending, and display of information to the user.

### Basket Manager
This is the controller of the application. It is assisted by `CurrencyManager` and `Message Manager`

### The main program provide the launch and calls the `BasketManager`

## Extension

- The error management and logging can be improved
- More tests cases can be added
- Extensible to use a database
- Forms can be created to get input.

## Test and Excution
- Clone this repository
-  Open it with Visual Studio
-  Run test
-  Run the program in debug mode.


