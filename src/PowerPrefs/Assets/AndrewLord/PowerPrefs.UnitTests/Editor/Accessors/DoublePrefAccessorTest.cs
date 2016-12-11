namespace AndrewLord.UnityPowerPrefs.UnitTests {

  using UnityEngine;
  using NUnit.Framework;

  public class DoublePrefAccessorTest {

    private static readonly string TestKey = "someTestKey";

    private DoublePrefAccessor accessor;

    [SetUp]
    public void SetUp() {
      accessor = new DoublePrefAccessor();
    }

    [TearDown]
    public void TearDown() {
      PlayerPrefs.DeleteAll();
    }

    [Test]
    public void GivenValueStored_WhenGet_ThenValue() {
      double expected = 10;
      PlayerPrefs.SetString(TestKey, expected.ToString());

      double actual = accessor.Get(TestKey, -1);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenKeyMissing_WhenGet_ThenDefault() {
      double expected = -1;

      double actual = accessor.Get(TestKey, expected);

      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenNoDefaultProvidedAndKeyMissing_WhenGet_ThenZero() {
      double actual = accessor.Get(TestKey);

      Assert.That(actual, Is.EqualTo(0));
    }

    [Test]
    public void WhenSet_ThenValueStored() {
      double expected = 10;

      accessor.Set(TestKey, expected);

      double actual = double.Parse(PlayerPrefs.GetString(TestKey, "100"));
      Assert.That(actual, Is.EqualTo(expected));
    }

    [Test]
    public void GivenValueAlreadyStored_WhenSet_ThenValueOverwritten() {
      double expected = 20;
      PlayerPrefs.SetString(TestKey, "-1");

      accessor.Set(TestKey, expected);

      double actual = double.Parse(PlayerPrefs.GetString(TestKey,"100"));
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}