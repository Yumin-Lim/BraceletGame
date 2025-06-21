using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class MakingBraceletCanvas : MonoBehaviour
{
    
    public GameObject SelectBeadsPanel;
    public Transform contentParentTr;
    
    
    
    // Start is called before the first frame update
    
   
    void Start()
    {
        User user = User.Instance;
        List<UserBeads> userBeads = user.userData.userBeads;

       

         for (int i = 0; i < userBeads.Count; i++)
        {
            if (userBeads[i].count > 0)
            {
                Debug.Log("패널 생성");
                GameObject SelectBeadsPanelClone = Instantiate(SelectBeadsPanel);
                SelectBeadsPanelClone.transform.SetParent(contentParentTr, false); //이거는 그냥 검색해서 찾은건데 뭔지 잘 모르겠음 이렇게 안하면 안보임니다 

                SelectBeadsPanel panel = SelectBeadsPanelClone.GetComponent<SelectBeadsPanel>();
                panel.SetBeads(userBeads[i].key);




            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    

}
