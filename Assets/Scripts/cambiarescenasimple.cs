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
}
