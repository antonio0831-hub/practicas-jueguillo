using UnityEngine;

public class DragItem : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging = false;

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPosition();
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
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 10f;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
