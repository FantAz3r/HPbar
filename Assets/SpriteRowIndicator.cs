using UnityEngine;

public class SpriteRowIndicator : MonoBehaviour
{
    [SerializeField] private RectTransform _healthSprite;

    private Health _health;
    private float _healthPercentage;
    private float _spriteSize;

    private void Awake()
    {
        _health = GetComponent<Health>();
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
        _healthPercentage = currentHealth / _health.MaxHealth;
        _healthSprite.sizeDelta = new Vector2(_healthPercentage * _spriteSize, _healthSprite.sizeDelta.y);
    }
}
