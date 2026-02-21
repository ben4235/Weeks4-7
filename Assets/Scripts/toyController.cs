using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToyController : MonoBehaviour
{
    //prefab for the ball objects
    public GameObject ballPrefab;

    //the dropper object game object
    public GameObject dropper;

    //slider variable. moving the slider will change the position of the dropper
    public Slider positionSlider;

    /*text labels that can be updated dynamically through the code. will contain the information for how many balls have
    been dropped + will show the current x position of the dropper.*/
    public TMP_Text ballCountText;
    public TMP_Text dropPositionText;

    //float containing how far the ball can be moved in the x direction (both negative and positive (-7 <-> +7)
    public float dropRangeX = 7f;

    //the y position in which balls get spawned
    public float dropY = 3.5f;

    //how fast the dropper spins
    public float dropperRotateSpeed = 45f;

    //using the list to keep track of items as the game is playing. 
    //using the list is nice because we can change the size of it as we go on... keeping track of the balls a. lets us know how many balls are on screen at any time, and b. gives us a way to destroy all tracked items. 
    private List<GameObject> activeBalls = new List<GameObject>();

    void Start()
    {
        //initializing our ui through start
        UpdateBallCountUI();
    }

    void Update()
    {

        //we need to move the dropper to where the slider value is
        //the slider only goes from 0-1 so we need to map the range through lerp function.
        //when the slider = 0 we want the x to be -7, when the slider = 1 we want the x to be +7
        float targetX = Mathf.Lerp(-dropRangeX, dropRangeX, positionSlider.value);

        //now we need to set the position of the dropper in the world.
        dropper.transform.position = new Vector3(targetX, dropY, 0f);

        //this is for rotating the dropper, transform.rotate will add rotation every frame. 
        //we want to rotate the dropper around the z axis in order for it to swing left and right.
        dropper.transform.Rotate(0f, 0f, dropperRotateSpeed * Time.deltaTime);

        //check the list and remove every entry where the condition is true. 
        activeBalls.RemoveAll(b => b == null);

        //update the ball count
        UpdateBallCountUI();
    }

    //function to be called by the button onClick. 
    public void OnDropButtonPressed()
    {
        //creating the spawn position. the x value stays the same as the dropper, (-0.5) just drops the ball lower 
        Vector3 spawnPos = new Vector3(dropper.transform.position.x, dropY - 0.5f, 0f);

        //when the button is pressed, create a new ball prefab on the screen
        GameObject newBall = Instantiate(ballPrefab, spawnPos, Quaternion.identity);

        //add the ball to the list
        activeBalls.Add(newBall);

        //call the function to update the ui
        UpdateBallCountUI();
    }

    //when the clear button gets pressed
    public void OnClearButtonPressed()
    {
        //check every ball in the list
        foreach (GameObject ball in activeBalls)
        {
            //check to make sure all the balls we clocked are still truly there, prevent bugs
            if (ball != null)
            {
                //when we know we are good to go, DESTROY!
                Destroy(ball);
            }
        }
        //empties the list of balls
        activeBalls.Clear();

        //call the function to update the ui
        UpdateBallCountUI();
    }

    //function to update the UI text. 
    private void UpdateBallCountUI()
    {
        //count only the entries that are not null
        int count = 0;
        //check how many balls are stored in the list 
        foreach (GameObject b in activeBalls)
        {
            if (b != null) count++;
        }
        //this will join the string + the count of the current list.
        ballCountText.text = "Balls: " + count;
    }
}