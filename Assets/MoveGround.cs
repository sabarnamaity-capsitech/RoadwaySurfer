using UnityEngine;

public class MoveGround : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, -10) * Time.deltaTime;
    }

   
}
