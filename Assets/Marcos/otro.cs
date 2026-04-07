using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RetoBotonPro : MonoBehaviour
{
    [Header("Configuración")]
    public KeyCode teclaDelReto = KeyCode.E;
    public float tiempoMantenerNecesario = 3f;
    public float tiempoLimiteGlobal = 5f;

    [Header("Referencias UI")]
    public GameObject textoVictoria;
    public GameObject textoPerdida;
    public Slider barraProgreso;

    private float cronometroMantener = 0f;
    private float cronometroGlobal = 0f;
    private bool retoFinalizado = false;
    private bool retoIniciado = false; // Nueva variable para controlar el inicio

    void Start()
    {
        textoVictoria.SetActive(false);
        textoPerdida.SetActive(false);
        if (barraProgreso != null) barraProgreso.value = 0;
    }

    void Update()
    {
        if (retoFinalizado) return;

        // --- LÓGICA DE INICIO ---
        // El tiempo global solo empieza a correr si el jugador presiona la tecla una vez
        if (!retoIniciado && Input.GetKeyDown(teclaDelReto))
        {
            retoIniciado = true;
            Debug.Log("¡El tiempo ha comenzado a correr!");
        }

        if (retoIniciado)
        {
            // 1. El tiempo global corre solo si ya se inició el reto
            cronometroGlobal += Time.deltaTime;

            // 2. Comprobar si se acabó el tiempo global
            if (cronometroGlobal >= tiempoLimiteGlobal)
            {
                FinalizarComoPerdida();
                return;
            }

            // 3. Lógica de mantener la tecla
            if (Input.GetKey(teclaDelReto))
            {
                cronometroMantener += Time.deltaTime;
                
                if (barraProgreso != null) 
                    barraProgreso.value = cronometroMantener / tiempoMantenerNecesario;

                if (cronometroMantener >= tiempoMantenerNecesario)
                {
                    FinalizarComoVictoria();
                }
            }
            else
            {
                // Si suelta, el progreso de "mantener" se reinicia, 
                // pero el tiempo global sigue corriendo.
                cronometroMantener = 0f;
                if (barraProgreso != null) barraProgreso.value = 0;
            }
        }
    }

    void FinalizarComoVictoria()
    {
        retoFinalizado = true;
        textoVictoria.SetActive(true);
        textoPerdida.SetActive(false);
        if (barraProgreso != null) barraProgreso.gameObject.SetActive(false);
        Debug.Log("¡Ganaste a tiempo!");
    }

    void FinalizarComoPerdida()
    {
        retoFinalizado = true;
        textoPerdida.SetActive(true);
        textoVictoria.SetActive(false);
        if (barraProgreso != null) barraProgreso.value = 0;
        Debug.Log("¡Se acabó el tiempo! Perdiste.");
    }
}