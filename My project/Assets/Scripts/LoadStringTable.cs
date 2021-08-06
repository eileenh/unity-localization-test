using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class LoadStringTable : MonoBehaviour
{
    public LocalizedStringTable tableToLoad;
    public TextMeshProUGUI textbox;
    
    public void LoadStrings()
    {
        var operation = tableToLoad.GetTableAsync();
        operation.WaitForCompletion();

        if (operation.OperationException != null)
        {
            // Here we're getting an exception, no data, and a status = Success
            textbox.text = "Failed to load string : " + operation.OperationException.Message;
        }
        else
        {
            textbox.text = "String loaded: " + operation.Result["NewString"].Value;            
        }
    }
}
