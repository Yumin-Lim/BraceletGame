using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MailTextCanvas : MonoBehaviour
{
    public TMP_Text MailContentText;
    public GameObject MailAlertIcon;

    public bool IsPrevQuestComplited;

    public QuestGiftBtnPrefab questGiftBtn;





    public GameObject panel;

    public MailContentData[] data = new MailContentData[]
   {
        new MailContentData { id = 0, text = "안녕. 상의할 일이 있어서 그런데 가구점 앞 상인회 사무소로 와줄래? -  "  }, // 보상 티켓한개
        new MailContentData { id = 1, text = "좋은 소식이 있어 마을에 새로운 상인들이 찾아왔어 다 너 덕분이야 고마워" },
        new MailContentData { id = 2, text = "테스트" }
   };


    public void LetterSending()
    {

    }


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (User.Instance.userData.userBracelets.Count >= 1)
        {
            
          
            //questGiftBtnPrefab
            Debug.Log("메일1도착");
            MailAlertIcon.SetActive(true);
            MailContentText.text = data[0].text;



            IsPrevQuestComplited = true;



        }

        if (User.Instance.userData.userTicketDatas.Count >= 3)
        {
            Debug.Log("메일2도착");
            MailAlertIcon.SetActive(true);
            MailContentText.text = data[1].text;
            IsPrevQuestComplited = true;
        }

    }

    public void OnClikedCloseButton()
    {
        gameObject.SetActive(false);
        MailAlertIcon.SetActive(false);
    }
    public void OnClickedOpenButton()
    {
        panel.SetActive(true);
    }

}
[System.Serializable]
public struct MailContentData
{
    public int id;
    public string text;
}


[System.Serializable]
public struct StoryQuestData
{
}

