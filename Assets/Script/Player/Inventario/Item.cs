using UnityEngine;

public enum itemTag { vazeio, cabeca_Equip, peito_Equip, pernas_Equip, pe_Equip, consumiveis}

[CreateAssetMenu(menuName ="RPG-2D/Item")]
public class Item : ScriptableObject
{
    public itemTag tag;
    public string nome;
    public GameObject prefabDoItem;
}
