using System.Collections.Generic;

namespace ParkingLots
{
    public abstract class ParkingBoyBase : PickerParker
    {
        readonly IParkable parkable;

        protected ParkingBoyBase(List<ParkingLot> parkingLots, ParkerType type)
        {
            pickerParkers.AddRange(parkingLots);
            parkable = ParkableFactory.CreateParkable(type);
        }

        public override ParkCarResult Park(Car car)
        {
            return parkable.ParkCar(pickerParkers, car);
        }
    }
}