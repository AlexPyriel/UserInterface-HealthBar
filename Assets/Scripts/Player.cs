using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] private AudioClip _die;
    [SerializeField] private AudioClip _hurt;
    [SerializeField] private AudioClip _heal;

    private Animator _animator;
    private AudioSource _audioSource;
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _health = 100;
    private int _damageAmount = 10;
    private int _healAmount = 10;

    public bool IsDead => _health <= 0;
    public static Action<int> OnHealthUpdated;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        OnHealthUpdated?.Invoke(_health);
    }

    public void TakeDamage()
    {
        if (IsDead) return;

        if (_health - _damageAmount <= _minHealth)
        {
            _health = _minHealth;
            _animator.SetTrigger(PlayerAnimations.Die);
            _audioSource.PlayOneShot(_die);
        }
        else
        {
            _health -= _damageAmount;
            _animator.SetTrigger(PlayerAnimations.Hurt);
            _audioSource.PlayOneShot(_hurt);
        }

        OnHealthUpdated?.Invoke(_health);
    }

    public void ApplyHeal()
    {
        if (IsDead) return;

        if (_health + _healAmount >= _maxHealth)
        {
            _health = _maxHealth;
            _animator.SetTrigger(PlayerAnimations.Recover);
        }
        else
        {
            _health += _healAmount;
            _animator.SetTrigger(PlayerAnimations.Heal);
        }

        OnHealthUpdated?.Invoke(_health);
        _audioSource.PlayOneShot(_heal);
    }

    public void Resurrect()
    {
        _health = _maxHealth;
        _animator.SetTrigger(PlayerAnimations.Resurrect);
        OnHealthUpdated?.Invoke(_health);
    }
}
