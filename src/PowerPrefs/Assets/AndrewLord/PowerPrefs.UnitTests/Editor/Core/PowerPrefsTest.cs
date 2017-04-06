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

      bool actual = PowerPrefs.ForBool().Get(TestKey, true);

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
      float expected = 10f;
      PlayerPrefs.SetFloat(TestKey, expected);

      float actual = PowerPrefs.ForFloat().Get(TestKey, 100f);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForFloat_WhenSet_ThenFloatStored() {
      float expected = 100f;
      PlayerPrefs.SetFloat(TestKey, 10f);

      PowerPrefs.ForFloat().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetFloat(TestKey, 10f), Is.EqualTo(expected));
    }

    [Test]
    public void GivenForInt_WhenGet_ThenIntRetrieved() {
      int expected = 10;
      PlayerPrefs.SetInt(TestKey, expected);

      int actual = PowerPrefs.ForInt().Get(TestKey, 100);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForInt_WhenSet_ThenIntStored() {
      int expected = 100;
      PlayerPrefs.SetInt(TestKey, 10);

      PowerPrefs.ForInt().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetInt(TestKey, 10), Is.EqualTo(expected));
    }

    [Test]
    public void GivenForString_WhenGet_ThenStringRetrieved() {
      string expected = "someOldValue";
      PlayerPrefs.SetString(TestKey, expected);

      string actual = PowerPrefs.ForString().Get(TestKey, "");

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForString_WhenSet_ThenStringStored() {
      string expected = "someNewValue";
      PlayerPrefs.SetString(TestKey, "someOldValue");

      PowerPrefs.ForString().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
    }

    [Test]
    public void GivenForChar_WhenGet_ThenCharRetrieved() {
      char expected = 'd';
      PlayerPrefs.SetString(TestKey, expected.ToString());

      char actual = PowerPrefs.ForChar().Get(TestKey, 'x');

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForChar_WhenSet_ThenCharStoredAsString() {
      char expected = 'a';
      PlayerPrefs.SetString(TestKey, "someOldValue");

      PowerPrefs.ForChar().Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "")[0], Is.EqualTo(expected));
    }

    [Test]
    public void GivenForLong_WhenGet_ThenLongRetrieved() {
      long expected = 123;
      PlayerPrefs.SetString(TestKey, expected.ToString());

      long actual = PowerPrefs.ForLong().Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForLong_WhenSet_ThenLongStoredAsString() {
      long expected = 22;
      PlayerPrefs.SetString(TestKey, "55");

      PowerPrefs.ForLong().Set(TestKey, expected);

      long actual = long.Parse(PlayerPrefs.GetString(TestKey, "-1"));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDouble_WhenGet_ThenDoubleRetrieved() {
      double expected = 123;
      PlayerPrefs.SetString(TestKey, expected.ToString());

      double actual = PowerPrefs.ForDouble().Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDouble_WhenSet_ThenDoubleStoredAsString() {
      double expected = 22;
      PlayerPrefs.SetString(TestKey, "55");

      PowerPrefs.ForDouble().Set(TestKey, expected);

      double actual = double.Parse(PlayerPrefs.GetString(TestKey, "-1"));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDateTime_WhenGet_ThenDateTimeRetrieved() {
      DateTime expected = new DateTime(123456);
      PlayerPrefs.SetString(TestKey, expected.Ticks.ToString());

      DateTime actual = PowerPrefs.ForDateTime().Get(TestKey, new DateTime(10));

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenForDateTime_WhenSet_ThenDateTimeStoredAsString() {
      DateTime expected = new DateTime(11111);
      PlayerPrefs.SetString(TestKey, "55");

      PowerPrefs.ForDateTime().Set(TestKey, expected);

      DateTime actual = new DateTime(long.Parse(PlayerPrefs.GetString(TestKey, "-1")));
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}
