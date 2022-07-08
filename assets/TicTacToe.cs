using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TicTacToe : MonoBehaviour
{
    // Spaces
    private int[] board = new int[9];
    private int player = 1;
    // 0 = X, 1 = O
    public bool AI = false;
    public Button s_0;
    public Button s_1;
    public Button s_2;
    public Button s_3;
    public Button s_4;
    public Button s_5;
    public Button s_6;
    public Button s_7;
    public Button s_8;
    public GameObject s_holder;
    public TMP_Text game_over;
    
    private Button[] buttons;

    public void restart() {
        board = new int[9];
        for(int i = 0; i < buttons.Length; i++){
            GameObject button = buttons[i].gameObject.transform.GetChild(0).gameObject;
            TMP_Text buttonText = button.GetComponent<TMP_Text>();
            buttonText.text = "";
        }
        game_over.gameObject.SetActive(false);
        s_holder.SetActive(true);
    }

    void Start()
    {
        buttons = new Button[9]{s_0, s_1, s_2, s_3, s_4, s_5, s_6, s_7, s_8};
    }

    bool winConditions() {
        for (int i = 2; i < 9; i+=3){
            if(board[i-1] == player && board[i-2] == player && board[i] == player){
                return true;
            }
        }
        int check2 = 0;
        for(int k = 0;k<3;k++){
            for (int i = k; i < 9; i+=3){
                if (board[i] == player){
                    if (k == 2){
                        print(check2+1);
                    }
                    check2++;
                }
            }
            if(check2 >= 3){
                return true;
            }
            check2 = 0;
        }

        if (check2 == 3){
            return true;
        }

        if(board[0] == player && board[4] == player && board[8] == player || board[2] == player && board[4] == player && board[6] == player){
            return true;
        }


        return false;
    }

    public void turn(int coords) {
        
        if (AI && coords == -1){
            if (board[3] < 2){
                board[3] = 2;
                GameObject button = s_3.gameObject.transform.GetChild(0).gameObject;
                TMP_Text buttonText = button.GetComponent<TMP_Text>();
                buttonText.text = "O";
            }
            else if (board[4] < 2){
                GameObject button = s_4.gameObject.transform.GetChild(0).gameObject;
                TMP_Text buttonText = button.GetComponent<TMP_Text>();
                buttonText.text = "O";
                board[4] = 2;
            }
            else {
                GameObject button = s_5.gameObject.transform.GetChild(0).gameObject;
                TMP_Text buttonText = button.GetComponent<TMP_Text>();
                buttonText.text = "O";
                board[5] = 2;
            }
        }
        else if (board[coords] == 0){
            board[coords] = player;
            
            GameObject button = buttons[coords].gameObject.transform.GetChild(0).gameObject;
            TMP_Text buttonText = button.GetComponent<TMP_Text>();

            if (winConditions()){
                game_over.gameObject.SetActive(true);
                s_holder.SetActive(false);
            }

            if (player == 1){
                buttonText.text = "X";
                player++;
                if (AI){
                    turn(-1);
                    player = 1;
                }
            } else {
                buttonText.text = "O";
                player--;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
