using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class ParkingAssistant
    {
        private readonly IDataStore dataStore;

        private IList<IParkingRecommender> AllOrderedParkingRecommenders;

        public ParkingAssistant( IDataStore dataStore, IEnumerable<IParkingRecommender> parkingRecommenders )
        {
            this.dataStore = dataStore;
            AllOrderedParkingRecommenders = parkingRecommenders.ToList();
        }

        public async Task<string> RecommendSpot( ParkIngAssistantModel aircraft )
        {
            string availableSpace = string.Empty;
            foreach (IParkingRecommender recommender in AllOrderedParkingRecommenders)
            {
                if (recommender.IsThereASpaceFree( aircraft, out availableSpace ))
                {
                    break;
                }
            }
            return availableSpace;
        }

        public async Task<bool> Park( ParkIngAssistantModel aircraft, string spotToParkIn )
        {
            return dataStore.Store( aircraft, spotToParkIn );
        }
    }
}