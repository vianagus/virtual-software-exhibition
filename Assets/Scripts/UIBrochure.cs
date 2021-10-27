using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBrochure : MonoBehaviour
{
    [Header("Container")]
    [SerializeField] GameObject brochureContainer;
    [SerializeField] GameObject identityContainer;
    [SerializeField] GameObject pitchContainer;
    [SerializeField] GameObject descriptionContainer;

    [Header("Identity")]
    [SerializeField] Image logo;
    [SerializeField] Text productName;

    [Header("Pitch & Description")]
    [SerializeField] Text pitch;
    [SerializeField] Text description;

    private void Start() 
    {
        CloseBrochure();
    }

    private void SetIdentity(Sprite logo, string productName)
    {
        this.productName.text = productName;
        if(logo == null) return;
        this.logo.sprite = logo;
    }

    private void SetPitch(string pitch)
    {
        this.pitch.text = pitch;
    }

    private void SetDescription(string description)
    {
        this.description.text = description;
    }

    public void OpenBrochure(StandBooth standBooth)
    {
        SetIdentity(standBooth.GetLogo(), standBooth.GetProductName());
        SetPitch(standBooth.GetProductPitch());
        SetDescription(standBooth.GetProductDescription());

        brochureContainer.SetActive(true);

        //StartCoroutine(ShowContent(1));
    }

    public void CloseBrochure()
    {
        //HideContent();
        brochureContainer.SetActive(false);
    }

    private IEnumerator ShowContent(float duration)
    {
        yield return new WaitForSeconds(duration);
        identityContainer.SetActive(true);
        yield return new WaitForSeconds(duration);
        pitchContainer.SetActive(true);
        yield return new WaitForSeconds(duration);
        descriptionContainer.SetActive(true);
    }

    private void HideContent()
    {
        identityContainer.SetActive(false);
        pitchContainer.SetActive(false);
        descriptionContainer.SetActive(false);
    }
}
