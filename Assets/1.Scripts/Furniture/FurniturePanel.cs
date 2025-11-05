using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.UI;

public class FurniturePanel : MonoBehaviour
{
   

   
    public string furnitrueName;
    public Image thumb;

    public GameObject buttonOn;
    public GameObject buttonOff;

    public FurnitureData furnitureData;

    public UserFurniture curFurniture;
    public Transform floorPr;

    



    // Start is called before the first frame update


    public void SetData(UserFurniture userFurniture)
    {
        this.furnitrueName = userFurniture.furnitureName;

        curFurniture = userFurniture;



        if (userFurniture.setUp)
        {
            //장착 되어있는 상태

            buttonOn.SetActive(false);
            buttonOff.SetActive(true);

        }
        else
        {
            buttonOn.SetActive(true);
            buttonOff.SetActive(false);
        }


        furnitureData = Resources.Load<FurnitureData>($"FurnitureData/{furnitrueName}");
        thumb.sprite = furnitureData.sprite;

    }


    public void UpdatePanel()
    {
        if (curFurniture.setUp)
        {
            //장착 되어있는 상태

            buttonOn.SetActive(false);
            buttonOff.SetActive(true);

        }
        else
        {
            buttonOn.SetActive(true);
            buttonOff.SetActive(false);
        }


    }

    public void onCliked()
    {


        User.Instance.SetUpFurniture(curFurniture, true);
        Furniture furniture = Instantiate(furnitureData.prefab, FurnitureManager.Instance.furniturePr);
        //해야하는게 
        if (furnitureData.arrange == FurnitureArrange.Floor)
        {

            furniture.transform.position = FurnitureManager.Instance.floorPr.position;


        }
        if (furnitureData.arrange == FurnitureArrange.Wall)
        {
            furniture.transform.position = FurnitureManager.Instance.wallPr.position;


        }
        UpdatePanel();
        furniture.Apply(curFurniture);
        User.Instance.SetFurniturePosition(curFurniture, curFurniture.position);


    }
}
