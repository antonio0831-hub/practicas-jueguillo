using UnityEngine;

public class ChangeAppearance : MonoBehaviour
{
    public Sprite newSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Makeup"))
        {
            GetComponent<SpriteRenderer>().sprite = newSprite;
        }
    }
}
