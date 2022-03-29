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
    // private Vector3 _startPosition;
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _health = 100;
    private int _damageAmount = 10;
    private int _healAmount = 10;

    // public int Health { get => _health; }

    public static Action<int> OnHealthUpdated;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
        // _startPosition = transform.position;
    }

    private void Start()
    {
        OnHealthUpdated?.Invoke(_health);
    }

    public void TakeDamage()
    {
        if (_health - _damageAmount <= _minHealth)
        {
            _health = _minHealth;
            _audioSource.PlayOneShot(_die);
        }
        else
        {
            _health -= _damageAmount;
            _audioSource.PlayOneShot(_hurt);
        }

        OnHealthUpdated?.Invoke(_health);
    }

    public void ApplyHeal()
    {
        if (_health + _healAmount > _maxHealth)
            _health = _maxHealth;
        else
            _health += _healAmount;

        OnHealthUpdated?.Invoke(_health);

        _audioSource.PlayOneShot(_heal);
    }
}
