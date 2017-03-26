using Assets.Scripts.Effects;
using UnityEngine;

namespace Assets.Scripts.Obstacle_Scripts
{
    // Attached to Obstacles - Player object must have the "Player" tag
    public class Obstacles : MonoBehaviour
    {
        PlayerController _player;
        // Kills player when it touches the obstacle
        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                _player = other.GetComponent<PlayerController>();

                if(_player.CanDie)
                    GetObjectKilledBy();

                _player.Die();

                if (_player.CanDie)
                {
                    GameObject global = GameObject.FindWithTag("Global");
                    if (global)
                        global.GetComponent<GetObjectsPosition>().Reset();
                }
            }
        }

        void GetObjectKilledBy()
        {
            switch (tag)
            {
                case "Fire":
                    GameObject.Find("Fire death").GetComponent<AudioSource>().Play();
                    _player.timesKilledByFire++;
                    _player.isKilledByFire = true;
                    break;

                case "Water":
                    GameObject.Find("Water death").GetComponent<AudioSource>().Play();
                    _player.timesKilledByWater++;
                    _player.isKilledByWater = true;
                    break;

                case "Rhino":
                    GameObject.Find("Rhino death").GetComponent<AudioSource>().Play();
                    _player.timesKilledByRhino++;
                    _player.isKilledByRhino = true;
                    break;

                case "Crocodile":
                    _player.timesKilledByCrocodile++;
                    _player.isKilledByCrocodile = true;
                    break;

                case "Lava":
                    GameObject.Find("Lava death").GetComponent<AudioSource>().Play();
                    _player.timesKilledByLava++;
                    _player.isKilledByLava = true;
                    break;

                case "Swinging Axe":
                    _player.timesKilledBySwingingAxe++;
                    _player.isKilledBySwingingAxe = true;
                    break;

                case "Grass Spikes":
                    _player.timesKilledByGrassSpikes++;
                    _player.isKilledByGrassSpikes = true;
                    break;

                case "Log":
                    _player.timesKilledByFallingLog++;
                    _player.isKilledByFallingLog = true;
                    break;

                case "Saw Blade":
                    GameObject.Find("Saw blade death").GetComponent<AudioSource>().Play();
                    _player.timesKilledBySawBlade++;
                    _player.isKilledBySawBlade = true;
                    break;

                default:
                    break;
            }
        }
    }
}
