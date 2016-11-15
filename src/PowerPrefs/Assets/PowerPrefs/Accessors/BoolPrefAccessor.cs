namespace PowerPrefs {

  using UnityEngine;

  public class BoolPrefAccessor : PrefAccessor<bool> {

    public bool Get(string prefKey, bool defaultValue = false) {
        int prefValue = PlayerPrefs.GetInt(prefKey, boolToInt(defaultValue));
        return prefValue == 1 ? true : false;
    }

    public PrefAccessor<bool> Set(string prefKey, bool prefValue) {
        PlayerPrefs.SetInt(prefKey, boolToInt(prefValue));
        return this;
    }

    private int boolToInt(bool prefValue) {
      return prefValue ? 1 : 0;
    }

  }
}