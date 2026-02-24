using UnityEngine;

public class CustomizationData : MonoBehaviour
{
    public static CustomizationData Instance;

    public Sprite selectedLipShape;
    public Color selectedLipColor = Color.white;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}