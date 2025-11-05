using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    public AudioClip collectSound;
   
    
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player touched the coin
        if (other.CompareTag("PlayerTag"))
        {
            // Find the GameManager in the scene
            // GameManager gameManager = FindObjectOfType<GameManager>();
            GameManager gameManager = FindAnyObjectByType<GameManager>();

            // If found, add +2 to the score
            if (gameManager != null)
            {
                gameManager.score += 2;
                gameManager.scoreText.text = gameManager.score.ToString();
                //Debug.Log("Score Increased");
            }
           
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
            // Destroy the coin after collecting
            Destroy(gameObject);
        }
    }
}
