using UnityEngine;
using NUnit.Framework;

namespace PowerPrefs.UnitTests {
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

	}
}
