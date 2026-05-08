using UnityEngine;
using TMPro;
public partial class MostrarPuntaje : MonoBehaviour
{
    public TextMeshProUGUI textoPuntaje;
    public GameObject TextoGanador;
    public GameObject TextoPerdedor;

    void Start()
    {
        // Verificamos que el GameManager exista para evitar errores
        if (GameManager.Instancia != null)
        {
            // Accedemos directamente a puntajeTotal del GameManager
            textoPuntaje.text = "Puntaje Final: " + GameManager.Instancia.puntajeTotal.ToString();
        }
        if(GameManager.Instancia.puntajeTotal >= 200)
        {
            TextoGanador.SetActive(true);
        }
        else
        {
            TextoPerdedor.SetActive(false);
        }
    }
}