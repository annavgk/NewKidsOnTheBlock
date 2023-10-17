using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [SerializeField] private Image _heart;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < GameManager.Instance.CurrentHealth; i++)
        {
            Instantiate(_heart,this.transform);
        }
        _heart.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
