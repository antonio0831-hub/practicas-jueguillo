using UnityEngine;

public class ApplyCustomization : MonoBehaviour
{
    public SpriteRenderer lipsRenderer;

    void Awake()
    {
        if (lipsRenderer == null)
            lipsRenderer = GetComponent<SpriteRenderer>(); // si el script está en el objeto Lips
    }

    void Start()
    {
        var data = CustomizationData.Instance;
        if (data == null || lipsRenderer == null) return;

        if (data.selectedLipShape != null)
            lipsRenderer.sprite = data.selectedLipShape;

        lipsRenderer.color = data.selectedLipColor;
    }
}