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

    public enum AircraftModel
    {
        Jumbos,
        Jets,
        Props
    }

    public class ParkIngAssistantModel
    {
        public AircraftType aircraftType { get; set; }
    }
}