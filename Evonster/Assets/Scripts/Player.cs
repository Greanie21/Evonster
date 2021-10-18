using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Monster monster;
    GameManager gm;

    Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.AddPlayer(this);
        monster = GameObject.Find("Gobbo").GetComponent<Goblin>();
        startGoblin();
    }

    void startGoblin()
    {
        monster.Strength = 3;
        monster.Intelligence = 3;
        monster.Dexterity = 3;
        monster.Life = 10;
        monster.XTile = 2;
        monster.ZTile = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.playerTurn)
        {
            Vector3 mousePosition = Input.mousePosition;
            bool getButonDown = Input.GetMouseButtonDown(0);
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                getButonDown = (Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began);
                if (getButonDown)
                    mousePosition = Input.GetTouch(0).position;
            }

            Ray raycast = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit raycastHit;
            if (Physics.Raycast(raycast, out raycastHit))
            {
                if (raycastHit.collider.transform.tag == "Grid")
                {
                    if (getButonDown)
                    {
                        if (collider != null)
                        {
                            //se clicar em outro tile volta o ultimo selecionado para branco
                            collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1, 1, 1, 0.35f));
                        }
                        collider = raycastHit.collider;

                        collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1, 1, 0, 0.35f));
                    }
                }
            }
        }
    }

    public void ConfirmMove()
    {
        if (collider != null)
        {
            collider.gameObject.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1, 1, 1, 0.35f));

            Vector3 difference = (collider.transform.position - transform.position);
            float diffX = difference.x / 2;
            float diffZ = difference.z / 2;
            if (diffZ > 0)
            {
                if (gm.TryToMove(monster.XTile, monster.ZTile + 1, monster.XTile, monster.ZTile))
                {
                    monster.ZTile++;
                }
            }
            else if (diffZ < 0)
            {
                if (gm.TryToMove(monster.XTile, monster.ZTile - 1, monster.XTile, monster.ZTile))
                {
                    monster.ZTile--;
                }
            }
            else if (diffX > 0)
            {
                if (gm.TryToMove(monster.XTile + 1, monster.ZTile, monster.XTile, monster.ZTile))
                {
                    monster.XTile++;
                }
            }
            else if (diffX < 0)
            {
                if (gm.TryToMove(monster.XTile - 1, monster.ZTile, monster.XTile, monster.ZTile))
                {
                    monster.XTile--;
                }
            }
            collider = null;
        }
    }
}
