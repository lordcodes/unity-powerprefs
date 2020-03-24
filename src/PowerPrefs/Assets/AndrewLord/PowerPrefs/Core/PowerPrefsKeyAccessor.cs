//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefs
{
    /// <summary>
    /// Get and set values of type ValueT to and from PlayerPrefs, with the key being stored.
    /// </summary>
    public class PowerPrefsKeyAccessor<ValueT>
    {
        private PowerPrefsAccessor<ValueT> accessor;
        private readonly string prefKey;

        /// <summary>
        /// Create a PowerPrefsKeyAccessor which can get and set values of type ValueT to and from PlayerPrefs, with the 
        /// key being stored.
        /// </summary>
        /// <param name="accessor">Accessor for type ValueT.</param>
        /// <param name="prefKey">The key to get and set values for.</param>
        public PowerPrefsKeyAccessor(PowerPrefsAccessor<ValueT> accessor, string prefKey)
        {
            this.accessor = accessor;
            this.prefKey = prefKey;
        }

        /// <summary>
        /// Get the value from PlayerPrefs.
        /// </summary>
        /// <param name="defaultValue">
        /// The default value to return if the key doesn't exist. If not specified it will equal the default value
        /// for the generic type ValueT.
        /// </param>
        /// <returns>The value stored for the key, or if not present then defaultValue.</returns>
        public ValueT Get(ValueT defaultValue = default)
        {
            return accessor.Get(prefKey, defaultValue);
        }

        /// <summary>
        /// Set a value into PlayerPrefs.
        /// </summary>
        /// <param name="prefValue">The value to set.</param>
        public void Set(ValueT prefValue)
        {
            accessor.Set(prefKey, prefValue);
        }
    }
}
