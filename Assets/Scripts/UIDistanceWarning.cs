using System.Collections;
using UnityEngine;

public class UIDistanceWarning : MonoBehaviour
{
    [SerializeField] GameObject warning;

    private void Start() 
    {
        warning.SetActive(false);
    }

    public void Active(float duration)
    {
        StartCoroutine(ActiveWarning(duration));
    }

    private IEnumerator ActiveWarning(float duration)
    {
        warning.SetActive(true);
        yield return new WaitForSeconds(duration);
        warning.SetActive(false);
    }
}
