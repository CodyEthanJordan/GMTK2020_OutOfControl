using UnityEngine;
using System.Collections;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
  static T _instance;
  public static bool applicationIsQuitting = false;
  public static T instance {
    get {
      if (applicationIsQuitting) {
        Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                         "' already destroyed on application quit." +
                         " Won't create again - returning null.");
        return null;
      }

      if (_instance == null) {
        _instance = (T)FindObjectOfType(typeof(T));

        if (FindObjectsOfType(typeof(T)).Length > 1) {
          Debug.LogError("[Singleton] Something went really wrong " + typeof(T) +
                         " - there should never be more than 1 singleton!" +
                         " Reopenning the scene might fix it.");
          return _instance;
        }
        if (_instance == null) {
          Debug.Log("Creating object " + typeof(T));
          GameObject singleton = new GameObject();
          _instance = singleton.AddComponent<T>();
          singleton.name = typeof(T).ToString();
        } else {
          Debug.Log("[Singleton] Using instance already created: " +
                    _instance.gameObject.name);
        }
      }

      return _instance;

    }
  }

  public virtual void Init() { }
  public virtual IEnumerator InitCoroutine() {
    yield return null;
  }
}