using System;
using System.Collections.Generic;
using ParkingLots;
using Xunit;

namespace Test_ParkingLot
{
    public class ParkingBoyFacts
    {
        [Fact]
        void should_pick_the_car_when_park_a_car_by_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(new List<PickerParker> { parkingLot });
            parkingBoy.Park(car);
            
            Car pickedCar = parkingBoy.Pick(carId);
            
            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_park_the_car_in_the_first_parking_lot_when_the_first_one_is_not_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<PickerParker> { firstParkingLot, secondParkingLot });
            const string carId = "ABC123";
            var car = new Car(carId);
            parkingBoy.Park(car);

            Car pickedCar = firstParkingLot.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_park_the_car_in_the_secondary_parking_lot_when_the_first_one_is_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<PickerParker> { firstParkingLot, secondParkingLot });
            const string carId = "ABC123";
            var car = new Car(carId);
            parkingBoy.Park(new Car("Not care"));
            parkingBoy.Park(car);

            Car pickedCar = secondParkingLot.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_when_the_first_parking_lot_is_full_and_park_the_car()
        {
            var parkingBoy = new ParkingBoy(new List<PickerParker> { new ParkingLot(1), new ParkingLot(1) });
            const string carId = "ABC123";
            var car = new Car(carId);
            parkingBoy.Park(new Car("not care"));
            parkingBoy.Park(car);

            Car pickedCar = parkingBoy.Pick(carId);
            
            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_not_park_car_when_all_parking_lot_are_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<PickerParker> { firstParkingLot, secondParkingLot });
            parkingBoy.Park(new Car("Not care1"));
            ParkCarResult parkCarResult = parkingBoy.Park(new Car("Not care2"));
            Assert.Equal(ParkCarResult.Success, parkCarResult);

            parkCarResult = parkingBoy.Park(new Car("Not care3"));

            Assert.Equal(ParkCarResult.NoParkingSpace, parkCarResult);
        }

        [Fact]
        void should_not_pick_a_car_when_the_car_has_been_picked_by_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(new List<PickerParker> { parkingLot });
            parkingBoy.Park(car);
            Car pickedCar = parkingBoy.Pick(carId);
            Assert.Same(car, pickedCar);

            pickedCar = parkingBoy.Pick(carId);
            Assert.Null(pickedCar);
        }

    }
}
