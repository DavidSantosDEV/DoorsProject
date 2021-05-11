using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystemHeart : MonoBehaviour
{
    private HeartVisuals _visuals;



    private float _maxHealth;
    public float MaxHealth
    {
        get => _maxHealth;
        set => _maxHealth = Mathf.Clamp(Mathf.RoundToInt(value),0,float.MaxValue);
    }
    private float curhealth;


    void Start()
    {
        curhealth = _maxHealth;
    }

    public void TakeDamage(float damage) 
    {
        double dmg = System.Math.Round(damage, 2);// Mathf.Round(damage);
    }


}
