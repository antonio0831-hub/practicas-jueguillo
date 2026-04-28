using UnityEngine;

[CreateAssetMenu(fileName = "NewCosmeticData", menuName = "Cosmeticos/Data")]
public class CosmeticData : ScriptableObject
{
    public Sprite selectedSprite;
    public Color selectedColor;
    public Sprite selectedLipShape;
    
    // NUEVAS VARIABLES PARA LA POSICIÓN Y ESCALA
    public Vector3 lipPosition;
    public Vector3 lipScale;
}