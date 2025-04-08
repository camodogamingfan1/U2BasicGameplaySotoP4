using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectAnimalFeeding : MonoBehaviour
{
    private static int score = 0;

    void Start()
    {

    }

    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            score++;
            Debug.Log("Score = "+ score);
        }
    }
}

