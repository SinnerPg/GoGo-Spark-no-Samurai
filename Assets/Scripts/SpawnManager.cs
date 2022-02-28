using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public Transform enemies;
    private GameObject obj;
    private int nOni, nTengu, nKappa, nYamauba, nKirin, nArahabaki, modeNumber;
    private float timePassed;
    private bool spawned = false, reset = false, found = false;
    private string monsterName, levelName;
    void Start()
    {
        levelName = SceneManager.GetActiveScene().name;
        if (levelName == "ArenaNormal")
        {
            modeNumber = 3;
            nOni = 4;
            nTengu = 4;
            nKappa = 4;
            nYamauba = 4;
            nKirin = 2;
            nArahabaki = 2;
        }
        else
        {
            modeNumber = 4;
            nOni = 3;
            nTengu = 2;
            nKappa = 3;
            nYamauba = 3;
            nKirin = 2;
            nArahabaki = 2;
        }
        for (int i = 0; i < 2; i++)
        {
            int spawn = Random.Range(1, 5);
            int monsterToSpawn = Random.Range(1, 7);
            switch (monsterToSpawn)
            {
                case 1:
                    monsterName = "AIOni";
                    break;
                case 2:
                    if (nTengu > 0)

                        monsterName = "AITengu";
                    break;
                case 3:
                    if (nKappa > 0)

                        monsterName = "AIKappa";
                    break;
                case 4:
                    if (nYamauba > 0)

                        monsterName = "AIYamauba";
                    break;
                case 5:
                    if (nKirin > 0)

                        monsterName = "AIKirin";
                    break;
                case 6:
                    if (nArahabaki > 0)
                        monsterName = "AIArahabaki";
                    break;
            }
            switch (spawn)
            {
                case 1:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, -2);
                    break;
                case 2:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(1).position.x, transform.GetChild(1).position.y, -2);
                    break;
                case 3:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(2).position.x, transform.GetChild(2).position.y, -2);
                    break;
                case 4:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -2);
                    break;
            }
        }
    }
    void Update()
    {
        timePassed += Time.deltaTime;

        if (Mathf.Round(timePassed) % 180 == 0 && Mathf.Round(timePassed) != 0)
        {
            this.gameObject.SetActive(false);
        }

        if (Mathf.Round(timePassed) % 60 == 0 && !reset)
        {
            reset = true;
            if (levelName == "ArenaNormal")
            {
                nOni = 4;
                nTengu = 4;
                nKappa = 4;
                nYamauba = 4;
                nKirin = 2;
                nArahabaki = 2;
            }
            else
            {
                nOni = 3;
                nTengu = 2;
                nKappa = 3;
                nYamauba = 3;
                nKirin = 2;
                nArahabaki = 2;
            }
        }
        else if (Mathf.Round(timePassed) % 60 != 0)
        {
            reset = false;
        }

        if (Mathf.Round(timePassed) % modeNumber == 0 && !spawned && Mathf.Round(timePassed) != 0)
        {
            spawned = true;
            int spawn = Random.Range(1, 5);
            while (!found)
            {
                int monsterToSpawn = Random.Range(1, 7);
                switch (monsterToSpawn)
                {
                    case 1:
                        if (nOni > 0)
                        {
                            found = true;
                            nOni--;
                            monsterName = "AIOni";
                        }
                        break;
                    case 2:
                        if (nTengu > 0)
                        {
                            found = true;
                            nTengu--;
                            monsterName = "AITengu";
                        }
                        break;
                    case 3:
                        if (nKappa > 0)
                        {
                            found = true;
                            nKappa--;
                            monsterName = "AIKappa";
                        }
                        break;
                    case 4:
                        if (nYamauba > 0)
                        {
                            found = true;
                            nYamauba--;
                            monsterName = "AIYamauba";
                        }
                        break;
                    case 5:
                        if (nKirin > 0)
                        {
                            found = true;
                            nKirin--;
                            monsterName = "AIKirin";
                        }
                        break;
                    case 6:
                        if (nArahabaki > 0)
                        {
                            found = true;
                            nArahabaki--;
                            monsterName = "AIArahabaki";
                        }
                        break;
                    default:
                        found = true;
                        break;
                }
            }
            switch (spawn)
            {
                case 1:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(0).position.x, transform.GetChild(0).position.y, -2);
                    break;
                case 2:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(1).position.x, transform.GetChild(1).position.y, -2);
                    break;
                case 3:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(2).position.x, transform.GetChild(2).position.y, -2);
                    break;
                case 4:
                    obj = Instantiate(Resources.Load(monsterName)) as GameObject;
                    obj.transform.parent = enemies;
                    obj.transform.position = new Vector3(transform.GetChild(3).position.x, transform.GetChild(3).position.y, -2);
                    break;
            }
            found = false;
        }

        if (Mathf.Round(timePassed) % modeNumber != 0)
        {
            spawned = false;
        }
    }
}
