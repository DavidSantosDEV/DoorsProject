using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
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
public class DialogueAndEvent
{
    public string Sentence;
    public UnityEvent SentenceEvent = null;
    public CharacterReaction reaction;
    public AudioClip sound;
}
