namespace Business.Helpers;

public static class IdGenerator
{
    public static string GenerateUniqueId() => Guid.NewGuid().ToString();

    public static int AutoIncrementId(int lastId) => lastId > 0 ? lastId + 1 : 1;
}
