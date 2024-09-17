using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer_code : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "cleanup")
        {
            Destroy(collision.gameObject);
        }
    }
}

