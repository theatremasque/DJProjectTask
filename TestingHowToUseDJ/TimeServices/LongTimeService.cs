namespace TestingHowToUseDJ.TimeServices;

public class LongTimeService : ITimeService
{
    public string GetTime()
    {
        return DateTime.Now.ToLongTimeString();
    }
}