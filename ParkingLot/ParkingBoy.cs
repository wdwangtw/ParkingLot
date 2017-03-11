using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class ParkingBoy
    {
        readonly List<ParkingLot> parkingLots;

        public ParkingBoy(List<ParkingLot> parkingLots)
        {
            this.parkingLots = new List<ParkingLot>();
            this.parkingLots.AddRange(parkingLots);
        }

        public Car Pick(string carId)
        {
            foreach (var parkingLot in parkingLots)
            {
                Car picked = parkingLot.Pick(carId);
                if (picked != null)
                {
                    return picked;
                }
            }

            return null;

        }

        public ParkCarResult Park(Car car)
        {
            return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }
    }
}