using TMPro;
using UnityEngine;

public class TextIndicator : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

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
        _text.text = $"{((int)currentHealth)}/{_health.MaxHealth}";
    }
}
