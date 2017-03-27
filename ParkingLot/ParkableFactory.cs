namespace ParkingLots
{
    public class ParkableFactory
    {
        public static IParkable CreateParkable(ParkerType parkerType)
        {
            switch (parkerType)
            {
                case ParkerType.Commen:
                    return new CommonParkable();
                case ParkerType.Smart:
                    return new SmartParkable();
                case ParkerType.Super:
                    return new SuperParkable();
                default:
                    return null;
            }
        }
    }
}