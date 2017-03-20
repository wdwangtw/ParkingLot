using System.Collections.Generic;
using ParkingLots;
using Xunit;

namespace Test_ParkingLot
{
    public class SmartParkingBoyFacts
    {
        [Fact]
        void should_pick_the_car_from_parking_lots_when_park_a_car_by_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { parkingLot });
            smartParkingBoy.Park(car);
            
            Car pickedCar = parkingLot.Pick(carId);
            
            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_parking_boy_when_park_a_car_to_parking_lot()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { parkingLot });
            parkingLot.Park(car);

            Car pickedCar = smartParkingBoy.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_parking_boy_when_park_a_car_by_parking_lot()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { parkingLot });
            smartParkingBoy.Park(car);

            Car pickedCar = smartParkingBoy.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_not_park_car_when_all_parking_lot_are_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { firstParkingLot, secondParkingLot });
            smartParkingBoy.Park(new Car("Not care1"));
            ParkCarResult parkCarResult = smartParkingBoy.Park(new Car("Not care2"));
            Assert.Equal(ParkCarResult.Success, parkCarResult);

            parkCarResult = smartParkingBoy.Park(new Car("Not care3"));

            Assert.Equal(ParkCarResult.NoParkingSpace, parkCarResult);
        }

        [Fact]
        void should_not_pick_a_car_when_the_car_has_been_picked_by_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { parkingLot });
            smartParkingBoy.Park(car);
            Car pickedCar = smartParkingBoy.Pick(carId);
            Assert.Same(car, pickedCar);

            pickedCar = smartParkingBoy.Pick(carId);
            Assert.Null(pickedCar);
        }

        [Fact]
        void should_park_a_car_to_second_parking_lot_when_the_second_one_has_more_parking_space()
        {
            var firstParkingLot = new ParkingLot(4);
            var secondParkingLot = new ParkingLot(4);
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { firstParkingLot, secondParkingLot });
            firstParkingLot.Park(new Car("notcare"));
            const string carId = "123";
            var car = new Car(carId);

            smartParkingBoy.Park(car);

            Assert.Same(car, secondParkingLot.Pick(carId));
        }
    }
}
