using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] List<Transform> snakeBody;
    [SerializeField] Transform body;
    GameManager gm;
    Food food;
    
    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        food = FindObjectOfType<Food>();
        snakeBody = new List<Transform>();
        snakeBody.Add(transform);
    }

    void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0)
        {
            direction = Vector2.right * xAxis;
        }
        if (yAxis != 0)
        {
            direction = Vector2.up * yAxis;
        }
    }

    private void FixedUpdate()
    {
        for (int i = snakeBody.Count - 1; i > 0; i--)
        {
            snakeBody[i].position = snakeBody[i - 1].position;
        }

        Move();
    }

    void Move()
    {
        float roundPosX = Mathf.Round(transform.position.x);
        float roundPosY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosX + direction.x, roundPosY + direction.y);
    }

    void GrowingSnake()
    {
        Transform SpawnBody = Instantiate(body, snakeBody[snakeBody.Count - 1].position, Quaternion.identity);
        snakeBody.Add(SpawnBody);
        gm.SetScore(10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            food.sound.Play();
            GrowingSnake();
        }
        else if (collision.CompareTag("Obstacles"))
        {
            gm.LifeScore();
        }
        else if (collision.CompareTag("Body"))
        {
            gm.LifeScore();
        }
    }

    public void RestartButton()
    {
        gm.gameOver.SetActive(false);
        Time.timeScale = 1;
        transform.position = Vector2.zero;
        direction = Vector2.zero;

        for (int i = 1; i < snakeBody.Count; i++)
        {
            Destroy(snakeBody[i].gameObject);
        }

        snakeBody.Clear();
        snakeBody.Add(transform);

        gm.score = 0;
        gm.textScore.text = "00";
        gm.life = 3;
        gm.lifeScore.text = "3";
    }
}
