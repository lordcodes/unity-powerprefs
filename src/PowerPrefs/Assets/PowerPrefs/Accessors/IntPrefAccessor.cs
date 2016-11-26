namespace PowerPrefs {

  using UnityEngine;

  /// <summary>
  /// Get and set int values.
  /// </summary>
  public class IntPrefAccessor : PrefAccessor<int> {

    /// <summary>
    /// Get an int value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
    /// </param>
    /// <returns>The int value stored at the key prefKey or if not present then the built-in default.</returns>
    public int Get(string prefKey, int defaultValue = default(int)) {
        return PlayerPrefs.GetInt(prefKey, defaultValue);
    }

    /// <summary>
    /// Set an int value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    /// <returns>This accessor.</returns>
    public PrefAccessor<int> Set(string prefKey, int prefValue) {
        PlayerPrefs.SetInt(prefKey, prefValue);
        return this;
    }
  }
}