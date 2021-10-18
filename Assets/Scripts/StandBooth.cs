using UnityEngine;

public class StandBooth : MonoBehaviour
{
    [SerializeField] string standBoothName;

    public string GetName()
    {
        return this.standBoothName;
    }
}
