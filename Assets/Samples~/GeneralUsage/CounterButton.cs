//
// PowerPrefs
// Copyright (C) 2016 Andrew Lord
// Apache License, Version 2.0, see LICENSE file for details
//
namespace AndrewLord.UnityPowerPrefsSample
{
    using AndrewLord.UnityPowerPrefs;
    using UnityEngine;
    using UnityEngine.UI;

    public class CounterButton : MonoBehaviour
    {
        private const string KeyCounter = "KeyCounter";

        public Text label;

        private PowerPrefsKeyAccessor<int> accessor;

        void Awake()
        {
            accessor = PowerPrefs.ForInt().KeyAccessor(KeyCounter);
            CounterChanged(accessor.Get());
        }

        public void IncrementCounter()
        {
            var counter = accessor.Get() + 1;
            accessor.Set(counter);
            CounterChanged(counter);
        }

        private void CounterChanged(int counter)
        {
            label.text = counter.ToString();
        }
    }
}
