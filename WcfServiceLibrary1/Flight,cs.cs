using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceLibrary1
{
    [DataContract]
    public class Flights_cs
    {
       
        [DataMember]
        public int FlightNumber { get; set; }
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string LocationFrom { get; set; }
        [DataMember]
        public string LocationTo { get; set; }
        [DataMember]
        public DateTime DepartureDate { get; set; }
        [DataMember]
        public DateTime ArrivalDate { get; set; }

         public Flights_cs (int flightNumber, string type, string locationFrom, string locationTo, DateTime departureDate, DateTime arrivalDate)
        {
            this.FlightNumber = flightNumber;
            this.Type = type;
            this.LocationFrom = locationFrom;
            this.LocationTo = locationTo;
            this.DepartureDate = departureDate;
            this.ArrivalDate = arrivalDate;

        }
        public Flights_cs()
        {

        }

        


    }

}
