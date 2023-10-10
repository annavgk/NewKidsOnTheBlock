using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthHeartSystem : MonoBehaviour
{
    public GameObject heartPrefab;
    public int maxHearts = 3;
    List<HealthHeart> hearts = new List<HealthHeart>();

    public void CreateFullHeart()
    {
        GameObject newHeart = Instantiate(heartPrefab);
        newHeart.transform.SetParent(transform);

        HealthHeart heartComponent = newHeart.GetComponent<HealthHeart>();
        heartComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(heartComponent);
    }
    public void ClearHeart()
    {
        foreach(Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<HealthHeart>();
    }
}
