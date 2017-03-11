using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> parkingLots;
        readonly ParkingBoyType parkingBoyType;

        protected ParkingBoyBase(List<ParkingLot> parkingLots, ParkingBoyType type)
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
                case ParkingBoyType.Smart:
                    return parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).ToList()[0].Park(car);
                case ParkingBoyType.Super:
                    return parkingLots.OrderByDescending(p => p.EmptyParkingSpaceRatio()).ToList()[0].Park(car);
                default:
                    return ParkCarResult.NoParkingBoyType;
            }
        }

        public Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}