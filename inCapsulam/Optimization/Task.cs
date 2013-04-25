using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using info.lundin.math;
using System.Collections;
using System.Threading;
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using inCapsulam.Optimization;
using inCapsulam.Optimization.Methods;
using inCapsulam.Optimization.Targets;

namespace inCapsulam.Optimization
{
    [Serializable()]
    public class Task
    {
        public const short TargetType_UserDefinedFunction = 0;
        public const short TargetType_PreDefinedFunction = 1;
        public const short TargetType_JavaScriptCode = 2;

        public int TimesToRun = 1;

        public BlackBox Target = null;

        public GeneticApproachMethod.Settings ga_Settings = new GeneticApproachMethod.Settings();

        public GeneticApproachMethod.Process ga_Process;

        public BlackBox[] Constraints = null;

        public bool[] IsEquality = null;
        
        public short TargetType;

        public double[] PointOfMinimum;

        public double[] Solve()
        {
            ga_Process = new GeneticApproachMethod.Process(this, ga_Settings);
            return ga_Process.RunToTheEnd();
        }

        public double EstimatePoint(double[] point)
        {
            double e = 0;
            if (PointOfMinimum == null) return Double.PositiveInfinity;
            for (int i = 0; i < point.Length; i++)
            {
                e += Math.Pow(point[i] - PointOfMinimum[i], 2);
            }
            e = Math.Sqrt(e) / point.Length;
            return e;
        }

        public string[] CollectStatistics()
        {
            string stats = "";
            string data = "";

            double averageValueBest = 0;
            double averageValueAverage = 0;
            double averageIterations = 0;
            double averageParentsCount = 0;
            double averageFeasiblesCount = 0;
            double averageTimeElapsed = 0;
            double averageConstrainedOptimizationQuality = 0;
            double successes = 0;
            for (int i = 0; i < TimesToRun; i++)
            {
                ga_Process = new GeneticApproachMethod.Process(this, ga_Settings);
                ga_Process.RunToTheEnd();
                data += GetStatisticsData();
                averageFeasiblesCount += ga_Process.Logging_FeasiblesCount.Last();
                averageValueAverage += ga_Process.Logging_AverageValue.Last();
                averageValueBest += ga_Process.Logging_BestValue.Last();
                averageIterations += ga_Process.Logging_BestFitness.Count;
                averageParentsCount += ga_Process.Logging_ParentsCount.Last();
                averageTimeElapsed += ga_Process.Logging_TimeElapsed;
                averageConstrainedOptimizationQuality += EstimatePoint(ga_Process.Logging_BestSolution.Last());
                if (Math.Abs(ga_Process.Logging_BestValue.Last()) < ga_Settings.Precision * 5) successes++;
            }
            averageParentsCount /= TimesToRun;
            averageIterations /= TimesToRun;
            averageValueBest /= TimesToRun;
            averageValueAverage /= TimesToRun;
            averageFeasiblesCount /= TimesToRun;
            averageTimeElapsed /= TimesToRun;
            averageConstrainedOptimizationQuality /= TimesToRun;
            successes /= TimesToRun;
            successes *= 100;
            averageParentsCount = Math.Round(averageParentsCount, 5);
            averageIterations = Math.Round(averageIterations, 5);
            averageValueBest = Math.Round(averageValueBest, 5);
            averageValueAverage = Math.Round(averageValueAverage, 5);
            averageFeasiblesCount = Math.Round(averageFeasiblesCount, 5);
            averageTimeElapsed = Math.Round(averageTimeElapsed, 5);
            averageConstrainedOptimizationQuality = Math.Round(averageConstrainedOptimizationQuality, 5);
            stats += GetSettingsInfo();
            stats += "\n\nРезультат усреднения по "+TimesToRun+" запускам:";
            stats += "\n\nНадёжность при экстремуме в нуле (интервал: " +ga_Settings.Precision*5+"):\n\t" + successes + "%";
            stats += "\nУсредненное расстояние до точки минимума:\n\t" + averageConstrainedOptimizationQuality;
            stats += "\nУсредненное значение ЦФ лучшего решения:\n\t" + averageValueBest;
            stats += "\nУсредненное среднее значение ЦФ:\n\t" + averageValueAverage;
            stats += "\nУсредненное количество поколений:\n\t" + averageIterations;
            stats += "\nУсредненное количество родителей в последнем поколении:\n\t" + averageParentsCount;
            stats += "\nУсредненное количество пригодных решений в последнем поколении:\n\t" + averageFeasiblesCount;
            stats += "\nУсредненное время поиска:\n\t" + averageTimeElapsed;
            return new string[2] { stats, data };
        }

