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

  /// <summary>
  /// Get and set double values.
  /// </summary>
  public class DoublePrefAccessor : PrefAccessor<double> {

  private readonly StringPrefAccessor stringAccessor = new StringPrefAccessor();

    /// <summary>
    /// Get a double value from PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to retrieve the value for.</param>
    /// <param name="defaultValue">
    /// The default value to return if the key doesn't exist. If not specified it will be the built-in default.
    /// </param>
    /// <returns>The double value stored at the key prefKey or if not present then the built-in default.</returns>
    public double Get(string prefKey, double defaultValue = default(double)) {
      var storedValue = stringAccessor.Get(prefKey, defaultValue.ToString());
      return double.Parse(storedValue);
    }

    /// <summary>
    /// Set a double value into PlayerPrefs.
    /// </summary>
    /// <param name="prefKey">The key to set a value for.</param>
    /// <param name="prefValue">The value to set.</param>
    /// <returns>This accessor.</returns>
    public PrefAccessor<double> Set(string prefKey, double prefValue) {
      stringAccessor.Set(prefKey, prefValue.ToString());
      return this;
    }
  }
}
