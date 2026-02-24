using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteButton : MonoBehaviour
{
    [SerializeField] string nombreEscena;

    void OnMouseDown()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
