using UnityEngine;

[CreateAssetMenu(fileName = "NewCosmeticData", menuName = "Cosmeticos/Data")]
public class CosmeticData : ScriptableObject
{
    public Sprite selectedBase;      // Para la base/máscara
    public Sprite selectedLipShape;  // Para los labios
    public Color selectedColor;      // Para el color

    // Mantén esta si la usas en otros scripts, pero organiza las nuevas
    public Sprite selectedSprite; 
    // NUEVAS VARIABLES PARA LA POSICIÓN Y ESCALA
    public Vector3 lipPosition;
    public Vector3 lipScale;
}