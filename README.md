# Kerridge Senior Xamarin developer

API Integration Test
Kerridge Commercial Systems has a public API available that can be used to search for places based on an
input criteria. The search results will contain some high-level information regarding the place, including its
unique id. The unique id can then be used to retrieve more detailed information regarding that place.
The API swagger page: https://staging.api.eos.kerridgecs.online/location/swagger/index.html
For this task we would like you to build an application that allows a user to search for places based on a single
input criteria, using the endpoint: /api/v1/locations/places . The app should display the full list of results
returned (showing the mainText and secondaryText for each item). Once the list has been displayed, the user
should then be able to request additional information for a specific place, using the endpoint:
/api/v1/locations/places/{id}. The following additional information should be displayed:
Name
Formatted Address
Vicinity
Url
Longitude and Latitude
UtcOffset
Authentication Authentication uses OAuth, and for this task we'll be using the client credentials flow. An
appropriate Client ID and Secret should have already been provided to you. An access token can be obtained
using the Identity Service: https://staging.identity.eos.kerridgecs.online, along with the following request:

(POST) https://staging.identity.eos.kerridgecs.online/connect/token
CONTENT-TYPE application/x-www-form-urlencoded
client_id={client_id}
client_secret={client_secret}
grant_type=client_credentials
scope=eos.common.fullaccess

Client ID:	94eb850d-448f-48ef-a085-5fee4807606e.apps.kerridgecs.com
Client Secret:	b609f130-2d13-43d4-93df-f8ab9f1cafde


Platform Choice You can create the application as either a command line application, web or mobile
application using any of the following platforms:
.NET Core for web and command line applications
.NET (Xamarin Android, Xamarin Forms or MAUI) for mobile applications
Choose an appropriate platform based on the role you are currently applying for.
Task Requirements Feel free to spend as much, or as little, time neccessary to compelete the task, as long as
the following requirements are met:
Complete the user story below
The code should compile and run in one step
Feel free to use whatever frameworks/libraries/packages that you see fit
You must include some tests



User Story As a user running the application I want to view a list of places based on a single input criteria
provided. The list should clearly show each place, showing it's main and secondary text.
As a user I want to request further, more detailed, information for any of the places returned in the original
search.
Acceptance Criteria
For a known place name, an appropriate set of results are returned
When requesting more information, the following details should be displayed:
(Name, Formatted Address, Vicinity, Url, Longitude and Latitude, UtcOffset)


