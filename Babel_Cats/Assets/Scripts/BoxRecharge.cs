using UnityEngine;
using System.Collections;

public class BoxRecharge : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            if (!coll.gameObject.transform.GetChild(2).GetComponent<UseWeapon>()._isWeaponAttach)
            {
                coll.gameObject.transform.GetChild(2).GetComponent<UseWeapon>().rechargeDurability();
                gameObject.SetActive(false);
            }
        }
    }
}
