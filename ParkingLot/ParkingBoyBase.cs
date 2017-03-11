using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> parkingLots;
        ParkingBoyType parkingBoyType;

        protected ParkingBoyBase(List<ParkingLot> parkingLots, ParkingBoyType type = ParkingBoyType.Commen)
        {
            this.parkingLots = new List<ParkingLot>();
            this.parkingLots.AddRange(parkingLots);
            parkingBoyType = type;
        }

        public ParkCarResult Park(Car car)
        {
            switch (parkingBoyType)
            {
                case ParkingBoyType.Commen:
                    return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                                 ? ParkCarResult.Success
                                 : ParkCarResult.NoParkingSpace;
            }
            return ParkCarResult.NoParkingSpace;
        }

        public Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}