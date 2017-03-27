using System.Collections.Generic;
using System.Linq;

namespace ParkingLots
{
    public class Manager : PickerParker
    {
        readonly IParkable parkable;

        public Manager(List<IPickerParker> pickerParkers)
        {
            this.pickerParkers = pickerParkers;
            parkable = ParkableFactory.CreateParkable(ParkerType.Commen);
        }

        public override string NameDescription
        {
            get { return "Manager"; }
        }

        public override ParkCarResult Park(Car car)
        {
            return parkable.ParkCar(pickerParkers, car);
        }
//
//        public override string Description(string pre)
//        {
//            string des = string.Format(
//                "{0} {1} {2}",
//                "Manager",
//                ((IPickerParker) this).ParkingSpaceCount() - ((IPickerParker) this).EmptyParkingSpace(),
//                ((IPickerParker) this).ParkingSpaceCount());
//            pickerParkers.ForEach(p => des += "\n\t" + p.Description());
//            return des;
//        }
    }
}