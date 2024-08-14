using CodeBase.Services.Input;
using UnityEngine;

namespace CodeBase.Infrastructure
{
    public class Game : MonoBehaviour
    {
        public static IInputService InputService;
        public GameStateMachine _stateMaachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            _stateMaachine = new GameStateMachine(new SceneLoader(coroutineRunner));
        }
    }
}
