using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallRespawn : MonoBehaviour
{
    Vector2 playerInitPosition;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            FindObjectOfType<PlayerController>().ResetPlayer();
            FindObjectOfType<PlayerController>().transform.position = playerInitPosition;
        }
    }
}
