using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collsion)
    {
        if (collsion.tag == "Player")
        {
            SceneManager.LoadScene(5);
        }
    }
}
