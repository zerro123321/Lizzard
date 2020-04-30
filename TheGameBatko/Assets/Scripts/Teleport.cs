using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform LinkedObject;
    private Transform ParentObject;
    private Transform PlayerTransform;
    //private Teleport LinkedObjectTeleport;

    public bool isTeleported;
    public int teleDelay = 1500;

    void Start()
    {
        isTeleported = false;
        ParentObject = gameObject.transform.parent;
        LinkedObject = ParentObject.GetComponentsInChildren<Transform>()
            .FirstOrDefault(t => t.name != gameObject.name && t.name != ParentObject.name && t.name.Contains("Teleport"));
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!(collision is CircleCollider2D))
        {
            return;
        }
        //var salam = LinkedObject.transform.GetComponents(typeof(Teleport));
        var tele = (Teleport)LinkedObject.transform.GetComponents(typeof(Teleport))[0];

        if (!isTeleported && collision.tag == "Player")
        {
            tele.isTeleported = true;
            var teleportSpot = LinkedObject.GetComponentsInChildren<Transform>()
                .FirstOrDefault(t => t.name.Contains("Spot"));
            PlayerTransform.position = teleportSpot.position;
            var playerController = PlayerTransform.gameObject.GetComponent<PlayerController2D>();
            playerController.isBlocked = true;
            Task.Run(() => {
                Thread.Sleep(teleDelay);
                playerController.isBlocked = false;
            });
        }
        isTeleported = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isTeleported)
        {
            var tele = (Teleport)LinkedObject.transform.GetComponents(typeof(Teleport))[0];
            tele.isTeleported = false;
        }
      
    }
}
