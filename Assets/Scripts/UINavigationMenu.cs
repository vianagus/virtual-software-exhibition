using UnityEngine;

public class UINavigationMenu : MonoBehaviour
{
    [Header("Initialize Buttons")]
    [SerializeField] GameObject openNavButton;
    [SerializeField] GameObject contentButtons;

    private void Start()
    {
        contentButtons.SetActive(false);
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
}
