using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkingLot
    {
        readonly List<Car> cars;
        public int ParkingSpaceCount { get; private set; }

        public ParkingLot(int parkingSpaceCount = 10)
        {
            cars = new List<Car>(parkingSpaceCount);
            ParkingSpaceCount = parkingSpaceCount;
        }

        public ParkCarResult Park(Car car)
        {
            if (cars.Count != ParkingSpaceCount)
            {
                cars.Add(car);
                return ParkCarResult.Success;
            }

            return ParkCarResult.NoParkingSpace;
        }

        public Car Pick(string carId)
        {
            Car picked = cars.FirstOrDefault(car => car.Id == carId);
            cars.Remove(picked);
            return picked;
        }
    }
}