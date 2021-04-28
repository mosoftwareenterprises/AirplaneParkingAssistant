using System.Threading.Tasks;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class ParkingAssistant
    {
        public async Task<string> RecommendSpot( ParkIngAssistantModel aircraft )
        {
            return "1";
        }

        public async Task<bool> Park( string spotToParkIn )
        {
            return true;
        }
    }
}