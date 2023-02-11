using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas GameOverCanvas;
    [SerializeField] Canvas PlayerCanvas;

    void Start()
    {
        GameOverCanvas.enabled = false;
        PlayerCanvas.enabled = true;
    }   

    public void HandleDeath()
    {
        GameOverCanvas.enabled = true;
        PlayerCanvas.enabled = false;

        Time.timeScale = 0;

        FindObjectOfType<PlayerMovementScript>().enabled = false;
        FindObjectOfType<GunScript>().enabled = false;       

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
