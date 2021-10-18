using UnityEngine;
using UnityEngine.UI;

public class ButtonStandBoothList : MonoBehaviour
{
    public void SetStandBoothName(string name)
    {
        GetComponentInChildren<Text>().text = name;
    }
}
