using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;



namespace Player
{
    [RequireComponent(typeof(InputManager), typeof(Rigidbody2D))]    
    public class PlayerController : MonoBehaviour, IFlowMovable
    
    {
        private Rigidbody2D _rb;
        public int maxTrash = 50;
        public int currentTrash;
        public TrashBar trashBar;
        public float maxVelocity = 20;

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

        
        public void ApplyFlow() {
            _rb.velocity += this.CurrentFlowDir * this.CurrentFlowForce;
        }

        public void Start(){
            currentTrash = 0;
            trashBar.setMaxTrash(maxTrash);
            trashBar.setTrash(currentTrash);
        }

        [field: HideInInspector] public Vector2 MovementInput { get; set; }

        // Movement Variables
        [SerializeField, Range(0f, 50f)]
        private float maxSpeed = 5f;
        [SerializeField, Range(0f, 100f)]
        public float maxAcceleration = 30f;
        [SerializeField, Range(0f, 100f)]
        public float maxDeceleration = 40f;
        
        [SerializeField, Range(0f, 100f)]
        public float turnAcceleration = 50f;
    
        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    
        private float GetAcceleration(float previousVelocity, float desiredVelocity)
        {
            if (previousVelocity * desiredVelocity < 0)
            {
                return turnAcceleration;
            }
            else if (Mathf.Abs(previousVelocity) < Mathf.Abs(desiredVelocity))
            {
                return maxAcceleration;
            }
            else
            {
                return maxDeceleration;
            }
        }
    
        private void FixedUpdate()
        {
            Vector2 desiredVelocity =
                MovementInput * maxSpeed;

            Vector2 maxVelocityChange = new Vector2(
                GetAcceleration(_rb.velocity.x, desiredVelocity.x),
                GetAcceleration(_rb.velocity.y, desiredVelocity.y)
            ) * Time.fixedDeltaTime;

            Vector2 newVelocity = new Vector2(
                Mathf.MoveTowards(_rb.velocity.x, desiredVelocity.x, maxVelocityChange.x),
                Mathf.MoveTowards(_rb.velocity.y, desiredVelocity.y, maxVelocityChange.y)
            );

            if (newVelocity.x <= maxVelocity) {
                _rb.velocity = newVelocity;
            } else {
                Vector2 velMax = new Vector2(20f,_rb.velocity.y);
                _rb.velocity = velMax;

            }
            Debug.Log(newVelocity);

            this.ApplyFlow();

        }

        void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObj = collision.gameObject;
        if (otherObj.tag == "Trash" && currentTrash < maxTrash)
        {
            Destroy(otherObj);
            currentTrash+=10;
            trashBar.setTrash(currentTrash);
        }else if(otherObj.tag == "Vaisseau"){
            //Launch cinematic
            Debug.Log("Vaisseau");
            
        }
    }
    }
}