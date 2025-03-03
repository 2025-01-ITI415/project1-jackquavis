using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.CompareTag("Player")) {
            
        }
    }
}
