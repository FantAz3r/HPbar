using UnityEngine;
using UnityEngine.UI;

public abstract class ChangeValueButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private int _changeValue;

    private Health _health;
    
    protected Health Health => _health;
    protected int ChangeValue => _changeValue;

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

    protected abstract void HandleButtonClick();
}
