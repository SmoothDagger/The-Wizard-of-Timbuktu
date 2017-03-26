using Assets.Scripts.Obstacle_Scripts;
using UnityEngine;

namespace Assets.Scripts.Effects
{
    public class Effect : MonoBehaviour
    {
        MonoBehaviour[] _scripts;
        Obstacles _obstacles;
        float EffectTime;

        void Start()
        {
            EffectTime = 5f;

            //stores all the scripts using MonoBehaviour on an object
            _scripts = gameObject.GetComponents<MonoBehaviour>();
            
            //disables all scripts except the Frozen Script;
            foreach (var script in _scripts)
            {
                if(script is Effect) continue;
                script.enabled = false;
            }
        }

        //Calculates the effect time remaining and destroy the effect when the time hits 0
        void Update()
        {
            EffectTime -= Time.deltaTime;
            if (EffectTime <= 0f)
                Destroy(this);
        }

        //Revert the object to its original state
        void OnDestroy()
        {
            //enables all scripts except the Frozen Script;
            foreach (var script in _scripts)
            {
                if (script is Effect) continue;
                script.enabled = true;
            }
                
        }
    }

}
