using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationManager : MonoBehaviour
{
    public static NavigationManager Instance;
    private string lastSceneName;

    void Awake()
    {
        // Patrón Singleton: evita que el objeto se borre al cargar escenas
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para cambiar de escena guardando la actual como "anterior"
    public void LoadNewScene(string sceneName)
    {
        lastSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

    // Método para volver a la escena guardada
    public void BackToPreviousScene()
    {
        if (!string.IsNullOrEmpty(lastSceneName))
        {
            SceneManager.LoadScene(lastSceneName);
        }
        else
        {
            Debug.LogWarning("No hay una escena previa registrada.");
        }
    }
}