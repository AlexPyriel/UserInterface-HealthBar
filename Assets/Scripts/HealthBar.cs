using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    private float _currentValue;
    private float _recoveryRate = 50f;
    private Coroutine _activeCoroutine;

    private void OnEnable()
    {
        Player.HealthUpdated += UpdateView;
    }

    private void OnDisable()
    {
        Player.HealthUpdated -= UpdateView;
    }

    private void UpdateView(int health)
    {
        if (_currentValue == 0)
            _slider.value = health;

        _currentValue = _slider.value;

        _text.text = $"Health: {health.ToString()}";

        if (_activeCoroutine != null)
            StopCoroutine(_activeCoroutine);
        _activeCoroutine = StartCoroutine(SmoothUpdate(health));
    }

    private IEnumerator SmoothUpdate(float health)
    {
        while (health != _currentValue)
        {
            _slider.value = Mathf.MoveTowards(_currentValue, health, _recoveryRate * Time.deltaTime);
            _currentValue = _slider.value;
            yield return null;
        }
    }
}
