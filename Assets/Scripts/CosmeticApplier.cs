using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class CosmeticApplier : MonoBehaviour
{
    [Header("Configuración del Cosmético")]
    public Sprite cosmeticSprite;      // La imagen de esta máscara
    public CosmeticData dataStorage;   // Tu archivo azul 'Elección Usuario'
    public SpriteRenderer faceRenderer; // El CosmeticLayer de la cara

    private Vector3 startPos;
    private bool isDragging;

    void Start() => startPos = transform.position;

    void OnMouseDown() => isDragging = true;

    void OnMouseUp()
    {
        isDragging = false;
        transform.position = startPos;

        if (faceRenderer != null && dataStorage != null && cosmeticSprite != null)
        {
            faceRenderer.sprite = cosmeticSprite;
            faceRenderer.enabled = true;

         
            dataStorage.selectedSprite = cosmeticSprite;

          
            #if UNITY_EDITOR
            EditorUtility.SetDirty(dataStorage); 
            AssetDatabase.SaveAssets();         
            #endif
            

            Debug.Log("SISTEMA: Guardado con éxito: " + cosmeticSprite.name);
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