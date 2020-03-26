//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{

    using NUnit.Framework;
    using System;
    using UnityEngine;

    public class DateTimePrefAccessorTest
    {
        private static readonly string TestKey = "someTestKey";

        private DateTimePrefAccessor accessor;

        [SetUp]
        public void SetUp()
        {
            accessor = new DateTimePrefAccessor();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void GivenValueStored_WhenGet_ThenValue()
        {
            var expected = new DateTime(1000);
            PlayerPrefs.SetString(TestKey, expected.Ticks.ToString());

            var actual = accessor.Get(TestKey, new DateTime(2000));

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenKeyMissing_WhenGet_ThenDefault()
        {
            var expected = new DateTime(3000);

            var actual = accessor.Get(TestKey, expected);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenCharTypeDefault()
        {
            var actual = accessor.Get(TestKey);

            Assert.That(actual, Is.EqualTo(default(DateTime)));
        }

        [Test]
        public void WhenSet_ThenValueStored()
        {
            var expected = new DateTime(15000);

            accessor.Set(TestKey, expected);

            var actual = new DateTime(long.Parse(PlayerPrefs.GetString(TestKey, "1000")));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten()
        {
            var expected = new DateTime(23000);
            PlayerPrefs.SetString(TestKey, "121");

            accessor.Set(TestKey, expected);

            var actual = new DateTime(long.Parse(PlayerPrefs.GetString(TestKey, "-1")));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
