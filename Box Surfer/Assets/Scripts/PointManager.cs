using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
 [SerializeField] float pointCount;
 [SerializeField] GameObject point;
 [SerializeField] GameObject score;
 
 [SerializeField] AudioSource getCoinSound;
 Animator anim;
 Text text;

    private void Start()
    {
        pointCount = 0;
        anim = point.GetComponent<Animator>();
        text = score.GetComponent<Text>();
        getCoinSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PointEffect();
    }

   

    public void IncreasePoint()
    {
        pointCount++;
        
        getCoinSound.Play();
        text.text = pointCount.ToString();
        point.SetActive(true);
    }

    public void PointEffect()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("StopPoint")) {
            point.SetActive(false);
        }
        
    }
}
