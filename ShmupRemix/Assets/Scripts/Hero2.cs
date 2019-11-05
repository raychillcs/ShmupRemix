using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero2 : MonoBehaviour
{
    static public Hero2 S; // Singleton

    [Header("Set in Inspector")]
    // These fields control the movement of the ship
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    public float gameRestartDelay = 2f;
    public GameObject projectilePrefab;
    public GameObject healProjectilePrefab;
    public float projectileSpeed = 40;
    public AudioSource audioSource;
    public AudioClip damageAudio;
    public AudioClip healAudio;

    [Header("Set Dynamically")]
    [SerializeField]
    private float _shieldLevel = 1;

    // This variable holds a reference to the last triggering GameObject
    private GameObject lastTriggerGo = null;

    void Awake()
    {
        if (S == null)
        {
            S = this; // Set the Singleton
        }
        else
        {
            Debug.LogError("Hero2.Awake() - Attempted to assign second Hero2.S!");
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Pull in information from the Input class
        float xAxis = Input.GetAxis("Horizontal2");
        float yAxis = Input.GetAxis("Vertical2");

        // Change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += xAxis * speed * Time.deltaTime;
        pos.y += yAxis * speed * Time.deltaTime;
        transform.position = pos;

        // Rotate the ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(yAxis * pitchMult, xAxis * rollMult, 270);

        // Allow the ship to fire
        if (Input.GetKeyDown(KeyCode.RightCommand))
        {
            TempFire();
            audioSource.PlayOneShot(damageAudio);
        }

        if (Input.GetKeyDown(KeyCode.RightAlt))
        {
            TempHealFire();
            audioSource.PlayOneShot(healAudio);
        }
    }

    void TempFire()
    {
        GameObject projGO = Instantiate<GameObject>(projectilePrefab);
        projGO.transform.position = transform.position;
        Rigidbody rigidB = projGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.right * projectileSpeed;
    }

    void TempHealFire()
    {
        GameObject projHealGO = Instantiate<GameObject>(healProjectilePrefab);
        projHealGO.transform.position = transform.position;
        Rigidbody rigidB = projHealGO.GetComponent<Rigidbody>();
        rigidB.velocity = Vector3.right * projectileSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        //print("Triggered: " + go.name);

        // Make sure it's not the same triggering GO as last time
        if (go == lastTriggerGo)
        {
            return;
        }

        lastTriggerGo = go;

        if (go.tag == "Enemy") // If the shield was triggered by an enemy
        {
            shieldLevel--; // Decrease the level of the shield by 1
            Destroy(go); // ...and Destroy the enemy
        }
        else
        {
            print("Triggered by non-enemy: " + go.name);
        }
    }

    public float shieldLevel
    {
        get
        {
            return (_shieldLevel);
        }
        set
        {
            _shieldLevel = Mathf.Min(value, 4);

            // If the shield is going to be set to less than zero
            if (value < 0)
            {
                Destroy(this.gameObject);

                // Tell Main.S to restart the game after a delay
                Main.S.DelayedRestart(gameRestartDelay);
            }
        }
    }
}
