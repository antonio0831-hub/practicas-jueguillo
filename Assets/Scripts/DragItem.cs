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

        // --- INICIO DEL CÓDIGO AÑADIDO ---
        // Comprobamos qué colliders 2D hay justo en la posición actual antes de volver al sitio
        Collider2D[] colliders = Physics2D.OverlapPointAll(transform.position);

        foreach (Collider2D col in colliders)
        {
            // Si detecta un collider que NO es este mismo objeto (asumimos que es la cara)
            if (col.gameObject != this.gameObject)
            {
                // Buscamos el script MakeupItem en este mismo objeto
                MakeupItem makeup = GetComponent<MakeupItem>();
                if (makeup != null)
                {
                    // Mandamos los puntos al GameManager
                    GameManager.Instancia.SumarPuntos(makeup.puntosQueDa);
                }
                break; // Rompemos el bucle para no sumar puntos varias veces si hay varios colliders superpuestos
            }
        }
        // --- FIN DEL CÓDIGO AÑADIDO ---

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