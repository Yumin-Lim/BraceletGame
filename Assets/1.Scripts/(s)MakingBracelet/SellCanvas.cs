using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.Analytics;

public class SellCanvas : MonoBehaviour
{
    public static SellCanvas Instance;

    public GameObject sellPanelPrefab;

    public Transform parentPanel;
    // Start is called before the first frame update

    void Awake()
    {
    }

    void Start()
    {
        //시작할때 한번 해야하나?
    }

    List<SellbraceletPanel> sellbraceletPanels = new List<SellbraceletPanel>();

    public void OnEnable() //여기 수정해야함 onenable 아니고 다른데서 불러야함 예를들면 팔찌를 만든후에???
    {

        for (int i = 0; i < sellbraceletPanels.Count; i++)
            sellbraceletPanels[i].gameObject.SetActive(false);

        var list = User.Instance.userData.userBracelets;
        if (list == null || list.Count == 0) return;

      
        for (int j = 0; j < list.Count; j++)
        {
            Debug.Log("셀캔버스 진입3");

            var panel = GetSellbraceletPanel();   
            panel.SetBracelet(list[j]);          
            list[j].price = 120;

          
        }
    

        SellbraceletPanel GetSellbraceletPanel()
        {
            for (int i = 0; i < sellbraceletPanels.Count; i++)
            {
                if (sellbraceletPanels[i].gameObject.activeSelf)
                {
                    continue;
                }

                sellbraceletPanels[i].gameObject.SetActive(true);
                return sellbraceletPanels[i];
            }
            GameObject SellPanel = Instantiate(sellPanelPrefab, parentPanel);
            SellbraceletPanel sellbraceletPanel = SellPanel.GetComponent<SellbraceletPanel>();
            sellbraceletPanels.Add(sellbraceletPanel);
            return sellbraceletPanel;
        }
    }

    public void OnClikedClose()
    {
        gameObject.SetActive(false);

        for (int i = 0; i < sellbraceletPanels.Count; i++)
        {
            sellbraceletPanels[i].gameObject.SetActive(false);
        }

    }




    // Update is called once per frame
    void Update()
    {

    }
}
