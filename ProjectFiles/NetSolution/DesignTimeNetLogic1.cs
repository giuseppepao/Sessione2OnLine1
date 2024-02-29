#region Using directives
using System;
using UAManagedCore;
using OpcUa = UAManagedCore.OpcUa;
using FTOptix.HMIProject;
using FTOptix.NetLogic;
using FTOptix.UI;
using FTOptix.DataLogger;
using FTOptix.NativeUI;
using FTOptix.Recipe;
using FTOptix.EventLogger;
using FTOptix.SQLiteStore;
using FTOptix.Store;
using FTOptix.ODBCStore;
using FTOptix.OPCUAServer;
using FTOptix.OPCUAClient;
using FTOptix.Modbus;
using FTOptix.Retentivity;
using FTOptix.CoreBase;
using FTOptix.CommunicationDriver;
using FTOptix.Core;
#endregion

public class DesignTimeNetLogic1 : BaseNetLogic
{
    [ExportMethod]
    public void CreaVariabili()
    {
        // Insert code to be executed by the method
        for (int i = 0; i < 10; i++) 
        {
            var miaVariabile = InformationModel.MakeVariable("MiaVar" + i, OpcUa.DataTypes.Int16);
            Project.Current.Get("Model/VarCreateDaCodice").Add(miaVariabile);
        }
    }
}
