//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefs.Extensions
{
    internal static class BoolExtensions
    {
        internal static int ToInt(this bool prefValue)
        {
            return prefValue ? 1 : 0;
        }
    }
}
