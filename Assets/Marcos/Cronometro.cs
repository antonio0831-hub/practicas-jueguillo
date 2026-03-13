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

    void Start()
    {
        textoVictoria.SetActive(false);
        textoPerdida.SetActive(false);
        if (barraProgreso != null) barraProgreso.value = 0;
    }

    void Update()
    {
        // Si ya ganó o ya perdió, no hacemos nada más
        if (retoFinalizado) return;

        // 1. El tiempo global corre SOLO desde el segundo 1
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
            // Si suelta, la barra vuelve a 0 pero el tiempo global sigue volando
            cronometroMantener = 0f;
            if (barraProgreso != null) barraProgreso.value = 0;
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
        textoPerdida.SetActive(true); // Aquí "salta" el texto solo al pasar los 5s
        textoVictoria.SetActive(false);
        if (barraProgreso != null) barraProgreso.value = 0;
        Debug.Log("¡Se acabó el tiempo! Perdiste.");
    }
}