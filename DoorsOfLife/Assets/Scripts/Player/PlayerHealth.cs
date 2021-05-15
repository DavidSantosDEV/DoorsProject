using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthComponent
{
    [Header("RumbleHit")]
    [SerializeField]
    private float lowStart = 1;
    [SerializeField]
    private float lowEnd = 1;
    [SerializeField]
    private float highStart = 1;
    [SerializeField]
    private float highEnd = 1;
    [SerializeField]
    private float tDivisor=10;


    //private PlayerAnimation _playerAnimation;
    private PlayerController _parent;
    protected override void Start()
    {
        base.Start();
        _parent = GameManager.Instance.GetPlayer();
    }

    public override void TakeDamage(float dmgVal)
    {
        base.TakeDamage(dmgVal);
        _parent.PlayerAnimationComponent.PlayHitAnimation();
        UIManager.Instance.UpdateHealth(currentHealth, MaxHealth);
        float t = dmgVal / MaxHealth * 0.8f;
        CameraShake.Instance.AddTrauma(t);
        GamepadRumbler.Instance.RumbleLinear(lowStart,lowEnd,highStart,highEnd, t / tDivisor);
    }

    protected override void Die()
    {
        base.Die();
        _parent.PlayerAnimationComponent.PlayDeathAnimation();
        _parent.OnIsDead();
        GameManager.Instance.ShowGameOver();  
    }
}
