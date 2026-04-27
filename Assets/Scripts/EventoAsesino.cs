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
        Debug.Log("¡El tiempo global se ha agotado! Iniciando reto...");
        
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
    }
}