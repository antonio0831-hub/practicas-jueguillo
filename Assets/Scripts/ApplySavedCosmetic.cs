using UnityEngine;

public class ApplySavedCosmetic : MonoBehaviour
{
    public string categoryID; 
    public CosmeticData dataStorage;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (dataStorage == null || renderer == null) return;

        var data = dataStorage.GetCosmetic(categoryID);

        if (data != null)
        {
            // Solo aplicamos la imagen y el color
            if (data.sprite != null) renderer.sprite = data.sprite;
            renderer.color = data.color;
            
            renderer.enabled = true;
        }
    }
}