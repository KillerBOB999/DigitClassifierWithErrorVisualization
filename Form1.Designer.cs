namespace DigitClassifierWithErrorVisualization
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title7 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title8 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title9 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button_PlayPause = new System.Windows.Forms.Button();
            this.button_Reset = new System.Windows.Forms.Button();
            this.button_Run = new System.Windows.Forms.Button();
            this.groupBox_RunTimeData = new System.Windows.Forms.GroupBox();
            this.label_Accuracy = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.output_Accuracy = new System.Windows.Forms.Label();
            this.label_MSEonValidationSet = new System.Windows.Forms.Label();
            this.label_MSEonTrainingSet = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.output_ValidationMSE = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.output_TrainingMSE = new System.Windows.Forms.Label();
            this.container = new System.Windows.Forms.Panel();
            this.output_Epoch = new System.Windows.Forms.Label();
            this.label_Epoch = new System.Windows.Forms.Label();
            this.groupBox_HyperParameters = new System.Windows.Forms.GroupBox();
            this.input_nNodesInNewHiddenLayer = new System.Windows.Forms.TextBox();
            this.label_nEquals = new System.Windows.Forms.Label();
            this.button_AddLayerWithNNodes = new System.Windows.Forms.Button();
            this.label_NodesInOutput = new System.Windows.Forms.Label();
            this.label_LearningRate = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.input_LearningRate = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.output_NodesInOutput = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.input_ValidationSetPortion = new System.Windows.Forms.TextBox();
            this.label_ValidationSetPortion = new System.Windows.Forms.Label();
            this.label_NumberOfHiddenLayers = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.output_NumberOfHiddenLayers = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.output_NodesInInput = new System.Windows.Forms.Label();
            this.label_NodesInInput = new System.Windows.Forms.Label();
            this.chart_MSEs = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox_RunTimeData.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.container.SuspendLayout();
            this.groupBox_HyperParameters.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_MSEs)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.button_PlayPause);
            this.splitContainer1.Panel1.Controls.Add(this.button_Reset);
            this.splitContainer1.Panel1.Controls.Add(this.button_Run);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_RunTimeData);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox_HyperParameters);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chart_MSEs);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 0;
            // 
            // button_PlayPause
            // 
            this.button_PlayPause.Enabled = false;
            this.button_PlayPause.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_PlayPause.Location = new System.Drawing.Point(12, 384);
            this.button_PlayPause.Name = "button_PlayPause";
            this.button_PlayPause.Size = new System.Drawing.Size(242, 29);
            this.button_PlayPause.TabIndex = 7;
            this.button_PlayPause.Text = "Pause Simulation";
            this.button_PlayPause.UseVisualStyleBackColor = true;
            this.button_PlayPause.Click += new System.EventHandler(this.button_PlayPause_Click);
            // 
            // button_Reset
            // 
            this.button_Reset.Enabled = false;
            this.button_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Reset.Location = new System.Drawing.Point(12, 419);
            this.button_Reset.Name = "button_Reset";
            this.button_Reset.Size = new System.Drawing.Size(242, 29);
            this.button_Reset.TabIndex = 6;
            this.button_Reset.Text = "Reset Simulation";
            this.button_Reset.UseVisualStyleBackColor = true;
            this.button_Reset.Click += new System.EventHandler(this.button_Reset_Click);
            // 
            // button_Run
            // 
            this.button_Run.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Run.Location = new System.Drawing.Point(12, 346);
            this.button_Run.Name = "button_Run";
            this.button_Run.Size = new System.Drawing.Size(242, 32);
            this.button_Run.TabIndex = 5;
            this.button_Run.Text = "Run Simulation";
            this.button_Run.UseVisualStyleBackColor = true;
            this.button_Run.Click += new System.EventHandler(this.button_Run_Click);
            // 
            // groupBox_RunTimeData
            // 
            this.groupBox_RunTimeData.Controls.Add(this.label_Accuracy);
            this.groupBox_RunTimeData.Controls.Add(this.panel9);
            this.groupBox_RunTimeData.Controls.Add(this.label_MSEonValidationSet);
            this.groupBox_RunTimeData.Controls.Add(this.label_MSEonTrainingSet);
            this.groupBox_RunTimeData.Controls.Add(this.panel6);
            this.groupBox_RunTimeData.Controls.Add(this.panel5);
            this.groupBox_RunTimeData.Controls.Add(this.container);
            this.groupBox_RunTimeData.Controls.Add(this.label_Epoch);
            this.groupBox_RunTimeData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_RunTimeData.Location = new System.Drawing.Point(3, 209);
            this.groupBox_RunTimeData.Name = "groupBox_RunTimeData";
            this.groupBox_RunTimeData.Size = new System.Drawing.Size(260, 136);
            this.groupBox_RunTimeData.TabIndex = 2;
            this.groupBox_RunTimeData.TabStop = false;
            this.groupBox_RunTimeData.Text = "Run-Time Data";
            // 
            // label_Accuracy
            // 
            this.label_Accuracy.AutoSize = true;
            this.label_Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Accuracy.Location = new System.Drawing.Point(6, 109);
            this.label_Accuracy.Name = "label_Accuracy";
            this.label_Accuracy.Size = new System.Drawing.Size(55, 13);
            this.label_Accuracy.TabIndex = 17;
            this.label_Accuracy.Text = "Accuracy:";
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.output_Accuracy);
            this.panel9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel9.Location = new System.Drawing.Point(135, 101);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(119, 30);
            this.panel9.TabIndex = 16;
            // 
            // output_Accuracy
            // 
            this.output_Accuracy.AutoSize = true;
            this.output_Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_Accuracy.Location = new System.Drawing.Point(3, 8);
            this.output_Accuracy.Name = "output_Accuracy";
            this.output_Accuracy.Size = new System.Drawing.Size(27, 13);
            this.output_Accuracy.TabIndex = 1;
            this.output_Accuracy.Text = "N/A";
            // 
            // label_MSEonValidationSet
            // 
            this.label_MSEonValidationSet.AutoSize = true;
            this.label_MSEonValidationSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MSEonValidationSet.Location = new System.Drawing.Point(6, 78);
            this.label_MSEonValidationSet.Name = "label_MSEonValidationSet";
            this.label_MSEonValidationSet.Size = new System.Drawing.Size(116, 13);
            this.label_MSEonValidationSet.TabIndex = 13;
            this.label_MSEonValidationSet.Text = "MSE on Validation Set:";
            // 
            // label_MSEonTrainingSet
            // 
            this.label_MSEonTrainingSet.AutoSize = true;
            this.label_MSEonTrainingSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_MSEonTrainingSet.Location = new System.Drawing.Point(6, 47);
            this.label_MSEonTrainingSet.Name = "label_MSEonTrainingSet";
            this.label_MSEonTrainingSet.Size = new System.Drawing.Size(108, 13);
            this.label_MSEonTrainingSet.TabIndex = 12;
            this.label_MSEonTrainingSet.Text = "MSE on Training Set:";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.output_ValidationMSE);
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(135, 70);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(119, 30);
            this.panel6.TabIndex = 10;
            // 
            // output_ValidationMSE
            // 
            this.output_ValidationMSE.AutoSize = true;
            this.output_ValidationMSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_ValidationMSE.Location = new System.Drawing.Point(3, 8);
            this.output_ValidationMSE.Name = "output_ValidationMSE";
            this.output_ValidationMSE.Size = new System.Drawing.Size(27, 13);
            this.output_ValidationMSE.TabIndex = 1;
            this.output_ValidationMSE.Text = "N/A";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.output_TrainingMSE);
            this.panel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel5.Location = new System.Drawing.Point(135, 39);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(119, 30);
            this.panel5.TabIndex = 6;
            // 
            // output_TrainingMSE
            // 
            this.output_TrainingMSE.AutoSize = true;
            this.output_TrainingMSE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_TrainingMSE.Location = new System.Drawing.Point(3, 8);
            this.output_TrainingMSE.Name = "output_TrainingMSE";
            this.output_TrainingMSE.Size = new System.Drawing.Size(27, 13);
            this.output_TrainingMSE.TabIndex = 1;
            this.output_TrainingMSE.Text = "N/A";
            // 
            // container
            // 
            this.container.Controls.Add(this.output_Epoch);
            this.container.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.container.Location = new System.Drawing.Point(135, 8);
            this.container.Name = "container";
            this.container.Size = new System.Drawing.Size(119, 30);
            this.container.TabIndex = 5;
            // 
            // output_Epoch
            // 
            this.output_Epoch.AutoSize = true;
            this.output_Epoch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_Epoch.Location = new System.Drawing.Point(3, 8);
            this.output_Epoch.Name = "output_Epoch";
            this.output_Epoch.Size = new System.Drawing.Size(27, 13);
            this.output_Epoch.TabIndex = 1;
            this.output_Epoch.Text = "N/A";
            // 
            // label_Epoch
            // 
            this.label_Epoch.AutoSize = true;
            this.label_Epoch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Epoch.Location = new System.Drawing.Point(6, 16);
            this.label_Epoch.Name = "label_Epoch";
            this.label_Epoch.Size = new System.Drawing.Size(41, 13);
            this.label_Epoch.TabIndex = 9;
            this.label_Epoch.Text = "Epoch:";
            // 
            // groupBox_HyperParameters
            // 
            this.groupBox_HyperParameters.Controls.Add(this.input_nNodesInNewHiddenLayer);
            this.groupBox_HyperParameters.Controls.Add(this.label_nEquals);
            this.groupBox_HyperParameters.Controls.Add(this.button_AddLayerWithNNodes);
            this.groupBox_HyperParameters.Controls.Add(this.label_NodesInOutput);
            this.groupBox_HyperParameters.Controls.Add(this.label_LearningRate);
            this.groupBox_HyperParameters.Controls.Add(this.panel2);
            this.groupBox_HyperParameters.Controls.Add(this.panel8);
            this.groupBox_HyperParameters.Controls.Add(this.panel3);
            this.groupBox_HyperParameters.Controls.Add(this.label_ValidationSetPortion);
            this.groupBox_HyperParameters.Controls.Add(this.label_NumberOfHiddenLayers);
            this.groupBox_HyperParameters.Controls.Add(this.panel4);
            this.groupBox_HyperParameters.Controls.Add(this.panel1);
            this.groupBox_HyperParameters.Controls.Add(this.label_NodesInInput);
            this.groupBox_HyperParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_HyperParameters.Location = new System.Drawing.Point(3, 3);
            this.groupBox_HyperParameters.Name = "groupBox_HyperParameters";
            this.groupBox_HyperParameters.Size = new System.Drawing.Size(260, 200);
            this.groupBox_HyperParameters.TabIndex = 1;
            this.groupBox_HyperParameters.TabStop = false;
            this.groupBox_HyperParameters.Text = "Hyper Parameters";
            // 
            // input_nNodesInNewHiddenLayer
            // 
            this.input_nNodesInNewHiddenLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_nNodesInNewHiddenLayer.Location = new System.Drawing.Point(32, 171);
            this.input_nNodesInNewHiddenLayer.Name = "input_nNodesInNewHiddenLayer";
            this.input_nNodesInNewHiddenLayer.Size = new System.Drawing.Size(66, 20);
            this.input_nNodesInNewHiddenLayer.TabIndex = 4;
            this.input_nNodesInNewHiddenLayer.Text = "4";
            this.input_nNodesInNewHiddenLayer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_nEquals
            // 
            this.label_nEquals.AutoSize = true;
            this.label_nEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_nEquals.Location = new System.Drawing.Point(6, 174);
            this.label_nEquals.Name = "label_nEquals";
            this.label_nEquals.Size = new System.Drawing.Size(22, 13);
            this.label_nEquals.TabIndex = 17;
            this.label_nEquals.Text = "n =";
            // 
            // button_AddLayerWithNNodes
            // 
            this.button_AddLayerWithNNodes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_AddLayerWithNNodes.Location = new System.Drawing.Point(104, 164);
            this.button_AddLayerWithNNodes.Name = "button_AddLayerWithNNodes";
            this.button_AddLayerWithNNodes.Size = new System.Drawing.Size(151, 32);
            this.button_AddLayerWithNNodes.TabIndex = 8;
            this.button_AddLayerWithNNodes.Text = "Add Layer with n Nodes";
            this.button_AddLayerWithNNodes.UseVisualStyleBackColor = true;
            this.button_AddLayerWithNNodes.Click += new System.EventHandler(this.button_AddLayerWithNNodes_Click);
            // 
            // label_NodesInOutput
            // 
            this.label_NodesInOutput.AutoSize = true;
            this.label_NodesInOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NodesInOutput.Location = new System.Drawing.Point(6, 79);
            this.label_NodesInOutput.Name = "label_NodesInOutput";
            this.label_NodesInOutput.Size = new System.Drawing.Size(87, 13);
            this.label_NodesInOutput.TabIndex = 16;
            this.label_NodesInOutput.Text = "Nodes in Output:";
            // 
            // label_LearningRate
            // 
            this.label_LearningRate.AutoSize = true;
            this.label_LearningRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LearningRate.Location = new System.Drawing.Point(6, 141);
            this.label_LearningRate.Name = "label_LearningRate";
            this.label_LearningRate.Size = new System.Drawing.Size(80, 13);
            this.label_LearningRate.TabIndex = 3;
            this.label_LearningRate.Text = "Learning Rate: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.input_LearningRate);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(135, 133);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(120, 30);
            this.panel2.TabIndex = 5;
            // 
            // input_LearningRate
            // 
            this.input_LearningRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_LearningRate.Location = new System.Drawing.Point(0, 5);
            this.input_LearningRate.Name = "input_LearningRate";
            this.input_LearningRate.Size = new System.Drawing.Size(119, 20);
            this.input_LearningRate.TabIndex = 2;
            this.input_LearningRate.Text = "0.001";
            this.input_LearningRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.output_NodesInOutput);
            this.panel8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel8.Location = new System.Drawing.Point(135, 71);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(119, 30);
            this.panel8.TabIndex = 15;
            // 
            // output_NodesInOutput
            // 
            this.output_NodesInOutput.AutoSize = true;
            this.output_NodesInOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_NodesInOutput.Location = new System.Drawing.Point(3, 8);
            this.output_NodesInOutput.Name = "output_NodesInOutput";
            this.output_NodesInOutput.Size = new System.Drawing.Size(13, 13);
            this.output_NodesInOutput.TabIndex = 2;
            this.output_NodesInOutput.Text = "4";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.input_ValidationSetPortion);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(135, 102);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(119, 30);
            this.panel3.TabIndex = 12;
            // 
            // input_ValidationSetPortion
            // 
            this.input_ValidationSetPortion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_ValidationSetPortion.Location = new System.Drawing.Point(0, 4);
            this.input_ValidationSetPortion.Name = "input_ValidationSetPortion";
            this.input_ValidationSetPortion.Size = new System.Drawing.Size(119, 20);
            this.input_ValidationSetPortion.TabIndex = 3;
            this.input_ValidationSetPortion.Text = "0.2";
            this.input_ValidationSetPortion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_ValidationSetPortion
            // 
            this.label_ValidationSetPortion.AutoSize = true;
            this.label_ValidationSetPortion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ValidationSetPortion.Location = new System.Drawing.Point(6, 109);
            this.label_ValidationSetPortion.Name = "label_ValidationSetPortion";
            this.label_ValidationSetPortion.Size = new System.Drawing.Size(111, 13);
            this.label_ValidationSetPortion.TabIndex = 11;
            this.label_ValidationSetPortion.Text = "Validation Set Portion:";
            // 
            // label_NumberOfHiddenLayers
            // 
            this.label_NumberOfHiddenLayers.AutoSize = true;
            this.label_NumberOfHiddenLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NumberOfHiddenLayers.Location = new System.Drawing.Point(6, 48);
            this.label_NumberOfHiddenLayers.Name = "label_NumberOfHiddenLayers";
            this.label_NumberOfHiddenLayers.Size = new System.Drawing.Size(130, 13);
            this.label_NumberOfHiddenLayers.TabIndex = 8;
            this.label_NumberOfHiddenLayers.Text = "Number of Hidden Layers:";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.output_NumberOfHiddenLayers);
            this.panel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel4.Location = new System.Drawing.Point(135, 40);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(119, 30);
            this.panel4.TabIndex = 7;
            // 
            // output_NumberOfHiddenLayers
            // 
            this.output_NumberOfHiddenLayers.AutoSize = true;
            this.output_NumberOfHiddenLayers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_NumberOfHiddenLayers.Location = new System.Drawing.Point(3, 8);
            this.output_NumberOfHiddenLayers.Name = "output_NumberOfHiddenLayers";
            this.output_NumberOfHiddenLayers.Size = new System.Drawing.Size(13, 13);
            this.output_NumberOfHiddenLayers.TabIndex = 2;
            this.output_NumberOfHiddenLayers.Text = "0";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.output_NodesInInput);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(135, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(119, 30);
            this.panel1.TabIndex = 2;
            // 
            // output_NodesInInput
            // 
            this.output_NodesInInput.AutoSize = true;
            this.output_NodesInInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output_NodesInInput.Location = new System.Drawing.Point(3, 7);
            this.output_NodesInInput.Name = "output_NodesInInput";
            this.output_NodesInInput.Size = new System.Drawing.Size(19, 13);
            this.output_NodesInInput.TabIndex = 1;
            this.output_NodesInInput.Text = "64";
            // 
            // label_NodesInInput
            // 
            this.label_NodesInInput.AutoSize = true;
            this.label_NodesInInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_NodesInInput.Location = new System.Drawing.Point(6, 16);
            this.label_NodesInInput.Name = "label_NodesInInput";
            this.label_NodesInInput.Size = new System.Drawing.Size(79, 13);
            this.label_NodesInInput.TabIndex = 0;
            this.label_NodesInInput.Text = "Nodes in Input:";
            // 
            // chart_MSEs
            // 
            this.chart_MSEs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "chart_Display";
            this.chart_MSEs.ChartAreas.Add(chartArea3);
            legend3.Alignment = System.Drawing.StringAlignment.Center;
            legend3.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend3.Name = "Legend1";
            this.chart_MSEs.Legends.Add(legend3);
            this.chart_MSEs.Location = new System.Drawing.Point(-10, 0);
            this.chart_MSEs.Name = "chart_MSEs";
            this.chart_MSEs.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart_MSEs.RightToLeft = System.Windows.Forms.RightToLeft.No;
            series5.ChartArea = "chart_Display";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.IsXValueIndexed = true;
            series5.Legend = "Legend1";
            series5.Name = "MSE on Training Set";
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.ChartArea = "chart_Display";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.IsXValueIndexed = true;
            series6.Legend = "Legend1";
            series6.Name = "MSE on Validation Set";
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart_MSEs.Series.Add(series5);
            this.chart_MSEs.Series.Add(series6);
            this.chart_MSEs.Size = new System.Drawing.Size(540, 450);
            this.chart_MSEs.TabIndex = 0;
            this.chart_MSEs.Text = "chart1";
            title7.Alignment = System.Drawing.ContentAlignment.TopCenter;
            title7.DockedToChartArea = "chart_Display";
            title7.IsDockedInsideChartArea = false;
            title7.Name = "chart_Title";
            title7.Text = "Epoch vs MSE";
            title8.DockedToChartArea = "chart_Display";
            title8.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Left;
            title8.IsDockedInsideChartArea = false;
            title8.Name = "yAxis_Title";
            title8.Text = "MSE";
            title9.Alignment = System.Drawing.ContentAlignment.BottomCenter;
            title9.DockedToChartArea = "chart_Display";
            title9.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            title9.IsDockedInsideChartArea = false;
            title9.Name = "xAxis_Title";
            title9.Text = "Epoch";
            this.chart_MSEs.Titles.Add(title7);
            this.chart_MSEs.Titles.Add(title8);
            this.chart_MSEs.Titles.Add(title9);
            this.chart_MSEs.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Digit Classifier with Error Visualization";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox_RunTimeData.ResumeLayout(false);
            this.groupBox_RunTimeData.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.container.ResumeLayout(false);
            this.container.PerformLayout();
            this.groupBox_HyperParameters.ResumeLayout(false);
            this.groupBox_HyperParameters.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_MSEs)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button_PlayPause;
        private System.Windows.Forms.Button button_Reset;
        private System.Windows.Forms.Button button_Run;
        private System.Windows.Forms.GroupBox groupBox_RunTimeData;
        private System.Windows.Forms.Label label_MSEonValidationSet;
        private System.Windows.Forms.Label label_MSEonTrainingSet;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label output_ValidationMSE;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label output_TrainingMSE;
        private System.Windows.Forms.Panel container;
        private System.Windows.Forms.Label output_Epoch;
        private System.Windows.Forms.Label label_Epoch;
        private System.Windows.Forms.GroupBox groupBox_HyperParameters;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label_ValidationSetPortion;
        private System.Windows.Forms.Label label_NumberOfHiddenLayers;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox input_LearningRate;
        private System.Windows.Forms.Label label_LearningRate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label output_NodesInInput;
        private System.Windows.Forms.Label label_NodesInInput;
        private System.Windows.Forms.Label label_NodesInOutput;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label output_NodesInOutput;
        private System.Windows.Forms.TextBox input_ValidationSetPortion;
        private System.Windows.Forms.Label output_NumberOfHiddenLayers;
        private System.Windows.Forms.Button button_AddLayerWithNNodes;
        private System.Windows.Forms.TextBox input_nNodesInNewHiddenLayer;
        private System.Windows.Forms.Label label_nEquals;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_MSEs;
        private System.Windows.Forms.Label label_Accuracy;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label output_Accuracy;
    }
}

