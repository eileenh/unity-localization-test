using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class StringFormat : MonoBehaviour
{
    public enum TestMode
    {
        StringFormat,
        CustomSmartFormat,
        LocSmartFormat
    }

    public TestMode testMode;
    public TextMeshProUGUI textbox;
    public LocalizedString stringTemplate;

    private void Start()
    {
        LocalizationSettings.Instance.OnSelectedLocaleChanged += InstanceOnOnSelectedLocaleChanged;
        UpdateString();
    }

    private void OnDestroy()
    {
        LocalizationSettings.Instance.OnSelectedLocaleChanged -= InstanceOnOnSelectedLocaleChanged;
    }

    public void UpdateString()
    {
        var formatArgs = new[] { new { Amount = 2333.33 }};
        
        
        String textboxString = "Not implemented";
        String sourceString;
        
        switch (testMode)
        {
            case TestMode.StringFormat:
                sourceString = stringTemplate.GetLocalizedString();
                textboxString = String.Format(sourceString, 2333.33);
                break;
            case TestMode.LocSmartFormat:
                textboxString = stringTemplate.GetLocalizedString(formatArgs);
                break;
            case TestMode.CustomSmartFormat:
                sourceString = stringTemplate.GetLocalizedString();
                textboxString = LocalizationSettings.Instance.GetStringDatabase().SmartFormatter
                    .Format(sourceString, formatArgs);
                break;
        }

        textbox.text = textboxString;
    }

    private void InstanceOnOnSelectedLocaleChanged(Locale obj)
    {
        UpdateString();
    }
}
