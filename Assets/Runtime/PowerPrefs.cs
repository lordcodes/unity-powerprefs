//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs
{
    using LordCodes.PowerPrefs.Accessors;
    using System;

    /// <summary>
    /// Read and write values of various different types to PlayerPrefs easily.
    /// </summary>
    public class PowerPrefs
    {
        private static PowerPrefsAccessor<bool> boolAccessor;
        private static PowerPrefsAccessor<float> floatAccessor;
        private static PowerPrefsAccessor<int> intAccessor;
        private static PowerPrefsAccessor<string> stringAccessor;
        private static PowerPrefsAccessor<char> charAccessor;
        private static PowerPrefsAccessor<double> doubleAccessor;
        private static PowerPrefsAccessor<long> longAccessor;
        private static PowerPrefsAccessor<DateTime> dateTimeAccessor;

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write bool type values.
        /// </summary>
        /// <returns>Bool prefs accessor</returns>
        public static PowerPrefsAccessor<bool> ForBool()
        {
            if (boolAccessor == null)
            {
                boolAccessor = new PowerPrefsAccessor<bool>(new BoolPrefAccessor());
            }
            return boolAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write float type values.
        /// </summary>
        /// <returns>Float prefs accessor</returns>
        public static PowerPrefsAccessor<float> ForFloat()
        {
            if (floatAccessor == null)
            {
                floatAccessor = new PowerPrefsAccessor<float>(new FloatPrefAccessor());
            }
            return floatAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write int type values.
        /// </summary>
        /// <returns>Int prefs accessor</returns>
        public static PowerPrefsAccessor<int> ForInt()
        {
            if (intAccessor == null)
            {
                intAccessor = new PowerPrefsAccessor<int>(new IntPrefAccessor());
            }
            return intAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write string type values.
        /// </summary>
        /// <returns>String prefs accessor</returns>
        public static PowerPrefsAccessor<string> ForString()
        {
            if (stringAccessor == null)
            {
                stringAccessor = new PowerPrefsAccessor<string>(new StringPrefAccessor());
            }
            return stringAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write char type values.
        /// </summary>
        /// <returns>Char prefs accessor</returns>
        public static PowerPrefsAccessor<char> ForChar()
        {
            if (charAccessor == null)
            {
                charAccessor = new PowerPrefsAccessor<char>(new CharPrefAccessor());
            }
            return charAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write double type values.
        /// </summary>
        /// <returns>Double prefs accessor</returns>
        public static PowerPrefsAccessor<double> ForDouble()
        {
            if (doubleAccessor == null)
            {
                doubleAccessor = new PowerPrefsAccessor<double>(new DoublePrefAccessor());
            }
            return doubleAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write long type values.
        /// </summary>
        /// <returns>Long prefs accessor</returns>
        public static PowerPrefsAccessor<long> ForLong()
        {
            if (longAccessor == null)
            {
                longAccessor = new PowerPrefsAccessor<long>(new LongPrefAccessor());
            }
            return longAccessor;
        }

        /// <summary>
        /// Create a PlayerPrefs accessor to read and write DateTime type values.
        /// </summary>
        /// <returns>DateTime prefs accessor</returns>
        public static PowerPrefsAccessor<DateTime> ForDateTime()
        {
            if (dateTimeAccessor == null)
            {
                dateTimeAccessor = new PowerPrefsAccessor<DateTime>(new DateTimePrefAccessor());
            }
            return dateTimeAccessor;
        }
    }
}
