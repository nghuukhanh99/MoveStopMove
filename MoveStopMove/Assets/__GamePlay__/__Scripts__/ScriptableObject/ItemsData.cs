using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/ItemData")]
public class ItemsData : ScriptableObject
{
    public int ID; // pant: 1, head: 1001, shield: 2001, setSkin: 3001:, weapon: 4001

    public ItemType ItemType;

    public NameOfItem Name;

    public List<GameObject> Prefab = new List<GameObject>();

    public Material material;

    public List<Material> materialLis = new List<Material>();

    public Sprite Icon;

    public int Cost;

    public int Bought;
}
