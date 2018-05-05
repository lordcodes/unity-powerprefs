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

  public class StringPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private StringPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new StringPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      var expected = "someValue";
      PlayerPrefs.SetString(TestKey, expected);

      var actual = accessor.Get(TestKey, "");

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      var expected = "someDefaultValue";

      var actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero() {
      var actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(""));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      var expected = "someValue";

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      var expected = "someNewValue";
      PlayerPrefs.SetString(TestKey, "oldValue");

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
    }
  }
}
