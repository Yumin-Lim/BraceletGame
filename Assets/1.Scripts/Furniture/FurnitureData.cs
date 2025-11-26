using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FurnitureData", menuName = "FurnitureData")]
public class FurnitureData : ScriptableObject
{


    public string key;
    public string furnitureName;
    public FurnitureArrange arrange;

    public FurnitureType type;

    public int price;
    public int stampPrice; //스탬프로 사는 가구일때의 가격
    public Sprite sprite;

    public int order; //쇼핑몰에서 보여지는 순서

    public Furniture prefab;
}

public enum FurnitureArrange
{
    Wall,
    Floor,
    Wallpaper, //벽지
    Flooring, //바닥 마루

}
public enum FurnitureType
{
    Normal, //돈으로 사는 가구 
    Stamp //스탬프로 사는 가구
}