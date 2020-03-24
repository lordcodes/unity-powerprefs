//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefs.Accessors.UnitTests
{
    using UnityEngine;
    using NUnit.Framework;

    public class BoolPrefAccessorTest
    {
        private static readonly string TestKey = "someTestKey";

        private BoolPrefAccessor accessor;

        [SetUp]
        public void SetUp()
        {
            accessor = new BoolPrefAccessor();
        }

        [TearDown]
        public void TearDown()
        {
            PlayerPrefs.DeleteAll();
        }

        [Test]
        public void GivenTrueValueStored_WhenGet_ThenTrue()
        {
            PlayerPrefs.SetInt(TestKey, 1);

            var actual = accessor.Get(TestKey, false);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void GivenFalseValueStored_WhenGet_ThenFalse()
        {
            PlayerPrefs.SetInt(TestKey, 0);

            var actual = accessor.Get(TestKey, true);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void GivenKeyMissing_WhenGet_ThenDefault()
        {
            var actual = accessor.Get(TestKey, true);

            Assert.That(actual, Is.True);
        }

        [Test]
        public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenFalse()
        {
            var actual = accessor.Get(TestKey);

            Assert.That(actual, Is.False);
        }

        [Test]
        public void GivenTrue_WhenSet_ThenTrueValueStored()
        {
            accessor.Set(TestKey, true);

            Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(1));
        }

        [Test]
        public void GivenFalse_WhenSet_ThenFalseValueStored()
        {
            accessor.Set(TestKey, false);

            Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(0));
        }
    }
}
