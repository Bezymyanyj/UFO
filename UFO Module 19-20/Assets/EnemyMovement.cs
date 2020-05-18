using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] points;

    public float speed = 2f;

    private Transform targetPoint;
    private int currentPoint;
    private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        currentPoint = 0;
        targetPoint = points[currentPoint];
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position == targetPoint.position){
            if(forward){
                currentPoint++;
            }
            else{
                currentPoint--;
            }
        }
        if(currentPoint >= points.Length){
            currentPoint = points.Length - 2;
            forward = false;
        }
        if(currentPoint <= 0){
            currentPoint = 1;
            forward = true;
        }
        targetPoint = points[currentPoint];

        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetPoint.position, speed * Time.deltaTime);
    }
}
