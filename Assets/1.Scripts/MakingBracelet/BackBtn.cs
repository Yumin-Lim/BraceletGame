using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackBtn : MonoBehaviour
{

  public GameObject shopPannel;
  public GameObject shop1Pannel;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }


  public void OnClickedButton()
  {
   ReGettingBeads();
   SceneManager.LoadScene("Lobby");


  }
    public void ReGettingBeads()
{
    // MakingBraceletManager 인스턴스 찾기
    MakingBraceletManager mgr = FindAnyObjectByType<MakingBraceletManager>();

    

    // 빈 공간이 있는 경우(즉, 비즈가 다 차지 않은 경우)
    if (mgr.haveEmptyPlace==false)
    {
        Debug.Log("아직 다 안채워져서 비즈최수");

        User user = User.Instance;

        foreach (Beads bead in mgr.currentBeads)
        {
         
            user.AddBeads(mgr.beadsKey, 1);
        }

        // currentBeads 리스트 비우기

    }
    else
    {
        Debug.Log(" 비즈를 회수X.");
    }
}


    public void ShopPannelCloseButton()
  {
    shopPannel.SetActive(false);
  }
  public void Shop1PannelCloseButton()
  {
    shop1Pannel.SetActive(false);
  }
}
