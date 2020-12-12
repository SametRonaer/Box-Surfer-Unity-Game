using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInvisibleObjects : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
