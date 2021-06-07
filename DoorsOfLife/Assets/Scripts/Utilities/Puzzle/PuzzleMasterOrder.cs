using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[System.Serializable]
public struct ObjectAndOrder
{
    [SerializeField]
    private GameObject objectFit;
    [SerializeField]
    private int order;
    public GameObject ObjectFit => objectFit;
    public int Order => order;
}*/



public class PuzzleMasterOrder : MonoBehaviour
{
    [SerializeField]
    private PuzzleColliderOrder[] colliderOrd;


    private int _index = 0;

    public bool UpdateMaster(PuzzleColliderOrder pz)
    {
        if(colliderOrd[_index] == pz)
        {
            _index++;
            return true;
        }
        else
        {
            _index = 0;
            return false;
            //foreach(PuzzleColliderOrder p in colliderOrd)
            //{
            //    pz.ResetPositions();
            //}
        }
    }
}
