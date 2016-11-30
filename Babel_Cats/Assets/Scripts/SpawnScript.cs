using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnScript : MonoBehaviour
{
    public float spawn_distance;
    public GameObject walls;
    public GameObject itembox;
    public GameObject[] levels;
    private float position;

    // Use this for initialization
    void Start()
    {
        GameObject Level;
        List<GameObject> ItemSpawnPoints = new List<GameObject>();
        Instantiate(walls, new Vector3(transform.position.x, transform.position.y - 24, transform.position.z), Quaternion.identity);
        Level = (GameObject)Instantiate(levels[Random.Range(0, levels.Length)], new Vector3(transform.position.x, transform.position.y - 24, transform.position.z), Quaternion.identity);
        foreach (Transform child in Level.transform)
            if (child.gameObject.tag == "Box")
                ItemSpawnPoints.Add(child.gameObject);
        ItemSpawnPoints[Random.Range(0, ItemSpawnPoints.Count)].SetActive(true);
        ItemSpawnPoints.Clear();
        Instantiate(walls, new Vector3(transform.position.x, transform.position.y - 12, transform.position.z), Quaternion.identity);
        Level = (GameObject)Instantiate(levels[Random.Range(0, levels.Length)], new Vector3(transform.position.x, transform.position.y - 12, transform.position.z), Quaternion.identity);
        foreach (Transform child in Level.transform)
            if (child.gameObject.tag == "Box")
                ItemSpawnPoints.Add(child.gameObject);
        ItemSpawnPoints[Random.Range(0, ItemSpawnPoints.Count)].SetActive(true);
        ///
        position = Camera.main.transform.position.y;
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.transform.position.y >= position + spawn_distance)
        {
            position = Camera.main.transform.position.y;
            Spawn();
        }
    }

    void Spawn()
    {
        GameObject Level;
        List<GameObject> ItemSpawnPoints = new List<GameObject>();
        Instantiate(walls, transform.position, Quaternion.identity);
        Level = (GameObject)Instantiate(levels[Random.Range(0, levels.Length)], transform.position, Quaternion.identity);
        foreach (Transform child in Level.transform)
            if (child.gameObject.tag == "Box")
                ItemSpawnPoints.Add(child.gameObject);
        ItemSpawnPoints[Random.Range(0, ItemSpawnPoints.Count)].SetActive(true);
    }
}
