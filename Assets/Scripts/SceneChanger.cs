using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nombreSiguienteEscena;

    [Header("Configuración del Guardado")]
    public SpriteRenderer overlayRenderer; 
    public CosmeticData dataStorage;        

    public void IrASiguienteEscena()
    {
   
        if (overlayRenderer != null && dataStorage != null)
        {
            dataStorage.selectedSprite = overlayRenderer.sprite;
            Debug.Log("Guardado automático al continuar: " + (overlayRenderer.sprite != null ? overlayRenderer.sprite.name : "Ninguno"));
        }

   
        SceneManager.LoadScene(nombreSiguienteEscena);
    }
}