using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class SliderControl : MonoBehaviour
{
    GameObject clothSimulation;

    public Slider dampingCoefficientSlider;
    public TextMeshProUGUI dampingCoefficientIndicator;

    public Slider stiffnessSlider;
    public TextMeshProUGUI stiffnessIndicator;

    public Slider restLengthSlider;
    public TextMeshProUGUI restLengthIndicator;

    public Slider gravitationalFieldXSlider;
    public TextMeshProUGUI gravitationalFieldXIndicator;

    public Slider gravitationalFieldYSlider;
    public TextMeshProUGUI gravitationalFieldYIndicator;

    public Slider gravitationalFieldZSlider;
    public TextMeshProUGUI gravitationalFieldZIndicator;

    public Slider windVelocityXSlider;
    public TextMeshProUGUI windVelocityXIndicator;

    public Slider windVelocityYSlider;
    public TextMeshProUGUI windVelocityYIndicator;

    public Slider windVelocityZSlider;
    public TextMeshProUGUI windVelocityZIndicator;

    public Slider normalToPlaneXSlider;
    public TextMeshProUGUI normalToPlaneXIndicator;

    public Slider normalToPlaneYSlider;
    public TextMeshProUGUI normalToPlaneYIndicator;

    public Slider normalToPlaneZSlider;
    public TextMeshProUGUI normalToPlaneZIndicator;

    public Slider dimensionsXSlider;
    public TextMeshProUGUI dimensionsXIndicator;

    public Slider dimensionsYSlider;
    public TextMeshProUGUI dimensionsYIndicator; 

    public TMP_InputField attachingInstructionsInputField;  

    void Start()
    {
        dampingCoefficientSlider.value = 4.0f/9.0f;
        stiffnessSlider.value = 0.5f;
        restLengthSlider.value = 0.5f;
        gravitationalFieldXSlider.value = 0.5f;
        gravitationalFieldYSlider.value = 0.5f;
        gravitationalFieldZSlider.value = 0.45f;
        windVelocityXSlider.value = 0.5f;
        windVelocityYSlider.value = 0.5f;
        windVelocityZSlider.value = 0.5f;
        normalToPlaneXSlider.value = 0.5f;
        normalToPlaneYSlider.value = 0.5f;
        normalToPlaneZSlider.value = 11.0f/20f;
        dimensionsXSlider.value = 0.24f;
        dimensionsYSlider.value = 0.49f;
        attachingInstructionsInputField.text = "first side, third side"; 
    }

    void Update()
    {
        clothSimulation = GameObject.Find("clothSimulation");
        ClothSim.ClothSim clothSim = clothSimulation.GetComponent<ClothSim.ClothSim>();

        dampingCoefficientIndicator.text = (0.1f + 0.9f*dampingCoefficientSlider.value).ToString("0.0");
        clothSim.dampingCoefficient = (0.1f + 0.9f*dampingCoefficientSlider.value);

        stiffnessIndicator.text = (20*stiffnessSlider.value).ToString("0.0");
        clothSim.stiffness = (20*stiffnessSlider.value);

        restLengthIndicator.text = (2*restLengthSlider.value).ToString("0.0");
        clothSim.restLength = (2*restLengthSlider.value);

        gravitationalFieldXIndicator.text = (-10 + 20*gravitationalFieldXSlider.value).ToString("0.0");
        clothSim.gravitationalField.x = (-10 + 20*gravitationalFieldXSlider.value);

        gravitationalFieldYIndicator.text = (-10 + 20*gravitationalFieldYSlider.value).ToString("0.0");
        clothSim.gravitationalField.y = (-10 + 20*gravitationalFieldYSlider.value);

        gravitationalFieldZIndicator.text = (-10 + 20*gravitationalFieldZSlider.value).ToString("0.0");
        clothSim.gravitationalField.z = (-10 + 20*gravitationalFieldZSlider.value);

        windVelocityXIndicator.text = (-10 + 20*windVelocityXSlider.value).ToString("0.0");
        clothSim.windVelocity.x = (-10 + 20*windVelocityXSlider.value);

        windVelocityYIndicator.text = (-10 + 20*windVelocityYSlider.value).ToString("0.0");
        clothSim.windVelocity.y = (-10 + 20*windVelocityYSlider.value);

        windVelocityZIndicator.text = (-10 + 20*windVelocityZSlider.value).ToString("0.0");
        clothSim.windVelocity.z = (-10 + 20*windVelocityZSlider.value);

        normalToPlaneXIndicator.text = (-10 + 20*normalToPlaneXSlider.value).ToString("0.0");
        clothSim.normalToPlane.x = (-10 + 20*normalToPlaneXSlider.value);

        normalToPlaneYIndicator.text = (-10 + 20*normalToPlaneYSlider.value).ToString("0.0");
        clothSim.normalToPlane.y = (-10 + 20*normalToPlaneYSlider.value);

        normalToPlaneZIndicator.text = (-10 + 20*normalToPlaneZSlider.value).ToString("0.0");
        clothSim.normalToPlane.z = (-10 + 20*normalToPlaneZSlider.value);

        dimensionsXIndicator.text = ((int) Math.Floor(1 + 39*dimensionsXSlider.value)).ToString("0");
        clothSim.dimensions.x = (int) Math.Floor(1 + 39*dimensionsXSlider.value);

        dimensionsYIndicator.text = ((int) Math.Floor(1 + 39*dimensionsYSlider.value)).ToString("0");
        clothSim.dimensions.y = (int) Math.Floor(1 + 39*dimensionsYSlider.value);

        clothSim.attachingInstructions = attachingInstructionsInputField.text;
    }
}
