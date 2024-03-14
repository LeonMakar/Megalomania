using TMPro;
using UnityEngine;
using Zenject;

public class GameStateMachine : StateMachine<GameStateMachine.GameStates>
{
    [field: SerializeField] public GameObject GameOVerPanel { get; private set; }
    [field: SerializeField] public TextMeshProUGUI GameOverText { get; private set; }


    [Inject]
    private void Construct()
    {
        GameIsPassiveState gameIsPassiveState = new GameIsPassiveState(GameStates.GamePassive,this);
        GameISActiveState gameISActiveState = new GameISActiveState(GameStates.GameActive);
        GameOverState gameOverState = new GameOverState(GameStates.GameOver,this);

        States.Add(GameStates.GamePassive, gameIsPassiveState);
        States.Add(GameStates.GameActive, gameISActiveState);
        States.Add(GameStates.GameOver, gameOverState);


        StartStateMachine(GameStates.GameActive);
    }

    public void SetGameOver() => TransitionToNextState(GameStates.GameOver);

    public void SetGameIsWin() => TransitionToNextState(GameStates.GamePassive);


    public enum GameStates
    {
        GamePassive,
        GameActive,
        GameOver,
    }
}
