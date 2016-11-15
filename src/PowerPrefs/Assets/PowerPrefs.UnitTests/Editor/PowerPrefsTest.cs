using UnityEngine;
using NUnit.Framework;

namespace PowerPrefs.UnitTests {
	public class PowerPrefsTest {

		[Test]
		public void GivenForBool_WhenGet_ThenBoolRetrieved() {
			string testKey = "someKey";
			PlayerPrefs.SetInt(testKey, 0);

			bool actual = PowerPrefs.ForBool().Get(testKey, true);

			Assert.That(actual, Is.False);
		}

    [Test]
		public void GivenForBool_WhenSet_ThenBoolStored() {
				string testKey = "someKey";
				PlayerPrefs.SetInt(testKey, 0);

				PowerPrefs.ForBool().Set(testKey, true);

				Assert.That(PlayerPrefs.GetInt(testKey, 100), Is.EqualTo(1));
		}

		[Test]
		public void GivenForFloat_WhenGet_ThenFloatRetrieved() {
			string testKey = "someKey";
      float expected = 10f;
			PlayerPrefs.SetFloat(testKey, expected);

			float actual = PowerPrefs.ForFloat().Get(testKey, 100f);

			Assert.That(actual, Is.EqualTo(expected));
		}

    [Test]
		public void GivenForFloat_WhenSet_ThenFloatStored() {
      string testKey = "someKey";
      float expected = 100f;
			PlayerPrefs.SetFloat(testKey, 10f);

      PowerPrefs.ForFloat().Set(testKey, expected);

      Assert.That(PlayerPrefs.GetFloat(testKey, 10f), Is.EqualTo(expected));
		}

		[Test]
		public void GivenForInt_WhenGet_ThenIntRetrieved() {
			string testKey = "someKey";
      int expected = 10;
			PlayerPrefs.SetInt(testKey, expected);

			int actual = PowerPrefs.ForInt().Get(testKey, 100);

			Assert.That(actual, Is.EqualTo(expected));
		}

    [Test]
		public void GivenForInt_WhenSet_ThenIntStored() {
      string testKey = "someKey";
      int expected = 100;
			PlayerPrefs.SetInt(testKey, 10);

      PowerPrefs.ForInt().Set(testKey, expected);

      Assert.That(PlayerPrefs.GetInt(testKey, 10), Is.EqualTo(expected));
		}

		[Test]
		public void GivenForString_WhenGet_ThenStringRetrieved() {
			string testKey = "someKey";
      string expected = "someOldValue";
			PlayerPrefs.SetString(testKey, expected);

			string actual = PowerPrefs.ForString().Get(testKey, "");

			Assert.That(actual, Is.EqualTo(expected));
		}

    [Test]
		public void GivenForString_WhenSet_ThenStringStored() {
      string testKey = "someKey";
      string expected = "someNewValue";
			PlayerPrefs.SetString(testKey, "someOldValue");

      PowerPrefs.ForString().Set(testKey, expected);

      Assert.That(PlayerPrefs.GetString(testKey, ""), Is.EqualTo(expected));
		}

	}
}
