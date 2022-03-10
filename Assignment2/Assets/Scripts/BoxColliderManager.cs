using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColliderManager : MonoBehaviour
{
    [SerializeField]
    private GameObject CrossPiece;
    [SerializeField]
    private GameObject CirclePiece;

    [SerializeField]
    private int BoxNumber;

    [SerializeField]
    private TicTacToeManager TTTManager;

    private void OnMouseDown()
    {
        if (!TTTManager.IsFinished())
        {
            PlaceCrossPiece();
            //if (TTTManager.CheckTurn() == 0)
            //{
            //    PlaceCrossPiece();
            //}
            //else
            //{
            //    PlaceCirclePiece();
            //}
        }
    }

    public void PlaceCrossPiece()
    {
        Vector3 NewPosition = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        GameObject NewPiece = Instantiate(CrossPiece, NewPosition, Quaternion.Euler(90, 0, 0));
        TTTManager.UpdateBoard(BoxNumber, 0, true);
    }

    public void PlaceCirclePiece()
    {
        Vector3 NewPosition = new Vector3(transform.position.x, transform.position.y - 0.3f, transform.position.z);
        GameObject NewPiece = Instantiate(CirclePiece, NewPosition, Quaternion.Euler(90, 0, 0));
        TTTManager.UpdateBoard(BoxNumber, 1, false);
    }
}
