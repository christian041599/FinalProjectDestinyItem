using System.Globalization;
using System.Security.AccessControl;

namespace Destiny_Items
{
    public partial class Form1 : Form
    {

        public static Form1 instance;

        List<Character> characters = new List<Character>();

        List<Weapon> weapons = new List<Weapon>();
        List<Armor> armors = new List<Armor>();

        int currentCharacter = 0;

        public Form1()
        {
            InitializeComponent();

            instance = this;

            //Filling the list before load 

            //Hunter
            weapons.Add(new Weapon("Last Word", "Handcannon", "Exotic"));
            armors.Add(new Armor("Night Hawk", "Helment", "Exotic"));
            characters.Add(new Character("Hunter", "Solar", weapons, armors));

            //Warlock
            weapons.Add(new Weapon("Thorn", "Handcannon", "Exotic"));
            armors.Add(new Armor("Sun Dancers", "Gauntlets", "Exotic"));
            characters.Add(new Character("Warlock", "Void", weapons, armors));

            //Titan 
            weapons.Add(new Weapon("Found Verdict", "Shotgun", "Legendary"));
            armors.Add(new Armor("Helm of Saint-14", "Helment", "Exotic"));
            characters.Add(new Character("Titan", "Void", weapons, armors));

            //Adding to the dropdown list 
            cmbCharacters.Items.Add(characters[0].Name);
            cmbCharacters.Items.Add(characters[1].Name);
            cmbCharacters.Items.Add(characters[2].Name);
            cmbCharacters.SelectedIndex = -1;

            cmbWhatArk.Items.Add("Solar");
            cmbWhatArk.Items.Add("Void");
            cmbWhatArk.Items.Add("Ark");

            cmbRaids.Items.Add("Vault of Glass");
            cmbRaids.Items.Add("Crota's End");
            cmbRaids.Items.Add("the Prison of Elders");
            cmbRaids.Items.Add("King's Fall");
            cmbRaids.Items.Add("Wraith of the Machine");
            cmbRaids.SelectedIndex = -1;

            cmbLorePick.Items.Add("Last Word");
            cmbLorePick.Items.Add("Thorn");
            cmbLorePick.Items.Add("Hawkmoon");
            cmbLorePick.SelectedIndex = -1;

            DisplayCharacterInventory();
        }
        private void DisplayCharacterInventory()
        {
            cmbDelete.Items.Clear();

            // display for all the output
            if (characters.Count > 0 && cmbCharacters.SelectedIndex >= 0)
            {
                Character currentChar = characters[cmbCharacters.SelectedIndex];
                label2.Text = $"Character's Name: {txtClass.Text}\nCharacter Class: {currentChar.Name}\nArkType: {currentChar.Arktype}\n\nWeapons:\n";
                foreach (Weapon weapon in currentChar.Weapon)
                {
                    label2.Text += $"{weapon.Name} (Type: {weapon.Type}, Rarity: {weapon.Rarity})\n";
                }

                label2.Text += "\nArmor:\n";
                foreach (Armor armor in currentChar.Armor)
                {
                    label2.Text += $"{armor.Name} (Type: {armor.Type}, Rarity: {armor.Rarity})\n";
                }

                cmbDelete.Items.AddRange(characters.Select(c => c.Name).ToArray());

            }
            else
            {
                label2.Text = "";
            }
        }
        private void btnWeaponAdd_Click(object sender, EventArgs e)
        {
            string characterName = txtClass.Text.Trim();
            string arkType = cmbWhatArk.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(characterName))
            {
                MessageBox.Show("Please enter a valid name for the character.");
                return;
            }
            if (string.IsNullOrEmpty(arkType))
            {
                MessageBox.Show("Please select a valid Ark type for the character.");
                return;
            }
            if (weapons.Count == 0 || armors.Count == 0)
            {
                MessageBox.Show("Please add at least one weapon and one armor piece to the character's inventory.");
                return;
            }


            if (characters.Count > currentCharacter)
            {
                // create new character object
                characters.Add(new Character(txtClass.Text, cmbWhatArk.SelectedIndex.ToString(), weapons, armors));
                characters[currentCharacter].Weapon.Add(new Weapon(txtWeaponName.Text, txtWeaponType.Text, txtWeaponRarity.Text));
                cmbCharacters.Items.Add(characters[currentCharacter].Name);
                DisplayCharacterInventory();

                // send to form 2
                Form2 form2 = new Form2();
                form2.CharacterInventory(characters);
            }
        }
        private void btnArmorAdd_Click(object sender, EventArgs e)
        {
            string characterName = txtClass.Text.Trim();
            string arkType = cmbWhatArk.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(characterName))
            {
                MessageBox.Show("Please enter a valid name for the character.");
                return;
            }
            if (string.IsNullOrEmpty(arkType))
            {
                MessageBox.Show("Please select a valid Ark type for the character.");
                return;
            }
            if (weapons.Count == 0 || armors.Count == 0)
            {
                MessageBox.Show("Please add at least one weapon and one armor piece to the character's inventory.");
                return;
            }

