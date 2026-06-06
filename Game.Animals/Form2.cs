using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game.Animals
{
    public partial class Form2 : Form
    {

        private Dictionary<PictureBox, string> correctPositions = new Dictionary<PictureBox, string>();
        private PictureBox draggedPictureBox = null;
        private Point originalLocation;
        private int score = 0;
        public Form2()
        {  


            InitializeComponent();
            InitializeGame();
        }
        private void InitializeGame()
        {

            correctPositions[pictureBox1] = "U";  // pictureBox1 should contain "A"
            correctPositions[pictureBox2] = "V";  // pictureBox2 should contain "B"
            correctPositions[pictureBox3] = "W";

            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox && control.Name.StartsWith("pictureBox") && control.Name.Length == 11) // A-C PictureBoxes
                {
                    pictureBox.MouseDown += Letter_MouseDown;
                }
            }
            foreach (var targetPictureBox in correctPositions.Keys)
            {
                targetPictureBox.AllowDrop = true;
                targetPictureBox.DragEnter += TargetPictureBox_DragEnter;
                targetPictureBox.DragDrop += TargetPictureBox_DragDrop;
            }
            /* Button resetButton = new Button();
             resetButton.Text = "Reset";
             resetButton.Location = new Point(10, 10);  // Adjust position as needed
             resetButton.Click += ResetButton_Click;
             this.Controls.Add(resetButton);*/

            Label scoreLabel = new Label();
            scoreLabel.Name = "scoreLabel";
            scoreLabel.Text = "Score: 0";
            scoreLabel.Location = new Point(20, 250);  // Adjust position as needed
            this.Controls.Add(scoreLabel);

        }
        private void Letter_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox pictureBox)
            {
                draggedPictureBox = pictureBox;
                originalLocation = pictureBox.Location;  // Store the original location
                pictureBox.DoDragDrop(pictureBox, DragDropEffects.Move);
            }

        }
        private void TargetPictureBox_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }


        private void TargetPictureBox_DragDrop(object sender, DragEventArgs e)
        {
            if (sender is PictureBox targetBox && draggedPictureBox != null)
            {
                string letter = draggedPictureBox.Name.Replace("pictureBox", "");

                if (correctPositions[targetBox] == letter)
                {
                    // Correct position, snap to target and add points
                    draggedPictureBox.Location = targetBox.Location;
                    UpdateScore(10);  // Add 10 points
                }


                else
                {
                    //  Incorrect position, return to original location and deduct points
                    // draggedPictureBox.Location = originalLocation;
                    //  UpdateScore(-10);  // Deduct 10 points
                    // if (UpdateScore==)
                }

                draggedPictureBox = null;  // Reset the dragged picture box
            }
            //  if (UpdateScore == 30) { }
        }


        private void UpdateScore(int points)
        {
            score += points;
            Label scoreLabel = this.Controls["scoreLabel"] as Label;
            if (scoreLabel != null)
            {
                scoreLabel.Text = $"Score: {score}";
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            // Reset all picture boxes to their original positions
            foreach (Control control in this.Controls)
            {
                if (control is PictureBox pictureBox && control.Name.StartsWith("pictureBox") && pictureBox.Name.Length == 11)
                {
                    // Reset each picture box's location to the initial position
                    // Here, you can set their locations manually or use a predefined location
                    pictureBox.Location = originalLocation;  // Adjust if different locations needed
                }
            }

            // Reset score
            score = 0;
            Label scoreLabel = this.Controls["scoreLabel"] as Label;
            if (scoreLabel != null)
            {
                scoreLabel.Text = "Score: 0";
            }









        }

        private void button1_Click(object sender, EventArgs e)
        {
            last v=new last();
            v.Show();   
        }
    }
}
