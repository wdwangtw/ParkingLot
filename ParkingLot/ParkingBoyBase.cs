using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> parkingLots;

        protected ParkingBoyBase(List<ParkingLot> parkingLots)
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
    }
}