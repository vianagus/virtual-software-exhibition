using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenLink : MonoBehaviour
{
    private string url;

    public void SetURL(string url)
    {
        this.url = url;
    }

    public void OnButtonClick()
    {
        Application.OpenURL(url);
    }
}
