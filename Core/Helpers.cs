using System;

namespace Core
{
    public static class Helpers
    {
        public static string GenerateName(string prefix, string originalName)
        {
            return $"{prefix}{DateTime.UtcNow.Ticks}{originalName}";
        }
    }
}
