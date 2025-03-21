using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class DamageButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _damage;

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
    }

    protected void OnEnable()
    {
        _button.onClick.AddListener(HandleButtonClick);
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(HandleButtonClick);
    }

    private void HandleButtonClick()
    {
        _health.TakeDamage(_damage);
        Debug.Log(" нопка была нажата!");
    }
}