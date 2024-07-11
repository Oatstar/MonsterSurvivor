using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Drag your monster prefab here in the Unity Inspector
    public int currentMonster;

    public void ChooseMonster(int monsterId)
    {
        currentMonster = monsterId;
    }

    void Update()
    {
        // Check if the left mouse button is clicked

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            // Get the mouse position in world coordinates
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f; // Ensure the z-coordinate is appropriate for 2D

            // Instantiate the monsterPrefab at the mouse position
            GameObject spawnedMonster = Instantiate(monsterPrefabs[currentMonster], mousePosition, Quaternion.identity);
            SpriteRenderer spriteRen = spawnedMonster.GetComponent<SpriteRenderer>();

        }
    }

}
