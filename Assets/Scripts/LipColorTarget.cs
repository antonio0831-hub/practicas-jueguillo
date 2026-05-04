using UnityEngine;

public class LipColorTarget : MonoBehaviour
{
    public string categoryID = "ColorLabio"; 
    public SpriteRenderer lipsRenderer;
    public CosmeticData dataStorage; 

    private void Awake()
    {
        if (lipsRenderer == null)
            lipsRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        // 1. Forzamos la carga desde el disco inmediatamente
        if (dataStorage != null)
        {
            dataStorage.CargarDesdeDisco();
            
            var data = dataStorage.GetCosmetic(categoryID);
            if (data != null)
            {
                // Solo si encontramos datos en el "cajón" ColorLabio, los aplicamos
                if (data.sprite != null) lipsRenderer.sprite = data.sprite;
                lipsRenderer.color = data.color;
                Debug.Log($"Labios cargados correctamente con color: {data.color}");
            }
        }
        // HEMOS BORRADO EL "ELSE IF" DEL SINGLETON. 
        // Ahora el script no tiene otra forma de ponerse color que no sea el archivo azul.
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Seguridad: Solo si el objeto que toca los labios es el pintalabios (Tag Lipstick)
        if (!other.CompareTag("Lipstick")) return;

        var item = other.GetComponent<coloritem>();
        if (item == null) return;

        // Actualizamos visualmente y guardamos
        lipsRenderer.color = item.lipstickColor;

        if (dataStorage != null)
        {
            dataStorage.CargarDesdeDisco();
            dataStorage.SaveCosmetic(categoryID, lipsRenderer.sprite, item.lipstickColor);
        }
    }
}