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

  using NUnit.Framework;
  using System;
  using UnityEngine;

  public class DateTimePrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private DateTimePrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new DateTimePrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      var expected = new DateTime(1000);
      PlayerPrefs.SetString(TestKey, expected.Ticks.ToString());

      var actual = accessor.Get(TestKey, new DateTime(2000));

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      var expected = new DateTime(3000);

      var actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenCharTypeDefault() {
      var actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(default(DateTime)));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      var expected = new DateTime(15000);

      accessor.Set(TestKey, expected);

      var actual = new DateTime(long.Parse(PlayerPrefs.GetString(TestKey, "1000")));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      var expected = new DateTime(23000);
      PlayerPrefs.SetString(TestKey, "121");

      accessor.Set(TestKey, expected);

      var actual = new DateTime(long.Parse(PlayerPrefs.GetString(TestKey, "-1")));
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}
