namespace ImageApi.Services.Constants;

public class Constants : IConstants
{
    private int _intervalTime;
    public int IntervalTime => _intervalTime;

    public Constants(IConfiguration config)
    {
        _intervalTime = config.GetValue<int?>("INTERVAL_TIME") ?? 0;
    }
}
