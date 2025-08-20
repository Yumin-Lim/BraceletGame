using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System;
using JetBrains.Annotations;

public class User : MonoBehaviour
{


    public static User Instance; //Instance 라는 변수에 User 넣는다

    public UserData userData;
    public string selectedBoardKey;

    //public ShopQuest shopQuest; //이걸 이제 퀘스트를 여러개 받을거니까 리스트로 만들자 


    public void Awake()
    {


        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); //반드시 Instance 설정 후에!해야한다
        }
        else
        {
            Destroy(gameObject); // 이미 존재하면 새로 만든 건 파괴해야한다???
        }

        userData = SaveManger.LoadData<UserData>("UserData");
        if (userData == null) // 신규유저
        {
            PlayerPrefs.DeleteAll(); 
            userData = new UserData();
            AddCoin(100);
            AddBoard("A");
            SaveManger.SaveData("UserData", userData);
        }


    }
    public void AddCoin(int c)
    {
        userData.coin += c;
        SaveManger.SaveData("UserData", userData);
    }

    public void AddExp(int e)
    {
        userData.exp += e;
        if (userData.exp >= 10)
        {
            userData.exp -= 10;
            LevelUp();

        }
        SaveManger.SaveData("UserData", userData);
    }
    void LevelUp()
    {
        userData.level++;
    }

    public void SaveData(QuestData questData)
    {
         SaveManger.SaveData("UserData", questData);
    }



    public void AddBeads(string key, int count)
    {
        UserBeads beads = GetUserBeads(key);
        beads.count += count;
        SaveManger.SaveData("UserData", userData);

    }

    public void SubBeads(string key)
    {
        UserBeads beads = GetUserBeads(key);
        beads.count--;
        SaveManger.SaveData("UserData", userData);
    }




    public UserBeads GetUserBeads(string key)
    {
        for (int i = 0; i < userData.userBeads.Count; i++)
        {
            if (userData.userBeads[i].key == key)
            {
                return userData.userBeads[i];
            }
        }
        UserBeads uBeads = new UserBeads();
        uBeads.key = key;
        uBeads.count = 0;
        userData.userBeads.Add(uBeads);
        return uBeads;

        //만약에 없는 키에 해당하는걸 만들어줌 
    }



   public void AddBracelet(UserBeadsPlaceData[] userBeadsPlaceDatas, string boardKey)
{
    UserBracelet userBracelet = new UserBracelet();
    userBracelet.userBeadsPlaceDatas = userBeadsPlaceDatas;

    //팔찌가 제작된 이름 자체가 키가 됌 - 이 부분 고민 필요
    userBracelet.key = DateTime.Now.ToString(); 
    userBracelet.boardKey = boardKey;
    userData.userBracelets.Add(userBracelet);

    SaveManger.SaveData("UserData", userData);
}

    public UserBracelet GetUserBracelet(string key)
    {
        for (int i = 0; i < userData.userBracelets.Count; i++)
        {
            if (userData.userBracelets[i].key == key)
            {
                return userData.userBracelets[i];
            }

        }
        UserBracelet userBracelet = new UserBracelet();
        userBracelet.key = key;
        userData.userBracelets.Add(userBracelet);
        return userBracelet;

    }

