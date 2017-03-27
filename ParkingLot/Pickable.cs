using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class Pickable
    {
        public Car Pick(List<IPickerParker> parkingLots, string carId)
        {
            return parkingLots.
                Select(parkingLot => parkingLot.Pick(carId)).
                FirstOrDefault(picked => picked != null);
        }
    }

    public class Descriptable
    {
        public string Description(IPickerParker pickerParker, string name)
        {
            return string.Format(
                "{0} {1} {2}",
                name,
                pickerParker.ParkingSpaceCount() - pickerParker.EmptyParkingSpace(),
                pickerParker.ParkingSpaceCount());
        }
    }
}