using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] string nombreEscena;

    public void OnMouseDown()
    {
        SceneManager.LoadScene(nombreEscena);
    }
    public void SalirDelJuego()
    {
        Application.Quit();
        Debug.Log("Saliendo del Juego");
    }
}
