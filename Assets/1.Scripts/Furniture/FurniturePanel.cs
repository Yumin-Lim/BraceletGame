using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePanel : MonoBehaviour
{
    public string key;
    public Image thumb;

    FurnitureData furnitureData;

    




    // Start is called before the first frame update


    public void SetData(UserFurniture userFurniture)
    {
        this.key = key;


        if (userFurniture.setUp)
        {
            userFurniture.setUp = true;
        }
        else{
            //장착하기 버튼 표시!
        }


        furnitureData = Resources.Load<FurnitureData>($"FurnitureData/{key}");
        thumb.sprite = furnitureData.sprite;

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void onCliked()
    {
        Instantiate(furnitureData.prefab, FurnitureManager.Instance.furniturePr);
    }
}
