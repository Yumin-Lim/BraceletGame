using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBeadsSys : MonoBehaviour
{
    public GameObject panelLevel_10;
    public int openLevel;

    
        // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnEnable()
    {
        if(User.Instance.userData.level >= openLevel)
        {
            this.panelLevel_10.SetActive(false);
        }
        else
        {
            this.panelLevel_10.SetActive(true);
        }
    }
    // Update is called once per frame
    void Update()
    {
      

    }



}
