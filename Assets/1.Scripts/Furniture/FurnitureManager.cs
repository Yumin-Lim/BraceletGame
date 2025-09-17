using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureManager : MonoBehaviour
{


    public Transform furniturePr;

    public static FurnitureManager Instance;
    // Start is called before the first frame update

    public void Awake()
    {
        Instance = this;
    }






    void Start()
    {

    }

    // Update is called once per frame
    public Furniture targetFurniture; //타깃
    bool editMode;
    void Update(){
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
            Vector2 screenPoint = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            targetFurniture.transform.position = worldPoint;
        }
        else if (Input.GetMouseButtonUp(0)) //클릭 해제 
        {
            //타깃 해지
            targetFurniture = null;
        }
    }

}