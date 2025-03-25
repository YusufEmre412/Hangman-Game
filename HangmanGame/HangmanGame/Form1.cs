using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HangmanGame
{
    public partial class Form1 : Form
    {
        #region Variables

        List<string> words = new List<string>
        {
            "software",
            "program",
            "engineer",
            "computer",
            "processor",
            "developer",
            "keyboard",
            "hardware",
            "variable",
            "function",
            "framework",
            "database",
            "compiler",
            "debugging",
            "iteration",
            "algorithm",
            "interface",
            "encryption",
            "networking",
            "application"

        };
        int wrongGuesses;
        string chosenWord;
        Random random;
        char[] displayWord;
       
        #endregion
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            wrongGuesses = 0;
            random = new Random();
            chosenWord = words[random.Next(words.Count)];
            displayWord = new string('_', chosenWord.Length).ToCharArray();
            string formattedWord = string.Join(" ",displayWord);
            labelWordDisplay.Text = formattedWord;
            pictureBox1.Image = Properties.Resources._1;
            
            #region Label Dictionary

            labelDict['a'] = label1;
            labelDict['b'] = label2;
            labelDict['c'] = label3;
            labelDict['d'] = label4;
            labelDict['e'] = label5;
            labelDict['f'] = label6;
            labelDict['g'] = label7;
            labelDict['h'] = label8;
            labelDict['i'] = label9;
            labelDict['j'] = label10;
            labelDict['k'] = label11;
            labelDict['l'] = label12;
            labelDict['m'] = label13;
            labelDict['n'] = label14;
            labelDict['o'] = label15;
            labelDict['p'] = label16;
            labelDict['q'] = label17;
            labelDict['r'] = label18;
            labelDict['s'] = label19;
            labelDict['t'] = label20;
            labelDict['u'] = label21;
            labelDict['v'] = label22;
            labelDict['w'] = label23;
            labelDict['x'] = label24;
            labelDict['y'] = label25;
            labelDict['z'] = label26;

            #endregion
        }
        private Dictionary<char, Label> labelDict = new Dictionary<char, Label>();

        private void btnGuess_Click(object sender, EventArgs e)
        {
            char guess = textBox1.Text.ToLower()[0]; 
            bool correctGuess = false;

            // Check if the word contains the guessed letter.
            for (int i = 0; i < chosenWord.Length; i++)
            {
                if (chosenWord[i] == guess)
                {
                    displayWord[i] = guess;
                    correctGuess = true;

                    
                }
            }
            // Update the word display.
            labelWordDisplay.Text = string.Join(" ", displayWord);
            
            //Paint the right guessed letter to green.
            if (correctGuess)
            {
                if (labelDict.ContainsKey(guess))
                {
                    labelDict[guess].ForeColor = Color.Green;
                }
            }

            // Paint the wrong guessed letter to red.
            if (!correctGuess)
            {
                if (labelDict.ContainsKey(guess))
                {
                    labelDict[guess].ForeColor = Color.Red;
                }
                UpdateHangman();
            }

            // Check if the game is over.
            if (!labelWordDisplay.Text.Contains('_'))
            {
                MessageBox.Show("You've won!!");
                Application.Restart();
            }
        }

        private void UpdateHangman()
        {
            wrongGuesses++;
            switch (wrongGuesses)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._2;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._3;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._4;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._5;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._6;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._7;
                    MessageBox.Show("You've lost! The word was \"" + chosenWord+ "\"");
                    Application.Restart();
                    break;

            }
        }
    }
}
