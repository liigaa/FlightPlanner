using System.Collections.Generic;

namespace FlightPlanner
{
    public class PageResult
    {
        public int Page { get; set; }
        public int TotalItems { get; set; }
        public List<Flight> Items { get; set; }

        public PageResult(List<Flight> flight)
        {
            Items = flight;
            TotalItems = flight.Count;
        }
    }
}
