using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameControlScript : MonoBehaviour
{
    public GameObject[] modules; // contains the availble sections
    public int spawnPos = 40;    // next spawn position for next position
    public int moduleNum;        // is used to "randomly choose" next section from modules array

    public GameObject player;

    public Queue<GameObject> currentModules = new Queue<GameObject>(); // contains all active modules

    private void Start()
    {
        // add start section and 2 other modules to currentModules
        GameObject startSection = GameObject.Find("Start Section");
        currentModules.Enqueue(startSection);
        StartCoroutine(GenerateModule());
        StartCoroutine(GenerateModule());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentModules.Count < 6)
        {
            StartCoroutine(GenerateModule());
        }

        // if player is past module
        if (currentModules.Peek().transform.position.z + 25 < player.transform.position.z)
        {
            // delete from currentModules queue and destroy
            Destroy(currentModules.Dequeue());
        }
    }

    IEnumerator GenerateModule()
    {
        moduleNum = Random.Range(0, 2);
        currentModules.Enqueue(Instantiate(modules[moduleNum], new Vector3(0,0,spawnPos), Quaternion.identity));
        spawnPos += 40;
        yield return new WaitForSeconds(8);
    }
}
