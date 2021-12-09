using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//moves camera to new room and handles mob events
public class RoomMove : MonoBehaviour
{
    public Vector3 cameraChange;
    public Vector3 playerChange;
    public CameraMovement cam;
    public EnemyFactory enemyFactory;
    public int spawns;
    [SerializeField]
    public EnemyFactory.EnemyType enemyType;
    private bool isTriggered;


    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<CameraMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isTriggered == false) {
            isTriggered = true;
            cam.minPosition += cameraChange;
            cam.maxPosition += cameraChange;
            collision.transform.position += playerChange;
            SpawnEnemies();
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            isTriggered = false;
        }
    }

    public void SpawnEnemies()
    {
        enemyFactory = new EnemyFactory();
        enemyFactory.DestroyAllEnemies();
        StartCoroutine(SpawnCo());
    }

    private IEnumerator SpawnCo(){
        yield return new WaitForSeconds(1f);
        enemyFactory.SpawnEnemies(spawns, enemyType);
    }
}
