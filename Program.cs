namespace giocovoca
{
    internal class Program
    {


		static int LancioDadi(int posizioneAttuale, int lunghezzaMappa, int cavalcatura, Random rnd)
		{
			int dado = rnd.Next(1, 7); 
			if (cavalcatura > 0)
			{
				Console.WriteLine("Usi la cavalcatura: avanzamento bonus +2 caselle!");
				dado =dado+2;
			}
			Console.WriteLine($"Hai tirato: {dado}");
			posizioneAttuale += dado;
			if (posizioneAttuale >= lunghezzaMappa)
			{
				posizioneAttuale = lunghezzaMappa - 1;
			}
			return posizioneAttuale;
		}


		static int EventoCombattimento(ref int vita, ref int spada, Random rnd)
		{
			Console.WriteLine("Evento Combattimento!");

			if (spada > 0)
			{
				Console.WriteLine("Vuoi usare la spada per vincere automaticamente il combattimento? (s/n)");
				string risposta = Console.ReadLine();
				if (risposta == "s")
				{
					Console.WriteLine("Hai usato la spada e vinto il combattimento!");
					spada = 0;
					return vita;
				}
				else
				{
					Console.WriteLine("Hai una piccola probabilità senza spada di vincere il combattimento.");
				}
			}

			
			int probabilita = rnd.Next(1, 7);
			if (probabilita <= 2)
			{
				Console.WriteLine("Hai vinto il combattimento!");
				return vita;
			}
			else
			{
				int danno = rnd.Next(10, 31); 
				Console.WriteLine($"Hai perso il combattimento e subito {danno} punti vita.");
				return vita - danno;
			}
		}




		static int EventoNiente(int vita)
			{
				Console.WriteLine("Nessun evento accaduto");
				return vita;
			}

		static int EventoRegalo(ref int vita, ref int spada, Random rnd)
		{
			Console.WriteLine("Evento Incontro con gli abitanti!");

			
			int tipoRegalo = rnd.Next(1, 4);

			if (tipoRegalo == 1)
			{
				int cura = rnd.Next(10, 21); // +10 / +20
				Console.WriteLine($"Un abitante gentile ti offre del cibo. Recuperi {cura} punti vita.");
				vita =vita+ cura;
			}
			else if (tipoRegalo == 2)
			{
				int danno = rnd.Next(10, 31);
				Console.WriteLine($"Un abitante sospetto ti dà cibo avariato! Perdi {danno} punti vita.");
				vita =vita- danno;
			}
			else
			{
				if (spada == 0)
				{
					Console.WriteLine("Un abitante ti regala una spada!");
					spada = 1;
				}
				else
				{
					Console.WriteLine("Un abitante voleva darti una spada, ma ne possiedi già una.");
				}
			}

			return vita;
		}

		static void Main(string[] args)
			{
				int spada = 0, vita = 100, cavalcatura = 0, posizione = 0;

				Console.WriteLine("Benvenuto nel gioco di avventura testuale!");
				Console.WriteLine("Scegli il tuo personaggio:");
				Console.WriteLine("1 Guerriero: ha spada che si può usare su un combattimento, bassa probabilità di fuga.");
				Console.WriteLine("2 Macellaio: parte con 50 di vita in più.");
				Console.WriteLine("3 Cavallerizzo: ha meno vita ma una cavalcatura per fuggire.");

	    	string scelta = Console.ReadLine();
			if (scelta == "1")
			{
				spada = 1;
			}
			else if (scelta == "2")
			{ 
				vita =vita+50;
			}
			else if (scelta == "3")
			{ 
				cavalcatura = 1; 
			}
			else
			{ 
				Console.WriteLine("Scelta non valida, partenza con valori base.");
			}

				string[] mappa = { "Minas Morgul", "Monte Fato", "Borgo Bislacco", "Umbertide", "Cioccolanti", "Gattonia", "Brontolopoli", "Puzzonia", "Neotronia", "Tucan City", "Cocco Beach", "Mekapolis", "Algeri", "Aïn M'lila", "Panzalunga", "Laserport", "Orbitalia", "Zuccherosole", "Neoturbo City", "Ventomare", "Rocca Ombrosa", "Solaris", "Nebulonia", "Valle Blu", "Fine del Viaggio" };

				string[] descrizione = {
"Minas Morgul: Una città oscura e minacciosa, avvolta da nebbie perpetue e presenze inquietanti.",
"Monte Fato: Una montagna alta e impervia, con sentieri scoscesi e venti gelidi.",
"Borgo Bislacco: Un borgo strano e colorato, dove tutto sembra fuori posto e imprevedibile.",
"Umbertide: Una città tranquilla con piccole taverne e mercati locali vivaci.",
"Cioccolanti: Terra dolce e golosa, con colline ricoperte di cioccolato e profumi irresistibili.",
"Gattonia: Una città popolata da gatti giganteschi che osservano ogni mossa dei visitatori.",
"Brontolopoli: Abitata da cittadini sempre brontoloni, qui ogni parola sembra un lamento.",
"Puzzonia: Un luogo maleodorante, ma pieno di misteri e oggetti nascosti.",
"Neotronia: Una città futuristica, piena di luci al neon e tecnologie avanzate.",
"Tucan City: Un paradiso tropicale con uccelli colorati e vegetazione lussureggiante.",
"Cocco Beach: Spiaggia dorata e mare cristallino, ideale per rilassarsi o trovare tesori nascosti.",
"Mekapolis: Una città industriale, piena di macchine e rumori metallici incessanti.",
"Algeri: Antica e affascinante, con bazar e vicoli labirintici da esplorare.",
"Aïn M'lila: Paese del deserto, con dune dorate e oasi nascoste.",
"Panzalunga: Una città allungata tra colline, famosa per i suoi mercati variopinti.",
"Laserport: Centro tecnologico avanzato, con portali laser e esperimenti scientifici.",
"Orbitalia: Una città sospesa tra le nuvole, dove le case fluttuano nell’aria.",
"Zuccherosole: Un luogo luminoso e dolce, dove il sole sembra zucchero fuso.",
"Neoturbo City: Metropoli velocissima, piena di corse, macchine futuristiche e adrenalina.",
"Ventomare: Una città costiera battuta dai venti, con fari e barche che oscillano.",
"Rocca Ombrosa: Fortezza antica circondata da foreste oscure e nebbia.",
"Solaris: Città splendente, dove ogni edificio brilla sotto il sole incessante.",
"Nebulonia: Avvolta da nebbie e misteri, perfetta per avventure o incontri segreti.",
"Valle Blu: Valle tranquilla con fiumi scintillanti e paesaggi rilassanti.",
"Fine del Viaggio: La destinazione finale, segno del successo e della conclusione dell’avventura."
		};

				

				Random rnd = new Random();

			while (posizione < mappa.Length && vita > 0)
			{
				Console.WriteLine("Premi invio per tirare il dado...");
				Console.ReadLine();

				posizione = LancioDadi(posizione, mappa.Length, cavalcatura, rnd);
				Console.WriteLine($"Sei arrivato in: {descrizione[posizione]}");

				int tipoEvento = rnd.Next(1, 4);
				if (tipoEvento == 1)
				{
					vita = EventoCombattimento(ref vita, ref spada, rnd);
				}
				else if (tipoEvento == 2)
				{
					vita = EventoRegalo(ref  vita, ref spada, rnd);
				}
				else
				{
					vita = EventoNiente(vita);
				}

				Console.WriteLine($"Vita attuale: {vita}");

				if (posizione == mappa.Length - 1)
				{
					Console.WriteLine("Hai raggiunto la destinazione finale! Complimenti!");
					return;
				}
				if (vita <= 0)
				{
					Console.WriteLine("Sei stato sconfitto! Fine del gioco.");
					return;
				}
			}

		}
	}

	}


