using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStrCatToShopBtn : MonoBehaviour
{
    public GameObject arrowButton;
    public GameObject camera;
    public Transform ShopStreetTr;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPosition);
            for(int i = 0; i < cols.Length; i++)    
            {
                if(cols[i].tag =="StorePlace")
                {
                    Debug.Log("버튼누름");
                    camera.transform.position = ShopStreetTr.position;
                }
            }
    }
    }
}
