using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Timers;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public GameObject canvas;
    public float movespeed;
    float movespeedbuffer;
    float timer;
    public GameObject pawn;
    int cellID = 1;
    readonly GameObject[] cells = new GameObject[100];
    // Start is called before the first frame update
    void Start()        
    {
        for(int i=1; i<=100;i++)
        {
            cells[i-1] = GameObject.Find(i.ToString());
            Debug.Log("Cell Created" + i);
        }
        movespeedbuffer = movespeed;
        pawn.transform.position = cells[0].transform.position;
        transform.rotation = Camera.main.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (cellID >= 100)
        {
            canvas.SetActive(true);
            Debug.Log("You win");
        }
        Timer();
        pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[cellID - 1].transform.position, timer);
        SnakeAndLadders();
    }
    private void OnMouseDown()
    {
        movespeed = movespeedbuffer;
        transform.rotation = Camera.main.transform.rotation;
        switch (Random.Range(1,7))
        {
            case 1:
                transform.Rotate(transform.up * 90);
                transform.Rotate(transform.up * 90);
                transform.Rotate(transform.up * 90);
                if ((cellID + 1) > 100)
                {
                    break;
                }
                else
                {
                    cellID += 1;
                }
                
                break;
            case 2:
                transform.Rotate(transform.right * 90);
                transform.Rotate(transform.right * 90);
                transform.Rotate(transform.right * 90);
                if ((cellID + 2) > 100)
                {
                    break;
                }
                else
                {
                    cellID += 2;
                }
                
                break;
            case 3:
                transform.Rotate(transform.right * 90);
                transform.Rotate(transform.right * 90);
                if ((cellID + 3) > 100)
                {
                    break;
                }
                else
                {
                    cellID += 3;
                }
                
                break;
            case 4:
                if ((cellID + 4) > 100)
                {
                    break;
                }
                else
                {
                    cellID += 4;
                }
                break;
            case 5:
                transform.Rotate(transform.right * 90);
                if ((cellID + 5) > 100)
                {
                    break;
                }
                else
                {
                    cellID += 5;
                }
                
                break;
            case 6:
                transform.Rotate(transform.up * 90);
                if ((cellID + 6) > 100)
                {
                    break;
                }
                else
                {
                    cellID += 6;
                }
                
                break;
            default:break;
        }
        Debug.Log(cellID);
    }
    void SnakeAndLadders()
    {
        
        if(cells[cellID-1].layer==8)
        {
            switch(cellID)
            {
                case 43:
                    cellID = 17;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[16].transform.position, timer);
                    break;
                case 50:
                    cellID = 5;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[4].transform.position, timer);
                    break;
                case 56:
                    cellID = 8;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[7].transform.position, timer);
                    break;
                case 73:
                    cellID = 15;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[14].transform.position, timer);
                    break;
                case 84:
                    cellID = 58;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[57].transform.position, timer);
                    break;
                case 87:
                    cellID = 49;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[48].transform.position, timer);
                    break;
                case 98:
                    cellID = 40;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[39].transform.position, timer);
                    break;
                default:
                    break;
            }
        }
        if(cells[cellID-1].layer==9)
        {
            switch(cellID)
            {
                case 2:
                    cellID = 23;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[22].transform.position, timer);
                    break;
                case 4:
                    cellID = 68;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[67].transform.position, timer);
                    break;
                case 6:
                    cellID = 45;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[44].transform.position, timer);
                    break;
                case 20:
                    cellID = 59;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[58].transform.position, timer);
                    break;
                case 30:
                    cellID = 96;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[95].transform.position, timer);
                    break;
                case 52:
                    cellID = 72;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[71].transform.position, timer);
                    break;
                case 57:
                    cellID = 96;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[95].transform.position, timer);
                    break;
                case 71:
                    cellID = 92;
                    pawn.transform.position = Vector2.Lerp(pawn.transform.position, cells[91].transform.position, timer);
                    break;
                default:break;
            }
        }
        
    }
    //void PauseDice()
    //{
    //    this.GetComponent<BoxCollider>().enabled = false;
    //}
    //void PlayDice()
    //{
    //    this.GetComponent<BoxCollider>().enabled = true;
    //}
    void Timer()
    {
        timer = 1 - ((movespeed - Time.deltaTime) / movespeedbuffer);
    }
}
