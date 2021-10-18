using UnityEngine;
using UnityEngine.UI;

public class UIStandBoothList : MonoBehaviour
{
    [SerializeField] GameObject standBoothButtonInstance;
    [SerializeField] GameObject listContainer;

    private void Start()
    {
        InstanceStandBoothList();
    }

    private void InstanceStandBoothList()
    {
        StandBooth[] standBoothsInScene = FindObjectsOfType<StandBooth>();

        foreach (StandBooth standBooth in standBoothsInScene)
        {
            GameObject standBoothList = Instantiate(standBoothButtonInstance);
            standBoothList.GetComponent<ButtonStandBoothList>().SetStandBooth(standBooth);
            standBoothList.GetComponentInChildren<Text>().text = standBooth.GetName();
            standBoothList.transform.parent = listContainer.transform;
        }
    }

    public void OnCloseButtonClick()
    {
        gameObject.SetActive(false);
    }
}
