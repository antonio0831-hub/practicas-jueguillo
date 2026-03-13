using UnityEngine;

public class TestSpriteApply : MonoBehaviour
{
    public SpriteRenderer targetRenderer;
    public Sprite spriteToApply;

    private void OnMouseUp()
    {
        if (targetRenderer == null)
        {
            Debug.Log("Falta targetRenderer");
            return;
        }

        if (spriteToApply == null)
        {
            Debug.Log("Falta spriteToApply");
            return;
        }

        targetRenderer.sprite = spriteToApply;
        targetRenderer.color = Color.white;
        targetRenderer.enabled = true;

        Debug.Log("Sprite aplicado a: " + targetRenderer.gameObject.name);
    }
}