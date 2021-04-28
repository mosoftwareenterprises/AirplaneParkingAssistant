using System.Collections.Generic;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class JumboParkingRecommender : IParkingRecommender
    {
        private readonly IDataStore dataStore;
        private List<AircraftType> validAircraftTypes = new List<AircraftType> { AircraftType.A380, AircraftType.B747, AircraftType.A330, AircraftType.B777, AircraftType.E195 };

        public JumboParkingRecommender( IDataStore dataStore )
        {
            this.dataStore = dataStore;
        }

        public bool IsThereASpaceFree( ParkIngAssistantModel aircraft, out string availableSpace )
        {
            availableSpace = string.Empty;
            if (validAircraftTypes.Contains( aircraft.aircraftType ))
            {
                //We are allowed to park here, so lets see if there are any spaces
                availableSpace = dataStore.FindAvailableSpace( AircraftModel.Jumbos );
                if (!string.IsNullOrEmpty( availableSpace ))
                {
                    return true;
                }
            }
            return false;
        }
    }
}