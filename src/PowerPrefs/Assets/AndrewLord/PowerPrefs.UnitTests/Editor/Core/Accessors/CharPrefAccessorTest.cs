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

  public class CharPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private CharPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new CharPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      var expected = "s";
      PlayerPrefs.SetString(TestKey, expected);

      var actual = accessor.Get(TestKey, 'd');

      Assert.That(actual, Is.EqualTo(expected[0]));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      var expected = 'e';

      var actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenCharTypeDefault() {
      var actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo('\0'));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      var expected = 'n';

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "i")[0], Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      var expected = 'y';
      PlayerPrefs.SetString(TestKey, "p");

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "t")[0], Is.EqualTo(expected));
    }
  }
}
