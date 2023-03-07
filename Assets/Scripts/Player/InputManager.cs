using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    [RequireComponent(typeof(PlayerController))]
    public class InputManager : MonoBehaviour, IFlowMovable
    {
        private Camera viewCam;
        public ReadTwoArduinoValuesExample myArduino;
        public bool locked = false;        
        private PlayerController _playerController;

        private Vector2 currentFlowDir;
        public Vector2 CurrentFlowDir
        {
            get
            {
                return currentFlowDir;
            }
            set
            {
                currentFlowDir = value;
            }
        }

        private float currentFlowForce;
        public float CurrentFlowForce
        {
            get
            {
                return currentFlowForce;
            }
            set
            {
                currentFlowForce = value;
            }
        }

        private void Awake()
        {
            _playerController = GetComponent<PlayerController>();
        }
        
        private void Start()
        {
            viewCam = Camera.main;
            IFlowMovable.CurrentFlowForce.set(1f);
            IFlowMovable.CurrentFlowDir.set(Vector2 (0,0));
        }
        
        private void Update()
        {

            
            
            if (locked)
                return;
            
            float horizontalMovement = Input.GetAxisRaw("Horizontal");
            float verticalMovement = Input.GetAxisRaw("Vertical");
            
            // FR : Lecture de la 1er valeur
            // EN : Read the first value   
            /*
            float horizontalMovement = myArduino.values[0];
            float verticalMovement = myArduino.values[1];*/
            // FR : Lecture de la 2eme valeur
            // EN : Read the second value
            
            _playerController.MovementInput = Vector2.ClampMagnitude(new Vector2(horizontalMovement, verticalMovement), 1);


        }


        void IFlowMovable.ApplyFlow() {
            this.velocity = this.CurrentFlowDir.get() * this.CurrentFlowForce.get();
        }

        void IFlowMovable.updateEnterCurrent() {
            this.CurrentFlowDir.set(Vector2 (0,10));
            this.CurrentFlowForce.set(2.0f);
        }

        void IFlowMovable.updateExitCurrent() {
            this.CurrentFlowDir.set(Vector2 (0,0));
            this.CurrentFlowForce.set(0f);
        }


    }
}
