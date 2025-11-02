using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FurnitureManager : MonoBehaviour
{


    public Transform furniturePr;  //생성되어야 하는 위치 (부모 오브젝트) -> 게임 킬때부터 있어야 함 
    public GameObject LobbyCanvas; //로비 캔버스        
    public static FurnitureManager Instance;
    // Start is called before the first frame update

    public GameObject canvas;

    public GameObject offButton;
    public GameObject onButton;

    public Transform floorPr;
    public Transform wallPr;


    //furnitureEditCanvas 켜지면 로비캔버스 비활성화
    //꺼지면 활성화 
    public void Awake()
    {
        Instance = this;
    }

    public void OnClickToEditMode()
    {
        Debug.Log("OnClickToEditMode()on");
        editMode = true;
        canvas.SetActive(true);
        offButton.SetActive(true);
        onButton.SetActive(false);

        LobbyCanvas.SetActive(false);


    }

    public void OnClickToEditModeClose()
    {
        Debug.Log("OnClickToEditModeClose()on");
        // onButton.SetActive(false);
        editMode = false;
        canvas.SetActive(false);
        offButton.SetActive(false);
        onButton.SetActive(true);

        LobbyCanvas.SetActive(true);


    }



    void Start()
    {
        for (int i = 0; i < User.Instance.userData.userFurnitures.Count; i++)
        {
            if (User.Instance.userData.userFurnitures[i].setUp == true)
            {

                FurnitureData furnitureData = Resources.Load<FurnitureData>($"FurnitureData/{User.Instance.userData.userFurnitures[i].furnitureName}");


               Furniture furniture = Instantiate(furnitureData.prefab);
                furniture.transform.position = (User.Instance.userData.userFurnitures[i].position);
                furniture.Apply(User.Instance.userData.userFurnitures[i]);

            }
        }
    }



    // Update is called once per frame
    public Furniture targetFurniture; //타깃
    bool editMode;
    void Update()
    {
        if (editMode == false)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 screenPoint = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            Collider2D col = Physics2D.OverlapPoint(worldPoint, LayerMask.GetMask("Furniture")); //인자반환

            if (col == null)
                return;
            targetFurniture = col.GetComponent<Furniture>();


        }
        else if (Input.GetMouseButton(0)) //클릳중
        {
            if (targetFurniture == null)
                return;

            Vector2 screenPoint = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);


            if (targetFurniture.furnitureData.arrange == FurnitureArrange.Floor)
            {


                Collider2D col = Physics2D.OverlapPoint(worldPoint, LayerMask.GetMask("Floor"));
                if (col != null)
                {
                    targetFurniture.transform.position = worldPoint;
                }

            }
            else
            {
                Collider2D col = Physics2D.OverlapPoint(worldPoint, LayerMask.GetMask("Wall"));
                if( col != null)
                {
                    targetFurniture.transform.position = worldPoint;
                }
            }


        }
        else if (Input.GetMouseButtonUp(0)) //클릭 해제 
        {

            if (targetFurniture == null)
                return;

            //타깃 해지
            User.Instance.SetFurniturePosition(targetFurniture.userFurniture, targetFurniture.transform.position);
            targetFurniture = null;


        }
    }




}