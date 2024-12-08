using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;


public class PopUpManager : MonoBehaviour
{
    public GameObject popUpPrefab;
    public GameObject canvasObject;

   //public string[,] popUpTexts =
   //     {
   //         { "Psalm 56:3", "When I am afraid, I put my trust in you." },
   //         { "Jeremiah 31:3", "I have loved you with an everlasting love." },
   //         { "Isaiah 41:13", "I am the Lord your God who takes hold of your right hand." },
   //         { "Romans 8:31", "If God is for us, who can be against us?" },
   //         { "John 10:28", "I give them eternal life, and they shall never perish." },
   //         { "Matthew 28:20", "I am with you always, to the very end of the age." },
   //         { "2 Corinthians 12:9", "My grace is sufficient for you." },
   //         { "James 4:8", "Come near to God, and He will come near to you." },
   //         { "Psalm 46:1", "God is our refuge and strength, an ever-present help in trouble." },
   //         { "Exodus 14:14", "The Lord will fight for you; you need only to be still." }
   //     };

    private void Start()
    {    

       // CreatePopUps(popUpTexts);
    }

    public void CreatePopUps(string[,] textsArray)
    {
        for (int i = 0; i < textsArray.GetLength(0); i++)
        {
            string name = textsArray[i, 0];
            string description = textsArray[i, 1];
            CreatePopUp(name, description);
        }
    }

    public void CreatePopUp(string verse, string Description)
    {
        GameObject createdPopUpObject = Instantiate(popUpPrefab, canvasObject.transform);
        createdPopUpObject.GetComponent<PopUpTexts>().SetPopUpDescriptionText(Description);
        createdPopUpObject.GetComponent<PopUpTexts>().SetPopUpVerse(verse);
        MovePopUp(createdPopUpObject);
    }

    public void MovePopUp(GameObject createdPopUpObject)
    {
        createdPopUpObject.GetComponent<RectTransform>().DOAnchorPosX(-100, 3f).OnComplete(() => Destroy(createdPopUpObject));
    }
}
