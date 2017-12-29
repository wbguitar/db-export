
using System;
using System.Collections.Generic;
using NUnit.Framework;

/// <summary>
///  
/// </summary>
[S7DB(DB = 2)]
public class Ricettepredosaggio : DBBase // DB2
{
    /// <summary>
    /// Set predosatore 1
    /// </summary>
    public double SetPred1 { get; set; }


    /// <summary>
    /// Set predosatore 2
    /// </summary>
    public double SetPred2 { get; set; }


    /// <summary>
    /// Set predosatore 3
    /// </summary>
    public double SetPred3 { get; set; }


    /// <summary>
    /// Set predosatore 4
    /// </summary>
    public double SetPred4 { get; set; }


    /// <summary>
    /// Set predosatore 5
    /// </summary>
    public double SetPred5 { get; set; }


    /// <summary>
    /// Set predosatore 6
    /// </summary>
    public double SetPred6 { get; set; }


    /// <summary>
    /// Set predosatore 7
    /// </summary>
    public double SetPred7 { get; set; }


    /// <summary>
    /// Set predosatore 8
    /// </summary>
    public double SetPred8 { get; set; }


    /// <summary>
    /// Set predosatore 9
    /// </summary>
    public double SetPred9 { get; set; }


    /// <summary>
    /// Set predosatore 10
    /// </summary>
    public double SetPred10 { get; set; }


    /// <summary>
    /// Set predosatore 11
    /// </summary>
    public double SetPred11 { get; set; }


    /// <summary>
    /// Set predosatore 12
    /// </summary>
    public double SetPred12 { get; set; }


    /// <summary>
    /// Set predosatore riciclato 1
    /// </summary>
    public double SetPredRic1 { get; set; }


    /// <summary>
    /// Set predosatore riciclato 2
    /// </summary>
    public double SetPredRic2 { get; set; }


    /// <summary>
    /// Set predosatore riciclato 3
    /// </summary>
    public double SetPredRic3 { get; set; }


    /// <summary>
    /// Set predosatore riciclato 4
    /// </summary>
    public double SetPredRic4 { get; set; }


    /// <summary>
    /// Tempo di start pred.1
    /// </summary>
    public ushort TimerStartPred1 { get; set; }


    /// <summary>
    /// Tempo di stop pred.1
    /// </summary>
    public ushort TimerStopPred1 { get; set; }


    /// <summary>
    /// Tempo di start pred.2
    /// </summary>
    public ushort TimerStartPred2 { get; set; }


    /// <summary>
    /// Tempo di stop pred.2
    /// </summary>
    public ushort TimerStopPred2 { get; set; }


    /// <summary>
    /// Tempo di start pred.3
    /// </summary>
    public ushort TimerStartPred3 { get; set; }


    /// <summary>
    /// Tempo di stop pred.3
    /// </summary>
    public ushort TimerStopPred3 { get; set; }


    /// <summary>
    /// Tempo di start pred.4
    /// </summary>
    public ushort TimerStartPred4 { get; set; }


    /// <summary>
    /// Tempo di stop pred.4
    /// </summary>
    public ushort TimerStopPred4 { get; set; }


    /// <summary>
    /// Tempo di start pred.5
    /// </summary>
    public ushort TimerStartPred5 { get; set; }


    /// <summary>
    /// Tempo di stop pred.5
    /// </summary>
    public ushort TimerStopPred5 { get; set; }


    /// <summary>
    /// Tempo di start pred.6
    /// </summary>
    public ushort TimerStartPred6 { get; set; }


    /// <summary>
    /// Tempo di stop pred.6
    /// </summary>
    public ushort TimerStopPred6 { get; set; }


    /// <summary>
    /// Tempo di start pred.7
    /// </summary>
    public ushort TimerStartPred7 { get; set; }


    /// <summary>
    /// Tempo di stop pred.7
    /// </summary>
    public ushort TimerStopPred7 { get; set; }


    /// <summary>
    /// Tempo di start pred.8
    /// </summary>
    public ushort TimerStartPred8 { get; set; }


    /// <summary>
    /// Tempo di stop pred.8
    /// </summary>
    public ushort TimerStopPred8 { get; set; }


    /// <summary>
    /// Tempo di start pred.9
    /// </summary>
    public ushort TimerStartPred9 { get; set; }


    /// <summary>
    /// Tempo di stop pred.9
    /// </summary>
    public ushort TimerStopPred9 { get; set; }


    /// <summary>
    /// Tempo di start pred.10
    /// </summary>
    public ushort TimerStartPred10 { get; set; }


    /// <summary>
    /// Tempo di stop pred.10
    /// </summary>
    public ushort TimerStopPred10 { get; set; }


    /// <summary>
    /// Tempo di start pred.11
    /// </summary>
    public ushort TimerStartPred11 { get; set; }


    /// <summary>
    /// Tempo di stop pred.11
    /// </summary>
    public ushort TimerStopPred11 { get; set; }


    /// <summary>
    /// Tempo di start pred.12
    /// </summary>
    public ushort TimerStartPred12 { get; set; }


    /// <summary>
    /// Tempo di stop pred.12
    /// </summary>
    public ushort TimerStopPred12 { get; set; }


    /// <summary>
    /// Tempo di start pred. riciclato 1
    /// </summary>
    public ushort TimerStartPredR1 { get; set; }


    /// <summary>
    /// Tempo di stop pred. riciclato 1
    /// </summary>
    public ushort TimerStopPredR1 { get; set; }


    /// <summary>
    /// Tempo di start pred. riciclato 2
    /// </summary>
    public ushort TimerStartPredR2 { get; set; }


    /// <summary>
    /// Tempo di stop pred. riciclato 2
    /// </summary>
    public ushort TimerStopPredR2 { get; set; }


    /// <summary>
    /// Tempo di start pred. riciclato 3
    /// </summary>
    public ushort TimerStartPredR3 { get; set; }


    /// <summary>
    /// Tempo di stop pred. riciclato 3
    /// </summary>
    public ushort TimerStopPredR3 { get; set; }


    /// <summary>
    /// Tempo di start pred. riciclato 4
    /// </summary>
    public ushort TimerStartPredR4 { get; set; }


    /// <summary>
    /// Tempo di stop pred. riciclato 4
    /// </summary>
    public ushort TimerStopPredR4 { get; set; }


    /// <summary>
    /// Controllo percentuale dei predosatori
    /// </summary>
    public double Controllo_Perc { get; set; }


    /// <summary>
    /// Stringa contenente il nome della ricetta
    /// </summary>
    private byte[] __Registro_Ric = new byte[32];
    [S7Array(Count = 32)]
    public byte[] Registro_Ric
    {
        get { return __Registro_Ric; }
        set { __Registro_Ric = value; }
    } // = new char[32];


    /// <summary>
    /// Numero di cicli per l'arresto a fine produzione
    /// </summary>
    public short Nr_Cicli_arresto_fine_pr { get; set; }


}