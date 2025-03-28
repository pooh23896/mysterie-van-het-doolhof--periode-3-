using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public RarityType rarityType;
    public Vector2Int range = new Vector2Int(0, 0);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;


}

public enum ItemType
{
   Food
}

public enum ActionType
{
    Eating
}

public enum RarityType
{
    Rarity
}