using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //If bullet touches enemy, lower enemy health by 33 and destroy bullet
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<enemyconttroll>().health -= 33f;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
