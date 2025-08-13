using UnityEngine;


[CreateAssetMenu(fileName = "BeadsData", menuName = "Game/BeadsData")]
public class BeadsData : ScriptableObject //객체를 만들기 위한 설계도 : class


{
    public int price;
    public string key;
    public string beadsName;
    public string des;
    public Concept concept; //이렇게 하면 아래 에서 있는 것들을 선택 가능
    public Sprite thum;
    public int openLv;

}