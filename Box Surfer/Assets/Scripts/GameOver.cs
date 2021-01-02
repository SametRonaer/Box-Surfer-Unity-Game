using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    GameObject player;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
     player= GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
     audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
           
            player.GetComponent<Animator>().SetTrigger("fall");
            audioSource.Play();

        }

        if(other.gameObject.tag == "Step")
        {
            other.gameObject.GetComponent<PlayerController>().enabled = false;
        }

    }

}
