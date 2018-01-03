
/// <summary>
///  
/// </summary>
[S7DB(DB = 3000)]
public class Maestro: DBBase // DB3000
{
	/// <summary>
	/// Status
	/// </summary>
	public short Status { get; set; }


	/// <summary>
	/// Plant is on
	/// </summary>
	public bool PlantOn { get; set; }


	/// <summary>
	/// Impianto attivo (almeno un motore acceso) Ciclo attivo (produzione)
	/// </summary>
	public bool PlantActive { get; set; }


	/// <summary>
	/// Allarmi presenti (almeno un allarme)
	/// </summary>
	public bool AlarmPresent { get; set; }


	/// <summary>
	/// Bruciatore acceso
	/// </summary>
	public bool BurnerOn { get; set; }


	/// <summary>
	/// Assorbimento motore aspirazione filtro [A]
	/// </summary>
	public short FilterEngineAmpere { get; set; }


	/// <summary>
	/// Assorbimento motore mescolatore [A]
	/// </summary>
	public short MixerEngineAmpere { get; set; }


	/// <summary>
	/// Ore lavoro motore aspirazione filtro (contatore)
	/// </summary>
	public int FilterWorkHours { get; set; }


	/// <summary>
	/// Ore lavoro motore mescolatore (contatore)
	/// </summary>
	public int MixerWorkHours { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia NV [Ton] (contatore)
	/// </summary>
	public double DosedNV { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia 1 [Ton] (contatore)
	/// </summary>
	public double DosedA1 { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia 2 [Ton] (contatore)
	/// </summary>
	public double DosedA2 { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia 3 [Ton] (contatore)
	/// </summary>
	public double DosedA3 { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia 4 [Ton] (contatore)
	/// </summary>
	public double DosedA4 { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia 5 [Ton] (contatore)
	/// </summary>
	public double DosedA5 { get; set; }


	/// <summary>
	/// Quantità materiale dosata tramoggia 6 [Ton] (contatore)
	/// </summary>
	public double DosedA6 { get; set; }


	/// <summary>
	/// Quantità filler 1 dosato [Ton] (contatore)
	/// </summary>
	public double DosedF1 { get; set; }


	/// <summary>
	/// Quantità filler 2 dosato [Ton] (contatore)
	/// </summary>
	public double DosedF2 { get; set; }


	/// <summary>
	/// Quantità filler 3 dosato [Ton] (contatore)
	/// </summary>
	public double DosedF3 { get; set; }


	/// <summary>
	/// Quantità bitume 1 dosato [Ton] (contatore)
	/// </summary>
	public double DosedB1 { get; set; }


	/// <summary>
	/// Quantità bitume 2 dosato [Ton] (contatore)
	/// </summary>
	public double DosedB2 { get; set; }


	/// <summary>
	/// Quantità bitume 3 dosato [Ton] (contatore)
	/// </summary>
	public double DosedB3 { get; set; }


	/// <summary>
	/// Quantità asfalto prodotto [Ton] (contatore)
	/// </summary>
	public double AsphaltProd { get; set; }


	/// <summary>
	/// ID ricetta attiva nel mescolatore
	/// </summary>
	public int MixerActiveRecipe { get; set; }


	/// <summary>
	/// Temperatura ingresso filtro [°C]
	/// </summary>
	public short FilterInputTemp { get; set; }


	/// <summary>
	/// Temperatura uscita filtro [°C]
	/// </summary>
	public short FilterOutputTemp { get; set; }


	/// <summary>
	/// Temperatura scivolo [°C]
	/// </summary>
	public short SlideTemp { get; set; }


	/// <summary>
	/// Temperatura tramoggia NV [°C]
	/// </summary>
	public short HopperNVTemp { get; set; }


	/// <summary>
	/// Temperatura tramoggia sabbia [°C]
	/// </summary>
	public short HopperSandTemp { get; set; }


	/// <summary>
	/// Temperatura scarico mescolatore [°C]
	/// </summary>
	public short MixerOutputTemp { get; set; }


}