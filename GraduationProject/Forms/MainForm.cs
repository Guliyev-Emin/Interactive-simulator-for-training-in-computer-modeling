using System;
using System.Drawing;
using System.Windows.Forms;
using GraduationProject.Controllers;
using GraduationProject.SolidWorks_Algorithms;

namespace GraduationProject;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        testToolStripMenuItem.Visible = false;
        Rendering.Visible = false;
    }

    private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Connection.AppConnection();
    }

    private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        throw new NotImplementedException();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
        Environment.Exit(0);
    }

    private void StepDrawingToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void FullDrawingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var modelVariant = GetModelVariantDialog(@"Отрисовка модели", @"Модель № ", @"Начертить");
        if (modelVariant is null)
            return;
        ConstructionModel.Drawing(modelVariant);
    }

    private void StepDeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest())
            RemoveModel.StepRemove();
    }

    private void FullDeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest())
            RemoveModel.RemoveFeature();
    }

    private void TreeReadToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ProjectTabControl.SelectTab(Reading);
        GetSolidWorksProjectTree();
    }

    private void readingSolidWorksProjectButton_Click(object sender, EventArgs e)
    {
        GetSolidWorksProjectTree();
    }

    private void saveModelButton_Click(object sender, EventArgs e)
    {
        var modelVariant = GetModelVariantDialog(@"Добавление модели", @"Модель № ", @"Сохранить");
        if (modelVariant is null)
            return;
        if (string.IsNullOrWhiteSpace(modelVariant))
            return;

        FileController.SavingModelPropertiesToAFile(modelVariant);
    }

    private void modelValidationButton_Click(object sender, EventArgs e)
    {
        var modelVariant = GetModelVariantDialog(@"Выбор модели", @"Модель № ", @"Проверить");
        if (modelVariant is null)
            return;
        ValidationModel(modelVariant);
    }

    private void GetSolidWorksProjectTree()
    {
        if (!ReadingModel.GetProjectTree(ref SolidWorksProjectTree))
            return;
        modelValidationButton.Visible = true;
        userModelPropertiesTextBox.Text = FileController.CreateTemplateModelProperties();
    }

    private static string GetModelVariantDialog(string title, string caption, string buttonCaption)
    {
        var modelVariantForm = new Form
        {
            FormBorderStyle = FormBorderStyle.FixedToolWindow,
            AutoScaleMode = AutoScaleMode.Font,
            Text = title,
            StartPosition = FormStartPosition.CenterScreen,
            AutoScaleDimensions = new SizeF(8F, 16F),
            Width = 240,
            Height = 120
        };

        var modelVariantLabel = new Label
        {
            Location = new Point(13, 9),
            Size = new Size(82, 29),
            Margin = new Padding(4, 0, 4, 0),
            Text = caption,
            TextAlign = ContentAlignment.MiddleCenter
        };

        var modelVariantText = new TextBox
        {
            Location = new Point(102, 12),
            Size = new Size(105, 22)
        };

        var confirmation = new Button
        {
            Text = buttonCaption,
            Location = new Point(126, 41),
            Margin = new Padding(4),
            Size = new Size(81, 26),
            DialogResult = DialogResult.OK
        };

        confirmation.Click += (_, _) => { modelVariantForm.Close(); };
        modelVariantForm.Controls.Add(modelVariantText);
        modelVariantForm.Controls.Add(confirmation);
        modelVariantForm.Controls.Add(modelVariantLabel);
        modelVariantForm.AcceptButton = confirmation;

        return modelVariantForm.ShowDialog() == DialogResult.OK ? modelVariantText.Text : null;
    }

    private void ValidationModel(string modelVariant)
    {
        if (modelVariant is null)
            return;
        initialModelPropertiesTextBox.Text = FileController.GetModelTextSketchesFromFile(modelVariant);
        userModelPropertiesTextBox.Text = FileController.CreateTemplateModelProperties();
        correctQualityResultTreeView.Nodes.Clear();
        correctQualityResultTreeView.BeginUpdate();
        errorQualityResultTreeView.Nodes.Clear();
        errorQualityResultTreeView.BeginUpdate();
        var comparerResult = Controller.ModelValidationController(modelVariant);
        if (comparerResult is not null)
        {
            var correct = comparerResult.Value.CorrectNodes;
            correct.Expand();
            var error = comparerResult.Value.ErrorNodes;
            error.Expand();

            correctQualityResultTreeView.Nodes.Add(correct);
            errorQualityResultTreeView.Nodes.Add(error);
        }
        correctQualityResultTreeView.EndUpdate();
        errorQualityResultTreeView.EndUpdate();
    }
}