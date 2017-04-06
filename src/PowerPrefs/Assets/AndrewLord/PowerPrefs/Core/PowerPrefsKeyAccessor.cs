//
// Copyright (C) 2017 Andrew Lord
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

  /// <summary>
  /// Get and set values of type ValueT to and from PlayerPrefs, with the key being stored.
  /// </summary>
  public class PowerPrefsKeyAccessor<ValueT> {

    private PowerPrefsAccessor<ValueT> accessor;
    private string prefKey;

    /// <summary>
    /// Create a PowerPrefsKeyAccessor which can get and set values of type ValueT to and from PlayerPrefs, with the 
    /// key being stored.
    /// </summary>
    /// <param name="accessor">Accessor for type ValueT.</param>
    /// <param name="prefKey">The key to get and set values for.</param>
    public PowerPrefsKeyAccessor(PowerPrefsAccessor<ValueT> accessor, string prefKey) {
      this.accessor = accessor;
      this.prefKey = prefKey;
    }

    /// <summary>
    /// Get the value from PlayerPrefs.
    /// </summary>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will equal the default value
    /// for the generic type ValueT.
    /// </param>
    /// <returns>The value stored for the key, or if not present then defaultValue.</returns>
    public ValueT Get(ValueT defaultValue = default(ValueT)) {
      return accessor.Get(prefKey, defaultValue);
    }

    /// <summary>
    /// Set a value into PlayerPrefs.
    /// </summary>
    /// <param name="prefValue">The value to set.</param>
    public void Set(ValueT prefValue) {
      accessor.Set(prefKey, prefValue);
    }
  }
}