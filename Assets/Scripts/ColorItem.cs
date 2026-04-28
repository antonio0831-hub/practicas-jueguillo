using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class coloritem : MonoBehaviour
{
    [Header("Configuración de Color")]
    public Color lipstickColor;
    public CosmeticData dataStorage;   // Referencia al archivo azul 'Elección Usuario'
    public SpriteRenderer faceRenderer; // El CosmeticLayer de la cara (opcional)

    void OnMouseUp()
    {
        // 1. Guardar en el Singleton (tu lógica original)
        if (CustomizationData.Instance != null)
        {
            CustomizationData.Instance.selectedLipColor = lipstickColor;
        }

        // 2. Guardar en el ScriptableObject (Lógica de CosmeticApplier)
        if (dataStorage != null)
        {
            dataStorage.selectedColor = lipstickColor; // Asegúrate de que este campo exista en CosmeticData

            // Aplicar visualmente si hay un faceRenderer asignado
            if (faceRenderer != null)
            {
                faceRenderer.color = lipstickColor;
            }

            // Guardado persistente en el Editor
            #if UNITY_EDITOR
            EditorUtility.SetDirty(dataStorage); 
            AssetDatabase.SaveAssets();         
            #endif

            Debug.Log("SISTEMA: Color guardado con éxito: " + lipstickColor);
        }
    }
}