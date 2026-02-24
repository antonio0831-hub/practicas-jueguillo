using UnityEngine;

public class LipColorTarget : MonoBehaviour
{
    public SpriteRenderer lipsRenderer;

    private void Awake()
    {
        if (lipsRenderer == null)
            lipsRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // aplica el color guardado al entrar en escena 2
        if (CustomizationData.Instance != null)
            lipsRenderer.color = CustomizationData.Instance.selectedLipColor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Lipstick")) return;

        var item = other.GetComponent<LipstickItem>();
        if (item == null) return;

        // 1) aplica color visual YA
        lipsRenderer.color = item.lipstickColor;

        // 2) guarda para escenas siguientes
        if (CustomizationData.Instance != null)
            CustomizationData.Instance.selectedLipColor = item.lipstickColor;
    }
}