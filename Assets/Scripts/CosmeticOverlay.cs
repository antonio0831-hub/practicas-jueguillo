using UnityEngine;

public class CosmeticOverlay : MonoBehaviour
{
    public Sprite cosmeticSprite;
    public SpriteRenderer overlayRenderer;


    private void OnMouseUp()
    {
        if (overlayRenderer == null || cosmeticSprite == null) return;

        overlayRenderer.sprite = cosmeticSprite;
        overlayRenderer.enabled = true;
    }
}