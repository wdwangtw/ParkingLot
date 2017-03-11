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
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }

        public ParkCarResult Park(Car car)
        {
            return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }
    }
}