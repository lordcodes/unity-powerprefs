//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace LordCodes.PowerPrefs.Accessors
{
    public interface IPrefAccessor<ValueT>
    {
        ValueT Get(string prefKey, ValueT defaultValue = default);

        IPrefAccessor<ValueT> Set(string prefKey, ValueT prefValue);
    }
}
