using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBeadsSys : MonoBehaviour
{
    public GameObject panelLevel_10;
    public int level;

    
        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.level = User.Instance.level;    

        if(level==1)
        {
            this.panelLevel_10.SetActive(false);
        }

    }



}