        public static string GetStatisticsHeader()
        {
            string data = "";

            data += "Количество бит" + "\t";
            data += "Селекция потомков" + "\t";
            data += "Скрещивание" + "\t";
            data += "Степень элитизма" + "\t";
            data += "Количество поколений" + "\t";
            data += "Степень мутации" + "\t";
            data += "Тип мутации" + "\t";
            data += "Селекция родителей" + "\t";
            data += "Штрафная функция" + "\t";
            data += "Размер популяции" + "\t";
            data += "Степень пост-оптимизации" + "\t";
            data += "Тип пост-оптимизации" + "\t";
            data += "Тип пост-селекции" + "\t";
            data += "Размер турнира" + "\t";
            data += "Используется селеция потомков" + "\t";
            data += "Используется элитизм" + "\t";
            data += "Используется грей-кодирование" + "\t";
            data += "Полученное значение ЦФ" + "\t";
            data += "Расстояние до точки минимума" + "\t";
            data += "Количество потоков вычислений" + "\t";
            data += "Затраченное время (мс)";
            data += "\n";

            return data;
        }

        public string GetStatisticsData()
        {
            string data = "";

            data += ga_Process.current.BitCount + "\t";
            data += ga_Process.current.ChildSelectionMode + "\t";
            data += ga_Process.current.CrossoverMode + "\t";
            data += ga_Process.current.ElitismNumber + "\t";
            data += ga_Process.current.IterationsMaxNumber + "\t";
            data += ga_Process.current.MutationCoefficient + "\t";
            data += ga_Process.current.MutationMode + "\t";
            data += ga_Process.current.ParentSelectionMode + "\t";
            data += ga_Process.current.PenaltyMode + "\t";
            data += ga_Process.current.PopulationCount + "\t";
            data += ga_Process.current.PostOptimizationCoefficient + "\t";
            data += ga_Process.current.PostOptimizationMode + "\t";
            data += ga_Process.current.PostSelectionMode + "\t";
            data += ga_Process.current.TournamentSize + "\t";
            data += (ga_Process.current.UseChildSelection ? "1" : "0") + "\t";
            data += (ga_Process.current.UseElitism ? "1" : "0") + "\t";
            data += (ga_Process.current.UseGreyCode ? "1" : "0") + "\t";
            data += ga_Process.Logging_BestValue.Last() + "\t";
            data += EstimatePoint(ga_Process.Logging_BestSolution.Last()) + "\t";
            data += ga_Process.current.ThreadsCount + "\t";
            data += ga_Process.Logging_TimeElapsed;
            data += "\n";

            return data;
        }

