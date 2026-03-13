using UnityEngine;

public class SpriteItem : MonoBehaviour
{
    [Header("Sprite que quieres colocar")]
    public Sprite spriteToApply;

    [Header("Dónde se mostrará")]
    public SpriteRenderer targetRenderer;

    [Header("Posición opcional donde mover el renderer")]
    public Transform targetPoint;
    void Start()
    {
    targetRenderer.enabled = true;
    targetRenderer.color = Color.white;
    }
    private void OnMouseUp()
    {
        if (targetRenderer == null || spriteToApply == null)
            return;

        // Cambia el sprite
        targetRenderer.sprite = spriteToApply;
        targetRenderer.enabled = true;

        // Si quieres colocar ese sprite en una posición exacta
        if (targetPoint != null)
        {
            targetRenderer.transform.position = targetPoint.position;
        }
    }
}