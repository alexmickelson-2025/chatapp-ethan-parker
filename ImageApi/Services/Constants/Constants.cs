namespace ImageApi.Services.Constants;

public class Constants : IConstants
{
    private int _intervalTime;
    public int IntervalTime => _intervalTime;

    private string _redisUrl;
    public string RedisUrl => _redisUrl;

    public Constants(IConfiguration config)
    {
        _intervalTime = config.GetValue<int?>("INTERVAL_TIME") ?? 0;
        _redisUrl = config.GetValue<string>("REDIS_URL") ?? throw new Exception("Redis url required");
    }
}
