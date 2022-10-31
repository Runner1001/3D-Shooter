using UnityEngine;

public abstract class WeaponComponent : MonoBehaviour
{
    protected Weapon weapon;

    protected abstract void WeaponFired();

    protected virtual void Awake()
    {
        weapon = GetComponent<Weapon>();
        weapon.OnFire += WeaponFired;
    }

    void OnDestroy()
    {
        weapon.OnFire -= WeaponFired;
    }
}
