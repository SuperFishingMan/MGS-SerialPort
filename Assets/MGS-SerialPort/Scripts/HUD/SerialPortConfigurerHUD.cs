﻿/*************************************************************************
 *  Copyright © 2017-2018 Mogoson. All rights reserved.
 *------------------------------------------------------------------------
 *  File         :  SerialPortConfigurerHUD.cs
 *  Description  :  Draw UI in scene to config serialport parameters.
 *------------------------------------------------------------------------
 *  Author       :  Mogoson
 *  Version      :  0.1.0
 *  Date         :  4/5/2017
 *  Description  :  Initial development version.
 *  
 *  Author       :  Mogoson
 *  Version      :  0.1.1
 *  Date         :  3/2/2018
 *  Description  :  Optimize.
 *************************************************************************/

using System.IO.Ports;
using UnityEngine;

namespace Developer.IO.Ports
{
    [AddComponentMenu("Developer/IO/Ports/SerialPortConfigurerHUD")]
    public class SerialPortConfigurerHUD : MonoBehaviour
    {
        #region Field and Property
        public float xOffset = 10;
        public float yOffset = 10;

        private SerialPortConfig config;
        #endregion

        #region Private Method
        private void Start()
        {
            var error = string.Empty;
            SerialPortConfigurer.ReadConfig(out config, out error);
        }

        private void OnGUI()
        {
            var rect = new Rect(xOffset, yOffset, 180, 180);
            GUILayout.BeginArea(rect, "Configurer", "Window");

            GUILayout.BeginHorizontal();
            GUILayout.Label("PortName");
            config.portName = GUILayout.TextField(config.portName, GUILayout.Width(60));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("BaudRate");
            config.baudRate = int.Parse(GUILayout.TextArea(config.baudRate.ToString(), GUILayout.Width(60)));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("Parity");
            config.parity = (Parity)int.Parse(GUILayout.TextArea(((int)config.parity).ToString(), GUILayout.Width(20)));
            GUILayout.Label(config.parity.ToString());
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("DataBits");
            config.dataBits = int.Parse(GUILayout.TextArea(config.dataBits.ToString(), GUILayout.Width(60)));
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            GUILayout.Label("StopBits");
            config.stopBits = (StopBits)int.Parse(GUILayout.TextArea(((int)config.stopBits).ToString(), GUILayout.Width(20)));
            GUILayout.Label(config.stopBits.ToString());
            GUILayout.EndHorizontal();

            if (GUILayout.Button("Apply"))
            {
                var error = string.Empty;
                SerialPortConfigurer.WriteConfig(config, out error);
            }
            GUILayout.EndArea();
        }
        #endregion
    }
}