using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieSpawnManager : MonoBehaviour
{

    [SerializeField]
    private List<Zombie> listZombieSpawn;

    [Tooltip("List waypoint zombie spawn")]
    [SerializeField]
    private List<Transform> waypoints;

    [Tooltip("List prefab zombie spawn")]
    [SerializeField]
    private List<GameObject> prefabsZombie;

    [SerializeField]
    private List<Transform> positionsZombieSpawn;

    [SerializeField]
    private int minSpawn = 10;

    [SerializeField]
    private int maxSpawn = 20;

    [SerializeField]
    private float timeSpawn = 5f;
    private float countTime = 0f;
    [SerializeField]
    private bool canSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        SpawnZombie();

        foreach(Zombie zom in listZombieSpawn)
        {
            if(zom.IsDead())
            {
                listZombieSpawn.Remove(zom);
                Destroy(zom.gameObject);
                GameManager.instance.IncreaseScore();
                break;
            }
        }
    }

    private void SpawnZombie()
    {
        if(canSpawn)
        {
            
            int size = Random.Range(minSpawn, maxSpawn);
            if (listZombieSpawn.Count > maxSpawn)
            {
                canSpawn = false;
                return;
            }
            else if (listZombieSpawn.Count + size > maxSpawn) ;
            {
                size = maxSpawn - listZombieSpawn.Count;
            }
            
            for (int i = 0; i < size; i++)
            {
                Transform ob = Instantiate(prefabsZombie[Random.Range(0, prefabsZombie.Count)], positionsZombieSpawn[Random.Range(0, positionsZombieSpawn.Count)]).transform;
                ZombieType zombieType = (ZombieType)Random.Range(0, System.Enum.GetValues(typeof(ZombieType)).Length);
                int health = Random.Range(0, 30);
                float distant = Random.Range(5f, 8f);
                float damage = Random.Range(1f, 3f);
                float percenBoost = Random.Range(0.1f, 0.13f);
                ob.gameObject.AddComponent(typeof(NavMeshAgent));
                Zombie zombie = ob.gameObject.AddComponent(ZombieFactory.GetZombieByType(zombieType).GetType()) as Zombie;
                zombie.InitZombie(health, damage, distant, percenBoost, 0f);
                zombie.SetGuiHealth(GameManager.instance.guiHealthForZombie);
                zombie.SetExplodePrefab(GameManager.instance.vfxBloodExplode);
                listZombieSpawn.Add(zombie);
            }
            canSpawn = false;
        }
        else
        {
            countTime += Time.deltaTime;
            if(countTime > timeSpawn)
            {
                canSpawn = true;
                countTime = 0;
            }
        }



    }

}
