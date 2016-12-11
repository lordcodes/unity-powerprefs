namespace AndrewLord.UnityPowerPrefs.UnitTests {

  using UnityEngine;
  using NUnit.Framework;

  public class LongPrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private LongPrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new LongPrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      long expected = 21;
      PlayerPrefs.SetString(TestKey, expected.ToString());

      long actual = accessor.Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      long expected = 31;

      long actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenCharTypeDefault() {
      long actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(0));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      long expected = 12;

      accessor.Set(TestKey, expected);

      long actual = long.Parse(PlayerPrefs.GetString(TestKey, "-1"));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      long expected = 23;
      PlayerPrefs.SetString(TestKey, "121");

      accessor.Set(TestKey, expected);

      long actual = long.Parse(PlayerPrefs.GetString(TestKey, "-1"));
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}