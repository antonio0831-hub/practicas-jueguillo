using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class coloritem : MonoBehaviour
{
    [Header("Configuración de Color")]
    public string categoryID = "Lips"; // Identificador para saber qué estamos pintando
    public Color lipstickColor;
    public CosmeticData dataStorage;   
    public SpriteRenderer faceRenderer; 

    void OnMouseUp()
    {
        // 1. Compatibilidad con Singleton original
        if (CustomizationData.Instance != null)
        {
            CustomizationData.Instance.selectedLipColor = lipstickColor;
        }

        // 2. Nuevo sistema de categorías (sin posición ni escala)
        if (dataStorage != null)
        {
            // Buscamos lo que ya existe para mantener el Sprite actual al cambiar solo el color
            var data = dataStorage.GetCosmetic(categoryID);
            Sprite currentSprite = (data != null) ? data.sprite : null;

            // Guardamos: ID, Sprite actual y el Nuevo Color
            dataStorage.SaveCosmetic(categoryID, currentSprite, lipstickColor);

            if (faceRenderer != null)
            {
                faceRenderer.color = lipstickColor;
            }

            #if UNITY_EDITOR
            EditorUtility.SetDirty(dataStorage); 
            AssetDatabase.SaveAssets();         
            #endif

            Debug.Log($"Color de {categoryID} guardado: {lipstickColor}");
        }
    }
}