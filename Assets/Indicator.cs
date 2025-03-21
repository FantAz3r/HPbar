using UnityEngine;

public abstract class Indicator : MonoBehaviour
{
    [SerializeField] private  Health _health;

    protected Health Health => _health;

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

    public abstract void ViewIndicator(float currentHealth);
}
