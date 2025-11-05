using UnityEngine;

public class MoveObstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 10f;
    // Update is called once per frame
    void Start()
    {
        Destroy(this.gameObject, 10f);
    }
    void Update()
    {
        this.transform.Translate(Vector3.back * speed * Time.deltaTime);
    }
}
