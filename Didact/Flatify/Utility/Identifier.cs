using System.Globalization;

namespace Didact.Flatify.Utility;

public static class Identifier
{
    public static string Create(string prefix)
    {
        return $"{prefix}-{Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture)}";
    }
}