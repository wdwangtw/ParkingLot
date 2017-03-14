using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkingLot : PickerParker
    {
        readonly List<Car> cars;
        readonly int parkingSpaceCount;

        public ParkingLot(int parkingSpaceCount = 10)
        {
            cars = new List<Car>(parkingSpaceCount);
            this.parkingSpaceCount = parkingSpaceCount;
        }

        public override ParkCarResult Park(Car car)
        {
            if (cars.Count != parkingSpaceCount)
            {
                cars.Add(car);
                return ParkCarResult.Success;
            }

            return ParkCarResult.NoParkingSpace;
        }

        public override Car Pick(string carId)
        {
            Car picked = cars.FirstOrDefault(car => car.Id == carId);
            cars.Remove(picked);
            return picked;
        }

        public override int EmptyParkingSpace()
        {
            return parkingSpaceCount - cars.Count;
        }

        public override double EmptyParkingSpaceRatio()
        {
            return EmptyParkingSpace()*1.0 / parkingSpaceCount;
        }
    }
}