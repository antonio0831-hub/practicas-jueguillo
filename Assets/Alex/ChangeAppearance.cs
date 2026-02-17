using UnityEngine;

public class ChangeAppearance : MonoBehaviour
{
    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Algo entró");

        if (other.CompareTag("Makeup"))
        {
            Debug.Log("Es maquillaje!");

            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
