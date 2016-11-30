using UnityEngine;
using System.Collections;

public class UseWeapon : MonoBehaviour
{
    private CharacterHandlingController _characterHandlingController;
    public bool _isWeaponAttach;
    public int _durability;

    void Start()
    {
        gameObject.GetComponent<Collider2D>().enabled = false;
        _characterHandlingController = GetComponentInParent<CharacterHandlingController>();
        _isWeaponAttach = false;
        _durability = 0;
        gameObject.SetActive(false);
    }

    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (_isWeaponAttach && _characterHandlingController._attack && _characterHandlingController._cooldownAttack > 0 && _durability > 0)
            {
                if (coll.gameObject.GetComponent<HitByPlayer>().hasBeenHit() == true)
                    _durability--;
                if (_durability <= 0)
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
        _durability = 5;
        _isWeaponAttach = true;
    }
}
