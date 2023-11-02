namespace TestingHowToUseDJ.TimeServices;

public class ShortTimeService : ITimeService
{
    public string GetTime()
    {
        return DateTime.Now.ToShortTimeString();
    }
}