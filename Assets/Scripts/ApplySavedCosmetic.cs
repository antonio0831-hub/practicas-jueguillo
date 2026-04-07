using UnityEngine;

public class ApplySavedCosmetic : MonoBehaviour
{
    public CosmeticData dataStorage;

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();

        if (dataStorage != null && dataStorage.selectedSprite != null)
        {
            renderer.sprite = dataStorage.selectedSprite;
            renderer.enabled = true;

        }
        else
        {
            Debug.LogWarning("AVISO: No se encontró imagen en el archivo azul.");
        }
    }
}