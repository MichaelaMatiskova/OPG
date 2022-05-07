using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    private Vector2 direction = Vector2.right;

    private List<Transform> segments;

    public Transform segmentPrefab;
    private Vector2 input;

    private void Start()
    {
        segments = new List<Transform>();

        ResetState();
    }


    private void Update()
    {
        if (direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                input = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                input = Vector2.down;
            }
        }
        if (direction.y != 0f) 
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                input = Vector2.left;
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                input = Vector2.right;
            }
        }
    }

    private void FixedUpdate()
    {
        if (input != Vector2.zero)
        {
            direction = input;
        }

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        transform.position = new Vector2(
            Mathf.Round(transform.position.x) + direction.x,
            Mathf.Round(transform.position.y) + direction.y);
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = segments[segments.Count - 1].position;

        segments.Add(segment);
    }

    private void ResetState()
    {
        //_direction = Vector2.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(transform);
        Score.scoreValue = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
            Score.scoreValue += 10;
        }
        else if (other.tag == "Obstacle")
        {
            GameOver(); 
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}


