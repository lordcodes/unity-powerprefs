//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefs.Accessors.UnitTests
{
    using UnityEngine;
    using NUnit.Framework;

    public class FloatPrefAccessorTest
    {
        private static readonly string TestKey = "someTestKey";

        private FloatPrefAccessor accessor;

        [SetUp]
        public void SetUp()
        {
            accessor = new FloatPrefAccessor();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void GivenValueStored_WhenGet_ThenValue()
        {
            var expected = 10f;
            PlayerPrefs.SetFloat(TestKey, expected);

            var actual = accessor.Get(TestKey, -1f);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenKeyMissing_WhenGet_ThenDefault()
        {
            var expected = -1f;

            var actual = accessor.Get(TestKey, expected);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero()
        {
            var actual = accessor.Get(TestKey);

            Assert.That(actual, Is.EqualTo(0f));
        }

        [Test]
        public void WhenSet_ThenValueStored()
        {
            var expected = 10f;

            accessor.Set(TestKey, expected);

            Assert.That(PlayerPrefs.GetFloat(TestKey, 100f), Is.EqualTo(expected));
        }

        [Test]
        public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten()
        {
            var expected = 20f;
            PlayerPrefs.SetFloat(TestKey, -1f);

            accessor.Set(TestKey, expected);

            Assert.That(PlayerPrefs.GetFloat(TestKey, 100f), Is.EqualTo(expected));
        }
    }
}
