using System.ComponentModel;

namespace GraduationProject.CheckForms;

partial class CheckForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.taskTabs = new System.Windows.Forms.TabControl();
            this.elementaryTask = new System.Windows.Forms.TabPage();
            this.elementaryTasks = new System.Windows.Forms.TableLayoutPanel();
            this.elementaryCheckMethodsPanel = new System.Windows.Forms.Panel();
            this.elementaryCheckMethods = new System.Windows.Forms.GroupBox();
            this.checkedElementaryCheckMethods = new System.Windows.Forms.CheckedListBox();
            this.ready_madeElementaryTasksPanel = new System.Windows.Forms.GroupBox();
            this.ready_madeElementaryTasks = new System.Windows.Forms.CheckedListBox();
            this.elementaryTaskForms = new System.Windows.Forms.TableLayoutPanel();
            this.basicTask = new System.Windows.Forms.TabPage();
            this.baseTaskMainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tasksForBaseTasksLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.baseTasksForBaseTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.baseTasksForBaseTaskСheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.elementaryTasksForBaseTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.elementaryTasksForBaseTaskСheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.ready_madeBaseTasksPanel = new System.Windows.Forms.GroupBox();
            this.ready_madeBaseTasks = new System.Windows.Forms.CheckedListBox();
            this.basesTasks = new System.Windows.Forms.TableLayoutPanel();
            this.baseTaskPanel = new System.Windows.Forms.GroupBox();
            this.baseTaskMainForm = new System.Windows.Forms.TableLayoutPanel();
            this.baseTaskContentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.baseTaskName = new System.Windows.Forms.TextBox();
            this.baseTaskContent = new System.Windows.Forms.TextBox();
            this.baseTrueResult = new System.Windows.Forms.TextBox();
            this.baseFalseResult = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tasksForBaseTasks = new System.Windows.Forms.ListBox();
            this.addBaseTask = new System.Windows.Forms.Button();
            this.derivedProblem = new System.Windows.Forms.TabPage();
            this.derivedTasksPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tasksPanelInDerivedTask = new System.Windows.Forms.Panel();
            this.tasksInDerivedTask = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.derivedTasksInDerivedTask = new System.Windows.Forms.CheckedListBox();
            this.groupB = new System.Windows.Forms.GroupBox();
            this.baseTasksInDerivedTask = new System.Windows.Forms.CheckedListBox();
            this.elementaryTasksBoxInDerivedTask = new System.Windows.Forms.GroupBox();
            this.elementaryTasksInDerivedTask = new System.Windows.Forms.CheckedListBox();
            this.ready_madeDerivedTasksPanel = new System.Windows.Forms.GroupBox();
            this.ready_madeDerivedTasksInnerPanel = new System.Windows.Forms.Panel();
            this.ready_madeDerivedTasks = new System.Windows.Forms.CheckedListBox();
            this.derivedTasks = new System.Windows.Forms.TableLayoutPanel();
            this.derivedTaskGroupBox = new System.Windows.Forms.GroupBox();
            this.derivedTask = new System.Windows.Forms.TableLayoutPanel();
            this.derivedTaskContentPanel = new System.Windows.Forms.TableLayoutPanel();
            this.derivedTaskName = new System.Windows.Forms.TextBox();
            this.derivedTaskContent = new System.Windows.Forms.TextBox();
            this.derivedTaskTrueResult = new System.Windows.Forms.TextBox();
            this.derivedTaskFalseResult = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tasksForDerivedTask = new System.Windows.Forms.ListBox();
            this.addDerivedTask = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tasksPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.updateButton = new System.Windows.Forms.Button();
            this.viewButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.checkingPage = new System.Windows.Forms.TabPage();
            this.checkingTasksPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.taskCheckMethods = new System.Windows.Forms.CheckedListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.viewButtonInCheckingWindow = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.comparer = new System.Windows.Forms.Button();
            this.read = new System.Windows.Forms.Button();
            this.connect = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.featureNames = new System.Windows.Forms.ComboBox();
            this.taskTabs.SuspendLayout();
            this.elementaryTask.SuspendLayout();
            this.elementaryTasks.SuspendLayout();
            this.elementaryCheckMethodsPanel.SuspendLayout();
            this.elementaryCheckMethods.SuspendLayout();
            this.ready_madeElementaryTasksPanel.SuspendLayout();
            this.basicTask.SuspendLayout();
            this.baseTaskMainLayoutPanel.SuspendLayout();
            this.tasksForBaseTasksLayoutPanel.SuspendLayout();
            this.baseTasksForBaseTaskGroupBox.SuspendLayout();
            this.elementaryTasksForBaseTaskGroupBox.SuspendLayout();
            this.ready_madeBaseTasksPanel.SuspendLayout();
            this.basesTasks.SuspendLayout();
            this.baseTaskPanel.SuspendLayout();
            this.baseTaskMainForm.SuspendLayout();
            this.baseTaskContentPanel.SuspendLayout();
            this.derivedProblem.SuspendLayout();
            this.derivedTasksPanel.SuspendLayout();
            this.tasksPanelInDerivedTask.SuspendLayout();
            this.tasksInDerivedTask.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupB.SuspendLayout();
            this.elementaryTasksBoxInDerivedTask.SuspendLayout();
            this.ready_madeDerivedTasksPanel.SuspendLayout();
            this.ready_madeDerivedTasksInnerPanel.SuspendLayout();
            this.derivedTasks.SuspendLayout();
            this.derivedTaskGroupBox.SuspendLayout();
            this.derivedTask.SuspendLayout();
            this.derivedTaskContentPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tasksPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.checkingPage.SuspendLayout();
            this.checkingTasksPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // taskTabs
            // 
            this.taskTabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.taskTabs.Controls.Add(this.elementaryTask);
            this.taskTabs.Controls.Add(this.basicTask);
            this.taskTabs.Controls.Add(this.derivedProblem);
            this.taskTabs.Location = new System.Drawing.Point(5, 3);
            this.taskTabs.Margin = new System.Windows.Forms.Padding(0);
            this.taskTabs.Name = "taskTabs";
            this.taskTabs.SelectedIndex = 0;
            this.taskTabs.Size = new System.Drawing.Size(934, 418);
            this.taskTabs.TabIndex = 0;
            // 
            // elementaryTask
            // 
            this.elementaryTask.Controls.Add(this.elementaryTasks);
            this.elementaryTask.Location = new System.Drawing.Point(4, 25);
            this.elementaryTask.Margin = new System.Windows.Forms.Padding(4);
            this.elementaryTask.Name = "elementaryTask";
            this.elementaryTask.Padding = new System.Windows.Forms.Padding(4);
            this.elementaryTask.Size = new System.Drawing.Size(926, 389);
            this.elementaryTask.TabIndex = 0;
            this.elementaryTask.Text = "Элементарная задача";
            this.elementaryTask.UseVisualStyleBackColor = true;
            // 
            // elementaryTasks
            // 
            this.elementaryTasks.ColumnCount = 3;
            this.elementaryTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.elementaryTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.elementaryTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.elementaryTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.elementaryTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.elementaryTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.elementaryTasks.Controls.Add(this.elementaryCheckMethodsPanel, 0, 0);
            this.elementaryTasks.Controls.Add(this.ready_madeElementaryTasksPanel, 2, 0);
            this.elementaryTasks.Controls.Add(this.elementaryTaskForms, 1, 0);
            this.elementaryTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryTasks.Location = new System.Drawing.Point(4, 4);
            this.elementaryTasks.Name = "elementaryTasks";
            this.elementaryTasks.RowCount = 1;
            this.elementaryTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.elementaryTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            this.elementaryTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.elementaryTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 381F));
            this.elementaryTasks.Size = new System.Drawing.Size(918, 381);
            this.elementaryTasks.TabIndex = 0;
            // 
            // elementaryCheckMethodsPanel
            // 
            this.elementaryCheckMethodsPanel.Controls.Add(this.elementaryCheckMethods);
            this.elementaryCheckMethodsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryCheckMethodsPanel.Location = new System.Drawing.Point(3, 3);
            this.elementaryCheckMethodsPanel.Name = "elementaryCheckMethodsPanel";
            this.elementaryCheckMethodsPanel.Size = new System.Drawing.Size(177, 375);
            this.elementaryCheckMethodsPanel.TabIndex = 4;
            // 
            // elementaryCheckMethods
            // 
            this.elementaryCheckMethods.Controls.Add(this.checkedElementaryCheckMethods);
            this.elementaryCheckMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryCheckMethods.Location = new System.Drawing.Point(0, 0);
            this.elementaryCheckMethods.Name = "elementaryCheckMethods";
            this.elementaryCheckMethods.Size = new System.Drawing.Size(177, 375);
            this.elementaryCheckMethods.TabIndex = 0;
            this.elementaryCheckMethods.TabStop = false;
            this.elementaryCheckMethods.Text = "Методы проверок";
            // 
            // checkedElementaryCheckMethods
            // 
            this.checkedElementaryCheckMethods.CheckOnClick = true;
            this.checkedElementaryCheckMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedElementaryCheckMethods.FormattingEnabled = true;
            this.checkedElementaryCheckMethods.HorizontalScrollbar = true;
            this.checkedElementaryCheckMethods.Location = new System.Drawing.Point(3, 18);
            this.checkedElementaryCheckMethods.Name = "checkedElementaryCheckMethods";
            this.checkedElementaryCheckMethods.Size = new System.Drawing.Size(171, 354);
            this.checkedElementaryCheckMethods.TabIndex = 4;
            this.checkedElementaryCheckMethods.SelectedIndexChanged += new System.EventHandler(this.checkedElementaryCheckMethods_SelectedIndexChanged);
            // 
            // ready_madeElementaryTasksPanel
            // 
            this.ready_madeElementaryTasksPanel.Controls.Add(this.ready_madeElementaryTasks);
            this.ready_madeElementaryTasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeElementaryTasksPanel.Location = new System.Drawing.Point(736, 3);
            this.ready_madeElementaryTasksPanel.Name = "ready_madeElementaryTasksPanel";
            this.ready_madeElementaryTasksPanel.Size = new System.Drawing.Size(179, 375);
            this.ready_madeElementaryTasksPanel.TabIndex = 5;
            this.ready_madeElementaryTasksPanel.TabStop = false;
            this.ready_madeElementaryTasksPanel.Text = "Экземпляры задач";
            // 
            // ready_madeElementaryTasks
            // 
            this.ready_madeElementaryTasks.CheckOnClick = true;
            this.ready_madeElementaryTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeElementaryTasks.FormattingEnabled = true;
            this.ready_madeElementaryTasks.HorizontalScrollbar = true;
            this.ready_madeElementaryTasks.Location = new System.Drawing.Point(3, 18);
            this.ready_madeElementaryTasks.Name = "ready_madeElementaryTasks";
            this.ready_madeElementaryTasks.Size = new System.Drawing.Size(173, 354);
            this.ready_madeElementaryTasks.TabIndex = 7;
            // 
            // elementaryTaskForms
            // 
            this.elementaryTaskForms.AutoScroll = true;
            this.elementaryTaskForms.BackColor = System.Drawing.Color.Transparent;
            this.elementaryTaskForms.ColumnCount = 1;
            this.elementaryTaskForms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.elementaryTaskForms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.elementaryTaskForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryTaskForms.Location = new System.Drawing.Point(186, 3);
            this.elementaryTaskForms.Name = "elementaryTaskForms";
            this.elementaryTaskForms.RowCount = 3;
            this.elementaryTaskForms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.elementaryTaskForms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.elementaryTaskForms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.elementaryTaskForms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.elementaryTaskForms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.elementaryTaskForms.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.elementaryTaskForms.Size = new System.Drawing.Size(544, 375);
            this.elementaryTaskForms.TabIndex = 6;
            // 
            // basicTask
            // 
            this.basicTask.Controls.Add(this.baseTaskMainLayoutPanel);
            this.basicTask.Location = new System.Drawing.Point(4, 25);
            this.basicTask.Margin = new System.Windows.Forms.Padding(4);
            this.basicTask.Name = "basicTask";
            this.basicTask.Size = new System.Drawing.Size(926, 389);
            this.basicTask.TabIndex = 1;
            this.basicTask.Text = "Базовая задача";
            this.basicTask.UseVisualStyleBackColor = true;
            // 
            // baseTaskMainLayoutPanel
            // 
            this.baseTaskMainLayoutPanel.ColumnCount = 3;
            this.baseTaskMainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.baseTaskMainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.baseTaskMainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.baseTaskMainLayoutPanel.Controls.Add(this.tasksForBaseTasksLayoutPanel, 0, 0);
            this.baseTaskMainLayoutPanel.Controls.Add(this.ready_madeBaseTasksPanel, 2, 0);
            this.baseTaskMainLayoutPanel.Controls.Add(this.basesTasks, 1, 0);
            this.baseTaskMainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTaskMainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.baseTaskMainLayoutPanel.Name = "baseTaskMainLayoutPanel";
            this.baseTaskMainLayoutPanel.RowCount = 1;
            this.baseTaskMainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTaskMainLayoutPanel.Size = new System.Drawing.Size(926, 389);
            this.baseTaskMainLayoutPanel.TabIndex = 0;
            // 
            // tasksForBaseTasksLayoutPanel
            // 
            this.tasksForBaseTasksLayoutPanel.ColumnCount = 1;
            this.tasksForBaseTasksLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tasksForBaseTasksLayoutPanel.Controls.Add(this.baseTasksForBaseTaskGroupBox, 0, 1);
            this.tasksForBaseTasksLayoutPanel.Controls.Add(this.elementaryTasksForBaseTaskGroupBox, 0, 0);
            this.tasksForBaseTasksLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksForBaseTasksLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.tasksForBaseTasksLayoutPanel.Name = "tasksForBaseTasksLayoutPanel";
            this.tasksForBaseTasksLayoutPanel.RowCount = 2;
            this.tasksForBaseTasksLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tasksForBaseTasksLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tasksForBaseTasksLayoutPanel.Size = new System.Drawing.Size(179, 383);
            this.tasksForBaseTasksLayoutPanel.TabIndex = 0;
            // 
            // baseTasksForBaseTaskGroupBox
            // 
            this.baseTasksForBaseTaskGroupBox.Controls.Add(this.baseTasksForBaseTaskСheckedListBox);
            this.baseTasksForBaseTaskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTasksForBaseTaskGroupBox.Location = new System.Drawing.Point(3, 194);
            this.baseTasksForBaseTaskGroupBox.Name = "baseTasksForBaseTaskGroupBox";
            this.baseTasksForBaseTaskGroupBox.Size = new System.Drawing.Size(173, 186);
            this.baseTasksForBaseTaskGroupBox.TabIndex = 1;
            this.baseTasksForBaseTaskGroupBox.TabStop = false;
            this.baseTasksForBaseTaskGroupBox.Text = "Базовые задачи";
            // 
            // baseTasksForBaseTaskСheckedListBox
            // 
            this.baseTasksForBaseTaskСheckedListBox.CheckOnClick = true;
            this.baseTasksForBaseTaskСheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTasksForBaseTaskСheckedListBox.FormattingEnabled = true;
            this.baseTasksForBaseTaskСheckedListBox.HorizontalScrollbar = true;
            this.baseTasksForBaseTaskСheckedListBox.Location = new System.Drawing.Point(3, 18);
            this.baseTasksForBaseTaskСheckedListBox.Name = "baseTasksForBaseTaskСheckedListBox";
            this.baseTasksForBaseTaskСheckedListBox.Size = new System.Drawing.Size(167, 165);
            this.baseTasksForBaseTaskСheckedListBox.TabIndex = 2;
            this.baseTasksForBaseTaskСheckedListBox.SelectedIndexChanged += new System.EventHandler(this.baseTasksForBaseTaskСheckedListBox_SelectedIndexChanged);
            // 
            // elementaryTasksForBaseTaskGroupBox
            // 
            this.elementaryTasksForBaseTaskGroupBox.Controls.Add(this.elementaryTasksForBaseTaskСheckedListBox);
            this.elementaryTasksForBaseTaskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryTasksForBaseTaskGroupBox.Location = new System.Drawing.Point(3, 3);
            this.elementaryTasksForBaseTaskGroupBox.Name = "elementaryTasksForBaseTaskGroupBox";
            this.elementaryTasksForBaseTaskGroupBox.Size = new System.Drawing.Size(173, 185);
            this.elementaryTasksForBaseTaskGroupBox.TabIndex = 0;
            this.elementaryTasksForBaseTaskGroupBox.TabStop = false;
            this.elementaryTasksForBaseTaskGroupBox.Text = "Элементарные задачи";
            // 
            // elementaryTasksForBaseTaskСheckedListBox
            // 
            this.elementaryTasksForBaseTaskСheckedListBox.CheckOnClick = true;
            this.elementaryTasksForBaseTaskСheckedListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryTasksForBaseTaskСheckedListBox.FormattingEnabled = true;
            this.elementaryTasksForBaseTaskСheckedListBox.HorizontalScrollbar = true;
            this.elementaryTasksForBaseTaskСheckedListBox.Location = new System.Drawing.Point(3, 18);
            this.elementaryTasksForBaseTaskСheckedListBox.Name = "elementaryTasksForBaseTaskСheckedListBox";
            this.elementaryTasksForBaseTaskСheckedListBox.Size = new System.Drawing.Size(167, 164);
            this.elementaryTasksForBaseTaskСheckedListBox.TabIndex = 0;
            this.elementaryTasksForBaseTaskСheckedListBox.SelectedIndexChanged += new System.EventHandler(this.elementaryTasksForBaseTaskСheckedListBox_SelectedIndexChanged);
            // 
            // ready_madeBaseTasksPanel
            // 
            this.ready_madeBaseTasksPanel.Controls.Add(this.ready_madeBaseTasks);
            this.ready_madeBaseTasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeBaseTasksPanel.Location = new System.Drawing.Point(743, 3);
            this.ready_madeBaseTasksPanel.Name = "ready_madeBaseTasksPanel";
            this.ready_madeBaseTasksPanel.Size = new System.Drawing.Size(180, 383);
            this.ready_madeBaseTasksPanel.TabIndex = 1;
            this.ready_madeBaseTasksPanel.TabStop = false;
            this.ready_madeBaseTasksPanel.Text = "Экземпляры задач";
            // 
            // ready_madeBaseTasks
            // 
            this.ready_madeBaseTasks.CheckOnClick = true;
            this.ready_madeBaseTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeBaseTasks.FormattingEnabled = true;
            this.ready_madeBaseTasks.Location = new System.Drawing.Point(3, 18);
            this.ready_madeBaseTasks.Name = "ready_madeBaseTasks";
            this.ready_madeBaseTasks.Size = new System.Drawing.Size(174, 362);
            this.ready_madeBaseTasks.TabIndex = 2;
            // 
            // basesTasks
            // 
            this.basesTasks.ColumnCount = 1;
            this.basesTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.basesTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.basesTasks.Controls.Add(this.baseTaskPanel, 0, 0);
            this.basesTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.basesTasks.Location = new System.Drawing.Point(188, 3);
            this.basesTasks.Name = "basesTasks";
            this.basesTasks.RowCount = 3;
            this.basesTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.basesTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.basesTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.basesTasks.Size = new System.Drawing.Size(549, 383);
            this.basesTasks.TabIndex = 2;
            // 
            // baseTaskPanel
            // 
            this.baseTaskPanel.Controls.Add(this.baseTaskMainForm);
            this.baseTaskPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTaskPanel.Location = new System.Drawing.Point(3, 3);
            this.baseTaskPanel.Name = "baseTaskPanel";
            this.baseTaskPanel.Size = new System.Drawing.Size(543, 189);
            this.baseTaskPanel.TabIndex = 1;
            this.baseTaskPanel.TabStop = false;
            this.baseTaskPanel.Text = "Базовая задача";
            // 
            // baseTaskMainForm
            // 
            this.baseTaskMainForm.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.baseTaskMainForm.ColumnCount = 2;
            this.baseTaskMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.baseTaskMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.baseTaskMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.baseTaskMainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.baseTaskMainForm.Controls.Add(this.baseTaskContentPanel, 0, 0);
            this.baseTaskMainForm.Controls.Add(this.tasksForBaseTasks, 1, 0);
            this.baseTaskMainForm.Controls.Add(this.addBaseTask, 1, 1);
            this.baseTaskMainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTaskMainForm.Location = new System.Drawing.Point(3, 18);
            this.baseTaskMainForm.Name = "baseTaskMainForm";
            this.baseTaskMainForm.RowCount = 2;
            this.baseTaskMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.baseTaskMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.baseTaskMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.baseTaskMainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.baseTaskMainForm.Size = new System.Drawing.Size(537, 168);
            this.baseTaskMainForm.TabIndex = 0;
            // 
            // baseTaskContentPanel
            // 
            this.baseTaskContentPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.baseTaskContentPanel.ColumnCount = 2;
            this.baseTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.baseTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.baseTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.baseTaskContentPanel.Controls.Add(this.baseTaskName, 1, 0);
            this.baseTaskContentPanel.Controls.Add(this.baseTaskContent, 1, 1);
            this.baseTaskContentPanel.Controls.Add(this.baseTrueResult, 1, 2);
            this.baseTaskContentPanel.Controls.Add(this.baseFalseResult, 1, 3);
            this.baseTaskContentPanel.Controls.Add(this.label5, 0, 3);
            this.baseTaskContentPanel.Controls.Add(this.label6, 0, 2);
            this.baseTaskContentPanel.Controls.Add(this.label7, 0, 1);
            this.baseTaskContentPanel.Controls.Add(this.label8, 0, 0);
            this.baseTaskContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTaskContentPanel.Location = new System.Drawing.Point(4, 4);
            this.baseTaskContentPanel.Name = "baseTaskContentPanel";
            this.baseTaskContentPanel.RowCount = 4;
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.baseTaskContentPanel.Size = new System.Drawing.Size(341, 126);
            this.baseTaskContentPanel.TabIndex = 0;
            // 
            // baseTaskName
            // 
            this.baseTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTaskName.Location = new System.Drawing.Point(170, 4);
            this.baseTaskName.Name = "baseTaskName";
            this.baseTaskName.Size = new System.Drawing.Size(167, 22);
            this.baseTaskName.TabIndex = 0;
            // 
            // baseTaskContent
            // 
            this.baseTaskContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTaskContent.Location = new System.Drawing.Point(170, 35);
            this.baseTaskContent.Name = "baseTaskContent";
            this.baseTaskContent.Size = new System.Drawing.Size(167, 22);
            this.baseTaskContent.TabIndex = 1;
            // 
            // baseTrueResult
            // 
            this.baseTrueResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTrueResult.Location = new System.Drawing.Point(170, 66);
            this.baseTrueResult.Name = "baseTrueResult";
            this.baseTrueResult.Size = new System.Drawing.Size(167, 22);
            this.baseTrueResult.TabIndex = 2;
            // 
            // baseFalseResult
            // 
            this.baseFalseResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseFalseResult.Location = new System.Drawing.Point(170, 97);
            this.baseFalseResult.Name = "baseFalseResult";
            this.baseFalseResult.Size = new System.Drawing.Size(167, 22);
            this.baseFalseResult.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 31);
            this.label5.TabIndex = 4;
            this.label5.Text = "Неправильный ответ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "Правильный ответ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(4, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "Содержание задачи";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(4, 1);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 30);
            this.label8.TabIndex = 7;
            this.label8.Text = "Наименование задачи";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tasksForBaseTasks
            // 
            this.tasksForBaseTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksForBaseTasks.FormattingEnabled = true;
            this.tasksForBaseTasks.HorizontalScrollbar = true;
            this.tasksForBaseTasks.ItemHeight = 16;
            this.tasksForBaseTasks.Location = new System.Drawing.Point(352, 4);
            this.tasksForBaseTasks.Name = "tasksForBaseTasks";
            this.tasksForBaseTasks.Size = new System.Drawing.Size(181, 126);
            this.tasksForBaseTasks.TabIndex = 1;
            // 
            // addBaseTask
            // 
            this.addBaseTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addBaseTask.Location = new System.Drawing.Point(352, 137);
            this.addBaseTask.Name = "addBaseTask";
            this.addBaseTask.Size = new System.Drawing.Size(181, 27);
            this.addBaseTask.TabIndex = 2;
            this.addBaseTask.Text = "Добавить";
            this.addBaseTask.UseVisualStyleBackColor = true;
            this.addBaseTask.Click += new System.EventHandler(this.addBaseTask_Click);
            // 
            // derivedProblem
            // 
            this.derivedProblem.Controls.Add(this.derivedTasksPanel);
            this.derivedProblem.Location = new System.Drawing.Point(4, 25);
            this.derivedProblem.Name = "derivedProblem";
            this.derivedProblem.Size = new System.Drawing.Size(926, 389);
            this.derivedProblem.TabIndex = 2;
            this.derivedProblem.Text = "Производная задача";
            this.derivedProblem.UseVisualStyleBackColor = true;
            // 
            // derivedTasksPanel
            // 
            this.derivedTasksPanel.ColumnCount = 3;
            this.derivedTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.derivedTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.derivedTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.derivedTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.derivedTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.derivedTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.derivedTasksPanel.Controls.Add(this.tasksPanelInDerivedTask, 0, 0);
            this.derivedTasksPanel.Controls.Add(this.ready_madeDerivedTasksPanel, 2, 0);
            this.derivedTasksPanel.Controls.Add(this.derivedTasks, 1, 0);
            this.derivedTasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTasksPanel.Location = new System.Drawing.Point(0, 0);
            this.derivedTasksPanel.Margin = new System.Windows.Forms.Padding(0);
            this.derivedTasksPanel.Name = "derivedTasksPanel";
            this.derivedTasksPanel.RowCount = 1;
            this.derivedTasksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.derivedTasksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.derivedTasksPanel.Size = new System.Drawing.Size(926, 389);
            this.derivedTasksPanel.TabIndex = 2;
            // 
            // tasksPanelInDerivedTask
            // 
            this.tasksPanelInDerivedTask.Controls.Add(this.tasksInDerivedTask);
            this.tasksPanelInDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksPanelInDerivedTask.Location = new System.Drawing.Point(3, 3);
            this.tasksPanelInDerivedTask.Name = "tasksPanelInDerivedTask";
            this.tasksPanelInDerivedTask.Size = new System.Drawing.Size(179, 383);
            this.tasksPanelInDerivedTask.TabIndex = 12;
            // 
            // tasksInDerivedTask
            // 
            this.tasksInDerivedTask.ColumnCount = 1;
            this.tasksInDerivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tasksInDerivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tasksInDerivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tasksInDerivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tasksInDerivedTask.Controls.Add(this.groupBox4, 0, 2);
            this.tasksInDerivedTask.Controls.Add(this.groupB, 0, 1);
            this.tasksInDerivedTask.Controls.Add(this.elementaryTasksBoxInDerivedTask, 0, 0);
            this.tasksInDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksInDerivedTask.Location = new System.Drawing.Point(0, 0);
            this.tasksInDerivedTask.Name = "tasksInDerivedTask";
            this.tasksInDerivedTask.RowCount = 3;
            this.tasksInDerivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tasksInDerivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tasksInDerivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tasksInDerivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tasksInDerivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tasksInDerivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tasksInDerivedTask.Size = new System.Drawing.Size(179, 383);
            this.tasksInDerivedTask.TabIndex = 12;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.derivedTasksInDerivedTask);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 257);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(173, 123);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Производные задачи";
            // 
            // derivedTasksInDerivedTask
            // 
            this.derivedTasksInDerivedTask.CheckOnClick = true;
            this.derivedTasksInDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTasksInDerivedTask.FormattingEnabled = true;
            this.derivedTasksInDerivedTask.HorizontalScrollbar = true;
            this.derivedTasksInDerivedTask.Location = new System.Drawing.Point(3, 18);
            this.derivedTasksInDerivedTask.Name = "derivedTasksInDerivedTask";
            this.derivedTasksInDerivedTask.Size = new System.Drawing.Size(167, 102);
            this.derivedTasksInDerivedTask.TabIndex = 0;
            this.derivedTasksInDerivedTask.SelectedIndexChanged += new System.EventHandler(this.derivedTasksInDerivedTask_SelectedIndexChanged);
            // 
            // groupB
            // 
            this.groupB.Controls.Add(this.baseTasksInDerivedTask);
            this.groupB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupB.Location = new System.Drawing.Point(3, 130);
            this.groupB.Name = "groupB";
            this.groupB.Size = new System.Drawing.Size(173, 121);
            this.groupB.TabIndex = 0;
            this.groupB.TabStop = false;
            this.groupB.Text = "Базовые задачи";
            // 
            // baseTasksInDerivedTask
            // 
            this.baseTasksInDerivedTask.CheckOnClick = true;
            this.baseTasksInDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.baseTasksInDerivedTask.FormattingEnabled = true;
            this.baseTasksInDerivedTask.HorizontalScrollbar = true;
            this.baseTasksInDerivedTask.Location = new System.Drawing.Point(3, 18);
            this.baseTasksInDerivedTask.Name = "baseTasksInDerivedTask";
            this.baseTasksInDerivedTask.Size = new System.Drawing.Size(167, 100);
            this.baseTasksInDerivedTask.TabIndex = 0;
            this.baseTasksInDerivedTask.SelectedIndexChanged += new System.EventHandler(this.baseTasksInDerivedTask_SelectedIndexChanged);
            // 
            // elementaryTasksBoxInDerivedTask
            // 
            this.elementaryTasksBoxInDerivedTask.Controls.Add(this.elementaryTasksInDerivedTask);
            this.elementaryTasksBoxInDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryTasksBoxInDerivedTask.Location = new System.Drawing.Point(3, 3);
            this.elementaryTasksBoxInDerivedTask.Name = "elementaryTasksBoxInDerivedTask";
            this.elementaryTasksBoxInDerivedTask.Size = new System.Drawing.Size(173, 121);
            this.elementaryTasksBoxInDerivedTask.TabIndex = 0;
            this.elementaryTasksBoxInDerivedTask.TabStop = false;
            this.elementaryTasksBoxInDerivedTask.Text = "Элементраные задачи";
            // 
            // elementaryTasksInDerivedTask
            // 
            this.elementaryTasksInDerivedTask.CheckOnClick = true;
            this.elementaryTasksInDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elementaryTasksInDerivedTask.FormattingEnabled = true;
            this.elementaryTasksInDerivedTask.HorizontalScrollbar = true;
            this.elementaryTasksInDerivedTask.Location = new System.Drawing.Point(3, 18);
            this.elementaryTasksInDerivedTask.Name = "elementaryTasksInDerivedTask";
            this.elementaryTasksInDerivedTask.Size = new System.Drawing.Size(167, 100);
            this.elementaryTasksInDerivedTask.TabIndex = 8;
            this.elementaryTasksInDerivedTask.SelectedIndexChanged += new System.EventHandler(this.elementaryTasksInDerivedTask_SelectedIndexChanged);
            // 
            // ready_madeDerivedTasksPanel
            // 
            this.ready_madeDerivedTasksPanel.Controls.Add(this.ready_madeDerivedTasksInnerPanel);
            this.ready_madeDerivedTasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeDerivedTasksPanel.Location = new System.Drawing.Point(743, 3);
            this.ready_madeDerivedTasksPanel.Name = "ready_madeDerivedTasksPanel";
            this.ready_madeDerivedTasksPanel.Size = new System.Drawing.Size(180, 383);
            this.ready_madeDerivedTasksPanel.TabIndex = 6;
            this.ready_madeDerivedTasksPanel.TabStop = false;
            this.ready_madeDerivedTasksPanel.Text = "Экземпляры задач";
            // 
            // ready_madeDerivedTasksInnerPanel
            // 
            this.ready_madeDerivedTasksInnerPanel.AutoScroll = true;
            this.ready_madeDerivedTasksInnerPanel.Controls.Add(this.ready_madeDerivedTasks);
            this.ready_madeDerivedTasksInnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeDerivedTasksInnerPanel.Location = new System.Drawing.Point(3, 18);
            this.ready_madeDerivedTasksInnerPanel.Name = "ready_madeDerivedTasksInnerPanel";
            this.ready_madeDerivedTasksInnerPanel.Size = new System.Drawing.Size(174, 362);
            this.ready_madeDerivedTasksInnerPanel.TabIndex = 9;
            // 
            // ready_madeDerivedTasks
            // 
            this.ready_madeDerivedTasks.CheckOnClick = true;
            this.ready_madeDerivedTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ready_madeDerivedTasks.FormattingEnabled = true;
            this.ready_madeDerivedTasks.HorizontalScrollbar = true;
            this.ready_madeDerivedTasks.Location = new System.Drawing.Point(0, 0);
            this.ready_madeDerivedTasks.Name = "ready_madeDerivedTasks";
            this.ready_madeDerivedTasks.Size = new System.Drawing.Size(174, 362);
            this.ready_madeDerivedTasks.TabIndex = 8;
            // 
            // derivedTasks
            // 
            this.derivedTasks.AutoScroll = true;
            this.derivedTasks.BackColor = System.Drawing.Color.Transparent;
            this.derivedTasks.ColumnCount = 1;
            this.derivedTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.derivedTasks.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.derivedTasks.Controls.Add(this.derivedTaskGroupBox, 0, 0);
            this.derivedTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTasks.Location = new System.Drawing.Point(188, 3);
            this.derivedTasks.Name = "derivedTasks";
            this.derivedTasks.RowCount = 3;
            this.derivedTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.derivedTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.derivedTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.derivedTasks.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.derivedTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.derivedTasks.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.derivedTasks.Size = new System.Drawing.Size(549, 383);
            this.derivedTasks.TabIndex = 13;
            // 
            // derivedTaskGroupBox
            // 
            this.derivedTaskGroupBox.Controls.Add(this.derivedTask);
            this.derivedTaskGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTaskGroupBox.Location = new System.Drawing.Point(3, 3);
            this.derivedTaskGroupBox.Name = "derivedTaskGroupBox";
            this.derivedTaskGroupBox.Size = new System.Drawing.Size(543, 189);
            this.derivedTaskGroupBox.TabIndex = 0;
            this.derivedTaskGroupBox.TabStop = false;
            this.derivedTaskGroupBox.Text = "Производная задача";
            // 
            // derivedTask
            // 
            this.derivedTask.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.derivedTask.ColumnCount = 2;
            this.derivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.derivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.derivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.derivedTask.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.derivedTask.Controls.Add(this.derivedTaskContentPanel, 0, 0);
            this.derivedTask.Controls.Add(this.tasksForDerivedTask, 1, 0);
            this.derivedTask.Controls.Add(this.addDerivedTask, 1, 1);
            this.derivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTask.Location = new System.Drawing.Point(3, 18);
            this.derivedTask.Name = "derivedTask";
            this.derivedTask.RowCount = 2;
            this.derivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.derivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.derivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.derivedTask.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.derivedTask.Size = new System.Drawing.Size(537, 168);
            this.derivedTask.TabIndex = 0;
            // 
            // derivedTaskContentPanel
            // 
            this.derivedTaskContentPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.derivedTaskContentPanel.ColumnCount = 2;
            this.derivedTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.derivedTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.derivedTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.derivedTaskContentPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.derivedTaskContentPanel.Controls.Add(this.derivedTaskName, 1, 0);
            this.derivedTaskContentPanel.Controls.Add(this.derivedTaskContent, 1, 1);
            this.derivedTaskContentPanel.Controls.Add(this.derivedTaskTrueResult, 1, 2);
            this.derivedTaskContentPanel.Controls.Add(this.derivedTaskFalseResult, 1, 3);
            this.derivedTaskContentPanel.Controls.Add(this.label1, 0, 3);
            this.derivedTaskContentPanel.Controls.Add(this.label2, 0, 2);
            this.derivedTaskContentPanel.Controls.Add(this.label3, 0, 1);
            this.derivedTaskContentPanel.Controls.Add(this.label4, 0, 0);
            this.derivedTaskContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTaskContentPanel.Location = new System.Drawing.Point(4, 4);
            this.derivedTaskContentPanel.Name = "derivedTaskContentPanel";
            this.derivedTaskContentPanel.RowCount = 4;
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.derivedTaskContentPanel.Size = new System.Drawing.Size(341, 126);
            this.derivedTaskContentPanel.TabIndex = 0;
            // 
            // derivedTaskName
            // 
            this.derivedTaskName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTaskName.Location = new System.Drawing.Point(170, 4);
            this.derivedTaskName.Name = "derivedTaskName";
            this.derivedTaskName.Size = new System.Drawing.Size(167, 22);
            this.derivedTaskName.TabIndex = 0;
            // 
            // derivedTaskContent
            // 
            this.derivedTaskContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTaskContent.Location = new System.Drawing.Point(170, 35);
            this.derivedTaskContent.Name = "derivedTaskContent";
            this.derivedTaskContent.Size = new System.Drawing.Size(167, 22);
            this.derivedTaskContent.TabIndex = 1;
            // 
            // derivedTaskTrueResult
            // 
            this.derivedTaskTrueResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTaskTrueResult.Location = new System.Drawing.Point(170, 66);
            this.derivedTaskTrueResult.Name = "derivedTaskTrueResult";
            this.derivedTaskTrueResult.Size = new System.Drawing.Size(167, 22);
            this.derivedTaskTrueResult.TabIndex = 2;
            // 
            // derivedTaskFalseResult
            // 
            this.derivedTaskFalseResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.derivedTaskFalseResult.Location = new System.Drawing.Point(170, 97);
            this.derivedTaskFalseResult.Name = "derivedTaskFalseResult";
            this.derivedTaskFalseResult.Size = new System.Drawing.Size(167, 22);
            this.derivedTaskFalseResult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 31);
            this.label1.TabIndex = 4;
            this.label1.Text = "Неправильный ответ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 30);
            this.label2.TabIndex = 5;
            this.label2.Text = "Правильный ответ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 30);
            this.label3.TabIndex = 6;
            this.label3.Text = "Содержание задачи";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 30);
            this.label4.TabIndex = 7;
            this.label4.Text = "Наименование задачи";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tasksForDerivedTask
            // 
            this.tasksForDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tasksForDerivedTask.FormattingEnabled = true;
            this.tasksForDerivedTask.HorizontalScrollbar = true;
            this.tasksForDerivedTask.ItemHeight = 16;
            this.tasksForDerivedTask.Location = new System.Drawing.Point(352, 4);
            this.tasksForDerivedTask.Name = "tasksForDerivedTask";
            this.tasksForDerivedTask.Size = new System.Drawing.Size(181, 126);
            this.tasksForDerivedTask.TabIndex = 1;
            // 
            // addDerivedTask
            // 
            this.addDerivedTask.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addDerivedTask.Location = new System.Drawing.Point(352, 137);
            this.addDerivedTask.Name = "addDerivedTask";
            this.addDerivedTask.Size = new System.Drawing.Size(181, 27);
            this.addDerivedTask.TabIndex = 2;
            this.addDerivedTask.Text = "Добавить";
            this.addDerivedTask.UseVisualStyleBackColor = true;
            this.addDerivedTask.Click += new System.EventHandler(this.addDerivedTask_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tasksPage);
            this.tabControl1.Controls.Add(this.checkingPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1047, 453);
            this.tabControl1.TabIndex = 1;
            // 
            // tasksPage
            // 
            this.tasksPage.Controls.Add(this.panel1);
            this.tasksPage.Controls.Add(this.taskTabs);
            this.tasksPage.Location = new System.Drawing.Point(4, 25);
            this.tasksPage.Name = "tasksPage";
            this.tasksPage.Padding = new System.Windows.Forms.Padding(3);
            this.tasksPage.Size = new System.Drawing.Size(1039, 424);
            this.tasksPage.TabIndex = 0;
            this.tasksPage.Text = "Задачи";
            this.tasksPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.updateButton);
            this.panel1.Controls.Add(this.viewButton);
            this.panel1.Controls.Add(this.deleteButton);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Location = new System.Drawing.Point(942, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(94, 415);
            this.panel1.TabIndex = 2;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(3, 119);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(90, 23);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "Обновить";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // viewButton
            // 
            this.viewButton.Location = new System.Drawing.Point(3, 90);
            this.viewButton.Name = "viewButton";
            this.viewButton.Size = new System.Drawing.Size(90, 23);
            this.viewButton.TabIndex = 3;
            this.viewButton.Text = "Просмотр";
            this.viewButton.UseVisualStyleBackColor = true;
            this.viewButton.Click += new System.EventHandler(this.viewButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(3, 61);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(90, 23);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(3, 32);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(90, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Изменить";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(90, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // checkingPage
            // 
            this.checkingPage.Controls.Add(this.checkingTasksPanel);
            this.checkingPage.Location = new System.Drawing.Point(4, 25);
            this.checkingPage.Name = "checkingPage";
            this.checkingPage.Padding = new System.Windows.Forms.Padding(3);
            this.checkingPage.Size = new System.Drawing.Size(1039, 424);
            this.checkingPage.TabIndex = 1;
            this.checkingPage.Text = "Проверка";
            this.checkingPage.UseVisualStyleBackColor = true;
            this.checkingPage.Click += new System.EventHandler(this.checkingPage_Click);
            // 
            // checkingTasksPanel
            // 
            this.checkingTasksPanel.ColumnCount = 3;
            this.checkingTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.checkingTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.checkingTasksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.checkingTasksPanel.Controls.Add(this.dataGridView1, 0, 0);
            this.checkingTasksPanel.Controls.Add(this.groupBox1, 0, 0);
            this.checkingTasksPanel.Controls.Add(this.panel2, 2, 0);
            this.checkingTasksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkingTasksPanel.Location = new System.Drawing.Point(3, 3);
            this.checkingTasksPanel.Name = "checkingTasksPanel";
            this.checkingTasksPanel.RowCount = 1;
            this.checkingTasksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.checkingTasksPanel.Size = new System.Drawing.Size(1033, 418);
            this.checkingTasksPanel.TabIndex = 24;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { this.Column1, this.Column2, this.Column3, this.Column5, this.Column4 });
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(261, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(613, 412);
            this.dataGridView1.TabIndex = 22;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column1.HeaderText = "Наименвоание метода";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 167;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column2.HeaderText = "Наименование задачи";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 167;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "Правильность решения";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 150;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column5.HeaderText = "Результат проверки";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 154;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Column4.HeaderText = "Out Data";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 78;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.taskCheckMethods);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(252, 412);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Методы проверок";
            // 
            // taskCheckMethods
            // 
            this.taskCheckMethods.CheckOnClick = true;
            this.taskCheckMethods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.taskCheckMethods.FormattingEnabled = true;
            this.taskCheckMethods.HorizontalScrollbar = true;
            this.taskCheckMethods.Location = new System.Drawing.Point(3, 18);
            this.taskCheckMethods.Name = "taskCheckMethods";
            this.taskCheckMethods.Size = new System.Drawing.Size(246, 391);
            this.taskCheckMethods.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.featureNames);
            this.panel2.Controls.Add(this.viewButtonInCheckingWindow);
            this.panel2.Controls.Add(this.exportButton);
            this.panel2.Controls.Add(this.comparer);
            this.panel2.Controls.Add(this.read);
            this.panel2.Controls.Add(this.connect);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(880, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 412);
            this.panel2.TabIndex = 23;
            // 
            // viewButtonInCheckingWindow
            // 
            this.viewButtonInCheckingWindow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.viewButtonInCheckingWindow.Location = new System.Drawing.Point(3, 151);
            this.viewButtonInCheckingWindow.Name = "viewButtonInCheckingWindow";
            this.viewButtonInCheckingWindow.Size = new System.Drawing.Size(144, 31);
            this.viewButtonInCheckingWindow.TabIndex = 28;
            this.viewButtonInCheckingWindow.Text = "Просмотр";
            this.viewButtonInCheckingWindow.UseVisualStyleBackColor = true;
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Location = new System.Drawing.Point(3, 40);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(144, 31);
            this.exportButton.TabIndex = 27;
            this.exportButton.Text = "Импорт";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // comparer
            // 
            this.comparer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.comparer.Location = new System.Drawing.Point(3, 114);
            this.comparer.Name = "comparer";
            this.comparer.Size = new System.Drawing.Size(144, 31);
            this.comparer.TabIndex = 26;
            this.comparer.Text = "Проверить";
            this.comparer.UseVisualStyleBackColor = true;
            // 
            // read
            // 
            this.read.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.read.Location = new System.Drawing.Point(3, 77);
            this.read.Name = "read";
            this.read.Size = new System.Drawing.Size(144, 31);
            this.read.TabIndex = 25;
            this.read.Text = "Чтение";
            this.read.UseVisualStyleBackColor = true;
            this.read.Click += new System.EventHandler(this.read_Click);
            // 
            // connect
            // 
            this.connect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.connect.Location = new System.Drawing.Point(3, 3);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(144, 31);
            this.connect.TabIndex = 24;
            this.connect.Text = "Подключиться\r\n";
            this.connect.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.deleteStripItem });
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(119, 26);
            // 
            // deleteStripItem
            // 
            this.deleteStripItem.Name = "deleteStripItem";
            this.deleteStripItem.Size = new System.Drawing.Size(118, 22);
            this.deleteStripItem.Text = "Удалить";
            this.deleteStripItem.Click += new System.EventHandler(this.deleteStripItem_Click);
            // 
            // featureNames
            // 
            this.featureNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.featureNames.FormattingEnabled = true;
            this.featureNames.Location = new System.Drawing.Point(0, 385);
            this.featureNames.Name = "featureNames";
            this.featureNames.Size = new System.Drawing.Size(147, 24);
            this.featureNames.TabIndex = 29;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1047, 453);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Location = new System.Drawing.Point(15, 15);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1063, 492);
            this.Name = "MainForm";
            this.taskTabs.ResumeLayout(false);
            this.elementaryTask.ResumeLayout(false);
            this.elementaryTasks.ResumeLayout(false);
            this.elementaryCheckMethodsPanel.ResumeLayout(false);
            this.elementaryCheckMethods.ResumeLayout(false);
            this.ready_madeElementaryTasksPanel.ResumeLayout(false);
            this.basicTask.ResumeLayout(false);
            this.baseTaskMainLayoutPanel.ResumeLayout(false);
            this.tasksForBaseTasksLayoutPanel.ResumeLayout(false);
            this.baseTasksForBaseTaskGroupBox.ResumeLayout(false);
            this.elementaryTasksForBaseTaskGroupBox.ResumeLayout(false);
            this.ready_madeBaseTasksPanel.ResumeLayout(false);
            this.basesTasks.ResumeLayout(false);
            this.baseTaskPanel.ResumeLayout(false);
            this.baseTaskMainForm.ResumeLayout(false);
            this.baseTaskContentPanel.ResumeLayout(false);
            this.baseTaskContentPanel.PerformLayout();
            this.derivedProblem.ResumeLayout(false);
            this.derivedTasksPanel.ResumeLayout(false);
            this.tasksPanelInDerivedTask.ResumeLayout(false);
            this.tasksInDerivedTask.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupB.ResumeLayout(false);
            this.elementaryTasksBoxInDerivedTask.ResumeLayout(false);
            this.ready_madeDerivedTasksPanel.ResumeLayout(false);
            this.ready_madeDerivedTasksInnerPanel.ResumeLayout(false);
            this.derivedTasks.ResumeLayout(false);
            this.derivedTaskGroupBox.ResumeLayout(false);
            this.derivedTask.ResumeLayout(false);
            this.derivedTaskContentPanel.ResumeLayout(false);
            this.derivedTaskContentPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tasksPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.checkingPage.ResumeLayout(false);
            this.checkingTasksPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
    }

        private System.Windows.Forms.ComboBox featureNames;

        private System.Windows.Forms.Button viewButtonInCheckingWindow;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button comparer;
        private System.Windows.Forms.Button read;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Panel panel2;

        private System.Windows.Forms.TableLayoutPanel checkingTasksPanel;

        private System.Windows.Forms.GroupBox baseTaskPanel;
        private System.Windows.Forms.TableLayoutPanel baseTaskMainForm;
        private System.Windows.Forms.TableLayoutPanel baseTaskContentPanel;
        private System.Windows.Forms.TextBox baseTaskName;
        private System.Windows.Forms.TextBox baseTaskContent;
        private System.Windows.Forms.TextBox baseTrueResult;
        private System.Windows.Forms.TextBox baseFalseResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox tasksForBaseTasks;
        private System.Windows.Forms.Button addBaseTask;

        private System.Windows.Forms.TableLayoutPanel basesTasks;

        private System.Windows.Forms.CheckedListBox ready_madeElementaryTasks;

        private System.Windows.Forms.CheckedListBox checkedElementaryCheckMethods;

        private System.Windows.Forms.CheckedListBox ready_madeBaseTasks;

        private System.Windows.Forms.CheckedListBox baseTasksForBaseTaskСheckedListBox;

        private System.Windows.Forms.GroupBox ready_madeBaseTasksPanel;

        private System.Windows.Forms.GroupBox baseTasksForBaseTaskGroupBox;
        private System.Windows.Forms.CheckedListBox elementaryTasksForBaseTaskСheckedListBox;

        private System.Windows.Forms.GroupBox elementaryTasksForBaseTaskGroupBox;

        private System.Windows.Forms.TableLayoutPanel tasksForBaseTasksLayoutPanel;

        private System.Windows.Forms.TableLayoutPanel baseTaskMainLayoutPanel;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;

        private System.Windows.Forms.DataGridViewButtonColumn Column3;

        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;

        private System.Windows.Forms.DataGridView dataGridView1;

        private System.Windows.Forms.Button addDerivedTask;

        private System.Windows.Forms.ListBox tasksForDerivedTask;

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.TextBox derivedTaskName;
        private System.Windows.Forms.TextBox derivedTaskContent;
        private System.Windows.Forms.TextBox derivedTaskTrueResult;
        private System.Windows.Forms.TextBox derivedTaskFalseResult;

        private System.Windows.Forms.TableLayoutPanel derivedTaskContentPanel;

        private System.Windows.Forms.TableLayoutPanel derivedTask;

        private System.Windows.Forms.GroupBox derivedTaskGroupBox;

        private System.Windows.Forms.TableLayoutPanel derivedTasks;

        private System.Windows.Forms.TableLayoutPanel elementaryTaskForms;

        private System.Windows.Forms.Button updateButton;

        private System.Windows.Forms.Button viewButton;

        private System.Windows.Forms.CheckedListBox baseTasksInDerivedTask;

        private System.Windows.Forms.CheckedListBox derivedTasksInDerivedTask;

        private System.Windows.Forms.TableLayoutPanel tasksInDerivedTask;

        private System.Windows.Forms.GroupBox groupBox4;

        private System.Windows.Forms.GroupBox groupB;
        private System.Windows.Forms.Panel tasksPanelInDerivedTask;

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;

        private System.Windows.Forms.Panel panel1;

        private System.Windows.Forms.ToolStripMenuItem deleteStripItem;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;

        private System.Windows.Forms.CheckedListBox elementaryTasksInDerivedTask;

        private System.Windows.Forms.Panel ready_madeDerivedTasksInnerPanel;

        private System.Windows.Forms.GroupBox elementaryTasksBoxInDerivedTask;

        private System.Windows.Forms.GroupBox ready_madeDerivedTasksPanel;
        private System.Windows.Forms.CheckedListBox ready_madeDerivedTasks;

        private System.Windows.Forms.TableLayoutPanel derivedTasksPanel;

        private System.Windows.Forms.TabControl taskTabs;

        private System.Windows.Forms.TabPage tasksPage;
        private System.Windows.Forms.TabPage checkingPage;


        private System.Windows.Forms.GroupBox ready_madeElementaryTasksPanel;

        private System.Windows.Forms.GroupBox elementaryCheckMethods;

        private System.Windows.Forms.TabPage derivedProblem;

        private System.Windows.Forms.CheckedListBox taskCheckMethods;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.Panel elementaryCheckMethodsPanel;

        private System.Windows.Forms.TableLayoutPanel elementaryTasks;

        private System.Windows.Forms.TabPage basicTask;

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage elementaryTask;

        #endregion
    
}