        public bool CheckConstraint(string expression)
        {
            UserDefinedTarget constraint = new UserDefinedTarget(expression, Target.Parameters.Length);
            try
            {
                constraint.TargetFunction();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AddConstraint(string expression, bool isEquality = false)
        {
            try
            {
                if (!CheckConstraint(expression)) return false;
                if (object.Equals(Constraints, null)) Constraints = new BlackBox[1];
                if (object.Equals(IsEquality, null)) IsEquality = new bool[1];
                else
                {
                    BlackBox[] temp = Constraints;
                    bool[] tempBoolean = IsEquality;
                    Constraints = new BlackBox[Constraints.Length + 1];
                    IsEquality = new bool[IsEquality.Length + 1];
                    for (int i = 0; i < temp.Length; i++)
                    {
                        Constraints[i] = temp[i];
                        IsEquality[i] = tempBoolean[i];
                    }
                }
                Constraints[Constraints.Length - 1] = new UserDefinedTarget(expression, Target.Parameters.Length);
                IsEquality[IsEquality.Length - 1] = isEquality;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemoveConstraint(int id)
        {
            if (object.Equals(Constraints, null)) return;
            if (object.Equals(IsEquality, null)) return;
            if (id < 0) return;
            BlackBox[] temp = Constraints;
            Constraints = new BlackBox[Constraints.Length - 1];
            bool[] tempBoolean = IsEquality;
            IsEquality = new bool[IsEquality.Length - 1];
            int k = 0;
            for (int i = 0; i < temp.Length; i++)
            {
                if (i != id)
                {
                    Constraints[k] = temp[i];
                    IsEquality[k] = tempBoolean[i];
                    k++;
                }
            }
        }

        public bool EditConstraint(int id, string expression, bool isEquality = false)
        {
            if (object.Equals(Constraints, null)) return false;
            if (object.Equals(IsEquality, null)) return false;
            if (id < 0) return false;
            try
            {
                if (!CheckConstraint(expression)) return false;

                BlackBox[] temp = Constraints;
                Constraints = new BlackBox[Constraints.Length];
                bool[] tempBoolean = IsEquality;
                IsEquality = new bool[IsEquality.Length];

                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == id)
                    {
                        IsEquality[i] = isEquality;
                        Constraints[i] = new UserDefinedTarget(expression, Target.Parameters.Length);
                        continue;
                    }
                    Constraints[i] = temp[i];
                    IsEquality[i] = tempBoolean[i];
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetInfo()
        {
            if (object.Equals(ga_Process, null)) return "";
            if (ga_Process.Logging_BestFitness.Count == 0)
            {
                return "Алгоритм не нашёл достаточно хороших решений на первой итерации, попробуйте уменьшить начальную область поиска.";
            }
            string r = "";
            GeneticApproachMethod.Process p = ga_Process;
            r = "Результаты исследования от " + DateTime.Now.ToLongDateString() + "\n\n";

            r += GetSettingsInfo() + "\n\n";

            r += "Минимальное значение:\n\t" + Various.DoubleToString(
                p.Logging_BestValue.Last(),
                5) +
                "\n";
            r += "Лучшая точка:\n\t";
            for (int i = 0; i < Target.Parameters.Length; i++)
            {
                r += p.Logging_BestSolution.Last()[i];
                if (i < Target.Parameters.Length - 1) r += "\n\t";
            }
            r += "\nРасстояние до точки минимума:\n\t";
            r += EstimatePoint(p.Logging_BestSolution.Last());
            r += "\n\n";
            r += "Среднее значение (последняя итерация):\n\t" +
                Various.DoubleToString(
                p.Logging_AverageValue.Last(),
                ga_Settings.DigitsAfterPoint) + "\n";
            r += "Всего итераций:\n\t" +
                p.Logging_BestSolution.Count + "\n";
            r += "Родителей на последней итерации:\n\t" +
                p.Logging_ParentsCount.Last() + "\n";
            r += "Допустимых решений на последней итерации:\n\t" +
                p.Logging_FeasiblesCount.Last() + "\n";
            r += "Вычислений целевой функции:\n\t" +
                p.Logging_ObjectiveFunctionCalculations + "\n";
            r += "Затраченное время (мс):\n\t" +
                p.Logging_TimeElapsed + "\n";
            return r;
        }

        public string GetSettingsInfo()
        {
            string r = "";

            r += "Количество переменных:\n\t" + Target.Parameters.Length + "\n";
            r += "Исследуемая проблема:\n\t" + ((ITarget)Target).Description;
            r += "\n";
            if (!object.Equals(Constraints, null))
            {
                r += "Cписок ограничений:\n\t";
                for (int i = 0; i < Constraints.Length; i++)
                {
                    if (typeof(UserDefinedTarget) == Constraints[i].GetType())
                    {
                        r += ((UserDefinedTarget)Constraints[i]).expression;
                        if (IsEquality[i]) r += " = 0\n\t";
                        else r += " >= 0\n\t";
                    }
                    else if (typeof(RectanglesTarget.Constraint_NoIntersection) == Constraints[i].GetType())
                    {
                        double value = ((RectanglesTarget.Constraint_NoIntersection)Constraints[i]).Calculate(ga_Process.Logging_BestSolution.Last());
                        r += "Площадь пересечения: " + value + "\n\t";
                    }
                }
            }
            r += "\n";

            r += "Настройки ГА:\n";

            r += "\nШтрафная функция: ";
            if (ga_Settings.PenaltyMode == GeneticApproachMethod.Settings.PenaltyAdaptive)
            {
                r += "Адаптивная";
            }
            else if (ga_Settings.PenaltyMode == GeneticApproachMethod.Settings.PenaltyDynamic)
            {
                r += "Динамическая";
            }
            else if (ga_Settings.PenaltyMode == GeneticApproachMethod.Settings.PenaltyConstraint)
            {
                r += "Минимизация ограничений";
            }
            else if (ga_Settings.PenaltyMode == GeneticApproachMethod.Settings.PenaltyEmpty)
            {
                r += "Не реализована";
            }

            r += "\nМутация: ";
            if (ga_Settings.MutationMode == GeneticApproachMethod.Settings.MutationBoolean)
            {
                r += "На булевых строках";
            }
            else if (ga_Settings.MutationMode == GeneticApproachMethod.Settings.MutationReal)
            {
                r += "Вещественная";
            }

            r += "\nСелекция (родители): ";
            if (ga_Settings.ParentSelectionMode == GeneticApproachMethod.Settings.SelectionProportional)
            {
                r += "Пропорциональная";
            }
            else if (ga_Settings.ParentSelectionMode == GeneticApproachMethod.Settings.SelectionRange)
            {
                r += "Ранговая";
            }
            else if (ga_Settings.ParentSelectionMode == GeneticApproachMethod.Settings.SelectionTournament)
            {
                r += "Турнирная";
            }

            r += "\nСелекция (потомки): ";
            if (ga_Settings.UseChildSelection)
            {
                if (ga_Settings.ChildSelectionMode == GeneticApproachMethod.Settings.SelectionProportional)
                {
                    r += "Пропорциональная";
                }
                else if (ga_Settings.ChildSelectionMode == GeneticApproachMethod.Settings.SelectionRange)
                {
                    r += "Ранговая";
                }
                else if (ga_Settings.ChildSelectionMode == GeneticApproachMethod.Settings.SelectionTournament)
                {
                    r += "Турнирная";
                }
            }
            else
            {
                r += "Не реализована";
            }

            r += "\nСкрещивание: ";
            if (ga_Settings.CrossoverMode == GeneticApproachMethod.Settings.CrossoverReal)
            {
                r += "Вещественное";
            }
            else if (ga_Settings.CrossoverMode == GeneticApproachMethod.Settings.CrossoverTwoPoints)
            {
                r += "Двухточечное";
            }
            else if (ga_Settings.CrossoverMode == GeneticApproachMethod.Settings.CrossoverUniform)
            {
                r += "Равномерное";
            }

            r += "\nПост-селекция: ";
            if (ga_Settings.PostSelectionMode == GeneticApproachMethod.Settings.PostSelectionBest)
            {
                r += "Лучшие";
            }
            else if (ga_Settings.PostSelectionMode == GeneticApproachMethod.Settings.PostSelectionHalfOldHalfNew)
            {
                r += "Родители и потомки поровну";
            }
            else if (ga_Settings.PostSelectionMode == GeneticApproachMethod.Settings.PostSelectionNew)
            {
                r += "Только потомки";
            }

            r += "\nРазмер популяции: " + ga_Settings.PopulationCount;
            r += "\nКоэффициент мутации: " + ga_Settings.MutationCoefficient;
            r += "\nРазмер турнира: " + ga_Settings.TournamentSize;
            r += "\nЭлитизм: " + (ga_Settings.UseElitism ? "Да" : "Нет");
            r += "\nШирина сетки дискретизации: " + ga_Settings.Precision;
            r += "\nБит на параметр: " + ga_Settings.BitCount;
            r += "\nГрей-кодирование: " + (ga_Settings.UseGreyCode ? "Да" : "Нет");
            r += "\nПост-оптимизация: ";
            if (ga_Settings.PostOptimizationMode == GeneticApproachMethod.Settings.PostOptimizationGradualCorrection)
            {
                r += "Многошаговый метод";
            }
            else if (ga_Settings.PostOptimizationMode == GeneticApproachMethod.Settings.PostOptimizationOneStepCorrection)
            {
                r += "Одношаговый метод";
            }
            r += "\nКоэффициент пост-оптимизации: " + ga_Settings.PostOptimizationCoefficient;
            r += "\nКоличество потоков вычислений: " + ga_Settings.ThreadsCount;
            return r;
        }

        private static string UTF8ByteArrayToString(byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            string constructedString = encoding.GetString(characters);
            return (constructedString);
        }

        private static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        public string SerializeToXml()
        {
            try
            {
                string xmlString = null;
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xs = new XmlSerializer(typeof(Task));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xs.Serialize(xmlTextWriter, this);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                xmlString = UTF8ByteArrayToString(memoryStream.ToArray());
                return xmlString;
            }
            catch (Exception ex)
            {
                return ex.ToString() + "\r\n\r\n" + ex.StackTrace;
            }
        }

        public static Task DeserializeToObject(string xml)
        {
            try
            {
                XmlSerializer xs = new XmlSerializer(typeof(Task));
                MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml));
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                return (Task)xs.Deserialize(memoryStream);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString() + "\r\n\r\n" + ex.StackTrace);
                return new Task();
            }
        }
    }
}
