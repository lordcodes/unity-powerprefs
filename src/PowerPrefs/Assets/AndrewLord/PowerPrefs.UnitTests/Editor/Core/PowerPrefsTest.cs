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
  using System;

  public class PowerPrefsTest {

    private static readonly string TestKey = "someTestKey";

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenForBool_WhenGet_ThenBoolRetrieved() {
      PlayerPrefs.SetInt(TestKey, 0);

      var actual = PowerPrefs.ForBool().Get(TestKey, true);

      Assert.That(actual, Is.False);
    }

    [Test]
    public void GivenForBool_WhenSet_ThenBoolStored() {
      PlayerPrefs.SetInt(TestKey, 0);

      PowerPrefs.ForBool().Set(TestKey, true);

      Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(1));
    }

    [Test]
    public void GivenForFloat_WhenGet_ThenFloatRetrieved() {
      var expected = 10f;
      PlayerPrefs.SetFloat(TestKey, expected);

      var actual = PowerPrefs.ForFloat().Get(TestKey, 100f);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForFloat_WhenSet_ThenFloatStored() {
      var expected = 100f;
      PlayerPrefs.SetFloat(TestKey, 10f);

      PowerPrefs.ForFloat().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetFloat(TestKey, 10f), Is.EqualTo(expected));
    }

    [Test]
    public void GivenForInt_WhenGet_ThenIntRetrieved() {
      var expected = 10;
      PlayerPrefs.SetInt(TestKey, expected);

      var actual = PowerPrefs.ForInt().Get(TestKey, 100);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForInt_WhenSet_ThenIntStored() {
      var expected = 100;
      PlayerPrefs.SetInt(TestKey, 10);

      PowerPrefs.ForInt().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetInt(TestKey, 10), Is.EqualTo(expected));
    }

    [Test]
    public void GivenForString_WhenGet_ThenStringRetrieved() {
      var expected = "someOldValue";
      PlayerPrefs.SetString(TestKey, expected);

      var actual = PowerPrefs.ForString().Get(TestKey, "");

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForString_WhenSet_ThenStringStored() {
      var expected = "someNewValue";
      PlayerPrefs.SetString(TestKey, "someOldValue");

      PowerPrefs.ForString().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
    }

    [Test]
    public void GivenForChar_WhenGet_ThenCharRetrieved() {
      var expected = 'd';
      PlayerPrefs.SetString(TestKey, expected.ToString());

      var actual = PowerPrefs.ForChar().Get(TestKey, 'x');

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForChar_WhenSet_ThenCharStoredAsString() {
      var expected = 'a';
      PlayerPrefs.SetString(TestKey, "someOldValue");

      PowerPrefs.ForChar().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "")[0], Is.EqualTo(expected));
    }

    [Test]
    public void GivenForLong_WhenGet_ThenLongRetrieved() {
      var expected = 123;
      PlayerPrefs.SetString(TestKey, expected.ToString());

      var actual = PowerPrefs.ForLong().Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForLong_WhenSet_ThenLongStoredAsString() {
      var expected = 22;
      PlayerPrefs.SetString(TestKey, "55");

      PowerPrefs.ForLong().Set(TestKey, expected);

      var actual = long.Parse(PlayerPrefs.GetString(TestKey, "-1"));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDouble_WhenGet_ThenDoubleRetrieved() {
      var expected = 123;
      PlayerPrefs.SetString(TestKey, expected.ToString());

      var actual = PowerPrefs.ForDouble().Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDouble_WhenSet_ThenDoubleStoredAsString() {
      var expected = 22;
      PlayerPrefs.SetString(TestKey, "55");

      PowerPrefs.ForDouble().Set(TestKey, expected);

      var actual = double.Parse(PlayerPrefs.GetString(TestKey, "-1"));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDateTime_WhenGet_ThenDateTimeRetrieved() {
      var expected = new DateTime(123456);
      PlayerPrefs.SetString(TestKey, expected.Ticks.ToString());

      var actual = PowerPrefs.ForDateTime().Get(TestKey, new DateTime(10));

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDateTime_WhenSet_ThenDateTimeStoredAsString() {
      var expected = new DateTime(11111);
      PlayerPrefs.SetString(TestKey, "55");

      PowerPrefs.ForDateTime().Set(TestKey, expected);

      var actual = new DateTime(long.Parse(PlayerPrefs.GetString(TestKey, "-1")));
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}
