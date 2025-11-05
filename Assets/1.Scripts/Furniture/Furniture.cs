using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : MonoBehaviour
{
    public string key;
    public FurnitureData furnitureData;

    public Transform spriteTr;
    public UserFurniture userFurniture;

    public GameObject removeButton;
    public GameObject rotateButton;

    void Start()
    {

        spriteTr = transform.Find("Sprites");
        furnitureData = Resources.Load<FurnitureData>($"FurnitureData/{key}");


    }

    void Update()
    {
       if(FurnitureManager.Instance.editMode)
        {
            removeButton.SetActive(true);
            rotateButton.SetActive(true);
        }
        else
        {
            removeButton.SetActive(false);
            rotateButton.SetActive(false);
        }
    }
    public void OnclikedRemove()
    {
       Debug.Log("가구 제거 클릭됨");
       
        Destroy(gameObject); //씬상에 가구 제거
        User.Instance.SetUpFurniture(userFurniture, false); // 사용자가 세팅 안하고있음으로 변경

        //사용중인지 furniture edit canvas 업데이트 
        FurnitureEditCanvas furnitureEditCanvas = FindObjectOfType<FurnitureEditCanvas>();
        furnitureEditCanvas.UpdateCanvas();

    }

    //현재 가구의 가구 데이터를 furnitureData에 담기
    // Start is called before the first frame update

    public void Apply(UserFurniture userFurniture)
    {
        this.userFurniture = userFurniture;
        spriteTr.localRotation = Quaternion.Euler(new Vector3(0, 0, userFurniture.rotationZ));
    }

    public void OnClickedRotate()



    {
        Debug.Log("회전 클릭됨");   
        
        spriteTr.Rotate(0, 0, 90);


        User.Instance.SetFurnitureZ(userFurniture, spriteTr.localRotation.z);
    }

    // Update is called once per frame
}
