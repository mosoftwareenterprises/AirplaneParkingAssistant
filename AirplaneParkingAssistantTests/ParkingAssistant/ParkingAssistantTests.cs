using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.JustMock;

namespace AirplaneParkingAssistant.ParkingAssistant.Tests
{
    [TestClass()]
    public class ParkingAssistantTests
    {
        [TestMethod()]
        [DataRow( AircraftType.A330 )]
        [DataRow( AircraftType.A380 )]
        [DataRow( AircraftType.B747 )]
        [DataRow( AircraftType.B777 )]
        [DataRow( AircraftType.E195 )]
        public async Task RecommendSpot_SmallPlaneButOnlyBigSpotAvailable_BigSpotFound( AircraftType parkingModel )
        {
            //Arrange
            var mockedDataStore = Mock.Create<IDataStore>();
            Mock.Arrange( () => mockedDataStore.FindAvailableSpace( AircraftModel.Props ) ).Returns( string.Empty );

            IEnumerable<IParkingRecommender> recommenders = new List<IParkingRecommender> {
                new PropsParkingRecommender(mockedDataStore),
                new JetParkingRecommender(mockedDataStore),
                new JumboParkingRecommender(new DataStore())};

            var systemUnderTest = new ParkingAssistant( mockedDataStore, recommenders );

            //Act
            string spotFound = await systemUnderTest.RecommendSpot( new ParkIngAssistantModel { aircraftType = parkingModel } );

            //Assert
            Assert.AreEqual( "Jumbos_0", spotFound, "Did not promote small aircraft to big spot" );
        }
    }
}