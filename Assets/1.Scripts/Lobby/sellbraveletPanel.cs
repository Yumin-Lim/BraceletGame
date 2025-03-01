using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Data.Common;
public class sellbraveletPanel : MonoBehaviour
{
  public TMP_Text countText;
  public TMP_Text sellCountText;
  public Image thumImage;


  public int maxBraceletCount; //보유한 팔찌 갯수
  public int currentSellCount; //판매할 갯수 

  public string key;
  public void SetBracelet(string Key)
  {
    this.key = Key;
    BraceletData data = BraceletManager.Instance.GetBraceletData(Key);
    thumImage.sprite = data.thum;
    UserBracelet userBracelet = User.Instance.GetUserBracelet(Key);
    sellCountText.text = userBracelet.count.ToString();
    countText.text = userBracelet.count.ToString();

    maxBraceletCount = userBracelet.count;
    currentSellCount = 1;


  }
  // Start is called before the first frame update


  //버튼에 대해서 생각해야 할 부분
  //1. +버튼의 범위 1~내가 가지고 있는 팔찌갯수 -user 에서 가져온다 
  //2. -버튼의 범위 1~내가 가지고 있는 팔찌 갯수
  //똑같은데...??
  public void onPlusButton()
  {

    //근데 텍스트만 바꾸면 그걸 user에 가서 뺄 수가 있나? 변수를 하나 만들어야 할 것 같은데
    if (maxBraceletCount > currentSellCount)
    {
      currentSellCount++;
      sellCountText.text = currentSellCount.ToString();
    }
    else
    {
      //버튼 비활성화 
      Debug.Log("비활성화");
    }



  }

  public void onMinusButton()
  {
    if (currentSellCount > 0) // 최소 0개까지 감소 가능
    {
      currentSellCount--;
      sellCountText.text = currentSellCount.ToString();
    }
    else
    {
      Debug.Log("버튼 비활성화");
    }
  }

  public void sellButton()
  {


    Debug.Log("팔렸습니다.");
    Debug.Log(key);
    UserBracelet userBracelet = User.Instance.GetUserBracelet(key);


    //User.Instance.GetUserBracelet(braceletKey);
    // userBracelet.count -= currentSellCount;
    User.Instance.SubBracelet(key, currentSellCount);

    BraceletData braceletData = BraceletManager.Instance.GetBraceletData(key);
    User.Instance.AddCoin(braceletData.price);
    


  }



  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
  //멤버변수와 함수 갯수 
}
