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
                    return ParkCarCommen(car, parkingLots);
                case ParkingBoyType.Smart:
                    return ParkCarSmart(car, parkingLots);
                case ParkingBoyType.Super:
                {
                    var parkCarSUper = new ParkCarBySuperBoy();
                    return parkCarSUper.ParkCar(car, parkingLots);
                }
                default:
                    return ParkCarResult.NoParkingBoyType;
            }
        }

        static ParkCarResult ParkCarSmart(Car car, List<ParkingLot> parkingLots)
        {
            return parkingLots.OrderByDescending(p => p.EmptyParkingSpace()).ToList()[0].Park(car);
        }

        static ParkCarResult ParkCarCommen(Car car, List<ParkingLot> parkingLots)
        {
            return parkingLots.Any(parkingLot => parkingLot.Park(car) == ParkCarResult.Success)
                ? ParkCarResult.Success
                : ParkCarResult.NoParkingSpace;
        }

        public Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}