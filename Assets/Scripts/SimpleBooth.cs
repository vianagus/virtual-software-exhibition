using UnityEngine;

[ExecuteInEditMode]
public class SimpleBooth : MonoBehaviour
{
    [SerializeField] Sprite poster;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.drawMode = SpriteDrawMode.Sliced;
        spriteRenderer.size = new Vector2(0.8411f, 1.189f); // A0 paper size
        spriteRenderer.sprite = poster;
    }
}
