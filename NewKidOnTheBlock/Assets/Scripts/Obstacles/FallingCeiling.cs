using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingCeiling : Obstacle
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed = .2f;
    private void FixedUpdate()
    { 
         this.transform.position = Vector3.MoveTowards(this.transform.position, _target.transform.position, _speed * Time.deltaTime);
    }


}
