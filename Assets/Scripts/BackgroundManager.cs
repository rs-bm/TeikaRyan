using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public GameObject bckPrefab;
    public float speed;
    public GameObject[] bcks;
    public float pivotPoint;
    public float scale;
    void Start() {
        pivotPoint = scale * 16 * -0.32f;
        bckPrefab.transform.localScale = new Vector3 (scale, scale, 10.0f);
        bcks = new GameObject[3];

        for (int i = 0; i < 3; i++)
        {
            float xPos = pivotPoint - (pivotPoint/2 * i);
            float yPos = pivotPoint - (pivotPoint/2 * i);
            Vector3 position = new Vector3(xPos, yPos, 10);
            bcks[i] = Instantiate(bckPrefab, position, Quaternion.identity);
        }
    }

    void Update() {
        for (int i = 0; i < 3; i++)
        {
            float xPos = bcks[i].transform.position.x + speed;
            float yPos = bcks[i].transform.position.y + speed;
            Vector3 position = new Vector3(xPos, yPos, 10);
            if (bcks[i].transform.position.x > -pivotPoint/2)
            {
                position = new Vector3(pivotPoint, pivotPoint, 10);
            }
            bcks[i].transform.position = position;
        }
    }
}
