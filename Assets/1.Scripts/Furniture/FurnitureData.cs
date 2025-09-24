using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnitureData", menuName = "FurnitureData")]
public class FurnitureData : ScriptableObject
{


    public string key;
    public string furnitureName;
    public FurnitureArrange arrange;
    public int price;
    public Sprite sprite;

    public Furniture prefab;
}

public enum FurnitureArrange
{
    Wall,
    Floor,
}