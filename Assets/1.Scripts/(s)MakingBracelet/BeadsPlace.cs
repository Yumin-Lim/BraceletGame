using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeadsPlace : MonoBehaviour
{
    public BeadsPlaceCorrect beadsPlaceCorrect;
    public Beads beads;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void SetBeads(Beads b)
{
    beads = b;

    if (beads != null)
    {
        beads.transform.position = transform.position;
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
