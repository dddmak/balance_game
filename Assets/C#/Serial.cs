using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using System.IO.Ports;
using UnityEngine;
using UniRx;

public class Serial : MonoBehaviour{

    public string portName;
    public int baurate;

    SerialPort serial;
    bool isLoop = true;

    void Start ()
    {
        this.serial = new SerialPort (portName, baurate, Parity.None, 8, StopBits.One);

        try
        {
            this.serial.Open();
            Scheduler.ThreadPool.Schedule (() => ReadData ()).AddTo(this);
        }
        catch(Exception e)
        {
            Debug.Log ("can not open serial port");
        }
    }

    public void ReadData()
    {
        byte[] start = new byte[5];
        start[0] = 0x3a;
        start[1] = 0x61;
        start[2] = 0x4d;
        start[3] = 0x61;
        start[4] = 0x3b;
        this.serial.Write(start,0,5);
        while (this.isLoop)
        {
            byte[] message1 = new byte[28];
            this.serial.Read(message1,0,28);
            int st = ((int)message1[26]) << 8 + (int)message1[27];
            //this.serial.Write(message1,0,1);
            //string text = System.Text.Encoding.ASCII.GetString(message1);
            Debug.Log(message1[26]);
            Debug.Log(message1[27]);
            //Debug.Log(st);
        }
    }

    void OnDestroy()
    {
        this.isLoop = false;
        this.serial.Close ();
    }
}
