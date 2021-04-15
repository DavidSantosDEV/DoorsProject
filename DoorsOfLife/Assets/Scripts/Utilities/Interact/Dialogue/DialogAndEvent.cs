using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterReaction
{
    Normal,
    Happy,
    Impressed,
    Angry,
    Sad,
    Bored
}


[System.Serializable] 
public class DialogAndEvent
{
    public string Sentence;
    public DialogEventBase SentenceEvent = null;
    public CharacterReaction reaction;
    public AudioClip sound;
}
