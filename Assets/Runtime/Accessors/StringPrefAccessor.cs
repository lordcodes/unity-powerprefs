//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{
    using UnityEngine;

    /// <summary>
    /// Get and set string values.
    /// </summary>
    public class StringPrefAccessor : IPrefAccessor<string>
    {
        /// <summary>
        /// Get a string value from PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to retrieve the value for.</param>
        /// <param name="defaultValue">
        /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
        /// </param>
        /// <returns>The string value stored at the key prefKey or if not present then the built-in default.</returns>
        public string Get(string prefKey, string defaultValue = default)
        {
            return PlayerPrefs.GetString(prefKey, defaultValue);
        }

        /// <summary>
        /// Set a string value into PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to set a value for.</param>
        /// <param name="prefValue">The value to set.</param>
        /// <returns>This accessor.</returns>
        public IPrefAccessor<string> Set(string prefKey, string prefValue)
        {
            PlayerPrefs.SetString(prefKey, prefValue);
            return this;
        }
    }
}
