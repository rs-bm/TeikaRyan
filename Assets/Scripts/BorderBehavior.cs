using UnityEngine;

public class BorderBehavior : MonoBehaviour
{
    public float timeout;
    public float timeStart;
    public GameObject gameOver;
    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Treat"))
        {
            timeStart = Time.time;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Treat"))
        {
            float currentTime = Time.time;
        float timeThusFar = currentTime - timeStart;
        if (timeThusFar > timeout)
        {
            gameOver.SetActive(true);
            Destroy(player);
        }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Treat"))
        {
            timeStart = 0.0f;
        }
    }
}
