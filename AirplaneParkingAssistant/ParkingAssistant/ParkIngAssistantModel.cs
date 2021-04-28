namespace AirplaneParkingAssistant.ParkingAssistant
{
    public enum AircraftType
    {
        A380,
        B747,
        A330,
        B777,
        E195
    }

    public class ParkIngAssistantModel
    {
        public AircraftType aircraftType { get; set; }
    }
}