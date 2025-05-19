using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToStreetButton : MonoBehaviour
{
  //public GameObject lobbyStreetPanel ;

  public StreetType streetType;
  
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
    StreetManager mgr = FindObjectOfType<StreetManager>();
    mgr.MoveTo(streetType);
   
  }

}
