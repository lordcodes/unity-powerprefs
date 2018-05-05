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
﻿namespace AndrewLord.UnityPowerPrefs.UnitTests {

  using UnityEngine;
  using NUnit.Framework;

  public class PowerPrefsKeyAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private PowerPrefsKeyAccessor<string> valueAccessor;

    [SetUp]
    public void SetUp() {
      PrefAccessor<string> accessor = new StringPrefAccessor();
      var powerPrefsAccessor = new PowerPrefsAccessor<string>(accessor);
      valueAccessor = new PowerPrefsKeyAccessor<string>(powerPrefsAccessor, TestKey);
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValueRetrievedThroughAccessor() {
      var expected = "some_stored_string";
      PlayerPrefs.SetString(TestKey, expected);

      var actual = valueAccessor.Get();

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueNotStored_WhenGet_ThenProvidedDefault() {
      var expected = "some_default";

      var actual = valueAccessor.Get(expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueNotStoredAndNoDefault_WhenGet_ThenTypeDefault() {
      var actual = valueAccessor.Get();

      Assert.That(actual, Is.EqualTo(string.Empty));
    }

    [Test]
    public void WhenSet_ThenValueStoredThroughAccessor() {
      var expected = "some_new_value";

      valueAccessor.Set(expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "not_this"), Is.EqualTo(expected));
    }
  }
}