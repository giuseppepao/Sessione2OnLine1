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

public class RuntimeNetLogic2 : BaseNetLogic
{
    public override void Start()
    {
        myPeriodicTask = new PeriodicTask(IncrementVariable, 1000, LogicObject);
        myPeriodicTask.Start();
    }

    public override void Stop()
    {
        myPeriodicTask.Dispose();
    }

    private void IncrementVariable()
    {
        var varPLC = Project.Current.GetVariable("Model/VarCreateDaCodice/MiaVar0");
        varPLC.Value = varPLC.Value + 1;
    }

    private PeriodicTask myPeriodicTask;
}
