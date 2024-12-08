using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    [SerializeField] AudioSource MsgPopFX;
    private PopUpManager popUpManager;

    (string verse, string description)[] popUpTexts =
        {
            ( "Psalm 56:3", "When I am afraid, I put my trust in you." ),
            ( "Jeremiah 31:3", "I have loved you with an everlasting love." ),
            ( "Isaiah 41:13", "I am the Lord your God who takes hold of your right hand." ),
            ( "Romans 8:31", "If God is for us, who can be against us?" ),
            ( "John 10:28", "I give them eternal life, and they shall never perish." ),
            ( "Matthew 28:20", "I am with you always, to the very end of the age." ),
            ( "2 Corinthians 12:9", "My grace is sufficient for you." ),
            ( "James 4:8", "Come near to God, and He will come near to you." ),
            ( "Psalm 46:1", "God is our refuge and strength, an ever-present help in trouble." ),
            ("Deuteronomy 31:6", "Be strong and courageous. Do not be afraid or terrified because of them, for the Lord your God goes with you; He will never leave you nor forsake you."),
            ("Isaiah 40:31", "But those who hope in the Lord will renew their strength. They will soar on wings like eagles; they will run and not grow weary, they will walk and not be faint."),
            ("Jeremiah 29:11", "For I know the plans I have for you, declares the Lord, plans to prosper you and not to harm you, plans to give you hope and a future."),
            ("Romans 8:28", "And we know that in all things God works for the good of those who love Him, who have been called according to His purpose."),
            ("Philippians 4:19", "And my God will meet all your needs according to the riches of His glory in Christ Jesus."),
            ("2 Corinthians 1:20", "For no matter how many promises God has made, they are 'Yes' in Christ. And so through Him the 'Amen' is spoken by us to the glory of God."),
            ("Joshua 1:9", "Have I not commanded you? Be strong and courageous. Do not be afraid; do not be discouraged, for the Lord your God will be with you wherever you go."),
            ("Psalm 37:4", "Take delight in the Lord, and He will give you the desires of your heart."),
            ("Matthew 11:28-29", "Come to me, all you who are weary and burdened, and I will give you rest. Take my yoke upon you and learn from me, for I am gentle and humble in heart, and you will find rest for your souls."),
            ("John 14:27", "Peace I leave with you; my peace I give you. I do not give to you as the world gives. Do not let your hearts be troubled and do not be afraid."),
            ("Psalm 91:4", "He will cover you with His feathers, and under His wings you will find refuge; His faithfulness will be your shield and rampart."),
            ("Isaiah 54:17", "No weapon forged against you will prevail, and you will refute every tongue that accuses you."),
            ("Proverbs 18:10", "The name of the Lord is a fortified tower; the righteous run to it and are safe."),
            ("2 Thessalonians 3:3", "But the Lord is faithful, and He will strengthen you and protect you from the evil one."),
            ("Deuteronomy 31:8", "The Lord Himself goes before you and will be with you; He will never leave you nor forsake you. Do not be afraid; do not be discouraged."),
            ("Psalm 121:7-8", "The Lord will keep you from all harm—He will watch over your life; the Lord will watch over your coming and going both now and forevermore."),
            ("Exodus 14:14", "The Lord will fight for you; you need only to be still."),
            ("Psalm 34:7", "The angel of the Lord encamps around those who fear Him, and He delivers them."),
            ("Nahum 1:7", "The Lord is good, a refuge in times of trouble. He cares for those who trust in Him.")
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
            (string verse, string description) = popUpTexts[randomIndex];

            // Trigger a pop-up with the selected verse and description
            popUpManager.CreatePopUp(verse, description);


            // Optional: Disable the trigger after activation to prevent reuse
            gameObject.SetActive(false);
        }
    }
}
