using System.Collections.Generic;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class JetParkingRecommender : IParkingRecommender
    {
        private readonly IDataStore dataStore;
        private List<AircraftType> validAircraftTypes = new List<AircraftType> { AircraftType.A330, AircraftType.B777, AircraftType.E195 };

        public JetParkingRecommender( IDataStore dataStore )
        {
            this.dataStore = dataStore;
        }

        public bool IsThereASpaceFree( ParkIngAssistantModel aircraft, out string availableSpace )
        {
            availableSpace = string.Empty;
            if (validAircraftTypes.Contains( aircraft.aircraftType ))
            {
                //We are allowed to park here, so lets see if there are any spaces
                availableSpace = dataStore.FindAvailableSpace( AircraftModel.Jets );
                if (!string.IsNullOrEmpty( availableSpace ))
                {
                    return true;
                }
            }
            return false;
        }
    }
}