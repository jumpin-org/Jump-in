using JumpIn.Common.Utility.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace JumpIn.Common.Utility.Helpers
{
    public static class ClassExtensionMethods
    {
        public static void CheckNotNull<T>([ValidatedNotNull] this T value, string parameterName, ILogger logger)
        {
            if (value is null)
            {
                logger.LogError(ExceptionMessages.ARGUMENT_NULL_EXCEPTION.InvariantFormat(new object[] { parameterName }));
                throw new ArgumentNullException(ExceptionMessages.ARGUMENT_NULL_EXCEPTION.InvariantFormat(new object[] { parameterName }));
            }
        }
    }

    [AttributeUsage(AttributeTargets.Parameter)]
    internal sealed class ValidatedNotNullAttribute : Attribute
    {
    }
    public static class StringExtensionMethods
    {
        public static string InvariantFormat(this string value, object[] args)
        {
            return string.Format(CultureInfo.InvariantCulture, value, args);
        }

        public static string InvariantFormat(this string value, object arg)
        {
            return string.Format(CultureInfo.InvariantCulture, value, arg);
        }
    }
}
