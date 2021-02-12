using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MazeConstructor))]

public class GameController : MonoBehaviour
{
    [SerializeField] private FpsMovement player;

    private MazeConstructor generator;

    private bool goalReached;

    // Use this for initialization
    void Start() {
        generator = GetComponent<MazeConstructor>();
        StartNewGame();
    }

    private void StartNewGame()
    {
        StartNewMaze();
    }

    private void StartNewMaze()
    {
        generator.GenerateNewMaze(13, 15, OnStartTrigger, OnGoalTrigger);

        float x = generator.startCol * generator.hallWidth;
        float y = 1;
        float z = generator.startRow * generator.hallWidth;
        player.transform.position = new Vector3(x, y, z);

        goalReached = false;
        player.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player.enabled)
        {
            return;
        }

    }

    private void OnGoalTrigger(GameObject trigger, GameObject other)
    {
        Debug.Log("ExitScene");

        Destroy(trigger);
        Application.Quit();
    }

    private void OnStartTrigger(GameObject trigger, GameObject other)
    {
        if (goalReached)
        {
            Debug.Log("Finish!");
            player.enabled = false;

            Application.Quit();
        }
    }
}
