using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class JoinGame : MonoBehaviour {
	string[] translations = {
		"shadow", "behir", "centaur", "baboon", "xorn", "demon", "partisan", "ettin",
		"halberd", "blink", "identify", "haste", "otyugh", "squid", "aranea", "cloaker",
		"swarm", "fireball", "ghost", "lullaby", "blight", "alarm", "athach", "owl",
		"unhallow", "glaive", "devil", "pony", "harpy", "veil", "mule", "gargoyle",
		"derro", "delver", "knife", "grease", "khopesh", "minotaur", "halfling", "sphinx",
		"scrying", "sunburst", "merfolk", "awaken", "kraken", "axe", "bodak", "badger",
		"guisarme", "chimera", "skum", "spectre", "daze", "mephit", "roper", "naga",
		"cheetah", "enthrall", "doom", "dragonne", "mummy", "mohrg", "bane", "clone",
		"insanity", "devourer", "basilisk", "skeleton", "fauchard", "gate", "jump",
		"krenshar", "sahuagin", "ironwood", "bulette", "scare", "unicorn", "commune",
		"digester", "longbow", "barghest", "roc", "liveoak", "fly", "lamia", "troll",
		"dart", "pick", "ranseur", "binding", "rast", "mending", "harpoon", "leopard",
		"mount", "levitate", "shout", "whale", "wyvern", "lance", "slaad", "prayer",
		"gorgon", "heroism", "weird", "spear", "aid", "lich", "rakshasa", "titan",
		"teleport", "sprite", "shades", "statue", "harm", "bat", "tiger", "ape",
		"yrthak", "stirge", "status", "worg", "zombie", "vision", "daylight", "knock",
		"whip", "camel", "blur", "sleep", "phasm", "owlbear", "goblin", "silence",
		"donkey", "orc", "monkey", "guidance", "demand", "triton", "shambler", "wight",
		"quench", "crossbow", "barkskin", "shield", "entangle", "virtue", "belker",
		"gnoll", "tongues", "slow", "dinosaur", "hydra", "javelin", "couatl", "dirk",
		"ravid", "pegasus", "heal", "bardiche", "passwall", "refuge", "archon", "golem",
		"spetum", "angel", "medusa", "shatter", "poison", "raven", "fungus", "girallon",
		"aboleth", "darkness", "ooze", "wish", "weasel", "hyena", "polearm", "eladrin",
		"boar", "club", "gnome", "horse", "kobold", "sending", "dagger", "nymph", "dog",
		"beholder", "lizard", "mimic", "lammasu", "thoqqua", "command", "seeming", "erase",
		"sympathy", "giant", "dictum", "ankheg", "dryad", "mislead", "griffon", "bless",
		"treant", "mace", "azer", "howler", "hag", "snare", "augury", "magmin", "web",
		"grick", "scourge", "formian", "porpoise", "rat", "sling", "bison", "remorhaz",
		"hallow", "wraith", "octopus", "allip", "maze", "genie", "eagle", "toad", "lion",
		"locathah", "screen", "miracle", "cat", "shark", "snake", "eyebite", "vampire",
		"trident", "voulge", "sunbeam", "ettercap", "lillend", "ghoul", "tojanida",
		"xill", "satyr", "drider", "glibness", "hawk", "dwarf", "message", "wolf",
		"shortbow", "elephant", "light", "grimlock", "sickle", "arquebus", "fear",
		"freedom", "flail", "rage", "chuul", "elf", "bugbear", "dream", "ogre", "flare",
		"scimitar", "choker"
	};

	public InputField input;
	bool isWaiting;
	NetworkManager manager;

	public void Update()
	{
		if (isWaiting && manager.IsClientConnected() && !ClientScene.ready) {
			if (ClientScene.localPlayers.Count == 0) {
                SceneManager.LoadScene (manager.onlineScene);
			}
		}
	}

	public void GetInput ()
	{
		manager = NetworkManager.singleton;

		string gameName = input.text;
		string[] components = gameName.Split (' ');
		string[] translated = components
			.Select (word => Array.IndexOf (translations, word).ToString ())
			.ToArray();
		string ip = String.Join (".", translated, 0, translated.Length);

		manager.networkAddress = ip;
		manager.StartClient ();
		isWaiting = true;
	}

	

}
