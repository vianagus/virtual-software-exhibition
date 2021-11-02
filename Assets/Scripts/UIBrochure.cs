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
    [SerializeField] Button presentationLink;
    [SerializeField] Button demoLink;

    private void Start() 
    {
        CloseBrochure();
    }

    private void SetLogo(Sprite logo)
    {
        if(logo == null) return;
        this.productLogo.sprite = logo;
    }

    private void SetName(string name)
    {
        this.productName.text = name;
    }

    private void SetDescription(string description)
    {
        this.description.text = description;
    }

    private void SetLinks(string presentationLink, string demoLink)
    {
        // for presentation link
        if(!presentationLink.Equals(""))
        {
            this.presentationLink.GetComponent<ButtonOpenLink>().SetURL(presentationLink);
            this.presentationLink.gameObject.SetActive(true);
        }
        else
        {
            this.presentationLink.gameObject.SetActive(false);
        }

        // for demo link
        if(!demoLink.Equals(""))
        {
            this.demoLink.GetComponent<ButtonOpenLink>().SetURL(demoLink);
            this.demoLink.gameObject.SetActive(true);
        }
        else
        {
            this.demoLink.gameObject.SetActive(false);
        }
    }

    public void OpenBrochure(StandBooth standBooth)
    {
        SetLogo(standBooth.GetLogo());
        SetName(standBooth.GetProductName());
        SetDescription(standBooth.GetProductDescription());
        SetLinks(standBooth.GetPresentationLink(), standBooth.GetDemoLink());

        brochureContainer.SetActive(true);
    }

    public void CloseBrochure()
    {
        brochureContainer.SetActive(false);
    }
}
