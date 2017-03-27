using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public abstract class PickerParker : IPickerParker
    {
        protected List<IPickerParker> pickerParkers;
        protected readonly Pickable pickable;
        public abstract string NameDescription { get; }

        protected PickerParker()
        {
            pickable = new Pickable();
            pickerParkers = new List<IPickerParker>();
        }

        public abstract ParkCarResult Park(Car car);

        public  Car Pick(string carId)
        {
            return pickable.Pick(pickerParkers, carId);
        }

        public int EmptyParkingSpace()
        {
            return pickerParkers.Sum(p => p.EmptyParkingSpace());
        }

        public int ParkingSpaceCount()
        {
            return pickerParkers.Sum(p => p.ParkingSpaceCount());
        }

        public string Description(string pre)
        {
            string des = "";
            if (string.IsNullOrEmpty(pre))
            {
                des = string.Format(
                "{0} {1} {2}\n",
                NameDescription,
                ParkingSpaceCount() - EmptyParkingSpace(),
                ParkingSpaceCount());
            }
            else
            {
                des = string.Format(
                "{0} {1} {2} {3}\n",
                pre,
                NameDescription,
                ParkingSpaceCount() - EmptyParkingSpace(),
                ParkingSpaceCount());
            }
            

            pre += "\t";
            pickerParkers.ForEach(p => des += p.Description(pre));
            return des;
        }

    }
}