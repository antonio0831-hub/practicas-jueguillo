using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class LipColorTarget : MonoBehaviour
{
    public SpriteRenderer lipsRenderer;
    public CosmeticData dataStorage; // Referencia al archivo azul 'Elección Usuario'

    private void Awake()
    {
        if (lipsRenderer == null)
            lipsRenderer = GetComponent<SpriteRenderer>();
    }

private void Start()
{
    if (dataStorage != null)
    {
        // 1. Cargar la forma (Sprite)
        if (dataStorage.selectedLipShape != null)
            lipsRenderer.sprite = dataStorage.selectedLipShape;

        // 2. Cargar el Color
        lipsRenderer.color = dataStorage.selectedColor;

        // 3. CARGAR POSICIÓN Y ESCALA (Esto corrige el problema)
        lipsRenderer.transform.localPosition = dataStorage.lipPosition;
        lipsRenderer.transform.localScale = dataStorage.lipScale;
    }
    else if (CustomizationData.Instance != null)
    {
        lipsRenderer.color = CustomizationData.Instance.selectedLipColor;
    }
}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Lipstick")) return;

        var item = other.GetComponent<coloritem>();
        if (item == null) return;

        // APLICAR COLOR VISUAL
        lipsRenderer.color = item.lipstickColor;

        // GUARDAR EN SINGLETON (Para cambio entre escenas rápido)
        if (CustomizationData.Instance != null)
            CustomizationData.Instance.selectedLipColor = item.lipstickColor;

        // GUARDAR EN COSMETIC DATA (Persistencia en disco)
        if (dataStorage != null)
        {
            dataStorage.selectedColor = item.lipstickColor;

            #if UNITY_EDITOR
            EditorUtility.SetDirty(dataStorage);
            AssetDatabase.SaveAssets();
            #endif
            
            Debug.Log("SISTEMA: Color de labios guardado en CosmeticData: " + item.lipstickColor);
        }
    }
}