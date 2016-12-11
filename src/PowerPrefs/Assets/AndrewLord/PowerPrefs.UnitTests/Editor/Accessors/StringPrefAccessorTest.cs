namespace AndrewLord.UnityPowerPrefs.UnitTests {

  using UnityEngine;
  using NUnit.Framework;

  public class StringPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private StringPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new StringPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      string expected = "someValue";
      PlayerPrefs.SetString(TestKey, expected);

      string actual = accessor.Get(TestKey, "");

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      string expected = "someDefaultValue";

      string actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero() {
      string actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(""));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      string expected = "someValue";

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      string expected = "someNewValue";
      PlayerPrefs.SetString(TestKey, "oldValue");

      accessor.Set(TestKey, expected);

      Assert.That(PlayerPrefs.GetString(TestKey, ""), Is.EqualTo(expected));
    }
  }
}