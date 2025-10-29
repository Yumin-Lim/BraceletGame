using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public string key;
    public FurnitureData furnitureData;

    public UserFurniture userFurniture;

    public void OnclikedRemove()
    {
        Destroy(gameObject); //씬상에 가구 제거
        User.Instance.SetUpFurniture(userFurniture, false); // 사용자가 세팅 안하고있음으로 변경

        //사용중인지 furniture edit canvas 업데이트 
       FurnitureEditCanvas furnitureEditCanvas = FindObjectOfType<FurnitureEditCanvas>();
    

    }

    //현재 가구의 가구 데이터를 furnitureData에 담기
    // Start is called before the first frame update
    void Start()
    {
    furnitureData = Resources.Load<FurnitureData>($"FurnitureData/{key}");
         

    }

    public void Apply(UserFurniture userFurniture)
    {
        this.userFurniture = userFurniture;
    }

    // Update is called once per frame
}
