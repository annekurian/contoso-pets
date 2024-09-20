using System.Globalization;
CultureInfo.CurrentCulture = new CultureInfo("en-us");
// the ourAnimals array will store the following: 
string animalSpecies = "";
string animalID = "";
string animalAge = "";
string animalPhysicalDescription = "";
string animalPersonalityDescription = "";
string animalNickname = "";
string suggestedDonation = "";

// variables that support data entry
int maxPets = 8;
string? readResult;
string menuSelection = "";
decimal decimalDonation = 0.00m;

// array used to store runtime data, there is no persisted data
string[,] ourAnimals = new string[maxPets, 7];

// TODO: Convert the if-elseif-else construct to a switch statement

// create some initial ourAnimals array entries
for (int i = 0; i < maxPets; i++)
{
    switch (i)
    {
        case 0:
            animalSpecies = "dog";
            animalID = "d1";
            animalAge = "2";
            animalPhysicalDescription = "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.";
            animalPersonalityDescription = "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses.";
            animalNickname = "lola";
            suggestedDonation = "85.00";
            break;

        case 1:
            animalSpecies = "dog";
            animalID = "d2";
            animalAge = "9";
            animalPhysicalDescription = "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.";
            animalPersonalityDescription = "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs.";
            animalNickname = "loki";
            suggestedDonation = "49.99";
            break;

        case 2:
            animalSpecies = "cat";
            animalID = "c3";
            animalAge = "1";
            animalPhysicalDescription = "small white female weighing about 8 pounds. litter box trained.";
            animalPersonalityDescription = "friendly";
            animalNickname = "Puss";
            suggestedDonation = "40.00";
            break;

        case 3:
            animalSpecies = "cat";
            animalID = "c4";
            animalAge = "?";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

        default:
            animalSpecies = "";
            animalID = "";
            animalAge = "";
            animalPhysicalDescription = "";
            animalPersonalityDescription = "";
            animalNickname = "";
            suggestedDonation = "";
            break;

    }

    ourAnimals[i, 0] = "ID #: " + animalID;
    ourAnimals[i, 1] = "Species: " + animalSpecies;
    ourAnimals[i, 2] = "Age: " + animalAge;
    ourAnimals[i, 3] = "Nickname: " + animalNickname;
    ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
    ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
    ourAnimals[i, 6] = "Suggested Donation: " + suggestedDonation;
    if (!decimal.TryParse(suggestedDonation, out decimalDonation))
    {
        decimalDonation = 45.00m;
    }
    ourAnimals[i, 6] = $"Suggested Donation: {decimalDonation:C2}";
}

// display the top-level menu options

Console.Clear();

