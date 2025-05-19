using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadsPlace : MonoBehaviour
{

    public Beads beads;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetBeads(Beads b) //이걸 호출하면 
    {
        beads=b;
        beads.transform.position = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
