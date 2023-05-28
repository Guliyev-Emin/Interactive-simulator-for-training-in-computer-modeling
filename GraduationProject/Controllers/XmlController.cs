using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using GraduationProject.ModelObjects.Objects;
using GraduationProject.ModelObjects.Objects.CheckObjects;
using GraduationProject.ModelObjects.Objects.SketchObjects;

namespace GraduationProject.Controllers;

public class XmlController

{
    private const string ControllingPath = @"../../Files/PropertiesOfAlgorithms/";
    private const string ControllingTwoDOperations = "twoDOperations";
    private const string ControllingTridimensionalOperation = "tridimensionalOperation";
    private const string ControllingDerivedTask = "derivedTask";
    private const string ControllingElementaryTask = "elementaryTask";
    private const string ControllingBaseTask = "baseTask";
    private const string ControllingTaskName = "taskName";
    private const string ControllingTaskContent = "taskContent";
    private const string ControllingTaskTrueResult = "taskTrueResult";
    private const string ControllingTaskFalseResult = "taskFalseResult";
    private const string ControllingTaskObjectCount = "taskObjectCount";
    private const string ControllingTaskReverse = "taskReversSolution";
    private const string ControllingSequenceTxt = "sequence";
    private const string ControllingMethodName = "methodName";
    private const string ControllingCheckType = "checkType";
    private const string ControllingLineStartX = "lineStartX";
    private const string ControllingLineStartY = "lineStartY";
    private const string ControllingLineStartZ = "lineStartZ";
    private const string ControllingLineEndX = "lineEndX";
    private const string ControllingLineEndY = "lineEndY";
    private const string ControllingLineEndZ = "lineEndZ";
    private const string ControllingPointX = "pointX";
    private const string ControllingPointY = "pointY";
    private const string ControllingPointZ = "pointZ";
    private const string ControllingId = "id";
    private const string ControllingType = "type";
    private const string ControllingLength = "length";
    private const string ControllingRadius = "radius";
    private const string ControllingCut = "Cut";
    private const string ControllingExtrusioan = "Extrusion";
    private static XmlDocument _document;

    private static XmlElement CreateElement(string name, string text)
    {
        var element = _document.CreateElement(name);
        element.AppendChild(_document.CreateTextNode(text));
        return element;
    }

    private static XmlElement CreateElement(string name)
    {
        return _document.CreateElement(name);
    }

    private static XmlAttribute CreateAttribute(string name, string text)
    {
        var attribute = _document.CreateAttribute(name);
        attribute.AppendChild(_document.CreateTextNode(text));
        return attribute;
    }

