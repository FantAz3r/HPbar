using System.Collections;
using UnityEngine;

public class SpriteLerpIndicator : MonoBehaviour
{
    [SerializeField] private RectTransform _healthSprite;
    [SerializeField] private float _spriteSpeed = 0.05f;

    private Health _health;
    private float _smoothHealth;
    private float _healthPercentage;
    private float _spriteSize;
    private Coroutine _currentCoroutine;

    private void Awake()
    {
        _health = GetComponent<Health>();
        _smoothHealth = _health.MaxHealth;
        _spriteSize = _healthSprite.sizeDelta.x;
    }

    private void OnEnable()
    {
        _health.Healed += ViewIndicator;
        _health.IsDamageTaken += ViewIndicator;
    }

    private void OnDisable()
    {
        _health.Healed -= ViewIndicator;
        _health.IsDamageTaken -= ViewIndicator;
    }

    public void ViewIndicator(float currentHealth)
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(SmoothHealthTransition(currentHealth));
    }

    private IEnumerator SmoothHealthTransition(float targetHealth)
    {
        while (_smoothHealth != targetHealth)
        {
            _smoothHealth = Mathf.Lerp(_smoothHealth, targetHealth, _spriteSpeed);
            _healthPercentage = _smoothHealth / _health.MaxHealth;
            _healthSprite.sizeDelta = new Vector2(_healthPercentage * _spriteSize, _healthSprite.sizeDelta.y);
            yield return null;
        }
    }
}

