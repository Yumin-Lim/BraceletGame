using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Random = UnityEngine.Random;
public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;


    public GameObject questBoardPrefab;
    public Transform parentPanel;

    public QuestData[] questDatas; //오늘 받을 수 있는 퀘스트 목록 



    void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);


    }


    void Start()
    {

        string questLastTime = PlayerPrefs.GetString("QuestLastTime");
        //questLastTime 이라는 이름의 락커에서 물건을 꺼내오는데 그 타입이 스트링이다.

        Debug.Log("QuestManager start() questLastTime" + questLastTime);

        //유저가 해당 퀘스트를 가지고 있는지 판별하고
        //가지고 있는 경우에는: 노출안함
        //가지고 있지 않는 경우: 노출함

        if (string.IsNullOrEmpty(questLastTime) == false)
        {
            if (questLastTime == DateTime.Now.Date.ToString()) //오늘 다시 접속한 상태 
            {
                Debug.Log("QuestManager start() 기존유저 같은날");
                QuestSaveData questSaveData = SaveManger.LoadData<QuestSaveData>("QuestSaveData");
                questDatas = questSaveData.questDatas;
                //이미 설정된 퀘스트 데이터를 다시 불러오는 코드 ?
                UpdateUi();




            }
            else //며칠 이따가 다시 접속했다 
            {
                Debug.Log("QuestManager start() 기존유저 다른날");
                User.Instance.userData.userQuestList.Clear();
                MakeQuestBoards();




                // 퀘스트 받아둔거 리셋하기 
            }
        }
        else //접속한적이 없다.
        {

            Debug.Log("QuestManager start() 신규유저");
            MakeQuestBoards();


        }

        DateTime today = DateTime.Now.Date; //today 라는 데이트 타임에 오늘 날짜를 저장했다


        PlayerPrefs.SetString("QuestLastTime", today.ToString());
        PlayerPrefs.Save();

    }


    void MakeQuestBoards()
    {
        questDatas = new QuestData[10]; //현제 레벨에 맞게 사용할 수 있는 비즈만 담는다 
        //아직 넣은거 아니고 넣을 수 있는 공간을 설정한것이다 그니까 new 가 있어야 실제로 담은것이다 

        List<BeadsData> canBeads = new List<BeadsData>();
        for (int i = 0; i < BeadsManager.Instance.beadsDatas.Length; i++)
        {
            if (BeadsManager.Instance.beadsDatas[i].openLv <= User.Instance.userData.level)
            {
                canBeads.Add(BeadsManager.Instance.beadsDatas[i]);
            }
        }

        List<string> canBoardKeys = new List<string>();
        for (int i = 0; i < User.Instance.userData.userBoardData.Count; i++) //UserInstance 에서 접근 가능한건 component vs class 
        {
            if (User.Instance.userData.userBoardData[i].purchased)
            {
                canBoardKeys.Add(User.Instance.userData.userBoardData[i].boardKey);
            }
        }


        for (int i = 0; i < questDatas.Length; i++)
        {
            questDatas[i] = new QuestData(); //각각의 칸에다 shopQuest 객체 채우기라는뜻


            questDatas[i].name = $"Daily Quest {i}"; //퀘스트의 번호 부여하는 코드로 i 랑 같음 (이거 i+1로 해야 1부터 시작하지)
            questDatas[i].des = $"Contents {i}"; //그리고 이거는 퀘스트의 내용을 부여하기 위해서 일단 만든코드로 나중에 수정해야함 
            questDatas[i].questKey = $"questKey{i}";
            questDatas[i].price = 100;
            questDatas[i].boardKey = canBoardKeys[Random.Range(0, canBoardKeys.Count)]; //여기 문제 이다 보유중인 보드 중 하나다 
            BoardData boardData = BeadsBoardManager.Instance.GetBoardData(questDatas[i].boardKey);

            //배열의 크기설정 객체가 담긴건 아님 
            questDatas[i].beadsPlaceCorrects = new BeadsPlaceCorrect[boardData.placeCount];

            for (int j = 0; j < questDatas[i].beadsPlaceCorrects.Length; j++)
            {
                questDatas[i].beadsPlaceCorrects[j] = new BeadsPlaceCorrect();
                questDatas[i].beadsPlaceCorrects[j].index = j;
                questDatas[i].beadsPlaceCorrects[j].beadKey = canBeads[Random.Range(0, canBeads.Count)].key;


            }

        }
        //배열자체가 저장이 안되니까 이렇게 
        QuestSaveData questSaveData = new QuestSaveData();
        questSaveData.questDatas = questDatas;

        SaveManger.SaveData("QuestSaveData", questSaveData);


        //   BraceletQuestView.Instance.questBoardUpdate();
        //이거는 뭐지  이거느 이제 수락했을때 수락한 퀘스트의 정보를 비즈 만드는 곳에서 보여주기 위해서 만든 코드임 
        UpdateUi();
    }

    void UpdateUi()
    {
        for (int i = 0; i < questDatas.Length; i++)
        {
            bool isHas = false;
            int k = questDatas.Length;
            for (int j = 0; j < User.Instance.userData.userQuestList.Count; j++)
            {
                if (User.Instance.userData.userQuestList[j].questKey == questDatas[i].questKey)
                {
                    isHas = true;
                    break;
                }


            }

            if (isHas)
                continue;

            GameObject questBoard = Instantiate(questBoardPrefab, parentPanel);

            QuestBoardPrefab script = questBoard.GetComponent<QuestBoardPrefab>();
            script.titleText.text = questDatas[i].name;
            script.descriptionText.text = questDatas[i].des;


            script.questForBoard = questDatas[i];

        }
    }


    // Update is called once per frame
    void Update()
    {

    }
}

[System.Serializable]
public class QuestData
{


    public string name;
    public string des;

    public string boardKey;
    public BeadsPlaceCorrect[] beadsPlaceCorrects;

    public int price;

    public string questKey;
}

[System.Serializable]
public class BeadsPlaceCorrect
{
    public int index;
    public string beadKey;
}

[System.Serializable]
public class QuestSaveData
{
    public QuestData[] questDatas;
}


