using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour {
    #region Variables
    //Classes
    private AttributeManager attributeManager;
    public object[] raiseAmounts = new object[2] { 5, 10 };
    #endregion

    // Find components and assign values to variables.
    void Start() {
        //Finders
        attributeManager = GameObject.Find("Player/AttributeManager").GetComponent<AttributeManager>();
    }

    //Switch between tagNames and call a class based of the tag.
    public void collisionSorter(string tagName, GameObject obj) {
        switch (tagName) {
            //Refuelling Object
            case "Refuel":
                attributeManager.ReFuel();
                Destroy(obj);
                break;
            //Resupplying Object
            case "Resupply":
                attributeManager.ReSupply();
                Destroy(obj);
                break;
            //Buffing Refuel (CREATED BUT NOT IMPLEMENTED)
            case "RaiseRefuel":
                attributeManager.CoRouteReFuel(raiseAmounts);
                Destroy(obj);
                break;
            //Buffing Resupply (CREATED BUT NOT IMPLEMENTED)
            case "RaiseResupply":
                attributeManager.CoRouteReSupply(raiseAmounts);
                Destroy(obj);
                break;
            default:
                break;
        }
    }
}
