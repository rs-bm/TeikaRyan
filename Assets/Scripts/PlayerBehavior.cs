using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float speed; // amt of pixels moved per frame
    private GameObject currentTreat;
    public float yOff = -1f;
    public GameObject[] treats;
    public int move;
    private float timeStart;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // float currentTime = Time.time;
        // print(currentTime);
        move = 0;
        timeStart = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        
        float currentTime = Time.time;

        if (currentTreat != null) {
            // current player position
            // gameObject is the owner of this script
            Vector3 playerPos = transform.position;
            Vector3 treatPos = new Vector3(0.0f, yOff, 0.0f);
            currentTreat.transform.position = playerPos + treatPos;
        } else
        {
            int result = Random.Range(0, treats.Length / 2);
            currentTreat = Instantiate(treats[result], new Vector3(0.0f, yOff, 0.0f), Quaternion.identity);
            float randomScale = UnityEngine.Random.Range(0.5f, 1.5f);
            currentTreat.transform.localScale = new Vector3(randomScale, randomScale, 1);
        }

        if (currentTime - timeStart > 0.25 && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            timeStart = Time.time;
            // give treat gravity and enable collider
            Rigidbody2D body = currentTreat.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;
            Collider2D col = currentTreat.GetComponent<Collider2D>();
    
            col.enabled = true;
            currentTreat = null;
        }

        Keyboard k = Keyboard.current;
        bool left = (k.leftArrowKey.isPressed || k.aKey.isPressed) && move != 1;
        bool right = (k.rightArrowKey.isPressed || k.dKey.isPressed) && move != 2;
        if (left) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;
        } 
        if (right) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        }
    }
    public void OnCollisionEnter2D(Collision2D other)
    {
        print("you touched " + (other.gameObject.name));
        if (other.gameObject.CompareTag("RB"));
        {
            move = 2; // Cannot move right
        }
        if (other.gameObject.CompareTag("LB"))
        {
            move = 1; // Cannot move left
        } 
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        print("you are touching " + other.gameObject.name);
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        print("you stopped touching " + other.gameObject.name);
        move = 0;
    }
}
