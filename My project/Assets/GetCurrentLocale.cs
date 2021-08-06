using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

public class GetCurrentLocale : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    
    void Start()
    {
        Locale currentLocale = LocalizationSettings.Instance.GetSelectedLocale();
        LocalizationSettings.Instance.OnSelectedLocaleChanged += InstanceOnOnSelectedLocaleChanged;
        InstanceOnOnSelectedLocaleChanged(currentLocale);
    }

    private void OnDestroy()
    {
        LocalizationSettings.Instance.OnSelectedLocaleChanged -= InstanceOnOnSelectedLocaleChanged;
    }

    private void InstanceOnOnSelectedLocaleChanged(Locale newLocale)
    {
        textbox.text = newLocale.LocaleName;
    }
}