    /// <summary>
    /// Метод по созданию структуры XML для элементарных задач
    /// </summary>
    /// <param name="elementaryTask">Элементарная задача</param>
    /// <returns>Структура xml с параметрами для элементарных задач</returns>
    private static XmlElement AddElementaryTask(ElementaryTask elementaryTask)
    {
        var elementaryTaskElement = CreateElement(ControllingElementaryTask);
        elementaryTaskElement.Attributes.Append(CreateAttribute(ControllingId, elementaryTask.Id.ToString()));
        elementaryTaskElement.Attributes.Append(CreateAttribute(ControllingMethodName, elementaryTask.MethodName));
        elementaryTaskElement.Attributes.Append(CreateAttribute(ControllingType, elementaryTask.Type));
        elementaryTaskElement.Attributes.Append(CreateAttribute(ControllingCheckType, elementaryTask.CheckType));
        elementaryTaskElement.AppendChild(CreateElement(ControllingTaskName, elementaryTask.TaskName));
        elementaryTaskElement.AppendChild(CreateElement(ControllingTaskContent, elementaryTask.TaskContent));
        elementaryTaskElement.AppendChild(CreateElement(ControllingTaskTrueResult, elementaryTask.TaskTrueResult));
        elementaryTaskElement.AppendChild(CreateElement(ControllingTaskFalseResult, elementaryTask.TaskFalseResult));
        if (elementaryTask.CountTask is not null)
        {
            elementaryTaskElement.AppendChild(CreateElement(ControllingTaskObjectCount,
                elementaryTask.CountTask.ObjectCount.ToString()));
        }
        else if (elementaryTask.PointTask is not null)
        {
            if (elementaryTask.PointTask.Point is not null)
            {
                elementaryTaskElement.AppendChild(CreateElement(ControllingPointX,
                    elementaryTask.PointTask.Point.X.ToString(CultureInfo.InvariantCulture)));
                elementaryTaskElement.AppendChild(CreateElement(ControllingPointY,
                    elementaryTask.PointTask.Point.Y.ToString(CultureInfo.InvariantCulture)));
                elementaryTaskElement.AppendChild(CreateElement(ControllingPointZ,
                    elementaryTask.PointTask.Point.Z.ToString(CultureInfo.InvariantCulture)));
            }
        }
        else if (elementaryTask.TridimensionalOperation is not null)
        {
            elementaryTaskElement.AppendChild(CreateElement(elementaryTask.Type,
                elementaryTask.TridimensionalOperation.Depth.ToString(CultureInfo.InvariantCulture)));
        }
        else
        {
            if (elementaryTask.PointTask != null && elementaryTask.PointTask.Line?.Length != null)
                elementaryTaskElement.AppendChild(CreateElement(ControllingLength,
                    elementaryTask.PointTask.Line.Length.ToString(CultureInfo.InvariantCulture)));
            if (elementaryTask.PointTask != null && elementaryTask.PointTask.Arc?.ArcRadius != null)
                elementaryTaskElement.AppendChild(CreateElement(ControllingRadius,
                    elementaryTask.PointTask.Arc?.ArcRadius.ToString(CultureInfo.InvariantCulture)));
        }

        elementaryTaskElement.AppendChild(CreateElement(ControllingTaskReverse, elementaryTask.Reverse.ToString()));
        return elementaryTaskElement;
    }

    /// <summary>
    /// Метод по созданию структуры XML для базовых задач
    /// </summary>
    /// <param name="baseTask">Базовая задача</param>
    /// <returns>Структура xml с параметрами для базовых задач</returns>
    private static XmlElement AddBaseTaskElement(BaseTask baseTask)
    {
        var baseTaskElement = CreateElement(ControllingBaseTask);
        baseTaskElement.Attributes.Append(CreateAttribute(ControllingId, baseTask.Id.ToString()));
        baseTaskElement.Attributes.Append(CreateAttribute(ControllingMethodName, baseTask.MethodName));
        baseTaskElement.AppendChild(CreateElement(ControllingTaskName, baseTask.TaskName));
        baseTaskElement.AppendChild(CreateElement(ControllingTaskContent, baseTask.TaskContent));
        baseTaskElement.AppendChild(CreateElement(ControllingTaskTrueResult, baseTask.TaskTrueResult));
        baseTaskElement.AppendChild(CreateElement(ControllingTaskFalseResult, baseTask.TaskFalseResult));
        
        if (baseTask.ElementaryTasks is not null)
            foreach (var elementaryTask in baseTask.ElementaryTasks)
                baseTaskElement?.AppendChild(AddElementaryTask(elementaryTask));

        if (baseTask.BaseTasks is not null && baseTask.BaseTasks.Count > 0)
        {
            foreach (var task in baseTask.BaseTasks)
                baseTaskElement?.AppendChild(AddBaseTaskElement(task));
            
        }
        
        baseTaskElement.AppendChild(CreateElement(ControllingSequenceTxt,
            baseTask.Sequence.Aggregate((first, second) => $@"{first}, {second}")));
        return baseTaskElement;
    }

