using ParkingLots;
using Xunit;

namespace Test_ParkingLot
{
    public class ParkingLotFacts
    {
        [Fact]
        void should_pick_the_car_when_park_a_car()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();

            parkingLot.Park(car);
            Car picked = parkingLot.Pick(carId);

            Assert.Same(car, picked);
        }

        [Fact]
        void should_pick_the_first_one_when_park_two_cars()
        {
            const string firstCarId = "ABC123";
            var firstCar = new Car(firstCarId);
            var secondCar = new Car("ABC321");
            var parkingLot = new ParkingLot();
            parkingLot.Park(firstCar);
            parkingLot.Park(secondCar);

            var picked = parkingLot.Pick(firstCarId);

            Assert.Same(firstCar, picked);
        }

        [Fact]
        void should_not_park_a_car_when_there_is_no_parking_space()
        {
            var car = new Car("ABC123");
            var anotherCar = new Car("CBA321");
            var parking = new ParkingLot(1);
            parking.Park(car);

            ParkCarResult parkCarResult = parking.Park(anotherCar);

            Assert.Equal(ParkCarResult.NoParkingSpace, parkCarResult);
        }

        [Fact]
        void should_park_a_car_when_there_is_no_parking_space_and_pick_an_exist_car()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var anotherCar = new Car("CBA321");
            var parking = new ParkingLot(1);
            parking.Park(car);
            parking.Pick(carId);

            ParkCarResult parkCarResult = parking.Park(anotherCar);

            Assert.Equal(ParkCarResult.Success, parkCarResult);
        }

        [Fact]
        void should_not_pick_a_car_when_the_car_has_been_picked()
        {
            const string carId = "ABC123";
            var car = new Car(carId);
            var parkingLot = new ParkingLot();

            parkingLot.Park(car);
            Car picked = parkingLot.Pick(carId);
            Assert.Same(car, picked);

            picked = parkingLot.Pick(carId);
            Assert.Null(picked);
        }
    }
}
