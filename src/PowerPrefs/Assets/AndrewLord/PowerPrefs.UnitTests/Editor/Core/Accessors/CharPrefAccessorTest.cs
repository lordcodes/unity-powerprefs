//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefs.Accessors.UnitTests
{

    using UnityEngine;
    using NUnit.Framework;

    public class CharPrefAccessorTest
    {
        private static readonly string TestKey = "someTestKey";

        private CharPrefAccessor accessor;

        [SetUp]
        public void SetUp()
        {
            accessor = new CharPrefAccessor();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void GivenValueStored_WhenGet_ThenValue()
        {
            var expected = "s";
            PlayerPrefs.SetString(TestKey, expected);

            var actual = accessor.Get(TestKey, 'd');

            Assert.That(actual, Is.EqualTo(expected[0]));
        }

        [Test]
        public void GivenKeyMissing_WhenGet_ThenDefault()
        {
            var expected = 'e';

            var actual = accessor.Get(TestKey, expected);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenCharTypeDefault()
        {
            var actual = accessor.Get(TestKey);

            Assert.That(actual, Is.EqualTo('\0'));
        }

        [Test]
        public void WhenSet_ThenValueStored()
        {
            var expected = 'n';

            accessor.Set(TestKey, expected);

            Assert.That(PlayerPrefs.GetString(TestKey, "i")[0], Is.EqualTo(expected));
        }

        [Test]
        public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten()
        {
            var expected = 'y';
            PlayerPrefs.SetString(TestKey, "p");

            accessor.Set(TestKey, expected);

            Assert.That(PlayerPrefs.GetString(TestKey, "t")[0], Is.EqualTo(expected));
        }
    }
}
