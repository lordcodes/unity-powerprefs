# PowerPrefs

[![Version](https://img.shields.io/badge/Version-v0.2.0-blue.svg)](https://github.com/andrewlord1990/unity-powerprefs/releases/latest)
[![Build Status](https://travis-ci.org/andrewlord1990/unity-powerprefs.svg?branch=master)](https://travis-ci.org/andrewlord1990/unity-powerprefs)
[![License](https://img.shields.io/badge/license-Apache%202.0-green.svg) ](https://github.com/andrewlord1990/unity-powerprefs/blob/master/LICENSE)

Unity provides a set of static `PlayerPrefs` methods to store key-value pairs, similar to `SharedPreferences` on Android. Unfortunately, there are only methods provided for `int`, `float` and `string`. Also, as the methods are static you cannot even add other types through extension methods. PowerPrefs provides access to many more types and also opens up the possibility for even more features as well.

## Download

You can obtain PowerPrefs by [using this link](https://github.com/andrewlord1990/unity-powerprefs/releases/download/v0.2.0/PowerPrefs.0.2.0.unitypackage).

Once you have the `unitypackage` file, you can import it into your Unity project. If your project is already open then you can simply double-click the downloaded package. Alternatively, go to `Assets -> Import Package -> Custom Package` within the Unity editor.

## Main Features

- Read and write values to `PlayerPrefs` with support for many extra types, such as `bool`, `char`, `DateTime` and `long`.
- Values are retrieved and written through an accessor class which is typed. Meaning there are no types in the method names and allowing you to store the accessor class to read and write a key safely, without mentioning the type again.
- A method is provided to migrate a value from one key to another, which is useful if you wish to rename one of your keys safely.
- The classes which read and write values contain instance methods, allowing you to add extra features through extension methods if you wish. Even better, contribute them back to the library for others to use too!

## Usage

First retrieve a typed accessor and then get or set a value:

```c#
PowerPrefs.ForBool().Get("aBoolean");
PowerPrefs.ForInt().Get("anInteger", -1);

PowerPrefs.ForLong().Set("aLong", 123456);
PowerPrefs.ForString().Set("aString", "Hello");
```

For the `Get` call you can provide a default value to return if the key doesn't exist. If this isn't provided then the default for that type will be used instead. E.g. for `int` it would be 0.

### Re-use Accessor

You have the option of storing and re-using the accessor class.

```c#
PowerPrefsAccessor<int> accessor = PowerPrefs.ForInt();
...
int myValue = accessor.Get("myKey");
accessor.Set("meyKey", 5);
```

An accessor for a particular key is also available: `PowerPrefsValue<T>`.

```c#
PowerPrefsValue<string> accessor = PowerPrefs.ForString().Value("someKey");
...
string myValue = accessor.Get();
accessor.Set("newValue");
```

## Suggestions

If there are any features that have been missed that you are interested in then please open an issue. Thanks!

## License

    Copyright 2016 Andrew Lord

    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
