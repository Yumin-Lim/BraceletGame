using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStreetButton : MonoBehaviour
{
  //public GameObject lobbyStreetPanel ;


  public GameObject camera;
  public Transform shoptr;
  public Transform lobbyTr;
  // Start is called before the first frame update



  void Start()


  {


  }
  // Update is called once per frame
  void Update()
  {

  }


  public void OnClikedButton()
  {

    if (camera.transform.position == lobbyTr.position)
    {


      camera.transform.position = shoptr.position;

    }
    else
    {

      camera.transform.position = lobbyTr.position;
    }
  }

}
