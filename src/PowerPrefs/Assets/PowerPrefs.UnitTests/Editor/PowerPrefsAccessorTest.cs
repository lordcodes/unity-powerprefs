using UnityEngine;
using NUnit.Framework;

namespace PowerPrefs.UnitTests {
	public class PowerPrefsAccessorTest {

    private static readonly string TestKey = "someTestKey";

		private PowerPrefsAccessor<int> powerPrefsAccessor;

		[SetUp]
		public void SetUp() {
			PrefAccessor<int> accessor = new IntPrefAccessor();
			powerPrefsAccessor = new PowerPrefsAccessor<int>(accessor);
		}

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

		[Test]
		public void GivenValueStored_WhenGet_ThenValueRetrievedThroughAccessor() {
			int expected = 25;
			PlayerPrefs.SetInt(TestKey, expected);

			int actual = powerPrefsAccessor.Get(TestKey, -1);

			Assert.That(actual, Is.EqualTo(expected));
		}

    [Test]
		public void GivenValueNotStored_WhenGet_ThenProvidedDefault() {
			int expected = -1;

			int actual = powerPrefsAccessor.Get(TestKey, expected);

			Assert.That(actual, Is.EqualTo(expected));
		}

    [Test]
		public void GivenValueNotStoredAndNoDefault_WhenGet_ThenTypeDefault() {
			int actual = powerPrefsAccessor.Get(TestKey);

			Assert.That(actual, Is.EqualTo(0));
		}

    [Test]
		public void WhenSet_ThenValueStoredThroughAccessor() {
			int expected = 99;

      powerPrefsAccessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetInt(TestKey, -1), Is.EqualTo(expected));
		}

    [Test]
		public void GivenValueStoredWithOldKey_WhenMoveKeys_ThenValueStoredWithNewKey() {
			int expected = 99;
			string oldKey = "oldKey";
			PlayerPrefs.SetInt(oldKey, expected);

      powerPrefsAccessor.MoveKeys(oldKey, TestKey);

      Assert.That(PlayerPrefs.GetInt(TestKey, -1), Is.EqualTo(expected));
		}

    [Test]
		public void GivenValueStoredWithOldKey_WhenMoveKeys_ThenOldKeyDeleted() {
			int expected = 99;
			string oldKey = "oldKey";
			PlayerPrefs.SetInt(oldKey, expected);

      powerPrefsAccessor.MoveKeys(oldKey, TestKey);

      Assert.That(PlayerPrefs.HasKey(oldKey), Is.False);
		}

	}
}
