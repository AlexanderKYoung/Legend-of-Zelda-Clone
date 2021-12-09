using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptCompontent;

    public Enemy(string name){
        GameObject = new GameObject(name);
        ScriptCompontent = GameObject.AddComponent<T>();
    }
}

public abstract class Enemy : MonoBehaviour{
    public Rigidbody2D Body;
    public SpriteRenderer Sprite;
    public BoxCollider2D Collider;
    public Animator Anim;
    
    public int Health;
    public int Damage;
    public int Speed;
    public int Direction;

    protected abstract void movementPattern();
    protected abstract void attackType();

    void Awake(){
        Body = gameObject.AddComponent<Rigidbody2D>();
        Sprite = gameObject.AddComponent<SpriteRenderer>();
        Collider = gameObject.AddComponent<BoxCollider2D>();
        Anim = gameObject.AddComponent<Animator>();

        Body.GetComponent<Rigidbody2D>().gravityScale = 0;
        Body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        Collider.size = new Vector2(1, 1);
        Collider.isTrigger = true;
        Sprite.sortingOrder = 1;
        Sprite.sortingLayerName = "Front";
        Collider.edgeRadius = 0f;
        transform.localScale = new Vector3(1f, 1f, 1f);

        gameObject.tag = "Enemy";
        gameObject.layer = LayerMask.NameToLayer("Default");
    }

    public void Initialize(int speed, int direction, int health, Vector2 position){
        Speed = speed;
        Direction = direction;
        Health = health;
        transform.position = position;
    }
    
    public bool isDead(){
        return Health <= 0;
    }
}

public class Armos : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("armos");

    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Boulder : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("boulder");

    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Ghini : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("ghini");

    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Leever : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("leever");
        
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Lynel : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("lynel");
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Moblin : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("moblin");
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Octorok : Enemy{

    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("octorok");
        
    }

    void Update(){
        
    }

    void Patrol(){
        
    }

    void Turn(){
        
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Peahat : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("peahat");
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class RiverZora : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("zora");
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}

public class Tektite : Enemy{
    void Start(){
        Sprite.sprite = Resources.Load<Sprite>("tektite");
    }

    protected override void movementPattern(){
        
    }

    protected override void attackType(){
        
    }
}