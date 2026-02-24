using UnityEngine;

public class ResetLips : MonoBehaviour
{
    public SpriteRenderer lipsRenderer;

    void Start()
    {
        lipsRenderer.color = Color.white; // o el color base de la piel/labio
    }
}