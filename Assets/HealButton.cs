using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _healAmount;

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
        _health.Heal(_healAmount);
        Debug.Log(" нопка была нажата!");
    }
}