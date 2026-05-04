using UnityEngine;
using System.Collections.Generic;

// Clase para definir cada pieza de maquillaje (importante para que Unity pueda guardarla)
[System.Serializable]
public class CosmeticSlot
{
    public string categoryID;
    public Sprite sprite;
    public Color color;
}

[CreateAssetMenu(fileName = "NewCosmeticData", menuName = "Cosmetic/Data")]
public class CosmeticData : ScriptableObject
{
    // Lista donde se guardan los datos en memoria durante el juego
    public List<CosmeticSlot> savedCosmetics = new List<CosmeticSlot>();

    /// <summary>
    /// Guarda un cosmético específico y lo sincroniza con el disco duro.
    /// </summary>
public void SaveCosmetic(string id, Sprite s, Color c)
{
    // 1. CARGA OBLIGATORIA: Antes de tocar nada, leemos lo que hay en el disco
    CargarDesdeDisco();

    // 2. BUSQUEDA: Buscamos si ya existe ese ID (ej: "ColorLabio")
    CosmeticSlot slot = savedCosmetics.Find(x => x.categoryID == id);
    
    if (slot == null)
    {
        slot = new CosmeticSlot { categoryID = id };
        savedCosmetics.Add(slot);
    }
    
    // 3. ASIGNACIÓN: Solo cambiamos el color y sprite del ID que toca
    slot.sprite = s;
    slot.color = c;

    // 4. GUARDADO FÍSICO: Lo escribimos en el disco duro
    GuardarEnDisco();
    Debug.Log("Guardado exitoso del ID: " + id);
}

    /// <summary>
    /// Busca un cosmético por su ID.
    /// </summary>
    public CosmeticSlot GetCosmetic(string id)
    {
        return savedCosmetics.Find(x => x.categoryID == id);
    }

    // --- MÉTODOS DE PERSISTENCIA (FUNDAMENTALES PARA LA BUILD) ---

    public void GuardarEnDisco()
    {
        // Convertimos este objeto a un texto JSON para guardarlo fuera del ScriptableObject
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString("BackupCosmeticos", json);
        PlayerPrefs.Save();
        Debug.Log("Maquillaje guardado en memoria persistente.");
    }

    public void CargarDesdeDisco()
    {
        // Si existe un guardado previo en el dispositivo, lo cargamos
        if (PlayerPrefs.HasKey("BackupCosmeticos"))
        {
            string json = PlayerPrefs.GetString("BackupCosmeticos");
            JsonUtility.FromJsonOverwrite(json, this);
        }
    }
}