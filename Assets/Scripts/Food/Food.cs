using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    [SerializeField] BoxCollider2D spawnArea;

    public AudioSource sound;

    void Start()
    {
        RandomPositionFood();
        sound = GetComponent<AudioSource>();
    }

    public void RandomPositionFood()
    {
        Bounds bounds = spawnArea.bounds;

        Vector2 randonArea = new Vector2(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y));

        float roundBoundx = Mathf.Round(randonArea.x);
        float roundBoundY = Mathf.Round(randonArea.y);

        transform.position = new Vector2(roundBoundx, roundBoundY);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RandomPositionFood();
        }
    }
}
