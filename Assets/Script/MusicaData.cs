using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MusicaData", menuName = "MusicaData", order = 1)]
public class MusicaData : ScriptableObject
{
    public Aud[] h;

}

[Serializable]
public class Aud
{
    [Header("AudioSource")]
    public AudioSource[] hit;

}

public enum WillDo { LoadScene, NextQuestion, }