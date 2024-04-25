using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Vector2 playerInitPosition;

    private void Start()
    {
        playerInitPosition = FindObjectOfType<PlayerController>().transform.position;    
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        FindObjectOfType<PlayerController>().ResetPlayer();
        FindObjectOfType<PlayerController>().transform.position = playerInitPosition;
    }
}
