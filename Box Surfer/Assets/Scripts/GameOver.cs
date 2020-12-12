using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
     player= GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            print("Finish");
            player.GetComponent<Animator>().SetTrigger("fall");
        }

        if(other.gameObject.tag == "Step")
        {
            other.gameObject.GetComponent<PlayerController>().enabled = false;
        }

    }

}
