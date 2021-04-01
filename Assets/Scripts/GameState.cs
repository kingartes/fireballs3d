
using UnityEngine;

namespace Assets.Scripts
{
    class GameState : MonoBehaviour
    {
        [SerializeField] private Tower _tower;

        private void Awake()
        {
            _tower.sizeChanged += DisplayWinMesage;
        }

        private void OnDestroy()
        {
            _tower.sizeChanged -= DisplayWinMesage;
        }

        private void DisplayWinMesage(int towerSize)
        {
            if(towerSize == 0)
            {
                Debug.Log("You won");
            }
        }
    }
}
