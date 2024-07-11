using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject[] monsterPrefabs; // Drag your monster prefab here in the Unity Inspector
    public int currentMonster;

    PlayerMonster[] monsterDefaultStats = new PlayerMonster[10];

    private void Awake()
    {
        CreateMonsters();
    }

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
            spawnedMonster.GetComponent<MonsterController>().InitializeMonster(monsterDefaultStats[currentMonster]);

        }
    }


    public void CreateMonsters()
    {
        PlayerMonster newMonster = new PlayerMonster();
        newMonster.monsterName = "Goblin";
        newMonster.health = 50;
        newMonster.speed = 100;
        newMonster.damage = 30;
        newMonster.evasion= 0.05f;
        newMonster.resilience = 30;
        monsterDefaultStats[0] = newMonster;

        newMonster = new PlayerMonster();
        newMonster.monsterName = "Wraith";
        newMonster.health = 100;
        newMonster.speed = 50;
        newMonster.damage = 50;
        newMonster.evasion = 5.00f;
        newMonster.resilience = 80;
        monsterDefaultStats[1] = newMonster;

        newMonster = new PlayerMonster();
        newMonster.monsterName = "Skeleton";
        newMonster.health = 80;
        newMonster.speed = 40;
        newMonster.damage = 100;
        newMonster.evasion = 0.10f;
        newMonster.resilience = 50;
        monsterDefaultStats[2] = newMonster;

        newMonster = new PlayerMonster();
        newMonster.monsterName = "Blob";
        newMonster.health = 150;
        newMonster.speed = 30;
        newMonster.damage = 70;
        newMonster.evasion = 0.00f;
        newMonster.resilience = 100;
        monsterDefaultStats[3] = newMonster;
    }
}

public class PlayerMonster
{
    public string monsterName = "";
    public int health = 100;
    public int speed = 50;
    public int damage = 50;
    public float evasion = 0.05f;
    public int resilience = 50;

}
