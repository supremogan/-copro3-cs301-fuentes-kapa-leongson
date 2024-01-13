using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NewpasaBago
{
    public interface ICharacterInfo
    {
        string Name { get; set; }
        int Origin { get; set; }
        int Companion { get; set; }
        int Role { get; set; }
        int Ability { get; set; }
        int FaceShape { get; set; }
        int HairLength { get; set; }
        int HairColor { get; set; }
        int HairType { get; set; }
        int BodyType { get; set; }
        int EyeColor { get; set; }
        int MouthType { get; set; }
        int Height { get; set; }
        int Race { get; set; }
        int Gender { get; set; }
        int Personality { get; set; }
        int Skin { get; set; }
        int Shirt { get; set; }
        int Bottom { get; set; }
        int Shoes { get; set; }
        int Accessories { get; set; }
        int Scar { get; set; }
    }
    public abstract class CharacterCreated
    {
        public abstract void SetCharacterInfo();
    }

    public struct CharacterStatus
    {
        public bool Cursed;

    }
    public class CharacterMenu : CharacterCreated, ICharacterInfo
    {
        private string playerName;
        private int originChoice;
        private int compChoice;
        private int roleChoice;
        protected int abilityChoice;
        private int faceShapeChoice;
        private int hairLengthChoice;
        private int hairColorChoice;
        private int hairTypeChoice;
        private int bodyTypeChoice;
        private int eyeColorChoice;
        private int mouthTypeChoice;
        private int heightChoice;
        private int raceChoice;
        private int genderChoice;
        private int personalityChoice;
        private int skinChoice;
        private int shirtTypeChoice;
        private int bottomTypeChoice;
        private int shoesChoice;
        private int accessoriesChoice;
        private int scarChoice;
        protected int totalStatPoints = 15;
        protected int defaultStats = 10;
        protected string[] attributeName = { "Strength", "Defense", "Luck", "Stealth", "Endurance", "Stamina", "Intelligence", "Agility" };
        protected int[] attributeChoice = new int[8];


        public string databaseNamin = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=C:\USERS\SUPRE\SOURCE\REPOS\NEWPASABAGO\NEWPASABAGO\CHARACTER.MDF;Integrated Security=True";



        public CharacterStatus Status { get; set; }

        public bool Cursed { get; set; }
        public string Name
        {
            get { return playerName; }
            set { playerName = value; }
        }
        public int Origin
        {
            get { return originChoice; }
            set { originChoice = value; }
        }
        public int Companion
        {
            get { return compChoice; }
            set { compChoice = value; }
        }
        public int Role
        {
            get { return roleChoice; }
            set { roleChoice = value; }
        }
        public int Ability
        {
            get { return abilityChoice; }
            set { abilityChoice = value; }
        }
        public int FaceShape
        {

            get { return faceShapeChoice; }
            set { faceShapeChoice = value; }
        }
        public int HairLength
        {
            get { return hairLengthChoice; }
            set { hairLengthChoice = value; }
        }
        public int HairColor
        {
            get { return hairColorChoice; }
            set { hairColorChoice = value; }
        }
        public int HairType
        {
            get { return hairTypeChoice; }
            set { hairTypeChoice = value; }
        }
        public int BodyType
        {
            get { return bodyTypeChoice; }
            set { bodyTypeChoice = value; }
        }
        public int EyeColor
        {
            get { return eyeColorChoice; }
            set { eyeColorChoice = value; }
        }
        public int MouthType
        {
            get { return mouthTypeChoice; }
            set { mouthTypeChoice = value; }
        }
        public int Height
        {
            get { return heightChoice; }
            set { heightChoice = value; }
        }
        public int Race
        {
            get { return raceChoice; }
            set { raceChoice = value; }
        }
        public int Gender
        {
            get { return genderChoice; }
            set { genderChoice = value; }
        }
        public int Personality
        {
            get { return personalityChoice; }
            set { personalityChoice = value; }
        }
        public int Skin
        {
            get { return skinChoice; }
            set { skinChoice = value; }
        }
        public int Shirt
        {
            get { return shirtTypeChoice; }
            set { shirtTypeChoice = value; }
        }
        public int Bottom
        {
            get { return bottomTypeChoice; }
            set { bottomTypeChoice = value; }
        }
        public int Shoes
        {
            get { return shoesChoice; }
            set { shoesChoice = value; }
        }
        public int Accessories
        {
            get { return accessoriesChoice; }
            set { accessoriesChoice = value; }
        }
        public int Scar
        {
            get { return scarChoice; }
            set { scarChoice = value; }
        }


        public CharacterMenu(string playerName, int originChoice, int compChoice, int roleChoice, int faceShapeChoice, int hairLengthChoice, int hairColorChoice,
            int hairTypeChoice, int bodyTypeChoice, int eyeColorChoice, int mouthTypeChoice, int heightChoice, int raceChoice, int genderChoice, int personalityChoice, int skinChoice,
            int shirtTypeChoice, int bottomTypeChoice, int shoesChoice, int accessoriesChoice, int scarChoice)
        {
            this.playerName = playerName;
            this.originChoice = originChoice;
            this.compChoice = compChoice;
            this.roleChoice = roleChoice;
            this.faceShapeChoice = faceShapeChoice;
            this.hairLengthChoice = hairLengthChoice;
            this.hairColorChoice = hairColorChoice;
            this.hairTypeChoice = hairTypeChoice;
            this.bodyTypeChoice = bodyTypeChoice;
            this.eyeColorChoice = eyeColorChoice;
            this.mouthTypeChoice = mouthTypeChoice;
            this.heightChoice = heightChoice;
            this.raceChoice = raceChoice;
            this.genderChoice = genderChoice;
            this.personalityChoice = personalityChoice;
            this.skinChoice = skinChoice;
            this.shirtTypeChoice = shirtTypeChoice;
            this.bottomTypeChoice = bottomTypeChoice;
            this.shoesChoice = shoesChoice;
            this.accessoriesChoice = accessoriesChoice;
            this.scarChoice = scarChoice;

            this.Status = new CharacterStatus { Cursed = false };
        }

        public void SetCharacterInfo(CharacterMenu[] characters, int index)
        {
            string[] originChoice = { "Lurra", "Eldoria", "Nithos" };
            string[] compChoice = { "Wolf", "Pixiemander", "Python" };
            string[] roleChoice = { "Knight", "Mage", "Berserker", "Healer", "Archer", "Assassin" };
            string[] abilityChoices = { "Shadow Dash", "Necromancy", "Invincibility", "Camouflage" };
            string[] faceShapeChoice = { "Round", "Oval", "Diamond", "Heart", "Rectangular", "Square" };
            string[] hairLengthChoice = { "Long", "Shoulder-Length", "Bobbed", "Short", "Buzzed", "Bald" };
            string[] hairColorChoice = { "Black", "Brown", "Blonde", " Red", "Ginger", "Auburn", "White", "Gray" };
            string[] hairTypeChoice = { "Straight", "Wavy", "Curly", "Coily", "Locked" };
            string[] bodyTypeChoice = { "Lean", "Muscular", "Average", "Slender", "Stout", "Curvaceous" };
            string[] eyeColorChoice = { "Brown", "Black", "Blue", "Hazel", "Gold" };
            string[] mouthTypeChoice = { "Natural", "Thin", "Round", "Wide", "Heart-Shaped" };
            string[] heightChoice = { "Short", "Average", "Tall" };
            string[] raceChoice = { "Human", "Elf", "Orc", "Dwarf", "Melusine" };
            string[] genderChoice = { "Male", "Female", "Non-Binary" };
            string[] personalityChoice = { "Timid", "Calm", "Expressive", "Aggressive", "Cheerful", "Stoic" };
            string[] skinChoice = { "Pale", "Light", "Tan", "Dark Brown", "Warm Brown", "Mahogany" };
            string[] shirtTypeChoice = { "Tunic", "Robe", "Cloak", "Gown", "Smock", "Surcot" };
            string[] bottomTypeChoice = { "Braisers", "Trousers", "Skirt" };
            string[] shoesChoice = { "Patten", "Leather Boots" };
            string[] accessoriesChoice = { "Bandage", "Necklace", "Scarf", "Hijab", "Ring" };
            string[] scarChoice = { "Scar - Eye", "Scar - Lips", "Scar - Abdomen", "None" };
            bool nameAlreadyExists = false;



            do
            {
                Console.WriteLine("---------------------------------------------------");
                do
                {
                    Console.Write("Can you tell me your name? ");
                    characters[index].playerName = Console.ReadLine().ToUpper();
                    if (string.IsNullOrWhiteSpace(characters[index].playerName))
                    {
                        Console.WriteLine("Name cannot be empty or blank. Please enter a valid name.");
                    }
                    else
                    {
                        break;
                    }

                } while (true);
                using (SqlConnection Connected = new SqlConnection(databaseNamin))
                {
                    Connected.Open();

                    string checkNameQuery = "SELECT COUNT(*) FROM dbo.CharacterInfo WHERE Name = @PlayerName";

                    using (SqlCommand checkNameCommand = new SqlCommand(checkNameQuery, Connected))
                    {
                        checkNameCommand.Parameters.AddWithValue("@PlayerName", characters[index].playerName);

                        int existingCount = (int)checkNameCommand.ExecuteScalar();

                        if (existingCount > 0)
                        {
                            Console.WriteLine($"Player with the name '{characters[index].playerName}' already exists. Choose a different name.");
                            nameAlreadyExists = true;
                        }
                        else
                        {
                            nameAlreadyExists = false;
                        }
                    }
                }

            } while (nameAlreadyExists);
            Console.WriteLine("---------------------------------------------------");


            Console.WriteLine("Now, before you enter this world " + characters[index].playerName + "," + " I have a few more questions need answered.");
            while (true)
            {
                try
                {
                    Console.WriteLine("Firstly, where do you come from?");
                    Console.WriteLine($"1. {originChoice[0]}");
                    Console.WriteLine($"2. {originChoice[1]}");
                    Console.WriteLine($"3. {originChoice[2]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].originChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].originChoice < 1 || characters[index].originChoice > originChoice.Length)
                    {
                        throw new InvalidInputException("Invalid origin choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("I've been told you had a companion travelling with you, what type of companion are they? ");
                    Console.WriteLine($"1. {compChoice[0]}");
                    Console.WriteLine($"2. {compChoice[1]}");
                    Console.WriteLine($"3. {compChoice[2]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].compChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].compChoice < 1 || characters[index].compChoice > compChoice.Length)
                    {
                        throw new InvalidInputException("Invalid origin choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Now what is your class? ");
                    Console.WriteLine($"1. {roleChoice[0]}");
                    Console.WriteLine($"2. {roleChoice[1]}");
                    Console.WriteLine($"3. {roleChoice[2]}");
                    Console.WriteLine($"4. {roleChoice[3]}");
                    Console.WriteLine($"5. {roleChoice[4]}");
                    Console.WriteLine($"6. {roleChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].roleChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].roleChoice < 1 || characters[index].roleChoice > roleChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("A class comes with a special ability, What ability do you have?");
                    Console.WriteLine($"1. {abilityChoices[0]}");
                    Console.WriteLine($"2. {abilityChoices[1]}");
                    Console.WriteLine($"3. {abilityChoices[2]}");
                    Console.WriteLine($"4. {abilityChoices[3]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].abilityChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].abilityChoice < 1 || characters[index].abilityChoice > abilityChoices.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Okay! now that I know who you are, let's move on to your appearance");
                    Console.WriteLine("First, Can you describe the shape of your face?");
                    Console.WriteLine($"1. {faceShapeChoice[0]}");
                    Console.WriteLine($"2. {faceShapeChoice[1]}");
                    Console.WriteLine($"3. {faceShapeChoice[2]}");
                    Console.WriteLine($"4. {faceShapeChoice[3]}");
                    Console.WriteLine($"5. {faceShapeChoice[4]}");
                    Console.WriteLine($"6. {faceShapeChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].faceShapeChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].faceShapeChoice < 1 || characters[index].faceShapeChoice > faceShapeChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Can you describe the length of your hair?");
                    Console.WriteLine($"1. {hairLengthChoice[0]}");
                    Console.WriteLine($"2. {hairLengthChoice[1]}");
                    Console.WriteLine($"3. {hairLengthChoice[2]}");
                    Console.WriteLine($"4. {hairLengthChoice[3]}");
                    Console.WriteLine($"5. {hairLengthChoice[4]}");
                    Console.WriteLine($"6. {hairLengthChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].hairLengthChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].hairLengthChoice < 1 || characters[index].hairLengthChoice > hairLengthChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("What is the color of your hair?");
                    Console.WriteLine($"1. {hairColorChoice[0]}");
                    Console.WriteLine($"2. {hairColorChoice[1]}");
                    Console.WriteLine($"3. {hairColorChoice[2]}");
                    Console.WriteLine($"4. {hairColorChoice[3]}");
                    Console.WriteLine($"5. {hairColorChoice[4]}");
                    Console.WriteLine($"6. {hairColorChoice[5]}");
                    Console.WriteLine($"7. {hairColorChoice[6]}");
                    Console.WriteLine($"8. {hairColorChoice[7]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].hairColorChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].hairColorChoice < 1 || characters[index].hairColorChoice > hairColorChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Describe the type of your hair?");
                    Console.WriteLine($"1. {hairTypeChoice[0]}");
                    Console.WriteLine($"2. {hairTypeChoice[1]}");
                    Console.WriteLine($"3. {hairTypeChoice[2]}");
                    Console.WriteLine($"4. {hairTypeChoice[3]}");
                    Console.WriteLine($"5. {hairTypeChoice[4]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].hairTypeChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].hairTypeChoice < 1 || characters[index].hairTypeChoice > hairTypeChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Now, describe the type of your body");
                    Console.WriteLine($"1. {bodyTypeChoice[0]}");
                    Console.WriteLine($"2. {bodyTypeChoice[1]}");
                    Console.WriteLine($"3. {bodyTypeChoice[2]}");
                    Console.WriteLine($"4. {bodyTypeChoice[3]}");
                    Console.WriteLine($"5. {bodyTypeChoice[4]}");
                    Console.WriteLine($"6. {bodyTypeChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].bodyTypeChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].bodyTypeChoice < 1 || characters[index].bodyTypeChoice > bodyTypeChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("May you describe your eyes for me?");
                    Console.WriteLine($"1. {eyeColorChoice[0]}");
                    Console.WriteLine($"2. {eyeColorChoice[1]}");
                    Console.WriteLine($"3. {eyeColorChoice[2]}");
                    Console.WriteLine($"4. {eyeColorChoice[3]}");
                    Console.WriteLine($"5. {eyeColorChoice[4]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].eyeColorChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].eyeColorChoice < 1 || characters[index].eyeColorChoice > eyeColorChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("May you also describe your mouth for me?");
                    Console.WriteLine($"1. {mouthTypeChoice[0]}");
                    Console.WriteLine($"2. {mouthTypeChoice[1]}");
                    Console.WriteLine($"3. {mouthTypeChoice[2]}");
                    Console.WriteLine($"4. {mouthTypeChoice[3]}");
                    Console.WriteLine($"5. {mouthTypeChoice[4]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].mouthTypeChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].mouthTypeChoice < 1 || characters[index].mouthTypeChoice > mouthTypeChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Traveller, describe your height for me");
                    Console.WriteLine($"1. {heightChoice[0]}");
                    Console.WriteLine($"2. {heightChoice[1]}");
                    Console.WriteLine($"3. {heightChoice[2]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].heightChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].heightChoice < 1 || characters[index].heightChoice > heightChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Traveller, what is your race?");
                    Console.WriteLine($"1. {raceChoice[0]}");
                    Console.WriteLine($"2. {raceChoice[1]}");
                    Console.WriteLine($"3. {raceChoice[2]}");
                    Console.WriteLine($"4. {raceChoice[3]}");
                    Console.WriteLine($"5. {raceChoice[4]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].raceChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].raceChoice < 1 || characters[index].raceChoice > raceChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Traveller, name your gender");
                    Console.WriteLine($"1. {genderChoice[0]}");
                    Console.WriteLine($"2. {genderChoice[1]}");
                    Console.WriteLine($"3. {genderChoice[2]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].genderChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].genderChoice < 1 || characters[index].genderChoice > genderChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");

                    Console.WriteLine("What is your personality?");
                    Console.WriteLine($"1. {personalityChoice[0]}");
                    Console.WriteLine($"2. {personalityChoice[1]}");
                    Console.WriteLine($"3. {personalityChoice[2]}");
                    Console.WriteLine($"4. {personalityChoice[3]}");
                    Console.WriteLine($"5. {personalityChoice[4]}");
                    Console.WriteLine($"6. {personalityChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].personalityChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].personalityChoice < 1 || characters[index].personalityChoice > personalityChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");

                    Console.WriteLine("Now, describe the color of your skin");
                    Console.WriteLine($"1. {skinChoice[0]}");
                    Console.WriteLine($"2. {skinChoice[1]}");
                    Console.WriteLine($"3. {skinChoice[2]}");
                    Console.WriteLine($"4. {skinChoice[3]}");
                    Console.WriteLine($"5. {skinChoice[4]}");
                    Console.WriteLine($"6. {skinChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].skinChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].skinChoice < 1 || characters[index].skinChoice > skinChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");

                    Console.WriteLine("Now, onto your clothes, describe what is your shirt");
                    Console.WriteLine($"1. {shirtTypeChoice[0]}");
                    Console.WriteLine($"2. {shirtTypeChoice[1]}");
                    Console.WriteLine($"3. {shirtTypeChoice[2]}");
                    Console.WriteLine($"4. {shirtTypeChoice[3]}");
                    Console.WriteLine($"5. {shirtTypeChoice[4]}");
                    Console.WriteLine($"6. {shirtTypeChoice[5]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].shirtTypeChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].shirtTypeChoice < 1 || characters[index].shirtTypeChoice > shirtTypeChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Next, describe your pants/skirt type");
                    Console.WriteLine($"1. {bottomTypeChoice[0]}");
                    Console.WriteLine($"2. {bottomTypeChoice[1]}");
                    Console.WriteLine($"3. {bottomTypeChoice[2]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].bottomTypeChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].bottomTypeChoice < 1 || characters[index].bottomTypeChoice > bottomTypeChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Next, describe your shoes");
                    Console.WriteLine($"1. {shoesChoice[0]}");
                    Console.WriteLine($"2. {shoesChoice[1]}");
                    Console.WriteLine("---------------------------------------------------");
                    characters[index].shoesChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].shoesChoice < 1 || characters[index].shoesChoice > shoesChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Next, do you wear some accessories?");
                    Console.WriteLine($"1. {accessoriesChoice[0]}");
                    Console.WriteLine($"2. {accessoriesChoice[1]}");
                    Console.WriteLine($"3. {accessoriesChoice[2]}");
                    Console.WriteLine($"4. {accessoriesChoice[3]}");
                    Console.WriteLine($"5. {accessoriesChoice[4]}");

                    Console.WriteLine("---------------------------------------------------");
                    characters[index].accessoriesChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].accessoriesChoice < 1 || characters[index].accessoriesChoice > accessoriesChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }
                    Console.WriteLine("---------------------------------------------------");


                    Console.WriteLine("Do you have some scars?");
                    Console.WriteLine($"1. {scarChoice[0]}");
                    Console.WriteLine($"2. {scarChoice[1]}");
                    Console.WriteLine($"3. {scarChoice[2]}");
                    Console.WriteLine($"4. {scarChoice[3]}");

                    Console.WriteLine("---------------------------------------------------");
                    characters[index].scarChoice = Convert.ToInt32(Console.ReadLine());
                    if (characters[index].scarChoice < 1 || characters[index].scarChoice > scarChoice.Length)
                    {
                        throw new InvalidInputException("Invalid role choice. Please enter a valid value.");
                    }

                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("These are your Base stats:");
                    Console.WriteLine("Strength:     10");
                    Console.WriteLine("Defense:      10");
                    Console.WriteLine("Luck:         10");
                    Console.WriteLine("Stealth:      10");
                    Console.WriteLine("Endurance:    10");
                    Console.WriteLine("Stamina:      10");
                    Console.WriteLine("Intelligence: 10");
                    Console.WriteLine("Agility:      10");
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("By completing the character customization process you have been given 15 stat points!");
                    Console.WriteLine("Distribute your 15 points EXACTLY among attributes");

                    try
                    {
                        Console.WriteLine("Distribute your 15 points among attributes");

                        while (true)
                        {
                            Console.WriteLine("\nDistribute remaining points among attributes (enter a value for each)");

                            for (int i = 0; i < characters[index].attributeChoice.Length; i++)
                            {
                                Console.Write($"Enter points for {characters[index].attributeName[i]}: ");
                                try
                                {
                                    characters[index].attributeChoice[i] = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid integer value.");
                                    i--;
                                }
                            }

                            int remainingPoints = characters[index].totalStatPoints - characters[index].attributeChoice.Sum();

                            if (remainingPoints == 0)
                            {
                                Console.WriteLine("\nAttribute customization complete. No remaining points.");
                                break;
                            }
                            else if (remainingPoints < 0)
                            {
                                Console.WriteLine($"\nYou have exceeded the total points by {-remainingPoints}. Please redistribute points.");
                            }
                            else
                            {
                                Console.WriteLine($"\nYou have {remainingPoints} points remaining. Please distribute all points.");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"An error occurred: {e.Message}");
                    }


                    bool validInput = false;
                    int curseChoice = 0;

                    while (!validInput)
                    {
                        Console.WriteLine("---------------------------------------------------");
                        Console.WriteLine("Are you a Cursed Child?");
                        Console.WriteLine("1. Yes");
                        Console.WriteLine("2. No");
                        Console.WriteLine("---------------------------------------------------");

                        try
                        {
                            curseChoice = Convert.ToInt32(Console.ReadLine());
                            characters[index].Status = new CharacterStatus { Cursed = (curseChoice == 1) };
                            validInput = true;
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Invalid input. Please enter a valid number.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                        finally
                        {
                            Console.WriteLine("---------------------------------------------------");
                        }
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                }
            }
        }
        public void InsertDatabase()
        {
            string[] originChoice = { "Lurra", "Eldoria", "Nithos" };
            string[] compChoice = { "Wolf", "Pixiemander", "Python" };
            string[] roleChoice = { "Knight", "Mage", "Berserker", "Healer", "Archer", "Assassin" };
            string[] abilityChoice = { "Shadow Dash", "Necromancy", "Invincibility", "Camouflage" };
            string[] faceShapeChoice = { "Round", "Oval", "Diamond", "Heart", "Rectangular", "Square" };
            string[] hairLengthChoice = { "Long", "Shoulder-Length", "Bobbed", "Short", "Buzzed", "Bald" };
            string[] hairColorChoice = { "Black", "Brown", "Blonde", " Red", "Ginger", "Auburn", "White", "Gray" };
            string[] hairTypeChoice = { "Straight", "Wavy", "Curly", "Coily", "Locked" };
            string[] bodyTypeChoice = { "Lean", "Muscular", "Average", "Slender", "Stout", "Curvaceous" };
            string[] eyeColorChoice = { "Brown", "Black", "Blue", "Hazel", "Gold" };
            string[] mouthTypeChoice = { "Natural", "Thin", "Round", "Wide", "Heart-Shaped" };
            string[] heightChoice = { "Short", "Average", "Tall" };
            string[] raceChoice = { "Human", "Elf", "Orc", "Dwarf", "Melusine" };
            string[] genderChoice = { "Male", "Female", "Non-Binary" };
            string[] personalityChoice = { "Timid", "Calm", "Expressive", "Aggressive", "Cheerful", "Stoic" };
            string[] skinChoice = { "Pale", "Light", "Tan", "Dark Brown", "Warm Brown", "Mahogany" };
            string[] shirtTypeChoice = { "Tunic", "Robe", "Cloak", "Gown", "Smock", "Surcot" };
            string[] bottomTypeChoice = { "Braisers", "Trousers", "Skirt" };
            string[] shoesChoice = { "Patten", "Leather Boots" };
            string[] accessoriesChoice = { "Bandage", "Necklace", "Scarf", "Hijab", "Ring" };
            string[] scarChoice = { "Scar - Eye", "Scar - Lips", "Scar - Abdomen", "None" };



            using (SqlConnection Connected = new SqlConnection(databaseNamin))
            {
                Connected.Open();


                string insertQuery = "INSERT INTO dbo.CharacterInfo (Name, Origin, Companion, Role, SpecialAbility, FaceShape, HairLength, HairColor, HairType, BodyType, EyeColor, MouthType, Height, Race, Gender, Personality, Skin, ShirtType, BottomType, Shoes, Accessories, Scar" +
                    ", Strength, Defense, Luck, Stealth, Endurance, Stamina, Intelligence, Agility, Curse) " +
                    "VALUES(@Name, @Origin, @Companion, @Role, @Ability, @FaceShape, @HairLength, @HairColor, @HairType, @BodyType, @EyeColor, @Mouth, @Height, @Race, @Gender" +
                    ", @personality, @Skin, @Shirt, @Bottom, @Shoes, @Accessories, @Scar, @Strength, @Defense, @Luck, @Stealth, @Endurance, @Stamina" +
                    ", @Intelligence, @Agility, @Curse)";

                using (SqlCommand insertData = new SqlCommand(insertQuery, Connected))
                {
                    insertData.Parameters.AddWithValue("@Name", Name);
                    insertData.Parameters.AddWithValue("@Origin", originChoice[Origin - 1]);
                    insertData.Parameters.AddWithValue("@Companion", compChoice[Companion - 1]);
                    insertData.Parameters.AddWithValue("@Role", roleChoice[Role - 1]);
                    insertData.Parameters.AddWithValue("@Ability", abilityChoice[Ability - 1]);
                    insertData.Parameters.AddWithValue("@FaceShape", faceShapeChoice[FaceShape - 1]);
                    insertData.Parameters.AddWithValue("@HairLength", hairLengthChoice[HairLength - 1]);
                    insertData.Parameters.AddWithValue("@HairColor", hairColorChoice[HairColor - 1]);
                    insertData.Parameters.AddWithValue("@HairType", hairTypeChoice[HairType - 1]);
                    insertData.Parameters.AddWithValue("@BodyType", bodyTypeChoice[BodyType - 1]);
                    insertData.Parameters.AddWithValue("@EyeColor", eyeColorChoice[EyeColor - 1]);
                    insertData.Parameters.AddWithValue("@Mouth", mouthTypeChoice[MouthType - 1]);
                    insertData.Parameters.AddWithValue("@Height", heightChoice[Height - 1]);
                    insertData.Parameters.AddWithValue("@Race", raceChoice[Race - 1]);
                    insertData.Parameters.AddWithValue("@Gender", genderChoice[Gender - 1]);
                    insertData.Parameters.AddWithValue("@personality", personalityChoice[Personality - 1]);
                    insertData.Parameters.AddWithValue("@Skin", skinChoice[Skin - 1]);
                    insertData.Parameters.AddWithValue("@Shirt", shirtTypeChoice[Shirt - 1]);
                    insertData.Parameters.AddWithValue("@Bottom", bottomTypeChoice[Bottom - 1]);
                    insertData.Parameters.AddWithValue("@Shoes", shoesChoice[Shoes - 1]);
                    insertData.Parameters.AddWithValue("@Accessories", accessoriesChoice[Accessories - 1]);
                    insertData.Parameters.AddWithValue("@Scar", scarChoice[Scar - 1]);
                    insertData.Parameters.AddWithValue("@Strength", attributeChoice[0] + defaultStats);
                    insertData.Parameters.AddWithValue("@Defense", attributeChoice[1] + defaultStats);
                    insertData.Parameters.AddWithValue("@Luck", attributeChoice[2] + defaultStats);
                    insertData.Parameters.AddWithValue("@Stealth", attributeChoice[3] + defaultStats);
                    insertData.Parameters.AddWithValue("@Endurance", attributeChoice[4] + defaultStats);
                    insertData.Parameters.AddWithValue("@Stamina", attributeChoice[5] + defaultStats);
                    insertData.Parameters.AddWithValue("@Intelligence", attributeChoice[6] + defaultStats);
                    insertData.Parameters.AddWithValue("@Agility", attributeChoice[7] + defaultStats);
                    insertData.Parameters.AddWithValue("@Curse", Status.Cursed);


                    insertData.ExecuteNonQuery();
                    Console.WriteLine("Data Stored!");
                    Console.WriteLine("---------------------------------------------------");
                }
            }
        }
        public void ShowDatabase()
        {
            using (SqlConnection Connected = new SqlConnection(databaseNamin))
            {
                Connected.Open();


                string selectQuery = "SELECT * FROM dbo.CharacterInfo";

                Console.WriteLine("Executing Query: " + selectQuery);

                using (SqlCommand selectData = new SqlCommand(selectQuery, Connected))
                {
                    using (SqlDataReader reader = selectData.ExecuteReader())
                    {
                        Console.WriteLine("Showing database for Character...");
                        Console.WriteLine("---------------------------------------------------");

                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Character_id"]} \nName: {reader["Name"]} \nOrigin: {reader["Origin"]} \nCompanion: {reader["Companion"]} \nRole: {reader["Role"]} \nSpecial Ability: {reader["SpecialAbility"]}" +
                            $"\nFace Shape: {reader["FaceShape"]} \nHair Length: {reader["HairLength"]} \nHair Color: {reader["HairColor"]} \nHair Type: {reader["HairType"]} \nBody Type: {reader["BodyType"]} \nEye Color: {reader["EyeColor"]}" +
                            $"\nMouth: {reader["MouthType"]} \nHeight: {reader["Height"]} \nRace: {reader["Race"]} \nGender: {reader["Gender"]} \nPersonality: {reader["Personality"]}, \nSkin: {reader["Skin"]} \nShirt: {reader["ShirtType"]}" +
                            $"\nBottom: {reader["BottomType"]} \nShoes: {reader["Shoes"]} \nAccessories: {reader["Accessories"]} \nScar: {reader["Scar"]} \nStrength: {reader["Strength"]} \nDefense: {reader["Defense"]} \nLuck: {reader["Luck"]} \nStealth: {reader["Stealth"]}" +
                            $"\nEndurance: {reader["Endurance"]} \nStamina: {reader["Stamina"]} \nIntelligence: {reader["Intelligence"]} \nAgility: {reader["Agility"]} \nCurse: {reader["Curse"]}");
                            Console.WriteLine("---------------------------------------------------");
                        }
                    }
                }
            }
        }
        public void DeleteCharacter(int Character_id)
        {
            using (SqlConnection connection = new SqlConnection(databaseNamin))
            {
                connection.Open();

                string deleteQuery = "DELETE FROM dbo.CharacterInfo WHERE Character_id = @Character_id";

                using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@Character_id", Character_id);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Character with ID {Character_id} deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"No character found with ID {Character_id}.");
                    }
                }
            }
        }

        public void SetCharacterInfo(CharacterMenu[] characters, int index, string customize)
        {
            Console.WriteLine(customize);
            Console.WriteLine("---------------------------------------------------");
        }
        public override void SetCharacterInfo()
        {

            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("GoodLuck On your Journey Traveller!");
        }

        public virtual void DisplayInfo()
        {
            string[] originChoice = { "Lurra", "Eldoria", "Nithos" };
            string[] compChoice = { "Wolf", "Pixiemander", "Python" };
            string[] roleChoice = { "Knight", "Mage", "Berserker", "Healer", "Archer", "Assassin" };
            string[] abilityChoice = { "Shadow Dash", "Necromancy", "Invincibility", "Camouflage" };
            string[] faceShapeChoice = { "Round", "Oval", "Diamond", "Heart", "Rectangular", "Square" };
            string[] hairLengthChoice = { "Long", "Shoulder-Length", "Bobbed", "Short", "Buzzed", "Bald" };
            string[] hairColorChoice = { "Black", "Brown", "Blonde", " Red", "Ginger", "Auburn", "White", "Gray" };
            string[] hairTypeChoice = { "Straight", "Wavy", "Curly", "Coily", "Locked" };
            string[] bodyTypeChoice = { "Lean", "Muscular", "Average", "Slender", "Stout", "Curvaceous" };
            string[] eyeColorChoice = { "Brown", "Black", "Blue", "Hazel", "Gold" };
            string[] mouthTypeChoice = { "Natural", "Thin", "Round", "Wide", "Heart-Shaped" };
            string[] heightChoice = { "Short", "Average", "Tall" };
            string[] raceChoice = { "Human", "Elf", "Orc", "Dwarf", "Melusine" };
            string[] genderChoice = { "Male", "Female", "Non-Binary" };
            string[] personalityChoice = { "Timid", "Calm", "Expressive", "Aggressive", "Cheerful", "Stoic" };
            string[] skinChoice = { "Pale", "Light", "Tan", "Dark Brown", "Warm Brown", "Mahogany" };
            string[] shirtTypeChoice = { "Tunic", "Robe", "Cloak", "Gown", "Smock", "Surcot" };
            string[] bottomTypeChoice = { "Braisers", "Trousers", "Skirt" };
            string[] shoesChoice = { "Patten", "Leather Boots" };
            string[] accessoriesChoice = { "Bandage", "Necklace", "Scarf", "Hijab", "Ring" };
            string[] scarChoice = { "Scar - Eye", "Scar - Lips", "Scar - Abdomen", "None" };




            Console.WriteLine($"Character Information:");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Origin: {originChoice[Origin - 1]}");
            Console.WriteLine($"Companion: {compChoice[Companion - 1]}");
            Console.WriteLine($"Role: {roleChoice[Role - 1]}");
            Console.WriteLine($"Special Ability: {abilityChoice[Ability - 1]}");
            Console.WriteLine($"Face Shape: {faceShapeChoice[FaceShape - 1]}");
            Console.WriteLine($"Hair Length: {hairLengthChoice[HairLength - 1]}");
            Console.WriteLine($"Hair Color: {hairColorChoice[HairColor - 1]}");
            Console.WriteLine($"Hair Type: {hairTypeChoice[HairType - 1]}");
            Console.WriteLine($"Body Type: {bodyTypeChoice[BodyType - 1]}");
            Console.WriteLine($"Eye Color: {eyeColorChoice[EyeColor - 1]}");
            Console.WriteLine($"Mouth Type: {mouthTypeChoice[MouthType - 1]}");
            Console.WriteLine($"Height: {heightChoice[Height - 1]}");
            Console.WriteLine($"Race: {raceChoice[Race - 1]}");
            Console.WriteLine($"Gender: {genderChoice[Gender - 1]}");
            Console.WriteLine($"Personality: {personalityChoice[Personality - 1]}");
            Console.WriteLine($"Skin: {skinChoice[Skin - 1]}");
            Console.WriteLine($"Shirt Type: {shirtTypeChoice[Shirt - 1]}");
            Console.WriteLine($"Bottom Type: {bottomTypeChoice[Bottom - 1]}");
            Console.WriteLine($"Shoes: {shoesChoice[Shoes - 1]}");
            Console.WriteLine($"Accessories: {accessoriesChoice[Accessories - 1]}");
            Console.WriteLine($"Scar: {scarChoice[Scar - 1]}");
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Attribute Distribution:");
            for (int i = 0; i < attributeName.Length; i++)
            {
                Console.WriteLine($"{attributeName[i]}: {attributeChoice[i] + defaultStats}");
            }
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Cursed: {Status.Cursed}");
            if (Status.Cursed == true)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Cursed Story Line");
                Console.WriteLine("You are a cursed individual, your existence bound to a malevolent force that has cast its curse upon you. You must seek a cursed relic of ancient power hidden within the darkest and most dangerous place in the realm. Your destiny is entwined to with breaking this maleficent artifact, you must embark on a journey filled with uncertainty. Should you fail to find this cursed relic, an ominous fate awaits you each night. A relentless barrage of attacks by monstrous creatures, drawn to the cursed energy that radiates off of you. Their goal is to torment your being each night, their haunting howls and screeches echoing through the darkness. The urgency to find the cursed artifact intensifies every sunset, as the impending doom and danger looms ever larger.");
            }
            else if (Status.Cursed == false)
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine("Normal Story Line");
                Console.WriteLine("You are a normal being in your realm, whispers of a curse that exists haunts the realm. Each night that the sun sets, aterrifying and monstrous presences appear, seeming to search for certain cursed individuals. As dusk fell, townsfolks would hide in their home in order to avoid the danger that looms. Unknown to you and the citizens, cursed individuals silently live within their village, trying to blend in with the crowd and also, seek refuge from the monsters. Fear etches through your village, the once happy and cheerful community now turned into uncertain and wary individuals. Each night, the air is filled with tension, normal citizens trying to avoid cursed individuals but also trying to hide and survive the monstrous creatures that looms. You, a normal citizen must find these cursed individuals and must get them away from your community, and also try to survive each night that comes.");
            }
        }
    }
    public class PlayerCharacter : CharacterMenu
    {

        public PlayerCharacter(string playerName, int originChoice, int compChoice, int roleChoice, int abilityChoice, int faceShapeChoice, int hairLengthChoice, int hairColorChoice,
            int hairTypeChoice, int bodyTypeChoice, int eyeColorChoice, int mouthTypeChoice, int heightChoice, int raceChoice, int genderChoice, int personalityChoice, int skinChoice,
            int shirtTypeChoice, int bottomTypeChoice, int shoesChoice, int accessoriesChoice, int scarChoice) : base(playerName, originChoice, compChoice, roleChoice, faceShapeChoice, hairLengthChoice, hairColorChoice,
             hairTypeChoice, bodyTypeChoice, eyeColorChoice, mouthTypeChoice, heightChoice, raceChoice, genderChoice, personalityChoice, skinChoice,
             shirtTypeChoice, bottomTypeChoice, shoesChoice, accessoriesChoice, scarChoice)
        {
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
        }
    }
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message) { }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            CharacterMenu[] characters = new CharacterMenu[1];
            characters[0] = new CharacterMenu("", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            while (true)
            {
                try
                {

                    Console.WriteLine("Welcome Traveller, choose in the Menu: ");
                    Console.WriteLine("1.New Game");
                    Console.WriteLine("2.Load Game");
                    Console.WriteLine("3.Exit");
                    Console.WriteLine("Enter your choice (1-3): ");
                    int nlGame = Convert.ToInt32(Console.ReadLine());
                    if (nlGame == 1)
                    {
                        Console.WriteLine("1.Story Lore!");
                        Console.WriteLine("2.Create Character");
                        int choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            Console.WriteLine("-------Story Line-------");
                            Console.WriteLine("The game takes place in the world of Hairiyah, thriving countries reside in the world of Hairiyah, where each factions are caught in a power struggle and a curse. There are 3 nations that that reside in the realm of Hairiyah, Lurra, Eldoria, and Nithos.");
                            Console.WriteLine("Lurra, a realm filled with flora and fauna, where magic and nature are in complete harmony with one another. The inhabitants of Lurra, known as Lurrans, are attuned to the magical powers they have. Lurrans are skilled in ancient arts, blending their knowledge with magical prowess. Their settlements, intertwined with living vines filled with magic. In Lurra, every rustle of leaves and ripple of water resonates with the ancient magic that courses through the land. ");
                            Console.WriteLine("Eldoria, full of kingdoms where nobles and citizens are brimming with might and honor. The inhabitants of Eldoria are called Eldorians. Eldorians are proud individuals who boast the achivements of their nation. They boast the might and glory that their ancestors have achieved. In Eldoria, citizens are also known for their respect during battles, known for always showing respect to the opponents that they fight.");
                            Console.WriteLine("Nithos, the dark isles, a place of chaos where power hungry individuals reside. Each individual who lives here has a reputation to preserve. The inhabitants of Nithos are known as Nithacans. Nithacans value power and reputation above all else. They do not like those who are weak and those who do not have high reputations to show.");
                            Console.WriteLine("Do you want to proceed to character creation? (1 for Yes, 2 for No)");
                            int proc = Convert.ToInt32(Console.ReadLine());
                            if (proc == 1)
                            {
                                characters[0].SetCharacterInfo(characters, 0);
                                characters[0].SetCharacterInfo(characters, 0, "Character Created Successfully");
                                characters[0].InsertDatabase();


                                characters[0].DisplayInfo();
                                characters[0].SetCharacterInfo();
                                Console.WriteLine("---------------------------------------------------");
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                        }
                        else if (choice == 2)
                        {

                            characters[0].SetCharacterInfo(characters, 0);
                            characters[0].SetCharacterInfo(characters, 0, "Character Created Successfully");
                            characters[0].InsertDatabase();


                            characters[0].DisplayInfo();
                            characters[0].SetCharacterInfo();
                            Console.WriteLine("---------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input!");
                        }
                    }
                    else if (nlGame == 2)
                    {
                        Console.WriteLine("1.Show Characters");
                        Console.WriteLine("2.Delete Characters");
                        int decs = Convert.ToInt32(Console.ReadLine());
                        if (decs == 1)
                        {
                            characters[0].ShowDatabase();
                        }
                        else if (decs == 2)
                        {
                            Console.WriteLine("Enter the character id you want to delete: ");
                            int characterIdToDelete = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Are you sure to delete this character? (1 = Yes, 2 = No)");
                            int confirm = Convert.ToInt32(Console.ReadLine());
                            if (confirm == 1)
                            {
                                characters[0].DeleteCharacter(characterIdToDelete);
                            }
                            else if (confirm == 2)
                            {
                                Environment.Exit(0);
                            }

                        }
                        else
                        {
                            Console.WriteLine("Error!");
                        }
                    }
                    else if (nlGame == 3)
                    {
                        Environment.Exit(0);
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
                catch (InvalidInputException ex)
                {
                    Console.WriteLine($"Invalid input: {ex.Message}");
                }
            }
        }
    }
}
