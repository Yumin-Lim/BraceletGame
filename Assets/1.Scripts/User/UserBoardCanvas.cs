using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBoardCanvas : MonoBehaviour
{

    public GameObject UserBoardPanelPrefab;
    public Transform ParentCanvas;

    // Start is called before the first frame update


    void OnEnable()
    {
        int childCount = ParentCanvas.childCount;
        for (int i = 0; i < childCount; i++)
        {
            Transform child = ParentCanvas.GetChild(i);
            Destroy(child.gameObject); //등록된것 진짜 지워지는건 다음프레임.
        }



        User user = User.Instance;
        List<UserBoardData> userBoards = user.userData.userBoardData;

        for (int i = 0; i < userBoards.Count; i++)
        {
            if (!userBoards[i].purchased)
                continue;
            GameObject UserBoardPanelClone = Instantiate(UserBoardPanelPrefab);
            UserBoardPanelClone.transform.SetParent(ParentCanvas, false);
            UseerBoardPanel panel = UserBoardPanelClone.GetComponent<UseerBoardPanel>();
            panel.SetBoard(userBoards[i].boardKey);


        }
    }


    //확인 하는 함수? 팔찌 보유갯수 보드 보유갯수 확인 똗닷가



    // Update is called once per frame
    void Update()
    {
    }
}
