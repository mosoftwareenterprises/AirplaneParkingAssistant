using System.Linq;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public interface IDataStore
    {
        bool Store( ParkIngAssistantModel aircraft, string spotToParkIn );

        string FindAvailableSpace( AircraftModel aircraft );
    }
}