    /// <summary>
    /// Метод по созданию структуры XML для производных задач
    /// </summary>
    /// <param name="derivedTask">Производная задача</param>
    /// <returns>Структура xml с параметрами для производных задач</returns>
    private static XmlElement AddDerivedTaskElemnt(DerivedTask derivedTask)
    {
        var derivedTaskElement = CreateElement(ControllingDerivedTask);
        derivedTaskElement.Attributes.Append(CreateAttribute(ControllingId, derivedTask.Id.ToString()));
        derivedTaskElement.Attributes.Append(CreateAttribute(ControllingMethodName, derivedTask.MethodName));
        derivedTaskElement.AppendChild(CreateElement(ControllingTaskName, derivedTask.TaskName));
        derivedTaskElement.AppendChild(CreateElement(ControllingTaskContent, derivedTask.TaskContent));
        derivedTaskElement.AppendChild(CreateElement(ControllingTaskTrueResult, derivedTask.TaskTrueResult));
        derivedTaskElement.AppendChild(CreateElement(ControllingTaskFalseResult, derivedTask.TaskFalseResult));
        derivedTaskElement.AppendChild(CreateElement(ControllingSequenceTxt,
            derivedTask.Sequence.Aggregate((first, second) => $@"{first}, {second}")));
        return derivedTaskElement;
    }

    /// <summary>
    ///     Рекурсивный метод создания узлов производных задач в XML файле
    /// </summary>
    /// <param name="derivedTasks">Список производных задач</param>
    /// <param name="derivedTaskElements">Ссылка на список узлов производных задач</param>
    /// <param name="twoDOperationsElement">Ссылка на узел двух мерных задач</param>
    /// <param name="derivedTaskElement">Ссылка на родительский узел производной задачи</param>
    private static void CreateDerivedTaskElement(List<DerivedTask> derivedTasks,
        ref List<XmlElement> derivedTaskElements, ref XmlElement twoDOperationsElement,
        ref XmlElement derivedTaskElement)
    {
        foreach (var derivedTask in derivedTasks)
        {
            if (derivedTaskElement is null)
                derivedTaskElement = AddDerivedTaskElemnt(derivedTask);
            else
                derivedTaskElement?.AppendChild(AddDerivedTaskElemnt(derivedTask));

            if (derivedTask.ElementaryTasks is not null)
                foreach (var elementaryTask in derivedTask.ElementaryTasks)
                    derivedTaskElement?.AppendChild(AddElementaryTask(elementaryTask));

            if (derivedTask.BaseTasks is not null)
                foreach (var baseTask in derivedTask.BaseTasks)
                {
                    derivedTaskElement?.AppendChild(AddBaseTaskElement(baseTask));
                }
            
            if (derivedTask.DerivedTasks is not null && derivedTask.DerivedTasks.Count != 0)
            {
                XmlElement newDerivedTaskElement = null;
                CreateDerivedTaskElement(derivedTask.DerivedTasks, ref derivedTaskElements,
                    ref twoDOperationsElement, ref newDerivedTaskElement);
                derivedTaskElement!.AppendChild(newDerivedTaskElement);
            }

            derivedTaskElements.Add(derivedTaskElement!);
            twoDOperationsElement.AppendChild(derivedTaskElement!);
        }
    }

    /// <summary>
    ///     Метод по сохранению произыодных задач в файл
    /// </summary>
    /// <param name="fileName">Название файла</param>
    /// <param name="derivedTasks">Списов производных задач</param>
    public static void CreateDerivedFile(string fileName, List<DerivedTask> derivedTasks)
    {
        _document = new XmlDocument();
        if (!Directory.Exists(ControllingPath))
            Directory.CreateDirectory(ControllingPath.Remove(ControllingPath.Length - 1));
        
        if (File.Exists(ControllingPath + fileName + ".xml"))
            _document.Load(ControllingPath + fileName + ".xml");
        var xRoot = _document.DocumentElement;
        var twoDOperationsElement = CreateElement(ControllingTwoDOperations);
        twoDOperationsElement.Attributes.Append(CreateAttribute(ControllingMethodName, "Эскиз1"));
        var derivedTaskElements = new List<XmlElement>();
        XmlElement taskElement = null;
        CreateDerivedTaskElement(derivedTasks, ref derivedTaskElements, ref twoDOperationsElement, ref taskElement);

        if (_document.ChildNodes[0] == null || !_document.ChildNodes[0].Name.Equals(ControllingTwoDOperations))
            _document.AppendChild(twoDOperationsElement);
        else
            foreach (var derivedTaskElement in derivedTaskElements)
                xRoot!.AppendChild(derivedTaskElement);

        _document.Save(ControllingPath + fileName + ".xml");
    }

