using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Drawline : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject line;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPosList;
    public List<GameObject> liness;
    [SerializeField] private TextMeshProUGUI rightToDrawText;

    int rightToDraw;
   
    void Start()
    {
        
        rightToDraw = 3;
        rightToDrawText.text = rightToDraw.ToString();
    }

    
    void Update()
    {
        if (Time.timeScale!=0 && rightToDraw !=0)
        {

            if (Input.GetMouseButtonDown(0))
            {
                CreateLine();
            }
            if (Input.GetMouseButton(0))
            {
                Vector2 fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                if (Vector2.Distance(fingerPos, fingerPosList[^1]) > .1f)
                {
                    LineUpdate(fingerPos);
                }
            }
        }

        if (liness.Count !=0 && rightToDraw !=0)
        {
            if (Input.GetMouseButtonUp(0))
            {
                rightToDraw--;
                rightToDrawText.text = rightToDraw.ToString();

            }
        }
    }

    void CreateLine()
    {
        line = Instantiate(linePrefab,Vector2.zero,Quaternion.identity);
        liness.Add(line);
        lineRenderer = line.GetComponent<LineRenderer>();
        edgeCollider = line.GetComponent<EdgeCollider2D>();
        fingerPosList.Clear();
        fingerPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        fingerPosList.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        lineRenderer.SetPosition(0,fingerPosList[0]);
        lineRenderer.SetPosition(1, fingerPosList[1]);
        edgeCollider.points = fingerPosList.ToArray();

    }


    void LineUpdate(Vector2 GetFingerPos)
    {
        fingerPosList.Add(GetFingerPos);
        lineRenderer.positionCount++;
        lineRenderer.SetPosition(lineRenderer.positionCount-1,GetFingerPos);
        edgeCollider.points = fingerPosList.ToArray();

    }

    public void Continue()
    {
        foreach (var item in liness)
        {
            Destroy(item.gameObject);
        }

        liness.Clear();
        rightToDraw=3;
        rightToDrawText.text = rightToDraw.ToString();

    }

    public void StartDraw()
    {
        rightToDraw = 3;
    }
}
