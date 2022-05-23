using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bananas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            PlayerManager.numberOfBananas++;
            Destroy(gameObject);
        }
    }
}
