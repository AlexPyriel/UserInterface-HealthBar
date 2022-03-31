using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        Player.Dead += OnPlayerDied;
        Player.Hurt += OnPlayerHurt;
        Player.Healed += OnPlayerHealed;
        Player.Recovered += OnPlayerRecovered;
        Player.Ressurected += OnPlayerRessurected;
    }

    private void OnDisable()
    {
        Player.Dead -= OnPlayerDied;
        Player.Hurt -= OnPlayerHurt;
        Player.Healed -= OnPlayerHealed;
        Player.Recovered -= OnPlayerRecovered;
        Player.Ressurected -= OnPlayerRessurected;
    }

    private void OnPlayerDied()
    {
        _animator.SetTrigger(PlayerAnimations.Die);
    }

    private void OnPlayerHurt()
    {
        _animator.SetTrigger(PlayerAnimations.Hurt);
    }

    private void OnPlayerHealed()
    {
        _animator.SetTrigger(PlayerAnimations.Heal);
    }

    private void OnPlayerRecovered()
    {
        _animator.SetTrigger(PlayerAnimations.Recover);
    }

    private void OnPlayerRessurected()
    {
        _animator.SetTrigger(PlayerAnimations.Resurrect);
    }
}
