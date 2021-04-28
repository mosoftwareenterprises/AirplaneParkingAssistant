namespace AirplaneParkingAssistant.ParkingAssistant
{
    public interface IParkingRecommender
    {
        bool IsThereASpaceFree( ParkIngAssistantModel aircraft, out string availableSpace );
    }
}