    private static ElementaryTask ElementaryTaskRead(XmlNode element)
    {
        var elementaryTask = new ElementaryTask();
        if (element.Attributes != null)
            foreach (XmlAttribute attribute in element.Attributes)
                switch (attribute.Name)
                {
                    case ControllingId:
                        elementaryTask.Id = Convert.ToUInt32(attribute.Value);
                        continue;
                    case ControllingMethodName:
                        elementaryTask.MethodName = attribute.Value;
                        continue;
                    case ControllingType:
                        elementaryTask.Type = attribute.Value;
                        continue;
                    case ControllingCheckType:
                        elementaryTask.CheckType = attribute.Value;
                        continue;
                }

        foreach (XmlElement elementaryTaskNode in element.ChildNodes)
            switch (elementaryTaskNode.Name)
            {
                case ControllingTaskName:
                    elementaryTask.TaskName = elementaryTaskNode.InnerText;
                    continue;
                case ControllingTaskContent:
                    elementaryTask.TaskContent = elementaryTaskNode.InnerText;
                    continue;
                case ControllingTaskObjectCount:
                    elementaryTask.CountTask ??= new CountTask();
                    elementaryTask.CountTask.ObjectCount =
                        Convert.ToUInt32(elementaryTaskNode.InnerText);
                    continue;
                case ControllingTaskTrueResult:
                    elementaryTask.TaskTrueResult = elementaryTaskNode.InnerText;
                    continue;
                case ControllingTaskFalseResult:
                    elementaryTask.TaskFalseResult = elementaryTaskNode.InnerText;
                    continue;
                case ControllingTaskReverse:
                    elementaryTask.Reverse = Convert.ToBoolean(elementaryTaskNode.InnerText);
                    continue;
                case ControllingPointX:
                    elementaryTask.PointTask ??= new PointTask();
                    elementaryTask.PointTask.Point ??= new UserPoint();
                    elementaryTask.PointTask.Point.X =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingPointY:
                    elementaryTask.PointTask.Point.Y =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingPointZ:
                    elementaryTask.PointTask.Point.Z =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLineStartX:
                    elementaryTask.PointTask ??= new PointTask();
                    elementaryTask.PointTask.Line ??= new Line();
                    elementaryTask.PointTask.Line.XStart =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLineStartY:
                    elementaryTask.PointTask.Line.YStart =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLineStartZ:
                    elementaryTask.PointTask.Line.ZStart =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLineEndX:
                    elementaryTask.PointTask.Line.XEnd =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLineEndY:
                    elementaryTask.PointTask.Line.YEnd =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLineEndZ:
                    elementaryTask.PointTask.Line.ZEnd =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingLength:
                    elementaryTask.PointTask ??= new PointTask();
                    elementaryTask.PointTask.Line ??= new Line();
                    elementaryTask.PointTask.Line.Length =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingRadius:
                    elementaryTask.PointTask ??= new PointTask();
                    elementaryTask.PointTask.Arc ??= new Arc();
                    elementaryTask.PointTask.Arc.ArcRadius =
                        Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    continue;
                case ControllingCut:
                case ControllingExtrusioan:
                    elementaryTask.TridimensionalOperation ??= new TridimensionalOperation();
                    elementaryTask.TridimensionalOperation.Depth =  Convert.ToDecimal(elementaryTaskNode.InnerText, CultureInfo.InvariantCulture);
                    break;
            }

        return elementaryTask;
    }

