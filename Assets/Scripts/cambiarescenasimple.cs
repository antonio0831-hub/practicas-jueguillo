using UnityEngine;
using UnityEngine.SceneManagement;
public class cambiarescenasimple : MonoBehaviour
{
    public string Base;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void cambiarescena()
    {
        SceneManager.LoadScene(Base);
    }

    // Update is called once per frame
    public void Salir()
    {
Application.Quit();
    }
    private void OnMouseDown()
    {
        if (!string.IsNullOrEmpty(Base))
        {
            Debug.Log("Cambiando a la escena: " + Base);
            SceneManager.LoadScene(Base);
        }
        else
        {
            Debug.LogWarning("¡Atención! No has puesto el nombre de la escena en el Inspector.");
        }
    }
}
