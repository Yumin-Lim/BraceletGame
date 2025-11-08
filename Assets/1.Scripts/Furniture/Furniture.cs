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


    public FurnitureDirection[] directions;

    void Awake()
    {
        directions = GetComponentsInChildren<FurnitureDirection>(true);
        if (spriteTr == null)
        {
            spriteTr = transform.Find("Sprites");
        }

        furnitureData = Resources.Load<FurnitureData>($"FurnitureData/{key}");


    }

    void Update()
    {
        if (FurnitureManager.Instance.editMode)
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
        if (spriteTr == null)
        {
            spriteTr = transform.Find("Sprites");
        }

        this.userFurniture = userFurniture; 
        SetRotation();
    }

    public void OnClickedRotate()



    {
        Debug.Log("회전 클릭됨");

        int z = (userFurniture.rotationZ + 1) % 4;


        User.Instance.SetFurnitureZ(userFurniture, z);
        SetRotation();
    }



    void SetRotation()
    {

        for (int i = 0; i < directions.Length; i++)
        {
            if (directions[i].index == userFurniture.rotationZ)
            {
                directions[i].gameObject.SetActive(true);
            }
            else
            {
                directions[i].gameObject.SetActive(false);
            }

        }
    }

    // Update is called once per frame
}