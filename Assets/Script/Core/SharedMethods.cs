using UnityEngine;

public class SharedMethods : MonoBehaviour
{
   public static SharedMethods instance;
   
   public enum Tags{
       Enemy,Player
   }
    void Awake()
    {
        if(instance !=null)
            Destroy(this.gameObject);
        instance = this;
    }
    ///<summary>
    ///Determine the closet gameobject with certain tag from gameobject calling this function.
    ///</summary>
    public Transform FindClosetObject(Transform callingObject, string tag){
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tag);
        float closetDistance = Mathf.Infinity;
        GameObject closetObject = null;
        foreach(GameObject gameObject in gameObjects){
            float distance = Vector3.Distance(callingObject.position,gameObject.transform.position);
            if(closetDistance>distance)
            {
                closetDistance = distance;
                closetObject = gameObject;
            } 
        }
        return closetObject == null?null: closetObject.transform;
    }
  
}
