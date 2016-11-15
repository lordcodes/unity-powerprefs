namespace PowerPrefs {

  using UnityEngine;

  public class FloatPrefAccessor : PrefAccessor<float> {

    public float Get(string prefKey, float defaultValue = 0f) {
        return PlayerPrefs.GetFloat(prefKey, defaultValue);
    }

    public PrefAccessor<float> Set(string prefKey, float prefValue) {
        PlayerPrefs.SetFloat(prefKey, prefValue);
        return this;
    }

  }
}