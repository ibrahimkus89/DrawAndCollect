using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawline : MonoBehaviour
{
    [SerializeField] GameObject linePrefab;
    [SerializeField] GameObject line;

    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] EdgeCollider2D edgeCollider;
    public List<Vector2> fingerPosList;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 fingerPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Vector2.Distance(fingerPos,fingerPosList[^1]) >.1f)
            {
                LineUpdate(fingerPos);
            }
        }
    }

    void CreateLine()
    {
        line = Instantiate(linePrefab,Vector2.zero,Quaternion.identity);
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
}
