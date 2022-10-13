﻿using FlightPlanner.Core.Models;
using System.Collections.Generic;

namespace FlightPlanner.Core.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight GetCompleteFlightById(int id);
        bool Exists(Flight flight);
        void DeleteById(int id);
        List<Flight> GetAllFlights();
        List<Airport> GetAirports(string phrase);
        List<Flight> GetFlights(Request request);
    }
}
