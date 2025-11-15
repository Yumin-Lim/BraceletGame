using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class shop_2 : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject ShopCanvas_2;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (EventSystem.current.IsPointerOverGameObject())
        {
            // UI 클릭 중 → 월드 클릭 무시
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {

            Vector2 screenPoint = Input.mousePosition;
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(screenPoint);
            Collider2D[] cols = Physics2D.OverlapPointAll(worldPoint);

            for (int i = 0; i < cols.Length; i++)
            {
                if (cols[i].tag == "Shop_2")
                {
                    Debug.Log("Shop!");
                    ShopCanvas_2.SetActive(true);

                }
            }


        }
    }
}
