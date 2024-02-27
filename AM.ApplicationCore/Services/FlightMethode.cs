using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class FlightMethode:IFlightMethods
    {
        public List<Flight> Flights = new List<Flight>();
        public Action<Plane> FlighDetailsDel;
        public Func<string, double> DurationAverageDel;
        public FlightMethode() {
            FlighDetailsDel = ShowFlightDetails;
            DurationAverageDel = DurationAverage;
        }

        public double DurationAverage(string destination)
        {
            //var req = from f in Flights where f.Destination == destination select f.EstimatedDuration;

            var req2 = Flights.Where(f => f.Destination == destination).Average(f => f.EstimatedDuration);

            return req2;
        }

        public IEnumerable<Flight> OrderDurationFlights()
        {
            //var req = from f in Flights
            //          orderby f.EstimatedDuration descending
            //          select f;
            
            var req2=Flights.OrderByDescending(f => f.EstimatedDuration);
            return req2;
        }

        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> dates2 = new List<DateTime>();
            //foreach (Flight f in Flights)
            //{
            //    if (f.Destination == destination)
            //        dates.Add(f.FlightDate);
            //}
            //    return dates;

            //dates = (from f in Flights
            //        where f.Destination == destination
            //        select f.FlightDate).ToList();
            
            dates2 = Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();
            return dates2;

        }

        public void GetFlights(string filtreType, string filtreValue)
        {
            switch (filtreType)
            {
                case "Destination":
                        foreach(Flight f in Flights)
                        if(f.Destination.Equals(filtreValue))
                            Console.WriteLine(f);
                    break;
                case "Departure":
                    foreach (Flight f in Flights)
                        if (f.Departure.Equals(filtreValue))
                            Console.WriteLine(f);
                    break;
                case "FlightDate":
                    foreach (Flight f in Flights)
                        if (f.FlightDate.Equals(DateTime.Parse(filtreValue)))
                            Console.WriteLine(f);
                    break;
                case "EstimatedDuration":
                    foreach (Flight f in Flights)
                        if (f.EstimatedDuration.Equals(int.Parse(filtreValue)))
                            Console.WriteLine(f);
                    break;
                    default: Console.WriteLine("Filtre introuvable");
                    break;
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //var req = from f in Flights
            //          where (f.FlightDate - startDate).TotalDays < 7 && (f.FlightDate - startDate).TotalDays > 0
            //          select f;
            var req2= Flights.Where(f=>DateTime.Compare(startDate,f.FlightDate)<0 && (f.FlightDate-startDate).TotalDays < 7);
            return req2.Count();
        }

        public void ShowFlightDetails(Plane plane)
        {
            //var req = from f in Flights
            //                          where f.Plane == plane
            //                          select new { f.FlightDate, f.Destination };

            var req2 = Flights.Where(f => f.Plane == plane).Select(f => new { f.FlightDate, f.Destination });
            foreach (var f in req2)
                Console.WriteLine(f);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight f)
        {
            //var req = from t in f.Passengers.OfType<Traveller>()
            //          orderby t.BirthDate
            //          select t;
            var req2 = f.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);
            return req2.Take(3);
        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var req2 = Flights.GroupBy(f => f.Destination);

            //var req = from f in Flights
            //          group f by f.Destination;
            foreach(var g in req2)
            {
                Console.WriteLine(g.Key);
                foreach(var f in g)
                
                    Console.WriteLine(f);
                
            }
            return req2;

            
        }
    }
}
