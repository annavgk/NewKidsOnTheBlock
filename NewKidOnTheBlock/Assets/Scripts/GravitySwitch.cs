using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour
{

    //[SerializeField]private  BoxCollider2D _collider;
    [SerializeField] private string direction;

    [SerializeField] private string secondaryDirection;
    [SerializeField] private bool _edge;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            if(other?.GetComponent<TriangleController>()?.gameObject.activeSelf == true)
            {
                Debug.Log("a");
                switch (direction)
                {
                    case "up":
                        if (Physics2D.gravity == new Vector2(0, 9.8f))
                        {
                            Secondary();
                            break;
                        }

                        if (_edge == true) //moves player to edge to stop them from falling
                        {
                            other.GetComponentInParent<Transform>().position = transform.position;
                        }
                        Physics2D.gravity = new Vector2(0, 9.8f);
                        break;
                    case "down":
                        if (Physics2D.gravity == new Vector2(0, -9.8f))
                        {
                            Secondary();
                            break;
                        }

                        if (_edge == true) //moves player to edge to stop them from falling
                        {
                            other.GetComponentInParent<Transform>().position = transform.position;
                        }
                        Physics2D.gravity = new Vector2(0, -9.8f);
                        break;
                    case "left":
                        if (Physics2D.gravity == new Vector2(-9.8f, 0))
                        {
                            Secondary();
                            break;
                        }

                        if (_edge == true) //moves player to edge to stop them from falling
                        {
                            other.GetComponentInParent<Transform>().position = transform.position;
                        }
                        Physics2D.gravity = new Vector2(-9.8f, 0);
                        break;
                    case "right":
                        if (Physics2D.gravity == new Vector2(9.8f, 0))
                        {
                            Secondary();
                            break;
                        }

                        
                        Physics2D.gravity = new Vector2(9.8f, 0);
                        if (_edge == true) //moves player to edge to stop them from falling
                        {
                            other.GetComponentInParent<Transform>().position = transform.position;
                        }
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
        

    private void Secondary()
    {
        switch (secondaryDirection)
        {
            case "up":
                
                Physics2D.gravity = new Vector2(0, 9.8f);
                break;
            case "down":
                
                Physics2D.gravity = new Vector2(0, -9.8f);
                break;
            case "left":
                
                Physics2D.gravity = new Vector2(-9.8f, 0);
                break;
            case "right":
                
                Physics2D.gravity = new Vector2(9.8f, 0);
                break;
            default:
                Physics2D.gravity = Physics2D.gravity;
                break;
                
        }
        
    }
}
   

