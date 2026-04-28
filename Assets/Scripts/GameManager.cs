using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public int puntajeTotal = 0;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int puntos)
    {
        puntajeTotal += puntos;
        Debug.Log("Puntos totales: " + puntajeTotal);
    }
}