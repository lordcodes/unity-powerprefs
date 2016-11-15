namespace PowerPrefs {

  using UnityEngine;

  public class StringPrefAccessor : PrefAccessor<string> {

    public string Get(string prefKey, string defaultValue = "") {
      return PlayerPrefs.GetString(prefKey, defaultValue);
    }

    public PrefAccessor<string> Set(string prefKey, string prefValue) {
      PlayerPrefs.SetString(prefKey, prefValue);
      return this;
    }

  }
}