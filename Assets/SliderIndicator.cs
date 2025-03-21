using UnityEngine;
using UnityEngine.UI;

public class SliderIndicator : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
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
        _slider.value = currentHealth / _health.MaxHealth;
    }
}
