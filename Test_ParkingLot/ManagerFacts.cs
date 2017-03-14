using System.Collections.Generic;
using ParkingLots;
using Xunit;

namespace Test_ParkingLot
{
    public class ManagerFacts
    {
        [Fact]
        void should_pick_the_car_from_parking_lots_when_park_a_car_by_manager()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var manager = new Manager(new List<PickerParker> { parkingLot });
            manager.Park(car);
            
            Car pickedCar = parkingLot.Pick(carId);
            
            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_manager_when_park_a_car_to_parking_lot()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var manager = new Manager(new List<PickerParker> { parkingLot });
            parkingLot.Park(car);

            Car pickedCar = manager.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_parking_boys_when_park_a_car_by_manager()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var parkingBoy = new SuperParkingBoy(new List<PickerParker> { parkingLot });
            var manager = new Manager(new List<PickerParker>{ parkingBoy });
            manager.Park(car);

            Car pickedCar = parkingBoy.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_pick_the_car_by_manager_when_park_a_car_by_parking_boy()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var parkingBoy = new SuperParkingBoy(new List<PickerParker> { parkingLot });
            var manager = new Manager(new List<PickerParker> { parkingBoy });
            parkingBoy.Park(car);
            Car pickedCar = manager.Pick(carId);

            Assert.Same(car, pickedCar);
        }
        
        [Fact]
        void should_pick_the_car_by_manager_when_park_a_car_by_manager()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var parkingBoy = new SuperParkingBoy(new List<PickerParker> { parkingLot });
            var manager = new Manager(new List<PickerParker> { parkingBoy });
            manager.Park(car);

            Car pickedCar = manager.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_not_park_car_by_manager_when_all_parking_lots_are_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<PickerParker> { secondParkingLot });
            var manager = new Manager(new List<PickerParker> { firstParkingLot , parkingBoy});
            manager.Park(new Car("Not care1"));
            ParkCarResult parkCarResult = manager.Park(new Car("Not care2"));
            Assert.Equal(ParkCarResult.Success, parkCarResult);

            parkCarResult = manager.Park(new Car("Not care3"));

            Assert.Equal(ParkCarResult.NoParkingSpace, parkCarResult);
        }

        [Fact]
        void should_not_pick_a_car_when_the_car_has_been_picked_by_manager()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();
            var parkingBoys =  new SmartParkingBoy(new List<PickerParker> { parkingLot });
            var manager = new Manager(new List<PickerParker>{parkingBoys});
            manager.Park(car);
            Car pickedCar = manager.Pick(carId);
            Assert.Same(car, pickedCar);

            pickedCar = manager.Pick(carId);
            Assert.Null(pickedCar);
        }
    }
}
