using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _text;

    private float _previousValue;
    private float _currentValue;
    private float _recoveryRate = 50f;
    private Coroutine _activeCoroutine;

    private void OnEnable()
    {
        Player.OnHealthUpdated += UpdateView;
    }

    private void OnDisable()
    {
        Player.OnHealthUpdated -= UpdateView;
    }

    private void UpdateView(int health)
    {
        _currentValue = (float)health;
        _text.text = $"Health: {_currentValue.ToString()}";

        if (_previousValue == 0)
        {
            _previousValue = _currentValue;
            _slider.value = _currentValue;
        }
        else
        {
            if (_activeCoroutine != null)
                StopCoroutine(_activeCoroutine);
            _activeCoroutine = StartCoroutine(SmoothUpdate());
        }
    }

    private IEnumerator SmoothUpdate()
    {
        while (_previousValue != _currentValue)
        {
            _slider.value = Mathf.MoveTowards(_previousValue, _currentValue, _recoveryRate * Time.deltaTime);
            _previousValue = _slider.value;
            yield return null;
        }
    }
}
