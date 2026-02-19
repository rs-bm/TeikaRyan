using UnityEngine;

public class TreatBehavior : MonoBehaviour
{
    public GameObject[] treats;
    public int treatType;

    void Start()
    {
        // get the sequence of available treats from PlayerBehavior
        treats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().treats;
    }
    
    void Update()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Treat") && other.gameObject.GetComponent<TreatBehavior>().treatType == treatType && treatType < treats.Length - 1)
        {
            if (gameObject.transform.position.x < other.transform.position.x 
            || (gameObject.transform.position.x == other.transform.position.x && gameObject.transform.position.y > other.transform.position.y))
            {
                int choice = treatType + 1;
                GameObject currentTreat = Instantiate(treats[choice], Vector3.Lerp(gameObject.transform.position, other.gameObject.transform.position, 0.5f), Quaternion.identity);
                currentTreat.GetComponent<Collider2D>().enabled = true;
                currentTreat.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
                // sound is cut off by Destroy(gameObject)
                GetComponent<AudioSource>().Play();
                Destroy(other.gameObject);
                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehavior>().updateScore(treatType);
            
            }
        }
    }
    
}


