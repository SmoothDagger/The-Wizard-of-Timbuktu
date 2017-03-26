using UnityEngine;

namespace Assets.Scripts
{
    public class Rotate : MonoBehaviour
    {
        public float Speed;

        void Start()
        {
            //tag = "Obstacle";
        }
	
        // Update is called once per frame
        void Update ()
        {
            
            transform.Rotate(new Vector3(0,0,1), Speed * Time.deltaTime);
        }
    }
}
