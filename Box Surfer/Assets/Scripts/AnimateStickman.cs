using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class AnimateStickman : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float speed = 5;
    [SerializeField] GameObject pointManager;
    Vector3 stepPosition;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -500.0F, 0);
        player = GameObject.FindGameObjectWithTag("Player");
        

    }

    // Update is called once per frame
    void Update()
    {

        rb.velocity = new Vector3(0, 0, speed);
 
       
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NewStep")
        {
            StepUp(other);

        }

        if(other.tag == "Point")
        {
            pointManager.GetComponent<PointManager>().IncreasePoint();
            Destroy(other.gameObject);
        }

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        DetectVictory(collision);
    }

    private void DetectVictory(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            if (gameObject.tag == "Player")
            {
                print("Victory");
                player.transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("victory");
            }
            collision.gameObject.tag = "SkippedFinish";
        }
    }

    private void StepUp(Collider other)
    {
        stepPosition = player.transform.position;
        player.transform.position += new Vector3(0, 0.65f, 0);
        other.gameObject.transform.position = stepPosition;
        other.GetComponent<AnimateStickman>().enabled = true;
        other.GetComponent<PlayerController>().enabled = true;
        other.tag = "Step";
        other.GetComponent<BoxCollider>().isTrigger = false;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
    }


 
}
