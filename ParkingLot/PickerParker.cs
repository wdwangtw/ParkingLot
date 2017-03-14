using System;

namespace ParkingLots
{
    abstract public class PickerParker
    {
        public abstract ParkCarResult Park(Car car);
        public abstract Car Pick(string carId);

        public virtual int EmptyParkingSpace()
        {
            throw new NotImplementedException();
        }

        public virtual double EmptyParkingSpaceRatio()
        {
            throw new NotImplementedException();
        }
    }
}