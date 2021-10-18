using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player player;
    public bool playerTurn = true;
    eBoard[,] board;
    enum eBoard
    {
        Empty = 0,
        Ally = 1,
        Enemy = 2
    }
    UiManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        board = new eBoard[,] { { eBoard.Empty, eBoard.Empty, eBoard.Empty },
                                { eBoard.Empty, eBoard.Empty, eBoard.Empty },
                                { eBoard.Empty, eBoard.Empty, eBoard.Ally },
                                { eBoard.Empty, eBoard.Empty, eBoard.Empty },
                                { eBoard.Empty, eBoard.Empty, eBoard.Empty },
                                { eBoard.Empty, eBoard.Empty, eBoard.Empty },
                                { eBoard.Empty, eBoard.Empty, eBoard.Enemy },
                              };


        for (int i = 0; i < board.GetLength(1); i++)
        {
            for (int j = 0; j < board.GetLength(0); j++)
            {
                GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                cube.transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
                cube.transform.tag = "Grid";
                cube.GetComponent<MeshRenderer>().material.SetOverrideTag("RenderType", "Transparent");
                cube.GetComponent<MeshRenderer>().material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                cube.GetComponent<MeshRenderer>().material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                cube.GetComponent<MeshRenderer>().material.SetInt("_ZWrite", 0);
                cube.GetComponent<MeshRenderer>().material.DisableKeyword("_ALPHATEST_ON");
                cube.GetComponent<MeshRenderer>().material.EnableKeyword("_ALPHABLEND_ON");
                cube.GetComponent<MeshRenderer>().material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                cube.GetComponent<MeshRenderer>().material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
                cube.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1, 1, 1, 0.35f));
                cube.transform.position = new Vector3(i*2, 0.0f, j*2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddPlayer(Player player)
    {
        this.player = player;
    }

    public bool TryToMove(int x, int z, int oldX, int oldZ)
    {
        //Debug.Log("X=" + oldX + "/TU quer ir para" + x + "/Tamanho total=" + board.GetLength(1));
        //Debug.Log("z=" + oldZ + "/TU quer ir para" + z + "/Tamanho total=" + board.GetLength(0));
        if (x < 0 || x >= board.GetLength(1))
        {
            return false;
        }
        if (z < 0 || z >= board.GetLength(0))
        {
            return false;
        }
        if (board[z, x] == eBoard.Empty)
        {
            //playerTurn = !playerTurn;
            board[z, x] = board[oldZ, oldX];
            board[oldZ, oldX] = eBoard.Empty;
            return true;
        }
        Debug.Log("enemy");
        return false;
    }
}
