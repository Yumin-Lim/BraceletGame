using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMaker : MonoBehaviour
{

    public static CatMaker Instance;

    public GameObject catPrefab;
    public string CatKey;

    public Cat[] cats;
    public Transform[] catPositions; //고양이가 위치할 수 있는 위치 들
    public List<Transform> canSelectPositions = new List<Transform>();


    public void Awake()
    {
        Instance = this;

        cats = new Cat[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            cats[i] = transform.GetChild(i).GetComponent<Cat>();
        }
        canSelectPositions.AddRange(catPositions);
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

    //다른 고양이가 선택한 곳인지 어떻게 알지?
    //다른 고양이가 선택한걸 일단 알아야하고 어딘가에서
    //그리고 뭔가 순서대로 저장할테니까 나머지 그 나머지중에서 준다 
    // 모든 포지션은 알고있고 
    //누가 선택하면 뺸다?? 
    //뺴고 그나머지중에서 한다.



//다른 자리 가기전에 자기 자리를 다시 리스트에 채워 넣어야한다.
    public Transform GetTransformPosition()
    {
        Transform randomPosition = canSelectPositions[Random.Range(0, canSelectPositions.Count)];
        canSelectPositions.Remove(randomPosition);
        return randomPosition;

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

