using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;
public class CompleteBraceletCanvas : MonoBehaviour
{
    public static CompleteBraceletCanvas Instance;


    public Image thumImage;
    public TMP_Text nameText;
    [SerializeField] private GameObject questCompleteBtn;
    public List<QuestData> currentQuestData = new List<QuestData>();

    [SerializeField] public static bool flag;

    // Start is called before the first frame update

    void Awake()
    {
        Instance = this;
    }
    void OnEnable()
    {
        if (flag)
        {
            questPopUp();
        }




    }


    public void OpenCompleteQuest(string braceletKey) //퀘스트를 우해서 
    {
        gameObject.SetActive(true);
        thumImage.sprite = Capture.Instance.LoadSpriteFromFile(braceletKey);
        nameText.text = "퀘스트 성공";

    }
    public void OpenCompleteFreeMode(string braceletKey) //프리모드 우해서 
    {
        gameObject.SetActive(true);


        thumImage.sprite = Capture.Instance.LoadSpriteFromFile(braceletKey);


        nameText.text = "나만의 팔찌 만들기 성공";

    }




    // Update is called once per frame
    void Update()
    {

    }



    public void questPopUp()
    {

        questCompleteBtn.SetActive(true);
    }
    public void OnClickedClose()
    {




        gameObject.SetActive(false);

        var mgr = FindObjectOfType<MakingBraceletManager>();

        for (int i = mgr.currentBeads.Count - 1; i >= 0; i--)
        {
            var bead = mgr.currentBeads[i];
            if (bead != null) Destroy(bead.gameObject);  // 이미 Destroy된 항목은 건너뜀
            mgr.currentBeads.RemoveAt(i);                 // 리스트에서도 제거
        }

        for (int i = 0; i < mgr.beadsBoard.beadsPlaces.Length; i++)
        {
            mgr.beadsBoard.beadsPlaces[i].beads = null;
        }

    }
}

