namespace PowerPrefs {

  /// <summary>
  /// Get and set long values.
  /// </summary>
  public class LongPrefAccessor : PrefAccessor<long> {

    private readonly StringPrefAccessor stringAccessor = new StringPrefAccessor();

    /// <summary>
    /// Get a long value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will be the built-in default
    /// </param>
    /// <returns>The long value stored at the key prefKey or if not present then the built-in default.</returns>
    public long Get(string prefKey, long defaultValue = default(long)) {
      string storedValue = stringAccessor.Get(prefKey, defaultValue.ToString());
      return long.Parse(storedValue);
    }

    /// <summary>
    /// Set a long value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    /// <returns>This accessor.</returns>
    public PrefAccessor<long> Set(string prefKey, long prefValue) {
      stringAccessor.Set(prefKey, prefValue.ToString());
      return this;
    }
  }
}