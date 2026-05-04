using UnityEngine;

public class coloritem : MonoBehaviour
{
    public string categoryID = "ColorLabio"; 
    public Color lipstickColor;
    public CosmeticData dataStorage;   
    public SpriteRenderer faceRenderer; 

    void OnMouseUp()
    {
        if (dataStorage != null)
        {
            // Cargamos lo que hay para no borrar otros cajones
            dataStorage.CargarDesdeDisco();

            var data = dataStorage.GetCosmetic(categoryID);
            Sprite currentSprite = (data != null) ? data.sprite : null;

            // Escribimos el color en el cajón
            dataStorage.SaveCosmetic(categoryID, currentSprite, lipstickColor);

            if (faceRenderer != null) faceRenderer.color = lipstickColor;

            #if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(dataStorage);
            UnityEditor.AssetDatabase.SaveAssets();
            #endif
        }
    }
}