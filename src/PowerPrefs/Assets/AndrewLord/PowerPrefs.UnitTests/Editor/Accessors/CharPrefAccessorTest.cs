namespace AndrewLord.UnityPowerPrefs.UnitTests {

  using UnityEngine;
  using NUnit.Framework;

  public class CharPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private CharPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new CharPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      string expected = "s";
      PlayerPrefs.SetString(TestKey, expected);

      char actual = accessor.Get(TestKey, 'd');

      Assert.That(actual, Is.EqualTo(expected[0]));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      char expected = 'e';

      char actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenCharTypeDefault() {
      char actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo('\0'));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      char expected = 'n';

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "i")[0], Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      char expected = 'y';
      PlayerPrefs.SetString(TestKey, "p");

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, "t")[0], Is.EqualTo(expected));
    }
  }
}