﻿using System;
using System.Globalization;

namespace AzureAdB2c.CrossCutting.ValueConverters
{
    public static class CurrencyConverter
    {
        public static string DecimalToCurrencyString(decimal amount, IFormatProvider provider = null)
        {
            if (provider == null)
                provider = CultureInfo.CurrentCulture;

            return amount.ToString("C", provider);
        }
    }
}