using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject posterContainer;
    [SerializeField] private GameObject brochureContainer;

    [Header("Navigation Menu")]
    [SerializeField] private GameObject navMenuButton;
    [SerializeField] private GameObject navMenu;
    [SerializeField] private GameObject navMenuStandBoothList;
    [SerializeField] private GameObject navMenuHelp;

    private void Update()
    {
        // close UIs system
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(navMenu.activeInHierarchy)
            {
                if(navMenuStandBoothList.activeInHierarchy || navMenuHelp.activeInHierarchy)
                {
                    navMenuStandBoothList.SetActive(false);
                    navMenuHelp.SetActive(false);
                    return;
                }

                navMenuButton.SetActive(true);
                navMenu.SetActive(false);
                return;
            }

            if(posterContainer.activeInHierarchy) { posterContainer.SetActive(false); return; }
            if(brochureContainer.activeInHierarchy) { brochureContainer.SetActive(false); return; }
        }
    }
}
