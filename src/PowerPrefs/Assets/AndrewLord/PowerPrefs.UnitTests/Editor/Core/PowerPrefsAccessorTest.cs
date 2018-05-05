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
namespace AndrewLord.UnityPowerPrefs.UnitTests {

  using UnityEngine;
  using NUnit.Framework;

  public class PowerPrefsAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private PowerPrefsAccessor<int> powerPrefsAccessor;

    [SetUp]
    public void SetUp() {
      PrefAccessor<int> accessor = new IntPrefAccessor();
      powerPrefsAccessor = new PowerPrefsAccessor<int>(accessor);
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValueRetrievedThroughAccessor() {
      var expected = 25;
      PlayerPrefs.SetInt(TestKey, expected);

      var actual = powerPrefsAccessor.Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueNotStored_WhenGet_ThenProvidedDefault() {
      var expected = -1;

      var actual = powerPrefsAccessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueNotStoredAndNoDefault_WhenGet_ThenTypeDefault() {
      var actual = powerPrefsAccessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(0));
    }

    [Test]
    public void WhenSet_ThenValueStoredThroughAccessor() {
      var expected = 99;

      powerPrefsAccessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetInt(TestKey, -1), Is.EqualTo(expected));
    }

    [Test]
    public void GivenKey_WhenKeyAccessor_ThenPowerPrefsKeyAccessorForProvidedKey() {
      var expected = 9999;
      PlayerPrefs.SetInt(TestKey, expected);

      var valueAccessor = powerPrefsAccessor.KeyAccessor(TestKey);

      Assert.That(valueAccessor.Get(), Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueStoredWithOldKey_WhenMigrateKey_ThenValueStoredWithNewKey() {
      var expected = 99;
      var oldKey = "oldKey";
      PlayerPrefs.SetInt(oldKey, expected);

      powerPrefsAccessor.MigrateKey(oldKey, TestKey);

      Assert.That(PlayerPrefs.GetInt(TestKey, -1), Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueStoredWithOldKey_WhenMigrateKey_ThenOldKeyDeleted() {
      var expected = 99;
      var oldKey = "oldKey";
      PlayerPrefs.SetInt(oldKey, expected);

      powerPrefsAccessor.MigrateKey(oldKey, TestKey);

      Assert.That(PlayerPrefs.HasKey(oldKey), Is.False);
    }
  }
}
