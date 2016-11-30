using UnityEngine;
using System.Collections;

public class ObjectDestroyerScript : MonoBehaviour
{
    // Trigger that destroys 2D object on collision
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.parent)
            Destroy(other.gameObject.transform.parent.gameObject);
        Destroy(other.gameObject);
    }
}
