using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _health = 100;

    public bool IsDead => _health <= 0;
    public event UnityAction<int> HealthUpdated;
    public event UnityAction Hurt;
    public event UnityAction Healed;
    public event UnityAction Dead;
    public event UnityAction Recovered;
    public event UnityAction Ressurected;

    public int MaxHealth => _maxHealth;

    private void Start()
    {
        HealthUpdated?.Invoke(_health);
    }

    public void TakeDamage(int damageAmount)
    {
        if (IsDead)
            return;

        _health = Mathf.Clamp(_health - damageAmount, _minHealth, _maxHealth);

        if (IsDead)
            Dead?.Invoke();
        else
            Hurt?.Invoke();

        HealthUpdated?.Invoke(_health);
    }

    public void Heal(int healAmount)
    {
        if (IsDead)
            return;

        _health = Mathf.Clamp(_health + healAmount, _minHealth, _maxHealth);

        if (_health == _maxHealth)
            Recovered.Invoke();
        else
            Healed?.Invoke();

        HealthUpdated?.Invoke(_health);
    }

    public void Resurrect()
    {
        _health = _maxHealth;
        Ressurected?.Invoke();
        HealthUpdated?.Invoke(_health);
    }
}
