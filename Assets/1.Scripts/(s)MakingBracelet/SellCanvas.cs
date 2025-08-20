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
        Instance = this;
    }

    void Start()
    {
        //
    }

    List<SellbraceletPanel> sellbraceletPanels = new List<SellbraceletPanel>();

    void OnEnable() //여기 수정해야함 onenable 아니고 다른데서 불러야함 예를들면 팔찌를 만든후에???
    {
        //생성 할 때 두번쨰 인자로 Transform 을 전달하면 생성된 애의 부모가?!
        //프리셋 모드
        /*
                for (int i = 0; i < User.Instance.userData.userBracelets.Count; i++)
                {
                    if (User.Instance.userData.userBracelets[i].count <= 0)
                        continue;

                    for (int j = 0; j < User.Instance.userData.userBracelets[i].count; j++)

                    {
                        //sellbraceletPanels 리스트에 비활성화 된 sellBraceletPanel이 없을떄 새로 만들고 



                        SellbraceletPanel panel = GetSellbraceletPanel();
                        panel.SetBracelet(User.Instance.userData.userBracelets[i].key);
                        Debug.Log("key값이 주어지는다");
                        Debug.Log(User.Instance.userData.userBracelets[i].key);

                    }


                }

//프리모드
       
Debug.Log("셀캔버스 진입");
        for (int i = 0; i < User.Instance.userData.userFreeBraceletDatas.Count; i++)
        {
            Debug.Log("셀캔버스 진입1");
            if (User.Instance.userData.userFreeBraceletDatas.Count <= 0)
                continue;
            Debug.Log("셀캔버스 진입2");
            for (int j = 0; j < User.Instance.userData.userFreeBraceletDatas.Count; j++)

            {
                Debug.Log("셀캔버스 진입3");
                SellbraceletPanel panel = GetSellbraceletPanel();
                panel.SetBracelet(User.Instance.userData.userFreeBraceletDatas[i].freeBraceletKey);
                //이게 문제임 이게 이제 팔려면 그 팔려는 팔찌의 키가 있어야 하는데 하나가 있어야 하는건데 흠...

            }





        }
        //여기가 카운트에 따라서 만들어지는게 아니라 단독적으로 하나당 패널 하나씩 만들어져야하는데 ....
*/ //퀘스트모드
        for (int i = 0; i < User.Instance.userData.userQuestList.Count; i++)
        {
            Debug.Log("셀캔버스 진입1");
            if (User.Instance.userData.userQuestList.Count <= 0)
                continue;
            Debug.Log("셀캔버스 진입2");
            for (int j = 0; j < User.Instance.userData.userQuestList.Count; j++)

            {
                Debug.Log("셀캔버스 진입3");
                SellbraceletPanel panel = GetSellbraceletPanel();
              //  panel.SetBracelet(User.Instance.userData.userQuestList[j].questKey);
                //이게 문제임 이게 이제 팔려면 그 팔려는 팔찌의 키가 있어야 하는데 하나가 있어야 하는건데 흠...

            }


        }

        //재사용을 위해서 

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
