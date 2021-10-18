using UnityEngine;

public class UINavigationMenu : MonoBehaviour
{
    [Header("Initialize Buttons")]
    [SerializeField] GameObject openNavButton;
    [SerializeField] GameObject contentButtons;

    [Header("Initialize Contents")]
    [SerializeField] GameObject standBoothList;

    private void Start()
    {
        contentButtons.SetActive(false);
        standBoothList.SetActive(false);
    }

    // open navigation menu by button click
    public void OnOpenNavButtonClick()
    {
        openNavButton.SetActive(false);
        contentButtons.SetActive(true);
    }

    // close navigation menu by button click
    public void OnCloseNavButtonClick()
    {
        openNavButton.SetActive(true);
        contentButtons.SetActive(false);
    }

    public void OnStandBoothListClick()
    {
        standBoothList.SetActive(true);
    }
}
