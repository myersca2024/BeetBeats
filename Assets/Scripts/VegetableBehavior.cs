using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VegetableBehavior : MonoBehaviour
{

    public ChoppingNoteSpawner noteSpawner;
    public GameManager gameManager;
    public Composer composer;

    private List<GameObject> veggies;
    private GameObject currVeg;
    private GameObject nextVeg;

    public GameObject posCurrentVeg;
    public GameObject posOnDeck;

    public int vegIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        veggies = noteSpawner.vegetables;
        currVeg = Instantiate(veggies[0], posCurrentVeg.transform.position, posCurrentVeg.transform.rotation);
        currVeg.gameObject.SetActive(true);
        nextVeg = Instantiate(veggies[2], posOnDeck.transform.position, posOnDeck.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        if (composer.songPositionInBeats != 0f)
        {
            float currentVeg = Mathf.Floor((Mathf.Floor(composer.songPositionInBeats) - 9f) / 4f);
           // Debug.Log("Current Veg: " + currentVeg + "\nVeg Index : " + vegIndex);
            if (currentVeg > vegIndex)
            {
                Debug.Log("vegIndex " + vegIndex);
                Debug.Log("Mod statement " + ((vegIndex + 1) % 2));
                if ((vegIndex + 1) % 2 == 0)
                {
                    Debug.Log("Next veg!");
                    //new veg moves in
                    currVeg.gameObject.SetActive(false);
                    vegIndex += 1;
                    nextVeg.transform.position = posCurrentVeg.transform.position;
                    currVeg = nextVeg;
                    if (vegIndex + 2 <= veggies.Count - 1)
                    {
                        nextVeg = Instantiate(veggies[vegIndex + 2], posOnDeck.transform.position, posOnDeck.transform.rotation);
                    }
                }
                else
                {
                    Debug.Log("Peeled!");
                    currVeg.gameObject.SetActive(false);
                    vegIndex += 1;
                    if (vegIndex <= veggies.Count - 1)
                    {
                        currVeg = Instantiate(veggies[vegIndex], posCurrentVeg.transform.position, posCurrentVeg.transform.rotation);
                    }
                    // replace curr veg with peeled version
                }       
              }
            if (vegIndex <= veggies.Count - 1)
            {
                veggies[vegIndex].transform.position = posCurrentVeg.transform.position;
            }

        }
       
    }
}
