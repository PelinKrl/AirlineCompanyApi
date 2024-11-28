# AirlineCompanyApi

Data Model
Below is the Entity-Relationship Diagram (ERD) for the project:

ER Diagram
![Ekran görüntüsü 2024-11-28 222448](https://github.com/user-attachments/assets/f734fd19-1292-4d08-a4be-542d24272e8e)


Tables
Flights Table
Id (Primary Key)
From (City of departure)
To (City of arrival)
AvailableDates (Comma-separated dates for flight availability)
Days (Comma-separated days of operation, e.g., Mon, Tue)
Capacity (Total number of seats)
BookedSeats (Number of seats already booked)

Tickets Table
Id (Primary Key)
FlightId (Foreign Key to Flights)
PassengerFullName (Name of the passenger)
BookingDate (Date and time of booking)
CheckedIn (Boolean indicating if the passenger has checked in)
API Documentation
You can access the API documentation via Swagger at the following URL (once the project is running):

AirlineCompanyWebAPI Deployed -----> https://airlinecompanyapi20241128160828.azurewebsites.net/index.html
Endpoints
Flights
POST /api/Flight/InsertFlight
GET /api/Flight/QueryFlights
GET /api/Flight/ReportFlights
Tickets
POST /api/Ticket/Book
POST /api/Ticket/CheckIn
Challenges Encountered
Deployment to azure with migrations.

Design Explanation: 
The Airline Company API is designed to manage flights, tickets, and users. It includes three primary entities: Flights, Tickets, and Users. The Flights entity represents scheduled flights with attributes such as origin, destination, operating dates, and capacity, while the Tickets entity manages individual bookings, linking each ticket to a specific flight and including details like passenger name, booking date, and check-in status. For simplicity, the Users entity does not interact with a database in this example, as the registration functionality is not implemented. Instead, a set of predefined users is stored in the code for demonstration purposes: { Username = "admin", Password = "password" }, { Username = "user1", Password = "user1pass" }, and { Username = "user2", Password = "user2pass" }. This approach facilitates authentication without requiring additional complexity. The relationships between entities are well-defined, with one flight supporting multiple tickets and users being able to book multiple tickets.

Test Cases: 
1.POST /Login/Login
Input1: {
  "username": "admin",
  "password": "password"
}
Input2: {
  "username": "user1",
  "password": "user1pass"
}
Input3: {
  "username": "user2",
  "password": "user2pass"
}
Input3:  {
  "username": "user3",
  "password": "user3pass"
}

POST /Flight/InsertFlight
Valid Input:
Version : 1.0
Input1:
{ 
   "From": "New York", 
   "To": "Los Angeles", 
   "AvailableDates":"2024-12-01,2024-12-10", 
   "Days":"Mon,Wed,Fri", 
   "Capacity": 200 
}
Input 2:
{ 
   "From": "London", 
   "To": "Paris", 
   "AvailableDates": "2024-12-05,2024-12-10", 
   "Days": "Tue,Thu,Sat", 
   "Capacity": 150 
}
Input 3:
{ 
   "From": "Dubai", 
   "To": "Mumbai", 
   "AvailableDates": "2024-11-20,2024-11-25", 
   "Days": "Sun,Mon,Fri", 
   "Capacity": 180 
}
Expected Output: HTTP 200 OK, {"message": "Flight added successfully"}.

3.GET/Flight/QueryFlights
Input 1 Parameters:
from: Tokyo
to: Seoul
date: Leave blank
pageNumber: 1
pageSize: 10
version: 1

Input 2 Parameters:
from: Sydney
to: Melbourne
date: 2024-12-15
pageNumber: 1
pageSize: 10
version: 1

Input 3 Parameters:
from: San Francisco
to: Chicago
date: 2024-12-10
pageNumber: 1
pageSize: 10
version: 1

4.GET/Flight/ReportFlights
Input:
from: New York
to: Los Angeles
date: 2024-12-01
capacity: 150
pageNumber: 1
pageSize: 10
version: 1.0

5.POST/Ticket/Book
Valid Input
json
Copy code
{
  "flightId": 1,
  "passengerFullName": "John Doe",
  "bookingDate": "2024-12-15T10:00:00Z"
}
6.POST/Ticket/CheckIn (in order to this end point work first booking must be done)
Insert Ticket Id: 
1 

Video Link: https://youtu.be/2g1Is-KGEWw
