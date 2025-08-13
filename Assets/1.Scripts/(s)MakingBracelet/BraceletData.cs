using UnityEngine;


[CreateAssetMenu(fileName = "BraceletData", menuName = "Game/BraceletData")]

public class BraceletData :  ScriptableObject  //객체를 만들기 위한 설계도 : class

{
    public int price;
    public string key;
    public string braceletName;
    public string des;
    public Concept concept; //이렇게 하면 아래 에서 있는 것들을 선택 가능
    public Sprite thum;
    public BraceletNeed[] braceletNeeds;
}
[System.Serializable]
public class BraceletNeed 
{
    public string beadsKey;
    [Header("0-1 비율로 작성했다 ")]
    public float rate;  
    public int count;
}


