using UnityEngine;
using System;

/*
2. Работу со здоровьем следует отделить от работы с анимациями, так как это разные ответственности. 
В этом плане работа с анимациями больше похожа на работу HealthBar'а, так как и то и то должно реагировать на игрока через его событие 
*/

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _health = 100;

    public bool IsDead => _health <= 0;
    public static Action<int> HealthUpdated;
    public static Action Hurt;
    public static Action Healed;
    public static Action Dead;
    public static Action Recovered;
    public static Action Ressurected;

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
