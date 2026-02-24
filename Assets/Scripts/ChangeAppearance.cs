using UnityEngine;

public class ChangeAppearance : MonoBehaviour
{
    public SpriteRenderer lipsRenderer;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lip"))
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                lipsRenderer.sprite = sr.sprite;

                // Guardamos selección
                CustomizationData.Instance.selectedLipShape = sr.sprite;
            }
        }
    }
}

