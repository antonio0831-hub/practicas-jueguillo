using UnityEngine;

public class LipstickItem : MonoBehaviour
{
    public Color lipstickColor;

    void OnMouseUp()
    {
        CustomizationData.Instance.selectedLipColor = lipstickColor;
    }
}