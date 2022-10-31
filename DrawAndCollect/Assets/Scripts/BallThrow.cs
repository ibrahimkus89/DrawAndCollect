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
    public static int numberOfBallsThrown;
    public static int TaSys;


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

                if (TaSys !=0 && TaSys %5 ==0)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        BallThrowAndSettings();
                    }
                    numberOfBallsThrown = 2;
                    TaSys++;
                }
                else
                {
                    BallThrowAndSettings();
                    numberOfBallsThrown = 1;
                    TaSys++;
                }
                
                yield return new WaitForSeconds(0.7f);
                randomBucketIndex = Random.Range(0, BucketPoints.Length - 1);
                Bucket.transform.position = BucketPoints[randomBucketIndex].transform.position;
                Bucket.SetActive(true);
                klt = true;
                Invoke("BallControl",5f);
            }
            else
            {
                yield return null;
            }
        }
    }


   
    public void Continue()
    {
        if (numberOfBallsThrown==1)
        {
            klt = false;
            Bucket.SetActive(false);
            CancelInvoke();
            numberOfBallsThrown--;
        }
        else
        {
            numberOfBallsThrown--;
        }

       
    }

    float GetAngle(float Value1,float Value2)
    {
        return Random.Range(Value1, Value2);

    }

    Vector3 GetPosition(float glnAngle)
    {
       return Quaternion.AngleAxis(glnAngle, Vector3.forward) * Vector3.right;
    }
    void BallControl()
    {
        if (klt)
        {
            GetComponent<GameManager>().GameOver();
        }
    }

    void BallThrowAndSettings()
    {
        Balls[activeBallIndex].transform.position = BallThrowCenter.transform.position;
        Balls[activeBallIndex].SetActive(true);
        Balls[activeBallIndex].gameObject.GetComponent<Rigidbody2D>().AddForce(GetPosition(GetAngle(70f, 110f)) * 750);

        if (activeBallIndex != Balls.Length - 1)
        {
            activeBallIndex++;

        }
        else
        {
            activeBallIndex = 0;
        }
    }
}