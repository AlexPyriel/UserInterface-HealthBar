using UnityEngine;

[RequireComponent(typeof(Animator))]

public class PlayerAnimator : MonoBehaviour
{
    [SerializeField] private Player _player;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _player.Dead += OnDead;
        _player.Hurt += OnHurt;
        _player.Healed += OnHealed;
        _player.Recovered += OnRecovered;
        _player.Ressurected += OnRessurected;
    }

    private void OnDisable()
    {
        _player.Dead -= OnDead;
        _player.Hurt -= OnHurt;
        _player.Healed -= OnHealed;
        _player.Recovered -= OnRecovered;
        _player.Ressurected -= OnRessurected;
    }

    private void OnDead()
    {
        _animator.SetTrigger(PlayerAnimations.Die);
    }

    private void OnHurt()
    {
        _animator.SetTrigger(PlayerAnimations.Hurt);
    }

    private void OnHealed()
    {
        _animator.SetTrigger(PlayerAnimations.Heal);
    }

    private void OnRecovered()
    {
        _animator.SetTrigger(PlayerAnimations.Recover);
    }

    private void OnRessurected()
    {
        _animator.SetTrigger(PlayerAnimations.Resurrect);
    }
}
