using UnityEngine;
using UnityEngine.UI;

public class PlayerController1 : MonoBehaviour
{
    [Header("Movement Settings")]
    public float laneDistance = 3f;
    public int laneNumber = 1;
    public float force = 10f;

    [Header("Game Over UI")]
    public GameObject gameOverPanel;

    private Rigidbody _rb;
    public bool isJumped = false;

    // Swipe detection variables
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private bool isSwiping = false;

    


     public GameObject pauseButton;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gameOverPanel.SetActive(false);
    }

    void Update()
    {
        HandleKeyboardInput();
        HandleSwipeInput();
    }

    //  PC Controls
    private void HandleKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber >= 1)
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber <= 1)
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }

    //  Mobile Controls (Swipe)
    private void HandleSwipeInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startTouchPosition = touch.position;
                    isSwiping = true;
                    break;

                case TouchPhase.Ended:
                    if (isSwiping)
                    {
                        endTouchPosition = touch.position;
                        DetectSwipe();
                        isSwiping = false;
                    }
                    break;
            }
        }
    }

    //  Detect the direction of the swipe
    private void DetectSwipe()
    {
        Vector2 swipeDelta = endTouchPosition - startTouchPosition;

        if (swipeDelta.magnitude < 50f)
            return; // Ignore very short swipes

        if (Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
        {
            // Horizontal swipe
            if (swipeDelta.x > 0)
                MoveRight();
            else
                MoveLeft();
        }
        else
        {
            // Vertical swipe
            if (swipeDelta.y > 0)
                Jump();
        }
    }

    //  Movement Methods
    private void MoveLeft()
    {
        if (laneNumber >= 1)
        {
            transform.position = new Vector3(transform.position.x - laneDistance, transform.position.y, transform.position.z);
            laneNumber--;
        }
    }

    private void MoveRight()
    {
        if (laneNumber <= 1)
        {
            transform.position = new Vector3(transform.position.x + laneDistance, transform.position.y, transform.position.z);
            laneNumber++;
        }
    }

    private void Jump()
    {
        if (!isJumped)
        {
            _rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            isJumped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isJumped = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            Debug.Log("GameOver");
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
            if (pauseButton != null)//hide the pause button
                pauseButton.SetActive(false);

        }
    }
}
