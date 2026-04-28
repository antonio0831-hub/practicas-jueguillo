using UnityEngine;
using TMPro; // Necesario para usar TextMeshPro

public partial class MostrarPuntaje : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;

    void Start()
    {
        // Verificamos que el GameManager exista para evitar errores
        if (GameManager.Instancia != null)
        {
            // Accedemos directamente a puntajeTotal del GameManager
            textoPuntaje.text = "Puntaje Final: " + GameManager.Instancia.puntajeTotal.ToString();
        }
    }
}