using UnityEngine;
using UnityEngine.SceneManagement;

public class EventoAsesinoGlobal : MonoBehaviour
{
    public static EventoAsesinoGlobal Instance;

    [Header("Configuración")]
    public float tiempoParaElSusto = 30f;
    public string escenaDelReto = "Cronometro";
    
    private float cronometro = 0f;
    private bool eventoActivado = false;
    public string escenaFinal;
    public string escenaPausa;

    void Awake()
    {
        // Al igual que el NavigationManager, evitamos que se destruya
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

    void Update()
    {
        if (SceneManager.GetActiveScene().name == escenaFinal) return;
        if(SceneManager.GetActiveScene().name == escenaPausa) return;
        // Solo cuenta si el evento no ha ocurrido todavía
        if (!eventoActivado)
        {
            cronometro += Time.deltaTime;

            if (cronometro >= tiempoParaElSusto)
            {
                ActivarEvento();
            }
        }
    }
void ActivarEvento()
    {
        eventoActivado = true;

        // --- NUEVA LÍNEA DE SEGURIDAD ---
        #if UNITY_EDITOR
        UnityEditor.AssetDatabase.SaveAssets(); // Fuerza a Unity a escribir los cambios en el archivo azul
        #endif
        // --------------------------------

        if (NavigationManager.Instance != null)
        {
            NavigationManager.Instance.LoadNewScene(escenaDelReto);
        }
        else
        {
            SceneManager.LoadScene(escenaDelReto);
        }
        ReiniciarEvento();
    }
    // Llama a esto desde el script de victoria para poder reiniciar el bucle si quieres
public void ReiniciarEvento()
{
    cronometro = 0f;
    eventoActivado = false;
    
    // Al reiniciar, buscamos todos los objetos con el script de carga y los obligamos a actualizarse
    ApplySavedCosmetic[] todosLosCosmeticos = FindObjectsByType<ApplySavedCosmetic>(FindObjectsSortMode.None);
}
}