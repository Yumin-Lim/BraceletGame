using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;

public class QuestBoardPrefab : MonoBehaviour
{

    public TMP_Text titleText;
    public TMP_Text descriptionText;
    public GameObject button;
    public Image thumImage;
    // Start is called before the first frame update

    public ShopQuest questForBoard;
    public int index; // 자신이 몇 번째인지 저장

    public void OnclickedButton()
    {
      User.Instance.userData.questList.Add(questForBoard);
    }



    // Update is called once per frame
    void Update()
    {

    }
}
