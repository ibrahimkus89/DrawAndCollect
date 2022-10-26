using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallThrow _ballThrow;
    [SerializeField] private Drawline _drawline;


    void Start()
    {
        
    }

  
    void Update()
    {
        
    }


    public void Continue()
    {
        _ballThrow.Continue();
        _drawline.Continue();
    }

    public void GameOver()
    {
        Debug.Log("LOST");
    }
}