do
{
    Console.WriteLine("Welcome to the Contoso PetFriends app. Your main menu options are:");
    Console.WriteLine(" 1. List all of our current pet information");
    Console.WriteLine(" 2. Add a new animal friend to the ourAnimals array");
    Console.WriteLine(" 3. Ensure animal ages and physical descriptions are complete");
    Console.WriteLine(" 4. Ensure animal nicknames and personality descriptions are complete");
    Console.WriteLine(" 5. Edit an animal’s age");
    Console.WriteLine(" 6. Edit an animal’s personality description");
    Console.WriteLine(" 7. Display all cats with a specified characteristic");
    Console.WriteLine(" 8. Display all dogs with a specified characteristic");
    Console.WriteLine();
    Console.WriteLine("Enter your selection number (or type Exit to exit the program)");
    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }
    Console.WriteLine($"You selected menu option {menuSelection}.");

    switch (menuSelection)
    {
        case "1":
            // List all of our current pet information
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    Console.WriteLine();
                    for (int j = 0; j < 7; j++)
                    {
                        Console.WriteLine(ourAnimals[i, j]);
                    }
                }
            }
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        case "2":
            // Add new animal friend to ourAnimals array
            string anotherPet = "y";
            int petCount = 0;
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 0] != "ID #: ")
                {
                    petCount += 1;
                }
            }
            if (petCount < maxPets)
            {
                Console.WriteLine($"We currently have {petCount} pets that need homes. We can manage {(maxPets - petCount)} more.");
            }
            while (anotherPet == "y" && petCount < maxPets)
            {
                bool validEntry = false;
                do
                {
                    Console.WriteLine("\n\rEnter 'dog' or 'cat' to begin a new entry");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalSpecies = readResult.ToLower();
                        validEntry = (animalSpecies != "dog" && animalSpecies != "cat") ? false : true;
                        animalID = animalSpecies.Substring(0, 1) + (petCount + 1).ToString();
                    }
                } while (validEntry == false);
                // get the pet's age. can be ? at initial entry.
                do
                {
                    int petAge;
                    Console.WriteLine("Enter the pet's age or enter ? if unknown");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalAge = readResult;
                        if (animalAge != "?")
                        {
                            validEntry = int.TryParse(animalAge, out petAge);
                        }
                        else
                        {
                            validEntry = true;
                        }
                    }
                } while (validEntry == false);

                // get a description of the pet's physical appearance/condition - animalPhysicalDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a physical description of the pet (size, color, gender, weight, housebroken)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPhysicalDescription = readResult.ToLower();
                        if (animalPhysicalDescription == "")
                        {
                            animalPhysicalDescription = "tbd";
                        }
                    }
                } while (animalPhysicalDescription == "");

                // get a description of the pet's personality - animalPersonalityDescription can be blank.
                do
                {
                    Console.WriteLine("Enter a description of the pet's personality (likes or dislikes, tricks, energy level)");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalPersonalityDescription = readResult.ToLower();
                        if (animalPersonalityDescription == "")
                        {
                            animalPersonalityDescription = "tbd";
                        }
                    }
                } while (animalPersonalityDescription == "");

                // get the pet's nickname. animalNickname can be blank.
                do
                {
                    Console.WriteLine("Enter a nickname for the pet");
                    readResult = Console.ReadLine();
                    if (readResult != null)
                    {
                        animalNickname = readResult.ToLower();
                        if (animalNickname == "")
                        {
                            animalNickname = "tbd";
                        }
                    }
                } while (animalNickname == "");

                // store the pet information in the ourAnimals array (zero based)
                ourAnimals[petCount, 0] = "ID #: " + animalID;
                ourAnimals[petCount, 1] = "Species: " + animalSpecies;
                ourAnimals[petCount, 2] = "Age: " + animalAge;
                ourAnimals[petCount, 3] = "Nickname: " + animalNickname;
                ourAnimals[petCount, 4] = "Physical description: " + animalPhysicalDescription;
                ourAnimals[petCount, 5] = "Personality: " + animalPersonalityDescription;
                // increment petCount (the array is zero-based, so we increment the counter after adding to the array)
                petCount = petCount + 1;
                // check maxPet limit
                if (petCount < maxPets)
                {
                    // another pet?
                    Console.WriteLine("Do you want to enter info for another pet (y/n)");
                    do
                    {
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            anotherPet = readResult.ToLower();
                        }
                    } while (anotherPet != "y" && anotherPet != "n");
                }
            }
            if (petCount >= maxPets)
            {
                Console.WriteLine("We have reached our limit on the number of pets that we can manage.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }


            break;
        case "3":
            // Ensure animal ages and physical descriptions are complete
            bool ageComplete = false;
            bool descriptionComplete = false;
            for (int i = 0; i < maxPets; i++)
            {
                int petAge;
                if (ourAnimals[i, 0] == "ID #: ")
                    continue;
                if (ourAnimals[i, 2] == "Age: ?")
                {
                    do
                    {
                        Console.WriteLine($"Enter an age for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalAge = readResult;
                            if (animalAge != "?")
                                ageComplete = int.TryParse(animalAge, out petAge);
                            else
                                ageComplete = false;

                        }
                        if (ageComplete)
                        {
                            ourAnimals[i, 2] = "Age: " + animalAge.ToString();
                        }
                    } while (ageComplete == false);
                }
                Console.WriteLine(ourAnimals[i, 4]);
                if (ourAnimals[i, 4] == "Physical description: " || ourAnimals[i, 4] == "Physical description: tbd")
                {
                    do
                    {
                        Console.WriteLine($"Enter a physical description for {ourAnimals[i, 0]} (size, color, breed, gender, weight, housebroken)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPhysicalDescription = readResult;
                            if (animalPhysicalDescription != "" && animalPhysicalDescription != "tbd")
                                descriptionComplete = true;

                        }
                        if (descriptionComplete)
                        {
                            ourAnimals[i, 4] = "Physical description: " + animalPhysicalDescription;
                        }
                    } while (descriptionComplete == false);
                }
            }
            if (ageComplete == true && descriptionComplete == true)
            {
                Console.WriteLine("Age and Physical description fields are complete for all of our friends.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;

        case "4":
            // Ensure animal nicknames and personality descriptions are complete
            bool nickNameComplete = false;
            bool personalityComplete = false;
            for (int i = 0; i < maxPets; i++)
            {
                int petAge;
                if (ourAnimals[i, 0] == "ID #: ")
                    continue;
                if (ourAnimals[i, 3] == "Nickname: ")
                {
                    do
                    {
                        Console.WriteLine($"Enter a nickname for {ourAnimals[i, 0]}");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalNickname = readResult;
                            if (animalNickname != "" && animalNickname != "tbd")
                                nickNameComplete = true;
                        }
                        if (nickNameComplete)
                        {
                            ourAnimals[i, 3] = "Nickname: " + animalNickname;
                        }
                    } while (nickNameComplete == false);
                }

                if (ourAnimals[i, 5] == "Personality: " || ourAnimals[i, 4] == "Personality: tbd")
                {
                    do
                    {
                        Console.WriteLine($"Enter a personality description for {ourAnimals[i, 0]} (likes or dislikes, tricks, energy level)");
                        readResult = Console.ReadLine();
                        if (readResult != null)
                        {
                            animalPersonalityDescription = readResult;
                            if (animalPersonalityDescription != "" && animalPersonalityDescription != "tbd")
                                personalityComplete = true;

                        }
                        if (personalityComplete)
                        {
                            ourAnimals[i, 5] = "Personality: " + animalPersonalityDescription;
                        }
                    } while (personalityComplete == false);
                }
            }
            if (nickNameComplete == true && personalityComplete == true)
            {
                Console.WriteLine("Nickname and Personality description fields are complete for all of our friends.");
                Console.WriteLine("Press the Enter key to continue.");
                readResult = Console.ReadLine();
            }

            break;
        case "8":
            //Display all dogs with specified characteristic
            string dogCharacteristics = "";

            while (dogCharacteristics == "")
            {
                // #2 have user enter multiple comma separated characteristics to search for
                Console.WriteLine("Enter desired dog characteristics to search for separated by comma");
                readResult = Console.ReadLine();
                if (readResult != null)
                {
                    dogCharacteristics = readResult.ToLower().Trim();
                }
            }
            string[] searchTerms = dogCharacteristics.Split(',');
            // trim leading and trailing spaces from each search term
            for (int i = 0; i < searchTerms.Length; i++)
            {
                searchTerms[i] = searchTerms[i].Trim();
            }
            Array.Sort(searchTerms);
            string dogDescription = "";
            bool matchesAnyDog = false;
            // #4 "rotating" animation with countdown
            string[] searchingIcons = { " |", " /", "--", " \\", " *" };

            // loops through the ourAnimals array to search for matching animals
            for (int i = 0; i < maxPets; i++)
            {
                if (ourAnimals[i, 1].Contains("dog"))
                {
                    // Search combined descriptions and report results
                    dogDescription = ourAnimals[i, 4] + "\n" + ourAnimals[i, 5];
                    bool matchesCurrentDog = false;

                    foreach (string term in searchTerms)
                    {
                        // only search if there is a term to search for
                        if (term != null && term.Trim() != "")
                        {

                            for (int j = 2; j > -1; j--)
                            {
                                // #5 update "searching" message to show countdown
                                foreach (string icon in searchingIcons)
                                {
                                    Console.Write($"\rsearching our dog {ourAnimals[i, 3]} for {term.Trim()} {icon} {j.ToString()}");
                                    Thread.Sleep(100);
                                }
                                Console.Write($"\r{new String(' ', Console.BufferWidth)}");
                            }
                            // #3a iterate submitted characteristic terms and search description for each term
                            if (dogDescription.Contains(" " + term.Trim() + " "))
                            {
                                // #3b update message to reflect current search term match 
                                Console.WriteLine($"\nOur dog {ourAnimals[i, 3]} is a match for {term}!");
                                matchesCurrentDog = true;
                                matchesAnyDog = true;

                            }
                        }
                    }
                    // #3d if the current dog is match, display the dog's info
                    if (matchesCurrentDog)
                    {
                        Console.WriteLine($"\n\r{ourAnimals[i, 3]} ({ourAnimals[i, 0]})\n{dogDescription}\n");
                    }
                }
            }
            if (!matchesAnyDog)
            {
                Console.WriteLine("\nNone of our dogs are a match found for: " + dogCharacteristics);
            }
            Console.WriteLine("\nPress the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

        default:
            // Add new animal friend to ourAnimals array
            Console.WriteLine("UNDER CONSTRUCTION - please check back next month to see progress.");
            Console.WriteLine("Press the Enter key to continue.");
            readResult = Console.ReadLine();
            break;

    }
} while (menuSelection != "exit");

