using UnityEngine;

public class ApplySavedCosmetic : MonoBehaviour
{
    public string categoryID; 
    public CosmeticData dataStorage;

    void OnEnable() 
    {
        ActualizarImagen();
    }

    public void ActualizarImagen()
    {
        if (dataStorage == null) return;

        // CRÍTICO: Lee los datos del disco antes de buscar el ID
        dataStorage.CargarDesdeDisco(); 

        var data = dataStorage.GetCosmetic(categoryID);

        if (data != null && data.sprite != null)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.sprite = data.sprite;
                renderer.color = data.color;
                renderer.enabled = true;
                Debug.Log($"Cargado con éxito desde disco: {categoryID}");
            }
        }
    }
}