namespace Business.Helpers;

public static class IdGenerator
{
    /// <summary>
    /// This generates a new uniqueid using GUID.
    /// </summary>
    
    public static string GenerateUniqueId() => Guid.NewGuid().ToString();

    public static int AutoIncrementId(int lastId) => lastId > 0 ? lastId + 1 : 1;
}
