using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

//manages the spawning and initialization of different enemies
public class EnemyFactory : MonoBehaviour
{   
    public enum EnemyType {
        Armos, 
        Boulder, 
        Ghini, 
        Leever, 
        Lynel, 
        Moblin, 
        Octorok, 
        Peahat, 
        RiverZora, 
        Tektite
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnEnemies(int n, EnemyType et){
        int i;
        Vector2 pos;
        
        for (i = 0; i < n; i++){
            pos = Camera.main.ViewportToWorldPoint(new Vector2(Random.value, Random.value));
            Tilemap tm = GameObject.Find("Ground").GetComponent<Tilemap>();
            GridLayout gl = tm.GetComponent<GridLayout>();
            Vector3Int cellPos = gl.WorldToCell(pos);
            Vector3 spawnPos = new Vector3(cellPos.x + .5f, cellPos.y + .5f);
            
            if (tm.HasTile(cellPos)){    
                    
                switch (et){
                    case EnemyType.Armos:
                        
                        Enemy<Armos> armos = new Enemy<Armos>("Armos");
                        armos.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Boulder:
                        Enemy<Boulder> boulder = new Enemy<Boulder>("Boulder");
                        boulder.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Ghini:
                        Enemy<Ghini> ghini = new Enemy<Ghini>("Ghini");
                        ghini.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Leever:
                        Enemy<Leever> leever = new Enemy<Leever>("Leever");
                        leever.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Lynel:
                        Enemy<Lynel> lynel = new Enemy<Lynel>("Lynel");
                        lynel.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Moblin:
                        Enemy<Moblin> moblin = new Enemy<Moblin>("Moblin");
                        moblin.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Octorok:
                        Enemy<Octorok> octorok = new Enemy<Octorok>("Octorok");
                        octorok.ScriptCompontent.Initialize(
                            speed: 30,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Peahat:
                        Enemy<Peahat> peahat = new Enemy<Peahat>("Peahat");
                        peahat.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.RiverZora:
                        Enemy<RiverZora> riverZora = new Enemy<RiverZora>("RiverZora");
                        riverZora.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                    case EnemyType.Tektite:
                        Enemy<Tektite> tektite = new Enemy<Tektite>("Tektite");
                        tektite.ScriptCompontent.Initialize(
                            speed: 1,
                            direction: Random.Range(0, 2) * 2 - 1,
                            health: 1,
                            position: spawnPos
                        );
                        break;
                }
            }else{
                i--;
            }
        }
    }

    public void DestroyAllEnemies(){
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");

        for(var i = 0; i < gameObjects.Length; i++){
            GameObject.Destroy(gameObjects[i]);
        }
    }
}
