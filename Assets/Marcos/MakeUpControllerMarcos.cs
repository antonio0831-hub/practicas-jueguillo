using UnityEngine;
using UnityEngine.UI; // Necesario para detectar componentes Image

public class MakeupControllerMarcos : MonoBehaviour
{
    [Header("Capas de la Cara (Arrastra las imágenes aquí)")]
    public Image capaLabios;
    public Image capaSombraOjos;
    public Image capaRubor;

    // --- FUNCIONES PARA COLORES (Labios, Rubor, etc.) ---

    public void CambiarColorLabios(Color nuevoColor)
    {
        if (capaLabios != null)
        {
            capaLabios.color = nuevoColor;
            // Aseguramos que sea visible (opacidad al máximo si quieres)
            capaLabios.gameObject.SetActive(true);
        }
    }

    public void CambiarColorRubor(Color nuevoColor)
    {
        if (capaRubor != null)
        {
            capaRubor.color = nuevoColor;
            capaRubor.gameObject.SetActive(true);
        }
    }

    // --- FUNCIONES PARA ESTILOS (Cambiar el dibujo/forma) ---

    public void CambiarEstiloSombra(Sprite nuevoDibujo)
    {
        if (capaSombraOjos != null)
        {
            capaSombraOjos.sprite = nuevoDibujo;
            capaSombraOjos.gameObject.SetActive(true);
        }
    }

    // --- FUNCIÓN PARA LIMPIAR TODO ---
    public void ResetearMaquillaje()
    {
        // Esto vuelve el color a blanco (neutral) o apaga las capas
        capaLabios.gameObject.SetActive(false);
        capaSombraOjos.gameObject.SetActive(false);
        capaRubor.gameObject.SetActive(false);
    }
}