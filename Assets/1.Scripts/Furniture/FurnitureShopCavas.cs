using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

public class FurnitureShopCavas : MonoBehaviour
{

    public List<FurnitureData> furnitureList;
    public GameObject furniturePanelPrefab;
    public Transform parentTr;
    // Start is called before the first frame update
    void Start()
    {
        FurnitureData[] furnitureDatas = Resources.LoadAll<FurnitureData>($"FurnitureData");
        furnitureList = furnitureDatas.OrderBy(e =>
        {
            return e.order;
        }).ToList();

        for (int i = 0; i < furnitureList.Count; i++)
        {
            GameObject panelObject = Instantiate(furniturePanelPrefab, parentTr);
            FurniturePanelPrefab panel = panelObject.GetComponent<FurniturePanelPrefab>();
            panel.furnitureData = furnitureList[i];

        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
