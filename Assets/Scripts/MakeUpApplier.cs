using UnityEngine;

public class MakeUpApplier : MonoBehaviour
{
    public SpriteRenderer lipsRenderer;

    void Start()
    {
        if (CustomizationData.Instance.selectedLipShape != null)
            lipsRenderer.sprite = CustomizationData.Instance.selectedLipShape;

        lipsRenderer.color = CustomizationData.Instance.selectedLipColor;
    }
}