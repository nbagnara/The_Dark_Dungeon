using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp5
{
    class Hero
    {

        private int maxHealth = 100;
        private int minHealth = 0;
        private int health;
        private int attack;
        private int defense;
        private int exp = 0;

        public int MyHealth
        {
            get
            {
                return health;
            }
            set
            {
                if (value <= minHealth)
                {
                    Program.Lose();
                }
                else if (value >= maxHealth)
                {
                    health = maxHealth;
                }
                else
                {
                    health = value;
                }

            }
        }



        public int MyAttack
        {
            get
            {
                return attack;
            }
            set
            {
                attack = value;
            }
        }
        public int MyDefense
        {
            get
            {
                return defense;
            }
            set
            {
                defense = value;
            }
        }
        public int MyExp
        {
            get
            {
                return exp;
            }
            set
            {
                //if ((value >=25 && value <= 55)|| (value >= 56 && value <= 90) || (value >= 91 && value <= 130))
                //{
                //    exp = value;
                //    LevelUp();
                //}
                //else
                //{
                //    exp = value;
                //}
                exp = value;

                
            }
        }
        public void Boost(int _boost)
        {
            MyAttack += _boost;
            MyDefense += _boost;
            maxHealth += _boost * 2;

            health = maxHealth;
            Console.WriteLine("Your attributes have increased!\nYour attack is now " + attack + ", your defense is now " + defense + ", and your health is now " + health + ".");
        }
        public void TakeDamage(int num)
        {
            //Console.WriteLine("You have taken " + num + " points of damage.");
            MyHealth -= num;
            Console.WriteLine("You now have " + health + " hit points left.");
        }
        public void GainHealth(int num)
        {
            MyHealth += num;
            Console.WriteLine("You have regained " + num + " HP.\nYour total health is now " + health + ".");
        }
        public void LevelUp()//have to figure out how to run this while game is running, maybe coroutine?
        {
            
            string attribute;
            int boost;
            while (MyExp > 0)
            {
                Console.Clear();
                Console.WriteLine("You have " + MyExp + " experience points. On which attributes would you like to spend them?");
                Console.WriteLine("Please type the attribute you would like to increase.\nYou may distribute your points to all or one\nit will keep asking you until you're out of points\n(attack, defense, or health)");
                attribute = Convert.ToString(Console.ReadLine().ToLower());
                Console.WriteLine("Now type the number of points you'd like to spend on that attribute?");
                boost = Convert.ToInt32(Console.ReadLine().ToLower());
                switch (attribute)
                {
                    case "attack":
                        MyAttack += boost;
                        break;
                    case "defense":
                        MyDefense += boost;
                        break;
                    case "health":
                        maxHealth += boost * 2;
                        break;
                    default:
                        break;
                }
                MyExp -= boost;
            }

            health = maxHealth;
            Console.WriteLine("Your attributes have increased!\nYour attack is now " + attack + ", your defense is now " +defense+ ", and your health is now "+ health + ".");

        }

    }
    class Swordsman : Hero//want more heros to be rdmly selected at game start
    {
        Random aRNG = new Random();
        Random dRNG = new Random();

        public Swordsman()
        {
            InitializeSwordsman();

        }
        public void InitializeSwordsman()
        {
            MyHealth = 100;
            MyAttack = aRNG.Next(8, 19);
            MyDefense = dRNG.Next(6, 16);
        }
        public void ReturnToMaxHealth()
        {
            MyHealth = 10000000;
            Console.WriteLine("You have been fully revitalized. Your health is now " + MyHealth);
        }
    }
    
    //classes


    class Program
    {
        //public variables

        static Swordsman swordsman = new Swordsman();
        //static int talkCount;
        [STAThread]
        static void Main(string[] args)
        {
            Start:
            Opening();
            //gunna cut battle or use it as the trap/ wrong way areas in the labrynth
            //just going to be gamestart in the cave before the door
            //door opens you to the labrynth
            //labrynth takes you to boss
            //end of labrynth you "level up" gain full health with an additional few points (randomized?)and choose whether to boost attack or defense
            //Boss();
            

            Console.ReadKey();
            goto Start;
        }
        //methods
        
        public static void Opening()
        {
            Console.WriteLine("Welcome! This is a text adventure where you have to escape a dungeon!\nThere's monsters to fight, loot sometimes, a hacky leveling up system, and even multiple endings!\n" +
                "(Press the any key or order a Tab to continue at the end of each piece of text)");
            Console.ReadKey();
            Console.WriteLine("and then more text will show up! Just like the 80s!\nPlease enjoy this text adventure, and don't worry you won't be dead if you can escape the dungeon.");
            Console.ReadKey();
            GameStart();
                
        }
        public static void GameStart()
        {
            
            Console.Clear();
            Console.WriteLine("Oof, dude, I'm not gunna sugar coat it, but I think you're dead.");
            Console.ReadKey();
            Console.WriteLine("Or about to be.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("It's pretty dark down here,\nso you feel around on your hands and knees until you find a what feels like an oily rag on a stick.\nYou prise it away from whatever it was stuck in and strike it with some flint.");
            
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("In the glow of the flame you see a skeleton with a broken hand beneath you.\nThe walls around you are smooth and the glow from the hole you came in is faint.\nYou turn around to see a large wooden door");
            Console.ReadKey();
            Console.WriteLine("Do you enter? (Please type: yes or no)");

            string YN = Convert.ToString(Console.ReadLine().ToLower());


            if (YN == "y"|| YN == "yes")
            {
                Console.Clear();


                //int defense = swordsman.MyDefense;
                //int attack = swordsman.MyAttack;
                //Console.WriteLine(swordsman.MyHealth);
                //Console.WriteLine("defense: " + defense);
                //Console.WriteLine("attack: " + attack);

                SitOne();
                //or
                //LabrynthFirst();
                //or
                //SitTwo(); b/c it starts with the hint chest and goes to labrynth

            }
            else
            {
                Console.Clear();
                Console.WriteLine("You sit down and wait to die.");
                Console.ReadKey();
                Console.Clear();
                Lose();
            }


        }

        public static void SitOne()
        {
            //first situation
            //Console.WriteLine("This is SitOne");

            Console.WriteLine("You shove open the heavy wooden door.\nDirt rains down from the stone archway as you walk through.");
            Console.ReadKey();
            Console.WriteLine("Wiping the dirt from your eyes you see a hallway of smoothly hewn walls stretch out before you.\nThe only light is the dim flame from your torch.");
            Console.ReadKey();


            //calls or is logic for battles 
            //turn based can choose attack/run/defend
            //attack leaves open for damage increases counter if win
            //defend reduces damage must defeat attacker to move on
            //run avoids fight but does not increase/decrease counter


            for (int i = 0; i < 2; i++)
            {
                
                Console.WriteLine("You come upon an intersection.\nWhich way do you go?\n(Please type: Right, Left or Straight) ");

                string rtLftStrt = Convert.ToString(Console.ReadLine().ToLower());
                //differentiate right straight and left a little bit more
                switch (rtLftStrt)
                {
                    case "right":
                        Console.Clear();
                        //Console.WriteLine("Right");
                        //Console.WriteLine(i);
                        Battle();
                        Console.ReadKey();

                        break;
                    case "left":
                        Console.Clear();
                        //Console.WriteLine("left");
                        //Console.WriteLine(i);
                        Battle();
                        Console.ReadKey();

                        break;
                    case "straight":
                        Console.Clear();
                        //Console.WriteLine("Straight");
                        //Console.WriteLine(i);
                        Battle();
                        Console.ReadKey();

                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Something went wrong. Please check your spelling.");
                        //Console.WriteLine(i);
                        i--;
                        Console.ReadKey();

                        break;
                }
                Console.Clear();




            }
            Console.WriteLine("You arrive at a flight of stairs leading up into yet more darkness.");
            Console.WriteLine("Do you enter? (Please type: yes or no)");

            string YN = Convert.ToString(Console.ReadLine().ToLower());


            if (YN == "y"|| YN == "yes")
            {
                


                
                
                Console.ReadKey();
                swordsman.LevelUp();
                Console.ReadKey();

                LabrynthFirst();

                

            }
            else
            {
                Console.Clear();
                Console.WriteLine("You take a nap at the bottom of the stairs and spider eats you.");
                Console.ReadKey();
                Console.Clear();
                Lose();
            }
            
        }
        public static void Chest()
        {
            Start:
            Random RNG = new Random();
            int boost = RNG.Next(5,11);
            Console.Clear();
            
            Console.WriteLine("You open the chest and are surprised to find 5 items inside.\nA vial of green solution teamimg with life energy (1),\na larger vial of green solution (2),\na vial of red solution teaming with " +
                    "strength (3),\na vial of blue solution teeming with resilience (4),\na tattered and rolled up piece of paper (5).\n(please type the correspond number of the item you wish to use, choose wisely.)");
            string oneTwoEtc = Convert.ToString(Console.ReadLine().ToLower());
            switch (oneTwoEtc)
            {
                case "1":

                    Console.WriteLine("You chose the small health potion.");
                    swordsman.GainHealth(15);
                    break;
                case "2":
                    Console.WriteLine("You chose the small health potion.");
                    swordsman.GainHealth(50);
                    break;
                case "3":
                    Console.WriteLine("You chose the potion of strength.");
                    //Console.WriteLine(swordsman.MyAttack);//debugging
                    swordsman.MyAttack += 15;
                    Console.WriteLine("Raw power courses through your veins.\nYou feel like you can take on any monster in your path.");
                    break;
                case "4":
                    Console.WriteLine("You chose the potion of resilience.");
                    //Console.WriteLine(swordsman.MyDefense);
                    swordsman.MyDefense += 15;
                    Console.WriteLine("A strange energy courses through your veins as you feel your skin harden.\nYou feel like nothing can hurt you.");
                    break;
                case "5":
                    Console.Clear();
                    Console.WriteLine("You unfurl the strange piece of paper. It reads:\nHello weary traveller.\nI do hope this finds you well,\nwell as well as one can be in the situation you've found yourself." +
                        "\nbut you've made it this far, no sense in giving up.\nIf I could give you some advice, talking is a much better way to come together on a solution than fighting.");
                    Console.WriteLine();
                    swordsman.Boost(boost);
                    break;
                default:
                    Console.WriteLine("yea I know the game is broken.\npress enter to go back to the chest and pick the only one of those choices theres nothing else.");
                    Console.ReadKey();
                    goto Start;
                    
            }
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("The rest of the items disappear. I hope you chose wisely.");
            Console.ReadKey();
        }
        public static void LabrynthFirst()
        {
            //switch loop
            //following light i++ 
            //wrong way i--
            //player passes images of life events through the labrynth.
            //control player actions with diff combos of right left or straight or back
            Console.Clear();
            int labCount = 0;
            
            Start:
            Console.Clear();
            Console.WriteLine("You reach the top of the stairs and a hallway made of rough stone bricks stretches out before you.\nYou walk forward until you come upon an intersection.\n(Please type: Right, Left or Straight)");
            string directions = Convert.ToString(Console.ReadLine().ToLower());

            while (labCount<=5)
            {

                switch (directions)
                {

                    case "right":
                        if (labCount == 0)
                        {
                            labCount++;
                            //labCount = 1
                            Console.Clear();
                            Console.WriteLine("You walk down the hallway and notice a painting on the wall.\nIt depicts a young family, a tired woman laid out on a bed\nand a man beaming at the newborn child in his arms.\nIt's " +
                                "not obvious at first but you recognize the man and the woman\nas your own parents and the scene depicted as you're own birth.");
                            Console.ReadKey();
                            //Console.WriteLine(directions + ", " + labCount);
                            
                            Console.WriteLine("You notice also that the halway is becoming brighter, and you see an intersection up ahead.\nWhich way do you go? (right or left)");
                            
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                            //Console.WriteLine(directions + ", " + labCount);

                        }
                        else if (labCount == 1 )
                        {//dead ends are battles and they pop you back to the last intersection.
                            
                            Console.Clear();
                            Console.WriteLine("It's almost as if someone has shut off the light. A monster attacks out of the inky blackness.");
                            Console.ReadKey();
                            Battle();
                            Console.WriteLine("After defeating the monster you turn around and go the other way. (Please type: left)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());


                        }
                        else if (labCount == -2)
                        {
                            Console.WriteLine("You walk down a long ever darkening halway. Eventually you trip over a chest.\n(type: open or ignore)");
                            string opIg = Convert.ToString(Console.ReadLine().ToLower());
                            if (opIg == "open")
                            {
                                Mimic();
                                //Console.WriteLine("there will be a mimic here");
                                //after mimic fight it turns into a chest and you can pick from the same items
                                //then you warp back to the entrance
                                labCount = 0;
                                goto Start;
                            }
                            else if (opIg == "ignore")
                            {
                                Console.WriteLine("You ignore the chest and return to the entrance.");
                                Console.ReadKey();
                                labCount = 0;
                                goto Start;
                            }
                            else
                            {
                                Console.WriteLine("check your spelling.\n(please type: Open or Ignore)");
                                opIg = Convert.ToString(Console.ReadLine().ToLower());
                            }

                        }
                        else if (labCount == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("It's almost as if someone has shut off the light. A monster attacks out of the inky blackness.");
                            Console.ReadKey();
                            Battle();
                            Console.WriteLine("After defeating the monster you turn around and go the other way.\n(Please type: left or straight)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (labCount == 3)
                        {//nearing the end of maze pic is birth of players kid
                            labCount++;
                            //labcount=4
                            Console.Clear();
                            Console.WriteLine("This halway is brighter still, and you come upon another painting.\nYou see yourself, much younger, holding your baby for the first time. Your partner is there looking on proudly,\n" +
                                "patiently waiting their turn.");
                            Console.ReadKey();
                            Console.WriteLine("A warm feeling spreads through you\nand you continue on the only direction you can.\n(Type: straight)");//takes you to room with bright door and 
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        
                        //Console.ReadKey();

                        break;

                    case "left":
                        if (labCount == 0)
                        {
                            labCount--;
                            Console.Clear();
                            //labcount=-1
                            Console.WriteLine("The hallway darkens and you come upon a hallway to your left.\n(type: left)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());

                        }
                        else if(labCount == -1)
                        {
                            labCount--;
                            //labCount=-2
                            Console.Clear();
                            Console.WriteLine("The hallway continues to darken.\nIn the light of the of the torch you make out an opening in the wall to your right.\n(type: right)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (labCount == 1)
                        {
                            labCount++;
                            //labcount=2
                            Console.Clear();
                            Console.WriteLine("As you walk down the hallway you notice another painting.\nIt's of you as a small boy on your first tricycle as your childhood puppy chases you.\n" +
                                "Your mother and father look on from the porch smiling at you.\nYou remember this day fondly as one of your most cherished childhood memories.\nYou also notice the loving " +
                                "detail\nand tender brushstrokes of the artist.");
                            Console.ReadKey();
                            Console.WriteLine("The halway brightens further as you walk down and you come upon another intersection.\n(PLease type: Right, Left, or Straight.)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (labCount == 2)
                        {
                            labCount++;
                            //labcount = 3
                            Console.Clear();
                            Console.WriteLine("You come upon yet another painting. This one depicting your wedding,\nnot the ceremony nor the reception, however. No, this delicately painted image\nis of the swirling sheets and sweaty faces," +
                                "contorted in the ecstatic agony of consummation.");
                            Console.ReadKey();
                            Console.WriteLine("as you continue on down the halway the light intensifies, straining your eyes. You come upon another intersection.\n(Type: Right)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        

                        break;

                    case "straight":

                        if (labCount == 4)
                        {//last scene in maze brightly lit room full of paintings from players life light emanating from a doorway
                            labCount++;
                            //labcount=5
                            Console.Clear();
                            Console.WriteLine("You come upon a brightly lit room. Paintings depicting your happiest moments cover the walls from floor to ceiling.\nThe light seems to be emanating " +
                                "from a doorway at the back of the room.");
                            Console.ReadKey();
                            Console.WriteLine("You take some time appreciating the paintings, wallowing in nostalgia before approaching the door.\nAs you approach the door you notice a" +
                                "chest beside it.\nDo you open it? (type: yes or no)");
                            string chest = Convert.ToString(Console.ReadLine().ToLower());
                            if (chest == "yes")
                            {
                                Chest();
                            }
                            
                            Console.ReadKey();
                            Console.WriteLine("Do you go throught the doorway? (please type: yes or no)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (labCount == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("It's almost as if all light has been sucked out of the room. A monster jumps out at you.");
                            Console.ReadKey();
                            Battle();
                            Console.WriteLine("After defeating the monster you turn around and go the other way. (Please type: right or left)");
                            directions = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (labCount == 0)
                        {
                            //labCount++;
                            //labcount=0
                            Console.Clear();
                            Console.WriteLine("You smack into a wall face first.");
                            swordsman.TakeDamage(1);
                            Console.ReadKey();
                            Console.WriteLine("You are warped back to the beginning of the maze. (press any key to continue.)");
                            Console.ReadKey();
                            goto Start;
                        }
                        

                        break;
                    

                    case "yes":
                        swordsman.LevelUp();
                        FinalSit();
                        break;
                    case "no":
                        Console.WriteLine("You sit and wallow in your memories for the rest of eternity.");
                        Console.ReadKey();
                        Lose();
                        break;

                    default:
                        
                        Console.Clear();
                        Console.WriteLine("Something went wrong. Please check your spelling your last command was " + directions + ".");

                        
                        directions = Convert.ToString(Console.ReadLine().ToLower());

                        break;
                }
                Console.Clear();




            }
            //Console.WriteLine("you are out of the loop.");
            Console.ReadKey();
        }

        public static void FinalSit()
        {
            //maybe a boss battle
            //Console.WriteLine("This is FinalSit");
            Console.Clear();
            Console.WriteLine("You open the door and find yourself in a whitespace.\nIf there are walls or a ceiling you can't see them. The door dematerializes as you close it behind you.\nYou are alone.");
            Console.ReadKey();
            Console.WriteLine("Or so it seems.");
            Console.ReadKey();
            Console.WriteLine("A formless black cloud materializes in front of you.");
            Console.ReadKey();
            Boss();
            
            //conversation with black cloud you are the painter, the black cloud is all the other memories, it is all things, you fight it to get back to your life.
            //so bring in logic from other battles here change it up so theres multiple attacks with varying damage,
            //~50% hp form changes takes on the form of you 
            //25% hp form change starts glitching/losing shape again.
            //probsmake a diff method to contain boss battle logic
            

            
           
        }
        public static void Boss()
        {
            //talk is how to win
            //fight continues the loop until player gets >10 HP
            //then rdm heal between 40-80 hp
            //goad player into talk

            //alt - fight gets you bad ending talk gets good ending
            //alt alt - fight loops you back to the beginning of the game talk wakes you up in hospital with family
            Random pAttrdmizer = new Random();
            Random eAttrdmizer = new Random();
            int talkTic = 0;
            int bossHP = 100;
            string ftTlk;
            Console.WriteLine("The black cloud swirls around you. It swallows the air around you\nand contains you to where you can't tell it from your own skin.\n" +
                "Suddenly it separates and piles itself in front of you. It remains shapeless and stationary.");
            Console.WriteLine("What do you do?");
           
            Console.WriteLine("(type: fight or talk)");
            ftTlk = Convert.ToString(Console.ReadLine().ToLower());

            while (talkTic <=4 || bossHP >0)
            {
                Console.Clear();
                
                switch (ftTlk)
                {
                    case "talk":
                        int bossAtt = eAttrdmizer.Next(20, 41);
                        if (talkTic == 0)
                        {
                            talkTic++;
                            Console.WriteLine("You hold your torch in defense but notice the fire has grown weak.\nYou ask it what it is.");
                            Console.ReadKey();
                            Console.WriteLine("Its surface roils and bristles violently and a thick dark spike shoots forth into your forehead and you take " + (bossAtt / 8) + " Damage.\n" +
                                "You are covered in your own shit. Your father towers over you his face, much larger than you remember,\nhis brow is furrowed in frustration and desparate resignation. Without you knowing\n" +
                                "a powerful stream of piss erupts from you into his nostril.\nYou laugh as he throws the dirty towel and walks away, yelling.\nYou can't see him he's gone and you don't" +
                                "know if he's ever coming back.\nYou hear your own voice say \"I am The Darkness.\"");
                            swordsman.TakeDamage(bossAtt / 8);
                            Console.ReadKey();

                            Console.WriteLine("fight or talk?");
                            ftTlk = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (talkTic == 1)
                        {
                            talkTic++;
                            Console.WriteLine("Without letting your guard down you ask it what is going on.");
                            Console.ReadKey();
                            Console.WriteLine("It's fringes become sharp and jagged. It spreads wide like the wings of a bat\nwith sharp spines at the tips and shrouds the area around you" +
                                " in darkness.\nYou are filled with despair and take " + (bossAtt / 6) + " damage. A memory flashes to the fore of your mind:\nyou farted in class next to the meanest girl in 6th grade.\nShe covers her mouth and nose with her sleeve" +
                                "\nand exclaims in disgust as the rest of the class giggles.");
                            swordsman.TakeDamage(bossAtt / 6);
                            Console.ReadKey();
                            Console.WriteLine("fight or talk?");
                            ftTlk = Convert.ToString(Console.ReadLine().ToLower());

                        }
                        else if (talkTic == 2)
                        {
                            talkTic++;
                            Console.WriteLine("You ask why this is happening to you, and hold your torch to look around but\nnotice the only light is coming from small cracks in the enemy's dark sphere" +
                                "\nshooting thin ribbons of light in all directions.");
                            Console.ReadKey();
                            Console.WriteLine("The ribbons of light play in the darkness until they focus\non a spot directly before you. You see a rough hologram of yourself in a stained T-shirt\n" +
                                "laying out on your couch, computer resting on your belly.\nThe image multiplies and you see the same thing with different T-shirts and various modes of entertainment.\n" +
                                "It's just you always just you alone killing time.\nYou take " + (bossAtt / 4) + " damage.");
                            swordsman.TakeDamage(bossAtt / 4);
                            Console.ReadKey();
                            Console.WriteLine("fight or talk?");
                            ftTlk = Convert.ToString(Console.ReadLine().ToLower());
                        }
                        else if (talkTic == 3)
                        {
                            talkTic++;
                            Console.WriteLine("The dome is in tatters, yet hardly any light passes through.\nA distance away you can make out a dark shape.\nYou call out to it" +
                                "asking why you are here.");
                            Console.ReadKey();
                            Console.WriteLine("You are in the hospital standing at your mother's bedside.\nShe has no hair, and her skin crinkles like paper under chin.\nShe reaches a spotted and scarred hand out to touch yours.\n" +
                                "You fight back the instinct to recoil, and let her hold you.\nShe asks how it's been at school, if you'd finished all your homework.\nYour dad steps in to say that's not what you came to talk about." +
                                "\nSo you do tell her what you came to say.\nYou tell her you love her. You tell her you're going to miss her. You tell her goodbye.\nYou take "+ bossAtt + " damage."); 
                            swordsman.TakeDamage(bossAtt);
                            Console.ReadKey();
                            Console.WriteLine("fight or talk?");
                            ftTlk = Convert.ToString(Console.ReadLine().ToLower());
                        }

                        else if (talkTic == 4)
                        {
                            talkTic++;
                            Console.WriteLine("The dark dome is stripped away allowing the bright whiteness through.\nA jet black human shadow sits before you slumped over head in its hands.");
                            Console.ReadKey();
                            Console.WriteLine("You approach The Darkness, slowly at first. It doesn't seem to notice you even as you get right up next to it.");
                            Console.ReadKey();
                            Console.WriteLine("You crouch down next to it and ask why, why did it show you all these things.");
                            Console.ReadKey();
                            Console.WriteLine("The Darkness bolts upright grabbing you by the face pulling you up with it.\nIt screams in the voice you use only in moments of your deepest despair." +
                                "\nThe blood curdling screech only you and your pillow know. You try to wrest yourself away,\ntaking its forearms in your hands you try to pull it off you.\n" +
                                "This only makes it's hold stronger as if its hands are sewn to your temples.");
                            Console.ReadKey();
                            swordsman.TakeDamage(swordsman.MyHealth - 1);
                            Console.ReadKey();
                            Console.WriteLine("It screams again and your ears buzz from the volume.\nYou look into its eyes and see they aren't there." +
                                "\n\"Don't take me back, please just destroy me.\" it pleads. \"It's despair and sorrow and discomfort and loss.\nThere is nothing there for me, nothing there for us,\nplease don't make me go back.\"");
                            Console.ReadKey();
                            Console.WriteLine("The grey brick archway from which you entered rematerializes next to you.\nWhat do you do?\n(Please type: drag or destroy)");
                            string dragOrDont = Convert.ToString(Console.ReadLine().ToLower());
                            if (dragOrDont == "drag")
                            {
                                Win();
                            }
                            else if (dragOrDont == "don't")
                            {
                                BossBadEnding();
                            }
                            else
                            {
                                Console.WriteLine("Please check your spelling, (drag it, destroy).");
                                dragOrDont = Convert.ToString(Console.ReadLine().ToLower());
                                if (dragOrDont == "drag")
                                {
                                    Win();
                                }
                                else if (dragOrDont == "don't")
                                {
                                    BossBadEnding();
                                }
                                else
                                {
                                    BossBadEnding();
                                }
                            }
                        }
                        break;

                    case "fight":
                        int playerAtt = pAttrdmizer.Next(1, 21) + swordsman.MyAttack;
                        int bossAttFt = playerAtt * (3 / 2);
                        Console.Clear();




                        if ((bossHP - playerAtt) <= 0)
                        {

                            Console.WriteLine("You swing your torch at the Darkness for " + playerAtt + " points of damage");
                            bossHP = bossHP - playerAtt;
                            swordsman.MyExp += 15;
                            Console.WriteLine("The Darkness recedes to blinding white and you feel like you're falling.\nThere's nothing to hold on to, nothing to save you and you're falling\n" +
                                "faster and faster.");
                            Console.ReadKey();
                            Console.WriteLine("\nYou have gained 15 points of experience.\nyou now have " + swordsman.MyExp + " Exp.");
                            Console.ReadKey();
                            swordsman.LevelUp();
                            Console.ReadKey();
                            GameStart();
                        }



                        else
                        {
                            if (bossAttFt <= 0)
                            {
                                bossAttFt = 0;
                            }
                            Console.WriteLine("You swing your torch at the Darkness for " + playerAtt + " points of damage");
                            bossHP = bossHP - playerAtt;
                            //Console.WriteLine("The skeleton now has " + skelHP + " hit points");
                            Console.ReadKey();
                            Console.WriteLine("You feel a hot, blunt object strike you for " + bossAttFt + " points of damage.");
                            swordsman.TakeDamage(bossAttFt);

                            Console.WriteLine("fight or talk?");
                            ftTlk = Convert.ToString(Console.ReadLine().ToLower());
                            

                        }
                        break;

                    default:
                        Console.WriteLine("please check your spelling.");
                        Console.WriteLine("fight or talk?");
                        ftTlk = Convert.ToString(Console.ReadLine().ToLower());
                        
                        
                        break;
                }
                
            }
        }

        private static void BossBadEnding()
        {
            //fix to where you destroy the darkness but still can't go through door, fight leads here too
            string bLYN;
            Console.WriteLine("You tighten your grip on The Darkness and tear away it's hands from your face.\nYou feel your skin separating from the bone, but you ignore it.\n" +
                "The Darkness' face drops in fear. You twist its wrist outward and feel a burning in yours.\nYou raise its arms above your head and force it to its knees." +
                "A boiling anger rises in your gut.\nYou pull it into you as you bring your foot down on its head releasing its arms as you do so.\n" +
                "You don't notice the skin peeled from your hands as you repeatedly stomp its head.\nWith each repeated stomp it takes another piece of you until you are nothing\n" +
                "but a skeleton with fresh ribbons of skin dangling from your frame.");
            //Console.WriteLine("The Darkness loosens its grip on you and sits back down. It makes no other sound.");
            Console.ReadKey();
            Console.WriteLine("The Darkness stands up and you see its dark lips form a smile as it pushes you out through the door.");
            //Console.WriteLine("You try the door but it won't open for you. You look back down at\nThe Darkness but it remains unmoving with its head in its hands.\n" +
            //    "It dawns on you that you can't leave without it. It won't budge, you no longer have the strength, you no longer have the stamina.\n" +
            //    "You waste away trying to move The Darkness from it's spot.");
            Console.ReadKey();
            Console.WriteLine("Would you like to try for a better ending?\n(Please type: Yes or No)");
            bLYN = Convert.ToString(Console.ReadLine().ToLower());
            
            switch (bLYN)
            {
                case "yes":
                    GameStart();
                    break;
                case "no":
                    Console.WriteLine("GoodBye");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("please check your spelling and re-enter your last command (yes or no)");
                    bLYN = Convert.ToString(Console.ReadLine().ToLower());
                    break;
            }

        }

        public static void Lose()
        {
            //lost all health GAME OVER screen
            Console.WriteLine("Rough day, huh?");
            Console.ReadKey();
            Console.WriteLine("It's gone all black.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You died.");
            Console.ReadKey();
            Console.WriteLine("For real this time.");
            Console.ReadKey();
            Console.Clear();
            Console.Write("Would you like to try for a better ending??\n(Please type: yes or no): ");

            string whyEn = Convert.ToString(Console.ReadLine().ToLower());
            Console.WriteLine();
            
            if (whyEn == "y"||whyEn == "yes")
            {
                GameStart();
            }
            else
            {
                Console.WriteLine("Then close the program,\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\nCoward.");
                Console.ReadKey();
            }

        }
        public static void Win()
        {
            //called after solving the boss
            //Player takes darkness back through the labrynth of happy memories
            //you wake up with your family surrounding you.

            Console.Clear();
            Console.WriteLine("Your grasp tightens on The Darkness and you drag it by the wrist pushing it deeper into your temples.\nIts face sinks in fear as it realizes what you're doing." +
                "Its arms lock at the elbows and tries to push you away as its hands melt into your skull.\nMemories rush in like cold, thick brine; memories of everytime you screamed at your significant other;" +
                "\nof all the times you told your parents you hated them; of all the times you lied, stole, cheated and hurt.\n");
            Console.ReadKey();
            Console.WriteLine("You look The Darkness dead in the shallow pits where your eyes would be,\nand you grip harder.\nIt locks out its knees and digs in its heels,\nbut you lean back knocking it off balance." +
                " It reels trying to find footing again but now it's face to face with you.\nNose to nose.\nEye to eye.\nAs your face touches with The Darkness it upends and falls into you feet flailing all the way down.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("In a flash it's gone and you stand alone in the whitespace.\nThe door opens and you see the bright room with all of your paintings.\nYou take the time to examine and soak in each one." +
                "Forcing The Darkness inside you to see them,\neach smile you gave to a friend, every touch of a loved one, and\nevery warm quiet night you shared with someone close.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You're in a room with bright lights shining in your eyes. Your back is sore as if from a rash.\nYour eyes adjust and the shadows become more defined.\n" +
                "You're on a bed with starchy green blankets and tubes prevent your mouth from closing.\nThere's a flurry of noise and fast rushing shadows. Until your eyes focus.\n");
            Console.ReadKey();
            Console.WriteLine("Your family surrounds you waiting for your return. Excitement fills the room bulging the walls\nand warping the windowpanes.");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("You did it! You beat back your darkness and returned to your family!\n\nThis is the best ending in my opinion,\nbut would you like to try again for funsies?\n" +
                "(Please type: yes or I'm satisfied)");


            string yn = Convert.ToString(Console.ReadLine().ToLower());
            Console.WriteLine();

            if (yn == "y"||yn == "yes"||yn == "yse" || yn == "sye" || yn == "eys")
            {
                GameStart();
            }
            else
            {
                Console.WriteLine("Thanks for playing!");
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.WriteLine("That's all folks.");
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.ReadKey();
                Console.WriteLine("No really... That's it.");
                Console.ReadKey();
            }

        }
        
        
        public static void Battle()//this might have to be in enemy or expanded into several separate fxns to represent diff enemys or it could rdmize and output the diff enemy encounters
        {
            string answer;
            Random rdm = new Random();
            int num = rdm.Next(1, 6);


            switch (num)
            {
                case 1:
                    //Console.WriteLine("case 1");

                    Skeleton();


                    break;
                case 2:
                    //Console.WriteLine("case 2");
                    SpiderLrg();
                    break;
                case 3:
                    //Console.WriteLine("case 3");
                    SpiderSmall();
                    break;
                case 4:
                    //Console.WriteLine("case 4");
                    Console.WriteLine("You find a chest!\nDo you open it?\n(Please type: Yes or No)");
                    answer = Convert.ToString(Console.ReadLine().ToLower());
                    if (answer == "yes" || answer == "y")
                    {
                        Mimic();
                    }
                    else
                    {
                        Console.WriteLine("You ignore the chest and walk away.");
                        
                    }
                    break;
                case 5:
                    Console.WriteLine("You find a chest!\nDo you open it?\n(Please type: Yes or No)");
                    answer = Convert.ToString(Console.ReadLine().ToLower());
                    if (answer == "yes" || answer == "y")
                    {
                        Chest();
                    }
                    else
                    {
                        Console.WriteLine("You ignore the chest and walk away.");

                    }

                    break;
                default:
                    Console.WriteLine("You came to a dead end and turned around.");
                    break;
            }
            // ideas for monsters:
            //skeleton with leathery ribbons of skin decent HP
            //small spider severely low hp
            //large spider lower hp
            //something else


        }
        private static void Potion()
        {
            Random potRdm = new Random();
            int potion = potRdm.Next(10, 21);
            Console.WriteLine("You find a mysterious incandescent liquid. It feels like it's teeming with energy!\n\nDo you drink it?\nY/N");
            string yesNo = Convert.ToString(Console.ReadLine().ToLower());
            if (yesNo == "yes"|| yesNo == "y")
            {
                swordsman.GainHealth(potion);

            }
            else if (yesNo == "no"|| yesNo == "n")
            {
                Console.WriteLine("You should probably drink it.\nI promise nothing bad will happen.");
                Console.WriteLine();
                Console.ReadKey();
                Console.WriteLine("You drink the potion.");
                swordsman.GainHealth(potion);

            }
            
        }
        public static void Skeleton()//60hp 3exp attack 9-15, take out reading out remaining enemy health to amplify feeling of fear
        {

            Random pAttrdmizer = new Random();
            Random eAttrdmizer = new Random();

            int skelHP = 60;
            Start:
            Console.WriteLine("A skeleton dripping with ribbons of leathery skin jumps from around the corner.\nIt raises a sword and shield toward you.");
            Console.WriteLine("What do you do?");
            //Console.WriteLine();
            Console.WriteLine("(type: fight or run)");
            string ftRn = Convert.ToString(Console.ReadLine().ToLower());


            if (ftRn == "run")
            {
                Console.Clear();
                Console.WriteLine("You run away screaming.");
                //Console.ReadKey();
            }
            else if (ftRn == "fight")
            {

                while (skelHP > 0)
                {
                    int playerAtt = pAttrdmizer.Next(1, 21) + swordsman.MyAttack;
                    int skelAttack = eAttrdmizer.Next(13,20) - swordsman.MyDefense;
                    Console.Clear();


                    

                    if ((skelHP - playerAtt) <= 0)
                    {

                        Console.WriteLine("You swing your torch at the skeleton for " + playerAtt + " points of damage");
                        skelHP = skelHP - playerAtt;
                        swordsman.MyExp+=3;
                        Console.WriteLine("The skeleton falls in a heap and a sense of gratitude washes through you as its spirit finally escapes.\n\nYou have gained 3 points of experience.\nyou now have " + swordsman.MyExp + " Exp.");
                    }



                    else
                    {
                        if (skelAttack <= 0)
                        {
                            skelAttack = 0;
                        }
                        Console.WriteLine("You swing your torch at the skeleton for " + playerAtt + " points of damage");
                        skelHP = skelHP - playerAtt;
                        //Console.WriteLine("The skeleton now has " + skelHP + " hit points");
                        Console.ReadKey();
                        Console.WriteLine("The skeleton slashes you for " + skelAttack + " points of damage.");
                        swordsman.TakeDamage(skelAttack);

                        Console.WriteLine("fight or run?");
                        ftRn = Convert.ToString(Console.ReadLine().ToLower());
                        if (ftRn == "run")
                        {
                            Console.Clear();
                            Console.WriteLine("You run away screaming.");
                            skelHP = 0;
                            //Console.ReadKey();

                        }

                    }

                    


                }


            }
            else
            {
                Console.WriteLine("please check your spelling.");
                Console.ReadKey();
                Console.Clear();
                goto Start;
            }

        }
        public static void Mimic()//75hp 6exp att 16-25
        {
            string ftRn;
            
            Random pAttrdmizer = new Random();
            Random eAttrdmizer = new Random();

            int mimHP = 75;
            Start:
            
            
            Console.WriteLine("As you open the chest you see razor-sharp metallic teeth\nprotruding from the underside of the lid. In the time it takes you to think it weird the lid snaps back on it's own\n" +
                "and a liquid ruby tongue lashes out at you.\nYou jump back.");
            Console.WriteLine("What do you do?");
            
            Console.WriteLine("(type: fight or run)");
            ftRn = Convert.ToString(Console.ReadLine().ToLower());


            if (ftRn == "run")
            {
                Console.Clear();
                Console.WriteLine("You run away screaming.");
                //Console.ReadKey();
            }
            else if (ftRn == "fight")
            {

                while (mimHP > 0)
                {
                    int playerAtt = pAttrdmizer.Next(1, 21) + swordsman.MyAttack;
                    int mimAtt = eAttrdmizer.Next(16, 26) - swordsman.MyDefense;
                    Console.Clear();




                    if ((mimHP - playerAtt) <= 0)
                    {

                        Console.WriteLine("You attack the mimic for " + playerAtt + " points of damage");
                        mimHP = mimHP - playerAtt;
                        swordsman.MyExp += 6;
                        Console.WriteLine("It's tongue drops limp onto the edge of the chest before evaporating along with its teeth.\nIt is now a normal chest.\n\nYou have gained 6 points of experience.\nyou now have " + swordsman.MyExp + " Exp.");
                        Console.ReadKey();
                        Chest();
                    }



                    else
                    {
                        if (mimAtt <= 0)
                        {
                            mimAtt = 0;
                        }
                        Console.WriteLine("You attack the mimic for " + playerAtt + " points of damage");
                        mimHP = mimHP - playerAtt;
                        //Console.WriteLine("The skeleton now has " + skelHP + " hit points");
                        Console.ReadKey();
                        Console.WriteLine("The mimic bites you for " + mimAtt + " points of damage.");
                        swordsman.TakeDamage(mimAtt);

                        Console.WriteLine("fight or run?");
                        ftRn = Convert.ToString(Console.ReadLine().ToLower());
                        if (ftRn == "run")
                        {
                            Console.Clear();
                            Console.WriteLine("You run away screaming.");
                            mimHP = 0;
                            //Console.ReadKey();

                        }

                    }




                }


            }
            else
            {
                Console.WriteLine("please check your spelling.");
                Console.ReadKey();
                Console.Clear();
                goto Start;
            }
        }
        public static void SpiderLrg()//45hp 4exp damage 15-20
        {

            Random pAttrdmizer = new Random();
            Random eAttrdmizer = new Random();

            int spiHP = 45;
            Start:
            Console.WriteLine("A spider towers over you. It leans down and snaps its venomous, dripping fangs\nthen rears back on its hind legs.");
            Console.WriteLine("What do you do?");
            Console.WriteLine();
            Console.WriteLine("(type: fight or run)");
            string ftRn = Convert.ToString(Console.ReadLine().ToLower());

         
            if (ftRn == "run")
            {
                Console.Clear();
                Console.WriteLine("You run away screaming.");
                //Console.ReadKey();
            }
            else if (ftRn == "fight")
            {

                while (spiHP > 0)
                {
                    int playerAtt = pAttrdmizer.Next(1, 21) + swordsman.MyAttack;
                    int spiAtt = eAttrdmizer.Next(15, 21) - swordsman.MyDefense;
                    Console.Clear();




                    if ((spiHP - playerAtt) <= 0)
                    {

                        Console.WriteLine("You attack the spider for " + playerAtt + " points of damage");
                        spiHP = spiHP - playerAtt;
                        swordsman.MyExp+= 4;
                        Console.WriteLine("The spider falls on its back and its legs curl in. You murdered a wild animal...\nin self defense of course.\n\nYou have gained 4 points of experience.\nyou now have " + swordsman.MyExp + " Exp.");
                    }



                    else
                    {
                        if (spiAtt <= 0)
                        {
                            spiAtt = 0;
                        }

                        Console.WriteLine("You attack the spider for " + playerAtt + " points of damage");
                        spiHP = spiHP - playerAtt;
                        //Console.WriteLine("The spider now has " + spiHP + " hit points");
                        Console.ReadKey();
                        Console.WriteLine("The spider slashes you for " + spiAtt + " points of damage.");
                        swordsman.TakeDamage(spiAtt);
                        Console.WriteLine("fight or run?");
                        ftRn = Convert.ToString(Console.ReadLine().ToLower());
                        if (ftRn == "run")
                        {
                            Console.Clear();
                            Console.WriteLine("You run away screaming.");
                            spiHP = 0;
                            //Console.ReadKey();

                        }

                    }




                }


            }
            else
            {
                Console.WriteLine("please check your spelling.");
                Console.ReadKey();
                Console.Clear();
                goto Start;
            }
        }
        public static void SpiderSmall()//variable hp 2exp wildly variable damage
        {

            Random pAttrdmizer = new Random();
            Random eAttrdmizer = new Random();
            Random spiRdmize = new Random();
            Random spiHPRdm = new Random();
            int spiChooser = spiRdmize.Next(1, 6);
            int sSpiHP = spiHPRdm.Next(18,33);
            Start:
            Console.WriteLine("A regular spider crawls on your arm. It could be a black widow or it could be a wolf spider.\nIt's dark in here you don't know");
            Console.WriteLine("What do you do?");
            Console.WriteLine();
            Console.WriteLine("(type: fight or run)");
            string ftRn = Convert.ToString(Console.ReadLine().ToLower());


            if (ftRn == "run")
            {
                Console.Clear();
                Console.WriteLine("You flail your arms wildly and run back to the last intersection. You can never\nbe sure you got the spider off.");
                //Console.ReadKey();
            }
            else if (ftRn == "fight")
            {

                while (sSpiHP > 0)
                {
                    int playerAtt = pAttrdmizer.Next(1, 21) + swordsman.MyAttack;
                    int sSpiAtt;
                    switch (spiChooser)
                    {
                        case 1:
                            sSpiAtt = 0;
                            break;
                        case 2:
                            sSpiAtt = eAttrdmizer.Next(5) - swordsman.MyDefense;
                            break;
                        case 3:
                            sSpiAtt = 95;
                            break;
                        case 4:
                            sSpiAtt = eAttrdmizer.Next(4) - swordsman.MyDefense;
                            break;
                        default:
                            sSpiAtt = 0;
                            break;
                    }
                    Console.Clear();




                    if ((sSpiHP - playerAtt) <= 0)
                    {

                        Console.WriteLine("You smack the spider for " + playerAtt + " points of damage,\nand leave a welt on your arm.");
                        sSpiHP = sSpiHP - playerAtt;
                        swordsman.MyExp+=2;
                        Console.WriteLine("You squish the spider and wipe the goo off your hands on the wall.\n\nYou have gained 2 points of experience.\nyou now have " + swordsman.MyExp + " Exp.");
                    }



                    else
                    {
                        if (sSpiAtt <= 0)
                        {
                            sSpiAtt = 0;
                        }
                        Console.WriteLine("You smack the spider for " + playerAtt + " points of damage,\nand leave a welt on your arm.");
                        sSpiHP = sSpiHP - playerAtt;
                        //Console.WriteLine("The spider now has " + sSpiHP + " hit points");
                        Console.ReadKey();
                        Console.WriteLine("The spider bites you for " + sSpiAtt + " points of damage.");
                        swordsman.TakeDamage(sSpiAtt);
                        Console.WriteLine("fight or run?");
                        ftRn = Convert.ToString(Console.ReadLine().ToLower());
                        if (ftRn == "run")
                        {
                            Console.Clear();
                            Console.WriteLine("You flail your arms wildly and run back to the last intersection. You can never\nbe sure you got the spider off.");
                            sSpiHP = 0;
                            //Console.ReadKey();

                        }

                    }




                }


            }
            else
            {
                Console.WriteLine("please check your spelling.");
                Console.ReadKey();
                Console.Clear();
                goto Start;
            }

        }
    }
}