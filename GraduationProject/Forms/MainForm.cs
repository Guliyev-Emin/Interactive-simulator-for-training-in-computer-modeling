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

public partial class MainForm : Form
{
    private static int _step;

    public MainForm()
    {
        InitializeComponent();
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
        if (!Connection.ConnectionTest()) return;
        switch (_step)
        {
            case 0:
            {
                Сonstruction.Step1();
                _step++;
                break;
            }
            case 1:
            {
                Сonstruction.Step2();
                //Сonstruction.Step5();
                _step++;
                break;
            }
            case 2:
            {
                Сonstruction.Step3();
                //Сonstruction.Step2();
                _step++;
                break;
            }
            case 3:
            {
                Сonstruction.Step4();
                //Сonstruction.Step3();
                _step++;
                break;
            }
            case 4:
            {
                Сonstruction.Step5();
                //Сonstruction.Step4();
                _step++;
                break;
            }
        }
    }

    private void FullDrawingToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (!Connection.ConnectionTest()) return;
        Сonstruction.Step1();
        Сonstruction.Step2();
        Сonstruction.Step3();
        Сonstruction.Step4();
        Сonstruction.Step5();
    }

    private void StepDeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest())
            Remove.StepRemove();
    }

    private void FullDeleteToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (Connection.ConnectionTest())
            Remove.RemoveFeature();
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
        if (string.IsNullOrWhiteSpace(modelVariant))
            return;

        FileController.SavingModelPropertiesToAFile(modelVariant);
    }
    
    private void modelValidationButton_Click(object sender, EventArgs e)
    {
        ValidationModel(GetModelVariantDialog(@"Выбор модели", @"Модель № ", @"Проверить"));
    }
    
    private void GetSolidWorksProjectTree()
    {
        SolidWorksProjectTree.Nodes.Clear();
        SolidWorksProjectTree.BeginUpdate();
        Reader.SolidWorksProjectTree = new TreeNode("Дерево проекта");
        Reader.SketchInfos = new List<SketchInfo>();
        var treeNode = Reader.ProjectReading(
            Connection.SwFeatureManager.GetFeatureTreeRootItem2((int)swFeatMgrPane_e.swFeatMgrPaneBottom));
        treeNode.Expand();
        SolidWorksProjectTree.Nodes.Add(treeNode);
        SolidWorksProjectTree.EndUpdate();
        modelValidationButton.Visible = true;
    }
    
    private string GetModelVariantDialog(string title, string caption, string buttonCaption)
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

        return modelVariantForm.ShowDialog() == DialogResult.OK ? modelVariantText.Text : "";
    }
    
    private void ValidationModel(string modelVariant)
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

}