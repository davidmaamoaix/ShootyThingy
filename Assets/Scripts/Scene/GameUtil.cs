using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUtils {

    // Gets the component on the GameObject with the given name.
    public static T findComponentOnObject<T>(string name) {
        GameObject obj = GameObject.Find(name);

        // TODO: Hey remember the new syntax added in C# 6?
        return obj == null ? default : obj.GetComponent<T>();
    }
}
