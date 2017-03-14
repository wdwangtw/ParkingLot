using System.Collections.Generic;
using ParkingLots;
using Xunit;

namespace Test_ParkingLot
{
    public class SuperParkingBoyFacts
    {
        [Fact]
        void should_pick_the_car_from_parking_lots_when_park_a_car_by_super_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var superParkingBoy = new SuperParkingBoy(new List<PickerParker> {parkingLot});
            superParkingBoy.Park(car);
            
            Car pickedCar = parkingLot.Pick(carId);
            
            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_super_parking_boy_when_park_a_car_to_parking_lot()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var superParkingBoy = new SuperParkingBoy(new List<PickerParker> { parkingLot });
            parkingLot.Park(car);

            Car pickedCar = superParkingBoy.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_super_parking_boy_when_park_a_car_by_super_parking_lot()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var superParkingBoy = new SuperParkingBoy(new List<PickerParker> { parkingLot });
            superParkingBoy.Park(car);

            Car pickedCar = superParkingBoy.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_not_park_car_by_super_boy_when_all_parking_lot_are_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var superParkingBoy = new SuperParkingBoy(new List<PickerParker> { firstParkingLot, secondParkingLot });
            superParkingBoy.Park(new Car("Not care1"));
            ParkCarResult parkCarResult = superParkingBoy.Park(new Car("Not care2"));
            Assert.Equal(ParkCarResult.Success, parkCarResult);

            parkCarResult = superParkingBoy.Park(new Car("Not care3"));

            Assert.Equal(ParkCarResult.NoParkingSpace, parkCarResult);
        }

        [Fact]
        void should_not_pick_a_car_when_the_car_has_been_picked_by_super_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var superParkingBoy = new SuperParkingBoy(new List<PickerParker> { parkingLot });
            superParkingBoy.Park(car);
            Car pickedCar = superParkingBoy.Pick(carId);
            Assert.Same(car, pickedCar);

            pickedCar = superParkingBoy.Pick(carId);
            Assert.Null(pickedCar);
        }

        [Fact]
        void should_park_a_car_to_second_parking_lot_by_super_parking_boy_when_the_second_one_has_more_empty_parking_space_ratio()
        {
            var firstParkingLot = new ParkingLot(3);
            var secondParkingLot = new ParkingLot(1);
            var smartParkingBoy = new SuperParkingBoy(new List<PickerParker> { firstParkingLot, secondParkingLot });
            firstParkingLot.Park(new Car("notcare"));
            const string carId = "123";
            var car = new Car(carId);

            smartParkingBoy.Park(car);

            Assert.Same(car, secondParkingLot.Pick(carId));
        }
    }
}
