namespace PowerPrefs {

  /// <summary>
  /// Get and set typed values.
  /// </summary>
	public interface PrefAccessor<ValueT> {

    /// <summary>
    /// Get a typed value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
    /// </param>
    /// <returns>The typed value stored at the key prefKey or if not present then the built-in default.</returns>
		ValueT Get(string prefKey, ValueT defaultValue = default(ValueT));

    /// <summary>
    /// Set a typed value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    /// <returns>This accessor.</returns>
		PrefAccessor<ValueT> Set(string prefKey, ValueT prefValue);

	}
}
