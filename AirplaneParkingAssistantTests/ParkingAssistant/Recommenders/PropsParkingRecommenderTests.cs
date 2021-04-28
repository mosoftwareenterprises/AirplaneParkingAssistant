using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;

namespace AirplaneParkingAssistant.ParkingAssistant.Tests
{
    [TestClass()]
    public class PropsParkingRecommenderTests
    {
        [TestMethod()]
        public void IsThereASpaceFree_ValidAircraftEmptyFirstSlot_FindsFirstSlot()
        {
            //Arrange
            var systemUnderTest = new PropsParkingRecommender( new DataStore() );

            //Act
            bool result = systemUnderTest.IsThereASpaceFree( new ParkIngAssistantModel { aircraftType = AircraftType.E195 }, out string foundParkingSpace );

            //Assert
            Assert.IsTrue( result, "Did not find a parking space" );
            Assert.AreEqual( "Props_0", foundParkingSpace, "Incorrect slot found" );
        }

        [TestMethod()]
        public void IsThereASpaceFree_JetAircraftSupplied_FailsToFindSlot()
        {
            //Arrange
            var systemUnderTest = new PropsParkingRecommender( new DataStore() );

            //Act
            bool result = systemUnderTest.IsThereASpaceFree( new ParkIngAssistantModel { aircraftType = AircraftType.A330 }, out string foundParkingSpace );

            //Assert
            Assert.IsFalse( result, "Found a parking space" );
            Assert.AreEqual( string.Empty, foundParkingSpace, "Incorrect slot found" );
        }

        [TestMethod()]
        public void IsThereASpaceFree_ValidFlightSlotsAllFilled_FailsToFindSlot()
        {
            //Arrange
            var dataStore = Mock.Create<IDataStore>();
            Mock.Arrange( () => dataStore.FindAvailableSpace( AircraftModel.Props ) ).Returns( string.Empty );
            var systemUnderTest = new PropsParkingRecommender( dataStore );

            //Act
            bool result = systemUnderTest.IsThereASpaceFree( new ParkIngAssistantModel { aircraftType = AircraftType.E195 }, out string foundParkingSpace );

            //Assert
            Assert.IsFalse( result, "Found a parking space" );
            Assert.AreEqual( string.Empty, foundParkingSpace, "Incorrect slot found" );
        }
    }
}