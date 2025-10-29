using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureEditCanvas : MonoBehaviour
{
    public GameObject furniturePanelPrefab;
    public Transform parentTr;

    public List<FurniturePanel> furniturePanels = new List<FurniturePanel>();

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("현재 보유 중인 가구 갯수 " + User.Instance.userData.userFurnitures.Count);

        for (int i = 0; User.Instance.userData.userFurnitures.Count > i; i++)
        {
            GameObject panelObject = Instantiate(furniturePanelPrefab, parentTr);
            FurniturePanel panel = panelObject.GetComponent<FurniturePanel>();
            panel.SetData(User.Instance.userData.userFurnitures[i]);

            furniturePanels.Add(panel);

            Debug.Log(i);


        }

    }


 public void UpdateCanvas() 
    {
        for(int i =0;i< furniturePanels.Count; i++)
        {
            furniturePanels[i].UpdatePanel();
        }
    }
}
