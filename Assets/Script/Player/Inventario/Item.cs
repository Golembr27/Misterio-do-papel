using UnityEngine;

public enum itemTag  { vazeio, cabeca_Equip, peito_Equip, pernas_Equip, pe_Equip, consumiveis}

[CreateAssetMenu(menuName ="RPG-2D/Item")]
public class Item : ScriptableObject
{
    [Header("Identificação")]
    public string ID; // ID único
    [Header("Categoria")]
    public itemTag tagCA;
    [Header("Especialidade")]
    public itemTag tagES;
    
}
