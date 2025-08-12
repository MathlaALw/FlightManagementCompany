# Flight Management System Summary

## Flight Management System - ERD 

![Flight Management System ERD](./Image/FMS-ERD.png)

### Entity-Relationship Diagram (ERD) for the Flight Management System, which manages flights, aircraft, crews, bookings, passengers, and airports.


### 1. Airport
**Attributes**  
- `AirportId` (PK)  
- `IATA` (unique)  
- `Name`  
- `City`  
- `Country`  
- `TimeZone`  

**Relationships**  
- Originates **Routes** (1:N)  
- Terminates **Routes** (1:N)  

---

### 2. Aircraft
**Attributes**  
- `AircraftId` (PK)  
- `TailNumber` (unique)  
- `Model`  
- `Capacity`  

**Relationships**  
- Operates **Flights** (1:N)  
- Has **Maintenance Records** (1:N)  

---

### 3. CrewMember
**Attributes**  
- `CrewId` (PK)  
- `FullName`  
- `Role`  
- `LicenseNo`  

**Relationships**  
- Assigned to **Flights** (M:N via `FlightCrew`)  

---

### 4. Route
**Attributes**  
- `RouteId` (PK)  
- `DistanceKm`  

**Relationships**  
- Has **Origin Airport** (N:1)  
- Has **Destination Airport** (N:1)  
- Scheduled as **Flights** (1:N)  

---

### 5. Flight
**Attributes**  
- `FlightId` (PK)  
- `FlightNumber`  
- `DepartureUtc`  
- `ArrivalUtc`  
- `Status`  

**Constraints**  
- Unique (`FlightNumber`, `DepartureUtc.Date`)  

**Relationships**  
- Belongs to **Route** (N:1)  
- Operated by **Aircraft** (N:1)  
- Has **Tickets** (1:N)  
- Staffed by **CrewMembers** (M:N)  

---

### 6. Passenger
**Attributes**  
- `PassengerId` (PK)  
- `FullName`  
- `PassportNo` (unique)  
- `Nationality`  
- `DOB`  

**Relationships**  
- Makes **Bookings** (1:N)  

---

### 7. Booking
**Attributes**  
- `BookingId` (PK)  
- `BookingRef` (unique)  
- `BookingDate`  
- `Status`  

**Relationships**  
- Made by **Passenger** (N:1)  
- Contains **Tickets** (1:N)  

---

### 8. Ticket
**Attributes**  
- `TicketId` (PK)  
- `SeatNumber`  
- `Fare`  
- `CheckedIn`  

**Relationships**  
- Part of **Booking** (N:1)  
- For a **Flight** (N:1)  
- Has **Baggage** (1:N)  

---

### 9. Baggage
**Attributes**  
- `BaggageId` (PK)  
- `WeightKg`  
- `TagNumber`  

**Relationships**  
- Belongs to **Ticket** (N:1)  

---

### 10. AircraftMaintenance
**Attributes**  
- `MaintenanceId` (PK)  
- `MaintenanceDate`  
- `Type`  
- `Notes`  

**Relationships**  
- Performed on **Aircraft** (N:1)  

---

### FlightCrew
**Attributes**  
- `FlightId` (PK/FK)  
- `CrewId` (PK/FK)  
- `RoleOnFlight`  

**Purpose**  
Resolves M:N relationship between **Flight** and **CrewMember**.

# Participation Constraints - Flight Management System

## Total Participation (1..1)
These relationships require **mandatory participation** from the entity on one side:

1. **Flight → Route**  
   - Every Flight must belong to exactly one Route.

2. **Flight → Aircraft**  
   - Every Flight must be operated by exactly one Aircraft.

3. **Ticket → Booking**  
   - Every Ticket must belong to exactly one Booking.

4. **Ticket → Flight**  
   - Every Ticket must be for exactly one Flight.

5. **Booking → Ticket**  
   - Every Booking must contain at least one Ticket.

---

## Partial Participation (0..N)
These relationships allow **optional participation** from the entity on one side:

1. **Airport → Route**  
   - An Airport may have no Routes.

2. **Aircraft → Flight**  
   - An Aircraft may have no Flights assigned.

3. **Flight → FlightCrew**  
   - A Flight may have no Crew assignments.

4. **Passenger → Booking**  
   - A Passenger may have no Bookings.

5. **Ticket → Baggage**  
   - A Ticket may have no Baggage.

---