    private static BaseTask BaseTaskRead(XmlNode element)
    {
        var baseTask = new BaseTask();
        if (element.Attributes != null)
            foreach (XmlAttribute attribute in element.Attributes)
                switch (attribute.Name)
                {
                    case ControllingId:
                        baseTask.Id = Convert.ToUInt32(attribute.Value);
                        continue;
                    case ControllingMethodName:
                        baseTask.MethodName = attribute.Value;
                        continue;
                }
        
        foreach (XmlElement baseTaskNode in element.ChildNodes)
            switch (baseTaskNode.Name)
            {
                case ControllingTaskName:
                    baseTask.TaskName = baseTaskNode.InnerText;
                    continue;
                case ControllingTaskContent:
                    baseTask.TaskContent = baseTaskNode.InnerText;
                    continue;
                case ControllingTaskTrueResult:
                    baseTask.TaskTrueResult = baseTaskNode.InnerText;
                    continue;
                case ControllingTaskFalseResult:
                    baseTask.TaskFalseResult = baseTaskNode.InnerText;
                    continue;
                case ControllingElementaryTask:
                    baseTask.ElementaryTasks ??= new List<ElementaryTask>();
                    baseTask.ElementaryTasks.Add(ElementaryTaskRead(baseTaskNode));
                    continue;
                case ControllingBaseTask:
                    baseTask.BaseTasks ??= new List<BaseTask>();
                    baseTask.BaseTasks.Add(BaseTaskRead(baseTaskNode));
                    continue;
                case ControllingSequenceTxt:
                    baseTask.Sequence = baseTaskNode.InnerText.Split(new[] { ", " }, StringSplitOptions.None)
                        .ToList();
                    continue;
            }

        return baseTask;
    }

    private static DerivedTask DerivedTaskRead(XmlNode element)
    {
        var derivedTask = new DerivedTask();
        if (element.Attributes != null)
            foreach (XmlAttribute attribute in element.Attributes)
                switch (attribute.Name)
                {
                    case ControllingId:
                        derivedTask.Id = Convert.ToUInt32(attribute.Value);
                        continue;
                    case ControllingMethodName:
                        derivedTask.MethodName = attribute.Value;
                        continue;
                }

        foreach (XmlElement derivedTaskNode in element.ChildNodes)
            switch (derivedTaskNode.Name)
            {
                case ControllingTaskName:
                    derivedTask.TaskName = derivedTaskNode.InnerText;
                    continue;
                case ControllingTaskContent:
                    derivedTask.TaskContent = derivedTaskNode.InnerText;
                    continue;
                case ControllingTaskTrueResult:
                    derivedTask.TaskTrueResult = derivedTaskNode.InnerText;
                    continue;
                case ControllingTaskFalseResult:
                    derivedTask.TaskFalseResult = derivedTaskNode.InnerText;
                    continue;
                case ControllingSequenceTxt:
                    derivedTask.Sequence = derivedTaskNode.InnerText.Split(new[] { ", " }, StringSplitOptions.None)
                        .ToList();
                    continue;
                case ControllingElementaryTask:
                    derivedTask.ElementaryTasks ??= new List<ElementaryTask>();
                    derivedTask.ElementaryTasks.Add(ElementaryTaskRead(derivedTaskNode));
                    continue;
                case ControllingDerivedTask:
                    derivedTask.DerivedTasks ??= new List<DerivedTask>();
                    derivedTask.DerivedTasks.Add(DerivedTaskRead(derivedTaskNode));
                    continue;
                case ControllingBaseTask:
                    derivedTask.BaseTasks ??= new List<BaseTask>();
                    derivedTask.BaseTasks.Add(BaseTaskRead(derivedTaskNode));
                    continue;
            }

        return derivedTask;
    }

    /// <summary>
    ///     Метод извлечения данных из XML файла
    /// </summary>
    /// <param name="fileName">Наименование файла</param>
    /// <returns>Возвращает список производных задач</returns>
    public static List<DerivedTask> ReadDerivedFile(string fileName)
    {
        _document = new XmlDocument();
        _document.Load(ControllingPath + fileName + ".xml");
        var elements = _document.DocumentElement;
        return elements is null ? null : (from XmlElement element in elements select DerivedTaskRead(element)).ToList();
    }
}