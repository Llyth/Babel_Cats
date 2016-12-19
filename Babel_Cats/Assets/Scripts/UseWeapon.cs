using UnityEngine;
using System.Collections;

public class UseWeapon : MonoBehaviour
{
    private CharacterHandlingController _characterHandlingController;
    public bool _isWeaponAttach;

    void Start()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        _characterHandlingController = GetComponentInParent<CharacterHandlingController>();
        _isWeaponAttach = false;
        gameObject.SetActive(false);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (_isWeaponAttach && _characterHandlingController._attack && _characterHandlingController._charactersClass.CooldownAttack > 0
                && _characterHandlingController._charactersClass.DurabilityWeapon > 0)
            {
                if (coll.gameObject.GetComponent<HitByPlayer>().hasBeenHit() == true)
                    _characterHandlingController._charactersClass.DurabilityWeapon--;
                if (_characterHandlingController._charactersClass.DurabilityWeapon <= 0)
                {
                    _isWeaponAttach = false;
                    gameObject.SetActive(false);
                }
            }
        }

    }

    public void rechargeDurability()
    {
        gameObject.SetActive(true);
        if (_characterHandlingController._charactersClass != null)
            _characterHandlingController._charactersClass.DurabilityWeapon = _characterHandlingController._charactersClass.MaxDurabilityWeapon;
        _isWeaponAttach = true;
    }
}
