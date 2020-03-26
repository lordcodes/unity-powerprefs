//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{
    using LordCodes.PowerPrefs.Extensions;
    using UnityEngine;

    /// <summary>
    /// Get and set bool values.
    /// </summary>
    public class BoolPrefAccessor : IPrefAccessor<bool>
    {
        /// <summary>
        /// Get a bool value from PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to retrieve the value for.</param>
        /// <param name="defaultValue">
        /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
        /// </param>
        /// <returns>The bool value stored at the key prefKey or if not present then the built-in default.</returns>
        public bool Get(string prefKey, bool defaultValue = default)
        {
            var prefValue = PlayerPrefs.GetInt(prefKey, defaultValue.ToInt());
            return prefValue == 1 ? true : false;
        }

        /// <summary>
        /// Set a bool value into PlayerPrefs.
        /// </summary>
        /// <param name="prefKey">The key to set a value for.</param>
        /// <param name="prefValue">The value to set.</param>
        /// <returns>This accessor.</returns>
        public IPrefAccessor<bool> Set(string prefKey, bool prefValue)
        {
            PlayerPrefs.SetInt(prefKey, prefValue.ToInt());
            return this;
        }
    }
}
