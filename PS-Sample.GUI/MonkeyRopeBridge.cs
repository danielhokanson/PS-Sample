using PS_Sample.Adapter;
using PS_Sample.Model;
using Svg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_Sample.GUI
{
    public partial class MonkeyRopeBridge : Form
    {
        protected SvgDocument svg;
        protected RopeBridge Bridge = new RopeBridge();
        public MonkeyRopeBridge()
        {
            InitializeComponent();
        }

        private void btnAddLeftSideMonkey_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            new Monkey(this.Bridge, Model.BridgeSide.Left);
            DrawMonkeys();
            this.UseWaitCursor = false;

        }

        private void btnAddRightSideMonkey_Click(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            new Monkey(this.Bridge, Model.BridgeSide.Right);
            DrawMonkeys();
            this.UseWaitCursor = false;

        }

        private void btnStartCrossing_Click(object sender, EventArgs e)
        {
            tmrMonkeyProcessing.Tick += TmrMonkeyProcessing_Tick;
            tmrMonkeyProcessing.Interval = 2000;
            tmrMonkeyProcessing.Start();
            btnStartCrossing.Enabled = false;
        }

        private void TmrMonkeyProcessing_Tick(object sender, EventArgs e)
        {
            this.UseWaitCursor = true;
            var didAnyCross = this.Bridge.ProcessAnimalMovement();
            DrawMonkeys();

            if (!didAnyCross)
            {
                tmrMonkeyProcessing.Stop();
                btnStartCrossing.Enabled = true;
            }
            this.UseWaitCursor = false;
        }

        private void DrawMonkeys()
        {
            grpLeft.Controls.Clear();
            grpRight.Controls.Clear();
            grpBridge.Controls.Clear();
            grpCrossedMonkeysLeft.Controls.Clear();
            grpCrossedMonkeysRight.Controls.Clear();

            DrawGroupBoxOfMonkeys(grpLeft, this.Bridge.LeftSideAnimalList);
            DrawGroupBoxOfMonkeys(grpRight, this.Bridge.RightSideAnimalList);
            DrawBridgeGroupBox();
            DrawGroupBoxOfMonkeys(grpCrossedMonkeysLeft, this.Bridge.LeftCrossedAnimals);
            DrawGroupBoxOfMonkeys(grpCrossedMonkeysRight, this.Bridge.RightCrossedAnimals);

            btnAddLeftSideMonkey.Enabled = this.Bridge.LeftSideAnimalList.Count <= 4;


            btnAddRightSideMonkey.Enabled = this.Bridge.RightSideAnimalList.Count <= 4;
        }

        private void DrawBridgeGroupBox()
        {
            var verticalOffset = 15;
            foreach (Animal[] lane in this.Bridge.CrossingAnimals)
            {
                GroupBox laneGroup = new GroupBox();
                laneGroup.Location = new Point(15, verticalOffset);
                laneGroup.Text = "Lane" + (Array.IndexOf(this.Bridge.CrossingAnimals, lane) + 1).ToString();
                laneGroup.Width = grpBridge.Width - 30;
                laneGroup.Height = 140;
                grpBridge.Controls.Add(laneGroup);
                verticalOffset += 155;
                bool isRightToLeft = lane.Any(animal => animal != null && animal.Side == BridgeSide.Right);
                int horizontalOffset = isRightToLeft ? laneGroup.Width - 15 - 110 : 15;
                DrawGroupBoxOfMonkeys(laneGroup, lane, 15, horizontalOffset, isRightToLeft ? -1 : 1);
            }
        }

        private void DrawGroupBoxOfMonkeys(GroupBox box, IEnumerable<Animal> animals, int animalBoxVerticalOffset = 15, int animalBoxHorizontalOffset = 15, int multiplier = 1)
        {
            var containerWidth = box.Width;
            var containerHeight = box.Height;
            foreach (Animal animal in animals)
            {
                if (animal != null)
                {
                    if (animal.UserControl == null)
                    {
                        Panel animalBox = new Panel();
                        animalBox.Height = 110;
                        animalBox.Width = 110;
                        animalBox.BackgroundImageLayout = ImageLayout.Stretch;
                        Label animalName = new Label();
                        animalName.BackColor = Color.Transparent;
                        animalName.Text = animal.GetType().Name;
                        animalName.Location = new Point(15, 15);
                        animalName.Font = new Font(animalName.Font, FontStyle.Bold);
                        animalName.ForeColor = Color.White;
                        animalBox.Controls.Add(animalName);

                        Label animalId = new Label();
                        animalId.BackColor = Color.Transparent;
                        animalId.Text = (animal.Id + 1).ToString();
                        animalId.Location = new Point(15, 75);
                        animalId.Font = new Font(animalId.Font, FontStyle.Bold);
                        animalId.ForeColor = Color.White;
                        animalBox.Controls.Add(animalId);
                        if (!string.IsNullOrWhiteSpace(animal.AvatarRelativePath) && File.Exists(animal.AvatarRelativePath) && animal.AvatarRelativePath.EndsWith(".svg"))
                        {
                            animalBox.BackgroundImageLayout = ImageLayout.Center;
                            animalBox.BackColor = Color.Black;
                            svg = SvgDocument.Open(animal.AvatarRelativePath);
                            svg.Height = 50;
                            svg.Width = 50;
                            animalBox.BackgroundImage = svg.Draw();
                        }
                        animal.UserControl = animalBox;
                    }
                    animal.UserControl.Location = new Point(animalBoxHorizontalOffset, animalBoxVerticalOffset);
                    box.Controls.Add(animal.UserControl);
                }
                animalBoxHorizontalOffset += 125 * multiplier;
            }
        }

        private void btnClearAnimals_Click(object sender, EventArgs e)
        {
            this.Bridge = new RopeBridge();
            DrawMonkeys();
        }
    }
}
