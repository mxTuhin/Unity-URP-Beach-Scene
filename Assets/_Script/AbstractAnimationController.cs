using System.Collections;
using System.Collections.Generic;
using Cinemachine.Utility;
using UnityEngine;

public class AbstractAnimationController : MonoBehaviour
{
    [Header("Abstract Animation Controller")]
    [SerializeField] private bool shouldAnim;
    private Animator _animator;

    private float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        primaryPos = transform.position;
        if(!shouldAnim)
            return;
        _animator = GetComponent<Animator>();


    }
    

    // Update is called once per frame
    void Update()
    {
        if(shouldAnim)
            waypointChaser();
        
    }
    #region waypointChaser

    [Header("waypointChaser")] public Vector3[] target;

    private int pointIndex = 0;
    private float minDist = 0.5f;
    [SerializeField]private bool shouldStop = false;
    private Vector3 primaryPos;
    
    void waypointChaser()
    {
        // print(primaryPos);
        //get the distance between the chaser and the target
        float distance = Vector3.Distance(transform.position,primaryPos+target[pointIndex]);
        //so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
        if (distance > minDist)
        {
            transform.position = Vector3.MoveTowards(transform.position, primaryPos+target[pointIndex], speed*Time.deltaTime);
            speed = Random.Range(2, 4);
        }
        else
        {
            if (shouldStop)
            {
                if (pointIndex < target.Length - 1)
                {
                    pointIndex += 1;
                }
            }
                
            else
            {
                pointIndex = (pointIndex+ 1) % target.Length;
            }
                
        }
    }
    #endregion
    
    
}
