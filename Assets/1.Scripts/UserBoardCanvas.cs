using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBoardCanvas : MonoBehaviour
{

    public GameObject UserBoardPanelPrefab;
    public Transform ParentCanvas;

    // Start is called before the first frame update
    void Start()
    {
        User user = User.Instance;
        List<UserBoardData> userBoards = user.userData.userBoardData;

        for (int i = 0; i < userBoards.Count; i++)
        {
            GameObject UserBoardPanelClone = Instantiate(UserBoardPanelPrefab);
            UserBoardPanelClone.transform.SetParent(ParentCanvas, false);
            UseerBoardPanel panel = UserBoardPanelClone.GetComponent<UseerBoardPanel>();
           panel.SetBoard(userBoards[i].boardKey);
            
        
        }


    }





    // Update is called once per frame
    void Update()
    {
    }
}
