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

  public class BoolPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private BoolPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new BoolPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenTrueValueStored_WhenGet_ThenTrue() {
      PlayerPrefs.SetInt(TestKey, 1);

      var actual = accessor.Get(TestKey, false);

      Assert.That(actual, Is.True);
    }

    [Test]
    public void GivenFalseValueStored_WhenGet_ThenFalse() {
      PlayerPrefs.SetInt(TestKey, 0);

      var actual = accessor.Get(TestKey, true);

      Assert.That(actual, Is.False);
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      var actual = accessor.Get(TestKey, true);

      Assert.That(actual, Is.True);
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenFalse() {
      var actual = accessor.Get(TestKey);

      Assert.That(actual, Is.False);
    }

    [Test]
    public void GivenTrue_WhenSet_ThenTrueValueStored() {
      accessor.Set(TestKey, true);

      Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(1));
    }

    [Test]
    public void GivenFalse_WhenSet_ThenFalseValueStored() {
      accessor.Set(TestKey, false);

      Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(0));
    }
  }
}
