using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBrochure : MonoBehaviour
{
    [Header("Containers")]
    [SerializeField] GameObject brochureContainer;
    [SerializeField] GameObject linksContainer;

    [Header("Contents")]
    [SerializeField] Image productLogo;
    [SerializeField] Text productName;
    [SerializeField] Text description;

    [Header("Links")]
    [SerializeField] Button presentationLink;
    [SerializeField] Button demoLink;

    [Header("Team")]
    [SerializeField] Text teamName;
    [SerializeField] Text instanceTeamMember;
    [SerializeField] Transform memberListContainer;

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

    private void SetTeam(Text instanceTeamMember, StandBooth standBooth)
    {
        this.teamName.text = standBooth.GetTeamName();

        // destroy all members
        Text[] memberList = memberListContainer.GetComponentsInChildren<Text>();
        if(memberList.Length != 0)
        {
            foreach (var member in memberList)
            {
                Destroy(member.gameObject);
            }
        }

        // instance members
        foreach (var member in standBooth.GetTeamMembers())
        {
            Text instanceMember = Instantiate(instanceTeamMember);
            instanceMember.transform.parent = memberListContainer.transform;
            instanceMember.text = member.memberName + "\n" + member.memberInfo;
        }
    }

    public void OpenBrochure(StandBooth standBooth)
    {
        SetLogo(standBooth.GetLogo());
        SetName(standBooth.GetProductName());
        SetDescription(standBooth.GetProductDescription());
        SetTeam(instanceTeamMember, standBooth);
        SetLinks(standBooth.GetPresentationLink(), standBooth.GetDemoLink());

        brochureContainer.SetActive(true);
    }

    public void CloseBrochure()
    {
        brochureContainer.SetActive(false);
    }
}
