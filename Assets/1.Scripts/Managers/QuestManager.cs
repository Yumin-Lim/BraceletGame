using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;
    public GameObject questBoardPrefab;
    public Transform parentPanel;

    [SerializeField]
    public QuestBoard[] questBoardObjects;
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
        for (int i = 0; i < shopQuests.Length; i++)
        {
           GameObject questBoard = Instantiate(questBoardPrefab, parentPanel); 
           
        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
