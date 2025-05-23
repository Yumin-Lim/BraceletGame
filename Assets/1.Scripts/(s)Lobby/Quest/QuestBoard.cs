using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{


    public GameObject des;
    public GameObject name;
    //이미지
    //보드타입 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
[System.Serializable]
public class QuestBoardItem
{
    public string name;
    public string des;
}