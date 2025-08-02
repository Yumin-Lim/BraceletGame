using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMaker : MonoBehaviour
{

    public static CatMaker Instance;

    public GameObject catPrefab;
    public string CatKey;

    public Cat[] cats;


    public void Awake()
    {
        Instance = this;

        cats = new Cat[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            cats[i] = transform.GetChild(i).GetComponent<Cat>();
        }
    }

    


    //생성의 기준 

    //생성은 그 장면이 보여지기 시작 할 때 만드는것이 가장 좋다.

    // Start is called before the first frame update

    public void StartStreet(StreetType streetType)
    {


        for (int i = 0; i < cats.Length; i++)
        {
            cats[i].gameObject.SetActive(false);
        }

        if (streetType == StreetType.Lobby)
        {

            for (int i = 0; i < User.Instance.userData.userCatData.Count; i++)
            {
                Cat cat = GetCat(User.Instance.userData.userCatData[i].CatKey);
                cat.gameObject.SetActive(true);

            }




        }
    }


    public Cat GetCat(string catKey)
    {
        for (int i = 0; i < cats.Length; i++)
        {
            if (cats[i].catKey == catKey)
                return cats[i];
        }

        return null;
    }


}

