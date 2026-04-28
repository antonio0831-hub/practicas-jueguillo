using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class CosmeticApplier : MonoBehaviour
{
    public string categoryID; // Escribir "Base", "Lips", etc.
    public Sprite cosmeticSprite;
    public CosmeticData dataStorage;
    public SpriteRenderer faceRenderer;

    private Vector3 startPos;
    private bool isDragging;

    void Start() => startPos = transform.position;
    void OnMouseDown() => isDragging = true;

    void OnMouseUp()
    {
        isDragging = false;
        transform.position = startPos;

        if (faceRenderer != null && dataStorage != null)
        {
            faceRenderer.sprite = cosmeticSprite;
            
            // Guardamos solo ID, Sprite y Color (Blanco por defecto al elegir forma)
            dataStorage.SaveCosmetic(categoryID, cosmeticSprite, Color.white);

            #if UNITY_EDITOR
            EditorUtility.SetDirty(dataStorage);
            AssetDatabase.SaveAssets();
            #endif
        }
    }

    void Update()
    {
        if (isDragging)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }
}