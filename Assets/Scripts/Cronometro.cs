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

    // Se ejecuta cada vez que el objeto se activa (útil si reciclas el objeto)

    void Update()
    {
        if (retoFinalizado) return;

        cronometroGlobal += Time.deltaTime;

        if (Input.GetKey(teclaDelReto))
        {
            cronometroMantener += Time.deltaTime;
        }
        else
        {
            cronometroMantener = Mathf.Max(0, cronometroMantener - Time.deltaTime); 
        }

        if (barraProgreso != null) 
            barraProgreso.value = cronometroMantener / tiempoMantenerNecesario;

        if (cronometroMantener >= tiempoMantenerNecesario)
        {
            FinalizarComoVictoria();
        }
        else if (cronometroGlobal >= tiempoLimiteGlobal)
        {
            FinalizarComoPerdida();
        }
    }

    void FinalizarComoVictoria()
    {
        retoFinalizado = true;
        Debug.Log("¡Victoria!");
        
        if (NavigationManager.Instance != null)
            NavigationManager.Instance.BackToPreviousScene();
    }

    void FinalizarComoPerdida()
    {
        retoFinalizado = true;
        SceneManager.LoadScene("GameOver");
    }
}