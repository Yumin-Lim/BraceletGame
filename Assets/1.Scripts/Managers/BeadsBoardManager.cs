using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadsBoardManager : MonoBehaviour
{
    public static BeadsBoardManager Instance;

    public BoardData[] boardDatas;
    // Start is called before the first frame update
    void Awake()
    {
          DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public BoardData GetBoardData(string boardKey)
    {
        for (int i = 0; i < boardDatas.Length; i++)
        {
            if (boardKey == boardDatas[i].boardKey)
            {
                return boardDatas[i];
            }
        }
        return null;
    }


}

[System.Serializable]
public class BoardData
{
    public string boardKey;
    public int price;
    public string name;
    public Sprite thum;
    public CatConcept concept;
    public int placeCount;

}