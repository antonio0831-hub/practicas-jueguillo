using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RetoBotonPro : MonoBehaviour
{
    [Header("Configuración")]
    public KeyCode teclaDelReto = KeyCode.E;
    public float tiempoMantenerNecesario = 3f;
    public float tiempoLimiteGlobal = 5f;
    public float cambiodeEscena = 20f;

    [Header("Referencias UI")]
    public Slider barraProgreso;

    private float cronometroMantener = 0f;
    private float cronometroGlobal = 0f;
    private bool retoFinalizado = false;

    void Start()
    {
        cambiodeEscena = 0f;
        if (barraProgreso != null) barraProgreso.value = 0;
    }

    void Update()
    {
        if(cambiodeEscena >= 20f)
        {
            CargadeEscena();
        }

        // 3. Lógica de mantener la tecla
    }

    void FinalizarComoVictoria()
    {
        retoFinalizado = true;
        NavigationManager.Instance.BackToPreviousScene();
         if (barraProgreso != null) barraProgreso.gameObject.SetActive(false);
    }

    void FinalizarComoPerdida()
    {
        retoFinalizado = true;
        SceneManager.LoadScene("GameOver");
        if (barraProgreso != null) barraProgreso.gameObject.SetActive(false);
    }
    void CargadeEscena()
    {
        SceneManager.LoadScene("Cronometro");
        Cronometro();
    }
    void Cronometro()
    {
        cronometroGlobal += Time.deltaTime;
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
     if (cronometroGlobal >= tiempoLimiteGlobal)
        {
            FinalizarComoPerdida();
            return;
       
    }
}
}