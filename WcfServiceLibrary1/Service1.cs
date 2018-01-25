using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public List<Flights_cs> list = new List<Flights_cs>();

        Flights_cs flight1 = new Flights_cs(1, "Boeiing", "Poprad", "Praha", DateTime.Parse("01.01.2018 15:00"), DateTime.Parse("02.02.2018 15:00"));
        Flights_cs flight2 = new Flights_cs(2, "Aero L-59 Super Albatros", "Hapiness", "Sadness", DateTime.Parse("02.02.2018 15:00"), DateTime.Parse("21.02.2018 22:00"));
        object myLock = new object();
        public void Add(Flights_cs flight)
        {
            list.Add(flight);
        }
        public void Populate()
        {
            Add(flight1);
            Add(flight2);
        }
        public string ChangeFlight(int flightNumber, string type, string locationFrom, string locationTo, DateTime departureTime, DateTime arrivalTime)
        {
            lock (myLock)
            {
                Flights_cs flight = FindFlightByID(flightNumber);
                string message = "";
                if (flight != null)
                {
                    flight.Type = type;
                    flight.LocationFrom = locationFrom;
                    flight.LocationTo = locationTo;
                    flight.DepartureDate = departureTime;
                    flight.ArrivalDate = arrivalTime;
                    message = "You changed the flight";
                }
                else
                {
                    message = "Flight not found";
                }
                return message;
            }
        }

        public Flights_cs FindFlightByID(int flightNumber)
        {
            lock (myLock)
            {
                Populate();
                Flights_cs a = new Flights_cs();
                a = null;
                foreach (Flights_cs m in list)
                {
                    if (m.FlightNumber == flightNumber)
                    {
                        a = m;
                    }

                }
                return a;
            }
        }

        public List<Flights_cs> GetData()
        {
            lock (myLock)
            {
                Populate();
                return list.ToList();
            }
        }

       
    }
}
