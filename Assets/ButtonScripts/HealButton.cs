using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Health))]
public class HealButton : ChangeValueButton
{
    protected override void HandleButtonClick()
    {
        Health.Heal(ChangeValue);
        Debug.Log(" нопка была нажата!");
    }
}