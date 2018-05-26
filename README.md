# PowerPrefs

[![Version](https://img.shields.io/badge/Version-v0.4.0-blue.svg)](https://github.com/andrewlord1990/unity-powerprefs/releases/latest)
[![Build Status](https://travis-ci.org/andrewlord1990/unity-powerprefs.svg?branch=master)](https://travis-ci.org/andrewlord1990/unity-powerprefs)
[![License](https://img.shields.io/badge/license-Apache%202.0-green.svg) ](https://github.com/andrewlord1990/unity-powerprefs/blob/master/LICENSE)

A **powerful** and **extensible** preferences package for Unity, built on top of `PlayerPrefs`. PowerPrefs provides access to many more types than before, whilst also providing type-safe accessors to your key-value store.

&nbsp;

<p align="center">
    <a href="#key-benefits">Features</a> • <a href="#installation">Installation</a> • <a href="#usage">Usage</a>
</p>

***

## Key Benefits

#### ▶︎ Many extra types

Read and write values to `PlayerPrefs` with support for many extra types, such as `bool`, `char`, `DateTime` and `long`. There is also the possibility for adding many more in the future.

#### ▶︎ Easy-to-use

You can be up and running without any configuration, simply start getting and setting values.

#### ▶︎ Type-safe accessors

Values are retrieved and written through an accessor class which is typed. This means there are no types in the method names and you can even store the accessor class to read and write a key safely, without mentioning the type again. You can also store an accessor for a particular key to be used across your codebase without re-specifying the key.

#### ▶︎ Migration

A method is provided to migrate a value from one key to another, which is useful if you wish to rename one of your keys safely.

#### ▶︎ Open for extension

The classes which read and write values contain instance methods, allowing you to add extra features through extension methods if you wish. Even better, contribute them back to the library for others to use too!

#### ▶︎ Fully documented

The public API is fully documented, including code documentation.

## Unity Support

It is developed and tested on Unity 2018.1.

## Installation

You can download the latest version of PowerPrefs by [using this link](https://github.com/andrewlord1990/unity-powerprefs/releases/download/v0.4.0/PowerPrefs.0.4.0.unitypackage).

Once you have the `unitypackage` file, you can import it into your Unity project. If your project is already open then you can simply double-click the downloaded package. Alternatively, go to `Assets -> Import Package -> Custom Package` within the Unity editor.

## Usage

First retrieve a typed accessor and then get or set a value:

```c#
PowerPrefs.ForBool().Get("aBoolean");
PowerPrefs.ForInt().Get("anInteger", -1);

PowerPrefs.ForLong().Set("aLong", 123456);
PowerPrefs.ForString().Set("aString", "Hello");
```

For the `Get` call you can provide a default value to return if the key doesn't exist. If this isn't provided then the default for that type will be used instead. E.g. for `int` it would be 0.

## Advanced Usage

### Re-use Accessor

You have the option of storing and re-using the accessor class.

```c#
var accessor = PowerPrefs.ForInt();
...
var myValue = accessor.Get("myKey");
accessor.Set("meyKey", 5);
```

An accessor for a particular key is also available: `PowerPrefsKeyAccessor<T>`.

```c#
var keyAccessor = PowerPrefs.ForString().KeyAccessor("someKey");
...
var myValue = keyAccessor.Get();
keyAccessor.Set("newValue");
```

## Contributing

- [Open an issue](https://github.com/andrewlord1990/unity-powerprefs/issues)

If you find something that you don't think is working correctly, you have a feature you would like to see in PowerPrefs or just because you want to ask for some help, please [open an issue](https://github.com/andrewlord1990/unity-powerprefs/issues).

- [Open a PR](https://github.com/andrewlord1990/unity-powerprefs/pulls)

If you would like to contribute some changes to PowerPrefs, I would greatly appreciate a PR. If you would like to make a major change, please create an issue first to discuss it.

## Author

Andrew Lord [@andrewlord1990](https://twitter.com/@andrewlord1990)
