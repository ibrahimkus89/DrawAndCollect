using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ballin"))
        {
            gameObject.SetActive(false);
            _gameManager.Continue(transform.position);
        }
        else if (collision.gameObject.CompareTag("GameOver"))
        {
            _gameManager.GameOver();
            gameObject.SetActive(false);
        }
    }
}
