//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{
    using System;

    /// <summary>
    /// Get and set DateTime values.
    /// </summary>
    public class DateTimePrefAccessor : IPrefAccessor<DateTime>
    {
        private readonly LongPrefAccessor longAccessor = new LongPrefAccessor();

        /// <summary>
        /// Get a DateTime value from PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to retrieve the value for.</param>
        /// <param name="defaultValue">
        /// The default value to return if the key doesn't exist. If not specified it will be the built-in default
        /// </param>
        /// <returns>The DateTime value stored at the key prefKey or if not present then the built-in default.</returns>
        public DateTime Get(string prefKey, DateTime defaultValue = default)
        {
            var storedValue = longAccessor.Get(prefKey, defaultValue.Ticks);
            return new DateTime(storedValue);
        }

        /// <summary>
        /// Set a DateTime value into PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to set a value for.</param>
        /// <param name="prefValue">The value to set.</param>
        /// <returns>This accessor.</returns>
        public IPrefAccessor<DateTime> Set(string prefKey, DateTime prefValue)
        {
            longAccessor.Set(prefKey, prefValue.Ticks);
            return this;
        }
    }
}
