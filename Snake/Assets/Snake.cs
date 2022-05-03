using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class Snake : MonoBehaviour
{
    private Vector2 _direction = Vector2.right;

    private List<Transform> _segments;

    public Transform segmentPrefab;

    //public GameOverScreen gameOverScreen; 
    public GameObject gameOverScreen;

    private void Start()
    {
        _segments = new List<Transform>();
        //_segments.Add(this.transform);

        //Canvas c = gameObject.GetComponent<Canvas>();
        //gameOverScreen = gameObject.GetComponent(typeof(GameOverScreen)) as GameOverScreen;
        //gameOverScreen = GameObject.FindGameObjectsWithTag("GameOverScreenTag")[0] as GameOverScreen;

        ResetState();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            _direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            _direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        //if (input != Vector2.zero)
        //{
         //   direction = input;
        //}

        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        transform.position = new Vector2(
            Mathf.Round(transform.position.x) + _direction.x,
            Mathf.Round(transform.position.y) + _direction.y//,
            //0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }

    private void ResetState()
    {
        //_direction = Vector2.right;
        transform.position = Vector3.zero;

        for (int i = 1; i < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        _segments.Add(transform);
        Score.scoreValue = 0;
        //transform.position = Vector3.zero;

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
        //gameOverScreen.GetComponent<GameOverScreen>().Setup(Score.scoreValue); 
        SceneManager.LoadScene("GameOverScreen");
    }
}


