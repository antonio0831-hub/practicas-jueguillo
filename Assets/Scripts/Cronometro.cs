using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Cronometro : MonoBehaviour
{
    [Header("Configuración")]
    public KeyCode teclaDelReto = KeyCode.E;
    public float tiempoMantenerNecesario = 3f;
    public float tiempoLimiteGlobal = 5f;

    [Header("Referencias UI")]
    public Slider barraProgreso;

    private float cronometroMantener = 0f;
    private float cronometroGlobal = 0f;
    private bool retoFinalizado = false;

    void Start()
    {
        if (barraProgreso != null) barraProgreso.value = 0;
        // Aquí no necesitas llamar a nada, el Update se encarga de empezar
    }

    void Update()
    {
        if (retoFinalizado) return;

        // El tiempo global empieza a correr en cuanto carga la escena
        cronometroGlobal += Time.deltaTime;

        // Lógica de presionar la tecla
        if (Input.GetKey(teclaDelReto))
        {
            cronometroMantener += Time.deltaTime;
        }
        else
        {
            // Si suelta la tecla, el progreso baja o se detiene (tú eliges)
            cronometroMantener = Mathf.Max(0, cronometroMantener - Time.deltaTime); 
        }

        // Actualizar la barra
        if (barraProgreso != null) 
            barraProgreso.value = cronometroMantener / tiempoMantenerNecesario;

        // VICTORIA: Si mantuvo el tiempo
        if (cronometroMantener >= tiempoMantenerNecesario)
        {
            FinalizarComoVictoria();
        }
        // DERROTA: Si se acabó el tiempo global
        else if (cronometroGlobal >= tiempoLimiteGlobal)
        {
            FinalizarComoPerdida();
        }
    }

    void FinalizarComoVictoria()
    {
        retoFinalizado = true;
        Debug.Log("¡Victoria lograda! Intentando volver...");
        // Carga la escena anterior (la Principal)
        NavigationManager.Instance.BackToPreviousScene();
    }

    void FinalizarComoPerdida()
    {
        retoFinalizado = true;
        SceneManager.LoadScene("GameOver");
    }
}