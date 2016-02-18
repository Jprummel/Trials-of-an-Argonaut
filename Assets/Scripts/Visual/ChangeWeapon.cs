using UnityEngine;
using System.Collections;

public class ChangeWeapon : MonoBehaviour 
{
    [SerializeField]private GameObject _swordEquipped;
    [SerializeField]private GameObject _spearEquipped;
    [SerializeField]private GameObject _shieldEquipped;

    [SerializeField]private GameObject _swordNotEquipped;
    [SerializeField]private GameObject _spearNotEquipped;
    [SerializeField]private GameObject _shieldNotEquipped;

    void Start()
    {
        EquipSwordAndShield();
    }

    
    public void EquipSwordAndShield()
    {
        _swordEquipped.SetActive(true);
        _swordNotEquipped.SetActive(false);

        _spearEquipped.SetActive(false);
        _spearNotEquipped.SetActive(true);

        _shieldEquipped.SetActive(true);
        _shieldNotEquipped.SetActive(false);
    }

    public void EquipSpear()
    {
        _swordEquipped.SetActive(false);
        _swordNotEquipped.SetActive(true);

        _spearEquipped.SetActive(true);
        _spearNotEquipped.SetActive(false);

        _shieldEquipped.SetActive(false);
        _shieldNotEquipped.SetActive(true);
    }
}
