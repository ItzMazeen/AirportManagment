// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;

Console.WriteLine("Hello, World!");
//Initialisation non parametré
Plane p = new Plane();
p.Capacity = 100;
Console.WriteLine(p.Capacity);
p.ManufactureDate = DateTime.Now;
Console.WriteLine(p.ManufactureDate);
p.PlaneType = PlaneType.Boeing;
Console.WriteLine(p.PlaneType);

//Initialisation  parametré
//Flight f = new Flight(15,"Paris","Tunis","Boeeng")
//Initialisation à travers l'initiateur d'objet
Flight f = new Flight()
{
    Departure = "Tunis",
    Destination = "Paris",
    FlightDate = new DateTime(2024, 2, 1, 15, 33, 11),
    EffectiveArrival = new DateTime(2024, 2, 1, 17, 33, 11),
    EstimatedDuration = 120
};
//ToString()
Console.WriteLine(f);
Console.WriteLine("******* CheckProfile *************");
Passenger passenger = new Passenger()
{
    FirstName = "mazen",
    LastName = "aljane",
    EmailAdress="mazen.aljane@esprit.tn"
};
Console.WriteLine(passenger.CheckProfile("Mazen","Aljane"));
Console.WriteLine(passenger.CheckProfile("Mazen", "Aljane","haha"));
Console.WriteLine("******* Passenger Type **************");
Staff staff = new Staff();
Traveller traveller = new Traveller();
passenger.PassengerType();
staff.PassengerType();
traveller.PassengerType();
FlightMethode fn = new FlightMethode();
Console.WriteLine("************ GetFlightDates ***************");
fn.Flights = TestData.listFlights;

foreach (DateTime d  in fn.GetFlightDates("Madrid"))
{
    Console.WriteLine(d);
}
Console.WriteLine("************ GetFlight by destination ***************");
fn.GetFlights("Destination", "Paris");
Console.WriteLine("************ GetFlight by estimation ***************");
fn.GetFlights("EstimatedDuration", "200");
Console.WriteLine("************ ShowFlightDetails ***************");
fn.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("************ ProgrammedFlightNumber ***************");
Console.WriteLine(fn.ProgrammedFlightNumber(new DateTime(2021, 12, 31)));
Console.WriteLine("************ Duration Average ***************");
Console.WriteLine(fn.DurationAverage("Madrid"));
Console.WriteLine("************ Order by Duration ***************");
foreach (Flight f1 in fn.OrderDurationFlights())
Console.WriteLine(f1);
Console.WriteLine("************ Senior Travellers ***************");
foreach (Traveller t in fn.SeniorTravellers(TestData.flight1))
Console.WriteLine(t.BirthDate);
Console.WriteLine("************ Destinations Group Flights ***************");
fn.DestinationGroupedFlights();
Console.WriteLine("************ ToUpperFullName ***************");
passenger.UpperFullName();
Console.WriteLine(passenger.FirstName+" "+passenger.LastName);




