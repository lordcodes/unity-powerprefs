//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{
    using UnityEngine;
    using NUnit.Framework;

    public class StringPrefAccessorTest
    {
        private static readonly string TestKey = "someTestKey";

        private StringPrefAccessor accessor;

        [SetUp]
        public void SetUp()
        {
            accessor = new StringPrefAccessor();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void GivenValueStored_WhenGet_ThenValue()
        {
            var expected = "someValue";
            PlayerPrefs.SetString(TestKey, expected);

            var actual = accessor.Get(TestKey, "");

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenKeyMissing_WhenGet_ThenDefault()
        {
            var expected = "someDefaultValue";

            var actual = accessor.Get(TestKey, expected);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero()
        {
            var actual = accessor.Get(TestKey);

            Assert.That(actual, Is.EqualTo(""));
        }

        [Test]
        public void WhenSet_ThenValueStored()
        {
            var expected = "someValue";

            accessor.Set(TestKey, expected);

            Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
        }

        [Test]
        public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten()
        {
            var expected = "someNewValue";
            PlayerPrefs.SetString(TestKey, "oldValue");

            accessor.Set(TestKey, expected);

            Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
        }
    }
}
