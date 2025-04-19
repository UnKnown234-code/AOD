using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Search;
using UnityEngine;

public class Skeleton_Spawner : MonoBehaviour
{
    // Enemy Prefabs
    [SerializeField] GameObject skeleton_minion;
    [SerializeField] GameObject skeleton_knight;
    [SerializeField] GameObject skeleton_commander;
    [SerializeField] GameObject king;
    
   
    // Enemy Spawner Place 
    [SerializeField] Vector2 minion_Spawner;
    [SerializeField] Vector2 skeleton_Spawner;
    [SerializeField] Vector2 Commander_Spawner;
    [SerializeField] Vector2 King_Spawner;


    // Counter for Enemies
    public int minion_spawned = 0;
    int Knight_spawned = 0;
    public int commander_spawned = 0;
   public  int king_Spawned = 0;

    [SerializeField] int max_minions;
    [SerializeField] int max_knights;
    [SerializeField]  int max_Commander;
    [SerializeField] public int max_King;
   
    // Bools
    public bool canSpawn  = true;
    public bool showVictory = false;
    
    
    
   Skeleton_Script sk;
  






    private void Awake()
    {
        sk = FindObjectOfType<Skeleton_Script>();
      
      




    }
  
    private void Update()
    {

        // When Certain numbers of Minions are spawed,, a Knight will be Spawned ...
        //.when certain number of knight spawned,,commander will spawn and this goes om..when King spawns ..the funtion will stop spawning 

        if (canSpawn)
        {
            if(minion_spawned == max_minions)
            {
                Instantiate(skeleton_knight, skeleton_Spawner, Quaternion.identity);
                minion_spawned = 0;
                Knight_spawned++;
                if(Knight_spawned == max_knights)
                {
                    Instantiate(skeleton_commander, Commander_Spawner, Quaternion.identity);
                    Knight_spawned = 0;
                    commander_spawned++;
                    if(commander_spawned == max_Commander)
                    {
                        Instantiate(king, King_Spawner, Quaternion.identity);
                        commander_spawned = 0;
                        king_Spawned++;
                        if(king_Spawned == max_King)
                        {
                            canSpawn = false;
                        }
                    }
                }
            }
        }
    }

   
}
