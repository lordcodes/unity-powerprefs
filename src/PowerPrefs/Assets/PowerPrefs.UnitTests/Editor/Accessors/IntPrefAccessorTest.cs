using UnityEngine;
using NUnit.Framework;

namespace PowerPrefs.UnitTests {
	public class IntPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private IntPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new IntPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

		[Test]
		public void GivenValueStored_WhenGet_ThenValue() {
      int expected = 10;
      PlayerPrefs.SetInt(TestKey, expected);

      int actual = accessor.Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      int expected = -1;

      int actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

		[Test]
		public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero() {
      int actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(0));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      int expected = 10;
      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      int expected = 20;
      PlayerPrefs.SetInt(TestKey, -1);

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetInt(TestKey, 100), Is.EqualTo(expected));
    }

  }
}