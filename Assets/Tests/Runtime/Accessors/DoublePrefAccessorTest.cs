//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{
    using UnityEngine;
    using NUnit.Framework;

    public class DoublePrefAccessorTest
    {
        private static readonly string TestKey = "someTestKey";

        private DoublePrefAccessor accessor;

        [SetUp]
        public void SetUp()
        {
            accessor = new DoublePrefAccessor();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void GivenValueStored_WhenGet_ThenValue()
        {
            var expected = 10;
            PlayerPrefs.SetString(TestKey, expected.ToString());

            var actual = accessor.Get(TestKey, -1);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenKeyMissing_WhenGet_ThenDefault()
        {
            var expected = -1;

            var actual = accessor.Get(TestKey, expected);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero()
        {
            var actual = accessor.Get(TestKey);

            Assert.That(actual, Is.EqualTo(0));
        }

        [Test]
        public void WhenSet_ThenValueStored()
        {
            var expected = 10;

            accessor.Set(TestKey, expected);

            var actual = double.Parse(PlayerPrefs.GetString(TestKey, "100"));
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten()
        {
            var expected = 20;
            PlayerPrefs.SetString(TestKey, "-1");

            accessor.Set(TestKey, expected);

            var actual = double.Parse(PlayerPrefs.GetString(TestKey, "100"));
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
