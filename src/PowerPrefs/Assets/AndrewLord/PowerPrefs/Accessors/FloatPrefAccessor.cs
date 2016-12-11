namespace AndrewLord.UnityPowerPrefs {

  using UnityEngine;

  /// <summary>
  /// Get and set float values.
  /// </summary>
  public class FloatPrefAccessor : PrefAccessor<float> {

    /// <summary>
    /// Get a float value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
    /// </param>
    /// <returns>The float value stored at the key prefKey or if not present then the built-in default.</returns>
    public float Get(string prefKey, float defaultValue = default(float)) {
      return PlayerPrefs.GetFloat(prefKey, defaultValue);
    }

    /// <summary>
    /// Set a float value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    /// <returns>This accessor.</returns>
    public PrefAccessor<float> Set(string prefKey, float prefValue) {
      PlayerPrefs.SetFloat(prefKey, prefValue);
      return this;
    }
  }
}