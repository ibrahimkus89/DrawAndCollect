using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ballin"))
        {
            gameObject.SetActive(false);
        }
        else if (collision.gameObject.CompareTag("GameOver"))
        {
            gameObject.SetActive(false);
        }
    }
}
