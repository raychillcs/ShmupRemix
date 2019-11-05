using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    static public Ally S; // Singleton

    [Header("Set in Inspector")]
    public float health = 10;
    public float gameRestartDelay = 2f;

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
            Debug.LogError("Ally.Awake() - Attempted to assign second Ally.S!");
        }
    }

    void Update()
    {
        if (health == 0)
        {
            Destroy(this.gameObject);

            // Tell Main.S to restart the game after a delay
            Main.S.DelayedRestart(gameRestartDelay);
        }
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
            health--; // Decrease the level of the shield by 1
            Destroy(go); // ...and Destroy the enemy
        }

        else if (go.tag == "ProjectileHero")
        {
            health--;
            Destroy(go);
        }

        else if (go.tag == "HealProjectile")
        {
            health++;
            Destroy(go);
        }

        else
        {
            print("Triggered by non-enemy: " + go.name);
        }
    }
}
