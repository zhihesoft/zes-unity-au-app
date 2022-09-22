using System.Linq;
using UnityEditor;

namespace Au.Builders
{
    public class BuildRunner
    {
        public static bool Run(params BuildTask[] task)
        {
            return Run(EditorUserBuildSettings.activeBuildTarget, task);
        }

        public static bool Run(BuildTarget target, params BuildTask[] tasks)
        {
            var runner = new BuildRunner(target);
            return runner.RunTasks(tasks);
        }

        private BuildRunner(BuildTarget target)
        {
            this.target = target;
        }

        public BuildTarget target { get; private set; }

        public bool RunTasks(BuildTask[] tasks)
        {
            return tasks.All(i => i.Build(this));
        }
    }
}
