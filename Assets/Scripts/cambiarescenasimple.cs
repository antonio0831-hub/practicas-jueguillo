using UnityEngine;
using UnityEngine.SceneManagement;
public class cambiarescenasimple : MonoBehaviour
{
    public string Escena;
    public string Escena2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void cambiarescena()
    {
        SceneManager.LoadScene(Escena);
    }

    // Update is called once per frame
    public void Salir()
    {
Application.Quit();
    }
    private void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(Escena))
        {
            Debug.Log("Cambiando a la escena: " +   Escena);
            SceneManager.LoadScene(Escena);
        }
        else
        {
            Debug.LogWarning("¡Atención! No has puesto el nombre de la escena en el Inspector.");
        }
    }
    public void escenanterior()
    {
           if (NavigationManager.Instance != null)
                {
                    NavigationManager.Instance.LoadNewScene(Escena2);
                }
                else
                {
                    SceneManager.LoadScene(Escena2);
                }
    }
}
