namespace PS_Sample.GUI
{
    partial class MonkeyRopeBridge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnAddLeftSideMonkey = new System.Windows.Forms.Button();
            this.btnAddRightSideMonkey = new System.Windows.Forms.Button();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.grpBridge = new System.Windows.Forms.GroupBox();
            this.grpCrossedMonkeysRight = new System.Windows.Forms.GroupBox();
            this.grpCrossedMonkeysLeft = new System.Windows.Forms.GroupBox();
            this.btnStartCrossing = new System.Windows.Forms.Button();
            this.tmrMonkeyProcessing = new System.Windows.Forms.Timer(this.components);
            this.btnClearAnimals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddLeftSideMonkey
            // 
            this.btnAddLeftSideMonkey.Location = new System.Drawing.Point(13, 13);
            this.btnAddLeftSideMonkey.Name = "btnAddLeftSideMonkey";
            this.btnAddLeftSideMonkey.Size = new System.Drawing.Size(195, 23);
            this.btnAddLeftSideMonkey.TabIndex = 0;
            this.btnAddLeftSideMonkey.Text = "Add Monkey to Left Queue";
            this.btnAddLeftSideMonkey.UseVisualStyleBackColor = true;
            this.btnAddLeftSideMonkey.Click += new System.EventHandler(this.btnAddLeftSideMonkey_Click);
            // 
            // btnAddRightSideMonkey
            // 
            this.btnAddRightSideMonkey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRightSideMonkey.Location = new System.Drawing.Point(934, 12);
            this.btnAddRightSideMonkey.Name = "btnAddRightSideMonkey";
            this.btnAddRightSideMonkey.Size = new System.Drawing.Size(195, 23);
            this.btnAddRightSideMonkey.TabIndex = 1;
            this.btnAddRightSideMonkey.Text = "Add Monkey to Right Queue";
            this.btnAddRightSideMonkey.UseVisualStyleBackColor = true;
            this.btnAddRightSideMonkey.Click += new System.EventHandler(this.btnAddRightSideMonkey_Click);
            // 
            // grpLeft
            // 
            this.grpLeft.Location = new System.Drawing.Point(13, 41);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(547, 137);
            this.grpLeft.TabIndex = 2;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "Waiting Monkeys";
            // 
            // grpRight
            // 
            this.grpRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRight.Location = new System.Drawing.Point(566, 41);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(563, 137);
            this.grpRight.TabIndex = 3;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "Waiting Monkeys";
            // 
            // grpBridge
            // 
            this.grpBridge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBridge.Location = new System.Drawing.Point(13, 206);
            this.grpBridge.MinimumSize = new System.Drawing.Size(1116, 265);
            this.grpBridge.Name = "grpBridge";
            this.grpBridge.Size = new System.Drawing.Size(1116, 265);
            this.grpBridge.TabIndex = 4;
            this.grpBridge.TabStop = false;
            this.grpBridge.Text = "Crossing Monkeys";
            // 
            // grpCrossedMonkeysRight
            // 
            this.grpCrossedMonkeysRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCrossedMonkeysRight.Location = new System.Drawing.Point(565, 503);
            this.grpCrossedMonkeysRight.Name = "grpCrossedMonkeysRight";
            this.grpCrossedMonkeysRight.Size = new System.Drawing.Size(563, 154);
            this.grpCrossedMonkeysRight.TabIndex = 6;
            this.grpCrossedMonkeysRight.TabStop = false;
            this.grpCrossedMonkeysRight.Text = "Waiting Monkeys";
            // 
            // grpCrossedMonkeysLeft
            // 
            this.grpCrossedMonkeysLeft.Location = new System.Drawing.Point(12, 503);
            this.grpCrossedMonkeysLeft.Name = "grpCrossedMonkeysLeft";
            this.grpCrossedMonkeysLeft.Size = new System.Drawing.Size(547, 154);
            this.grpCrossedMonkeysLeft.TabIndex = 5;
            this.grpCrossedMonkeysLeft.TabStop = false;
            this.grpCrossedMonkeysLeft.Text = "Waiting Monkeys";
            // 
            // btnStartCrossing
            // 
            this.btnStartCrossing.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartCrossing.Location = new System.Drawing.Point(293, 12);
            this.btnStartCrossing.Name = "btnStartCrossing";
            this.btnStartCrossing.Size = new System.Drawing.Size(448, 23);
            this.btnStartCrossing.TabIndex = 7;
            this.btnStartCrossing.Text = "Start Crossing";
            this.btnStartCrossing.UseVisualStyleBackColor = true;
            this.btnStartCrossing.Click += new System.EventHandler(this.btnStartCrossing_Click);
            // 
            // btnClearAnimals
            // 
            this.btnClearAnimals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearAnimals.Location = new System.Drawing.Point(807, 12);
            this.btnClearAnimals.Name = "btnClearAnimals";
            this.btnClearAnimals.Size = new System.Drawing.Size(121, 23);
            this.btnClearAnimals.TabIndex = 8;
            this.btnClearAnimals.Text = "Clear Animals";
            this.btnClearAnimals.UseVisualStyleBackColor = true;
            this.btnClearAnimals.Click += new System.EventHandler(this.btnClearAnimals_Click);
            // 
            // MonkeyRopeBridge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 666);
            this.Controls.Add(this.btnClearAnimals);
            this.Controls.Add(this.btnStartCrossing);
            this.Controls.Add(this.grpCrossedMonkeysRight);
            this.Controls.Add(this.grpCrossedMonkeysLeft);
            this.Controls.Add(this.grpBridge);
            this.Controls.Add(this.grpRight);
            this.Controls.Add(this.grpLeft);
            this.Controls.Add(this.btnAddRightSideMonkey);
            this.Controls.Add(this.btnAddLeftSideMonkey);
            this.MinimumSize = new System.Drawing.Size(1157, 705);
            this.Name = "MonkeyRopeBridge";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddLeftSideMonkey;
        private System.Windows.Forms.Button btnAddRightSideMonkey;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.GroupBox grpBridge;
        private System.Windows.Forms.GroupBox grpCrossedMonkeysRight;
        private System.Windows.Forms.GroupBox grpCrossedMonkeysLeft;
        private System.Windows.Forms.Button btnStartCrossing;
        private System.Windows.Forms.Timer tmrMonkeyProcessing;
        private System.Windows.Forms.Button btnClearAnimals;
    }
}

