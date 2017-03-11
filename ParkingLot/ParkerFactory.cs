namespace ParkingLots
{
    public class ParkerFactory
    {
        public static IParker CreateParker(ParkingBoyType boyType)
        {
            switch (boyType)
            {
                case ParkingBoyType.Commen:
                    return new CommonParker();
                case ParkingBoyType.Smart:
                    return new SmartParker();
                case ParkingBoyType.Super:
                    return new SuperParker();
                default:
                    return null;
            }
        }
    }
}