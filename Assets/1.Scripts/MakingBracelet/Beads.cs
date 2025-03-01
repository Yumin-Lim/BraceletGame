using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beads : MonoBehaviour
{
    public string beadsKey;
    public SpriteRenderer spriteRdr;
    public void SetBeads(string beadsKey)
    {
        this. beadsKey = beadsKey;
        spriteRdr.sprite = BeadsManager.Instance.GetBeadsData(beadsKey).thum;
    }


//변수 종류 3개 멤버변수, 매개변수, 지역변수 -> 멤버변수 써야함 

    
    
    
}
