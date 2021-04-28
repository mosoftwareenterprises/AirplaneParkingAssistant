using System.Collections.Generic;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class PropsParkingRecommender : IParkingRecommender
    {
        private readonly IDataStore dataStore;
        private List<AircraftType> validAircraftTypes = new List<AircraftType> { AircraftType.E195 };

        public PropsParkingRecommender( IDataStore dataStore )
        {
            this.dataStore = dataStore;
        }

        public bool IsThereASpaceFree( ParkIngAssistantModel aircraft, out string availableSpace )
        {
            availableSpace = string.Empty;
            if (validAircraftTypes.Contains( aircraft.aircraftType ))
            {
                //We are allowed to park here, so lets see if there are any spaces
                availableSpace = dataStore.FindAvailableSpace( AircraftModel.Props );
                if (!string.IsNullOrEmpty( availableSpace ))
                {
                    return true;
                }
            }
            return false;
        }
    }
}