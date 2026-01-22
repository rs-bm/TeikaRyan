using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    public float speed; // amt of pixels moved per frame
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {
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
