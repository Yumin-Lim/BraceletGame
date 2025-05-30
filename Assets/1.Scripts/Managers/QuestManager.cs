using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;


    public GameObject questBoardPrefab;
    public Transform parentPanel;



    [SerializeField]
    public QuestBoard[] questBoards;
    public ShopQuest[] shopQuests;


    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    void Start()
    {

        MakeQuestBoards();

    }

   void MakeQuestBoards()
{
    questBoards = new QuestBoard[10];

    for (int i = 0; i < questBoards.Length; i++)
    {
        questBoards[i] = new QuestBoard();
        questBoards[i].name = $"Daily Quest {i}";
        questBoards[i].des = $"Contents {i}";

        GameObject questBoard = Instantiate(questBoardPrefab, parentPanel);

        QuestBoardPrefab script = questBoard.GetComponent<QuestBoardPrefab>();
        script.titleText.text = questBoards[i].name;
        script.descriptionText.text = questBoards[i].des;
        questBoards[i].shopQuest = shopQuests[i];
        script.questForBoard = shopQuests[i];
    }

    BraceletQuestView.Instance.questBoardUpdate();
}




    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class QuestBoard
{
    public string name;
    public string des;
    public ShopQuest shopQuest;
}