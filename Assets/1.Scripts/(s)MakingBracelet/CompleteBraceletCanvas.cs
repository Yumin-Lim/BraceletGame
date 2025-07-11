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

    [SerializeField]  public static bool flag; 

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
    public void OpenComplete(BraceletData makeBraceletData)
    {
        gameObject.SetActive(true);
        thumImage.sprite = makeBraceletData.thum;
        nameText.text = makeBraceletData.name;

    }

     public void OpenComplete() //퀘스트를 우해서 
    {
        gameObject.SetActive(true);
       // thumImage.sprite = makeBraceletData.thum;
        nameText.text = "퀘스트 성공";

    }
     public void OpenCompleteFreeMode() //프리모드 우해서 
    {
        gameObject.SetActive(true);
       // thumImage.sprite = makeBraceletData.thum;
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

        MakingBraceletManager mgr = FindObjectOfType<MakingBraceletManager>();
        // mgr.currentBeads
        for (int i = 0; i < mgr.currentBeads.Count; i++)
        {
            Destroy(mgr.currentBeads[i].gameObject);
        }
        mgr.currentBeads.Clear();
        for (int i = 0; i < mgr.beadsBoard.beadsPlaces.Length; i++)
        {
            mgr.beadsBoard.beadsPlaces[i].beads = null;
        }
    }
}
