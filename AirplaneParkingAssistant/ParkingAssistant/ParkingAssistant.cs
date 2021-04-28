using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirplaneParkingAssistant.ParkingAssistant
{
    public class ParkingAssistant
    {
        private readonly IDataStore dataStore;

        private List<IParkingRecommender> AllOrderedParkingRecommenders;

        public ParkingAssistant( IDataStore dataStore, JumboParkingRecommender jumboParkingRecommender, JetParkingRecommender jetParkingRecommender, PropsParkingRecommender propsParkingRecommender )
        {
            this.dataStore = dataStore;
            //This is ordered smallest space to biggest, so it finds the smallest parking spot first
            AllOrderedParkingRecommenders = new List<IParkingRecommender> {
                propsParkingRecommender,
                jetParkingRecommender,
            jumboParkingRecommender            };
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