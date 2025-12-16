namespace giocovoca
{
	internal class Program
	{
		static int lanciodadi(int posizioneAttuale, int lunghezzaMappa, int cavalcatura, Random rnd)
		{
			int dado = rnd.Next(1, 7);

			Console.WriteLine($"hai tirato: {dado}");
			posizioneAttuale = posizioneAttuale + dado;
			if (posizioneAttuale >= lunghezzaMappa)
			{
				posizioneAttuale = lunghezzaMappa - 1;
			}
			return posizioneAttuale;
		}


		static int eventocombattimento(ref int vita, ref int spada, Random rnd, ref int mostriuccisi, int scelta, ref int cavalcatura)
		{
			Console.WriteLine("evento combattimento");

			Console.WriteLine("Un mostro ti blocca la strada!");
			Console.WriteLine("\"Non passerai vivo, umano!\"");
			Console.WriteLine("Stringe le zanne e si prepara ad attaccare...");

			if (spada > 0)
			{
				Console.WriteLine("vuoi usare la spada per vincere automaticamente il combattimento? (s/n)");
				string risposta = Console.ReadLine();
				if (risposta == "s")
				{
					Console.WriteLine("hai usato la spada e vinto il combattimento opsssss");
					spada--;
					mostriuccisi++;
					return vita;
				}
				else
				{
					Console.WriteLine("hai una piccola probabilità senza spada di vincere il combattimento");
				}
			}
			if (cavalcatura > 0)
			{
				Console.WriteLine("vuoi usare la cavalcatura per fuggire dal combattimento? (s/n)");
				string decisione = Console.ReadLine();
				if (decisione == "s")
				{
					Console.WriteLine("hai usato la cavalcatura e sei scappato dal combattimento, ma hai subito 10 punti danno,vediamo se riesci a prendermi");
					cavalcatura--;
					return vita - 10;
				}
			}



			int probabilita = rnd.Next(1, 7);
			int danni = rnd.Next(5, 16);
			if (probabilita <= 2)
			{
				Console.WriteLine("hai vinto il combattimento,pero hai subito " + danni);
				mostriuccisi++;
				vita = vita - danni;

				if (scelta == 2)
				{
					vita = vita + 10;
					Console.WriteLine("essendo un macellaio hai guadagnato 10 punti extra per la vittoria, ora hai " + vita + " di vita totale");
				}
				return vita;
			}
			else
			{
				int danno = rnd.Next(10, 31);
				Console.WriteLine($"hai perso il combattimento e subito {danno} punti vita");
				return vita - danno;
			}
		}




		static int eventoniente(int vita)
		{
			Console.WriteLine("nessun evento accaduto");
			return vita;
		}


		static void aggiinventario(string[] inventario, ref int indice, string oggetto)
		{
			if (indice < inventario.Length)
			{
				inventario[indice] = oggetto;
				indice++;
				Console.WriteLine($"{oggetto} aggiunto all'inventario");
			}
			else
			{
				Console.WriteLine("inventario pieno");
			}
		}

		static bool mostrainventario(string[] inventario, int indice)
		{
			Console.WriteLine(" inventario:");
			if (indice == 0)
			{
				Console.WriteLine(" vuoto");
				return false;
			}

			for (int i = 0; i < indice; i++)
			{
				Console.WriteLine($" {inventario[i]}");

			}
			return true;
		}


		static int eventoregalo(ref int vita, ref int spada, Random rnd,
						string[] inventario, ref int indiceInventario, ref int cavalcatura)
		{
			Console.WriteLine("evento incontro con gli abitanti");


			int tipoRegalo = rnd.Next(1, 5);

			if (tipoRegalo == 1)
			{
				Console.WriteLine("Un abitante si avvicina sorridendo.");
				Console.WriteLine("\"Viaggiatore, sembri stanco... riposa nella mia casa.\"");
				Console.WriteLine("\"Accetta questo cibo per il cammino.\"");
				string asciiArt = @"
                                                                  ___
                                                             ___..--'  .`.
                                                    ___...--'     -  .` `.`.
                                           ___...--' _      -  _   .` -   `.`.
                                  ___...--'  -       _   -       .`  `. - _ `.`.
                           __..--'_______________ -         _  .`  _   `.   - `.`.
                        .`    _ /\    -        .`      _     .`__________`. _  -`.`.
                      .` -   _ /  \_     -   .`  _         .` |Train Depot|`.   - `.`.
                    .`-    _  /   /\   -   .`        _   .`   |___________|  `. _   `.`.
                  .`________ /__ /_ \____.`____________.`     ___       ___  - `._____`|
                    |   -  __  -|    | - |  ____  |   | | _  |   |  _  |   |  _ |
                    | _   |  |  | -  |   | |.--.| |___| |    |___|     |___|    |
                    |     |--|  |    | _ | |'--'| |---| |   _|---|     |---|_   |
                    |   - |__| _|  - |   | |.--.| |   | |    |   |_  _ |   |    |
                 ---``--._      |    |   |=|'--'|=|___|=|====|___|=====|___|====|
                 -- . ''  ``--._| _  |  -|_|.--.|_______|_______________________|
                `--._           '--- |_  |:|'--'|:::::::|:::::::::::::::::::::::|
                _____`--._ ''      . '---'``--._|:::::::|:::::::::::::::::::::::|
                ----------`--._          ''      ``--.._|:::::::::::::::::::::::|
                `--._ _________`--._'        --     .   ''-----..............LGB'
                     `--._----------`--._.  _           -- . :''           -    ''
                          `--._ _________`--._ :'              -- . :''      -- . ''
                 -- . ''       `--._ ---------`--._   -- . :''
                          :'        `--._ _________`--._:'  -- . ''      -- . ''
                  -- . ''     -- . ''    `--._----------`--._      -- . ''     -- . ''
                                              `--._ _________`--._
                 -- . ''           :'              `--._ ---------`--._-- . ''    -- . ''
                          -- . ''       -- . ''         `--._ _________`--._   -- . ''
                :'                 -- . ''          -- . ''  `--._----------`--._";

				aggiinventario(inventario, ref indiceInventario, "Cibo");
			}
			else if (tipoRegalo == 2)
			{
				int danno = rnd.Next(10, 31);
				Console.WriteLine($"un abitante sospetto ti dà cibo avariato Perdi {danno} punti vita");
				vita = vita - danno;
				string asciiArt = @"
                   \\\|||///
                 .  =======
                / \| O   O |
                \ / \`___'/
                 #   _| |_
                (#) (     )
                 #\//|* *|\\
                 #\/(  *  )/
                 #   =====
                 #   ( U )
                 #   || ||
                .#---'| |`----.
                `#----' `-----'";

			}
			else if (tipoRegalo == 3)
			{
				if (spada == 0)
				{
					Console.WriteLine("un abitante ti regala una spada");
					spada++;
					string asciiArt = @"
                         _
                        (_)
                        |_|
                        |_|
                        |_|
                        |_|
                        |_|
                    o=========o
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        | |
                        \ /";

					aggiinventario(inventario, ref indiceInventario, "Spada");
				}
				else
				{
					Console.WriteLine(" ciao viaggiatore vorrei regalarti una spada");
					Console.WriteLine("ti ringrazio molto ma non posso accettare il tuo dono perche ne ho già una");

				}
			}
			else
			{
				if (cavalcatura > 0)
				{
					Console.WriteLine(" ciao viaggiatore vorrei regalarti una cavalcatura");
					Console.WriteLine("ti ringrazio molto ma non posso accettare il tuo dono perche ne ho già una");


				}
				else
				{
					Console.WriteLine("un abitante ti regala una cavalcatura");
					cavalcatura++;
				}
				aggiinventario(inventario, ref indiceInventario, "Cavalcatura");
			}

			return vita;
		}

		static void Main(string[] args)
		{
			int spada = 0, vita = 100, cavalcatura = 0, posizione = 0, mostriuccisi = 0, scelta, indiceInventario = 0;
			bool giocoInCorso = true;
			string[] inventario = new string[10];


			Random rnd = new Random();

			Console.WriteLine("È un gioco di avventura testuale in cui il giocatore sceglie uno tra tre personaggi, ognuno con abilità specifiche come maggiore resistenza, danni più elevati o una migliore possibilità di fuga e avrai a disposizione un inventario dove tenere oggetti con massimo 10 slot . L’obiettivo è attraversare una mappa rappresentata da un array monodimensionale, composta da diverse città disposte lungo un percorso, e raggiungere la città finale.Il movimento avviene tramite il lancio di un dado virtuale che determina di quante caselle il personaggio può avanzare a ogni turno, entro un limite massimo. Ogni volta che si entra in una nuova città si attiva un evento casuale, che può includere combattimenti, incontri o la raccolta di oggetti. Durante la partita il giocatore può ottenere e utilizzare oggetti come pozioni, armi, scudi e cavalcature, che permettono di avanzare più velocemente ma possono andare perse. A ogni turno è possibile scegliere diverse azioni, come tirare il dado, controllare lo stato del personaggio, gestire l’inventario, usare un oggetto o uscire dal gioco. La partita termina quando si raggiunge la destinazione finale, quando il personaggio perde tutti i punti vita o in seguito a un evento speciale.\r\n\r\n");
			Console.WriteLine("1 Guerriero: ha spada che si può usare su un combattimento, bassa probabilità di fuga.");
			Console.WriteLine("2 Macellaio: parte con 50 di vita in più, e ogni uccisione ti da 10 di vita aggiuntivi.");
			Console.WriteLine("3 Cavallerizzo: ha meno vita ma una cavalcatura per fuggire.");

			do
			{
				Console.WriteLine("Scegli il tuo personaggio tra quelli elencati sopra ");
				scelta = Convert.ToInt32(Console.ReadLine());

			}
			while (scelta < 1 || scelta > 3);
			if (scelta == 1)
			{

				Console.WriteLine("Il guerriero stringe la spada.");
				Console.WriteLine("La battaglia è il mio destino.");
				string asciiArt = @"
                 _
                (_)
                |_|
                |_|
                |_|
                |_|
                |_|
            o=========o
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                | |
                \ /";

				spada = 1;
				aggiinventario(inventario, ref indiceInventario, "Spada");
			}
			else if (scelta == 2)
			{
				vita = vita + 50;
				Console.WriteLine("Il macellaio sorride sinistramente.");
				Console.WriteLine("Ogni vittoria mi rende più forte.");
			}
			else if (scelta == 3)
			{

				Console.WriteLine("Il cavallerizzo accarezza la sua cavalcatura.");
				Console.WriteLine("Se le cose vanno male, fuggiremo.");
				string asciiArt = @"
                                            _(\_/)
                                          ,((((^`\
                                         ((((  (6 \
                                       ,((((( ,    \
                   ,,,_              ,(((((  /""._  ,`,
                  ((((\\ ,...       ,((((   /    `-.-'
                  )))  ;'    `""'""'""((((   (
                 (((  /            (((      \
                  )) |                      |
                 ((  |        .       '     |
                 ))  \     _ '      `t   ,.')
                 (   |   y;- -,-""'""-.\   \/
                 )   / ./  ) /         `\  \
                    |./   ( (           / /'
                    ||     \\          //'|
                jgs ||      \\       _//'||
                    ||       ))     |_/  ||
                    \_\     |_/          ||
                    `""'                  \_\";


				cavalcatura = 1;
				aggiinventario(inventario, ref indiceInventario, "Cavalcatura");
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


			while (giocoInCorso == true)
			{
				Console.WriteLine("premi invio per tirare il dado...");
				Console.ReadLine();

				posizione = lanciodadi(posizione, mappa.Length, cavalcatura, rnd);
				Console.WriteLine($"Sei arrivato in: {descrizione[posizione]}");

				int tipoEvento = rnd.Next(1, 8);
				if (tipoEvento <= 4)
				{
					vita = eventocombattimento(ref vita, ref spada, rnd, ref mostriuccisi, scelta, ref cavalcatura);
				}
				else if (tipoEvento <= 7 || tipoEvento >= 4)
				{
					vita = eventoregalo(ref vita, ref spada, rnd,
						 inventario, ref indiceInventario, ref cavalcatura);
				}
				else
				{
					vita = eventoniente(vita);
				}

				Console.WriteLine($"vita attuale: {vita}");


				Console.WriteLine("vuoi vedere il tuo inventario? (s/n)");
				if (Console.ReadLine() == "s")
				{

					if (mostrainventario(inventario, indiceInventario))
					{
						bool ciboTrovato = false;

						for (int i = 0; i < indiceInventario; i++)
						{
							if (inventario[i] == "Cibo")
							{
								ciboTrovato = true;
							}
						}

						if (ciboTrovato == true)
						{

							Console.WriteLine("vuoi mangiare il cibo che hai in inventario? (s/n)");
							string sn = Console.ReadLine();

							if (sn == "s")
							{
								vita = vita + 20;
								Console.WriteLine("hai mangiato del cibo e recuperato 20 punti vita.");
							}
						}

					}
					else
					{
						Console.WriteLine("il tuo inventario è vuoto.");
					}

				}

				if (posizione == mappa.Length - 1)
				{
					Console.WriteLine("La luce illumina la città finale.");
					Console.WriteLine("Hai superato ogni prova.");
					Console.WriteLine("La leggenda del tuo viaggio sarà ricordata.");
					Console.WriteLine("hai raggiunto la destinazione finale! Complimenti!");
					giocoInCorso = false;
				}
				if (vita <= 0)
				{
					Console.WriteLine("sei stato sconfitto! Fine del gioco.");
					giocoInCorso = false;
				}
				if (mostriuccisi >= 3)
				{
					Console.WriteLine("Complimenti! Hai dimostrato il tuo valore in battaglia.");
					Console.WriteLine("hai sconfitto 3 mostri quindi hai vinto il gioco");
					giocoInCorso = false;
				}

			}
		}
	}

}





