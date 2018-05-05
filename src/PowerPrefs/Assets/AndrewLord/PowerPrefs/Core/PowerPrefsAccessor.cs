//
// Copyright (C) 2016 Andrew Lord
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License.
//
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and limitations under the License.
//
namespace AndrewLord.UnityPowerPrefs {

  using UnityEngine;

  /// <summary>
  /// Get, set and migrate values of type ValueT to and from PlayerPrefs.
  /// </summary>
  public class PowerPrefsAccessor<ValueT> {

    private PrefAccessor<ValueT> accessor;

    /// <summary>
    /// Create a PowerPrefsAccessor from a PrefAccessor which can read and write the desired type.
    /// Already setup PowerPrefsAccessors for the main types are available through the PowerPrefs class.
    /// </summary>
    /// <param name="accessor">The PlayerPrefs accessor for the desired type.</param>
    public PowerPrefsAccessor(PrefAccessor<ValueT> accessor) {
      this.accessor = accessor;
    }

    /// <summary>
    /// Get a value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will equal the default value
    /// for the generic type ValueT.
    /// </param>
    /// <returns>The value stored at the key prefKey, or if not present then defaultValue.</returns>
    public ValueT Get(string prefKey, ValueT defaultValue = default(ValueT)) {
      return accessor.Get(prefKey, defaultValue);
    }

    /// <summary>
    /// Set a value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    public void Set(string prefKey, ValueT prefValue) {
      accessor.Set(prefKey, prefValue);
    }

    /// <summary>
    /// Retrieve a PowerPrefsValue which will allow you to get and set to and from a particular key in PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The PlayerPrefs key.</param>
    /// <returns>A class to access value for a particular PlayerPrefs key.</returns>
    public PowerPrefsKeyAccessor<ValueT> KeyAccessor(string prefKey) {
      return new PowerPrefsKeyAccessor<ValueT>(this, prefKey);
    }

    /// <summary>
    /// Moves the value stored for one key to be stored for the other key. This can be useful if you want to
    /// rename a PlayerPrefs key, but without existing data stored at the old key from being lost.
    /// </summary>
    /// <param name="oldKey">The old key to move data from.</param>
    /// <param name="newKey">The new key to store the data for.</param>
    public void MigrateKey(string oldKey, string newKey) {
      if (PlayerPrefs.HasKey(oldKey)) {
        var prefValue = accessor.Get(oldKey, default(ValueT));
        accessor.Set(newKey, prefValue);
        PlayerPrefs.DeleteKey(oldKey);
      }
    }
  }
}
