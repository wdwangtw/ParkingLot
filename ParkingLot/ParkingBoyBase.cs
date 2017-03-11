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
                {
                    var parkCarByCommonBoy = new ParkCarByCommonBoy();
                    return parkCarByCommonBoy.ParkCar(car, parkingLots);
                }
                case ParkingBoyType.Smart:
                {
                    var parkCarBySmartBoy = new ParkCarBySmartBoy();
                    return parkCarBySmartBoy.ParkCar(car, parkingLots);
                }
                case ParkingBoyType.Super:
                {
                    var parkCarSUper = new ParkCarBySuperBoy();
                    return parkCarSUper.ParkCar(car, parkingLots);
                }
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