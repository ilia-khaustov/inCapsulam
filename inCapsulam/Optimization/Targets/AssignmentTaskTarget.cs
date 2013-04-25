using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using inCapsulam.Optimization;

namespace inCapsulam
{
    [Serializable()]
    public class AssignmentTaskTarget : BlackBox
    {
        public double[] Efficiency;
        int _employeesCount;
        int _tasksCount;

        public int MaxEmployeesForTask;
        public int MaxTasksForEmployees;
        public int MaxValueForTask;
        public int MaxValueForEmployee;

        public int EmployeesCount
        {
            get
            {
                return _employeesCount;
            }
            set
            {
                _employeesCount = value;
                CalculateEfficiency();
            }
        }
        public int TasksCount
        {
            get
            {
                return _tasksCount;
            }
            set
            {
                _tasksCount = value;
                CalculateEfficiency();
            }
        }

        public AssignmentTaskTarget()
        {
            Parameters = new double[1];
        }

        private void CalculateEfficiency()
        {
            Efficiency = new double[EmployeesCount * TasksCount];
            for (int i = 0; i < Efficiency.Length; i++)
            {
                if (1 == 1)
                {
                    Efficiency[i] = Program.rndm.NextDouble();
                }
            }
            Parameters = new double[Efficiency.Length];
        }

        public override double TargetFunction()
        {
            double value = 0;
            for (int i = 0; i < Efficiency.Length; i++)
            {
                value += Efficiency[i] * Parameters[i];
            }
            return -value;
        }

        public class Constraint_MaxEmployeesForTask : BlackBox
        {
            AssignmentTaskTarget Target;
            int Value;
            int TaskId;

            public Constraint_MaxEmployeesForTask(AssignmentTaskTarget target, int value, int taskId)
            {
                Target = target;
                Value = value;
                TaskId = taskId;
            }

            public override double TargetFunction()
            {
                double diff = 0;
                double valueFound = 0;
                for (int i = TaskId * Target.EmployeesCount; i < TaskId * Target.EmployeesCount + Target.EmployeesCount; i++)
                {
                    if (Parameters[i] > 0) valueFound++;
                }
                diff = Value - valueFound;
                return diff * 100;
            }
        }

        public class Constraint_MaxTasksForEmployee : BlackBox
        {
            AssignmentTaskTarget Target;
            int Value;
            int EmployeeId;

            public Constraint_MaxTasksForEmployee(AssignmentTaskTarget target, int value, int employeeId)
            {
                Target = target;
                Value = value;
                EmployeeId = employeeId;
            }

            public override double TargetFunction()
            {
                double diff = 0;
                double valueFound = 0;
                for (int i = EmployeeId; i < Parameters.Length; i += Target.EmployeesCount)
                {
                    if (Parameters[i] > 0) valueFound++;
                }
                diff = Value - valueFound;
                return diff * 100;
            }
        }

        public class Constraint_MaxValueForTask : BlackBox
        {
            AssignmentTaskTarget Target;
            double Value;
            int TaskId;

            public Constraint_MaxValueForTask(AssignmentTaskTarget target, double value, int taskId)
            {
                Target = target;
                Value = value;
                TaskId = taskId;
            }

            public override double TargetFunction()
            {
                double diff = 0;
                double valueFound = 0;
                for (int i = TaskId * Target.EmployeesCount; i < TaskId * Target.EmployeesCount + Target.EmployeesCount; i++)
                {
                    valueFound += Parameters[i];
                }
                diff = Value - valueFound;
                return diff;
            }
        }

        public class Constraint_MaxValueForEmployee : BlackBox
        {
            AssignmentTaskTarget Target;
            double Value;
            int EmployeeId;

            public Constraint_MaxValueForEmployee(AssignmentTaskTarget target, double value, int employeeId)
            {
                Target = target;
                Value = value;
                EmployeeId = employeeId;
            }

            public override double TargetFunction()
            {
                double diff = 0;
                double valueFound = 0;
                for (int i = EmployeeId; i < Parameters.Length; i += Target.EmployeesCount)
                {
                    valueFound += Parameters[i];
                }
                diff = Value - valueFound;
                return diff;
            }
        }
    }
}
