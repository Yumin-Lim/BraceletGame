using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureEditCanvas : MonoBehaviour
{
    public GameObject furniturePanelPrefab;
    public Transform parentTr;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("현재 보유 중인 가구 갯수 " + User.Instance.userData.userFurnitures.Count);

        for (int i = 0; User.Instance.userData.userFurnitures.Count > i; i++)
        {
            GameObject panel = Instantiate(furniturePanelPrefab, parentTr);
            panel.GetComponent<FurniturePanel>().SetData(User.Instance.userData.userFurnitures[i]);

            Debug.Log(i);

        }
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
