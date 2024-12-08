using System.Globalization;

namespace Didact.Flatify.Forms;

public static class Identifier
{
    public static string Create(string prefix)
    {
        return $"{prefix}-{Guid.NewGuid().ToString("N", CultureInfo.InvariantCulture)}";
    }
}