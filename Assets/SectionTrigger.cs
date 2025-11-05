using Unity.VisualScripting;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject ground;


    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Instantiate(ground,new Vector3(0,0,37),Quaternion.identity);
        }
    }
}



