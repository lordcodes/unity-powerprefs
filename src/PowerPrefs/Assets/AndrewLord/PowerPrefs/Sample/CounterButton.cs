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
namespace AndrewLord.UnityPowerPrefsSample {

  using AndrewLord.UnityPowerPrefs;
  using UnityEngine;
  using UnityEngine.UI;

  public class CounterButton : MonoBehaviour {

    private const string KeyCounter = "KeyCounter";

    public Text label;

    private PowerPrefsKeyAccessor<int> accessor;

    void Awake() {
      accessor = PowerPrefs.ForInt().KeyAccessor(KeyCounter);
      CounterChanged(accessor.Get());
    }

    public void IncrementCounter() {
      var counter = accessor.Get() + 1;
      accessor.Set(counter);
      CounterChanged(counter);
    }

    private void CounterChanged(int counter) {
      label.text = counter.ToString();
    }
  }
}
