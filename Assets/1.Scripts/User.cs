using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class User : MonoBehaviour
{

    public static User Instance; //Instance 라는 변수에 User 넣는다
    public int coin;

    public int level;
    public int exp;


    public List<UserBracelet> userBracelets = new List<UserBracelet>();//UserBeads 라는 데이터를 담을 수 이ㅣㅆ는 바구니를 만들겠다. 변수는 바구니 이름일뿐


    public void Awake()
    {
        DontDestroyOnLoad(gameObject);//씬 ㅈ ㅓㄴ환되어도 제거되지 않는다 


        Instance = this;
    }
    public void AddCoin(int c)
    {
        coin += c;
    }






    public List<UserBeads> userBeads = new List<UserBeads>();//UserBeads 라는 데이터를 담을 수 이ㅣㅆ는 바구니를 만들겠다. 변수는 바구니 이름일뿐

    public void AddBeads(string key, int count)
    {
        UserBeads beads = GetUserBeads(key);
        beads.count += count;

    }

    public void SubBeads(string key)
    {
        UserBeads beads = GetUserBeads(key);
        beads.count--;
    }



    public UserBeads GetUserBeads(string key)
    {
        for (int i = 0; i < userBeads.Count; i++)
        {
            if (userBeads[i].key == key)
            {
                return userBeads[i];
            }
        }
        UserBeads uBeads = new UserBeads();
        uBeads.key = key;
        uBeads.count = 0;
        userBeads.Add(uBeads);
        return uBeads;

        //만약에 없는 키에 해당하는걸 만들어줌 
    }



    public void AddBracelet(string key, int count)
    {
        UserBracelet userBracelet = GetUserBracelet(key);
        userBracelet.count += count;
    }







    public UserBracelet GetUserBracelet(string key)
    {
        for (int i = 0; i < userBracelets.Count; i++)
        {
            if (userBracelets[i].key == key)
            {
                return userBracelets[i];
            }

        }
        UserBracelet userBracelet = new UserBracelet();
        userBracelet.key = key;
        userBracelets.Add(userBracelet);
        return userBracelet;

    }






    public void SubBracelet(string key, int count)
    {
        for (int i = 0; i < userBracelets.Count; i++)
        {
            if (userBracelets[i].key == key)
            {
                userBracelets[i].count -= count;
            }

        }


        // UserBracelet userBracelet=GetUserBracelet(key);
        // userBracelet.count -= count;
    }









    // Start is called before the first frame update
    void Start()
    {


        SceneManager.LoadScene("Lobby");


    }

    // Update is called once per frame
    void Update()
    {
         level = exp / 10; 
    }


}

[System.Serializable]
public class UserBeads
{
    public string key;
    public int count;
}

[System.Serializable]
public class UserBracelet
{
    public string key;
    public int count;
}