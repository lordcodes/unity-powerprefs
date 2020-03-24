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

    public class InputBox : MonoBehaviour
    {
        private const string KeyInput = "KeyInput";

        public InputField inputField;

        void Awake()
        {
            var inputValue = PowerPrefs.ForString().Get(KeyInput, "Default");
            inputField.text = inputValue;
        }

        public void InputValueChanged(string input)
        {
            PowerPrefs.ForString().Set(KeyInput, input);
        }
    }
}
