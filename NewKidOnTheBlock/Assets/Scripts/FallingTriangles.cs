using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingTriangles : MonoBehaviour
{
    public float fallSpeed = 5f;
    public float destroyDelay = 2f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    private void Update()
    {
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }



}
