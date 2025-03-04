using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public SceneController controller;
    private Rigidbody rb;

    void Start() {
        rb = GetComponent<Rigidbody>();
    }
    
    void OnCollisionEnter (Collision col) {
        if (col.gameObject.CompareTag("Player")) {
            controller.NextScene();
        }
    }
}
