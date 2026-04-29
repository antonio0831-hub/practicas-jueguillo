using UnityEngine;
using UnityEngine.SceneManagement;

public class Pausa : MonoBehaviour
{
    // MOVIDO: Las variables ahora están DENTRO de la clase
    public KeyCode Tecla = KeyCode.Escape;
    public string escena;
    public string escena2;

void Update()
    {
        if (Input.GetKeyDown(Tecla))
        {
            if (!string.IsNullOrEmpty(escena))
            {
                // CAMBIO: En lugar de SceneManager, usamos tu NavigationManager
                if (NavigationManager.Instance != null)
                {
                    NavigationManager.Instance.LoadNewScene(escena);
                }
                else
                {
                    SceneManager.LoadScene(escena);
                }
            }
        }
    }

    public void continuarAljuego()
    {
        // Mantiene tu lógica de navegación original
        if (NavigationManager.Instance != null)
        {
            NavigationManager.Instance.BackToPreviousScene();
        }
    }
    public void salirdeljuego()
    {
        SceneManager.LoadScene(escena2);
    }
}