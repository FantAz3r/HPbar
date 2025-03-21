using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class DamageButton : ChangeValueButton
{
    protected override void HandleButtonClick()
    {
        Health.TakeDamage(ChangeValue);
        Debug.Log(" нопка была нажата!");
    }
}