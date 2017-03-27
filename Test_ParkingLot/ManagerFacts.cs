using System.Collections.Generic;
using System.Linq;
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
            var manager = new Manager(new List<IPickerParker> { parkingLot });
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
            var manager = new Manager(new List<IPickerParker> { parkingLot });
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
            var parkingBoy = new SuperParkingBoy(new List<ParkingLot> { parkingLot });
            var manager = new Manager(new List<IPickerParker>{ parkingBoy });
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
            var parkingBoy = new SuperParkingBoy(new List<ParkingLot> { parkingLot });
            var manager = new Manager(new List<IPickerParker> { parkingBoy });
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
            var parkingBoy = new SuperParkingBoy(new List<ParkingLot> { parkingLot });
            var manager = new Manager(new List<IPickerParker> { parkingBoy });
            manager.Park(car);

            Car pickedCar = manager.Pick(carId);

            Assert.Same(car, pickedCar);
        }

        [Fact]
        void should_not_park_car_by_manager_when_all_parking_lots_are_full()
        {
            var firstParkingLot = new ParkingLot(1);
            var secondParkingLot = new ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot> { secondParkingLot });
            var manager = new Manager(new List<IPickerParker> { firstParkingLot , parkingBoy});
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
            var parkingBoys =  new SmartParkingBoy(new List<ParkingLot> { parkingLot });
            var manager = new Manager(new List<IPickerParker>{parkingBoys});
            manager.Park(car);
            Car pickedCar = manager.Pick(carId);
            Assert.Same(car, pickedCar);

            pickedCar = manager.Pick(carId);
            Assert.Null(pickedCar);
        }

        [Fact]
        void should_show_parking_lots_and_parking_boys_parking_info()
        {
            List<Car> cars = CreateCars(10);

            ParkingLot ParkingLot1 = CreateParkingLots(3, cars.GetRange(0, 2));
            ParkingLot ParkingLot2 = CreateParkingLots(3, cars.GetRange(2, 1));
            ParkingLot ParkingLot3 = CreateParkingLots(3, cars.GetRange(3, 2));
            ParkingLot ParkingLot4 = CreateParkingLots(3, cars.GetRange(5, 3));
            ParkingLot ParkingLot5 = CreateParkingLots(3, cars.GetRange(8, 2));

            var parkingBoy = new ParkingBoy(new List<ParkingLot>{ParkingLot1, ParkingLot2});
            var superParkingBoy = new SuperParkingBoy(new List<ParkingLot> { ParkingLot3 });
            var smartParkingBoy = new SmartParkingBoy(new List<ParkingLot> { ParkingLot4 });

            var manager = new Manager(new List<IPickerParker>{parkingBoy, ParkingLot5, superParkingBoy, smartParkingBoy});

            string des = manager.Description("");
            const string expectedDes = "Manager 10 15\n\t ParkingBoy 3 6\n\t\t ParkingLot 2 3\n\t\t ParkingLot 1 3\n\t ParkingLot 2 3\n\t SuperBoy 2 3\n\t\t ParkingLot 2 3\n\t SmartBoy 3 3\n\t\t ParkingLot 3 3\n";

            Assert.Equal(expectedDes, des);

        }

        ParkingLot CreateParkingLots(int spaceCount, List<Car> cars)
        {
            var parkingLot = new ParkingLot(spaceCount);
            cars.ForEach(car => parkingLot.Park(car));
            return parkingLot;
        }

        List<Car> CreateCars(int carCount)
        {
            return Enumerable.Range(0, carCount).Select(i => new Car(i.ToString())).ToList();
        }
    }
}
