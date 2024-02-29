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

public class RuntimeNetLogic1 : BaseNetLogic
{
    IUAVariable miaVarPLC;
    public override void Start()
    {
        // Insert code to be executed when the user-defined logic is started
        Log.Info("Ho aperto la pagina script");
        miaVarPLC = Project.Current.GetVariable("Model/VarCreateDaCodice/MiaVar1");
        miaVarPLC.VariableChange += MiaVarPLC_VariableChange;
    }

    private void MiaVarPLC_VariableChange(object sender, VariableChangeEventArgs e)
    {
        var mioRettangolo = Owner.Get<Rectangle>("Rectangle1");
        switch ((int)e.NewValue)
        {
            case 1:
                mioRettangolo.FillColor = Colors.Red; 
                break;
            case 2:
                mioRettangolo.FillColor = Colors.Yellow;
                break;
            case 3:
                mioRettangolo.FillColor = Colors.Lime;
                break;

            default:
                mioRettangolo.FillColor = Colors.Gray;
                break;
        }
        
    }

    public override void Stop()
    {
        // Insert code to be executed when the user-defined logic is stopped
        Log.Info("Ho chiuso la pagina script");
        miaVarPLC.VariableChange -= MiaVarPLC_VariableChange;
    }

    [ExportMethod]
    public void mioMetodo(string testoLog)
    {
        Log.Info(testoLog);
    }
}
