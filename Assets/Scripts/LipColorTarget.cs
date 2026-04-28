using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class LipColorTarget : MonoBehaviour
{
    public string categoryID = "Lips"; 
    public SpriteRenderer lipsRenderer;
    public CosmeticData dataStorage; 

    private void Awake()
    {
        if (lipsRenderer == null)
            lipsRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (dataStorage != null)
        {
            // Cargamos por categoría
            var data = dataStorage.GetCosmetic(categoryID);
            if (data != null)
            {
                if (data.sprite != null) lipsRenderer.sprite = data.sprite;
                lipsRenderer.color = data.color;
                // NOTA: Ya no tocamos el transform.localPosition ni scale aquí
            }
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

        lipsRenderer.color = item.lipstickColor;

        if (dataStorage != null)
        {
            // Al pintar, mantenemos el sprite que ya tiene puesto el renderer
            dataStorage.SaveCosmetic(categoryID, lipsRenderer.sprite, item.lipstickColor);

            #if UNITY_EDITOR
            EditorUtility.SetDirty(dataStorage);
            AssetDatabase.SaveAssets();
            #endif
            
            Debug.Log($"Color de {categoryID} actualizado en el almacén.");
        }
    }
}