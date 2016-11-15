using UnityEngine;

namespace PowerPrefs {

  public class PowerPrefsAccessor<ValueT> {

    private PrefAccessor<ValueT> accessor;

    public PowerPrefsAccessor(PrefAccessor<ValueT> accessor) {
      this.accessor = accessor;
    }

    public ValueT Get(string prefKey, ValueT defaultValue = default(ValueT)) {
      return accessor.Get(prefKey, defaultValue);
    }

    public void Set(string prefKey, ValueT prefValue) {
      accessor.Set(prefKey, prefValue);
    }

    public void MoveKeys(string oldKey, string newKey) {
      if (PlayerPrefs.HasKey(oldKey)) {
        ValueT prefValue = accessor.Get(oldKey, default(ValueT));
        accessor.Set(newKey, prefValue);
        PlayerPrefs.DeleteKey(oldKey);
      }
    }

  }
}