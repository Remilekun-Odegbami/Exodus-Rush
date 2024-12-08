using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    [SerializeField] AudioSource MsgPopFX;
    private PopUpManager popUpManager;

     public string[,] popUpTexts =
        {
            { "Psalm 56:3", "When I am afraid, I put my trust in you." },
            { "Jeremiah 31:3", "I have loved you with an everlasting love." },
            { "Isaiah 41:13", "I am the Lord your God who takes hold of your right hand." },
            { "Romans 8:31", "If God is for us, who can be against us?" },
            { "John 10:28", "I give them eternal life, and they shall never perish." },
            { "Matthew 28:20", "I am with you always, to the very end of the age." },
            { "2 Corinthians 12:9", "My grace is sufficient for you." },
            { "James 4:8", "Come near to God, and He will come near to you." },
            { "Psalm 46:1", "God is our refuge and strength, an ever-present help in trouble." },
            { "Exodus 14:14", "The Lord will fight for you; you need only to be still." }
        };


    private void Start()
    {
        // Find the PopUpManager in the scene
        popUpManager = FindObjectOfType<PopUpManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MsgPopFX.Play();
            // Select a random index
            int randomIndex = Random.Range(0, popUpTexts.Length);
            Debug.Log("pop up text is " + popUpTexts.Length);

            // Trigger a pop-up with the selected verse and description
            //  popUpManager.CreatePopUp(popUpTexts[randomIndex, 0], popUpTexts[randomIndex, 1]);
              popUpManager.CreatePopUp(popUpTexts[randomIndex, 0]);

            // Optional: Disable the trigger after activation to prevent reuse
            gameObject.SetActive(false);
        }
    }
}
