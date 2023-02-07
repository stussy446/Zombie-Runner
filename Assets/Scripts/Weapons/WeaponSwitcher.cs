using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    Weapon[] weapons;
    int currentWeaponIndex = 0;

    private void Awake()
    {
        weapons = GetComponentsInChildren<Weapon>(true);
        DeactivateAllWeapons();

        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    public void SetActiveWeapon()
    {
        DeactivateWeapon();

        currentWeaponIndex++;
        if (currentWeaponIndex == weapons.Length)
        {
            currentWeaponIndex = 0;
        }

        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    private void DeactivateWeapon()
    {
        weapons[currentWeaponIndex].gameObject.SetActive(false);
    }

    public void DeactivateAllWeapons()
    {
        foreach (Transform weapon in transform)
        {
            weapon.gameObject.SetActive(false);
        }
    }
}
