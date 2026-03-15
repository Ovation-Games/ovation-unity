using System;

namespace Ovation.Utils
{
    internal static class IdempotencyKeyGenerator
    {
        internal static string Generate()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}
