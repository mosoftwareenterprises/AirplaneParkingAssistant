using System.Collections.Generic;
using System.Linq;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class DataStore : IDataStore
    {
        private Dictionary<string, ParkIngAssistantModel> jumboParkingSpots = new Dictionary<string, ParkIngAssistantModel>();
        private Dictionary<string, ParkIngAssistantModel> jetParkingSpots = new Dictionary<string, ParkIngAssistantModel>();
        private Dictionary<string, ParkIngAssistantModel> propParkingSpots = new Dictionary<string, ParkIngAssistantModel>();

        public DataStore()
        {
            for (int i = 0; i < 25; i++)
            {
                jumboParkingSpots.Add( $"Jumbos_{i}", null );
                propParkingSpots.Add( $"Props_{i}", null );
            }

            for (int i = 0; i < 50; i++)
            {
                jetParkingSpots.Add( $"Jets_{i}", null );
            }
        }

        public bool Store( ParkIngAssistantModel aircraft, string spotToParkIn )
        {
            //Check we have that spot, AND its currently empty
            if (jumboParkingSpots.ContainsKey( spotToParkIn ) && jumboParkingSpots[spotToParkIn] == null)
            {
                jumboParkingSpots[spotToParkIn] = aircraft;
                return true;
            }
            else if (jetParkingSpots.ContainsKey( spotToParkIn ) && jetParkingSpots[spotToParkIn] == null)
            {
                jetParkingSpots[spotToParkIn] = aircraft;
                return true;
            }
            else if (propParkingSpots.ContainsKey( spotToParkIn ) && propParkingSpots[spotToParkIn] == null)
            {
                propParkingSpots[spotToParkIn] = aircraft;
                return true;
            }
            return false;
        }

        public string FindAvailableSpace( AircraftModel aircraft )
        {
            if (aircraft == AircraftModel.Jumbos)
            {
                var foundSpot = jumboParkingSpots.FirstOrDefault( t => t.Value == null );
                if (foundSpot.Key != null)
                {
                    return foundSpot.Key;
                }
            }
            else if (aircraft == AircraftModel.Jets)
            {
                var foundSpot = jetParkingSpots.FirstOrDefault( t => t.Value == null );
                if (foundSpot.Key != null)
                {
                    return foundSpot.Key;
                }
            }
            else if (aircraft == AircraftModel.Props)
            {
                var foundSpot = propParkingSpots.FirstOrDefault( t => t.Value == null );
                if (foundSpot.Key != null)
                {
                    return foundSpot.Key;
                }
            }

            return string.Empty;
        }
    }
}