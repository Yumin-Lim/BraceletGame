using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BraceletQuestView : MonoBehaviour
{

    public GameObject BraceletQuestPanel;
    public Transform parentPanel;

    public static BraceletQuestView Instance;
    public List<QuestData> boardQuestList = new List<QuestData>();


    public void Awake()
    {
        Instance = this;
    }

    public void questBoardUpdate()
    {
        boardQuestList = User.Instance.userData.userQuestList;
        questBoardMaking();
    }

    public void questBoardMaking()
    {
        for (int i = 0; i < boardQuestList.Count; i++)
        {
            GameObject questBoard = Instantiate(BraceletQuestPanel, parentPanel);
            BraceletQuestBoard script = questBoard.GetComponent<BraceletQuestBoard>();
            script.questForBraceletBoard = (boardQuestList[i]);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        questBoardUpdate();


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void onClikedButton()
    {

    }
}

public class BraceletQuestPanel
{
    public string name;
    public QuestData shopQuest;
}