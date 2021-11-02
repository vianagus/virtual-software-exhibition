using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBrochure : MonoBehaviour
{
    [Header("Initialize Container")]
    [SerializeField] GameObject brochureContainer;

    [Header("Initialize Contents")]
    [SerializeField] Image productLogo;
    [SerializeField] Text productName;
    [SerializeField] Text description;

    private void Start() 
    {
        CloseBrochure();
    }

    private void SetIdentity(Sprite logo, string productName)
    {
        this.productName.text = productName;
        if(logo == null) return;
        this.productLogo.sprite = logo;
    }

    private void SetDescription(string description)
    {
        this.description.text = description;
    }

    public void OpenBrochure(StandBooth standBooth)
    {
        SetIdentity(standBooth.GetLogo(), standBooth.GetProductName());
        SetDescription(standBooth.GetProductDescription());

        brochureContainer.SetActive(true);
    }

    public void CloseBrochure()
    {
        //HideContent();
        brochureContainer.SetActive(false);
    }
}
