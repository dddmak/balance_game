using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System;
using System.IO.Ports;
using UnityEngine;
using UniRx;
using System.Text;
public class RotateSerial : MonoBehaviour{
    string message;
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

    void Update () {

        byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
        string bin = Convert.ToString(data[0], 2);
        string bin2 = Convert.ToString(data[1], 2);
        int bin_int = Int32.Parse(bin);
        int bin2_int = Int32.Parse(bin2);
        bin_int = bin_int << 8;
        bin2_int = bin_int + bin2_int;
        Debug.Log(bin2);
        //Debug.Log(data[1]);
        if (data[0]==1) {
            transform.Rotate (1f,0f,0f);
        }
        if (data[0]==2) {
            transform.Rotate (-1f,0f,0f);
        }
        if (data[0]==3) {
            transform.Rotate (0f,0f,-1f);
        }
        if (data[0]==4) {
            transform.Rotate (0f,0f,1f);
        }
        //Debug.Log( message );
    }


    void ReadData()
    {
        while (this.isLoop)
        {
            message = this.serial.ReadLine();
            //Debug.Log( message );
        }
    }

    void OnDestroy()
    {
        this.isLoop = false;
        this.serial.Close ();
    }
}
