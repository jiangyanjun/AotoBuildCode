using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Millennials.Creator.BaseClass
{
    public static class SolutionBaseClass
    {
        public const string baseClassTemplate =

@"Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio 2012
{0}
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{1}
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
EndGlobal
";

        public const string baseProjectTemplate =
        @"
Project(""{0}"") = ""{1}"", ""{2}"", ""{3}""
EndProject";

        public const string baseGlobalSectionTemplate =
        @"
{0}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
{0}.Debug|Any CPU.Build.0 = Debug|Any CPU
{0}.Release|Any CPU.ActiveCfg = Release|Any CPU
{0}.Release|Any CPU.Build.0 = Release|Any CPU";
    }
}