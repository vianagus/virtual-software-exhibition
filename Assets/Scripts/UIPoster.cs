using UnityEngine;
using UnityEngine.UI;

public class UIPoster : MonoBehaviour
{
    [SerializeField] GameObject posterContainer;

    private void Awake()
    {
        posterContainer.SetActive(false);
    }

    public void OpenPoster(Sprite poster)
    {
        posterContainer.SetActive(true);
        GetComponentInChildren<Image>().sprite = poster;
    }

    public void ClosePoster()
    {
        posterContainer.SetActive(false);
    }
}
