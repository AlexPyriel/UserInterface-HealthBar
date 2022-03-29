using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _health = 100;
    private int _damageAmount = 10;
    private int _healAmount = 10;

    // public int Health { get => _health; }

    public static Action<int> OnHealthUpdated;

    private void Start()
    {
        OnHealthUpdated?.Invoke(_health);
    }

    public void TakeDamage()
    {
        if (_health - _damageAmount < _minHealth)
            _health = _minHealth;
        else
            _health -= _damageAmount;

        OnHealthUpdated?.Invoke(_health);
    }

    public void ApplyHeal()
    {
        if (_health + _healAmount > _maxHealth)
            _health = _maxHealth;
        else
            _health += _healAmount;

        OnHealthUpdated?.Invoke(_health);
    }
}
