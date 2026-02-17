using UnityEngine;
using UnityEngine.SceneManagement; // Esencial para cambiar de escena

public class ControladorPausaMarcos : MonoBehaviour
{
    public string nombreDeLaEscenaJuego = "MONTAJE"; // Escribe aquí el nombre exacto de tu escena de nivel

    public void CargarJuego()
    {
        // Reseteamos el tiempo por si acaso (si vienes de una pausa previa)
        Time.timeScale = 1f;
        
        // Carga la escena del juego
        SceneManager.LoadScene(nombreDeLaEscenaJuego);
    }

    public void SalirDelJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
}