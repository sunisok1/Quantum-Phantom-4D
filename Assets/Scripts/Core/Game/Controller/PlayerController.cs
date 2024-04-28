using UnityEngine;

namespace Core.Game.Controller
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Main main; // Reference to the Main class that handles movement logic

        private void Update()
        {
            // Move forward
            if (Input.GetKeyUp(KeyCode.W))
            {
                main.MoveForward();
            }

            // Move backward
            if (Input.GetKeyUp(KeyCode.S))
            {
                main.MoveBack();
            }

            // Move left
            if (Input.GetKeyUp(KeyCode.A))
            {
                main.MoveLeft();
            }

            // Move right
            if (Input.GetKeyUp(KeyCode.D))
            {
                main.MoveRight();
            }

            // Move up (ascend)
            if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.RightShift))
            {
                main.MoveUp();
            }

            // Move down (descend)
            if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.RightControl))
            {
                main.MoveDown();
            }

            // Switch dimension
            if (Input.GetKeyUp(KeyCode.Space))
            {
                main.SwitchDimen();
            }
        }
    }
}