using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(StandBooth))]
public class SimpleBooth : MonoBehaviour
{
    private StandBooth standBooth;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        standBooth = GetComponent<StandBooth>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = new Vector2(0.8411f, 1.189f); // A0 paper size
        spriteRenderer.sprite = standBooth.GetPoster();
    }
}
