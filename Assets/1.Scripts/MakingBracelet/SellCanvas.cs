using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

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

    void OnEnable() //껏다가 켜질 때 마다
    {
        //생성 할 때 두번쨰 인자로 Transform 을 전달하면 생성된 애의 부모가?!

        for (int i = 0; i < User.Instance.userBracelets.Count; i++)
        {
            if(User.Instance.userBracelets[i].count <= 0)
            continue;
            
            for(int j = 0; j < User.Instance.userBracelets[i].count;)
            {
                   GameObject SellPanel = Instantiate(sellPanelPrefab, parentPanel);
            sellbraveletPanel sellbraveletPanel = SellPanel.GetComponent<sellbraveletPanel>();
            sellbraveletPanel.SetBracelet(User.Instance.userBracelets[i].key);
            Debug.Log("key값이 주어지는다");
            Debug.Log(User.Instance.userBracelets[i].key);

            }
         



        }
        //여기가 카운트에 따라서 만들어지는게 아니라 단독적으로 하나당 패널 하나씩 만들어져야하는데 ....


        

    }


    void destoryPanel()
    {

    }



    // Update is called once per frame
    void Update()
    {

    }
}
