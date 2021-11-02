using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBrochure : MonoBehaviour
{
    [Header("Initialize Container")]
    [SerializeField] GameObject brochureContainer;
    [SerializeField] GameObject linksContainer;

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
        // hide links part when all link is empty
        if(presentationLink.Equals("") && demoLink.Equals(""))
        {
            linksContainer.SetActive(false);
        }

        // show/hide presentation link
        if(!presentationLink.Equals(""))
        {
            linksContainer.SetActive(true);
            this.presentationLink.GetComponent<ButtonOpenLink>().SetURL(presentationLink);
            this.presentationLink.gameObject.SetActive(true);
        }
        else
        {
            this.presentationLink.gameObject.SetActive(false);
        }

        // shiw/hide demo link
        if(!demoLink.Equals(""))
        {
            linksContainer.SetActive(true);
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
