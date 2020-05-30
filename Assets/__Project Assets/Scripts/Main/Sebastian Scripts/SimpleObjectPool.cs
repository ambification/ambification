using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SimpleObjectPool : MonoBehaviour
{
   public Object prefab;
   private Stack<GameObject> innactiveInstances = new Stack<GameObject>();

   /// <summary>
   /// instance and add an add to it a PoolObject component
   /// </summary>
   /// <returns></returns>
   public GameObject GetObject()
   {
      GameObject spawnedGameObject;

      if (innactiveInstances.Count > 0)
      {
         spawnedGameObject = innactiveInstances.Pop();
      }
      else
      {
         spawnedGameObject = (GameObject)GameObject.Instantiate(prefab);
         PooledObject pooledObject = spawnedGameObject.AddComponent<PooledObject>();
         pooledObject.pool = this;
      }
      
      spawnedGameObject.SetActive(true);
      return spawnedGameObject;
   }

   /// <summary>
   /// Return an object from the pool
   /// </summary>
   /// <param name="toReturn"></param>
   public void ReturnGameObject(GameObject toReturn)
   {
      PooledObject pooledObject = toReturn.GetComponent<PooledObject>();

      if (pooledObject != null && pooledObject.pool == this)
      {
         toReturn.SetActive(false);
         innactiveInstances.Push(toReturn);
      }
      else
      {
         Debug.LogWarning(toReturn.name + "Was returned to a pool, it wasn't spawned from! Destroying");
      }
   }
}

/// <summary>
/// pool properties
/// </summary>
public class PooledObject : MonoBehaviour
{
   public SimpleObjectPool pool;
}
