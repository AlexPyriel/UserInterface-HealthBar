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
        _player.Dead += OnPlayerDied;
        _player.Hurt += OnPlayerHurt;
        _player.Healed += OnPlayerHealed;
        _player.Recovered += OnPlayerRecovered;
        _player.Ressurected += OnPlayerRessurected;
    }

    private void OnDisable()
    {
        _player.Dead -= OnPlayerDied;
        _player.Hurt -= OnPlayerHurt;
        _player.Healed -= OnPlayerHealed;
        _player.Recovered -= OnPlayerRecovered;
        _player.Ressurected -= OnPlayerRessurected;
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
