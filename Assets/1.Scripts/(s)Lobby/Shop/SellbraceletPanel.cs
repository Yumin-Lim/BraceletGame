using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System.Data.Common;
using System.Data;
using UnityEditor.Rendering;
using System;
public class SellbraceletPanel : MonoBehaviour
{


  public Image thumImage;
  public static SellbraceletPanel Instance;
  public UserBracelet userBracelet;

  public void Awake()
  {
    Instance = this;


    Capture.Instance.pictureSet(userBracelet.key); //이건 어차피 의미가 없다 늦게 불려지니까 
    
    
  }

  public void SetBracelet(UserBracelet userBracelet)
  {
    this.userBracelet = userBracelet;
      thumImage.sprite = userBracelet.thum;
  }

  public void sellButton()
  {

    Debug.Log("팔렸습니다.");

    User.Instance.SubBracelet(userBracelet);
    
    BraceletData braceletData = BraceletManager.Instance.GetBraceletData(userBracelet.key);


    // User.Instance.AddCoin(User.Instance.GetUserBracelet.price);


    gameObject.SetActive(false);

  }

 

  void Start()
  {
    thumImage.sprite = userBracelet.thum;
  }

  // Update is called once per frame
  void Update()
  {

  }

  internal void SetBracelet(string questKey)
  {
    throw new NotImplementedException();
  }
  //멤버변수와 함수 갯수 
}
