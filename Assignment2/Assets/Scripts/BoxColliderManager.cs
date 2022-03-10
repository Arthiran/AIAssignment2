using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CrossPiece;
    [SerializeField]
    private GameObject CirclePiece;

    private void OnMouseDown()
    {
        PlaceCrossPiece();
    }

    void PlaceCrossPiece()
    {
        Vector3 NewPosition = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        GameObject NewPiece = Instantiate(CrossPiece, NewPosition, Quaternion.Euler(90, 0, 0));
    }

    void PlaceCirclePiece()
    {
        Vector3 NewPosition = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        GameObject NewPiece = Instantiate(CirclePiece, NewPosition, Quaternion.Euler(90, 0, 0));
    }
}
