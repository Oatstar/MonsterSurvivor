using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponColliderController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            //Debug.Log("Monster hit!");
            collision.GetComponent<MonsterController>().TakeDamage(10);
        }
    }
}
