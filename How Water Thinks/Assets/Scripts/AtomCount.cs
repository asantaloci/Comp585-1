﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AtomCount : MonoBehaviour {

    float targetVoltage;
    int i = 0;
    public int KAtomsOut;
    public int KAtomsIn;
    public int NaAtomsOut;
    public int NaAtomsIn;
    public int ClAtomsOut;
    public int ClAtomsIn;
    public int numAtomsOuter;
    public int numAtomsInner;
    public float voltageOuter;
    public float voltageInner;
    public float voltage;
    public float oldVoltage;
    public float reflectChance = 0;
    public float minVoltage;
    public float maxVoltage;
    public GameObject zeroMembrane;

    // Use this for initialization
    void Start () {
        targetVoltage = 0;
	}

    public float getTargetVoltage()
    {
        return targetVoltage;
    }
    public float getVoltageOuter()
    {
        return voltageOuter;
    }

    public float getVoltageInner()
    {
        return voltageInner;
    }

    public float getVoltage()
    {
        return voltage;
    }

    // Update is called once per frame
    void Update () {
        //Getting the number of atoms inside and outside
        //numAtomsOuter = 0;
        //numAtomsInner = 0;
        voltageOuter = 0;
        voltageInner = 0;
        voltage = 0;
        maxVoltage = 0;
        minVoltage = 0;
        NaAtomsIn = 0;
        NaAtomsOut = 0;
        KAtomsIn = 0;
        KAtomsOut = 0;
        ClAtomsOut = 0;
        ClAtomsIn = 0;
        voltage = 0;


        foreach (GameObject atom in GameObject.FindGameObjectsWithTag("SodiumAtom")) {
            if (atom.transform.position.y > 214.95)
            {
                NaAtomsOut++;
                voltage--;
            }
            else
            {
                NaAtomsIn++;
                voltage++;
            }
        }
        foreach (GameObject atom in GameObject.FindGameObjectsWithTag("PotassiumAtom"))
        {
            if (atom.transform.position.y > 214.95)
            {
                KAtomsOut++;
                voltage--;
            }
            else
            {
                KAtomsIn++;
                voltage++;
            }

        }
        foreach (GameObject atom in GameObject.FindGameObjectsWithTag("ChlorineAtom"))
        {
            if (atom.transform.position.y > 214.95)
            {
                ClAtomsOut++;
                voltage++;
            }
            else
            {
                ClAtomsIn++;
                voltage--;
            }

        }
        // voltage = (NaAtomsIn + KAtomsIn + ClAtomsOut) - (NaAtomsOut + KAtomsOut + ClAtomsIn);
        if (oldVoltage == 0) {oldVoltage = voltage;}
        //print(zeroMembrane.active);
        if (voltage != oldVoltage) {
            if(zeroMembrane.active == false)
            {
                GameObject.Find("AtomCrossingSound").GetComponent<AudioSource>().Play();
            }
        }
        oldVoltage = voltage;
        
        float rTF = 14.06f;
        // string deltaVCountText;
        // if (voltage > 0) deltaVCountText = "+" + System.Math.Round(rTF * Mathf.Log(voltage), 2);
        // else if (voltage < 0) deltaVCountText = "-" + System.Math.Round(rTF * Mathf.Log(-voltage), 2);
        // else deltaVCountText = "0.00";

        if (voltage > 0) voltage = rTF * Mathf.Log(voltage);
        else if (voltage < 0) voltage = rTF * -Mathf.Log(-voltage);
        else voltage = 0;

        // print("voltage: " + voltage + "      newVoltage: " + deltaVCountText);

        
        if (GameObject.FindGameObjectWithTag("Voltage") != null) GameObject.FindGameObjectWithTag("Voltage").GetComponent<Slider>().value = voltage;
        if (GameObject.FindGameObjectWithTag("VoltageText") != null) GameObject.FindGameObjectWithTag("VoltageText").GetComponent<Text>().text = "" + voltage;
        //print(NaAtomsOut + KAtomsOut);
        //print(KAtomsIn + NaAtomsIn);
        //print("voltage: " + voltage);
        //I commented this out...they were deleting k atoms above the membrane for some reason.

        // foreach (GameObject atom in GameObject.FindGameObjectsWithTag("PotassiumAtom"))
        // {
        //     if (atom.transform.position.y > 214.95)
        //     {
        //         /*numAtomsOuter += 1;
        //         voltage--;
        //         voltageOuter++;*/
        //         print("destroying atom");
        //         Destroy(atom);
        //         GameObject.FindGameObjectWithTag("Atoms").GetComponent<CreateAtoms>().AddNAtoms(1, 1, 0, 0, 1);
        //     }
        //     else
        //     {
        //         numAtomsInner += 1;
        //         voltage++;
        //         voltageInner++;
        //     }
        // }

        
        if (GameObject.FindGameObjectWithTag("NaOut") != null) GameObject.FindGameObjectWithTag("NaOut").GetComponent<Text>().text = "" + NaAtomsOut;
        if (GameObject.FindGameObjectWithTag("NaIn") != null) GameObject.FindGameObjectWithTag("NaIn").GetComponent<Text>().text = "" + NaAtomsIn;
        if (GameObject.FindGameObjectWithTag("KOut") != null) GameObject.FindGameObjectWithTag("KOut").GetComponent<Text>().text = "" + KAtomsOut;
        if (GameObject.FindGameObjectWithTag("KIn") != null) GameObject.FindGameObjectWithTag("KIn").GetComponent<Text>().text = "" + KAtomsIn;
        if (GameObject.FindGameObjectWithTag("ClOut") != null) GameObject.FindGameObjectWithTag("ClOut").GetComponent<Text>().text = "" + ClAtomsOut;
        if (GameObject.FindGameObjectWithTag("ClIn") != null) GameObject.FindGameObjectWithTag("ClIn").GetComponent<Text>().text = "" + ClAtomsIn;

        /*Old voltage outer code block
        if (voltageOuter > 0) GameObject.FindGameObjectWithTag("VoltageOutsideCounterText").GetComponent<Text>().text = "Voltage Outside: " + System.Math.Round(Mathf.Log(voltageOuter), 2) + " mV";
        else if (voltageOuter < 0) GameObject.FindGameObjectWithTag("VoltageOutsideCounterText").GetComponent<Text>().text = "Voltage Outside: -" + System.Math.Round(Mathf.Log(-1 * voltageOuter), 2) + " mV";
        else GameObject.FindGameObjectWithTag("VoltageOutsideCounterText").GetComponent<Text>().text = "Voltage Outside: 0 mV";
        */

        /*Old voltage inner code block
        if (voltageInner > 0) GameObject.FindGameObjectWithTag("VoltageInsideCounterText").GetComponent<Text>().text = "Voltage Inside: " + System.Math.Round(Mathf.Log(voltageInner), 2) + " mV";
        else if (voltageInner < 0) GameObject.FindGameObjectWithTag("VoltageInsideCounterText").GetComponent<Text>().text = "Voltage Inside: -" + System.Math.Round(Mathf.Log(-1 * voltageInner), 2) + " mV";
        else GameObject.FindGameObjectWithTag("VoltageInsideCounterText").GetComponent<Text>().text = "Voltage Inside: 0 mV";
        */

        // float rTF = 14.06f;
        // string deltaVCountText;
        // if (voltage > 0) deltaVCountText = "+" + System.Math.Round(rTF * Mathf.Log(voltage), 2);
        // else if (voltage < 0) deltaVCountText = "-" + System.Math.Round(rTF * Mathf.Log(-voltage), 2);
        // else deltaVCountText = "0.00";
        // if (GameObject.FindGameObjectWithTag("DeltaVCountText") != null) GameObject.FindGameObjectWithTag("DeltaVCountText").GetComponent<Text>().text = "ΔV = " + deltaVCountText + " mV";

        // //Handling voltage
        // float maxVoltage = GameObject.FindGameObjectsWithTag("SodiumAtom").Length + GameObject.FindGameObjectsWithTag("ChlorineAtom").Length + GameObject.FindGameObjectsWithTag("PotassiumAtom").Length;
        // if (GameObject.FindGameObjectWithTag("VoltmeterTextTop") != null && GameObject.FindGameObjectsWithTag("SodiumAtom").Length + GameObject.FindGameObjectsWithTag("ChlorineAtom").Length + GameObject.FindGameObjectsWithTag("PotassiumAtom").Length != 0) GameObject.FindGameObjectWithTag("VoltmeterTextTop").GetComponent<Text>().text = "+" + System.Math.Round(rTF * Mathf.Log(GameObject.FindGameObjectsWithTag("SodiumAtom").Length + GameObject.FindGameObjectsWithTag("ChlorineAtom").Length + GameObject.FindGameObjectsWithTag("PotassiumAtom").Length), 2).ToString() + " mV";
        // else if (GameObject.FindGameObjectWithTag("VoltmeterTextTop") != null) GameObject.FindGameObjectWithTag("VoltmeterTextTop").GetComponent<Text>().text = "0 mV";
        // if (GameObject.FindGameObjectWithTag("VoltmeterTextBottom") != null && GameObject.FindGameObjectsWithTag("SodiumAtom").Length + GameObject.FindGameObjectsWithTag("ChlorineAtom").Length + GameObject.FindGameObjectsWithTag("PotassiumAtom").Length != 0) GameObject.FindGameObjectWithTag("VoltmeterTextBottom").GetComponent<Text>().text = "-" + System.Math.Round(rTF * Mathf.Log(GameObject.FindGameObjectsWithTag("SodiumAtom").Length + GameObject.FindGameObjectsWithTag("ChlorineAtom").Length + GameObject.FindGameObjectsWithTag("PotassiumAtom").Length), 2).ToString() + " mV";
        // else if (GameObject.FindGameObjectWithTag("VoltmeterTextBottom") != null) GameObject.FindGameObjectWithTag("VoltmeterTextBottom").GetComponent<Text>().text = "0 mV";

        // //Setting voltage slider values
        // if (GameObject.FindGameObjectWithTag("Voltage") != null)
        // {
        //     Slider voltageSlider = GameObject.FindGameObjectWithTag("Voltage").GetComponent<Slider>();

        //     voltageSlider.minValue = rTF * -Mathf.Log(maxVoltage);
        //     voltageSlider.maxValue = rTF * Mathf.Log(maxVoltage);

        //     if (voltage > 0) voltageSlider.value = rTF * Mathf.Log(voltage);
        //     else if (voltage < 0) voltageSlider.value = rTF * -Mathf.Log(-voltage);
        //     else voltageSlider.value = 0;

        //     if (voltage < 0) GameObject.FindGameObjectWithTag("Voltage").GetComponentInChildren<Image>().color = new Color((-voltage / maxVoltage * 255f) / 255f, 0f / 255f, 0f / 255f);
        //     else if (voltage > 0) GameObject.FindGameObjectWithTag("Voltage").GetComponentInChildren<Image>().color = new Color(0f / 0f, 0f / 0f, (voltage / maxVoltage * 255f) / 255f);
        //     else GameObject.FindGameObjectWithTag("Voltage").GetComponentInChildren<Image>().color = new Color(0f / 255f, 0f / 255f, 0f / 255f);
        // }

        
        // if (GameObject.FindGameObjectsWithTag("VoltageChanger").Length > 0) targetVoltage = GameObject.FindGameObjectWithTag("VoltageChanger").GetComponent<Slider>().value;
        // //reflectChance = 100.0f * Mathf.Abs((voltage/maxVoltage) - (targetVoltage/maxVoltage));
        // reflectChance = 0;
        //Debug.Log("reflectchance = " + reflectChance + ", voltage = " + voltage + ", maxVoltage = " + maxVoltage + ", i = " + i);
        //i++;
        //Debug.Log("voltageInner = " + voltageInner + ", voltageOuter = " + voltageOuter);
    }
}
