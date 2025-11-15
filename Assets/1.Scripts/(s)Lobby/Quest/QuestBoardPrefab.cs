using UnityEngine.UI;
using UnityEngine;
using TMPro;


public class QuestBoardPrefab : MonoBehaviour
{

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public GameObject button;
    public Image thumImage;
    // Start is called before the first frame update

    public QuestData questForBoard;
    public int index; // 자신이 몇 번째인지 저장

  public void OnclickedButton()
  {

    

    User.Instance.userData.userQuestList.Add(questForBoard);
    //업데이트 하는 함수가 필요함 User의 업데이트 하는 
    SaveManger.SaveData("UserData", User.Instance.userData);
      
  Destroy(gameObject);
      
    }



    // Update is called once per frame
    void Update()
    {

    }
}
