<p align="center">
    <img src="Art/logo.png" width="500" max-width="90%" alt="PowerPrefs" />
</p>

<p align="center">
    <a href="https://github.com/lordcodes/unity-powerprefs/releases/latest">
        <img src="https://img.shields.io/github/release/lordcodes/unity-powerprefs.svg?style=flat" alt="Latest release" />
    </a>
    <img src="https://img.shields.io/badge/platform-unity-blueviolet.svg?style=flat" alt="Twitter: @lordcodes" />
    <a href="https://twitter.com/lordcodes">
        <img src="https://img.shields.io/badge/twitter-@lordcodes-00acee.svg?style=flat" alt="Twitter: @lordcodes" />
    </a>
</p>

A **powerful** and **extensible** preferences package for Unity, built on top of `PlayerPrefs`. PowerPrefs provides access to many more types than before, whilst also providing type-safe accessors to your key-value store.

&nbsp;

<p align="center">
    <a href="#features">Features</a> • <a href="#install">Install</a> • <a href="#usage">Usage</a>
</p>

***

## Features

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

## Install

You can download the latest version of PowerPrefs [from releases](https://github.com/lordcodes/unity-powerprefs/releases/latest).

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

## Contributing or Help

If you notice any bugs or have a new feature to suggest, please check out the [contributing guide](https://github.com/lordcodes/unity-powerprefs/blob/master/CONTRIBUTING.md). If you want to make changes, please make sure to discuss anything big before putting in the effort of creating the PR.

To reach out, please contact [@lordcodes on Twitter](https://twitter.com/lordcodes).
