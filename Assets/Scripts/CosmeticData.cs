using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewCosmeticData", menuName = "Cosmeticos/Data")]
public class CosmeticData : ScriptableObject
{
    [System.Serializable]
    public class CosmeticSlot
    {
        public string categoryID; 
        public Sprite sprite;
        public Color color = Color.white;
    }

    public List<CosmeticSlot> savedCosmetics = new List<CosmeticSlot>();

    // Ahora solo guardamos ID, Sprite y Color
    public void SaveCosmetic(string id, Sprite s, Color c)
    {
        CosmeticSlot slot = savedCosmetics.Find(x => x.categoryID == id);
        if (slot == null)
        {
            slot = new CosmeticSlot { categoryID = id };
            savedCosmetics.Add(slot);
        }
        slot.sprite = s;
        slot.color = c;
    }

    public CosmeticSlot GetCosmetic(string id)
    {
        return savedCosmetics.Find(x => x.categoryID == id);
    }
}