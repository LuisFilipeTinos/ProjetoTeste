using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyierController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Gem"))
            Destroy(collision.gameObject);
    }
}
