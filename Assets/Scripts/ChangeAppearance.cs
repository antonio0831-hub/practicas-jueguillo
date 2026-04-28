using UnityEngine;
#if UNITY_EDITOR
using UnityEditor; 
#endif

public class ChangeAppearance : MonoBehaviour
{
    public SpriteRenderer lipsRenderer; // El "labio" del personaje
    public CosmeticData dataStorage;    // Tu archivo de guardado

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lip"))
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                // 1. Cambio visual inmediato
                lipsRenderer.sprite = sr.sprite;

                // 2. Guardar en el archivo de datos (ScriptableObject)
// Dentro de OnTriggerEnter2D en ChangeAppearance.cs
if (dataStorage != null)
{
    dataStorage.selectedLipShape = sr.sprite; // CAMBIO: Guarda en el cajón de labios
    dataStorage.lipPosition = lipsRenderer.transform.localPosition; //
    dataStorage.lipScale = lipsRenderer.transform.localScale; //
    // ... resto del código de guardado editor ...
}

                // 3. Guardar en el Singleton (opcional, según tu lógica)
                if (CustomizationData.Instance != null)
                {
                    CustomizationData.Instance.selectedLipShape = sr.sprite;
                }
                
                Debug.Log("SISTEMA: Labios actualizados y guardados.");
            }
        }
    }
}