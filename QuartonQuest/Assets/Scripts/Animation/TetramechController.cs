using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Animations;

public class TetramechController : MonoBehaviour
{
    public Animator charAnim;
    // Start is called before the first frame update
    void Start()
    {
        charAnim = GetComponent<Animator>();
        GameCoreController.Instance.GameOver += GameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if(!GameCoreController.Instance.IsGameOver)
        {
            if (GameCoreController.Instance.IsPlayerTurn)
            {
                if (name == "PlayerCharacter")
                {
                    charAnim.Play("Armature_ThinkingAction");
                }
            }
            else if (GameCoreController.Instance.CurrentTurn == GameCoreController.GameTurnState.OPPONENT)
            {
                if (name == "PlayerCharacter")
                {
                    charAnim.Play("Armature_ArmatureAction");
                }
            }
        }
    }

    public void GameOver()
    {
        switch (GameCoreController.Instance.CurrentTurn)
        {
            case GameCoreController.GameTurnState.PLAYERWON:
            case GameCoreController.GameTurnState.OPPONENTFORFEIT:
                if (name == "PlayerCharacter")
                {
                    charAnim.Play("Armature_WinAction");
                }
                else
                {
                    charAnim.Play("Armature_LoseAction");
                }
                break;
            case GameCoreController.GameTurnState.OPPONENTWON:
            case GameCoreController.GameTurnState.PLAYERFORFEIT:
                if (name != "PlayerCharacter")
                {
                    charAnim.Play("Armature_WinAction");
                }
                else
                {
                    charAnim.Play("Armature_LoseAction");
                }
                break;
            case GameCoreController.GameTurnState.GAMETIED:
                //At tie, both play lose action
                charAnim.Play("Armature_LoseAction");
                break;
        }
    }
}
