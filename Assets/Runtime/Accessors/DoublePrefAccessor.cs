//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefs.Accessors
{
    /// <summary>
    /// Get and set double values.
    /// </summary>
    public class DoublePrefAccessor : IPrefAccessor<double>
    {
        private readonly StringPrefAccessor stringAccessor = new StringPrefAccessor();

        /// <summary>
        /// Get a double value from PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to retrieve the value for.</param>
        /// <param name="defaultValue">
        /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
        /// </param>
        /// <returns>The double value stored at the key prefKey or if not present then the built-in default.</returns>
        public double Get(string prefKey, double defaultValue = default)
        {
            var storedValue = stringAccessor.Get(prefKey, defaultValue.ToString());
            return double.Parse(storedValue);
        }

        /// <summary>
        /// Set a double value into PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to set a value for.</param>
        /// <param name="prefValue">The value to set.</param>
        /// <returns>This accessor.</returns>
        public IPrefAccessor<double> Set(string prefKey, double prefValue)
        {
            stringAccessor.Set(prefKey, prefValue.ToString());
            return this;
        }
    }
}
