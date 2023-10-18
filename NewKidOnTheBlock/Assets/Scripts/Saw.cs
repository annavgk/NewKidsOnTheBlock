using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Obstacle
{
    [SerializeField] private GameObject _endPosition;
    [SerializeField] private float _speed = .2f;
    private Vector3 startPosition;
    private Vector3 _target;
    private Vector3 endPosition;

    private void Awake()
    {
        startPosition = transform.position;
        endPosition = _endPosition.transform.position;
    }

    private void FixedUpdate()
    {

        if (transform.position == startPosition)
        {
            _target = endPosition;
        }
        if (transform.position == endPosition)
        {
            _target = startPosition;
        }
        this.transform.position = Vector3.MoveTowards(this.transform.position, _target, _speed * Time.deltaTime);

    }



}   
