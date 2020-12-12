using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatePlayer : MonoBehaviour
{
    GameObject player, particles;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        particles = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject;
        anim = player.GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NewStep")
        {
            anim.SetTrigger("jump");
            particles.SetActive(true);
            Invoke("CloseParticles", 0.2f);
        }
    }

    public void CloseParticles()
    {
        particles.SetActive(false);
    }
}
