using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float speed; // amt of pixels moved per frame
    public GameObject treat;
    private GameObject currentTreat;
    public float yOff = -1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        if (currentTreat != null) {
            // current player position
            // gameObject is the owner of this script
            Vector3 playerPos = transform.position;
            Vector3 treatPos = new Vector3(0.0f, yOff, 0.0f);
            currentTreat.transform.position = playerPos + treatPos;
        } else
        {
            currentTreat = Instantiate(treat, new Vector3(0.0f, yOff, 0.0f), Quaternion.identity);
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame) {
            // give treat gravity and enable collider
            Rigidbody2D body = currentTreat.GetComponent<Rigidbody2D>();
            body.gravityScale = 1.0f;
            Collider2D col = currentTreat.GetComponent<Collider2D>();
    
            col.enabled = true;
            currentTreat = null;
        }

        Keyboard k = Keyboard.current;
        if (k.leftArrowKey.isPressed || k.aKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x - speed;
            transform.position = newPos;
        } else if (k.rightArrowKey.isPressed || k.dKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.x = newPos.x + speed;
            transform.position = newPos;
        } if (k.upArrowKey.isPressed || k.wKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.y = newPos.y + speed;
            transform.position = newPos;
        } else if (k.downArrowKey.isPressed || k.sKey.isPressed) {
            Vector3 newPos = transform.position;
            newPos.y = newPos.y - speed;
            transform.position = newPos;
        }
    }
}
