using UnityEngine;

public class MakeupItem : MonoBehaviour
{
    public int puntosQueDa = 10;
    private void OnMouseDown()
    {
        GameManager.Instancia.SumarPuntos(puntosQueDa);

        Debug.Log("¡Maquillaje recogido con un clic!");

        Destroy(gameObject);
    }
}