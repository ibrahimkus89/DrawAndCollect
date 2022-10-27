using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrow : MonoBehaviour
{
    [SerializeField] private GameObject[] Balls;
    [SerializeField] private GameObject BallThrowCenter;
    [SerializeField] private GameObject Bucket;
    [SerializeField] private GameObject[] BucketPoints;



    int activeBallIndex;
    int randomBucketIndex;
    bool klt;


    public void GameStart()
    {
        StartCoroutine(BallShootingSystem());
    }

    IEnumerator BallShootingSystem()
    {
        while (true)
        {

            if (!klt)
            {
                yield return new WaitForSeconds(.5f);
                Balls[activeBallIndex].transform.position = BallThrowCenter.transform.position;
                Balls[activeBallIndex].SetActive(true);

                float angle = Random.Range(70f, 110f);
                Vector2 pos = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
                Balls[activeBallIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(pos * 750);

                if (activeBallIndex != Balls.Length - 1)
                {
                    activeBallIndex++;

                }
                else
                {
                    activeBallIndex = 0;
                }

                yield return new WaitForSeconds(0.7f);
                randomBucketIndex = Random.Range(0, BucketPoints.Length - 1);
                Bucket.transform.position = BucketPoints[randomBucketIndex].transform.position;
                Bucket.SetActive(true);
                klt = true;
            }
            else
            {
                yield return null;
            }
        }
    }


   
    public void Continue()
    {
        klt = false;
        Bucket.SetActive(true);
    }
}