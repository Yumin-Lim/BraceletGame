using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SoundInfo", menuName = "Sound/SoundInfo", order = 0)]
public class SoundInfo : ScriptableObject {
    public SoundType soundType;
    public AudioClip clip;
}
public enum SoundType
{
    Click,
    Purchase,
    Beads,
    Reward,

}