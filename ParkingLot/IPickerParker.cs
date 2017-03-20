using System;

namespace ParkingLots
{
    public interface IPickerParker
    {
        ParkCarResult Park(Car car);
        Car Pick(string carId);
    }
}