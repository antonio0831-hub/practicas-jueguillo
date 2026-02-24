using UnityEngine;

public class ChangeAppearance : MonoBehaviour
{
    public int puntos = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        MakeupItem item = other.GetComponent<MakeupItem>();

        if (item != null && !item.usado)
        {
            GetComponent<SpriteRenderer>().sprite = item.aparienciaQueDa;
            puntos += item.puntosQueDa;

            item.usado = true;
        }
    }
}