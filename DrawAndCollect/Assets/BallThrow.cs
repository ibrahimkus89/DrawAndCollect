using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    [SerializeField] private GameObject[] Balls;
    [SerializeField] private GameObject BallThrowCenter;

    int activeBallIndex;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Balls[activeBallIndex].transform.position = BallThrowCenter.transform.position;
            Balls[activeBallIndex].SetActive(true);

            float angle = Random.Range(70f,110f);
            Vector2 pos = Quaternion.AngleAxis(angle,Vector3.forward) * Vector3.right;
            Balls[activeBallIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(pos * 750);

            if (activeBallIndex!=Balls.Length-1)
            {
                activeBallIndex++;

            }
            else
            {
                activeBallIndex = 0;
            }

        }
    }
}