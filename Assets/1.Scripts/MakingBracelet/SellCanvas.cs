using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;

public class SellCanvas : MonoBehaviour
{
    
    
    public GameObject sellPanelPrefab;

   public Transform parentPanel;
    // Start is called before the first frame update
    void Start()
    {
        //
    }

    void OnEnable() //껏다가 켜질 때 마다
    {
       //생성 할 때 두번쨰 인자로 Transform 을 전달하면 생성된 애의 부모가?!
        
        for(int i=0; i<User.Instance.userBracelets.Count;i++)
        {
             GameObject SellPanel = Instantiate(sellPanelPrefab, parentPanel);
             sellbraveletPanel sellbraveletPanel = SellPanel.GetComponent<sellbraveletPanel>();
             sellbraveletPanel.SetBracelet(User.Instance.userBracelets[i].key);
            Debug.Log("key값이 주어지는다");
            Debug.Log(User.Instance.userBracelets[i].key);
            
            //게임 오브젝트 안에 있는게 컴포넌트 

             
    
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
