using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class ParkingBoyBase
    {
        protected List<ParkingLot> parkingLots;
        readonly IParker parker;

        protected ParkingBoyBase(List<ParkingLot> parkingLots, ParkingBoyType type)
        {
            this.parkingLots = new List<ParkingLot>();
            this.parkingLots.AddRange(parkingLots);
            parker = ParkerFactory.CreateParker(type);
        }

        public ParkCarResult Park(Car car)
        {
            return parker != null ? parker.ParkCar(parkingLots, car) : ParkCarResult.NoParkingBoyType;
        }

        public Car Pick(string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }
}