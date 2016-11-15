namespace PowerPrefs {

  using UnityEngine;

  public class IntPrefAccessor : PrefAccessor<int> {

    public int Get(string prefKey, int defaultValue = 0) {
        return PlayerPrefs.GetInt(prefKey, defaultValue);
    }

    public PrefAccessor<int> Set(string prefKey, int prefValue) {
        PlayerPrefs.SetInt(prefKey, prefValue);
        return this;
    }

  }
}