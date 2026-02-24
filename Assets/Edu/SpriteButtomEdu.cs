using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriteButtonEdu : MonoBehaviour
{
    [SerializeField] string nombreEscena;

    void OnMouseDown()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
