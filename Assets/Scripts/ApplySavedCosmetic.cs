using UnityEngine;

public class ApplySavedCosmetic : MonoBehaviour
{
    public CosmeticData dataStorage;
    public bool esLabio; // Marca esta casilla en el Inspector solo para el objeto de los labios

    void Start()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (dataStorage == null || renderer == null) return;

        if (esLabio)
        {
            // CARGA DATOS DE LABIOS
            if (dataStorage.selectedLipShape != null)
            {
                renderer.sprite = dataStorage.selectedLipShape;
                renderer.color = dataStorage.selectedColor;
                transform.localPosition = dataStorage.lipPosition;
                transform.localScale = dataStorage.lipScale;
            }
        }
        else
        {
            // CARGA DATOS DE BASE
            if (dataStorage.selectedBase != null)
            {
                renderer.sprite = dataStorage.selectedBase;
            }
        }
    }
}