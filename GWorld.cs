using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ResourceQueue {

    public Queue<GameObject> que = new Queue<GameObject>();
    public string tag;
    public string modState;

    public ResourceQueue(string t, string ms, WorldStates w) {

        tag = t;
        modState = ms;
        if (tag != "") {

            GameObject[] resources = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject r in resources) {
                
                que.Enqueue(r);
            }
        }

        if (modState != "") {

            w.ModifyState(modState, que.Count);
        }
    }

    // Add the resource
    public void AddResource(GameObject r) {

        que.Enqueue(r);
    }


    // Remove the resource
    public GameObject RemoveResource() {

        if (que.Count == 0) return null;

        return que.Dequeue();
    }

    // Overloaded RemoveResource
    public void RemoveResource(GameObject r) {

        // Put everything in a new queue except 'r' and copy it back to que
        que = new Queue<GameObject>(que.Where(p => p != r));
    }
}

public sealed class GWorld {

    // Our GWorld instance
    private static readonly GWorld instance = new GWorld();
    // Our world states
    private static WorldStates world;
    // Queue of irons
    private static ResourceQueue irons;
    // Queue of stones
    private static ResourceQueue stones;
    // Queue of woods
    private static ResourceQueue woods;
    private static ResourceQueue buildings;
    

    // Storage for all
    private static Dictionary<string, ResourceQueue> resources = new Dictionary<string, ResourceQueue>();

    static GWorld() {

        // Create our world
        world = new WorldStates();
        // Create irons array
        irons = new ResourceQueue("Iron", "FreeIron", world);
        // Add to the resources Dictionary
        resources.Add("irons", irons);
        // Create stones array
        stones = new ResourceQueue("Stone", "FreeStone", world);
        // Add to the resources Dictionary
        resources.Add("stones", stones);
        // Create woods array
        woods = new ResourceQueue("Wood", "FreeWood", world);
        // Add to the resources Dictionary
        resources.Add("woods", woods);

        buildings = new ResourceQueue("Build", "FreeBuild", world);
        // Add to the resources Dictionary
        resources.Add("buildings", buildings);
        
        // Set the time scale in Unity
        Time.timeScale = 1.0f;
    }

    public ResourceQueue GetQueue(string type) {

        return resources[type];
    }

    private GWorld() {

    }

    public static GWorld Instance {

        get { return instance; }
    }

    public WorldStates GetWorld() {

        return world;
    }
}
