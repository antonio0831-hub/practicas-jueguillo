using UnityEngine;



public class DragItem : MonoBehaviour
{
    private bool dragging;
    private Vector3 offset;

    void OnMouseDown()
    {
        Vector3 mousePos = GetMouseWorldPosition();
        offset = transform.position - mousePos;
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (dragging)
        {
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z; // ← CLAVE
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}