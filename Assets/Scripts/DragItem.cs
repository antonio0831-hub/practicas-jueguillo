using UnityEngine;

public class DragItem : MonoBehaviour
{
    private Vector3 offset;
    private bool dragging;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        dragging = true;
    }

    void OnMouseUp()
    {
        dragging = false;
        // vuelva a su sitio SIEMPRE (así no se queda por ahí)
        transform.position = startPos;
    }

    void Update()
    {
        if (dragging)
            transform.position = GetMouseWorldPos() + offset;
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = 10f;
        return Camera.main.ScreenToWorldPoint(mouse);
    }
}