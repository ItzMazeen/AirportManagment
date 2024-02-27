using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IFlightMethods
    {
        List<DateTime> GetFlightDates(string destination);
        void GetFlights(string filtreType, string filtreValue);
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> OrderDurationFlights();
        IEnumerable<Traveller> SeniorTravellers(Flight f);

        IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights();
    }
}
