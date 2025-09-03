using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public string key;
    public FurnitureData furnitureData;
    //현재 가구의 가구 데이터를 furnitureData에 담기
    // Start is called before the first frame update
    void Start()
    {
       furnitureData = Resources.Load<FurnitureData>($"FurnitnureData/{key}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
