using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float laneDistance = 3f;
    public int laneNumber = 1;
    private Rigidbody _rb;
    public float force = 10f;

    public bool isJumped = false;
    //in inspector it is checked,make it false to jump
    public GameObject gameOverPanel;
   
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow) && laneNumber >= 1)
        {
            transform.position = new Vector3(transform.position.x - laneDistance, transform.position.y, transform.position.z);
            laneNumber--;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && laneNumber <= 1)
        {
            transform.position = new Vector3(transform.position.x + laneDistance, transform.position.y, transform.position.z);
            laneNumber++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!isJumped)
            {
                _rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                isJumped = true;
            }

        }


    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumped = false;
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Debug.Log("GameOver");
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);

           
        }
    }



}
