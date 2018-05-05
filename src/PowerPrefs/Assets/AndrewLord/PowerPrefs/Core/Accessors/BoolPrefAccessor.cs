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
  /// Get and set bool values.
  /// </summary>
  public class BoolPrefAccessor : PrefAccessor<bool> {

    /// <summary>
    /// Get a bool value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
    /// </param>
    /// <returns>The bool value stored at the key prefKey or if not present then the built-in default.</returns>
    public bool Get(string prefKey, bool defaultValue = default(bool)) {
      var prefValue = PlayerPrefs.GetInt(prefKey, boolToInt(defaultValue));
      return prefValue == 1 ? true : false;
    }

    /// <summary>
    /// Set a bool value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    /// <returns>This accessor.</returns>
    public PrefAccessor<bool> Set(string prefKey, bool prefValue) {
      PlayerPrefs.SetInt(prefKey, boolToInt(prefValue));
      return this;
    }

    private int boolToInt(bool prefValue) {
      return prefValue ? 1 : 0;
    }
  }
}