/*

    public void AddFreeBracelet(UserBeadsPlaceData[] userBeadsPlaceDatas, string boardKey) //멤버변수 접근시 this
    {
        UserBracelet userBraceletData = new UserBracelet(); //
        userFreeBraceletData.boardKey = boardKey;
        userFreeBraceletData.userBeadsPlaceDatas = userBeadsPlaceDatas;
        userFreeBraceletData.freeBraceletKey = "freeBraceletKey";
        userFreeBraceletData.price = 1000;
        userData.userFreeBraceletDatas.Add(userFreeBraceletData);
    }


    public void AddQuestBracelet(UserQuestBraceletData[] userQuestBraceletDatas) //멤버변수 접근시 this
    {
        UserQuestBraceletData userQuestBraceletData = new UserQuestBraceletData(); //
        userQuestBraceletData.QuestBraceletKey = "questBraceletKey";
        userQuestBraceletData.price = 1000;
        userData.userQuestBraceletDatas.Add(userQuestBraceletData);
    }




    public UserBracelet GetUserBracelet(string key)
    {
        for (int i = 0; i < userData.userBracelets.Count; i++)
        {
            if (userData.userBracelets[i].key == key)
            {
                return userData.userBracelets[i];
            }

        }
        UserBracelet userBracelet = new UserBracelet();
        userBracelet.key = key;
        userData.userBracelets.Add(userBracelet);
        return userBracelet;

    }


    public UserFreeBraceletData GetFreeUserBracelet(UserFreeBraceletData userFreeBraceletData)
    {
        return null;


    }




*/

    public void SubBracelet(UserBracelet userBracelet)
    {
         userData.userBracelets.Remove(userBracelet);

        // UserBracelet userBracelet=GetUserBracelet(key);
        // userBracelet.count -= count;
    }



    public UserCatData GetCat(string CatKey)
    {
        for (int i = 0; i < userData.userCatData.Count; i++)
        {
            if (userData.userCatData[i].CatKey == CatKey)
            {

                return userData.userCatData[i];
            }

        }

        //이게 꼭 필요한가????
        UserCatData newCat = new UserCatData();
        newCat.CatKey = CatKey;
        userData.userCatData.Add(newCat);

        return newCat;
    }


    public void AddCat(string CatKey, int count)
    {
        UserCatData cat = GetCat(CatKey);
        SaveManger.SaveData("UserData", userData);


    }

    public UserBoardData GetBoard(string BoardKey)
    {
        for (int i = 0; i < userData.userBoardData.Count; i++)
        {
            if (userData.userBoardData[i].boardKey == BoardKey)
            {
                return userData.userBoardData[i];
            }
        }

        // 없으면 새로 생성
        UserBoardData newBoard = new UserBoardData();
        newBoard.boardKey = BoardKey;
        userData.userBoardData.Add(newBoard);

        return newBoard;
    }




    public void AddBoard(string BoardKey)
    {
        UserBoardData board = GetBoard(BoardKey);
        board.purchased = true;
        SaveManger.SaveData("UserData", userData);

    }



    // Start is called before the first frame update
    void Start()
    {


        SceneManager.LoadScene("Lobby");



    }

    // Update is called once per frame


}

[System.Serializable]
public class UserBeads
{
    public string key;
    public int count;
}



[System.Serializable]
public class UserCatData
{
    public string CatKey;
    public int count;
}

[System.Serializable]
public class UserBoardData
{
    public string boardKey;
    public bool purchased;

}



[System.Serializable] //객체를 만들려면 class 가 필요하다 
//객체는 메모리상에 할당된 데이터 
public class UserData
{
    public int coin;

    public int level;
    public int exp;

    
    public List<UserBracelet> userBracelets = new List<UserBracelet>();
   // public List<UserQuestBraceletData> userQuestBraceletDatas = new List<UserQuestBraceletData>();
    //public List<UserFreeBraceletData> userFreeBraceletDatas = new List<UserFreeBraceletData>();
    //UserBeads 라는 데이터를 담을 수 이ㅣㅆ는 바구니를 만들겠다. 변수는 바구니 이름일뿐

    public List<UserBeads> userBeads = new List<UserBeads>();//UserBeads 라는 데이터를 담을 수 이ㅣㅆ는 바구니를 만들겠다. 변수는 바구니 이름일뿐
    public List<UserCatData> userCatData = new List<UserCatData>();
    public List<UserBoardData> userBoardData = new List<UserBoardData>(); //사용자가 ㄷ어떤 보드 가지고 있고 안가지고 있고 유저의 보드 보유 상태 



    public List<QuestData> userQuestList = new List<QuestData>(); //유저가 수락한 퀘스트
}



//유저가 자유롭게 만든 팔찌 데이터
[System.Serializable]
public class UserBracelet
{
    //여러개의 객체를 만드닌까 
    public string boardKey;
    public string key;
    public UserBeadsPlaceData[] userBeadsPlaceDatas;

    public Sprite thum;

    public string freeBraceletKey;
    public int price;

}
[System.Serializable]
public class UserBeadsPlaceData
{
    public int index;
    public string beadsKey;
}




[System.Serializable]



public class UserQuestBraceletData
{
    //여러개의 객체를 만드닌까 
    public string boardKey;

    public Sprite thum;

    public string QuestBraceletKey;
    public int price;

}
