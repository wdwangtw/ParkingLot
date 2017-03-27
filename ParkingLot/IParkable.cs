using System.Collections.Generic;

namespace ParkingLots
{
    public interface IParkable
    {
        ParkCarResult ParkCar(List<IPickerParker> parkingLots, Car car);
    }
}