using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using GraduationProject.Construction;
using GraduationProject.Controllers;
using GraduationProject.Model.Models;
using SolidWorks.Interop.swconst;

namespace GraduationProject;

public partial class ReadForm : Form
{
    
    public ReadForm()
    {
        InitializeComponent();
    }

    public void SetSolidWorksProjectTree()
    {
        SolidWorksProjectTree.BeginUpdate();
        Reader.SolidWorksProjectTree = new TreeNode("Открыть дерево проекта");
        Reader.SketchInfos = new List<SketchInfo>();
        var treeNode = Reader.ProjectReading(
            Connection.FeatureManager.GetFeatureTreeRootItem2((int)swFeatMgrPane_e.swFeatMgrPaneBottom));
        treeNode.Expand();
        SolidWorksProjectTree.Nodes.Add(treeNode);
        SolidWorksProjectTree.EndUpdate();
    }

    private void exit_buttonClick(object sender, EventArgs eventArgs)
    {
        Close();
    }

    private void reReading_Click(object sender, EventArgs e)
    {
        SolidWorksProjectTree.Nodes.Clear();
        SetSolidWorksProjectTree();
    }

    private void writeToFile_Click(object sender, EventArgs e)
    {
        var modelVariant = GetModelVariantDialog(@"Добавление модели", @"Модель № ", @"Сохранить");
        if (string.IsNullOrWhiteSpace(modelVariant))
            return;

        FileController.SavingModelPropertiesToAFile(modelVariant);
    }

    private static string GetModelVariantDialog(string title, string caption, string buttonCaption)
    {
        var modelVariantForm = new Form
        {
            FormBorderStyle = FormBorderStyle.FixedDialog,
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
            DialogResult = DialogResult.OK,
            
        };
        
        confirmation.Click += (_, _) => { modelVariantForm.Close(); };
        modelVariantForm.Controls.Add(modelVariantText);
        modelVariantForm.Controls.Add(confirmation);
        modelVariantForm.Controls.Add(modelVariantLabel);
        modelVariantForm.AcceptButton = confirmation;

        return modelVariantForm.ShowDialog() == DialogResult.OK ? modelVariantText.Text : "";
    }

    private void ComparerModel(string modelVariant)
    {
        initialModelPropertiesTextBox.Text = FileController.GetModelTextSketchesFromFile(modelVariant);
        userModelPropertiesTextBox.Text = FileController.CreateTemplateModelProperties();
        errorQualityResultTextBox.Text = string.Empty;
        correctQualityResultTextBox.Text = string.Empty;
        
        var comparer = Controller.Comparer(modelVariant);
        if (comparer is null) return;
        foreach (var comparerResults in comparer)
            comparerResults.ForEach(comparerObjectResults =>
            {
                comparerObjectResults.ForEach(comparerResult =>
                {
                    foreach (var correct in comparerResult.correct.Where(correct =>
                                 !Regex.IsMatch(correctQualityResultTextBox.Text,
                                     $@"\w*{comparerResult.correct[0]}\w*") ||
                                 !correct.Equals(comparerResult.correct[0])))
                        correctQualityResultTextBox.Text += correct.Replace("\n", Environment.NewLine);

                    foreach (var error in comparerResult.error.Where(error =>
                                 !Regex.IsMatch(errorQualityResultTextBox.Text, $@"\w*{comparerResult.error[0]}\w*") ||
                                 !error.Equals(comparerResult.error[0])))
                        errorQualityResultTextBox.Text += error.Replace("\n", Environment.NewLine);
                });
            });
    }

    private void button1_Click(object sender, EventArgs e)
    {
        ComparerModel(GetModelVariantDialog(@"Выбор модели", @"Модель № ", @"Проверить"));
    }
}