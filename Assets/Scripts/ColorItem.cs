using UnityEngine;

public class coloritem : MonoBehaviour
{
    public Color lipstickColor;

    void OnMouseUp()
    {
        CustomizationData.Instance.selectedLipColor = lipstickColor;
    }
}