# BeerCellarTest
This project uses Angular 8 and .NET Core 3.1 Framework.

I used an onion architecture in the Web API. In the Domain layer, I placed all the models and interfaces that the API needs.
These interfaces will be registered together with their corresponding implementations to the service collection in Startup.cs 
to be able to inject it to the constructors of the services and controllers that need it. In the infrastructure layer, I used gateway
interfaces to my concrete classes to be able to couple it loosely to the services that uses it in case if I want to replace the existing
gateway implementations. In the service layer, there are service classes that does not have that much functionality for now besides calling
the methods in the gateway and passes its result to the controller and vice versa. The controller uses these services by getting its instance
in the DI container provided by the framework itself.

In the client application, I just used bootstrap grid, cards, and modals to display the beer logos and details. The details will be displayed
in the modal component by inputting the data from the dashboard component to the modal component. The sorting functionality has 3 options
(name, abv, date of creation). The filter functionality could only filter the beers for their category only.

I used the BreweryDB sandbox API to collect samples of data of beers. Its endpoints are being called in the gateways in the infrastructure layer
by using HttpClient. This HttpClient is also registered in the DI container.

The remaining sub-tasks and the adding of new bottles are missing due to time restrictions.