            if (characters.Count > currentCharacter)
            {
                // create new character object
                characters.Add(new Character(txtClass.Text, cmbWhatArk.SelectedIndex.ToString(), weapons, armors));
                characters[currentCharacter].Armor.Add(new Armor(txtArmorName.Text, txtArmorType.Text, txtArmorRarity.Text));
                DisplayCharacterInventory();
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cmbCharacters.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a character to update.");
                return;
            }

            if (string.IsNullOrEmpty(txtUpdatedWeapon.Text) || string.IsNullOrEmpty(txtUpdatedArmor.Text))
            {
                MessageBox.Show("Please enter the updated weapon and armor information.");
                return;
            }

            if (cmbCharacters.SelectedIndex >= 0)
            {
                Character currentChar = characters[cmbCharacters.SelectedIndex];
                currentChar.Arktype = cmbWhatArk.SelectedItem.ToString();

                // update the weapons
                currentChar.Weapon.Clear();
                currentChar.Weapon.Add(new Weapon(txtUpdatedWeapon.Text, txtWeaponType.Text, txtWeaponRarity.Text));

                // update the armors
                currentChar.Armor.Clear();
                currentChar.Armor.Add(new Armor(txtUpdatedArmor.Text, txtUpdatedArmorType.Text, txtUpdatedArmorRarity.Text));

                DisplayCharacterInventory();

                Form2 form2 = new Form2();
                form2.SetInventory(label2.Text); // pass in the updated inventory string
                form2.Show();
            }
        }

        //private bool IsValidRarity(string rarity)
        //{
        //    return rarity.Equals("Exotic", StringComparison.OrdinalIgnoreCase) ||
        //           rarity.Equals("Legendary", StringComparison.OrdinalIgnoreCase);
        //}

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var result = characters.Where(c =>
                    c.Name.ToLower().Contains(searchText) ||
                    c.Arktype.ToLower().Contains(searchText) ||
                    c.Weapon.Any(w => w.Name.ToLower().Contains(searchText)) ||
                    c.Armor.Any(a => a.Name.ToLower().Contains(searchText)))
                    .ToList();

                if (result.Any())
                {
                    // Update the character list to show only the search results
                    cmbCharacters.Items.Clear();
                    foreach (var character in result)
                    {
                        cmbCharacters.Items.Add(character.Name);
                    }
                    cmbCharacters.SelectedIndex = 0; // select the first search result

                    DisplayCharacterInventory();

                    // Display the search results in the label
                    string searchResultText = "Search results:\n";
                    foreach (var character in result)
                    {
                        searchResultText += $"Name: {character.Name}\n";
                        searchResultText += $"Weapon: {string.Join(", ", character.Weapon.Select(w => w.Name))}\n";
                    }
                    lblSearchResults.Text = searchResultText;
                }
            }
            else
            {
                // If the search text is empty, show all characters
                cmbCharacters.Items.Clear();
                foreach (var character in characters)
                {
                    cmbCharacters.Items.Add(character.Name);
                }
                cmbCharacters.SelectedIndex = 0; // select the first character

                DisplayCharacterInventory();
            }
        }
        private void cmbCharacters_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCharacter = cmbCharacters.SelectedIndex;
            DisplayCharacterInventory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string selectedItem = cmbDelete.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedItem))
            {
                Character selectedCharacter = characters.FirstOrDefault(c => c.Name == selectedItem);
                if (selectedCharacter != null)
                {
                    characters.Remove(selectedCharacter);
                    cmbCharacters.Items.Remove(selectedCharacter);
                    cmbDelete.Items.Remove(selectedItem);
                    MessageBox.Show("Item successfully deleted!");
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show("Selected item not found in character list.");
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete.");
            }
        }

        private void ClearInputs()
        {
            txtClass.Clear();
            cmbWhatArk.SelectedIndex = -1;
            cmbCharacters.SelectedIndex = -1;
            txtWeaponName.Clear();
            txtWeaponType.Clear();
            txtWeaponRarity.Clear();
            txtArmorName.Clear();
            txtArmorType.Clear();
            txtArmorRarity1.Clear();
        }

        private void btnViewForm2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            DisplayCharacterInventory();
            form.SetInventory(label2.Text);
            form.Show();
        }

        private void cmbRaids_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItems = cmbRaids.SelectedItem.ToString();

            if (selectedItems == "Vault of Glass")
            {
                lblRecommendation.Text = $"We recommend using... \n\nFor the Waking Ruins section: Fatebringer, Sword Breaker, Gjallarhorn, Ice Breaker." +
                    $"\n\nFor the Templar’s Well – Conflux Phase section: Fatebringer, Hawkmoon, Swordbreaker, Found Verdict, Machine Gun with Void Damage" +
                    $"\n\nFor the Oracle & Templar Phase section: Vision of Confluence, Atheon’s Epilogue, void shotgun, void fusion rifle, Ice Breaker" +
                    $"\n\nFor the Gatekeeper  section: Black Hammer, Ice Breaker, Gjallarhorn" +
                    $"\n\nFor Atheon  section: Atheon’s Epilogue, Ice Breaker, Black Hammer, Gjallarhorn, or any legendary/exotic machine gun with good range & stability";
            }
            else if (selectedItems == "Crota's End")
            {
                lblRecommendation.Text = $"We recommend using... \n\nFor The Abyss section: Fatebringer, MIDA Multitool, Icebreaker, Bad Juju." +
                    $"\n\nFor The Bridge section: Hunger of Crota, Thunderlord, Obsidian Mind" +
                    $"\n\nFor The Thrallway section: MIDA Multitool, Sword Breaker, Gjallarhorn" +
                    $"\n\nFor The Ir Yut section: Dragon's Breath, Mask of the Third Man, Abyss Defiant" +
                    $"\n\nFor Crota: Red Death, Gjallarhorn, Truth";
            }
            else if (selectedItems == "the Prison of Elders")
            {
                lblRecommendation.Text = $"We recommend using... \n\nFor Arena: Praedyth’s Revenge, Icebreaker, Gjallarhorn, Word of Crota, Oversoul Edict, Vision of Confluence";
            }
            else if (selectedItems == "King's Fall")
            {
                lblRecommendation.Text = $"We recommend using... \n\nFor Totems section: Vision of Confluence, MIDA Multitool,  Zhalo Supercell, Sword Breaker, Ace of Spades" +
                    $"\n\nFor Warpriest section: Black Spindle, Icebreaker, Thunderlord" +
                    $"\n\nFor Golgoroth section: Quillim's Terminus, Black Spindle, Icebreaker, Thunderlord" +
                    $"\n\nFor Daughters section: Touch of Malice, Quillim's Terminus, Black Spindle, Icebreaker, Thunderlord, Hereafter " +
                    $"\n\nFor Oryx section: Touch of Malice, Quillim's Terminus, Black Spindle, Icebreaker, Thunderlord, Hereafter ";
            }

            Form3 form3 = new Form3();
            form3.SetInventory(lblRecommendation.Text);
            form3.Show();
        }

        private void cmbLorePick_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItems = cmbLorePick.SelectedItem.ToString();

            if (selectedItems == "Last Word")
            {
                lblLoreDisplay.Text = "\"Yours, until the last flame dies and all words have been spoken.\" —Shin Malphur to you, as you journey forth into the unknown\r\n\r\nKnew this day would come, and with it, one last lesson…\r\n\r\nThere's an end to all things, kid. Good and bad.\r\n\r\nSure, the best times seem small, and the bad tend to linger, but the only permanent is eternity.\r\n\r\nI'm off to meet it.\r\n\r\nIf you're lucky, someday you will too.\r\n\r\nFor now, though, you've got road yet traveled and lives yet lived.\r\n\r\nI know you got hate in you. Most do. Trick is to use it, 'stead of it usin' you.\r\n\r\nBut you know this—vengeance is a motivator, not the motive.\r\n\r\nMeant to—hoped to—say these words to you one last time in person, but writin' 'em down seems the safe bet with the prey we're trackin'.\r\n\r\nWorst part about bein' a good guy? As much as you may want it, you can't always win. But that truth don't bother me. We do the right thing, 'cause the right thing needs doin'. So, when another does harm—casts their shadow upon you or your kin—you go 'head and hunt for the justice needed to answer any sins inflicted.\r\n\r\nDon't hunt 'em 'cause you been wronged.\r\n\r\nHunt 'em 'cause what they did was wrong.\r\n\r\nThere's a world of difference there, kid.\r\n\r\nOne makes you selfish. The other makes you a hero.\r\n\r\nAnd I see a hero in you.\r\n\r\nAnd with this last good lesson, a gift. I know it feels right in your hand—its weight easy, its trigger smooth. Use it as you will—I know you'll use it right.\r\n\r\nIt's yours now, 'til the last flame dies and all words've been spoken.\r\n\r\n'Til that time.\r\n\r\nSafe journeys. Straight aim. And good huntin'.\r\n\r\nJ.\r\n\r\n—A letter to Shin Malphur from his third father, Jaren Ward, written before Ward's ill-fated showdown with the infamous Dredgen Yor in the wooded hollow beyond Beggars' Gulch";
                pbUno.Image = Properties.Resources.weapon_tn_the_last_word;
            }
            else if (selectedItems == "Thorn")
            {
                lblLoreDisplay.Text = "\"To rend one's enemies is to see them not as equals, but objects—hollow of spirit and meaning.\" —13th Understanding, 7th Book of Sorrow\r\n\r\n\"The Weapons of Sorrow are not the endgame, but a road map. Each evolution, every advance in the delivery of pain and the mastery of destruction feeds the Hive's hateful weapons research. They will map every scream, harness every aggression, until they understand every method by which to ravage the hearts, minds, and flesh of man. And in doing so, they will turn us against ourselves—feeding our lust, our greed, our fear, until we become a threat unto ourselves like none we could imagine. So, wield these, angry reaper. Strive to know the darkness in your own heart. Walk in the shadows of fallen heroes. And know that you are an enemy of hope.\"\r\n\r\n—a warning";
                pbUno.Image = Properties.Resources.weapon_tn_thorn;
            }
            else if (selectedItems == "Hawkmoon")
            {
                lblLoreDisplay.Text = "Stalk thy prey and let loose thy talons upon the Darkness.\r\n\r\nWhat is this feeling?\r\n\r\nI did not ask for it. I do not understand it. I do not want it.\r\n\r\nThe Crow is so carefree in his ignorance. The bonfire's glow lights up his pale features and I am drawn to the hope in his gold eyes. Where is the despairing child I anticipated?\r\n\r\nHe drinks from an open bottle of wine against the recommendation of his Ghost. The Guardian encourages him and they are laughing. This celebration is maddening; neither have reason to be so jubilant. Their world is ending and they thrash like dying creatures in the final light of collapsing stars. They do not seem to acknowledge the futility of their existence, the impermanence of it in the face of cosmic annihilation.\r\n\r\nNow the Guardian is drinking, standing close to the fire. Their Ghost, too, encourages them not to partake. They poison themselves for the enjoyment of it.\r\n\r\nI am reminded of my sisters. Of moments spent by lapping shores, gazing up at infinite stars full of possibilities and wonder. I am left yearning.\r\n\r\nWhat is this feeling?\r\n\r\nI do not understand it. I do not want it.\r\n\r\nThey are celebrating their victory over the Taken. The Crow is making a gun shape with his hand, swinging the nearly empty bottle of wine around in the other like a Sword. The Guardian looks pensive, sitting on a rock by the fire, contemplating the secret they are keeping. The Crow notices, but tries not to show it. He wants the Guardian's spirits to be lifted. He wants to be supportive, so that they may share in their triumphs together.\r\n\r\nAs equals.\r\n\r\nI am reminded of my home. I am reminded of the warmth of the sun and the embrace of my family. I am reminded of my father's face. I am reminded of everyone I betrayed. All the blood spilled in the name of immortality. The warmth of the sun burns me with its memory.\r\n\r\nWhat is this feeling?\r\n\r\nI do not want it.\r\n\r\nThe fire has nearly died. The Crow fell over and cannot stand, though he insists he is fine. The Guardian is turning the embers with the tip of their Sword. The Ghosts are talking to one another in quiet conspiracy. The celebration has ended, but I can sense their emotions are mixed: complex and myriad things, when a simple, singular focus would suffice.\r\n\r\nThere is a growing kinship here. Against better judgment.\r\n\r\nWhat is this feeling?";
                pbUno.Image = Properties.Resources.weapon_tn_hawkmoon;
            }

            Form4 form4 = new Form4();
            form4.SetLore(lblLoreDisplay.Text, pbUno.Image);
            form4.Show();
        }
    }
}
