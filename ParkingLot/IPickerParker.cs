using System;

namespace ParkingLots
{
    public interface IPickerParker
    {
        ParkCarResult Park(Car car);
        Car Pick(string carId);
        int EmptyParkingSpace();
        int ParkingSpaceCount();
        string Description(string pre);
    }
}